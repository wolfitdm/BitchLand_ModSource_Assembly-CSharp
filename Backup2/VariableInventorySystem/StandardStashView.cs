// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.StandardStashView
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
namespace VariableInventorySystem;

public class StandardStashView : MonoBehaviour, IVariableInventoryView
{
  [SerializeField]
  private GameObject cellPrefab;
  [SerializeField]
  private ScrollRect scrollRect;
  [SerializeField]
  private GridLayoutGroup gridLayoutGroup;
  [SerializeField]
  private Graphic condition;
  [SerializeField]
  private RectTransform conditionTransform;
  [SerializeField]
  private RectTransform background;
  [SerializeField]
  private float holdScrollPadding;
  [SerializeField]
  private float holdScrollRate;
  [SerializeField]
  private Color defaultColor;
  [SerializeField]
  private Color positiveColor;
  [SerializeField]
  private Color negativeColor;
  protected IVariableInventoryCell[] itemViews;
  protected CellCorner cellCorner;
  private int? originalId;
  private IVariableInventoryCellData originalCellData;
  private Vector3 conditionOffset;
  private Action<IVariableInventoryCell> onCellClick;
  private Action<IVariableInventoryCell> onCellOptionClick;
  private Action<IVariableInventoryCell> onCellEnter;
  private Action<IVariableInventoryCell> onCellExit;

  public StandardStashViewData StashData { get; private set; }

  public int CellCount => this.StashData.CapacityWidth * this.StashData.CapacityHeight;

  public void SetCellCallback(
    Action<IVariableInventoryCell> onCellClick,
    Action<IVariableInventoryCell> onCellOptionClick,
    Action<IVariableInventoryCell> onCellEnter,
    Action<IVariableInventoryCell> onCellExit)
  {
    this.onCellClick = onCellClick;
    this.onCellOptionClick = onCellOptionClick;
    this.onCellEnter = onCellEnter;
    this.onCellExit = onCellExit;
  }

  public virtual void Apply(IVariableInventoryViewData data)
  {
    this.StashData = (StandardStashViewData) data;
    if (this.itemViews == null || this.itemViews.Length != this.CellCount)
    {
      this.itemViews = new IVariableInventoryCell[this.CellCount];
      for (int index = 0; index < this.CellCount; ++index)
      {
        StandardCell component = UnityEngine.Object.Instantiate<GameObject>(this.cellPrefab, this.gridLayoutGroup.transform).GetComponent<StandardCell>();
        this.itemViews[index] = (IVariableInventoryCell) component;
        component.transform.SetAsFirstSibling();
        component.SetCellCallback(this.onCellClick, this.onCellOptionClick, this.onCellEnter, this.onCellExit, (Action<IVariableInventoryCell>) (_ => this.scrollRect.enabled = false), (Action<IVariableInventoryCell>) (_ => this.scrollRect.enabled = true));
        component.Apply((IVariableInventoryCellData) null);
      }
      this.background.SetAsFirstSibling();
      this.gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
      this.gridLayoutGroup.constraintCount = this.StashData.CapacityWidth;
      this.gridLayoutGroup.cellSize = ((IEnumerable<IVariableInventoryCell>) this.itemViews).First<IVariableInventoryCell>().DefaultCellSize;
      this.gridLayoutGroup.spacing = ((IEnumerable<IVariableInventoryCell>) this.itemViews).First<IVariableInventoryCell>().MargineSpace;
    }
    for (int index = 0; index < this.StashData.CellData.Length; ++index)
      this.itemViews[index].Apply(this.StashData.CellData[index]);
  }

  public virtual void ReApply()
  {
    if (!this.StashData.IsDirty)
      return;
    this.Apply((IVariableInventoryViewData) this.StashData);
    this.StashData.IsDirty = false;
  }

  public virtual void OnPrePick(IVariableInventoryCell stareCell)
  {
    if (stareCell?.CellData == null)
      return;
    (int num1, int num2) = this.GetRotateSize(stareCell.CellData);
    this.conditionTransform.sizeDelta = new Vector2(stareCell.DefaultCellSize.x * (float) num1, stareCell.DefaultCellSize.y * (float) num2);
  }

  public virtual bool OnPick(IVariableInventoryCell stareCell)
  {
    if (stareCell?.CellData == null)
      return false;
    int? id = this.StashData.GetId(stareCell.CellData);
    if (!id.HasValue)
      return false;
    this.originalId = id;
    this.originalCellData = stareCell.CellData;
    this.itemViews[id.Value].Apply((IVariableInventoryCellData) null);
    this.StashData.InsertInventoryItem(id.Value, (IVariableInventoryCellData) null);
    return true;
  }

