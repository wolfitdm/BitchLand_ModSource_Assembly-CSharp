// Decompiled with JetBrains decompiler
// Type: Civilian
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
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
        person.StartingClothes.Add(this.Prefabs_Any[UnityEngine.Random.Range(0, this.Prefabs_Any.Count)]);
        person.StartingClothes.Add(this.Prefabs_Top[UnityEngine.Random.Range(0, this.Prefabs_Top.Count)]);
        person.StartingClothes.Add(this.Prefabs_Pants[UnityEngine.Random.Range(0, this.Prefabs_Pants.Count)]);
        person.StartingClothes.Add(this.Prefabs_Shoes[UnityEngine.Random.Range(0, this.Prefabs_Shoes.Count)]);
        person.StartingClothes.Add(this.Prefabs_Garter[UnityEngine.Random.Range(0, this.Prefabs_Garter.Count)]);
      }
      else
      {
        person.StartingClothes.Add(this.PrefabsMale_Top[UnityEngine.Random.Range(0, this.PrefabsMale_Top.Count)]);
        person.StartingClothes.Add(this.PrefabsMale_Pants[UnityEngine.Random.Range(0, this.PrefabsMale_Pants.Count)]);
        person.StartingClothes.Add(this.PrefabsMale_Shoes[UnityEngine.Random.Range(0, this.PrefabsMale_Shoes.Count)]);
        if ((double) UnityEngine.Random.Range(0.0f, 1f) < 0.30000001192092896)
          person.StartingClothes.Add(Main.Instance.Prefabs_Beards[UnityEngine.Random.Range(0, Main.Instance.Prefabs_Beards.Count)]);
      }
    }
    base.ApplyTo(person, addClothing, addWeapon, addHair, commingFrom);
    if (UnityEngine.Random.Range(0, 4) != 1)
      return;
    person.States[12] = true;
  }

  public override void GetAssignedto(Person person)
  {
    base.GetAssignedto(person);
    if (!Main.Instance.OpenWorld)
      return;
    person.State = Person_State.Work;
  }

  public override bool BehaviourPass(Person person)
  {
    if (Main.Instance.OpenWorld)
      person.SeekBed();
    return false;
  }

  public override bool BehaviourPass_Work(Person person)
  {
    if ((double) UnityEngine.Random.Range(0.0f, 1f) >= 0.5)
    {
      List<bl_ow_job> blOwJobList = new List<bl_ow_job>();
      foreach (Component component1 in Physics.OverlapSphere(person.transform.position, 100f, (int) Main.Instance.ResourceCheckLayers))
      {
        bl_ow_job component2 = component1.GetComponent<bl_ow_job>();
        if ((UnityEngine.Object) component2 != (UnityEngine.Object) null && !component2.BeingMoved && component2.ForClass == this.ThisType && (UnityEngine.Object) component2.WorkerSpot.InteractingPerson == (UnityEngine.Object) null)
          blOwJobList.Add(component2);
      }
      if (person.DEBUG)
        Debug.Log((object) ("_jobs.Count " + blOwJobList.Count.ToString()));
      float num = 999999f;
      bl_ow_job _closest = (bl_ow_job) null;
      for (int index = 0; index < blOwJobList.Count; ++index)
      {
        bl_ow_job blOwJob = blOwJobList[index];
        if ((double) Vector2.Distance(new Vector2(person.transform.position.x, person.transform.position.z), new Vector2(blOwJob.RootObj.transform.position.x, blOwJob.RootObj.transform.position.z)) < (double) num)
          _closest = blOwJob;
      }
      if ((UnityEngine.Object) _closest != (UnityEngine.Object) null)
      {
        if (person.DEBUG)
          Debug.Log((object) "closest != null   1111");
        bool flag = false;
        switch (person.PersonalityData.WorkEffeciency)
        {
          case e_WorkEffeciency.Default:
            flag = !person.NeedsEnergy;
            break;
          case e_WorkEffeciency.Lazy:
            flag = false;
            break;
          case e_WorkEffeciency.Energetic:
            flag = true;
            break;
          case e_WorkEffeciency.Depends_Rel_LazyLow_EnerHigh:
            flag = person.Favor > 70;
            break;
        }
        if (!person.HasPathTo(_closest.WorkerSpot.transform.position))
        {
          for (int index = 0; index < blOwJobList.Count; ++index)
          {
            bl_ow_job blOwJob = blOwJobList[index];
            if (person.HasPathTo(blOwJob.WorkerSpot.transform.position))
            {
              _closest = blOwJob;
              if (person.DEBUG)
              {
                Debug.Log((object) "closest != null   22222");
                goto label_28;
              }
              else
                goto label_28;
            }
          }
          goto label_31;
        }
label_28:
        if (person.DEBUG)
          Debug.Log((object) "LBL_GoToThisJob");
        person.NavmeshProxDistance = 1f;
        person.AddCullBlocker("worktime");
        person.AddWorkScheduleTask(new Person.ScheduleTask()
        {
          IDName = "GoToCivJob",
          ActionPlace = _closest.WorkerSpot.transform,
          RunTo = flag,
          NoMoveChecker = true,
          NoMoveTimer = 4f,
          WhenNoMove = (Action) (() => person.CompleteScheduleTask(true)),
          OnArrive = (Action) (() =>
          {
            if ((UnityEngine.Object) _closest != (UnityEngine.Object) null && (UnityEngine.Object) _closest.WorkerSpot != (UnityEngine.Object) null && (UnityEngine.Object) _closest.WorkerSpot.InteractingPerson == (UnityEngine.Object) null)
              _closest.WorkerSpot.Interact(person);
            person.CompleteScheduleTask(true);
          })
        }, true);
        return true;
      }
    }
label_31:
    if (person.DEBUG)
      Debug.Log((object) "nothing to do");
    person.NavmeshProxDistance = 0.2f;
    person.RemoveCullBlocker("worktime");
    return false;
  }
}
