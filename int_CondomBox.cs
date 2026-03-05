// Decompiled with JetBrains decompiler
// Type: int_CondomBox
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
