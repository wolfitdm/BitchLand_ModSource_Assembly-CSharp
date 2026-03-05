// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.Sample.CaseCellData
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
