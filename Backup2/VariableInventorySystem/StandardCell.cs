// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.StandardCell
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
namespace VariableInventorySystem;

public class StandardCell : VariableInventoryCell
{
  [SerializeField]
  private Vector2 defaultCellSize;
  [SerializeField]
  private Vector2 margineSpace;
  [SerializeField]
  private RectTransform sizeRoot;
  [SerializeField]
  private RectTransform target;
  [SerializeField]
  private Graphic background;
  [SerializeField]
  private RawImage cellImage;
  [SerializeField]
  private Graphic highlight;
  [SerializeField]
  private StandardButton button;
  protected bool isSelectable = true;
  protected IVariableInventoryAsset currentImageAsset;

  public override Vector2 DefaultCellSize => this.defaultCellSize;

  public override Vector2 MargineSpace => this.margineSpace;

  protected override IVariableInventoryCellActions ButtonActions
  {
    get => (IVariableInventoryCellActions) this.button;
  }

  protected virtual StandardAssetLoader Loader { get; set; }

  public Vector2 GetCellSize()
  {
    IVariableInventoryCellData cellData1 = this.CellData;
    double x = (cellData1 != null ? (double) cellData1.Width : 1.0) * ((double) this.defaultCellSize.x + (double) this.margineSpace.x) - (double) this.margineSpace.x;
    IVariableInventoryCellData cellData2 = this.CellData;
    double y = (double) ((cellData2 != null ? (float) cellData2.Height : 1f) * (this.defaultCellSize.y + this.margineSpace.y) - this.margineSpace.y);
    return new Vector2((float) x, (float) y);
  }

  public Vector2 GetRotateCellSize()
  {
    IVariableInventoryCellData cellData = this.CellData;
    int num = cellData != null ? (cellData.IsRotate ? 1 : 0) : 0;
    Vector2 cellSize = this.GetCellSize();
    if (num != 0)
    {
      float x = cellSize.x;
      cellSize.x = cellSize.y;
      cellSize.y = x;
    }
    return cellSize;
  }

  public override void SetSelectable(bool value)
  {
    this.ButtonActions.SetActive(value);
    this.isSelectable = value;
  }

  public virtual void SetHighLight(bool value) => this.highlight.gameObject.SetActive(value);

  protected override void OnApply()
  {
    this.SetHighLight(false);
    this.target.gameObject.SetActive(this.CellData != null);
    this.ApplySize();
    if (this.CellData == null)
    {
      this.cellImage.gameObject.SetActive(false);
      this.background.gameObject.SetActive(false);
    }
    else
    {
      if (this.currentImageAsset != this.CellData.ImageAsset)
      {
        this.currentImageAsset = this.CellData.ImageAsset;
        this.cellImage.gameObject.SetActive(false);
        if (this.Loader == null)
          this.Loader = new StandardAssetLoader();
        this.StartCoroutine(this.Loader.LoadAsync(this.CellData.ImageAsset, (Action<Texture2D>) (tex =>
        {
          this.cellImage.texture = (Texture) tex;
          this.cellImage.gameObject.SetActive(true);
        })));
      }
      this.background.gameObject.SetActive(this.isSelectable);
    }
  }

  protected virtual void ApplySize()
  {
    this.sizeRoot.sizeDelta = this.GetRotateCellSize();
    this.target.sizeDelta = this.GetCellSize();
    RectTransform target = this.target;
    Vector3 forward = Vector3.forward;
    IVariableInventoryCellData cellData = this.CellData;
    double num = (cellData != null ? (cellData.IsRotate ? 1 : 0) : 0) != 0 ? 90.0 : 0.0;
    Vector3 vector3 = forward * (float) num;
    target.localEulerAngles = vector3;
  }
}
