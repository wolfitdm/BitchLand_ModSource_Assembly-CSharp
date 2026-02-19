// Decompiled with JetBrains decompiler
// Type: Civilian
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Civilian : BaseType
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
        person.StartingClothes.Add(this.Prefabs_Any[Random.Range(0, this.Prefabs_Any.Count)]);
        person.StartingClothes.Add(this.Prefabs_Top[Random.Range(0, this.Prefabs_Top.Count)]);
        person.StartingClothes.Add(this.Prefabs_Pants[Random.Range(0, this.Prefabs_Pants.Count)]);
        person.StartingClothes.Add(this.Prefabs_Shoes[Random.Range(0, this.Prefabs_Shoes.Count)]);
        person.StartingClothes.Add(this.Prefabs_Garter[Random.Range(0, this.Prefabs_Garter.Count)]);
      }
      else
      {
        person.StartingClothes.Add(this.PrefabsMale_Top[Random.Range(0, this.PrefabsMale_Top.Count)]);
        person.StartingClothes.Add(this.PrefabsMale_Pants[Random.Range(0, this.PrefabsMale_Pants.Count)]);
        person.StartingClothes.Add(this.PrefabsMale_Shoes[Random.Range(0, this.PrefabsMale_Shoes.Count)]);
        if ((double) Random.Range(0.0f, 1f) < 0.30000001192092896)
          person.StartingClothes.Add(Main.Instance.Prefabs_Beards[Random.Range(0, Main.Instance.Prefabs_Beards.Count)]);
      }
    }
    base.ApplyTo(person, addClothing, addWeapon, addHair);
    if (Random.Range(0, 4) != 1)
      return;
    person.States[12] = true;
  }

  public override void GetAssignedto(Person person)
  {
    base.GetAssignedto(person);
    person.State = Person_State.Free;
  }
}
