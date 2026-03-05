// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.IVariableInventoryCellData
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
