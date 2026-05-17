// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.IVariableInventoryCell
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace VariableInventorySystem
{
  public interface IVariableInventoryCell
  {
    RectTransform RectTransform { get; }

    IVariableInventoryCellData CellData { get; }

    Vector2 DefaultCellSize { get; }

    Vector2 MargineSpace { get; }

    void Apply(IVariableInventoryCellData data);

    void SetSelectable(bool isSelectable);
  }
}
