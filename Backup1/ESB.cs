// Decompiled with JetBrains decompiler
// Type: ESB
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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

  public override void GetAssignedto(Person person)
  {
    base.GetAssignedto(person);
    person.State = Person_State.Work;
  }
}
