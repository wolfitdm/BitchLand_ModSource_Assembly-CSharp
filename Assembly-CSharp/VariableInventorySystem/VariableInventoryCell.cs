// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.VariableInventoryCell
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace VariableInventorySystem
{
  public abstract class VariableInventoryCell : MonoBehaviour, IVariableInventoryCell
  {
    public RectTransform RectTransform => (RectTransform) this.transform;

    public IVariableInventoryCellData CellData { get; protected set; }

    public virtual Vector2 DefaultCellSize { get; set; }

    public virtual Vector2 MargineSpace { get; set; }

    protected virtual IVariableInventoryCellActions ButtonActions { get; set; }

    public virtual void SetCellCallback(
      Action<IVariableInventoryCell> onPointerClick,
      Action<IVariableInventoryCell> onPointerOptionClick,
      Action<IVariableInventoryCell> onPointerEnter,
      Action<IVariableInventoryCell> onPointerExit,
      Action<IVariableInventoryCell> onPointerDown,
      Action<IVariableInventoryCell> onPointerUp)
    {
      this.ButtonActions.SetCallback((Action) (() =>
      {
        Action<IVariableInventoryCell> action = onPointerClick;
        if (action == null)
          return;
        action((IVariableInventoryCell) this);
      }), (Action) (() =>
      {
        Action<IVariableInventoryCell> action = onPointerOptionClick;
        if (action == null)
          return;
        action((IVariableInventoryCell) this);
      }), (Action) (() =>
      {
        Action<IVariableInventoryCell> action = onPointerEnter;
        if (action == null)
          return;
        action((IVariableInventoryCell) this);
      }), (Action) (() =>
      {
        Action<IVariableInventoryCell> action = onPointerExit;
        if (action == null)
          return;
        action((IVariableInventoryCell) this);
      }), (Action) (() =>
      {
        Action<IVariableInventoryCell> action = onPointerDown;
        if (action == null)
          return;
        action((IVariableInventoryCell) this);
      }), (Action) (() =>
      {
        Action<IVariableInventoryCell> action = onPointerUp;
        if (action == null)
          return;
        action((IVariableInventoryCell) this);
      }));
    }

    public void Apply(IVariableInventoryCellData cellData)
    {
      this.CellData = cellData;
      this.OnApply();
    }

    public abstract void SetSelectable(bool value);

    protected abstract void OnApply();
  }
}
