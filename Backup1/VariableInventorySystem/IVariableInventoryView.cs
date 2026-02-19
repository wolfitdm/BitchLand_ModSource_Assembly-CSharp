// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.IVariableInventoryView
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine.EventSystems;

#nullable disable
namespace VariableInventorySystem
{
  public interface IVariableInventoryView
  {
    void SetCellCallback(
      Action<IVariableInventoryCell> onCellClick,
      Action<IVariableInventoryCell> onCellOptionClick,
      Action<IVariableInventoryCell> onCellEnter,
      Action<IVariableInventoryCell> onCellExit);

    void Apply(IVariableInventoryViewData data);

    void ReApply();

    void OnPrePick(IVariableInventoryCell stareCell);

    bool OnPick(IVariableInventoryCell stareCell);

    void OnDrag(
      IVariableInventoryCell stareCell,
      IVariableInventoryCell effectCell,
      PointerEventData cursorPosition);

    bool OnDrop(IVariableInventoryCell stareCell, IVariableInventoryCell effectCell);

    void OnDroped(bool isDroped);

    void OnCellEnter(IVariableInventoryCell stareCell, IVariableInventoryCell effectCell);

    void OnCellExit(IVariableInventoryCell stareCell);

    void OnSwitchRotate(IVariableInventoryCell stareCell, IVariableInventoryCell effectCell);
  }
}
