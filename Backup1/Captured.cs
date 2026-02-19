// Decompiled with JetBrains decompiler
// Type: Captured
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class Captured : BaseType
{
  public Captured.PossibleWear[] PossibleWears;

  public override void ApplyTo(
    Person person,
    bool addClothing = true,
    bool addWeapon = true,
    bool addHair = true,
    RandomNPCHere commingFrom = null)
  {
    person.StartingClothes.Add(Main.Instance.Feet);
    if (addClothing)
    {
      for (int index = 0; index < this.Prefabs_Any.Count; ++index)
        person.StartingClothes.Add(this.Prefabs_Any[index]);
      int index1 = UnityEngine.Random.Range(0, this.PossibleWears.Length);
      for (int index2 = 0; index2 < this.PossibleWears[index1].Wears.Length; ++index2)
        person.StartingClothes.Add(this.PossibleWears[index1].Wears[index2]);
    }
    base.ApplyTo(person, addClothing, addWeapon, addHair);
    UnityEngine.Random.Range(0, 4);
    if (UnityEngine.Random.Range(0, 3) == 0)
      person.States[21] = true;
    person.DirtySkin = true;
  }

  public override void GetAssignedto(Person person)
  {
    base.GetAssignedto(person);
    person.State = Person_State.Free;
  }

  [Serializable]
  public class PossibleWear
  {
    public GameObject[] Wears;
  }
}
