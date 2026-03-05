// Decompiled with JetBrains decompiler
// Type: Outfitter
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
