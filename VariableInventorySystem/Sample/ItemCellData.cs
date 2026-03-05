// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.Sample.ItemCellData
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
