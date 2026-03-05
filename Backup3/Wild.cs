// Decompiled with JetBrains decompiler
// Type: Wild
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Wild : BaseType
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
      if (Random.Range(0, 3) == 0)
      {
        int num = Random.Range(1, 4);
        for (int index = 0; index < num; ++index)
          person.StartingClothes.Add(this.Prefabs_Any[Random.Range(0, this.Prefabs_Any.Count)]);
      }
    }
    base.ApplyTo(person, addClothing, addWeapon, addHair);
    if ((Object) commingFrom != (Object) null && commingFrom.SpawnClean)
      return;
    switch (Random.Range(0, 7))
    {
      case 1:
        person.States[17] = true;
        break;
      case 2:
        person.States[18] = true;
        break;
      case 3:
        person.States[19] = true;
        break;
    }
    switch (Random.Range(0, 8))
    {
      case 1:
        person.States[12] = true;
        break;
      case 2:
        person.States[13] = true;
        break;
      case 3:
        person.States[14] = true;
        break;
      case 4:
        person.States[15] = true;
        break;
      case 5:
        person.States[16] = true;
        break;
    }
    if (Random.Range(0, 3) == 0)
      person.States[20] = true;
    person.DirtySkin = true;
  }

  public override void GetAssignedto(Person person)
  {
    base.GetAssignedto(person);
    person.State = Person_State.Free;
  }
}
