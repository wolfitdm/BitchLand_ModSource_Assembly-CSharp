// Decompiled with JetBrains decompiler
// Type: job_ArmyBuildingWork
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class job_ArmyBuildingWork : bl_WorkJobManager
{
  public List<Transform> StandSpots = new List<Transform>();
  public List<bl_RandomPatrol> Patrols = new List<bl_RandomPatrol>();
  public Interactible SiaSpot;
  public List<MultiInteractible> WallPussies = new List<MultiInteractible>();

  public Person.ScheduleTask StandGuardTask(Person person)
  {
    return new Person.ScheduleTask()
    {
      IDName = "GuardStandSpot",
      ActionPlace = this.StandSpots[person.JobIndex],
      OnArrive = (Action) (() =>
      {
        person.RandActionTimer = 10f;
        person.transform.position = this.StandSpots[person.JobIndex].position;
        person.transform.eulerAngles = this.StandSpots[person.JobIndex].eulerAngles;
      }),
      WhileDoing = (Action) (() =>
      {
        person.RandActionTimer -= Time.deltaTime;
        if ((double) person.RandActionTimer >= 0.0)
          return;
        person.AddWorkScheduleTask(this.StandGuardTask(person));
        person.CompleteScheduleTask();
      })
    };
  }

  public override void AddJobToWorker(Person person)
  {
    base.AddJobToWorker(person);
    int jobIndex = person.JobIndex;
    switch (jobIndex)
    {
      case 0:
      case 1:
      case 2:
      case 3:
      case 4:
      case 5:
      case 8:
        person.AddWorkScheduleTask(this.StandGuardTask(person), true);
        break;
      case 6:
      case 7:
        person.ThisPersonInt.StartTalkMono = (MonoBehaviour) this;
        person.ThisPersonInt.StartTalkFunc = "Chat_ReceptionGuard";
        person.AddWorkScheduleTask(this.StandGuardTask(person), true);
        break;
      case 9:
        break;
      case 10:
        break;
      case 11:
        break;
      case 12:
        break;
      case 13:
        break;
      case 14:
        break;
      case 15:
        break;
      case 16 /*0x10*/:
        break;
      case 17:
        break;
      case 18:
        break;
      case 19:
        break;
      case 20:
      case 21:
      case 22:
      case 23:
        this.Patrols[person.JobIndex - 20].StartPatrol(person);
        break;
      case 100:
        this.SiaSpot.Interact(person);
        break;
      default:
        int num = jobIndex - 101;
        break;
    }
  }

  public override void _EndWorkFor(Person person)
  {
    base._EndWorkFor(person);
    person.AddGoHome();
  }

  public void Chat_ReceptionGuard()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person person = _gameplay.PersonChattingTo;
    _gameplay.RemoveAllChatOptions();
    _gameplay.AddChatOption("What's your name?", (Action) (() =>
    {
      Main.Instance.GameplayMenu.EnableMove();
      person.PlayerKnowsName = true;
      person.ThisPersonInt.InteractText = "Talk to " + person.Name;
      string[] strArray = new string[3]
      {
        person.Name,
        "It's " + person.Name,
        "My name's " + person.Name
      };
      _gameplay.DisplaySubtitle(strArray[UnityEngine.Random.Range(0, strArray.Length)], (AudioClip) null, new Action(person.ThisPersonInt.EndTheChat));
    }));
    _gameplay.AddChatOption("You're cute, let's have sex", (Action) (() =>
    {
      Main.Instance.GameplayMenu.EnableMove();
      _gameplay.DisplaySubtitle("I can't right now", (AudioClip) null, new Action(person.ThisPersonInt.EndTheChat));
    }));
    _gameplay.AddChatOption("I'd like to work here", (Action) (() =>
    {
      Main.Instance.GameplayMenu.EnableMove();
      _gameplay.DisplaySubtitle("Talk with War, she's just outside", (AudioClip) null, new Action(person.ThisPersonInt.EndTheChat));
    }));
    _gameplay.SelectChatOption(0);
    Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
  }
}
