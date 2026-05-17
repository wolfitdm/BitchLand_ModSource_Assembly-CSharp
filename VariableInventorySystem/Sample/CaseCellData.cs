// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.Sample.CaseCellData
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace VariableInventorySystem.Sample
{
  public class CaseCellData : IStandardCaseCellData, IVariableInventoryCellData
  {
    public int Id => 0;

    public int Width { get; private set; }

    public int Height { get; private set; }

    public bool IsRotate { get; set; }

    public IVariableInventoryAsset ImageAsset { get; }

    public StandardCaseViewData CaseData { get; }

    public CaseCellData(int sampleSeed)
    {
      this.Width = 4;
      this.Height = 3;
      this.ImageAsset = (IVariableInventoryAsset) new StandardAsset("Image/chest");
      this.CaseData = new StandardCaseViewData(8, 6);
    }
  }
}
