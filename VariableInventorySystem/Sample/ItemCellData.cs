// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.Sample.ItemCellData
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace VariableInventorySystem.Sample
{
  public class ItemCellData : IVariableInventoryCellData
  {
    public int Id => 0;

    public int Width { get; private set; }

    public int Height { get; private set; }

    public bool IsRotate { get; set; }

    public IVariableInventoryAsset ImageAsset { get; }

    public ItemCellData(int sampleSeed)
    {
      switch (sampleSeed)
      {
        case 0:
          this.Width = 2;
          this.Height = 1;
          this.ImageAsset = (IVariableInventoryAsset) new StandardAsset("Image/handgun");
          break;
        case 1:
          this.Width = 2;
          this.Height = 1;
          this.ImageAsset = (IVariableInventoryAsset) new StandardAsset("Image/handgun2");
          break;
        case 2:
          this.Width = 4;
          this.Height = 2;
          this.ImageAsset = (IVariableInventoryAsset) new StandardAsset("Image/rifle");
          break;
        case 3:
          this.Width = 5;
          this.Height = 2;
          this.ImageAsset = (IVariableInventoryAsset) new StandardAsset("Image/sniper");
          break;
        case 4:
          this.Width = 2;
          this.Height = 2;
          this.ImageAsset = (IVariableInventoryAsset) new StandardAsset("Image/submachinegun");
          break;
        case 5:
          this.Width = 2;
          this.Height = 1;
          this.ImageAsset = (IVariableInventoryAsset) new StandardAsset("Image/handgun");
          break;
        case 6:
          this.Width = 2;
          this.Height = 1;
          this.ImageAsset = (IVariableInventoryAsset) new StandardAsset("Image/handgun2");
          break;
      }
    }
  }
}
