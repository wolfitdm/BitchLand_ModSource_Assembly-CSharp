// Decompiled with JetBrains decompiler
// Type: int_Lamp
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class int_Lamp : Interactible
{
  [Header("lamp")]
  public GameObject OnOn;
  public Material[] LampMats_ON;
  public Material[] LampMats_FUCKINGOFF;
  public MeshRenderer Ren;
  public int MatToSwitch;

  public override void Interact(Person person)
  {
    if (this.OnOn.activeSelf)
      this.TurnOff();
    else
      this.TurnOn();
  }

  public virtual void TurnOn()
  {
    this.OnOn.SetActive(true);
    if (!((Object) this.Ren != (Object) null))
      return;
    this.Ren.materials = this.LampMats_ON;
  }

  public virtual void TurnOff()
  {
    this.OnOn.SetActive(false);
    if (!((Object) this.Ren != (Object) null))
      return;
    this.Ren.materials = this.LampMats_FUCKINGOFF;
  }

  public override string[] sd_SaveData(char SlitChar = ':')
  {
    List<string> stringList = new List<string>();
    stringList.AddRange((IEnumerable<string>) base.sd_SaveData(SlitChar));
    stringList.Add(this.OnOn.activeSelf ? "1" : "0");
    return stringList.ToArray();
  }

  public override void sd_LoadData(string[] Data, char SlitChar = ':')
  {
    base.sd_LoadData(Data, SlitChar);
    if (Data[this._CurrentLoadingIndex++] == "1")
      this.TurnOn();
    else
      this.TurnOff();
  }
}
