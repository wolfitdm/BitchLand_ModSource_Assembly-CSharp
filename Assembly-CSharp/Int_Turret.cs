// Decompiled with JetBrains decompiler
// Type: Int_Turret
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Int_Turret : Interactible
{
  public Weapon Turret;

  public override void Interact(Person person)
  {
    base.Interact(person);
    person.gameObject.SetActive(false);
    this.Turret.playerWeapon = person.tag == "Player";
    this.Turret._WeaponSystem = person.WeaponInv;
    this.enabled = this.CanLeave;
  }

  private void Update()
  {
    if (!Input.GetButtonUp("Drop"))
      return;
    this.StopInteracting();
  }

  public void Fire() => this.Turret.Fire();

  public override void StopInteracting()
  {
    base.StopInteracting();
    this.InteractingPerson.gameObject.SetActive(true);
  }
}
