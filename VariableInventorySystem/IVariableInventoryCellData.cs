// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.IVariableInventoryCellData
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
