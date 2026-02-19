// Decompiled with JetBrains decompiler
// Type: bl_RandomPatrol
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
  public bool NonRandomSpots;
  public int _PreviousSpot;

  public void StartPatrol(Person person)
  {
    this.ThisPerson = person;
    this.AddDestonationPatrol();
  }

  public void AddDestonationPatrol()
  {
    if (Main.Instance.OpenWorld)
    {
      string str = this.ThisPerson.SaveableVars.Get("ArmyData");
      if (str == null || str.Length <= 1)
        return;
      string[] strArray = str.Split(":", StringSplitOptions.None);
      if (!(strArray[0] == "1"))
        return;
      switch (strArray[1])
      {
        case "Wonder":
          return;
        case "Random Spots":
          return;
      }
    }
    Transform spot;
    if (!this.NonRandomSpots)
    {
      do
      {
        spot = this.Spots[UnityEngine.Random.Range(0, this.Spots.Count)];
      }
      while ((UnityEngine.Object) spot == (UnityEngine.Object) null);
    }
    else
    {
      do
      {
        spot = this.Spots[this._PreviousSpot];
        ++this._PreviousSpot;
        if (this._PreviousSpot >= this.Spots.Count)
          this._PreviousSpot = 0;
      }
      while ((UnityEngine.Object) spot == (UnityEngine.Object) null);
    }
    this.ThisPerson.AddWorkScheduleTask(new Person.ScheduleTask()
    {
      IDName = "Patrol",
      ActionPlace = spot,
      OnArrive = (Action) (() =>
      {
        this.ThisPerson.WorkScheduleTasks.Clear();
        this.ThisPerson.CompleteScheduleTask(false);
        this.ThisPerson.DecideTimer = UnityEngine.Random.Range(this.WaitMin, this.WaitMax);
        this.AddDestonationPatrol();
      })
    });
  }

  public void WaitSomeTime()
  {
    this.ThisPerson.CompleteScheduleTask();
    this.Invoke("AddDestonationPatrol", UnityEngine.Random.Range(this.WaitMin, this.WaitMax));
  }
}
