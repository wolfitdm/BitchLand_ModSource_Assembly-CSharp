// Decompiled with JetBrains decompiler
// Type: Mis_Hadley
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Mis_Hadley : Mission
{
  public Person Hadley;
  public AudioClip[] VoiceLines;
  public AudioClip[] VoiceLines_org;
  public AudioClip[] VoiceLines2;
  public int DIYdildosBrought;
  public Transform HadleyRoom;
  public Transform CabinetPlace;
  public Transform[] SPOTS;
  public GameObject[] HaldeyClothes;
  public GameObject[] HaldeyClothes2;
  public GameObject[] GooPiles;
  public GameObject Cam;
  public GameObject GooPillsPrefab;

  public void InitHadley()
  {
    this.Hadley = Main.Instance.CityCharacters.Hadley;
    this.Hadley.ThisPersonInt.StartTalkFunc = "Chat_Hadley";
    this.Hadley.ThisPersonInt.StartTalkMono = (MonoBehaviour) this;
  }

  public override void InitMission()
  {
    base.InitMission();
    this.CurrentGoal = this.Goals[0];
    if (this.CurrentGoal.Completed)
    {
      if (!Main.Instance.ScatContent)
        return;
      this.CurrentGoal = this.Goals[1];
      if (this.CurrentGoal.Completed)
      {
        this.CurrentGoal = this.Goals[2];
        if (this.CurrentGoal.Completed)
        {
          this.CurrentGoal = this.Goals[3];
          if (this.CurrentGoal.Completed)
            this.CompletedMission = true;
        }
      }
    }
    if (this.CompletedMission)
      return;
    Main.Instance.GameplayMenu.DisplayGoal(this.CurrentGoal, true);
  }

  public void Chat_Hadley()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person person = _gameplay.PersonChattingTo;
    if (this.CompletedMission)
    {
      person.ThisPersonInt.SetDefaultChat();
      person.ThisPersonInt.DefaultTalk();
    }
    else if ((this.CurrentGoal == null || this.CurrentGoal.Title.Length == 0) && !this.Goals[0].Completed)
    {
      _gameplay.DisplaySubtitle("You... OH YOU!", this.VoiceLines[0], (Action) (() =>
      {
        person.ResetAllShapes();
        _gameplay.DisplaySubtitle("You're back!", this.VoiceLines[1], (Action) (() =>
        {
          person.ResetAllShapes();
          _gameplay.DisplaySubtitle("Hey so, you need to help me, to find some fuckable things", this.VoiceLines[2], (Action) (() =>
          {
            person.ResetAllShapes();
            Main.Instance.GameplayMenu.StartMission((Mission) this);
            _gameplay.DisplaySubtitle("Just look around in the trash piles", this.VoiceLines[3], (Action) (() =>
            {
              person.ResetAllShapes();
              _gameplay.DisplaySubtitle("I also have a small backpack at my house", this.VoiceLines[4], (Action) (() => _gameplay.DisplaySubtitle("Use that one or any backpack to bring me the stuff", this.VoiceLines[5], (Action) (() => _gameplay.DisplaySubtitle("I'll be around", this.VoiceLines[6], (Action) (() =>
              {
                Main.Instance.GameplayMenu.DisplayGoal(this.Goals[0], true);
                this.CurrentGoal = this.Goals[0];
                person.ThisPersonInt.EndTheChat();
              }), person, e_BlendShapes.Smug)), person, e_BlendShapes.Smug)), person, e_BlendShapes.Smug);
            }), person, e_BlendShapes.Smug);
          }), person, e_BlendShapes.Smug);
        }), person, e_BlendShapes.Smug);
      }), person, e_BlendShapes.Smug);
    }
    else
    {
      switch (this.CurrentGoalIndex)
      {
        case 0:
          _gameplay.RemoveAllChatOptions();
          _gameplay.AddChatOption("You're cute, let's fuck", (Action) (() =>
          {
            Main.Instance.GameplayMenu.EnableMove();
            _gameplay.DisplaySubtitle("Throw me down already", this.VoiceLines[7], new Action(person.ThisPersonInt.EndTheChat));
          }));
          _gameplay.AddChatOption("I got some of the stuff you asked for here (in equipped backpack)", (Action) (() =>
          {
            if ((UnityEngine.Object) Main.Instance.Player.CurrentBackpack == (UnityEngine.Object) null)
            {
              _gameplay.DisplaySubtitle("You have no backpack, what are you talking about?", this.VoiceLines[8], new Action(person.ThisPersonInt.EndTheChat), person, e_BlendShapes.Smug);
            }
            else
            {
              List<GameObject> gameObjectList = new List<GameObject>();
              bool flag = this.DIYdildosBrought == 0;
              bool _isDone = false;
              for (int index = 0; index < Main.Instance.Player.CurrentBackpack.ThisStorage.StorageItems.Count; ++index)
              {
                int_dildo component = Main.Instance.Player.CurrentBackpack.ThisStorage.StorageItems[index].GetComponent<int_dildo>();
                if ((UnityEngine.Object) component == (UnityEngine.Object) null && Main.Instance.Player.CurrentBackpack.ThisStorage.StorageItems[index].transform.childCount != 0)
                  component = Main.Instance.Player.CurrentBackpack.ThisStorage.StorageItems[index].transform.GetChild(0).GetComponent<int_dildo>();
                if ((UnityEngine.Object) component != (UnityEngine.Object) null)
                {
                  ++this.DIYdildosBrought;
                  gameObjectList.Add(component.RootObj);
                }
              }
              for (int index = 0; index < gameObjectList.Count; ++index)
              {
                Main.Instance.Player.CurrentBackpack.ThisStorage.RemoveItem(gameObjectList[index]);
                gameObjectList[index].transform.position = this.HadleyRoom.position;
              }
              if (this.DIYdildosBrought >= 10)
              {
                _isDone = true;
                this.CompleteGoal(0);
              }
              _gameplay.ShowNotification(gameObjectList.Count.ToString() + " items removed");
              if (flag)
                _gameplay.DisplaySubtitle("Let's see what we got here...", this.VoiceLines[9], (Action) (() => _gameplay.DisplaySubtitle("Well I've fucked worse things", this.VoiceLines[10], (Action) (() =>
                {
                  if (_isDone)
                    this.StartGoal2();
                  else
                    _gameplay.DisplaySubtitle("These aren't enough yet, we need some more", this.VoiceLines[11], (Action) (() => person.ThisPersonInt.EndTheChat()), person, e_BlendShapes.Smug);
                }), person, e_BlendShapes.Scared)), person, e_BlendShapes.Smug);
              else if (_isDone)
                this.StartGoal2();
              else
                _gameplay.DisplaySubtitle("These aren't enough yet, we need some more", this.VoiceLines[11], (Action) (() => person.ThisPersonInt.EndTheChat()), person, e_BlendShapes.Smug);
            }
          }));
          _gameplay.SelectChatOption(0);
          Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
          break;
        case 2:
          _gameplay.DisplaySubtitle("Wow you actually got some?", this.VoiceLines[29], (Action) (() => _gameplay.DisplaySubtitle("Next you gotta craft me a Scat Tube", this.VoiceLines[30], (Action) (() => _gameplay.DisplaySubtitle("It's gonna go crazy with these pills", this.VoiceLines[31], (Action) (() =>
          {
            this.CompleteGoal(2);
            this.AddGoal(3, true);
            person.ThisPersonInt.EndTheChat();
          }), person, e_BlendShapes.Smug)), person, e_BlendShapes.Smug)), person, e_BlendShapes.Shocked);
          break;
        case 3:
          if ((UnityEngine.Object) Main.Instance.Player.CurrentBackpack != (UnityEngine.Object) null && Main.Instance.Player.CurrentBackpack.ThisStorage.HasItem("Scat Tube") || Main.Instance.Player.Storage_Hands.HasItem("Scat Tube"))
          {
            Main.Instance.Player.AddMoveBlocker("hadleyquest");
            person.AddMoveBlocker("hadleyquest");
            person.ThisPersonInt.AddBlocker("quest");
            person.ProxSeen.gameObject.SetActive(false);
            Main.Instance.Player.ProxSeen.gameObject.SetActive(false);
            Main.Instance.CanSaveFlags_add("HaldeyQuest");
            _gameplay.DisplaySubtitle("Oh wow!", this.VoiceLines[33], (Action) (() => _gameplay.DisplaySubtitle("We are going to my place Now!", this.VoiceLines[34], (Action) (() =>
            {
              this.CompleteGoal(3);
              person.ThisPersonInt.EndTheChat();
              Main.Instance.GameplayMenu.TheScreenFader.FadeOut(2f, new Action(this.HadleyTube));
            }), person, e_BlendShapes.Shocked)), person, e_BlendShapes.Shocked);
            break;
          }
          _gameplay.DisplaySubtitle("I'll be waitin", this.VoiceLines[32], new Action(person.ThisPersonInt.EndTheChat), person, e_BlendShapes.Shocked);
          break;
      }
    }
  }

  public void HadleyTube()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person _hadley = Main.Instance.CityCharacters.Hadley;
    Main.Instance.GameplayMenu.TheScreenFader.FadeIn(1f);
    Main.Instance.Player.PlaceAt(this.SPOTS[0]);
    _hadley.PlaceAt(this.SPOTS[1]);
    _hadley.ChangeUniform(this.HaldeyClothes);
    Main.RunInSeconds((Action) (() => _gameplay.DisplaySubtitle("So you took one and it was that effective?", this.VoiceLines[35], (Action) (() => _gameplay.DisplaySubtitle("I'mma take the whole bottle then", this.VoiceLines[36], (Action) (() =>
    {
      _hadley.ThisPersonInt.EndTheChat();
      _hadley.ChangeUniform(this.HaldeyClothes2);
      this.Cam.SetActive(true);
      _hadley.PlaceAt(this.SPOTS[2]);
      _hadley.enabled = false;
      _hadley.navMesh.enabled = false;
      Main.RunInNextFrame((Action) (() => _hadley.Anim.Play("Anim_MastSitDildo5")));
      Main.Instance.GlobalAudio.PlayOneShot(Main.Instance.ShitSounds[4]);
      Main.RunInSeconds((Action) (() => Main.Instance.GlobalAudio.PlayOneShot(Main.Instance.ShitSounds[4])), 2f);
      Main.RunInSeconds((Action) (() =>
      {
        _hadley.Anim.Play("SleepSex2_1");
        _hadley.LookAtPlayer.Disable = true;
        Main.Instance.GlobalAudio.PlayOneShot(Main.Instance.ShitSounds[4]);
      }), 3f);
      Main.RunInSeconds((Action) (() =>
      {
        this.GooPiles[0].SetActive(true);
        Main.Instance.GlobalAudio.PlayOneShot(Main.Instance.ShitSounds[4]);
      }), 3.5f);
      Main.RunInSeconds((Action) (() =>
      {
        this.GooPiles[1].SetActive(true);
        Main.Instance.GlobalAudio.PlayOneShot(Main.Instance.ShitSounds[4]);
      }), 5f);
      Main.RunInSeconds((Action) (() => Main.Instance.GlobalAudio.PlayOneShot(Main.Instance.ShitSounds[4])), 6f);
      Main.RunInSeconds((Action) (() =>
      {
        this.GooPiles[2].SetActive(true);
        Main.Instance.GlobalAudio.PlayOneShot(Main.Instance.ShitSounds[4]);
      }), 7f);
      Main.RunInSeconds((Action) (() =>
      {
        Main.Instance.GlobalAudio.PlayOneShot(Main.Instance.ShitSounds[4]);
        Main.Instance.GameplayMenu.TheScreenFader.FadeOut(4f, new Action(this.HadleyTubeEnd));
      }), 9f);
    }), _hadley)), _hadley)), 2f);
  }

  public void HadleyTubeEnd()
  {
    this.CompleteMission();
    this.Cam.SetActive(false);
    Main.Instance.GameplayMenu.TheScreenFader.FadeIn(1f);
    Main.Instance.CanSaveFlags_remove("HaldeyQuest");
    Main.Instance.Player.RemoveMoveBlocker("hadleyquest");
    Main.Instance.Player.ProxSeen.gameObject.SetActive(true);
    Main.RunInSeconds((Action) (() =>
    {
      Person hadley = Main.Instance.CityCharacters.Hadley;
      hadley.enabled = true;
      hadley.navMesh.enabled = true;
      hadley.ThisPersonInt.RemoveBlocker("quest");
      hadley.RemoveMoveBlocker("hadleyquest");
      hadley.ChangeUniform(this.HaldeyClothes);
      hadley.LookAtPlayer.Disable = false;
      hadley.ProxSeen.gameObject.SetActive(true);
    }), 30f);
  }

  public void StartGoal2()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person person = _gameplay.PersonChattingTo;
    _gameplay.DisplaySubtitle("Thanks, these will be VERY helpfull~", this.VoiceLines[22], (Action) (() => _gameplay.DisplaySubtitle("You can crash at my place if u want a safe place to sleep anytime", this.VoiceLines[23], (Action) (() => _gameplay.DisplaySubtitle("Now let's get down to something more interesting...", this.VoiceLines[24], (Action) (() => _gameplay.DisplaySubtitle("Last era they were trying to develop some pill", this.VoiceLines[12], (Action) (() => _gameplay.DisplaySubtitle("that would instantly feed you with all needed nutrition", this.VoiceLines[13], (Action) (() => _gameplay.DisplaySubtitle("And they actually made some", this.VoiceLines[14], (Action) (() => _gameplay.DisplaySubtitle("But they had a drawback", this.VoiceLines[15], (Action) (() =>
    {
      if (!Main.Instance.ScatContent)
        _gameplay.DisplaySubtitle("Oh, well you could help me with it...", (AudioClip) null, (Action) (() => _gameplay.DisplaySubtitle("But you disabled that stuff in the Settings, so...", (AudioClip) null, (Action) (() => person.ThisPersonInt.EndTheChat()), person, e_BlendShapes.Smug)), person, e_BlendShapes.Smug);
      else
        _gameplay.DisplaySubtitle("once injested, it'd expand into a gooey material in your guts", this.VoiceLines[16], (Action) (() => _gameplay.DisplaySubtitle("This was to make you feel full", this.VoiceLines[17], (Action) (() => _gameplay.DisplaySubtitle("But it'd expand so much that you'd shit goo everywhere", this.VoiceLines[18], (Action) (() => _gameplay.DisplaySubtitle("And that actually sounds hot to me", this.VoiceLines[19], (Action) (() => _gameplay.DisplaySubtitle("I've seen some in the Clinic that look like them", this.VoiceLines[20], (Action) (() => _gameplay.DisplaySubtitle("Go there and steal some without Maylenne seeing", this.VoiceLines[21], (Action) (() =>
        {
          this.AddGoal(1, true);
          person.ThisPersonInt.EndTheChat();
        }), person, e_BlendShapes.Smug)), person, e_BlendShapes.Smug)), person, e_BlendShapes.Smug)), person, e_BlendShapes.Smug)), person, e_BlendShapes.Smug)), person, e_BlendShapes.Smug);
    }), person, e_BlendShapes.Smug)), person, e_BlendShapes.Smug)), person, e_BlendShapes.Scared)), person, e_BlendShapes.Shocked)), person, e_BlendShapes.Smug)), person, e_BlendShapes.Smug)), expression: e_BlendShapes.Smug);
  }

  public void CheckHadleyMissionCabinet()
  {
    if (this.CurrentGoal != this.Goals[1])
      return;
    if ((UnityEngine.Object) Main.Instance.Player.InteractingWith != (UnityEngine.Object) null)
      Main.Instance.Player.InteractingWith.StopInteracting();
    Main.Instance.GameplayMenu.CloseStorage();
    Main.Instance.Player.AddMoveBlocker("HadleyMissionpills");
    Main.Instance.CityCharacters.Maylenne.StartScheduleTask(new Person.ScheduleTask()
    {
      IDName = "stealingpills",
      RunTo = true,
      ActionPlace = this.CabinetPlace,
      OnArrive = (Action) (() =>
      {
        UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
        Person personChattingTo = _gameplay.PersonChattingTo;
        Main.Instance.CityCharacters.Maylenne.transform.LookAt(Main.Instance.Player.transform);
        _gameplay.DisplaySubtitle("What the hell are you trying to steal there?", this.VoiceLines[25], (Action) (() => _gameplay.DisplaySubtitle("Oh these huh?   Why don't we give them a try?", this.VoiceLines[26], (Action) (() =>
        {
          Main.Instance.CityCharacters.Maylenne.ThisPersonInt.EndTheChat();
          Main.Spawn(this.GooPillsPrefab).GetComponentInChildren<int_GooPills>().Interact(Main.Instance.Player);
          Main.RunInSeconds((Action) (() =>
          {
            UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
            Person personChattingTo = _gameplay.PersonChattingTo;
            _gameplay.DisplaySubtitle("Oh, so that's what these do", this.VoiceLines[27], (Action) (() => _gameplay.DisplaySubtitle("Why don't you take some, as a souvenir", this.VoiceLines[28], (Action) (() =>
            {
              Main.Instance.CityCharacters.Maylenne.ThisPersonInt.EndTheChat();
              this.CompleteGoal(1);
              this.AddGoal(2, true);
              Main.Instance.Player.RemoveMoveBlocker("HadleyMissionpills");
            }), Main.Instance.CityCharacters.Maylenne)), Main.Instance.CityCharacters.Maylenne);
          }), 3f);
        }), Main.Instance.CityCharacters.Maylenne)), Main.Instance.CityCharacters.Maylenne);
      })
    });
  }

  public void ShatPills()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person personChattingTo = _gameplay.PersonChattingTo;
    _gameplay.DisplaySubtitle("What the hell are you trying to steal there?", this.VoiceLines[25], (Action) (() => _gameplay.DisplaySubtitle("Oh these huh?   Why don't we give them a try?", this.VoiceLines[26], (Action) (() =>
    {
      Main.Instance.CityCharacters.Maylenne.ThisPersonInt.EndTheChat();
      Main.Spawn(this.GooPillsPrefab).GetComponentInChildren<int_GooPills>();
      Main.Instance.Player.RemoveMoveBlocker("HadleyMissionpills");
    }), Main.Instance.CityCharacters.Maylenne)), Main.Instance.CityCharacters.Maylenne);
  }
}
