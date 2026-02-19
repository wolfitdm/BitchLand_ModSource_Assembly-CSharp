// Decompiled with JetBrains decompiler
// Type: Army
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
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
        person.StartingClothes.Add(this.Prefabs_Top[UnityEngine.Random.Range(0, this.Prefabs_Top.Count)]);
        person.StartingClothes.Add(this.Prefabs_Pants[UnityEngine.Random.Range(0, this.Prefabs_Pants.Count)]);
        person.StartingClothes.Add(this.Prefabs_Shoes[UnityEngine.Random.Range(0, this.Prefabs_Shoes.Count)]);
        person.StartingClothes.Add(this.Prefabs_Hat[UnityEngine.Random.Range(0, this.Prefabs_Hat.Count)]);
        if (UnityEngine.Random.Range(0, 2) == 0)
          person.StartingClothes.Add(this.Prefabs_Any[UnityEngine.Random.Range(0, this.Prefabs_Any.Count)]);
      }
      else
      {
        person.StartingClothes.Add(this.PrefabsMale_Top[UnityEngine.Random.Range(0, this.PrefabsMale_Top.Count)]);
        person.StartingClothes.Add(this.PrefabsMale_Pants[UnityEngine.Random.Range(0, this.PrefabsMale_Pants.Count)]);
        person.StartingClothes.Add(this.PrefabsMale_Shoes[UnityEngine.Random.Range(0, this.PrefabsMale_Shoes.Count)]);
        person.StartingClothes.Add(this.Prefabs_Hat[UnityEngine.Random.Range(0, this.Prefabs_Hat.Count)]);
        if ((double) UnityEngine.Random.Range(0.0f, 1f) < 0.30000001192092896)
          person.StartingClothes.Add(Main.Instance.Prefabs_Beards[UnityEngine.Random.Range(0, Main.Instance.Prefabs_Beards.Count)]);
        if ((double) UnityEngine.Random.Range(0.0f, 1f) > 0.5)
          person.StartingClothes.Add(this.PrefabsMale_Any[UnityEngine.Random.Range(0, this.PrefabsMale_Any.Count)]);
      }
    }
    base.ApplyTo(person, addClothing, addWeapon, addHair);
    if (!addWeapon)
      return;
    GameObject weapon = UnityEngine.Object.Instantiate<GameObject>(this.Prefabs_Weapons[UnityEngine.Random.Range(0, this.Prefabs_Weapons.Count)]);
    person.WeaponInv.PickupWeapon(weapon);
    person.WeaponInv.startingWeaponIndex = (double) UnityEngine.Random.Range(0.0f, 1f) > 0.5 ? 1 : 0;
  }

  public override void OnSeePerson(Person person, Person otherPerson)
  {
    base.OnSeePerson(person, otherPerson);
    if (!((UnityEngine.Object) otherPerson.PersonType != (UnityEngine.Object) null) || otherPerson.PersonType.ThisType != Person_Type.ESB)
      return;
    Debug.Log((object) ("Army seen ESB " + otherPerson.Name));
    person.StartFighting(otherPerson);
  }

  public override void GetAssignedto(Person person)
  {
    base.GetAssignedto(person);
    person.State = Person_State.Work;
  }

  public override bool BehaviourPass(Person person)
  {
    person.SeekBed();
    return false;
  }

  public override bool BehaviourPass_Work(Person person)
  {
    bool flag = false;
    Person _trainee = (Person) null;
    if ((UnityEngine.Object) person.WeaponInv.CurrentWeapon == (UnityEngine.Object) null)
    {
      for (int index = 0; index < person.WeaponInv.weapons.Count; ++index)
      {
        if ((UnityEngine.Object) person.WeaponInv.weapons[index] != (UnityEngine.Object) null)
        {
          flag = true;
          person.WeaponInv.SetActiveWeapon(person.WeaponInv.weapons[index]);
        }
      }
    }
    else
      flag = true;
    if (person.DEBUG)
      Debug.Log((object) ("_hasWEapom " + flag.ToString()));
    if (!flag)
    {
      Collider[] colliderArray = Physics.OverlapSphere(person.transform.position, 100f, (int) Main.Instance.ResourceCheckLayers);
      float num1 = 99999f;
      Weapon _closestwweapon = (Weapon) null;
      float num2 = 99999f;
      Weapon weapon1 = (Weapon) null;
      for (int index = 0; index < colliderArray.Length; ++index)
      {
        Weapon weapon2 = colliderArray[index].GetComponentInChildren<Weapon>();
        if ((UnityEngine.Object) weapon2 == (UnityEngine.Object) null)
          weapon2 = colliderArray[index].GetComponentInParent<Weapon>();
        if ((UnityEngine.Object) weapon2 != (UnityEngine.Object) null && !weapon2.PickedUp && person.HasPathTo(weapon2.ActualWeaponModel.transform.position))
        {
          if (weapon2.ThisToolType == e_MiningTool.Undefined)
          {
            float num3 = Vector2.Distance(new Vector2(person.transform.position.x, person.transform.position.z), new Vector2(weapon2.ActualWeaponModel.transform.position.x, weapon2.ActualWeaponModel.transform.position.z));
            if ((double) num3 < (double) num2)
            {
              num2 = num3;
              weapon1 = weapon2;
            }
          }
          else
          {
            float num4 = Vector2.Distance(new Vector2(person.transform.position.x, person.transform.position.z), new Vector2(weapon2.ActualWeaponModel.transform.position.x, weapon2.ActualWeaponModel.transform.position.z));
            if ((double) num4 < (double) num1)
            {
              num1 = num4;
              _closestwweapon = weapon2;
            }
          }
        }
      }
      if ((UnityEngine.Object) weapon1 != (UnityEngine.Object) null)
        _closestwweapon = weapon1;
      if ((UnityEngine.Object) _closestwweapon != (UnityEngine.Object) null)
      {
        if (person.DEBUG)
          Debug.Log((object) "GoPickupWeapon");
        person.NavmeshProxDistance = 1f;
        person.AddCullBlocker("worktime");
        person.AddWorkScheduleTask(new Person.ScheduleTask()
        {
          IDName = "GoPickupWeapon",
          ActionPlace = _closestwweapon.ActualWeaponModel.transform,
          RunTo = true,
          NoMoveChecker = true,
          NoMoveTimer = 4f,
          WhenNoMove = (Action) (() => person.CompleteScheduleTask(true)),
          OnArrive = (Action) (() =>
          {
            if ((UnityEngine.Object) _closestwweapon != (UnityEngine.Object) null && !_closestwweapon.PickedUp && (double) Vector3.Distance(_closestwweapon.ActualWeaponModel.transform.position, person.transform.position) < 1.0)
              person.WeaponInv.PickupWeapon(_closestwweapon.gameObject);
            person.CompleteScheduleTask(true);
          })
        }, true);
        return true;
      }
    }
    if (person.DEBUG)
      Debug.Log((object) "Checking assignments");
    string str = person.SaveableVars.Get("ArmyData");
    string[] strArray1 = (string[]) null;
    if (str != null && str.Length > 1)
    {
      if (person.DEBUG)
        Debug.Log((object) ("_split[0] " + strArray1[0]));
      string[] strArray2 = str.Split(":", StringSplitOptions.None);
      switch (strArray2[0])
      {
        case "1":
          if (person.DEBUG)
            Debug.Log((object) ("_split[1] " + strArray2[1]));
          switch (strArray2[1])
          {
            case "Wonder":
              goto label_52;
            case "Random Spots":
              if (person.DEBUG)
                Debug.Log((object) "LBL_PatrolRandom");
              int_PatrolSpot[] objectsOfType = UnityEngine.Object.FindObjectsOfType<int_PatrolSpot>(true);
              int index1 = UnityEngine.Random.Range(0, objectsOfType.Length);
              person.NavmeshProxDistance = 1f;
              person.AddWorkScheduleTask(new Person.ScheduleTask()
              {
                IDName = "LBL_PatrolRandom",
                ActionPlace = objectsOfType[index1].RootObj.transform,
                RunTo = false,
                NoMoveChecker = true,
                NoMoveTimer = 4f,
                WhenNoMove = (Action) (() => person.CompleteScheduleTask(true)),
                OnArrive = (Action) (() => person.CompleteScheduleTask(true))
              }, true);
              return true;
            default:
              for (int index2 = 0; index2 < Main.Instance.AllPatrols.Count; ++index2)
              {
                if (Main.Instance.AllPatrols[index2].Name == strArray2[1])
                {
                  bl_Patrol allPatrol = Main.Instance.AllPatrols[index2];
                  if (person.DEBUG)
                    Debug.Log((object) "LBL_PatrolSpecific");
                  bl_RandomPatrol blRandomPatrol = person.gameObject.GetComponent<bl_RandomPatrol>();
                  if ((UnityEngine.Object) blRandomPatrol == (UnityEngine.Object) null)
                    blRandomPatrol = person.gameObject.AddComponent<bl_RandomPatrol>();
                  blRandomPatrol.Spots.Clear();
                  blRandomPatrol.Spots.AddRange((IEnumerable<Transform>) allPatrol.Spots);
                  blRandomPatrol.WaitMin = 2f;
                  blRandomPatrol.WaitMax = 10f;
                  blRandomPatrol.NonRandomSpots = true;
                  blRandomPatrol.StartPatrol(person);
                  return true;
                }
              }
              goto label_52;
          }
      }
    }
    if (person.DEBUG)
      Debug.Log((object) "LBL_CheckForTrainees");
    if (UnityEngine.Random.Range(0, 3) == 0)
    {
      int count = Main.Instance.SpawnedPeopleOfType_World[2].Count;
      if (count != 0)
      {
        int index3 = UnityEngine.Random.Range(0, count);
        for (int index4 = 0; index4 < 5; ++index4)
        {
          _trainee = Main.Instance.SpawnedPeopleOfType_World[2][index3];
          if ((UnityEngine.Object) _trainee != (UnityEngine.Object) null && !_trainee.TheHealth.dead && _trainee.ThisPersonInt.CanInteract && !_trainee.Interacting && person.HasPathTo(_trainee.transform.position))
          {
            ++index3;
            if (index3 >= count)
              index3 = 0;
          }
          else
            break;
        }
        if (!((UnityEngine.Object) _trainee == (UnityEngine.Object) null))
        {
          if (person.DEBUG)
            Debug.Log((object) "LBL_TrainThisTrainee");
          person.NavmeshProxDistance = 1f;
          person.AddWorkScheduleTask(new Person.ScheduleTask()
          {
            IDName = "LBL_TrainThisTrainee",
            ActionPlace = _trainee.transform,
            RunTo = true,
            NoMoveChecker = true,
            NoMoveTimer = 4f,
            WhenNoMove = (Action) (() => person.CompleteScheduleTask(true)),
            OnArrive = (Action) (() =>
            {
              if ((UnityEngine.Object) _trainee != (UnityEngine.Object) null && !_trainee.TheHealth.dead && SpawnedSexScene.CanStartSex(person, _trainee) && _trainee.ThisPersonInt.CanInteract)
              {
                _trainee.UnRagdoll();
                SpawnedSexScene spawnedSexScene = Main.Instance.SexScene.SpawnSexScene(4, UnityEngine.Random.Range(0, 4), person, _trainee, canControl: false);
                spawnedSexScene.On_ClothingToggle(true);
                spawnedSexScene.TimerForRandomPoseChange = true;
                spawnedSexScene.TimerMax = UnityEngine.Random.Range(10f, 30f);
                spawnedSexScene.TimerPoseChange = spawnedSexScene.TimerMax;
                spawnedSexScene.TimerForRandomSexEnd = true;
                spawnedSexScene.TimerSexEnd = spawnedSexScene.TimerMax - 1f;
                switch (UnityEngine.Random.Range(0, 6))
                {
                  case 1:
                    _trainee.States[12] = true;
                    break;
                  case 2:
                    _trainee.States[13] = true;
                    break;
                  case 3:
                    _trainee.States[14] = true;
                    break;
                  case 4:
                    _trainee.States[15] = true;
                    break;
                  case 5:
                    _trainee.States[16] = true;
                    break;
                }
                person.CompleteScheduleTask(false);
              }
              else
                person.CompleteScheduleTask(true);
            })
          }, true);
          return true;
        }
      }
    }
label_52:
    if (person.DEBUG)
      Debug.Log((object) "LBL_PatrolWonder");
    return false;
  }
}
