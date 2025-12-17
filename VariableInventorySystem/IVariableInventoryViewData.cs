// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.IVariableInventoryViewData
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace VariableInventorySystem;

public interface IVariableInventoryViewData
{
  bool IsDirty { get; set; }

  int? GetId(IVariableInventoryCellData cellData);

  int? GetInsertableId(IVariableInventoryCellData cellData);

  void InsertInventoryItem(int id, IVariableInventoryCellData cellData);

  bool CheckInsert(int id, IVariableInventoryCellData cellData);
}
