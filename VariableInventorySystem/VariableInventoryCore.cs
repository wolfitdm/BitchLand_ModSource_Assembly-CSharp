// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.VariableInventoryCore
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

#nullable disable
namespace VariableInventorySystem;

public abstract class VariableInventoryCore : 
  MonoBehaviour,
  IBeginDragHandler,
  IEventSystemHandler,
  IDragHandler,
  IEndDragHandler
{
  protected IVariableInventoryCell stareCell;
  protected IVariableInventoryCell effectCell;
  private bool? originEffectCellRotate;
  private Vector2 cursorPosition;

  protected List<IVariableInventoryView> InventoryViews { get; set; } = new List<IVariableInventoryView>();

  protected virtual GameObject CellPrefab { get; set; }

  protected virtual RectTransform EffectCellParent { get; set; }

  public virtual void Initialize()
  {
    this.effectCell = UnityEngine.Object.Instantiate<GameObject>(this.CellPrefab, (Transform) this.EffectCellParent).GetComponent<IVariableInventoryCell>();
    this.effectCell.RectTransform.gameObject.SetActive(false);
    this.effectCell.SetSelectable(false);
  }

  public virtual void AddInventoryView(IVariableInventoryView variableInventoryView)
  {
    this.InventoryViews.Add(variableInventoryView);
    variableInventoryView.SetCellCallback(new Action<IVariableInventoryCell>(this.OnCellClick), new Action<IVariableInventoryCell>(this.OnCellOptionClick), new Action<IVariableInventoryCell>(this.OnCellEnter), new Action<IVariableInventoryCell>(this.OnCellExit));
  }

  public virtual void RemoveInventoryView(IVariableInventoryView variableInventoryView)
  {
    this.InventoryViews.Remove(variableInventoryView);
  }

  public virtual void OnBeginDrag(PointerEventData eventData)
  {
    if (eventData.button != PointerEventData.InputButton.Left)
      return;
    foreach (IVariableInventoryView inventoryView in this.InventoryViews)
      inventoryView.OnPrePick(this.stareCell);
    IVariableInventoryCellData cellData = this.stareCell?.CellData;
    if (!this.InventoryViews.Any<IVariableInventoryView>((Func<IVariableInventoryView, bool>) (x => x.OnPick(this.stareCell))))
      return;
    this.effectCell.RectTransform.gameObject.SetActive(true);
    this.effectCell.Apply(cellData);
  }

  public virtual void OnDrag(PointerEventData eventData)
  {
    if (this.effectCell?.CellData == null)
      return;
    foreach (IVariableInventoryView inventoryView in this.InventoryViews)
      inventoryView.OnDrag(this.stareCell, this.effectCell, eventData);
    RectTransformUtility.ScreenPointToLocalPointInRectangle(this.EffectCellParent, eventData.position, eventData.enterEventCamera, out this.cursorPosition);
    (int, int) rotateSize = this.GetRotateSize(this.effectCell.CellData);
    this.effectCell.RectTransform.localPosition = (Vector3) (this.cursorPosition + new Vector2((float) ((double) -(rotateSize.Item1 - 1) * (double) this.effectCell.DefaultCellSize.x * 0.5), (float) ((double) (rotateSize.Item2 - 1) * (double) this.effectCell.DefaultCellSize.y * 0.5)));
  }

  private (int, int) GetRotateSize(IVariableInventoryCellData cell)
  {
    return (cell.IsRotate ? cell.Height : cell.Width, cell.IsRotate ? cell.Width : cell.Height);
  }

  public virtual void OnEndDrag(PointerEventData eventData)
  {
    if (this.effectCell.CellData == null)
      return;
    bool isDroped = this.InventoryViews.Any<IVariableInventoryView>((Func<IVariableInventoryView, bool>) (x => x.OnDrop(this.stareCell, this.effectCell)));
    if (!isDroped && this.originEffectCellRotate.HasValue)
    {
      this.effectCell.CellData.IsRotate = this.originEffectCellRotate.Value;
      this.effectCell.Apply(this.effectCell.CellData);
      this.originEffectCellRotate = new bool?();
    }
    foreach (IVariableInventoryView inventoryView in this.InventoryViews)
      inventoryView.OnDroped(isDroped);
    this.effectCell.RectTransform.gameObject.SetActive(false);
    this.effectCell.Apply((IVariableInventoryCellData) null);
  }

  public virtual void SwitchRotate()
  {
    if (this.effectCell.CellData == null)
      return;
    if (!this.originEffectCellRotate.HasValue)
      this.originEffectCellRotate = new bool?(this.effectCell.CellData.IsRotate);
    this.effectCell.CellData.IsRotate = !this.effectCell.CellData.IsRotate;
    this.effectCell.Apply(this.effectCell.CellData);
    (int, int) rotateSize = this.GetRotateSize(this.effectCell.CellData);
    this.effectCell.RectTransform.localPosition = (Vector3) (this.cursorPosition + new Vector2((float) ((double) -(rotateSize.Item1 - 1) * (double) this.effectCell.DefaultCellSize.x * 0.5), (float) ((double) (rotateSize.Item2 - 1) * (double) this.effectCell.DefaultCellSize.y * 0.5)));
    foreach (IVariableInventoryView inventoryView in this.InventoryViews)
      inventoryView.OnSwitchRotate(this.stareCell, this.effectCell);
  }

  protected virtual void OnCellClick(IVariableInventoryCell cell)
  {
  }

  protected virtual void OnCellOptionClick(IVariableInventoryCell cell)
  {
  }

  protected virtual void OnCellEnter(IVariableInventoryCell cell)
  {
    this.stareCell = cell;
    foreach (IVariableInventoryView inventoryView in this.InventoryViews)
      inventoryView.OnCellEnter(this.stareCell, this.effectCell);
  }

  protected virtual void OnCellExit(IVariableInventoryCell cell)
  {
    foreach (IVariableInventoryView inventoryView in this.InventoryViews)
      inventoryView.OnCellExit(this.stareCell);
    this.stareCell = (IVariableInventoryCell) null;
  }
}
