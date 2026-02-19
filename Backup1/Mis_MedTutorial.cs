// Decompiled with JetBrains decompiler
// Type: Mis_MedTutorial
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class Mis_MedTutorial : Mission
{
  public Person Sarah;
  public AudioClip[] VoiceLines;
  public Transform[] ReleasedSpots;
  public bool WaitingToCloseJournal;
  public bool sgownSleepMsg;
  public bool FirstTalk;
  public bl_RandomPatrol SarahPatrol;
  public bool addedTask;

  public override void InitMission()
  {
    base.InitMission();
    this.Sarah.ThisPersonInt.StartTalkMono = (MonoBehaviour) this;
    this.Sarah.ThisPersonInt.StartTalkFunc = "SarahChat";
    Main.Instance.CityCharacters.SetPerson(this.Sarah);
    this.CurrentGoal = this.Goals[0];
    if (!this.CurrentGoal.Completed)
    {
      Main.Instance.MainThreads.Add(new Action(this.Goal0));
    }
    else
    {
      this.CurrentGoal = this.Goals[1];
      if (!this.CurrentGoal.Completed)
      {
        Main.Instance.MainThreads.Add(new Action(this.Goal1));
      }
      else
      {
        this.CurrentGoal = this.Goals[2];
        if (!this.CurrentGoal.Completed)
        {
          Main.Instance.MainThreads.Add(new Action(this.Goal2));
        }
        else
        {
          this.CurrentGoal = this.Goals[3];
          if (!this.CurrentGoal.Completed)
          {
            Main.Instance.MainThreads.Add(new Action(this.Goal3));
          }
          else
          {
            this.CurrentGoal = this.Goals[4];
            if (!this.CurrentGoal.Completed)
            {
              Main.Instance.MainThreads.Add(new Action(this.Goal4));
            }
            else
            {
              this.FirstTalk = true;
              this.AddSarahTask();
              this.CurrentGoal = this.Goals[5];
              if (this.CurrentGoal.Completed)
                this.CompletedMission = true;
            }
          }
        }
      }
    }
    if (this.CompletedMission)
      return;
    Main.Instance.GameplayMenu.DisplayGoal(this.CurrentGoal, true);
  }

  public void Goal0()
  {
    if (!Main.Instance.Player.Masturbating)
      return;
    this.CompleteGoal(0);
    Main.Instance.MainThreads.Remove(new Action(this.Goal0));
    this.AddGoal(1, true);
    Main.Instance.MainThreads.Add(new Action(this.Goal1));
  }

  public void Goal1()
  {
    if (!Main.Instance.Player.UserControl.FirstPerson)
      return;
    this.CompleteGoal(1);
    Main.Instance.MainThreads.Remove(new Action(this.Goal1));
    this.AddGoal(2, true);
    Main.Instance.MainThreads.Add(new Action(this.Goal2));
  }

  public void Goal2()
  {
    if (!Main.Instance.Player.HasMoveBlocker("SleepingFloor"))
      return;
    this.CompleteGoal(2);
    Main.Instance.MainThreads.Remove(new Action(this.Goal2));
    this.AddGoal(3, true);
    Main.Instance.MainThreads.Add(new Action(this.Goal3));
  }

  public void Goal3()
  {
    if (!this.sgownSleepMsg && !Main.Instance.Player.HasMoveBlocker("SleepingFloor"))
    {
      this.sgownSleepMsg = true;
      Main.Instance.GameplayMenu.ShowMessageBox("At night it'll get very dark!\nFind a safe place and Sleep to speed up time!\n\nEnable/Disable Day Cycle in settings");
    }
    if (!this.WaitingToCloseJournal && Main.Instance.GameplayMenu.JournalMenu.activeSelf)
    {
      this.WaitingToCloseJournal = true;
    }
    else
    {
      if (!this.WaitingToCloseJournal || Main.Instance.GameplayMenu.JournalMenu.activeSelf)
        return;
      this.CompleteGoal(3);
      Main.Instance.MainThreads.Remove(new Action(this.Goal3));
      this.AddGoal(4, true);
      Main.Instance.MainThreads.Add(new Action(this.Goal4));
    }
  }

  public void Goal4()
  {
    if (!this.FirstTalk)
      return;
    this.CompleteGoal(4);
    Main.Instance.MainThreads.Remove(new Action(this.Goal4));
    this.AddGoal(5, true);
  }

  public void SarahChat()
  {
    Main.Instance.Player.UserControl.StopMoving();
    if (!this.FirstTalk)
    {
      this.FirstTalk = true;
      Main.Instance.Player.UserControl.FirstPerson = true;
      Main.Instance.Player.UserControl.LateUpdate();
      this.Sarah.transform.position = new Vector3(-9.444f, 0.016f, 27.239f);
      Main.Instance.Player.transform.position = new Vector3(-8.684f, 0.0f, 27.42f);
      this.Sarah.transform.LookAt(Main.Instance.Player.transform);
      Main.Instance.Player.transform.LookAt(this.Sarah.transform);
      (this.Sarah as Girl).GirlPhysics = true;
      Main.Instance.GameplayMenu.AfterSubtitle = (Action) null;
      Main.Instance.GameplayMenu.DisplaySubtitle("Welcome back sweetie. How was it like exploring the world out there?", this.VoiceLines[0], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("While you're living here again, your first priority is finding a job", this.VoiceLines[2], new Action(this.SarahChat2), this.Sarah, lipsyncTime: 1f)), this.Sarah, lipsyncTime: 1f);
    }
    else
      this.SarahChat2();
  }

  public void SarahChat2()
  {
    Debug.Log((object) nameof (SarahChat2));
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person person = _gameplay.PersonChattingTo;
    _gameplay.RemoveAllChatOptions();
    _gameplay.AddChatOption("Who are you again?", (Action) (() =>
    {
      if (Main.Instance.FreeWorldPatch)
        _gameplay.DisplaySubtitle("I'm your Step-Mother you silly", this.VoiceLines[3], new Action(this.SarahChat2));
      else
        _gameplay.DisplaySubtitle("I'm (censored) you silly", this.VoiceLines[30], new Action(this.SarahChat2));
    }));
    if (Main.Instance.AllMissions[10].Goals[0].Completed && !Main.Instance.AllMissions[10].CompletedMission)
      _gameplay.AddChatOption("[Finish current mission first] So about that job in the Mines...", new Action(Main.Instance.GameplayMenu.EnableMove));
    else if (Main.Instance.AllMissions[8].CompletedMission && !Main.Instance.AllMissions[11].CompletedMission)
      _gameplay.AddChatOption("(Starts mission) So about that job in the Mines...", new Action((Main.Instance.AllMissions[11] as Mis_Mines_Med).SarahTalkInit));
    else if (Main.Instance.AllMissions[11].CompletedMission)
      _gameplay.AddChatOption("Hey let's do it again", new Action((Main.Instance.AllMissions[11] as Mis_Mines_Med).AfterMissionSex));
    _gameplay.AddChatOption("Where do I find a job?", (Action) (() => _gameplay.DisplaySubtitle("You really forgot the place didn't you?  At your right there's the Army building, for Army work", this.VoiceLines[4], (Action) (() => _gameplay.DisplaySubtitle("At your left there's the Strip club, for sex work", this.VoiceLines[5], (Action) (() => _gameplay.DisplaySubtitle("And if you want to work in the Mines, talk with me later", this.VoiceLines[6], new Action(this.SarahChat2), this.Sarah)), this.Sarah)), this.Sarah)));
    _gameplay.AddChatOption("About hair colors...", new Action(this.SarahHairCOlorAsk));
    string chattext = Main.Instance.FreeWorldPatch ? "See ya later mom!" : "See ya later!";
    _gameplay.AddChatOption(chattext, (Action) (() =>
    {
      _gameplay.DisplaySubtitle("Kisses, Have fun~", this.VoiceLines[7], new Action(person.ThisPersonInt.EndTheChat), this.Sarah);
      Main.Instance.GameplayMenu.EnableMove();
      (this.Sarah as Girl).GirlPhysics = false;
      if (this.addedTask)
        return;
      Main.Instance.DayCycle.enabled = Main.Instance.SettingsMenu.DayCycle.isOn;
      Main.Instance.DayCycle.ResetMidday();
      this.AddSarahTask();
    }));
    _gameplay.SelectChatOption(0);
    Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
  }

  public void AddSarahTask()
  {
    this.addedTask = true;
    Main.Instance.GameplayMenu.SleepButtons[0].interactable = true;
    Main.Instance.GameplayMenu.SleepButtons[1].interactable = true;
    this.SarahPatrol.StartPatrol(this.Sarah);
  }

  public void OnTrigerEnterMsg()
  {
    Main.Instance.GameplayMenu.ShowMessageBox("This is a unfinished build!\nYou can explore now.\nLater try New game with the other Dificulty GameModes too!\n\nCheck  https://patreon.com/Breakfast5  for Updates, or consider Supporting for faster Updates and Benefits!");
  }

  public void SarahHairCOlorAsk()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person personChattingTo = _gameplay.PersonChattingTo;
    _gameplay.RemoveAllChatOptions();
    _gameplay.AddChatOption("Why does almost everyone have colored hair?", (Action) (() => _gameplay.DisplaySubtitle("How did you even forgot that? Did you hit your head somewhere?", this.VoiceLines[8], (Action) (() => _gameplay.DisplaySubtitle("Even tho not always mandatory, to keep order in our land, most people use the color of their job class", this.VoiceLines[9], new Action(this.SarahHairCOlorAsk))))));
    _gameplay.AddChatOption("What's the Red color?", (Action) (() => _gameplay.DisplaySubtitle("The worker class are the people who make things happen with hard labor", this.VoiceLines[10], (Action) (() => _gameplay.DisplaySubtitle("Like building our structures, mine resources, and so on", this.VoiceLines[11], (Action) (() => _gameplay.DisplaySubtitle("They are in fact obligated to use red colored hair, as most of them don't have total freedom yet", this.VoiceLines[12], new Action(this.SarahHairCOlorAsk))))))));
    _gameplay.AddChatOption("What's the Blue color?", (Action) (() => _gameplay.DisplaySubtitle("The civilian class is any of us when we are not forced at any job, mostly sex workers use it", this.VoiceLines[13], new Action(this.SarahHairCOlorAsk))));
    _gameplay.AddChatOption("What's the Green color?", (Action) (() => _gameplay.DisplaySubtitle("That's the army, and green it's also useful as camouflage", this.VoiceLines[14], (Action) (() => _gameplay.DisplaySubtitle("They protect the city, or attack enemies out there", this.VoiceLines[15], new Action(this.SarahHairCOlorAsk))))));
    _gameplay.AddChatOption("(More Options)", new Action(this.SarahColrQuestion2));
    _gameplay.SelectChatOption(0);
    Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
  }

  public void SarahColrQuestion2()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person personChattingTo = _gameplay.PersonChattingTo;
    _gameplay.RemoveAllChatOptions();
    _gameplay.AddChatOption("What's the Bleached color?", (Action) (() => _gameplay.DisplaySubtitle("Bleached hair is used on prisioners that are being processed and trained into future population for us", this.VoiceLines[16], new Action(this.SarahColrQuestion2))));
    _gameplay.AddChatOption("What are the Purple and Pink colors?", (Action) (() => _gameplay.DisplaySubtitle("Those aren't our people, they're the ESB's", this.VoiceLines[17], (Action) (() => _gameplay.DisplaySubtitle("They're some tribe out there that attacks us for some reason only your dad knows, and doesn't tell anyone", this.VoiceLines[18], (Action) (() => _gameplay.DisplaySubtitle("They use those colors to avoid friendly fire between all of us", this.VoiceLines[19], (Action) (() => _gameplay.DisplaySubtitle("Good for us, they are easy to spot", this.VoiceLines[20], (Action) (() => _gameplay.DisplaySubtitle("Bad for us, if you spot them, there's gonna be a fight", this.VoiceLines[21], new Action(this.SarahColrQuestion2))))))))))));
    _gameplay.AddChatOption("What's the Orange color?", (Action) (() => _gameplay.DisplaySubtitle("That's the Royal class, it's our family, the rulers of this city", this.VoiceLines[22], (Action) (() => _gameplay.DisplaySubtitle("Although we don't usually use it too often because it stands out too much", this.VoiceLines[23], (Action) (() => _gameplay.DisplaySubtitle("Can't let the enemy know who's the important people, if they come in our city", this.VoiceLines[24], (Action) (() => _gameplay.DisplaySubtitle("Personally I look much sexier in this shock blue~  It's your dad's favourite *wink*", this.VoiceLines[25], new Action(this.SarahColrQuestion2))))))))));
    _gameplay.AddChatOption("Are there people without colored hair?", (Action) (() => _gameplay.DisplaySubtitle("Of course, either someone that just didn't colored their hair", this.VoiceLines[26], (Action) (() => _gameplay.DisplaySubtitle("But if it's out there, that'll be what we call a Wild", this.VoiceLines[27], (Action) (() => _gameplay.DisplaySubtitle("The Wild are people who aren't part of us, or of any tribe", this.VoiceLines[28], (Action) (() => _gameplay.DisplaySubtitle("That is, until you find them and convert them into one of us", this.VoiceLines[29], new Action(this.SarahColrQuestion2))))))))));
    _gameplay.AddChatOption("Okay I've asked all I wanted to ask", new Action(this.SarahChat2));
    _gameplay.SelectChatOption(0);
    Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
  }
}
