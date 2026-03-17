// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.IVariableInventoryViewData
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
