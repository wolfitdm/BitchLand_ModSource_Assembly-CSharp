// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.IVariableInventoryViewData
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace VariableInventorySystem
{
  public interface IVariableInventoryViewData
  {
    bool IsDirty { get; set; }

    int? GetId(IVariableInventoryCellData cellData);

    int? GetInsertableId(IVariableInventoryCellData cellData);

    void InsertInventoryItem(int id, IVariableInventoryCellData cellData);

    bool CheckInsert(int id, IVariableInventoryCellData cellData);
  }
}
