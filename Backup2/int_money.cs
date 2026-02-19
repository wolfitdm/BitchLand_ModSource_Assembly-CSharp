// Decompiled with JetBrains decompiler
// Type: int_money
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class int_money : Interactible
{
  public int Value;
  public ItemRarity Rarity;
  public int NoteIndex;

  public override void Interact(Person person)
  {
    if (person.IsPlayer)
    {
      Main.Instance.GameplayMenu.ShowNotification($"Picked {this.Value.ToString()} Bitch Notes");
      switch (this.Value)
      {
        case 10:
          Main.Instance.GameplayMenu.HasBitchNotes10[this.NoteIndex] = true;
          break;
        case 20:
          Main.Instance.GameplayMenu.HasBitchNotes20[this.NoteIndex] = true;
          break;
        case 50:
          if (this.Rarity == ItemRarity.Secret)
          {
            Main.Instance.GameplayMenu.HasBitchNotesProt[this.NoteIndex] = true;
            break;
          }
          Main.Instance.GameplayMenu.HasBitchNotes50[this.NoteIndex] = true;
          break;
        case 100:
          Main.Instance.GameplayMenu.HasBitchNotes100[this.NoteIndex] = true;
          break;
        case 1000:
          Main.Instance.GameplayMenu.HasBitchNotes1000[this.NoteIndex] = true;
          break;
      }
    }
    person.Money += this.Value;
    Object.Destroy((Object) this.gameObject);
  }

  public override string[] sd_SaveData(char SlitChar = ':')
  {
    List<string> stringList = new List<string>();
    stringList.AddRange((IEnumerable<string>) base.sd_SaveData(SlitChar));
    stringList.Add(this.Value.ToString());
    return stringList.ToArray();
  }

  public override void sd_LoadData(string[] Data, char SlitChar = ':')
  {
    base.sd_LoadData(Data, SlitChar);
    if (Data.Length <= this._CurrentLoadingIndex)
      return;
    this.Value = int.Parse(Data[this._CurrentLoadingIndex++]);
    this.InteractText = this.name = this.Value.ToString() + " Bitch Notes";
  }
}
