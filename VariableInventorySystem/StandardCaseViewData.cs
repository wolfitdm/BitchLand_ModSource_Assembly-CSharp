// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.StandardCaseViewData
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace VariableInventorySystem
{
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
}
