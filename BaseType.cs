// Decompiled with JetBrains decompiler
// Type: BaseType
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
  public bool _OW_SetWorkStates;
  public float _OW_StartTime = 0.15f;
  public float _OW_EndTime = 0.85f;
  public bool _OW_SetEnterWork;
  public bool _OW_SetExitWork;

  public Person_Type_menu ThisType_menu
  {
    get
    {
      switch (this.ThisType)
      {
        case Person_Type.Prisioner:
          return Person_Type_menu.Prisioner;
        case Person_Type.Worker:
          return Person_Type_menu.Worker;
        case Person_Type.Civilian:
          return Person_Type_menu.Civilian;
        case Person_Type.HigherCivilian:
          return Person_Type_menu.Royal;
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
    if (Main.Instance.OpenWorld)
      Main.Instance.SpawnedPeopleOfType[(int) this.ThisType].Add(person);
    else
      Main.Instance.SpawnedPeopleOfType_World[(int) this.ThisType].Add(person);
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

  public virtual void GetAssignedto(Person person)
  {
    if ((Object) person.PersonType != (Object) this)
      person.PersonType.GetUnAssigned(person);
    person.PersonType = this;
  }

  public virtual void GetUnAssigned(Person person)
  {
    person.FreeScheduleTasks.Clear();
    person.WorkScheduleTasks.Clear();
  }

  public virtual bool BehaviourPass(Person person) => false;

  public virtual bool BehaviourPass_Free(Person person) => false;

  public virtual bool BehaviourPass_Work(Person person) => false;

  public virtual void FixedUpdate()
  {
    if (!this._OW_SetWorkStates || !Main.Instance.OpenWorld)
      return;
    if (!this._OW_SetEnterWork && ((double) Main.Instance.DayCycle.timeOfDay < (double) this._OW_StartTime || (double) Main.Instance.DayCycle.timeOfDay > (double) this._OW_EndTime))
    {
      this._OW_SetEnterWork = true;
      this._OW_SetExitWork = false;
      for (int index = 0; index < Main.Instance.SpawnedPeople_World.Count; ++index)
      {
        if ((Object) Main.Instance.SpawnedPeople_World[index].PersonType == (Object) this)
          Main.Instance.SpawnedPeople_World[index].State = Person_State.Work;
      }
    }
    if (this._OW_SetExitWork || (double) Main.Instance.DayCycle.timeOfDay <= (double) this._OW_StartTime || (double) Main.Instance.DayCycle.timeOfDay >= (double) this._OW_EndTime)
      return;
    this._OW_SetEnterWork = false;
    this._OW_SetExitWork = true;
    for (int index = 0; index < Main.Instance.SpawnedPeople_World.Count; ++index)
    {
      if ((Object) Main.Instance.SpawnedPeople_World[index].PersonType == (Object) this)
        Main.Instance.SpawnedPeople_World[index].State = Person_State.Free;
    }
  }
}
