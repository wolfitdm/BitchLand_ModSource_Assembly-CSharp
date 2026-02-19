// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.StandardStashViewData
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace VariableInventorySystem;

public class StandardStashViewData : IVariableInventoryViewData
{
  private bool[] mask;

  public bool IsDirty { get; set; }

  public IVariableInventoryCellData[] CellData { get; }

  public int CapacityWidth { get; }

  public int CapacityHeight { get; }

  public StandardStashViewData(int capacityWidth, int capacityHeight)
    : this(new IVariableInventoryCellData[capacityWidth * capacityHeight], capacityWidth, capacityHeight)
  {
  }

  public StandardStashViewData(
    IVariableInventoryCellData[] cellData,
    int capacityWidth,
    int capacityHeight)
  {
    this.IsDirty = true;
    this.CellData = cellData;
    this.CapacityWidth = capacityWidth;
    this.CapacityHeight = capacityHeight;
    this.UpdateMask();
  }

  public virtual int? GetId(IVariableInventoryCellData cellData)
  {
    for (int index = 0; index < this.CellData.Length; ++index)
    {
      if (this.CellData[index] == cellData)
        return new int?(index);
    }
    return new int?();
  }

  public virtual int? GetInsertableId(IVariableInventoryCellData cellData)
  {
    for (int id = 0; id < this.mask.Length; ++id)
    {
      if (!this.mask[id] && this.CheckInsert(id, cellData))
        return new int?(id);
    }
    return new int?();
  }

  public virtual void InsertInventoryItem(int id, IVariableInventoryCellData cellData)
  {
    this.CellData[id] = cellData;
    this.IsDirty = true;
    this.UpdateMask();
  }

  public virtual bool CheckInsert(int id, IVariableInventoryCellData cellData)
  {
    if (id < 0)
      return false;
    (int num1, int num2) = this.GetRotateSize(cellData);
    if (id % this.CapacityWidth + (num1 - 1) >= this.CapacityWidth || id + (num2 - 1) * this.CapacityWidth >= this.CellData.Length)
      return false;
    for (int index1 = 0; index1 < num1; ++index1)
    {
      for (int index2 = 0; index2 < num2; ++index2)
      {
        if (this.mask[id + index1 + index2 * this.CapacityWidth])
          return false;
      }
    }
    return true;
  }

  protected void UpdateMask()
  {
    this.mask = new bool[this.CapacityWidth * this.CapacityHeight];
    for (int index1 = 0; index1 < this.CellData.Length; ++index1)
    {
      if (this.CellData[index1] != null && !this.mask[index1])
      {
        int num1 = this.CellData[index1].IsRotate ? this.CellData[index1].Height : this.CellData[index1].Width;
        int num2 = this.CellData[index1].IsRotate ? this.CellData[index1].Width : this.CellData[index1].Height;
        for (int index2 = 0; index2 < num1; ++index2)
        {
          for (int index3 = 0; index3 < num2; ++index3)
          {
            int index4 = index1 + index2 + index3 * this.CapacityWidth;
            if (index4 < this.mask.Length)
              this.mask[index4] = true;
          }
        }
      }
    }
  }

  protected (int, int) GetRotateSize(IVariableInventoryCellData cell)
  {
    return cell == null ? (1, 1) : (cell.IsRotate ? cell.Height : cell.Width, cell.IsRotate ? cell.Width : cell.Height);
  }
}
