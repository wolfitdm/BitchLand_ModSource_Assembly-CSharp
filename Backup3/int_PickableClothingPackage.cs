// Decompiled with JetBrains decompiler
// Type: int_PickableClothingPackage
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class int_PickableClothingPackage : int_ResourceItem
{
  [Header("Clothing")]
  public GameObject Clothing;
  public GameObject MaleClothing;
  public string ClothingData;

  public override void Interact(Person person) => this.Dress(person);

  public void Dress(Person person, bool isPrefab = false)
  {
    GameObject prefab = !(person is Guy) ? this.Clothing : this.MaleClothing;
    if ((Object) prefab == (Object) null)
      return;
    person.DressClothe(prefab, clothingData: this.ClothingData);
    if (isPrefab)
      return;
    Object.Destroy((Object) this.RootObj);
  }

  public override void sd_LoadData(string[] Data, char SlitChar = ':')
  {
    base.sd_LoadData(Data, SlitChar);
    if (Data.Length < this._CurrentLoadingIndex + 1)
      return;
    this.ClothingData = Data[this._CurrentLoadingIndex];
  }

  public override string[] sd_SaveData(char SlitChar = ':')
  {
    List<string> stringList = new List<string>();
    stringList.AddRange((IEnumerable<string>) base.sd_SaveData(SlitChar));
    stringList.Add(this.ClothingData);
    return stringList.ToArray();
  }
}
