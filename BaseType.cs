// Decompiled with JetBrains decompiler
// Type: BaseType
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class BaseType : MonoBehaviour
{
  public Person_Type ThisType;
  public Color TypeColor;
  public Color[] HairColors;
  public int NaturalHairColorChance = 10;
  public bool DontColorMales;
  public List<GameObject> Prefabs_Any = new List<GameObject>();
  public List<GameObject> Prefabs_Shoes = new List<GameObject>();
  public List<GameObject> Prefabs_Pants = new List<GameObject>();
  public List<GameObject> Prefabs_Top = new List<GameObject>();
  public List<GameObject> Prefabs_UnderwearTop = new List<GameObject>();
  public List<GameObject> Prefabs_UnderwearLower = new List<GameObject>();
  public List<GameObject> Prefabs_Garter = new List<GameObject>();
  public List<GameObject> Prefabs_Socks = new List<GameObject>();
  public List<GameObject> Prefabs_Hat = new List<GameObject>();
  public List<GameObject> Prefabs_Weapons = new List<GameObject>();
  public List<GameObject> PrefabsMale_Any = new List<GameObject>();
  public List<GameObject> PrefabsMale_Shoes = new List<GameObject>();
  public List<GameObject> PrefabsMale_Pants = new List<GameObject>();
  public List<GameObject> PrefabsMale_Top = new List<GameObject>();
  public List<GameObject> PrefabsMale_UnderwearTop = new List<GameObject>();
  public List<GameObject> PrefabsMale_UnderwearLower = new List<GameObject>();
  public List<GameObject> _NiceHairs = new List<GameObject>();
  public List<Dressable> _NiceHairsChance = new List<Dressable>();

  public Person_Type_menu ThisType_menu
  {
    get
    {
      switch (this.ThisType)
      {
        case Person_Type.Worker:
          return Person_Type_menu.Worker;
        case Person_Type.Civilian:
          return Person_Type_menu.Civilian;
        case Person_Type.Army:
          return Person_Type_menu.Army;
        case Person_Type.Royal:
          return Person_Type_menu.Royal;
        default:
          return Person_Type_menu.Wild;
      }
    }
    set
    {
    }
  }

  public virtual void ApplyTo(
    Person person,
    bool addClothing = true,
    bool addWeapon = true,
    bool addHair = true,
    RandomNPCHere commingFrom = null)
  {
    if (addHair)
    {
      if (person is Girl)
      {
        if (person.SPAWN_noUglyHair)
        {
          List<GameObject> gameObjectList = new List<GameObject>();
          for (int index = 0; index < Main.Instance.Prefabs_Hair.Count; ++index)
          {
            if (!Main.Instance.Prefabs_Hair[index].GetComponent<Dressable>().Ugly)
              gameObjectList.Add(Main.Instance.Prefabs_Hair[index]);
          }
          person.StartingClothes.Add(gameObjectList[Random.Range(0, gameObjectList.Count)]);
        }
        else if (person.SPAWN_onlyGoodHair)
        {
          List<GameObject> gameObjectList = new List<GameObject>();
          for (int index = 0; index < Main.Instance.Prefabs_Hair.Count; ++index)
          {
            if (Main.Instance.Prefabs_Hair[index].GetComponent<Dressable>().Good)
              gameObjectList.Add(Main.Instance.Prefabs_Hair[index]);
          }
          person.StartingClothes.Add(gameObjectList[Random.Range(0, gameObjectList.Count)]);
        }
        else
          person.StartingClothes.Add(Main.Instance.Prefabs_Hair[Random.Range(0, Main.Instance.Prefabs_Hair.Count)]);
      }
      else
        person.StartingClothes.Add(Main.Instance.Prefabs_MaleHair[Random.Range(0, Main.Instance.Prefabs_MaleHair.Count)]);
    }
    person.PersonType = this;
    if ((!this.DontColorMales || !(person is Guy)) && this.HairColors != null && this.HairColors.Length != 0 && Random.Range(0, 100) > this.NaturalHairColorChance)
      person.DyedHairColor = this.HairColors[Random.Range(0, this.HairColors.Length)];
    person.Init();
    Main.Instance.SpawnedPeopleOfType[(int) this.ThisType].Add(person);
    if (!addHair || !((Object) person.CurrentHair != (Object) null) || (double) Random.Range(0.0f, 1f) <= 0.5)
      return;
    switch (person.CurrentHair.ReverseAxis)
    {
      case Axis.X:
        person.CurrentHair.transform.localScale = new Vector3(-person.CurrentHair.transform.localScale.x, person.CurrentHair.transform.localScale.y, person.CurrentHair.transform.localScale.z);
        break;
      case Axis.Y:
        person.CurrentHair.transform.localScale = new Vector3(person.CurrentHair.transform.localScale.x, -person.CurrentHair.transform.localScale.y, person.CurrentHair.transform.localScale.z);
        break;
      case Axis.Z:
        person.CurrentHair.transform.localScale = new Vector3(person.CurrentHair.transform.localScale.x, person.CurrentHair.transform.localScale.y, -person.CurrentHair.transform.localScale.z);
        break;
    }
  }

  public virtual void OnSeePerson(Person person, Person otherPerson)
  {
    if (!otherPerson.TempAggroContainsID(this.ThisType))
      return;
    Debug.Log((object) ("Seen with TempAggro " + otherPerson.Name));
    person.StartFighting(otherPerson, otherPerson.TempAggroMelee(this.ThisType));
  }
}
