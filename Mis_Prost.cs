// Decompiled with JetBrains decompiler
// Type: Mis_Prost
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class Mis_Prost : Mission
{
  public job_StripClub StripClub;
  public Transform DeskGirlFuckSpot;
  public bl_HangZone StaffRoom;
  public Int_Storage Lvl1_Locker;
  public GameObject LockerArea;
  public AudioClip[] CarolLines;
  public AudioSource BarMusic;
  public Transform ZeaBedroomSpot;
  public Transform ZeaSexroomSpot;
  public string ZeaWaitAnim;
  public Interactible ZeaSexWait;
  public GameObject ZeaSexStartTrigger;
  public GameObject[] ZeaClothes;
  public bl_HangZone StipClubZone;

  public override void InitMission()
  {
    base.InitMission();
    this.Lvl1_Locker.gameObject.SetActive(true);
    this.Lvl1_Locker.RootObj.SetActive(true);
    this.CurrentGoal = this.Goals[0];
    if (!this.CurrentGoal.Completed)
    {
      this.LockerArea.SetActive(true);
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
        this.Lvl1_Locker.Locked = false;
        this.CurrentGoal = this.Goals[2];
        if (!this.CurrentGoal.Completed)
        {
          Main.Instance.MainThreads.Add(new Action(this.Goal2));
        }
        else
        {
          this.CurrentGoal = this.Goals[3];
          if (this.CurrentGoal.Completed)
          {
            this.CurrentGoal = this.Goals[4];
            if (!this.CurrentGoal.Completed)
            {
              Main.Instance.MainThreads.Add(new Action(this.Goal4_2));
            }
            else
            {
              this.CurrentGoal = this.Goals[5];
              if (this.CurrentGoal.Completed)
              {
                this.StaffRoom.SafeHouse = true;
                this.CurrentGoal = this.Goals[6];
                if (!this.CurrentGoal.Completed)
                {
                  Main.Instance.CityCharacters.Zea.AddMoveBlocker("StripQuest");
                  Main.Instance.CityCharacters.Zea.transform.SetPositionAndRotation(this.ZeaBedroomSpot.position, this.ZeaBedroomSpot.rotation);
                  Main.Instance.CityCharacters.Zea.gameObject.SetActive(true);
                  this.ZeaBedroomSpot.gameObject.SetActive(true);
                  Main.Instance.CityCharacters.Zea.ChangeUniform(this.ZeaClothes);
                  Main.Instance.CityCharacters.Zea.Anim.Play(this.ZeaWaitAnim);
                  Main.Instance.CityCharacters.Zea.ThisPersonInt.AddBlocker("StripQuest");
                  Main.Instance.CityCharacters.Zea.FreeScheduleTasks.Clear();
                  Main.Instance.CityCharacters.Zea.WorkScheduleTasks.Clear();
                  Main.Instance.CityCharacters.Zea.CurrentScheduleTask = (Person.ScheduleTask) null;
                }
                else
                {
                  this.ZeaBedroomSpot.gameObject.SetActive(false);
                  this.CurrentGoal = this.Goals[7];
                  if (!this.CurrentGoal.Completed)
                  {
                    Main.Instance.CityCharacters.Zea.transform.SetPositionAndRotation(this.ZeaSexroomSpot.position, this.ZeaSexroomSpot.rotation);
                    Main.Instance.CityCharacters.Zea.gameObject.SetActive(true);
                    Main.Instance.CityCharacters.Zea.ChangeUniform(this.ZeaClothes);
                    Main.Instance.CityCharacters.Zea.Anim.Play(this.ZeaWaitAnim);
                    Main.Instance.CityCharacters.Zea.ThisPersonInt.AddBlocker("StripQuest");
                    Main.Instance.CityCharacters.Zea.FreeScheduleTasks.Clear();
                    Main.Instance.CityCharacters.Zea.WorkScheduleTasks.Clear();
                    Main.Instance.CityCharacters.Zea.CurrentScheduleTask = (Person.ScheduleTask) null;
                    Main.Instance.CityCharacters.Zea.RemoveMoveBlocker("StripQuest");
                    Main.Instance.CityCharacters.Zea.StartScheduleTask(new Person.ScheduleTask()
                    {
                      IDName = "ZeaSexGo",
                      ActionPlace = this.ZeaSexroomSpot,
                      OnArrive = (Action) (() => this.ZeaSexStartTrigger.SetActive(true))
                    });
                  }
                  else
                  {
                    this.CurrentGoal = this.Goals[8];
                    if (!this.CurrentGoal.Completed)
                    {
                      Main.Instance.MainThreads.Add(new Action(this.Goal8));
                    }
                    else
                    {
                      this.CurrentGoal = this.Goals[9];
                      if (this.CurrentGoal.Completed)
                        this.CompletedMission = true;
                    }
                  }
                }
              }
            }
          }
        }
      }
    }
    if (this.CompletedMission)
      return;
    Main.Instance.GameplayMenu.DisplayGoal(this.CurrentGoal, true);
  }

  public void Goal1()
  {
    if (!((UnityEngine.Object) Main.Instance.Player.CurrentTop == (UnityEngine.Object) null) || !((UnityEngine.Object) Main.Instance.Player.CurrentPants == (UnityEngine.Object) null))
      return;
    this.CompleteGoal(1);
    Main.Instance.MainThreads.Remove(new Action(this.Goal1));
    this.Lvl1_Locker.Locked = false;
    this.Lvl1_Locker.gameObject.SetActive(true);
    this.Lvl1_Locker.RootObj.SetActive(true);
    this.AddGoal(2, true);
    Main.Instance.MainThreads.Add(new Action(this.Goal2));
  }

  public void Goal2()
  {
    if (!((UnityEngine.Object) Main.Instance.Player.CurrentGarter != (UnityEngine.Object) null))
      return;
    this.CompleteGoal(2);
    Main.Instance.MainThreads.Remove(new Action(this.Goal2));
    this.AddGoal(3, true);
  }

  public int ClientsProstedto
  {
    get => int.Parse(Main.Instance.GlobalVars[nameof (ClientsProstedto)]);
    set
    {
      Main.Instance.GlobalVars[nameof (ClientsProstedto)] = value.ToString();
      this.Goal4(value);
    }
  }

  public void Goal4(int value)
  {
    if (this.ClientsProstedto < 1 || Main.Instance.Player.Money < 200)
      return;
    this.CompleteGoal(4);
    this.AddGoal(5, true);
  }

  public void Goal4_2()
  {
    if (Main.Instance.Player.Money < 200)
      return;
    this.CompleteGoal(4);
    Main.Instance.MainThreads.Remove(new Action(this.Goal4_2));
    this.AddGoal(5, true);
  }

  public void Goal8()
  {
    if (Main.Instance.Player.Money < 2000)
      return;
    this.CompleteGoal(8);
    Main.Instance.MainThreads.Remove(new Action(this.Goal8));
    this.AddGoal(9, true);
  }

  public void Chat_Zea()
  {
    this.ZeaBedroomSpot.gameObject.SetActive(false);
    UI_Gameplay gameplayMenu = Main.Instance.GameplayMenu;
    Person personChattingTo = gameplayMenu.PersonChattingTo;
    gameplayMenu.EnterChatWith(Main.Instance.CityCharacters.Zea, (MonoBehaviour) this, "Chat_Zea2");
    Main.Instance.CityCharacters.Zea.Anim.Play(this.ZeaWaitAnim);
    Main.RunInNextFrame((Action) (() => Main.Instance.CityCharacters.Zea.Anim.Play(this.ZeaWaitAnim)));
    Main.Instance.Player.UserControl.FirstPerson = true;
    Main.Instance.Player.UserControl.LateUpdate();
  }

  public void Chat_Zea2()
  {
    UI_Gameplay gameplayMenu = Main.Instance.GameplayMenu;
    bool flag = false;
    if (Main.Instance.GlobalVars.ContainsKey("MeetZea"))
      flag = bool.Parse(Main.Instance.GlobalVars["MeetZea"]);
    if (!flag)
      gameplayMenu.DisplaySubtitle("Hey Hi there!  I'm Zea, you're also new here?  Guess we're roommates then", (Main.Instance.AllMissions[7] as Mis_Army).ZeaVoiceLines[0], new Action(this.Chat_Zea3), Main.Instance.CityCharacters.Zea, e_BlendShapes.Smile);
    else
      gameplayMenu.DisplaySubtitle("Hey Hi there!  Looks like we're roommates here too", (Main.Instance.AllMissions[7] as Mis_Army).ZeaVoiceLines[1], new Action(this.Chat_Zea3), Main.Instance.CityCharacters.Zea, e_BlendShapes.Smile);
    Main.Instance.CityCharacters.Zea.PlayerKnowsName = true;
    Main.Instance.CityCharacters.Zea.ThisPersonInt.SetDefaultInteraction();
    Main.Instance.GlobalVars.Add("MeetZea", "True");
  }

  public void Chat_Zea3()
  {
    Main.Instance.GameplayMenu.EnableMove();
    Main.Instance.CityCharacters.Zea.ThisPersonInt.EndTheChat();
    this.CompleteGoal(6);
    this.AddGoal(7, true);
    Main.Instance.CityCharacters.Zea.RemoveMoveBlocker("StripQuest");
    Main.Instance.CityCharacters.Zea.StartScheduleTask(new Person.ScheduleTask()
    {
      IDName = "ZeaSexGo",
      ActionPlace = this.ZeaSexroomSpot,
      OnArrive = (Action) (() => this.ZeaSexStartTrigger.SetActive(true))
    });
  }

  public void EnterSexRoom()
  {
    this.ZeaSexStartTrigger.SetActive(false);
    UI_Gameplay gameplayMenu = Main.Instance.GameplayMenu;
    Person personChattingTo = gameplayMenu.PersonChattingTo;
    gameplayMenu.EnterChatWith(Main.Instance.CityCharacters.Zea, (MonoBehaviour) this, "Chat_Zea4");
  }

  public void Chat_Zea4()
  {
    UI_Gameplay gameplayMenu = Main.Instance.GameplayMenu;
    Person personChattingTo = gameplayMenu.PersonChattingTo;
    if ((UnityEngine.Object) this.BarMusic != (UnityEngine.Object) null)
      this.BarMusic.volume = 0.05f;
    gameplayMenu.DisplaySubtitle("Well, this time I will be your client", this.CarolLines[28], new Action(this.ZeaSexRoomChat), Main.Instance.CityCharacters.Zea);
  }

  public void ZeaSexRoomChat()
  {
    Person personChattingTo = Main.Instance.GameplayMenu.PersonChattingTo;
    if ((UnityEngine.Object) this.BarMusic != (UnityEngine.Object) null)
      this.BarMusic.volume = 1f;
    personChattingTo.ThisPersonInt.EndTheChat();
    SpawnedSexScene spawnedSexScene = Main.Instance.SexScene.SpawnSexScene(2, 11, Main.Instance.Player, Main.Instance.CityCharacters.Zea, receiveMoney: true, canControl: false);
    spawnedSexScene.TimerForRandomPoseChange = true;
    spawnedSexScene.TimerMax = UnityEngine.Random.Range(10f, 20f);
    spawnedSexScene.TimerPoseChange = spawnedSexScene.TimerMax;
    spawnedSexScene.TimerForRandomSexEnd = true;
    spawnedSexScene.TimerSexEnd = UnityEngine.Random.Range(60f, 120f);
    spawnedSexScene.transform.root.position = this.ZeaSexroomSpot.position;
    Main.Instance.CityCharacters.Zea.FreeScheduleTasks.Clear();
    Main.Instance.CityCharacters.Zea.WorkScheduleTasks.Clear();
    Main.Instance.CityCharacters.Zea.CurrentScheduleTask = (Person.ScheduleTask) null;
    Main.Instance.CityCharacters.Zea.ThisPersonInt.SetDefaultChat();
    Main.Instance.CityCharacters.Zea.RemoveMoveBlocker("StripQuest");
    Main.Instance.CityCharacters.Zea.ThisPersonInt.RemoveBlocker("StripQuest");
    Main.Instance.CityCharacters.Zea.CurrentZone = this.StipClubZone;
    Main.Instance.CityCharacters.Zea.State = Person_State.Free;
    Main.Instance.CityCharacters.Zea.ScheduleDecide();
    this.CompleteGoal(7);
    this.AddGoal(8, true);
    Main.Instance.MainThreads.Add(new Action(this.Goal8));
    spawnedSexScene.OnSexEnd = (Action) (() =>
    {
      if ((Main.Instance.AllMissions[10] as Mis_Zea1).MissionCanStart())
      {
        Main.RunInSeconds((Action) (() => (Main.Instance.AllMissions[10] as Mis_Zea1).StartIfItCan()), 10f);
      }
      else
      {
        Main.Instance.GameplayMenu.ShowNotification("You can do the Army mission");
        Main.Instance.GameplayMenu.DisplayGoal(Main.Instance.AllMissions[16 /*0x10*/].Goals[1], true);
      }
    });
  }

  public void DeskChat()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person person = _gameplay.PersonChattingTo;
    _gameplay.RemoveAllChatOptions();
    if (this.CurrentGoal == this.Goals[9] && !this.Goals[9].Completed)
    {
      if ((UnityEngine.Object) this.BarMusic != (UnityEngine.Object) null)
        this.BarMusic.volume = 0.05f;
      _gameplay.DisplaySubtitle("I knew there had to be a reason for clients to be asking for you...", this.CarolLines[22], (Action) (() => _gameplay.DisplaySubtitle("Why are you wasting your time doing this kind or work?", this.CarolLines[23], (Action) (() => _gameplay.DisplaySubtitle("You've got a city to run, go.", this.CarolLines[24], (Action) (() => _gameplay.DisplaySubtitle("Oh... Unless this is some punishment they put on you for some reason", this.CarolLines[25], (Action) (() => _gameplay.DisplaySubtitle("Well anyway, do what you want", this.CarolLines[26], (Action) (() =>
      {
        if ((UnityEngine.Object) this.BarMusic != (UnityEngine.Object) null)
          this.BarMusic.volume = 1f;
        person.ThisPersonInt.EndTheChat();
        this.CompleteGoal(9);
        this.CompleteMission();
      }))))))))));
    }
    else if (this.CurrentGoal == this.Goals[5] && !this.Goals[5].Completed)
    {
      if (Main.Instance.AllMissions[7].Goals[0].Completed && !Main.Instance.AllMissions[7].CompletedMission || Main.Instance.AllMissions[8].Goals[0].Completed && !Main.Instance.AllMissions[8].CompletedMission)
      {
        Main.Instance.GameplayMenu.ShowNotification("Can't continue this mission at this moment.  Advance in the [Army] first.");
        Main.Instance.GameplayMenu.EnableMove();
        person.ThisPersonInt.EndTheChat();
      }
      else
      {
        if ((UnityEngine.Object) this.BarMusic != (UnityEngine.Object) null)
          this.BarMusic.volume = 0.05f;
        _gameplay.DisplaySubtitle("So you managed to earn 200 huh?", this.CarolLines[15], (Action) (() => _gameplay.DisplaySubtitle("Wasn't that hard, was it?", this.CarolLines[16 /*0x10*/], (Action) (() =>
        {
          Main.Instance.GameplayMenu.ShowNotification("Unlocked new safehouse [Stripclub Bedroom]");
          this.StaffRoom.SafeHouse = true;
          _gameplay.DisplaySubtitle("Well you're one of us now, you can use the [staff room] upstairs as your own", this.CarolLines[27], (Action) (() => _gameplay.DisplaySubtitle("Level yourself up, so you can make more profit too", this.CarolLines[17], (Action) (() => _gameplay.DisplaySubtitle("And then come back to me when you've earned 2000", this.CarolLines[18], (Action) (() => _gameplay.DisplaySubtitle("Then I'll gift you a rank 2 uniform", this.CarolLines[19], (Action) (() => _gameplay.DisplaySubtitle("meanwhile, we have a client upstairs that asked just for you", this.CarolLines[20], (Action) (() => _gameplay.DisplaySubtitle("Meet their fetishes and they'll pay you well", this.CarolLines[21], (Action) (() =>
          {
            if ((UnityEngine.Object) this.BarMusic != (UnityEngine.Object) null)
              this.BarMusic.volume = 1f;
            person.ThisPersonInt.EndTheChat();
            this.CompleteGoal(5);
            this.AddGoal(6, true);
            Main.Instance.CityCharacters.Zea.AddMoveBlocker("StripQuest");
            Main.Instance.CityCharacters.Zea.transform.SetPositionAndRotation(this.ZeaBedroomSpot.position, this.ZeaBedroomSpot.rotation);
            Main.Instance.CityCharacters.Zea.gameObject.SetActive(true);
            this.ZeaBedroomSpot.gameObject.SetActive(true);
            Main.Instance.CityCharacters.Zea.ChangeUniform(this.ZeaClothes);
            Main.Instance.CityCharacters.Zea.Anim.Play(this.ZeaWaitAnim);
            Main.Instance.CityCharacters.Zea.ThisPersonInt.AddBlocker("StripQuest");
          }))))))))))));
        }))));
      }
    }
    else if (this.CurrentGoal == this.Goals[3] && !this.Goals[3].Completed)
    {
      if ((UnityEngine.Object) this.BarMusic != (UnityEngine.Object) null)
        this.BarMusic.volume = 0.05f;
      _gameplay.DisplaySubtitle("Alright, you're all dressed and ready", this.CarolLines[10], (Action) (() => _gameplay.DisplaySubtitle("You can go around and get clients manually", this.CarolLines[11], (Action) (() => _gameplay.DisplaySubtitle("Some might come to you on their own too", this.CarolLines[12], (Action) (() => _gameplay.DisplaySubtitle("Or you can just ask me for a client and I send you into a room", this.CarolLines[13], (Action) (() => _gameplay.DisplaySubtitle("Go ahead and earn 200 out there, then come back", this.CarolLines[14], (Action) (() =>
      {
        if ((UnityEngine.Object) this.BarMusic != (UnityEngine.Object) null)
          this.BarMusic.volume = 1f;
        person.ThisPersonInt.EndTheChat();
        this.CompleteGoal(3);
        this.AddGoal(4, true);
        Main.Instance.MainThreads.Add(new Action(this.Goal4_2));
      }))))))))));
    }
    else
    {
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
      if (this.Goals[3].Completed)
        _gameplay.AddChatOption("Got any client?", (Action) (() =>
        {
          if ((UnityEngine.Object) this.StripClub.PickFreeBed() == (UnityEngine.Object) null)
          {
            _gameplay.DisplaySubtitle("All rooms are occupied at the moment, come back later", (AudioClip) null, new Action(person.ThisPersonInt.EndTheChat));
            Main.Instance.GameplayMenu.EnableMove();
          }
          else
          {
            _gameplay.DisplaySubtitle("Not at the moment", (AudioClip) null, new Action(person.ThisPersonInt.EndTheChat));
            Main.Instance.GameplayMenu.EnableMove();
          }
        }));
      else if (!Main.Instance.CanSaveGame)
        _gameplay.AddChatOption("(Unavailable during other mission) I'd like to work here", (Action) (() => person.ThisPersonInt.EndTheChat()));
      else if (Main.Instance.Player is Girl)
        _gameplay.AddChatOption("I'd like to work here", (Action) (() =>
        {
          if ((UnityEngine.Object) this.BarMusic != (UnityEngine.Object) null)
            this.BarMusic.volume = 0.05f;
          Main.Instance.AllMissions[16 /*0x10*/].CompleteGoal(0);
          _gameplay.DisplaySubtitle("You can always ask anyone out there for paid sex", this.CarolLines[0], (Action) (() => _gameplay.DisplaySubtitle("But they might think you're trying to rob them, so they won't trust you", this.CarolLines[1], (Action) (() => _gameplay.DisplaySubtitle("But by being dressed as a prostitute, clients will trust you more", this.CarolLines[2], (Action) (() => _gameplay.DisplaySubtitle("Out there you can wear whatever you want", this.CarolLines[3], (Action) (() => _gameplay.DisplaySubtitle("But in this club you need to wear the proper uniform", this.CarolLines[4], (Action) (() => _gameplay.DisplaySubtitle("It's your first time? Are you a basic bitch now?", this.CarolLines[5], (Action) (() => _gameplay.DisplaySubtitle("Well then whatever, you start with a pre-used basic uniform then", this.CarolLines[6], (Action) (() => _gameplay.DisplaySubtitle("and then later I can level you up to a new uniform.", this.CarolLines[7], (Action) (() => _gameplay.DisplaySubtitle("Go to the lockers behind the curtains on the dance stage", this.CarolLines[8], (Action) (() => _gameplay.DisplaySubtitle("Leave your clothing there, equip your uniform, then come back to me", this.CarolLines[9], (Action) (() =>
          {
            if ((UnityEngine.Object) this.BarMusic != (UnityEngine.Object) null)
              this.BarMusic.volume = 1f;
            Main.Instance.GameplayMenu.ShowNotification("Received [Locker Key]");
            Main.Instance.AllMissions[1].CompleteGoal(5);
            Main.Instance.GameplayMenu.StartMission((Mission) this);
            person.ThisPersonInt.EndTheChat();
          }))))))))))))))))))));
        }));
      _gameplay.AddChatOption("I just wanna get fucked so bad right now", (Action) (() =>
      {
        _gameplay.DisplaySubtitle("Get that pussy in view, and go on the stage sex spots", (AudioClip) null, new Action(person.ThisPersonInt.EndTheChat));
        Main.Instance.GameplayMenu.EnableMove();
      }));
      _gameplay.AddChatOption("I'd like a girl please (200BN)", (Action) (() =>
      {
        if (Main.Instance.Player.Money >= 200)
          _gameplay.DisplaySubtitle("Go upstairs or pick one around", (AudioClip) null, new Action(person.ThisPersonInt.EndTheChat));
        else
          _gameplay.DisplaySubtitle("You don't have enough Bitch Notes.  You'll need 200", (AudioClip) null, new Action(person.ThisPersonInt.EndTheChat));
        Main.Instance.GameplayMenu.EnableMove();
      }));
      _gameplay.AddChatOption("Are you available too? (500BN)", (Action) (() =>
      {
        if (Main.Instance.Player.Money >= 500)
        {
          person.ThisPersonInt.EndTheChat();
          Main.Instance.Player.transform.SetPositionAndRotation(this.DeskGirlFuckSpot.position, this.DeskGirlFuckSpot.rotation);
          person.State = Person_State.Work;
          person.RandActionTimer = 0.0f;
          Main.Instance.Player.Money -= 500;
          Main.Instance.GameplayMenu.ShowNotification("Paid 500 Bitch Notes");
          if (person.Interacting)
            person.InteractingWith.StopInteracting();
          if (person.Favor < 0)
            person.Favor = 1;
          person.Energy = person.EnergyMax;
          Main.Instance.SexScene.SpawnSexScene(2, 4, Main.Instance.Player, person);
        }
        else
        {
          Main.Instance.GameplayMenu.EnableMove();
          _gameplay.DisplaySubtitle("500 Bitch Notes", (AudioClip) null, new Action(person.ThisPersonInt.EndTheChat));
        }
      }));
      _gameplay.SelectChatOption(0);
      Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
    }
  }

  public void DeskSpawn(Person person)
  {
    Main.Instance.CityCharacters.SetPerson(person);
    if (person.Favor < 0)
      person.Favor = 1;
    person.Energy = person.EnergyMax = 1000f;
    person.DyedHairColor = new Color(0.0f, 0.5f, 1f);
    Transform boobLeft = person.BoobLeft;
    Transform boobRight = person.BoobRight;
    Vector3 vector3_1 = new Vector3(1.2f, 1.2f, 1.2f);
    Vector3 vector3_2 = vector3_1;
    boobRight.localScale = vector3_2;
    Vector3 vector3_3 = vector3_1;
    boobLeft.localScale = vector3_3;
    Transform assCheekLeft = person.AssCheekLeft;
    Transform assCheekRight = person.AssCheekRight;
    vector3_1 = new Vector3(1.2f, 1f, 1f);
    Vector3 vector3_4 = vector3_1;
    assCheekRight.localScale = vector3_4;
    Vector3 vector3_5 = vector3_1;
    assCheekLeft.localScale = vector3_5;
    person.Hips.localScale = new Vector3(1.1f, 1f, 1f);
    Transform legLeft = person.LegLeft;
    Transform legRight = person.LegRight;
    vector3_1 = new Vector3(1.1f, 1f, 1.1f);
    Vector3 vector3_6 = vector3_1;
    legRight.localScale = vector3_6;
    Vector3 vector3_7 = vector3_1;
    legLeft.localScale = vector3_7;
    Transform upperThighLeft = person.UpperThighLeft;
    person.UpperThighRight.localScale = vector3_1 = Vector3.one;
    Vector3 vector3_8 = vector3_1;
    upperThighLeft.localScale = vector3_8;
    Transform midThighLeft = person.MidThighLeft;
    person.MidThighRight.localScale = vector3_1 = Vector3.one;
    Vector3 vector3_9 = vector3_1;
    midThighLeft.localScale = vector3_9;
    Transform lowerThighLeft = person.LowerThighLeft;
    person.LowerThighRight.localScale = vector3_1 = Vector3.one;
    Vector3 vector3_10 = vector3_1;
    lowerThighLeft.localScale = vector3_10;
    person.transform.localScale = Vector3.one;
  }

  public void OnEnter_Lockers()
  {
    this.CompleteGoal(0);
    this.LockerArea.SetActive(false);
    this.AddGoal(1, true);
    Main.Instance.MainThreads.Add(new Action(this.Goal1));
  }
}
