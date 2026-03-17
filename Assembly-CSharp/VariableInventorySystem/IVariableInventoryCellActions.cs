// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.IVariableInventoryCellActions
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
namespace VariableInventorySystem
{
  public interface IVariableInventoryCellActions
  {
    void SetActive(bool value);

    void SetCallback(
      Action onPointerClick,
      Action onPointerClickOption,
      Action onPointerEnter,
      Action onPointerExit,
      Action onPointerDown,
      Action onPointerUp);
  }
}
