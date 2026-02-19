// Decompiled with JetBrains decompiler
// Type: job_StripClub
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class job_StripClub : bl_WorkJobManager
{
  public List<Interactible> DancePoles = new List<Interactible>();
  public List<int_bed> SexRoomBeds = new List<int_bed>();
  public List<Int_Storage> ClothesLockers = new List<Int_Storage>();
  public Transform ReceptionPlace;
  public Interactible ReceptionInt;
  public Mission ProstMiss;
  public Transform StageSexSpot;

  public Person.ScheduleTask ReceptionTask(Person person)
  {
    return new Person.ScheduleTask()
    {
      IDName = nameof (ReceptionTask),
      ActionPlace = this.ReceptionPlace,
      OnArrive = (Action) (() =>
      {
        Debug.Log((object) "ON ARRIVE");
        person.ThisPersonInt.StartTalkMono = (MonoBehaviour) this.ProstMiss;
        person.ThisPersonInt.StartTalkFunc = "DeskChat";
        if (!this.ReceptionInt.CanInteract)
          return;
        this.ReceptionInt.Interact(person);
      })
    };
  }

  public Person.ScheduleTask DancePoleTask(Person person)
  {
    int _poleIndex = person.JobIndex >= 100 ? person.JobIndex - 100 : person.JobIndex;
    return new Person.ScheduleTask()
    {
      IDName = "PoleDancing",
      ActionPlace = this.DancePoles[_poleIndex].transform,
      OnArrive = (Action) (() =>
      {
        person.RandActionTimer = 10f;
        Interactible dancePole = this.DancePoles[_poleIndex];
        if (!dancePole.CanInteract)
          return;
        dancePole.Interact(person);
      }),
      WhileDoing = (Action) (() =>
      {
        person.RandActionTimer -= Time.deltaTime;
        if ((double) person.RandActionTimer >= 0.0)
          return;
        person.AddWorkScheduleTask(this.DancePoleTask(person));
        person.CompleteScheduleTask();
      })
    };
  }

  public override void AddJobToWorker(Person person)
  {
    base.AddJobToWorker(person);
    person.ThisPersonInt.StartTalkMono = (MonoBehaviour) this;
    person.ThisPersonInt.StartTalkFunc = "StripChat";
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
        person.AddWorkScheduleTask(this.DancePoleTask(person), true);
        break;
      case 10:
        person.AddWorkScheduleTask(this.ReceptionTask(person), true);
        break;
    }
    if (person.JobIndex < 100)
      return;
    person.AddWorkScheduleTask(this.DancePoleTask(person), true);
  }

  public override void _EndWorkFor(Person person)
  {
    base._EndWorkFor(person);
    person.AddGoHome();
  }

  public override void AddWorker(Person person)
  {
    base.AddWorker(person);
    person.ThisPersonInt.StartTalkMono = (MonoBehaviour) this;
    person.ThisPersonInt.StartTalkFunc = "StripChat";
    if (Main.Instance.LoadedGame || person.JobIndex >= 100 || person.JobIndex == 10)
      return;
    if ((double) UnityEngine.Random.Range(0.0f, 1f) > 0.5)
    {
      for (int index = 0; index < Main.Instance.Prefabs_ProstSuit2.Count; ++index)
        person.DressClothe(Main.Instance.Prefabs_ProstSuit2[index]);
    }
    else
    {
      for (int index = 0; index < Main.Instance.Prefabs_ProstSuit1.Count; ++index)
        person.DressClothe(Main.Instance.Prefabs_ProstSuit1[index]);
    }
  }

  public void StripChat()
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
    _gameplay.AddChatOption("What's your price?", (Action) (() =>
    {
      _gameplay.DisplaySubtitle("200 Bitch Notes", (AudioClip) null, new Action(person.ThisPersonInt.EndTheChat));
      Main.Instance.GameplayMenu.EnableMove();
    }));
    string[] _rands = new string[4]
    {
      "Hey you're really cute.  Let's have sex",
      "You're adorable.  Let's fuck",
      "Hey you're super cute!  I wanna have sex with you",
      "Hey you're really hot.  Let's do some action"
    };
    _gameplay.AddChatOption(_rands[UnityEngine.Random.Range(0, _rands.Length)], (Action) (() =>
    {
      if (Main.Instance.Player.Money >= 200)
      {
        if (person.State == Person_State.Work)
        {
          person.ThisPersonInt.EndTheChat();
          Main.Instance.Player.transform.SetPositionAndRotation(this.StageSexSpot.position, this.StageSexSpot.rotation);
          person.State = Person_State.Work;
          person.RandActionTimer = 0.0f;
          Main.Instance.Player.Money -= 200;
          Main.Instance.GameplayMenu.ShowNotification("Paid 200 Bitch Notes");
          if (person.Interacting)
            person.InteractingWith.StopInteracting();
          if (person.Favor < 0)
            person.Favor = 1;
          person.Energy = person.EnergyMax;
          Main.Instance.SexScene.SpawnSexScene(2, 4, Main.Instance.Player, person);
        }
        else
        {
          int_bed _bed = this.PickFreeBed();
          if ((bool) (UnityEngine.Object) _bed)
          {
            person.State = Person_State.Work;
            person.RandActionTimer = 0.0f;
            Main.Instance.Player.Money -= 200;
            Main.Instance.GameplayMenu.ShowNotification("Paid 200 Bitch Notes");
            _rands = new string[3]
            {
              "Let's go",
              "Come with me",
              "This way"
            };
            _gameplay.DisplaySubtitle(_rands[UnityEngine.Random.Range(0, _rands.Length)], (AudioClip) null, new Action(person.ThisPersonInt.EndTheChat));
            person.AddWorkScheduleTask(new Person.ScheduleTask()
            {
              IDName = "PaidSex",
              ActionPlace = _bed.NavMeshInteractSpot,
              OnStartGoing = (Action) (() => person.RandActionTimer = 3f),
              OnArrive = (Action) (() =>
              {
                person.CompleteScheduleTask(false);
                _bed.Interact_SexyWait(person);
              })
            }, true);
            if (person.Interacting)
              person.InteractingWith.StopInteracting();
          }
          else
            _gameplay.DisplaySubtitle("Lemme check...and there's no beds available right now, come back a bit later", (AudioClip) null, new Action(person.ThisPersonInt.EndTheChat));
        }
      }
      else
        _gameplay.DisplaySubtitle("You don't have enough Bitch Notes", (AudioClip) null, new Action(person.ThisPersonInt.EndTheChat));
      Main.Instance.GameplayMenu.EnableMove();
    }));
    _gameplay.SelectChatOption(0);
    Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
  }

  public int_bed PickFreeBed()
  {
    int[] array = new int[this.SexRoomBeds.Count];
    for (int index = 0; index < array.Length; ++index)
      array[index] = index;
    bl_HangZone.Shuffle(ref array);
    for (int index = 0; index < this.SexRoomBeds.Count; ++index)
    {
      if (this.SexRoomBeds[array[index]].CanInteract)
        return this.SexRoomBeds[array[index]];
    }
    return (int_bed) null;
  }
}
