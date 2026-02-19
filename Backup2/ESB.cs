// Decompiled with JetBrains decompiler
// Type: ESB
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class ESB : BaseType
{
  public override void ApplyTo(
    Person person,
    bool addClothing = true,
    bool addWeapon = true,
    bool addHair = true,
    RandomNPCHere commingFrom = null)
  {
    if (addClothing)
    {
      person.StartingClothes.Add(this.Prefabs_Top[Random.Range(0, this.Prefabs_Top.Count)]);
      person.StartingClothes.Add(this.Prefabs_Pants[Random.Range(0, this.Prefabs_Pants.Count)]);
      person.StartingClothes.Add(this.Prefabs_Shoes[Random.Range(0, this.Prefabs_Shoes.Count)]);
      person.StartingClothes.Add(this.Prefabs_Hat[Random.Range(0, this.Prefabs_Hat.Count)]);
      if (Random.Range(0, 2) == 0)
        person.StartingClothes.Add(this.Prefabs_Any[Random.Range(0, this.Prefabs_Any.Count)]);
    }
    base.ApplyTo(person, addClothing, addWeapon, addHair);
    if ((Object) commingFrom != (Object) null && !commingFrom.SpawnClean)
      person.DirtySkin = true;
    if (!addWeapon)
      return;
    int index = Random.Range(0, this.Prefabs_Weapons.Count);
    if (!((Object) this.Prefabs_Weapons[index] != (Object) null))
      return;
    GameObject weapon = Object.Instantiate<GameObject>(this.Prefabs_Weapons[index]);
    person.WeaponInv.PickupWeapon(weapon);
    person.WeaponInv.startingWeaponIndex = 1;
  }

  public override void OnSeePerson(Person person, Person otherPerson)
  {
    base.OnSeePerson(person, otherPerson);
    if (!((Object) otherPerson.PersonType != (Object) null) || otherPerson.PersonType.ThisType == Person_Type.ESB)
      return;
    Debug.Log((object) ("ESB seen NonESB " + otherPerson.Name));
    person.StartFighting(otherPerson);
  }
}
