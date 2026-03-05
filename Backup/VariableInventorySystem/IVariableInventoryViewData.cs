// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.IVariableInventoryViewData
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