  public virtual void OnDrag(
    IVariableInventoryCell stareCell,
    IVariableInventoryCell effectCell,
    PointerEventData pointerEventData)
  {
    if (stareCell == null)
      return;
    Vector2 localPosition1 = this.GetLocalPosition(this.scrollRect.viewport, pointerEventData.position, pointerEventData.enterEventCamera);
    Rect rect;
    if ((double) localPosition1.y < (double) this.scrollRect.viewport.rect.min.y + (double) this.holdScrollPadding)
    {
      float num1 = this.scrollRect.verticalNormalizedPosition * this.scrollRect.viewport.rect.height - this.holdScrollRate;
      ScrollRect scrollRect = this.scrollRect;
      double num2 = (double) num1;
      rect = this.scrollRect.viewport.rect;
      double height = (double) rect.height;
      double num3 = (double) Mathf.Clamp01((float) (num2 / height));
      scrollRect.verticalNormalizedPosition = (float) num3;
    }
    double y = (double) localPosition1.y;
    rect = this.scrollRect.viewport.rect;
    double num4 = (double) rect.max.y - (double) this.holdScrollPadding;
    if (y > num4)
    {
      double normalizedPosition = (double) this.scrollRect.verticalNormalizedPosition;
      rect = this.scrollRect.viewport.rect;
      double height1 = (double) rect.height;
      float num5 = (float) (normalizedPosition * height1) + this.holdScrollRate;
      ScrollRect scrollRect = this.scrollRect;
      double num6 = (double) num5;
      rect = this.scrollRect.viewport.rect;
      double height2 = (double) rect.height;
      double num7 = (double) Mathf.Clamp01((float) (num6 / height2));
      scrollRect.verticalNormalizedPosition = (float) num7;
    }
    Vector2 localPosition2 = this.GetLocalPosition(stareCell.RectTransform, pointerEventData.position, pointerEventData.enterEventCamera);
    Vector2 vector2_1 = new Vector2(stareCell.DefaultCellSize.x * 0.5f, (float) (-(double) stareCell.DefaultCellSize.y * 0.5));
    Vector2 vector2_2 = vector2_1;
    Vector2 vector2_3 = localPosition2 + vector2_2;
    this.conditionOffset = new Vector3(Mathf.Floor(vector2_3.x / stareCell.DefaultCellSize.x) * stareCell.DefaultCellSize.x, Mathf.Ceil(vector2_3.y / stareCell.DefaultCellSize.y) * stareCell.DefaultCellSize.y);
    int cellCorner1 = (int) this.cellCorner;
    this.cellCorner = this.GetCorner((new Vector2(vector2_3.x % stareCell.DefaultCellSize.x, vector2_3.y % stareCell.DefaultCellSize.y) - vector2_1) * 0.5f);
    (int, int) rotateSize = this.GetRotateSize(effectCell.CellData);
    Vector3 evenNumberOffset = this.GetEvenNumberOffset(rotateSize.Item1, rotateSize.Item2, stareCell.DefaultCellSize.x * 0.5f, stareCell.DefaultCellSize.y * 0.5f);
    this.conditionTransform.position = stareCell.RectTransform.position + (this.conditionOffset + evenNumberOffset) * stareCell.RectTransform.lossyScale.x;
    int cellCorner2 = (int) this.cellCorner;
    if (cellCorner1 == cellCorner2)
      return;
    this.UpdateCondition(stareCell, effectCell);
  }

  public virtual bool OnDrop(IVariableInventoryCell stareCell, IVariableInventoryCell effectCell)
  {
    if (!((IEnumerable<IVariableInventoryCell>) this.itemViews).Any<IVariableInventoryCell>((Func<IVariableInventoryCell, bool>) (item => item == stareCell)))
      return false;
    int? index = this.GetIndex(stareCell, effectCell.CellData, this.cellCorner);
    if (!index.HasValue)
      return false;
    if (!this.StashData.CheckInsert(index.Value, effectCell.CellData))
    {
      if (stareCell.CellData != null && stareCell.CellData is IStandardCaseCellData cellData)
      {
        int? insertableId = cellData.CaseData.GetInsertableId(effectCell.CellData);
        if (insertableId.HasValue)
        {
          cellData.CaseData.InsertInventoryItem(insertableId.Value, effectCell.CellData);
          this.originalId = new int?();
          this.originalCellData = (IVariableInventoryCellData) null;
          return true;
        }
      }
      return false;
    }
    this.StashData.InsertInventoryItem(index.Value, effectCell.CellData);
    this.itemViews[index.Value].Apply(effectCell.CellData);
    this.originalId = new int?();
    this.originalCellData = (IVariableInventoryCellData) null;
    return true;
  }

  public virtual void OnDroped(bool isDroped)
  {
    this.conditionTransform.gameObject.SetActive(false);
    this.condition.color = this.defaultColor;
    if (!isDroped && this.originalId.HasValue)
    {
      this.itemViews[this.originalId.Value].Apply(this.originalCellData);
      this.StashData.InsertInventoryItem(this.originalId.Value, this.originalCellData);
    }
    this.originalId = new int?();
    this.originalCellData = (IVariableInventoryCellData) null;
  }

  public virtual void OnCellEnter(
    IVariableInventoryCell stareCell,
    IVariableInventoryCell effectCell)
  {
    this.conditionTransform.gameObject.SetActive(effectCell?.CellData != null);
    (stareCell as StandardCell).SetHighLight(true);
  }

  public virtual void OnCellExit(IVariableInventoryCell stareCell)
  {
    this.conditionTransform.gameObject.SetActive(false);
    this.condition.color = this.defaultColor;
    this.cellCorner = CellCorner.None;
    (stareCell as StandardCell).SetHighLight(false);
  }

