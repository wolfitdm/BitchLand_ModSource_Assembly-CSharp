// Decompiled with JetBrains decompiler
// Type: int_CondomBox
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class int_CondomBox : Interactible
{
  public Interactible MainPromptInt;
  public int _Condoms = 10;

  public int Condoms
  {
    set
    {
      this._Condoms = value;
      this.MainPromptInt.InteractText = "Condom Box (" + value.ToString() + ")";
    }
    get => this._Condoms;
  }

  public override void Interact(Person person)
  {
    if (this.Condoms <= 0)
      return;
    --this.Condoms;
    Main.Spawn(Main.Instance.AllPrefabs[153], saveable: true).transform.position = this.transform.position + new Vector3(0.0f, 0.1f, 0.0f);
  }

  public override string[] sd_SaveData(char SlitChar = ':')
  {
    List<string> stringList = new List<string>();
    stringList.AddRange((IEnumerable<string>) base.sd_SaveData(SlitChar));
    stringList.Add(this.Condoms.ToString());
    return stringList.ToArray();
  }

  public override void sd_LoadData(string[] Data, char SlitChar = ':')
  {
    base.sd_LoadData(Data, SlitChar);
    if (Data.Length < this._CurrentLoadingIndex + 1)
      return;
    this.Condoms = int.Parse(Data[this._CurrentLoadingIndex++]);
  }
}
