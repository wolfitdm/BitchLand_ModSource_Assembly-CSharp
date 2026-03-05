// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.IVariableInventoryCell
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