  public virtual void OnSwitchRotate(
    IVariableInventoryCell stareCell,
    IVariableInventoryCell effectCell)
  {
    if (stareCell == null)
      return;
    (int width, int height) = this.GetRotateSize(effectCell.CellData);
    this.conditionTransform.sizeDelta = new Vector2(effectCell.DefaultCellSize.x * (float) width, effectCell.DefaultCellSize.y * (float) height);
    Vector3 evenNumberOffset = this.GetEvenNumberOffset(width, height, stareCell.DefaultCellSize.x * 0.5f, stareCell.DefaultCellSize.y * 0.5f);
    this.conditionTransform.position = stareCell.RectTransform.position + (this.conditionOffset + evenNumberOffset) * stareCell.RectTransform.lossyScale.x;
    this.UpdateCondition(stareCell, effectCell);
  }

  protected virtual int? GetIndex(IVariableInventoryCell stareCell)
  {
    int? index1 = new int?();
    for (int index2 = 0; index2 < this.itemViews.Length; ++index2)
    {
      if (this.itemViews[index2] == stareCell)
        index1 = new int?(index2);
    }
    return index1;
  }

  protected virtual int? GetIndex(
    IVariableInventoryCell stareCell,
    IVariableInventoryCellData effectCellData,
    CellCorner cellCorner)
  {
    int? nullable1 = this.GetIndex(stareCell);
    (int num1, int num2) = this.GetRotateSize(effectCellData);
    if (num1 % 2 == 0 && (cellCorner & CellCorner.Left) != CellCorner.None)
    {
      int? nullable2 = nullable1;
      nullable1 = nullable2.HasValue ? new int?(nullable2.GetValueOrDefault() - 1) : new int?();
    }
    int? nullable3;
    if (num2 % 2 == 0 && (cellCorner & CellCorner.Top) != CellCorner.None)
    {
      nullable3 = nullable1;
      int capacityWidth = this.StashData.CapacityWidth;
      nullable1 = nullable3.HasValue ? new int?(nullable3.GetValueOrDefault() - capacityWidth) : new int?();
    }
    nullable3 = nullable1;
    int num3 = (num1 - 1) / 2;
    nullable3 = nullable3.HasValue ? new int?(nullable3.GetValueOrDefault() - num3) : new int?();
    int num4 = (num2 - 1) / 2 * this.StashData.CapacityWidth;
    return nullable3.HasValue ? new int?(nullable3.GetValueOrDefault() - num4) : new int?();
  }

  protected virtual (int, int) GetRotateSize(IVariableInventoryCellData cell)
  {
    return cell == null ? (1, 1) : (cell.IsRotate ? cell.Height : cell.Width, cell.IsRotate ? cell.Width : cell.Height);
  }

  protected virtual Vector2 GetLocalPosition(RectTransform parent, Vector2 position, Camera camera)
  {
    Vector2 localPoint = Vector2.zero;
    RectTransformUtility.ScreenPointToLocalPointInRectangle(parent, position, camera, out localPoint);
    return localPoint;
  }

  protected virtual CellCorner GetCorner(Vector2 localPosition)
  {
    CellCorner corner = CellCorner.None;
    if ((double) localPosition.x < (double) Mathf.Epsilon)
      corner |= CellCorner.Left;
    if ((double) localPosition.x > (double) Mathf.Epsilon)
      corner |= CellCorner.Right;
    if ((double) localPosition.y > (double) Mathf.Epsilon)
      corner |= CellCorner.Top;
    if ((double) localPosition.y < (double) Mathf.Epsilon)
      corner |= CellCorner.Bottom;
    return corner;
  }

  protected virtual Vector3 GetEvenNumberOffset(
    int width,
    int height,
    float widthOffset,
    float heightOffset)
  {
    Vector3 zero = Vector3.zero;
    if (width % 2 == 0)
    {
      if ((this.cellCorner & CellCorner.Left) != CellCorner.None)
        zero.x -= widthOffset;
      if ((this.cellCorner & CellCorner.Right) != CellCorner.None)
        zero.x += widthOffset;
    }
    if (height % 2 == 0)
    {
      if ((this.cellCorner & CellCorner.Top) != CellCorner.None)
        zero.y += heightOffset;
      if ((this.cellCorner & CellCorner.Bottom) != CellCorner.None)
        zero.y -= heightOffset;
    }
    return zero;
  }

  protected virtual void UpdateCondition(
    IVariableInventoryCell stareCell,
    IVariableInventoryCell effectCell)
  {
    int? index = this.GetIndex(stareCell, effectCell.CellData, this.cellCorner);
    if (index.HasValue && this.StashData.CheckInsert(index.Value, effectCell.CellData))
      this.condition.color = this.positiveColor;
    else if (stareCell.CellData != null && stareCell.CellData is IStandardCaseCellData cellData && cellData.CaseData.GetInsertableId(effectCell.CellData).HasValue)
      this.condition.color = this.positiveColor;
    else
      this.condition.color = this.negativeColor;
  }
}
