// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.IVariableInventoryCellData
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace VariableInventorySystem
{
  public interface IVariableInventoryCellData
  {
    int Id { get; }

    int Width { get; }

    int Height { get; }

    bool IsRotate { get; set; }

    IVariableInventoryAsset ImageAsset { get; }
  }
}
