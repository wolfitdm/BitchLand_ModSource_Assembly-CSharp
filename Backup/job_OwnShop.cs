// Decompiled with JetBrains decompiler
// Type: job_OwnShop
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class job_OwnShop : bl_WorkJobManager
{
  public List<Transform> StandSpots = new List<Transform>();
  public List<Transform> ItemSpawnSpots = new List<Transform>();
  public List<GameObject> Items = new List<GameObject>();
  public Int_Storage Storage;

  public Person.ScheduleTask StandShopTask(Person person)
  {
    return new Person.ScheduleTask()
    {
      IDName = "ShopStandSpot",
      ActionPlace = this.StandSpots[person.JobIndex],
      RunTo = true,
      KeepPathEnabled = true,
      OnArrive = (Action) (() =>
      {
        person.RandActionTimer = 10f;
        person.transform.position = this.StandSpots[person.JobIndex].position;
        person.transform.eulerAngles = this.StandSpots[person.JobIndex].eulerAngles;
        Interactible componentInChildren = this.StandSpots[person.JobIndex].GetComponentInChildren<Interactible>();
        if (!((UnityEngine.Object) componentInChildren != (UnityEngine.Object) null))
          return;
        componentInChildren.Interact(person);
      }),
      WhileDoing = (Action) (() =>
      {
        person.RandActionTimer -= Time.deltaTime;
        if ((double) person.RandActionTimer >= 0.0)
          return;
        person.AddWorkScheduleTask(this.StandShopTask(person));
        person.CompleteScheduleTask();
      })
    };
  }

  public override void AddJobToWorker(Person person)
  {
    base.AddJobToWorker(person);
    person.ThisPersonInt.StartTalkMono = (MonoBehaviour) this;
    person.ThisPersonInt.StartTalkFunc = "ChatShop";
    switch (person.JobIndex)
    {
      case 0:
      case 1:
      case 2:
      case 3:
      case 4:
      case 5:
      case 6:
      case 7:
      case 8:
        person.AddWorkScheduleTask(this.StandShopTask(person), true);
        break;
    }
  }

  public override void _EndWorkFor(Person person)
  {
    person.ThisPersonInt.SetDefaultChat();
    if ((UnityEngine.Object) person.InteractingWith != (UnityEngine.Object) null)
      person.InteractingWith.StopInteracting(person);
    base._EndWorkFor(person);
    person.AddGoHome();
  }

  public void ChatShop()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person person = _gameplay.PersonChattingTo;
    _gameplay.RemoveAllChatOptions();
    _gameplay.AddChatOption("Hello", (Action) (() =>
    {
      string[] strArray = new string[4]
      {
        "Hi",
        "Do you need something?",
        "Sup",
        "Kinda busy right now"
      };
      _gameplay.DisplaySubtitle(strArray[UnityEngine.Random.Range(0, strArray.Length)], (AudioClip) null, new Action(person.ThisPersonInt.EndTheChat));
      Main.Instance.GameplayMenu.EnableMove();
    }));
    _gameplay.AddChatOption("What do you sell?", (Action) (() =>
    {
      _gameplay.DisplaySubtitle("Mostly clothing, take a look", Main.Instance.Personalities[0].Voice_Generics[6], new Action(person.ThisPersonInt.EndTheChat));
      Main.Instance.GameplayMenu.EnableMove();
      Main.Instance.GameplayMenu.OpenTrader(this.Storage);
    }));
    _gameplay.AddChatOption("Show me ya junk", (Action) (() =>
    {
      Main.Instance.GameplayMenu.EnableMove();
      Main.Instance.GameplayMenu.OpenTrader(this.Storage);
    }));
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
    string[] strArray1 = new string[4]
    {
      "Hey you're really cute.  Let's have sex",
      "You're adorable.  Let's fuck",
      "Hey you're super cute!  I wanna have sex with you",
      "Hey you're really hot.  Let's do some action"
    };
    _gameplay.AddChatOption(strArray1[UnityEngine.Random.Range(0, strArray1.Length)], (Action) (() =>
    {
      _gameplay.DisplaySubtitle("Meet me after work at my place, " + person.HomeAddress, (AudioClip) null, new Action(person.ThisPersonInt.EndTheChat));
      Main.Instance.GameplayMenu.EnableMove();
    }));
    _gameplay.SelectChatOption(0);
    Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
  }
}
