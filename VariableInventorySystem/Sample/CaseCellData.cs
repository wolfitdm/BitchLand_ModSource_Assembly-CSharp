// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.Sample.CaseCellData
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace VariableInventorySystem.Sample;

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
