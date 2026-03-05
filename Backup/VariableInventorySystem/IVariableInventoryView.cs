// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.IVariableInventoryView
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
