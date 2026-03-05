// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.StandardCaseViewData
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
