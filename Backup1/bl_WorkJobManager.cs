// Decompiled with JetBrains decompiler
// Type: bl_WorkJobManager
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class bl_WorkJobManager : MonoBehaviour
{
  public string JobName;
  public float Time_SmallerCheckpoint = 0.25f;
  public float Time_LargerCheckpoint = 0.75f;
  public bool WorksInsideCheckpoints;
  public bool _CurrentTimeIsInsideCheckpoints;
  public bool FindWorkerWhenNull;
  public bl_HangZone AssociatedZone;
  public bool NeverEndJob;
  public bool CalledJobStart;
  public bool CalledJobEnd;
  public bool WorkTime;
  public List<Person> Workers = new List<Person>();
  public Transform WorkStartPlace;

  public DayNightCycle DayCycle
  {
    get => Main.Instance.DayCycle;
    set => Main.Instance.DayCycle = value;
  }

  public virtual void Start()
  {
  }

  public void Update()
  {
    this._CurrentTimeIsInsideCheckpoints = (double) this.DayCycle.timeOfDay > (double) this.Time_SmallerCheckpoint && (double) this.DayCycle.timeOfDay < (double) this.Time_LargerCheckpoint;
    if (!this.CalledJobStart && this._CurrentTimeIsInsideCheckpoints == this.WorksInsideCheckpoints)
      this.OnWorkStart();
    if (this.NeverEndJob || !this.WorkTime || this.CalledJobEnd || !this._CurrentTimeIsInsideCheckpoints != this.WorksInsideCheckpoints)
      return;
    this.OnWorkEnd();
  }

  public virtual void OnWorkStart()
  {
    this.WorkTime = true;
    this.CalledJobStart = true;
    this.CalledJobEnd = false;
    if (this.FindWorkerWhenNull && this.Workers.Count == 0)
    {
      Main.Instance.ActionAfterWhenNav((Action) (() => Main.RunInSeconds((Action) (() =>
      {
        if (this.Workers.Count != 0)
          return;
        for (int index = 0; index < this.AssociatedZone.PeopleInZone.Count; ++index)
        {
          if (!this.AssociatedZone.PeopleInZone[index].IsPlayer && (UnityEngine.Object) this.AssociatedZone.PeopleInZone[index].WorkJob == (UnityEngine.Object) null && this.AssociatedZone.PeopleInZone[index].State == Person_State.Free && this.AssociatedZone.PeopleInZone[index].PersonType.ThisType != Person_Type.Army && this.AssociatedZone.PeopleInZone[index].PersonType.ThisType != Person_Type.Royal && this.AssociatedZone.PeopleInZone[index].PersonType.ThisType != Person_Type.HigherCivilian && this.AssociatedZone.PeopleInZone[index].PersonType.ThisType != Person_Type.ESB)
          {
            this.AddWorker(this.AssociatedZone.PeopleInZone[index]);
            break;
          }
        }
      }), 10f)));
    }
    else
    {
      for (int index = 0; index < this.Workers.Count; ++index)
        this._StartWorkFor(this.Workers[index]);
    }
  }

  public virtual void OnWorkEnd()
  {
    this.WorkTime = false;
    this.CalledJobStart = false;
    this.CalledJobEnd = true;
    for (int index = 0; index < this.Workers.Count; ++index)
      this._EndWorkFor(this.Workers[index]);
  }

  public virtual void _StartWorkFor(Person person)
  {
    person.State = Person_State.Work;
    this.AddJobToWorker(person);
  }

  public virtual void _EndWorkFor(Person person)
  {
    person.AddWorkScheduleTask(new Person.ScheduleTask()
    {
      IDName = "LeaveWork",
      ActionPlace = person.transform,
      OnStartGoing = (Action) (() =>
      {
        person.State = Person_State.Free;
        person.CompleteScheduleTask();
      })
    }, true);
  }

  public virtual void AddWorker(Person person)
  {
    person.WorkJob = this;
    if (!this.Workers.Contains(person))
      this.Workers.Add(person);
    if (!this.WorkTime)
      return;
    this._StartWorkFor(person);
  }

  public virtual void AddJobToWorker(Person person)
  {
  }
}
