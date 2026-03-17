// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.IVariableInventoryCell
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
