// Decompiled with JetBrains decompiler
// Type: job_CapturedHouse
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class job_CapturedHouse : bl_WorkJobManager
{
  public List<bl_HangZone> Cells = new List<bl_HangZone>();
  public AudioClip[] VoiceLines;

  public override void AddWorker(Person person)
  {
    base.AddWorker(person);
    person.ThisPersonInt.StartTalkMono = (MonoBehaviour) this;
    person.ThisPersonInt.StartTalkFunc = person.PersonType.ThisType == Person_Type.Prisioner ? "ChatPrisioner" : "ChatGuard";
  }

  public void AddNPC(Person person)
  {
    person.ThisPersonInt.StartTalkMono = (MonoBehaviour) this;
    person.ThisPersonInt.StartTalkFunc = "ChatPrisioner";
    (Main.Instance.AllMissions[6] as Mis_Dance).PossibleClients.Add(person);
    if (!(person is Girl))
      return;
    (person as Girl).PregnancyPercent = 0.0f;
  }

  public void ChatPrisioner()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person person = _gameplay.PersonChattingTo;
    if ((double) UnityEngine.Random.Range(0.0f, 1f) <= 0.75)
    {
      string[] strArray = new string[4]
      {
        "What do you want?",
        "I can't right now",
        "Leave me alone",
        "..."
      };
      int randOf = person._PersonalityData.GetRandOf(strArray.Length);
      _gameplay.DisplaySubtitle(strArray[randOf], this.VoiceLines[randOf], new Action(person.ThisPersonInt.EndTheChat));
      Main.Instance.GameplayMenu.EnableMove();
    }
    else
    {
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
        _gameplay.DisplaySubtitle("I can't right now", this.VoiceLines[1], new Action(person.ThisPersonInt.EndTheChat));
      }));
      _gameplay.SelectChatOption(0);
      Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
    }
  }

  public void ChatGuard()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person person = _gameplay.PersonChattingTo;
    if ((double) UnityEngine.Random.Range(0.0f, 1f) <= 0.75)
    {
      string[] strArray = new string[4]
      {
        "Keep moving",
        "You're fine, keep going",
        "Just go do something",
        "..."
      };
      int randOf = person._PersonalityData.GetRandOf(strArray.Length);
      _gameplay.DisplaySubtitle(strArray[randOf], this.VoiceLines[randOf + 4], new Action(person.ThisPersonInt.EndTheChat));
      Main.Instance.GameplayMenu.EnableMove();
    }
    else
    {
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
        _gameplay.DisplaySubtitle("Might visit your cell later this night", this.VoiceLines[8], new Action(person.ThisPersonInt.EndTheChat));
      }));
      _gameplay.SelectChatOption(0);
      Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
    }
  }
}
