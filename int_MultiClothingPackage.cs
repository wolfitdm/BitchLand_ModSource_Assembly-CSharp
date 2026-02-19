// Decompiled with JetBrains decompiler
// Type: int_MultiClothingPackage
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
