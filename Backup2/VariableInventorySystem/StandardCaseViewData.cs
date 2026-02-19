// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.StandardCaseViewData
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace VariableInventorySystem;

public class StandardCaseViewData : StandardStashViewData
{
  public StandardCaseViewData(int capacityWidth, int capacityHeight)
    : base(capacityWidth, capacityHeight)
  {
  }

  public StandardCaseViewData(
    IVariableInventoryCellData[] cellData,
    int capacityWidth,
    int capacityHeight)
    : base(cellData, capacityWidth, capacityHeight)
  {
  }

  public override int? GetInsertableId(IVariableInventoryCellData cellData)
  {
    return cellData is IStandardCaseCellData standardCaseCellData && standardCaseCellData.CaseData == this ? new int?() : base.GetInsertableId(cellData);
  }

  public override bool CheckInsert(int id, IVariableInventoryCellData cellData)
  {
    return (!(cellData is IStandardCaseCellData standardCaseCellData) || standardCaseCellData.CaseData != this) && base.CheckInsert(id, cellData);
  }
}
