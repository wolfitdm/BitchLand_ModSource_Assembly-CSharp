// Decompiled with JetBrains decompiler
// Type: int_MultiClothingPackage
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
[Obsolete]
public class int_MultiClothingPackage : MultiInteractible
{
  public int_PickableClothingPackage PickableClothingPackage;

  public override void sd_LoadData(string[] Data, char SlitChar = ':')
  {
    base.sd_LoadData(Data, SlitChar);
    this.PickableClothingPackage.ClothingData = Data[this._CurrentLoadingIndex];
  }

  public override string[] sd_SaveData(char SlitChar = ':')
  {
    List<string> stringList = new List<string>();
    stringList.AddRange((IEnumerable<string>) base.sd_SaveData(SlitChar));
    stringList.Add(this.PickableClothingPackage.ClothingData);
    return stringList.ToArray();
  }
}
