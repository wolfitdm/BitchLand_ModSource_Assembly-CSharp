// Decompiled with JetBrains decompiler
// Type: Army
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Army : BaseType
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
      if (person is Girl)
      {
        person.StartingClothes.Add(this.Prefabs_Top[Random.Range(0, this.Prefabs_Top.Count)]);
        person.StartingClothes.Add(this.Prefabs_Pants[Random.Range(0, this.Prefabs_Pants.Count)]);
        person.StartingClothes.Add(this.Prefabs_Shoes[Random.Range(0, this.Prefabs_Shoes.Count)]);
        person.StartingClothes.Add(this.Prefabs_Hat[Random.Range(0, this.Prefabs_Hat.Count)]);
        if (Random.Range(0, 2) == 0)
          person.StartingClothes.Add(this.Prefabs_Any[Random.Range(0, this.Prefabs_Any.Count)]);
      }
      else
      {
        person.StartingClothes.Add(this.PrefabsMale_Top[Random.Range(0, this.PrefabsMale_Top.Count)]);
        person.StartingClothes.Add(this.PrefabsMale_Pants[Random.Range(0, this.PrefabsMale_Pants.Count)]);
        person.StartingClothes.Add(this.PrefabsMale_Shoes[Random.Range(0, this.PrefabsMale_Shoes.Count)]);
        person.StartingClothes.Add(this.Prefabs_Hat[Random.Range(0, this.Prefabs_Hat.Count)]);
        if ((double) Random.Range(0.0f, 1f) < 0.30000001192092896)
          person.StartingClothes.Add(Main.Instance.Prefabs_Beards[Random.Range(0, Main.Instance.Prefabs_Beards.Count)]);
        if ((double) Random.Range(0.0f, 1f) > 0.5)
          person.StartingClothes.Add(this.PrefabsMale_Any[Random.Range(0, this.PrefabsMale_Any.Count)]);
      }
    }
    base.ApplyTo(person, addClothing, addWeapon, addHair);
    if (!addWeapon)
      return;
    GameObject weapon = Object.Instantiate<GameObject>(this.Prefabs_Weapons[Random.Range(0, this.Prefabs_Weapons.Count)]);
    person.WeaponInv.PickupWeapon(weapon);
    person.WeaponInv.startingWeaponIndex = (double) Random.Range(0.0f, 1f) > 0.5 ? 1 : 0;
  }

  public override void OnSeePerson(Person person, Person otherPerson)
  {
    base.OnSeePerson(person, otherPerson);
    if (!((Object) otherPerson.PersonType != (Object) null) || otherPerson.PersonType.ThisType != Person_Type.ESB)
      return;
    Debug.Log((object) ("Army seen ESB " + otherPerson.Name));
    person.StartFighting(otherPerson);
  }
}
