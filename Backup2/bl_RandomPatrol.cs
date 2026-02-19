// Decompiled with JetBrains decompiler
// Type: bl_RandomPatrol
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class bl_RandomPatrol : MonoBehaviour
{
  public Person ThisPerson;
  public List<Transform> Spots = new List<Transform>();
  public float WaitMin;
  public float WaitMax;

  public void StartPatrol(Person person)
  {
    this.ThisPerson = person;
    this.AddDestonationPatrol();
  }

  public void AddDestonationPatrol()
  {
    this.ThisPerson.AddWorkScheduleTask(new Person.ScheduleTask()
    {
      IDName = "Patrol",
      ActionPlace = this.Spots[UnityEngine.Random.Range(0, this.Spots.Count)],
      OnArrive = (Action) (() =>
      {
        this.AddDestonationPatrol();
        this.ThisPerson.CompleteScheduleTask(false);
        this.ThisPerson.DecideTimer = UnityEngine.Random.Range(this.WaitMin, this.WaitMax);
      })
    });
  }

  public void WaitSomeTime()
  {
    this.ThisPerson.CompleteScheduleTask();
    this.Invoke("AddDestonationPatrol", UnityEngine.Random.Range(this.WaitMin, this.WaitMax));
  }
}
