// Decompiled with JetBrains decompiler
// Type: Int_ResourceMining
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class Int_ResourceMining : Interactible
{
  public ResourceTypes ThisOre;
  public int OreCount = 1;
  public GameObject MinedOre;

  public override void Interact(Person person)
  {
    base.Interact(person);
    if (person.IsPlayer)
    {
      if ((UnityEngine.Object) person.WeaponInv.CurrentWeapon != (UnityEngine.Object) null && person.WeaponInv.CurrentWeapon.auto == Auto.PickAxe)
      {
        person.WeaponInv.CurrentWeapon.OnEndOfShoot = (Action) (() => this.GetMined(person));
        person.WeaponInv.CurrentWeapon.MeleeFire();
      }
      else
        Main.Instance.GameplayMenu.ShowMessageBox("You need a pickaxe to mine!");
    }
    this.StopInteracting();
  }

  public void GetMined(Person person)
  {
    if (person.Perks.Contains("Mining Skill lvl 2"))
      ++this.OreCount;
    for (int index = 0; index < this.OreCount; ++index)
      Main.Spawn(this.MinedOre, saveable: true).transform.position = this.transform.position + new Vector3(0.0f, 0.4f, 0.0f);
    UnityEngine.Object.Destroy((UnityEngine.Object) this.gameObject);
  }
}
