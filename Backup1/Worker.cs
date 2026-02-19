// Decompiled with JetBrains decompiler
// Type: Worker
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#nullable disable
public class Worker : BaseType
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
        person.StartingClothes.Add(this.Prefabs_Any[UnityEngine.Random.Range(0, this.Prefabs_Any.Count)]);
        person.StartingClothes.Add(this.Prefabs_Top[UnityEngine.Random.Range(0, this.Prefabs_Top.Count)]);
        person.StartingClothes.Add(this.Prefabs_Pants[UnityEngine.Random.Range(0, this.Prefabs_Pants.Count)]);
        person.StartingClothes.Add(this.Prefabs_Shoes[UnityEngine.Random.Range(0, this.Prefabs_Shoes.Count)]);
      }
      else
      {
        person.StartingClothes.Add(this.PrefabsMale_Top[UnityEngine.Random.Range(0, this.PrefabsMale_Top.Count)]);
        person.StartingClothes.Add(this.PrefabsMale_Pants[UnityEngine.Random.Range(0, this.PrefabsMale_Pants.Count)]);
        person.StartingClothes.Add(this.PrefabsMale_Shoes[UnityEngine.Random.Range(0, this.PrefabsMale_Shoes.Count)]);
        if ((double) UnityEngine.Random.Range(0.0f, 1f) < 0.30000001192092896)
          person.StartingClothes.Add(Main.Instance.Prefabs_Beards[UnityEngine.Random.Range(0, Main.Instance.Prefabs_Beards.Count)]);
      }
      GameObject prefabsWeapon = this.Prefabs_Weapons[UnityEngine.Random.Range(0, this.Prefabs_Weapons.Count)];
      if ((UnityEngine.Object) prefabsWeapon != (UnityEngine.Object) null)
      {
        GameObject weapon = UnityEngine.Object.Instantiate<GameObject>(prefabsWeapon);
        person.WeaponInv.PickupWeapon(weapon);
        person.WeaponInv.startingWeaponIndex = 1;
      }
    }
    base.ApplyTo(person, addClothing, addWeapon, addHair);
    switch (UnityEngine.Random.Range(0, 4))
    {
      case 1:
        person.States[12] = true;
        break;
      case 2:
        person.States[13] = true;
        break;
    }
    if (UnityEngine.Random.Range(0, 3) == 0)
      person.States[20] = true;
    person.DirtySkin = (double) UnityEngine.Random.Range(0.0f, 1f) > 0.5;
  }

  public override void GetAssignedto(Person person)
  {
    base.GetAssignedto(person);
    person.State = Person_State.Work;
  }

  public override void GetUnAssigned(Person person)
  {
    base.GetUnAssigned(person);
    person.Storage_Hands.RemoveAllItems();
  }

  public override bool BehaviourPass(Person person)
  {
    person.SeekBed();
    return false;
  }

  public Transform FindAnyAccessToPlan(int_ConstructionPlan plan, Person person)
  {
    if ((UnityEngine.Object) plan.NavMeshInteractSpot != (UnityEngine.Object) null && person.HasPathTo(plan.NavMeshInteractSpot.position))
      return plan.NavMeshInteractSpot;
    for (int index = 0; index < plan.ReferenceSpots.Length; ++index)
    {
      if (person.HasPathTo(plan.ReferenceSpots[index].position))
        return plan.ReferenceSpots[index];
    }
    for (int index = 0; index < plan.ConstructionSpots.Length; ++index)
    {
      if (person.HasPathTo(plan.ConstructionSpots[index].position))
        return plan.ConstructionSpots[index];
    }
    if ((UnityEngine.Object) plan.RootObj != (UnityEngine.Object) null && person.HasPathTo(plan.RootObj.transform.position))
      return plan.RootObj.transform;
    return person.HasPathTo(plan.transform.position) ? plan.transform : (Transform) null;
  }

  public override bool BehaviourPass_Work(Person person)
  {
    int_ConstructionPlan _planToDo = (int_ConstructionPlan) null;
    int_ConstructionPlan _planToMineFor = (int_ConstructionPlan) null;
    float num1 = 99999f;
    float num2 = 99999f;
    bool flag1 = false;
    switch (person.PersonalityData.WorkEffeciency)
    {
      case e_WorkEffeciency.Default:
        flag1 = !person.NeedsEnergy;
        break;
      case e_WorkEffeciency.Lazy:
        flag1 = false;
        break;
      case e_WorkEffeciency.Energetic:
        flag1 = true;
        break;
      case e_WorkEffeciency.Depends_Rel_LazyLow_EnerHigh:
        flag1 = person.Favor > 70;
        break;
    }
    int_ConstructionPlan[] objectsOfType = UnityEngine.Object.FindObjectsOfType<int_ConstructionPlan>();
    Dictionary<int_ConstructionPlan, float> source1 = new Dictionary<int_ConstructionPlan, float>();
    Dictionary<int_ConstructionPlan, float> source2 = new Dictionary<int_ConstructionPlan, float>();
    for (int index = 0; index < objectsOfType.Length; ++index)
    {
      if (!objectsOfType[index].BeingMoved && !objectsOfType[index].CanNOTBuild && objectsOfType[index].CanAddPersonToBuild)
      {
        float num3 = Vector2.Distance(new Vector2(objectsOfType[index].RootObj.transform.position.x, objectsOfType[index].RootObj.transform.position.z), new Vector2(person.transform.position.x, person.transform.position.z));
        if ((double) num3 < 250.0)
        {
          if (objectsOfType[index].AllResourcesIn)
          {
            if (!source1.ContainsKey(objectsOfType[index]))
              source1.Add(objectsOfType[index], num3);
            if ((double) num3 < (double) num1)
            {
              num1 = num3;
              _planToDo = objectsOfType[index];
            }
          }
          else
          {
            if (!source2.ContainsKey(objectsOfType[index]))
              source2.Add(objectsOfType[index], num3);
            if ((double) num3 < (double) num2)
            {
              num2 = num3;
              _planToMineFor = objectsOfType[index];
            }
          }
        }
      }
    }
label_19:
    if ((UnityEngine.Object) _planToDo != (UnityEngine.Object) null)
    {
      if (person.DEBUG)
        Debug.Log((object) "GoBuildPlan");
      Transform anyAccessToPlan = this.FindAnyAccessToPlan(_planToDo, person);
      if (!((UnityEngine.Object) anyAccessToPlan == (UnityEngine.Object) null))
      {
        person.Storage_Hands.RemoveAllItems();
        person.NavmeshProxDistance = 1f;
        person.AddCullBlocker("worktime");
        person.AddWorkScheduleTask(new Person.ScheduleTask()
        {
          IDName = "GoBuildPlan",
          ActionPlace = anyAccessToPlan,
          RunTo = flag1,
          NoMoveChecker = true,
          NoMoveTimer = 4f,
          WhenNoMove = (Action) (() => person.CompleteScheduleTask(true)),
          OnArrive = (Action) (() =>
          {
            if ((UnityEngine.Object) _planToDo != (UnityEngine.Object) null)
            {
              _planToDo.Interact(person);
              person.CompleteScheduleTask(false);
            }
            else
              person.CompleteScheduleTask(true);
          })
        }, true);
        return true;
      }
    }
    else if (!((UnityEngine.Object) _planToMineFor != (UnityEngine.Object) null))
      goto label_110;
    else
      goto label_45;
label_25:
    if (person.DEBUG)
      Debug.Log((object) "LBL_SortPlanLists");
    Dictionary<int_ConstructionPlan, float> dictionary1 = source1.OrderBy<KeyValuePair<int_ConstructionPlan, float>, float>((Func<KeyValuePair<int_ConstructionPlan, float>, float>) (p => p.Value)).ToDictionary<KeyValuePair<int_ConstructionPlan, float>, int_ConstructionPlan, float>((Func<KeyValuePair<int_ConstructionPlan, float>, int_ConstructionPlan>) (p => p.Key), (Func<KeyValuePair<int_ConstructionPlan, float>, float>) (p => p.Value));
    Dictionary<int_ConstructionPlan, float> dictionary2 = source2.OrderBy<KeyValuePair<int_ConstructionPlan, float>, float>((Func<KeyValuePair<int_ConstructionPlan, float>, float>) (p => p.Value)).ToDictionary<KeyValuePair<int_ConstructionPlan, float>, int_ConstructionPlan, float>((Func<KeyValuePair<int_ConstructionPlan, float>, int_ConstructionPlan>) (p => p.Key), (Func<KeyValuePair<int_ConstructionPlan, float>, float>) (p => p.Value));
    if (dictionary1.Count > 0)
    {
      if (person.DEBUG)
        Debug.Log((object) "(_sortedPlans_allin.Count > 0)");
      foreach (KeyValuePair<int_ConstructionPlan, float> keyValuePair in dictionary1)
      {
        int_ConstructionPlan key = keyValuePair.Key;
        if ((UnityEngine.Object) this.FindAnyAccessToPlan(key, person) != (UnityEngine.Object) null)
        {
          _planToDo = key;
          goto label_19;
        }
      }
    }
    if (dictionary2.Count > 0)
    {
      if (person.DEBUG)
        Debug.Log((object) "(_sortedPlans.Count > 0)");
      using (Dictionary<int_ConstructionPlan, float>.Enumerator enumerator = dictionary2.GetEnumerator())
      {
        while (enumerator.MoveNext())
        {
          int_ConstructionPlan key = enumerator.Current.Key;
          if ((UnityEngine.Object) this.FindAnyAccessToPlan(key, person) != (UnityEngine.Object) null)
          {
            _planToMineFor = key;
            goto label_45;
          }
        }
        goto label_110;
      }
    }
    else
      goto label_110;
label_45:
    bool hasTooManyOfAny;
    e_ResourceType resource = _planToMineFor.NextRandomIngredient(out hasTooManyOfAny, out int _);
    int ofResourcesInInv = person.GetAmountOfResourcesInInv(resource);
    if (person.DEBUG)
    {
      Debug.Log((object) "LBL_GotPlanToMineFor");
      Debug.Log((object) ("_ing = " + resource.ToString()));
      Debug.Log((object) ("_toomany = " + hasTooManyOfAny.ToString()));
      Debug.Log((object) ("_resIHave = " + ofResourcesInInv.ToString()));
    }
    if (ofResourcesInInv != 0 | hasTooManyOfAny)
    {
      if (person.DEBUG)
        Debug.Log((object) "GoAddOrRemoveResourcesToPlan");
      Transform anyAccessToPlan = this.FindAnyAccessToPlan(_planToMineFor, person);
      if (!((UnityEngine.Object) anyAccessToPlan == (UnityEngine.Object) null))
      {
        person.NavmeshProxDistance = 1f;
        person.AddCullBlocker("worktime");
        person.AddWorkScheduleTask(new Person.ScheduleTask()
        {
          IDName = "GoAddOrRemoveResourcesToPlan",
          ActionPlace = anyAccessToPlan,
          RunTo = flag1,
          NoMoveChecker = true,
          NoMoveTimer = 4f,
          WhenNoMove = (Action) (() => person.CompleteScheduleTask(true)),
          OnArrive = (Action) (() =>
          {
            if ((UnityEngine.Object) _planToMineFor != (UnityEngine.Object) null)
              _planToMineFor.Interact(person);
            person.CompleteScheduleTask(true);
          })
        }, true);
        return true;
      }
      goto label_25;
    }
    else
    {
      Collider[] colliderArray1 = Physics.OverlapSphere(person.transform.position, 100f, (int) Main.Instance.ResourceCheckLayers);
      if (person.DEBUG)
        Debug.Log((object) ("_woodhits = " + colliderArray1.Length.ToString()));
      Dictionary<int_ResourceItem, float> source3 = new Dictionary<int_ResourceItem, float>();
      float num4 = 99999f;
      int_ResourceItem _closestwood = (int_ResourceItem) null;
      for (int index = 0; index < colliderArray1.Length; ++index)
      {
        int_ResourceItem componentInChildren = colliderArray1[index].GetComponentInChildren<int_ResourceItem>();
        if ((UnityEngine.Object) componentInChildren != (UnityEngine.Object) null && componentInChildren.ResourceType == resource && (UnityEngine.Object) componentInChildren.RootObj.transform.parent == (UnityEngine.Object) null)
        {
          float num5 = Vector2.Distance(new Vector2(person.transform.position.x, person.transform.position.z), new Vector2(componentInChildren.RootObj.transform.position.x, componentInChildren.RootObj.transform.position.z));
          if (!source3.ContainsKey(componentInChildren))
            source3.Add(componentInChildren, num5);
          if ((double) num5 < (double) num4)
          {
            num4 = num5;
            _closestwood = componentInChildren;
          }
        }
      }
      if ((UnityEngine.Object) _closestwood != (UnityEngine.Object) null)
      {
        if (person.DEBUG)
          Debug.Log((object) "Gopickupwood");
        Transform transform = (UnityEngine.Object) _closestwood.RootObj != (UnityEngine.Object) null ? _closestwood.RootObj.transform : _closestwood.NavMeshInteractSpot ?? _closestwood.transform;
        if (!person.HasPathTo(transform.position))
        {
          Dictionary<int_ResourceItem, float> dictionary3 = source3.OrderBy<KeyValuePair<int_ResourceItem, float>, float>((Func<KeyValuePair<int_ResourceItem, float>, float>) (p => p.Value)).ToDictionary<KeyValuePair<int_ResourceItem, float>, int_ResourceItem, float>((Func<KeyValuePair<int_ResourceItem, float>, int_ResourceItem>) (p => p.Key), (Func<KeyValuePair<int_ResourceItem, float>, float>) (p => p.Value));
          if (dictionary3.Count > 0)
          {
            using (Dictionary<int_ResourceItem, float>.Enumerator enumerator = dictionary3.GetEnumerator())
            {
              while (enumerator.MoveNext())
              {
                _closestwood = enumerator.Current.Key;
                transform = (UnityEngine.Object) _closestwood.RootObj != (UnityEngine.Object) null ? _closestwood.RootObj.transform : _closestwood.NavMeshInteractSpot ?? _closestwood.transform;
                if (person.HasPathTo(transform.position))
                  goto label_72;
              }
              goto label_73;
            }
          }
          else
            goto label_73;
        }
label_72:
        person.Storage_Hands.RemoveAllItems();
        person.NavmeshProxDistance = 1f;
        person.AddCullBlocker("worktime");
        person.AddWorkScheduleTask(new Person.ScheduleTask()
        {
          IDName = "Gopickupwood",
          ActionPlace = transform,
          RunTo = flag1,
          NoMoveChecker = true,
          NoMoveTimer = 4f,
          WhenNoMove = (Action) (() => person.CompleteScheduleTask(true)),
          OnArrive = (Action) (() =>
          {
            if ((UnityEngine.Object) _closestwood != (UnityEngine.Object) null && (double) Vector3.Distance(_closestwood.transform.position, person.transform.position) < 1.0)
              person.PickUpItem(_closestwood.RootObj);
            person.CompleteScheduleTask(true);
          })
        }, true);
        return true;
      }
label_73:
      Collider[] colliderArray2 = colliderArray1;
      if (person.DEBUG)
        Debug.Log((object) ("_treehits -> " + colliderArray2.Length.ToString()));
      float num6 = 99999f;
      bl_MinableObject _closestTree = (bl_MinableObject) null;
      for (int index = 0; index < colliderArray2.Length; ++index)
      {
        bl_MinableObject blMinableObject = colliderArray2[index].GetComponentInChildren<bl_MinableObject>();
        InteractRedirect component = colliderArray2[index].GetComponent<InteractRedirect>();
        if ((UnityEngine.Object) blMinableObject == (UnityEngine.Object) null && (UnityEngine.Object) component != (UnityEngine.Object) null && component.Redirect is bl_MinableObject)
          blMinableObject = (bl_MinableObject) component.Redirect;
        if ((UnityEngine.Object) blMinableObject != (UnityEngine.Object) null && blMinableObject.RawResources && blMinableObject.ResourceItOffers == resource && blMinableObject.CheckCanInteract(person) && person.HasPathTo(blMinableObject.RootObj.transform.position))
        {
          float num7 = Vector2.Distance(new Vector2(person.transform.position.x, person.transform.position.z), new Vector2(blMinableObject.RootObj.transform.position.x, blMinableObject.RootObj.transform.position.z));
          if ((double) num7 < (double) num6)
          {
            num6 = num7;
            _closestTree = blMinableObject;
          }
        }
      }
      if ((UnityEngine.Object) _closestTree != (UnityEngine.Object) null)
      {
        if (person.DEBUG)
          Debug.Log((object) ("_closestTree != null -> " + _closestTree.RootObj.name));
        if (person.DEBUG)
          Debug.Log((object) ("_closesttreedist = " + num6.ToString()));
        for (int index = 0; index < person.WeaponInv.weapons.Count; ++index)
        {
          if ((UnityEngine.Object) person.WeaponInv.weapons[index] != (UnityEngine.Object) null && person.WeaponInv.weapons[index].GetComponent<Weapon>().ThisToolType == _closestTree.MiningTool)
          {
            person.WeaponInv.SetActiveWeapon(index);
            if (person.DEBUG)
              Debug.Log((object) "LBL_GoMineTree");
            person.Storage_Hands.RemoveAllItems();
            person.NavmeshProxDistance = 2f;
            person.AddCullBlocker("worktime");
            person.AddWorkScheduleTask(new Person.ScheduleTask()
            {
              IDName = "GoMineTree",
              ActionPlace = _closestTree.RootObj.transform ?? _closestTree.NavMeshInteractSpot ?? _closestTree.transform,
              RunTo = flag1,
              NoMoveChecker = true,
              NoMoveTimer = 4f,
              WhenNoMove = (Action) (() => person.CompleteScheduleTask(true)),
              OnArrive = (Action) (() =>
              {
                if ((UnityEngine.Object) _closestTree != (UnityEngine.Object) null && _closestTree.CheckCanInteract(person))
                {
                  person.Do_Schedule_GoingToTargetThread = false;
                  person.CompleteScheduleTask(false);
                  _closestTree.Interact(person);
                }
                else
                  person.CompleteScheduleTask(true);
              })
            }, true);
            return true;
          }
        }
        if (person.DEBUG)
          Debug.Log((object) "no tool");
        Collider[] colliderArray3 = colliderArray1;
        for (int index = 0; index < colliderArray3.Length; ++index)
        {
          Weapon _weapon = colliderArray3[index].GetComponentInChildren<Weapon>();
          if ((UnityEngine.Object) _weapon == (UnityEngine.Object) null)
            _weapon = colliderArray3[index].GetComponentInParent<Weapon>();
          if (person.DEBUG && (UnityEngine.Object) _weapon != (UnityEngine.Object) null)
          {
            bool flag2 = !_weapon.PickedUp;
            Debug.Log((object) ("!_weapon.PickedUp " + flag2.ToString()));
            flag2 = _weapon.ThisToolType == _closestTree.MiningTool;
            Debug.Log((object) ("_weapon.ThisToolType == _closestTree.MiningTool " + flag2.ToString()));
          }
          if ((UnityEngine.Object) _weapon != (UnityEngine.Object) null && !_weapon.PickedUp && _weapon.ThisToolType == _closestTree.MiningTool && person.HasPathTo(_weapon.ActualWeaponModel.position))
          {
            if (person.DEBUG)
              Debug.Log((object) "GoPickupTool");
            person.NavmeshProxDistance = 1f;
            person.AddCullBlocker("worktime");
            person.AddWorkScheduleTask(new Person.ScheduleTask()
            {
              IDName = "GoPickupTool",
              ActionPlace = _weapon.ActualWeaponModel.transform,
              RunTo = flag1,
              NoMoveChecker = true,
              NoMoveTimer = 4f,
              WhenNoMove = (Action) (() => person.CompleteScheduleTask(true)),
              OnArrive = (Action) (() =>
              {
                if ((UnityEngine.Object) _weapon != (UnityEngine.Object) null && !_weapon.PickedUp && (double) Vector3.Distance(_weapon.ActualWeaponModel.transform.position, person.transform.position) < 1.0)
                  person.WeaponInv.PickupWeapon(_weapon.gameObject);
                person.CompleteScheduleTask(true);
              })
            }, true);
            return true;
          }
        }
      }
      if (person.DEBUG)
        Debug.Log((object) "no mineable type");
    }
label_110:
    if (person.DEBUG)
      Debug.Log((object) "LBL_FindStore");
    person.Storage_Hands.RemoveAllItems();
    if ((UnityEngine.Object) person.WeaponInv.CurrentWeapon != (UnityEngine.Object) null)
      person.WeaponInv.CurrentWeapon.Holdster();
    person.NavmeshProxDistance = 0.2f;
    person.RemoveCullBlocker("worktime");
    return false;
  }
}
