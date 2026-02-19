// Decompiled with JetBrains decompiler
// Type: Outfitter
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
[Serializable]
public class Outfitter : MonoBehaviour
{
  private CharacterDemoController ac;
  private int oldWeaponIndex;
  [SerializeField]
  public List<WeaponSlot> weapons;

  private void Start()
  {
    this.ac = this.GetComponentInChildren<CharacterDemoController>();
    for (int index1 = 0; index1 < this.weapons.Count; ++index1)
    {
      for (int index2 = 0; index2 < this.weapons[index1].models.Count; ++index2)
        this.weapons[index1].models[index2].enabled = false;
    }
    for (int index = 0; index < this.weapons[this.ac.WeaponState].models.Count; ++index)
      this.weapons[this.ac.WeaponState].models[index].enabled = true;
    this.oldWeaponIndex = this.ac.WeaponState;
  }

  private void Update()
  {
    if (this.ac.WeaponState == this.oldWeaponIndex)
      return;
    for (int index = 0; index < this.weapons[this.oldWeaponIndex].models.Count; ++index)
      this.weapons[this.oldWeaponIndex].models[index].enabled = false;
    for (int index = 0; index < this.weapons[this.ac.WeaponState].models.Count; ++index)
      this.weapons[this.ac.WeaponState].models[index].enabled = true;
    this.oldWeaponIndex = this.ac.WeaponState;
  }
}
