// Decompiled with JetBrains decompiler
// Type: Mis_Mines_Med
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

#nullable disable
public class Mis_Mines_Med : Mission
{
  public int TrainScene;
  public Transform SarahKickDoorSpot;
  public Transform SarahSexDest;
  public Transform SarahSexSpot;
  public Transform SarahCaveSpot;
  public Int_Door TheDoor;
  public AudioClip DoorKickSound;
  public TeleportDoor LabEntranceDoor;
  public TeleportDoor LabExitDoor;
  public Int_Door The2ndDoor;
  public Int_Door The3rdDoor;
  public AudioClip[] VoiceLines;
  public bl_LocalLOD HotelLod;
  public GameObject[] SarahSexClothes;
  public GameObject[] SarahNormalClothes;
  public Transform[] SarahSexTimeSpot;
  public GameObject[] EnableWhenCouchSex;
  public Transform[] SPOTS;
  public Transform Grates;
  public Transform GratesEndSpot;
  public Transform RespawnSpot;
  public GameObject HOle;
  [Header(" - runtime")]
  public Transform EnterSpot;
  public float SexTimer;
  public SpawnedSexScene _sex;
  public bool _Said;
  public float _Crawling;
  public float _CrawlingMax;
  public bool _SephieArrivedAtTrain;

  public void InitTrainsScene()
  {
  }

  public void HasLoaded()
  {
  }

  public void StartIfItCan()
  {
    if (!this.MissionCanStart())
      return;
    Main.Instance.GameplayMenu.StartMission((Mission) this);
  }

  public bool MissionCanStart()
  {
    return !this.CompletedMission && Main.Instance.AllMissions[8].CompletedMission && Main.Instance.AllMissions[3].Goals[7].Completed;
  }

  public override void InitMission()
  {
    Debug.LogError((object) "Mis_Mines_Med InitMission()");
    (Main.Instance.AllMissions[10] as Mis_Zea1).StartIfItCan();
    if (!this.MissionCanStart() || this._Inited)
      return;
    base.InitMission();
    this.CurrentGoal = this.Goals[0];
    if (this.CurrentGoal.Completed)
    {
      this.CurrentGoal = this.Goals[1];
      if (this.CurrentGoal.Completed)
      {
        this.CurrentGoal = this.Goals[2];
        if (this.CurrentGoal.Completed)
          this.CompletedMission = true;
      }
    }
    if (!this.CompletedMission)
    {
      Main.Instance.GameplayMenu.DisplayGoal(this.CurrentGoal, true);
    }
    else
    {
      (Main.Instance.AllMissions[10] as Mis_Zea1).StartIfItCan();
      if (Main.Instance.AllMissions[12].CompletedMission)
        return;
      Main.Instance.AllMissions[12].InitMission();
    }
  }

  public void AfterMissionSex()
  {
    UI_Gameplay gameplayMenu1 = Main.Instance.GameplayMenu;
    Person person = Main.Instance.CityCharacters.Sarah;
    person.AddMoveBlocker("asdasd");
    person.ThisPersonInt.EndTheChat();
    person.State = Person_State.Work;
    person.FootStepsAudio.gameObject.SetActive(true);
    Main.Instance.Player.AddMoveBlocker("SarahQuest");
    Main.Instance.MusicPlayer.pitch = 1f;
    Main.Instance.MusicPlayer.volume = 1f;
    Main.Instance.MusicPlayer.PlayOneShot(Main.Instance.PunchSounds[UnityEngine.Random.Range(0, Main.Instance.PunchSounds.Length)]);
    Main.Instance.Player.UserControl.FirstPerson = false;
    person.enabled = false;
    person.Anim.Play("jump_13_b");
    this.TheDoor.CloseDoor();
    Main.RunInSeconds((Action) (() =>
    {
      this.HotelLod.AlwaysON = true;
      this.HotelLod.Show();
      person.enabled = true;
      person.RemoveMoveBlocker("asdasd");
      person.Anim.SetLayerWeight(1, 1f);
      Main.Instance.Player.UserControl.FirstPerson = false;
      Main.Instance.Player.Anim.Play("BeingCarried");
      Main.Instance.Player.transform.SetParent(person.ShoulderRight);
      Main.Instance.Player.transform.localPosition = new Vector3(0.112f, -0.755f, -0.22f);
      Main.Instance.Player.transform.localEulerAngles = Vector3.zero;
      Main.Instance.Player._Rigidbody.isKinematic = true;
      Main.Instance.Player.enabled = false;
      Main.Instance.Player.UserControl.enabled = false;
      Main.Instance.Player.UserControl.m_Character.enabled = false;
      Main.Instance.Player.GetComponent<NavMeshObstacle>().enabled = false;
      Main.Instance.Player.LookAtPlayer.Disable = true;
      Main.Instance.Player.UserControl.TheCam.m_Target = person.transform;
      person.StartScheduleTask(new Person.ScheduleTask()
      {
        IDName = "SarahCarry1",
        RunTo = true,
        ActionPlace = this.SarahKickDoorSpot,
        OnArrive = (Action) (() =>
        {
          person.AddMoveBlocker("asdasd");
          person.enabled = false;
          person.transform.SetPositionAndRotation(this.SarahKickDoorSpot.position, this.SarahKickDoorSpot.rotation);
          Main.RunInNextFrame((Action) (() =>
          {
            person.Anim.Play("kick_24");
            this.TheDoor.OpenDoor();
            Main.Instance.MusicPlayer.pitch = 1f;
            Main.Instance.MusicPlayer.volume = 0.5f;
            Main.Instance.MusicPlayer.PlayOneShot(this.DoorKickSound, 0.5f);
          }));
          Main.RunInSeconds((Action) (() =>
          {
            Main.Instance.MusicPlayer.pitch = 1f;
            Main.Instance.MusicPlayer.volume = 1f;
            person.RemoveMoveBlocker("asdasd");
            person.enabled = true;
            person.StartScheduleTask(new Person.ScheduleTask()
            {
              IDName = "SarahCarry2",
              RunTo = true,
              ActionPlace = this.SarahSexDest,
              OnArrive = (Action) (() =>
              {
                person.FootStepsAudio.gameObject.SetActive(false);
                person.Anim.SetLayerWeight(1, 0.0f);
                Main.Instance.Player.transform.SetParent((Transform) null);
                Main.Instance.Player.UserControl.TheCam.m_Target = Main.Instance.Player.transform;
                Main.Instance.Player.transform.position = this.SarahSexDest.position;
                Main.Instance.Player.transform.eulerAngles = this.SarahSexDest.eulerAngles;
                Main.Instance.Player.GetComponent<NavMeshObstacle>().enabled = true;
                Main.Instance.Player.LookAtPlayer.Disable = false;
                Main.Instance.Player.Energy = 100f;
                person.Energy = 100f;
                Main.Instance.Player.NoEnergyLoss = true;
                person.NoEnergyLoss = true;
                person.ChangeUniform(this.SarahSexClothes);
                for (int index = 0; index < this.EnableWhenCouchSex.Length; ++index)
                  this.EnableWhenCouchSex[index].SetActive(true);
                (person as Girl).HasCondomPut = true;
                if (Main.Instance.Player.HasPenis)
                {
                  Main.Instance.MusicPlayer.PlayOneShot(Main.Instance.PunchSounds[UnityEngine.Random.Range(0, Main.Instance.PunchSounds.Length)]);
                  this._sex = Main.Instance.SexScene.SpawnSexScene(6, 0, Main.Instance.Player, Main.Instance.CityCharacters.Sarah, canControl: false);
                  this._sex.transform.root.position = this.SarahSexSpot.position;
                  this._sex.transform.root.rotation = this.SarahSexSpot.rotation;
                  Main.Instance.SexScene.OpenSex2();
                  Main.Instance.SexScene.CanExitSexScene = true;
                  this._sex.On_ClothingToggle_ind(person, true);
                  this._sex.On_ClothingToggle_ind(Main.Instance.Player, false);
                  Main.Instance.SexScene.SpeedSlider.value = 2f;
                  person.LookAtPlayer.playerTransform = Main.Instance.Player.Head;
                  person.LookAtPlayer.OnlyEyes = false;
                }
                else
                {
                  person.transform.position = this.SarahSexTimeSpot[0].position;
                  person.transform.rotation = this.SarahSexTimeSpot[0].rotation;
                  Main.Instance.Player.transform.position = this.SarahSexTimeSpot[1].position;
                  Main.Instance.Player.transform.rotation = this.SarahSexTimeSpot[1].rotation;
                  person.enabled = false;
                  person.AddMoveBlocker("asdasd");
                  Main.Instance.Player.enabled = false;
                  Main.Instance.Player.AddMoveBlocker("asdasd");
                  Main.RunInNextFrame((Action) (() => person.Anim.Play("mast2pp")));
                  Main.Instance.Player.Anim.Play("CouchSexSit");
                  (person as Girl).StrapOn = person.DressClothe(Main.Instance.TempStraponPanties);
                  person.PutPenis();
                  person.PenisErect = true;
                  person.Penis.GetComponentInChildren<SkinnedMeshRenderer>(true).material = Main.Instance.StraponMat;
                  person.PostureState = Person_PostureState.Standing;
                  person.HasPenis = true;
                  this._sex = Main.Instance.SexScene.SpawnSexScene(6, 2, Main.Instance.CityCharacters.Sarah, Main.Instance.Player, canControl: false);
                  Main.Instance.MusicPlayer.PlayOneShot(Main.Instance.PunchSounds[UnityEngine.Random.Range(0, Main.Instance.PunchSounds.Length)]);
                  this._sex.transform.root.position = this.SarahSexSpot.position;
                  this._sex.transform.root.rotation = this.SarahSexSpot.rotation;
                  Main.Instance.SexScene.OpenSex2();
                  Main.Instance.SexScene.CanExitSexScene = true;
                  this._sex.On_ClothingToggle_ind(person, true);
                  this._sex.On_ClothingToggle_ind(Main.Instance.Player, false);
                  Main.Instance.SexScene.SpeedSlider.value = 2f;
                  Main.Instance.SexScene.Sex2Pose.value = 2;
                }
                this._sex.OnSexEnd = (Action) (() =>
                {
                  for (int index = 0; index < this.EnableWhenCouchSex.Length; ++index)
                    this.EnableWhenCouchSex[index].SetActive(false);
                  UI_Gameplay gameplayMenu3 = Main.Instance.GameplayMenu;
                  Person sarah = Main.Instance.CityCharacters.Sarah;
                  sarah.HasPenis = false;
                  sarah.ChangeUniform(this.SarahNormalClothes);
                  sarah.RemovePenis();
                  Main.Instance.Player.enabled = true;
                  Main.Instance.Player.UserControl.enabled = true;
                  Main.Instance.Player.UserControl.m_Character.enabled = true;
                  Main.Instance.Player.RemoveMoveBlocker("SarahQuest");
                  Main.Instance.Player.RemoveMoveBlocker("asdasd");
                  sarah.CompleteScheduleTask(false);
                  (Main.Instance.AllMissions[1] as Mis_MedTutorial).SarahPatrol.StartPatrol(sarah);
                  sarah.ScheduleDecide();
                });
              })
            });
          }), 1.2f);
        })
      });
      person.navMesh.speed = 6f;
    }), 0.9f);
  }

  public void SarahTalkInit()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person person = Main.Instance.CityCharacters.Sarah;
    this.LabEntranceDoor.Locked = true;
    _gameplay.DisplaySubtitle("Well, it's not exactly what you think", this.VoiceLines[16 /*0x10*/], (Action) (() =>
    {
      person.ThisPersonInt.AddBlocker("quest");
      Main.Instance.CanSaveFlags_add("SarahMission");
      this.CompleteGoal(0);
      _gameplay.DisplaySubtitle("But before that, I need to commemorate your return", this.VoiceLines[17], (Action) (() =>
      {
        person.AddMoveBlocker("asdasd");
        person.ThisPersonInt.EndTheChat();
        person.State = Person_State.Work;
        person.FootStepsAudio.gameObject.SetActive(true);
        Main.Instance.Player.AddMoveBlocker("SarahQuest");
        Main.Instance.MusicPlayer.pitch = 1f;
        Main.Instance.MusicPlayer.volume = 1f;
        Main.Instance.MusicPlayer.PlayOneShot(Main.Instance.PunchSounds[UnityEngine.Random.Range(0, Main.Instance.PunchSounds.Length)]);
        Main.Instance.Player.UserControl.FirstPerson = false;
        person.enabled = false;
        person.Anim.Play("jump_13_b");
        this.TheDoor.CloseDoor();
        Main.RunInSeconds((Action) (() =>
        {
          this.HotelLod.AlwaysON = true;
          this.HotelLod.Show();
          person.enabled = true;
          person.RemoveMoveBlocker("asdasd");
          person.Anim.SetLayerWeight(1, 1f);
          Main.Instance.Player.UserControl.FirstPerson = false;
          Main.Instance.Player.Anim.Play("BeingCarried");
          Main.Instance.Player.transform.SetParent(person.ShoulderRight);
          Main.Instance.Player.transform.localPosition = new Vector3(0.112f, -0.755f, -0.22f);
          Main.Instance.Player.transform.localEulerAngles = Vector3.zero;
          Main.Instance.Player._Rigidbody.isKinematic = true;
          Main.Instance.Player.enabled = false;
          Main.Instance.Player.UserControl.enabled = false;
          Main.Instance.Player.UserControl.m_Character.enabled = false;
          Main.Instance.Player.GetComponent<NavMeshObstacle>().enabled = false;
          Main.Instance.Player.LookAtPlayer.Disable = true;
          Main.Instance.Player.UserControl.TheCam.m_Target = person.transform;
          person.StartScheduleTask(new Person.ScheduleTask()
          {
            IDName = "SarahCarry1",
            RunTo = true,
            ActionPlace = this.SarahKickDoorSpot,
            OnArrive = (Action) (() =>
            {
              person.AddMoveBlocker("asdasd");
              person.enabled = false;
              person.transform.SetPositionAndRotation(this.SarahKickDoorSpot.position, this.SarahKickDoorSpot.rotation);
              Main.RunInNextFrame((Action) (() =>
              {
                person.Anim.Play("kick_24");
                this.TheDoor.OpenDoor();
                Main.Instance.MusicPlayer.pitch = 1f;
                Main.Instance.MusicPlayer.volume = 0.5f;
                Main.Instance.MusicPlayer.PlayOneShot(this.DoorKickSound, 0.5f);
              }));
              Main.RunInSeconds((Action) (() =>
              {
                Main.Instance.MusicPlayer.pitch = 1f;
                Main.Instance.MusicPlayer.volume = 1f;
                person.RemoveMoveBlocker("asdasd");
                person.enabled = true;
                person.StartScheduleTask(new Person.ScheduleTask()
                {
                  IDName = "SarahCarry2",
                  RunTo = true,
                  ActionPlace = this.SarahSexDest,
                  OnArrive = (Action) (() =>
                  {
                    person.FootStepsAudio.gameObject.SetActive(false);
                    person.Anim.SetLayerWeight(1, 0.0f);
                    Main.Instance.Player.transform.SetParent((Transform) null);
                    Main.Instance.Player.UserControl.TheCam.m_Target = Main.Instance.Player.transform;
                    Main.Instance.Player.transform.position = this.SarahSexDest.position;
                    Main.Instance.Player.transform.eulerAngles = this.SarahSexDest.eulerAngles;
                    Main.Instance.Player.GetComponent<NavMeshObstacle>().enabled = true;
                    Main.Instance.Player.LookAtPlayer.Disable = false;
                    Main.Instance.Player.Energy = 100f;
                    person.Energy = 100f;
                    Main.Instance.Player.NoEnergyLoss = true;
                    person.NoEnergyLoss = true;
                    person.ChangeUniform(this.SarahSexClothes);
                    for (int index = 0; index < this.EnableWhenCouchSex.Length; ++index)
                      this.EnableWhenCouchSex[index].SetActive(true);
                    (person as Girl).HasCondomPut = true;
                    this.SexTimer = 30f;
                    Main.Instance.MainThreads.Add(new Action(this.SexTimerFunc));
                    if (Main.Instance.Player.HasPenis)
                    {
                      Main.Instance.MusicPlayer.PlayOneShot(Main.Instance.PunchSounds[UnityEngine.Random.Range(0, Main.Instance.PunchSounds.Length)]);
                      this._sex = Main.Instance.SexScene.SpawnSexScene(6, 0, Main.Instance.Player, Main.Instance.CityCharacters.Sarah, canControl: false);
                      Main.Instance.SexScene.SexSubtitle.text = "Oh, I've been missing this one";
                      Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[18]);
                      this._sex.transform.root.position = this.SarahSexSpot.position;
                      this._sex.transform.root.rotation = this.SarahSexSpot.rotation;
                      Main.Instance.SexScene.OpenSex2();
                      Main.Instance.SexScene.CanExitSexScene = false;
                      this._sex.On_ClothingToggle_ind(person, true);
                      this._sex.On_ClothingToggle_ind(Main.Instance.Player, false);
                      Main.Instance.SexScene.SpeedSlider.value = 2f;
                      person.LookAtPlayer.playerTransform = Main.Instance.Player.Head;
                      person.LookAtPlayer.OnlyEyes = false;
                      Main.RunInSeconds((Action) (() =>
                      {
                        Main.Instance.SexScene.SexSubtitle.text = "This time I'm gonna give you exactly 30 seconds with me";
                        Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[20]);
                        Main.RunInSeconds((Action) (() => Main.Instance.SexScene.SexSubtitle.text = string.Empty), 3f);
                      }), 3f);
                    }
                    else
                    {
                      person.transform.position = this.SarahSexTimeSpot[0].position;
                      person.transform.rotation = this.SarahSexTimeSpot[0].rotation;
                      Main.Instance.Player.transform.position = this.SarahSexTimeSpot[1].position;
                      Main.Instance.Player.transform.rotation = this.SarahSexTimeSpot[1].rotation;
                      person.enabled = false;
                      person.AddMoveBlocker("asdasd");
                      Main.Instance.Player.enabled = false;
                      Main.Instance.Player.AddMoveBlocker("asdasd");
                      Main.RunInNextFrame((Action) (() => person.Anim.Play("mast2pp")));
                      Main.Instance.Player.Anim.Play("CouchSexSit");
                      (person as Girl).StrapOn = person.DressClothe(Main.Instance.TempStraponPanties);
                      person.PutPenis();
                      person.PenisErect = true;
                      person.Penis.GetComponentInChildren<SkinnedMeshRenderer>(true).material = Main.Instance.StraponMat;
                      person.PostureState = Person_PostureState.Standing;
                      person.HasPenis = true;
                      _gameplay.DisplaySubtitle("I bet you've missed this one", this.VoiceLines[19], (Action) (() =>
                      {
                        this._sex = Main.Instance.SexScene.SpawnSexScene(6, 2, Main.Instance.CityCharacters.Sarah, Main.Instance.Player, canControl: false);
                        Main.Instance.MusicPlayer.PlayOneShot(Main.Instance.PunchSounds[UnityEngine.Random.Range(0, Main.Instance.PunchSounds.Length)]);
                        this._sex.transform.root.position = this.SarahSexSpot.position;
                        this._sex.transform.root.rotation = this.SarahSexSpot.rotation;
                        Main.Instance.SexScene.OpenSex2();
                        Main.Instance.SexScene.CanExitSexScene = false;
                        this._sex.On_ClothingToggle_ind(person, true);
                        this._sex.On_ClothingToggle_ind(Main.Instance.Player, false);
                        Main.Instance.SexScene.SpeedSlider.value = 2f;
                        Main.Instance.SexScene.Sex2Pose.value = 2;
                        Main.Instance.SexScene.SexSubtitle.text = "This time I'm gonna give you exactly 30 seconds with me";
                        Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[20]);
                        Main.RunInSeconds((Action) (() => Main.Instance.SexScene.SexSubtitle.text = string.Empty), 3f);
                      }), person);
                    }
                  })
                });
              }), 1.2f);
            })
          });
          person.navMesh.speed = 6f;
        }), 0.9f);
      }));
    }));
  }

  public void SexTimerFunc()
  {
    this.SexTimer -= Time.deltaTime;
    Main.Instance.SexScene.Sex2TimerUI.text = this.SexTimer.ToString("00");
    if ((double) this.SexTimer >= 0.0)
      return;
    Main.Instance.MainThreads.Remove(new Action(this.SexTimerFunc));
    this._sex.SafeSexEnd();
    for (int index = 0; index < this.EnableWhenCouchSex.Length; ++index)
      this.EnableWhenCouchSex[index].SetActive(false);
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person person = Main.Instance.CityCharacters.Sarah;
    person.HasPenis = false;
    person.ChangeUniform(this.SarahNormalClothes);
    person.RemovePenis();
    Main.Instance.Player.enabled = true;
    Main.Instance.Player.UserControl.enabled = true;
    Main.Instance.Player.UserControl.m_Character.enabled = true;
    Main.Instance.Player.RemoveMoveBlocker("SarahQuest");
    Main.Instance.Player.RemoveMoveBlocker("asdasd");
    _gameplay.DisplaySubtitle("We have to go now", this.VoiceLines[21], (Action) (() => _gameplay.DisplaySubtitle("We can continue later when we have more time", this.VoiceLines[22], (Action) (() =>
    {
      person.ThisPersonInt.EndTheChat();
      this.AddGoal(1, true);
      person.StartScheduleTask(new Person.ScheduleTask()
      {
        IDName = "SarahCave",
        RunTo = true,
        ActionPlace = this.SarahCaveSpot,
        OnArrive = (Action) (() =>
        {
          person.transform.SetPositionAndRotation(this.SarahCaveSpot.position, this.SarahCaveSpot.rotation);
          Main.Instance.MainThreads.Add(new Action(this.Goal2));
        })
      });
      person.navMesh.speed = 6f;
    }), person)), person);
  }

  public void Goal2()
  {
    if ((double) Vector3.Distance(Main.Instance.Player.transform.position, Main.Instance.CityCharacters.Sarah.transform.position) >= 2.0)
      return;
    Main.Instance.MainThreads.Remove(new Action(this.Goal2));
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person person = Main.Instance.CityCharacters.Sarah;
    this.CompleteGoal(1);
    _gameplay.DisplaySubtitle("This here is the entrance to Sephie's secret lab", this.VoiceLines[23], (Action) (() => _gameplay.DisplaySubtitle("She's our lead scientist in...everything", this.VoiceLines[24], (Action) (() => _gameplay.DisplaySubtitle("But don't tell anyone, not even our own", this.VoiceLines[25], (Action) (() =>
    {
      this.LabEntranceDoor.Locked = false;
      this.LabExitDoor.Locked = true;
      this.The2ndDoor.Locked = true;
      person.ThisPersonInt.EndTheChat();
      this.AddGoal(2, true);
    }), person)), person)), person);
  }

  public void Goal3()
  {
    if (!this.LabEntranceDoor.Locked)
      this.EnterLab();
    if (!this.Goals[0].Completed && !this.Goals[1].Completed || this.Goals[2].Completed)
      return;
    this.The2ndDoor.CloseDoor();
    this.The2ndDoor.Locked = true;
    this.LabExitDoor.Locked = true;
    this.CompleteGoal(2);
    UI_Gameplay gameplayMenu = Main.Instance.GameplayMenu;
    Person person = Main.Instance.CityCharacters.Sarah;
    Person merussy = Main.Instance.CityCharacters.Merussy;
    person.AddMoveBlocker("quest");
    person.ThisPersonInt.AddBlocker("quest");
    person.PlaceAt(this.SPOTS[0]);
    person.StartScheduleTask(new Person.ScheduleTask()
    {
      IDName = "SarahGoToSephie",
      RunTo = false,
      ActionPlace = this.SPOTS[2],
      OnArrive = (Action) (() =>
      {
        person.PlaceAt(this.SPOTS[2]);
        Main.Instance.MainThreads.Add(new Action(this.Goal4));
      })
    });
    merussy.PlaceAt(this.SPOTS[1]);
    merussy.State = Person_State.Work;
    merussy.AddMoveBlocker("quest");
    merussy.ThisPersonInt.AddBlocker("quest");
    merussy.CantBeForced = false;
    person.CantBeForced = false;
  }

  public void ExitLab()
  {
    Debug.LogError((object) "ExitLab()");
    Main.Instance.PlayerWakeupPlaces = Main.Instance.OrgPlayerWakeupPlaces;
  }

  public void EnterLab()
  {
    Main.Instance.PlayerWakeupPlaces = new List<Transform>();
    Main.Instance.PlayerWakeupPlaces.Add(this.RespawnSpot);
  }

  public void Goal4()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person sarah = Main.Instance.CityCharacters.Sarah;
    Person sephie = Main.Instance.CityCharacters.Merussy;
    if ((double) Vector3.Distance(Main.Instance.Player.transform.position, Main.Instance.CityCharacters.Sarah.transform.position) >= 2.0)
      return;
    Main.Instance.MainThreads.Remove(new Action(this.Goal4));
    sarah.LookAtPlayer.NonplayerTarget = sephie.Head;
    sephie.LookAtPlayer.NonplayerTarget = sarah.Head;
    Main.Instance.MusicPlayer.volume = 0.5f;
    _gameplay.DisplaySubtitle("Why are you here", this.VoiceLines[1], (Action) (() =>
    {
      sephie.LookAtPlayer.NonplayerTarget = (Transform) null;
      _gameplay.DisplaySubtitle("What the heck I told you to not bring anyone here", this.VoiceLines[2], (Action) (() =>
      {
        sephie.LookAtPlayer.NonplayerTarget = sarah.Head;
        _gameplay.DisplaySubtitle("Yes yes I know, but I found something I have to show you two, in your cave there", this.VoiceLines[26], (Action) (() => _gameplay.DisplaySubtitle("What the fuck where you doing in there!?", this.VoiceLines[3], (Action) (() => _gameplay.DisplaySubtitle("That's not a cave, that's my \"Failed experiements pit\"", this.VoiceLines[4], (Action) (() => _gameplay.DisplaySubtitle("That's where I throw away my worse Bio trash", this.VoiceLines[5], (Action) (() =>
        {
          sephie.LookAtPlayer.NonplayerTarget = (Transform) null;
          _gameplay.DisplaySubtitle("It's the last place in the world you should go look for anything", this.VoiceLines[6], (Action) (() =>
          {
            sephie.LookAtPlayer.NonplayerTarget = sarah.Head;
            _gameplay.DisplaySubtitle("I know I know, But my job is to monitor everything in the city, even the worse trash can", this.VoiceLines[27], (Action) (() =>
            {
              sephie.RemoveMoveBlocker("quest");
              sephie.LookAtPlayer.NonplayerTarget = (Transform) null;
              sarah.LookAtPlayer.NonplayerTarget = (Transform) null;
              sarah.ThisPersonInt.EndTheChat();
              this.AddGoal(3, true);
              _gameplay.DisplaySubtitle("Oh my fucking god", this.VoiceLines[7], new Action(sephie.ThisPersonInt.EndTheChat), sephie);
              sarah.StartScheduleTask(new Person.ScheduleTask()
              {
                IDName = "SarahGoToCaveDoor",
                RunTo = false,
                ActionPlace = this.SPOTS[3],
                OnArrive = (Action) (() =>
                {
                  sarah.PlaceAt(this.SPOTS[3]);
                  Main.Instance.MainThreads.Add(new Action(this.Goal5));
                })
              });
              sephie.StartScheduleTask(new Person.ScheduleTask()
              {
                IDName = "SephieGoToCaveDoor",
                RunTo = false,
                ActionPlace = this.SPOTS[4],
                OnArrive = (Action) (() => { })
              });
            }), sarah);
          }), sephie);
        }), sephie)), sephie)), sephie)), sarah);
      }), sephie);
    }), sephie);
  }

  public void Goal5()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person sarah = Main.Instance.CityCharacters.Sarah;
    Person sephie = Main.Instance.CityCharacters.Merussy;
    if ((double) Vector3.Distance(Main.Instance.Player.transform.position, Main.Instance.CityCharacters.Sarah.transform.position) >= 4.0)
      return;
    Main.Instance.MainThreads.Remove(new Action(this.Goal5));
    this.The2ndDoor.Locked = false;
    this.The2ndDoor.OpenDoor();
    this.The3rdDoor.OpenDoor();
    sarah.ProxSeen.gameObject.SetActive(false);
    sephie.ProxSeen.gameObject.SetActive(false);
    Main.Instance.Player.ProxSeen.gameObject.SetActive(false);
    sarah.StartScheduleTask(new Person.ScheduleTask()
    {
      IDName = "SarahGoToHole",
      RunTo = false,
      ActionPlace = this.SPOTS[5],
      OnArrive = (Action) (() =>
      {
        sarah.PlaceAt(this.SPOTS[5]);
        Main.Instance.MainThreads.Add(new Action(this.Goal6));
      })
    });
    sephie.StartScheduleTask(new Person.ScheduleTask()
    {
      IDName = "SephieGoToHole",
      RunTo = false,
      ActionPlace = this.SPOTS[6],
      OnArrive = (Action) (() => { })
    });
    Main.RunInSeconds((Action) (() => _gameplay.DisplaySubtitle("Just being here we are at a high risk of a serious disease", this.VoiceLines[8], new Action(sephie.ThisPersonInt.EndTheChat), sephie)), 3f);
    sarah.DressClothe(Main.Instance.AllPrefabs[58]);
    sephie.DressClothe(Main.Instance.AllPrefabs[58]);
    (sarah.CurrentHat as HelmetWithLamp).EnableLamp();
    (sephie.CurrentHat as HelmetWithLamp).EnableLamp();
  }

  public void Goal6()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person sarah = Main.Instance.CityCharacters.Sarah;
    Person sephie = Main.Instance.CityCharacters.Merussy;
    if ((double) Vector3.Distance(Main.Instance.Player.transform.position, Main.Instance.CityCharacters.Sarah.transform.position) >= 3.0)
      return;
    this.CompleteGoal(3);
    Main.Instance.MainThreads.Remove(new Action(this.Goal6));
    _gameplay.DisplaySubtitle("Look here, some of your \"bio trash\" has been digging a tunnel", this.VoiceLines[28], (Action) (() =>
    {
      sarah.enabled = false;
      sarah.PlaceAt(this.SPOTS[7]);
      Main.RunInNextFrame((Action) (() => sarah.Anim.Play("Throw1")));
      Main.RunInSeconds((Action) (() =>
      {
        this.Grates.SetParent(sarah.LeftHandStuff);
        this.Grates.localPosition = new Vector3(-0.175f, -0.204f, -0.459f);
        this.Grates.localEulerAngles = new Vector3(348.404877f, 4.12945557f, 89.9118042f);
      }), 1.2f);
      Main.RunInSeconds((Action) (() =>
      {
        this.Grates.SetParent((Transform) null);
        this.Grates.PlaceAt(this.GratesEndSpot);
        Main.Instance.MusicPlayer.PlayOneShot(Main.Instance.SearchTrashSounds[9], 1f);
      }), 2.3f);
      Main.RunInSeconds((Action) (() => sarah.enabled = true), 3.24f);
      _gameplay.DisplaySubtitle("Gladly I was here to block it before they could escape, or worse", this.VoiceLines[29], (Action) (() => _gameplay.DisplaySubtitle("And I also found they actually got somewhere, come inside", this.VoiceLines[30], (Action) (() =>
      {
        Main.RunInNextFrame((Action) (() =>
        {
          sarah.enabled = false;
          sarah.navMesh.enabled = false;
          sarah.PlaceAt(this.SPOTS[8]);
          sarah.Anim.Play("crawl1");
          Main.Instance.MainThreads.Add(new Action(this.Goal7));
        }));
        _gameplay.DisplaySubtitle("This bitch is insane", this.VoiceLines[9], (Action) (() =>
        {
          sarah.ThisPersonInt.EndTheChat();
          this._Said = true;
          this.AddGoal(4, true);
        }), sephie);
      }), sarah)), sarah);
    }), sarah);
  }

  public void Goal7()
  {
    Person sarah = Main.Instance.CityCharacters.Sarah;
    Person merussy = Main.Instance.CityCharacters.Merussy;
    if (!this._Said)
    {
      sarah.PlaceAt(this.SPOTS[8]);
      sarah.transform.LookAt(this.SPOTS[9]);
    }
    else
    {
      sarah.Anim.Play("crawl_10");
      sarah.transform.LookAt(this.SPOTS[9]);
      this._Crawling += Time.deltaTime;
      float t = this._Crawling / this._CrawlingMax;
      sarah.transform.position = Vector3.Lerp(this.SPOTS[8].position, this.SPOTS[9].position, t);
      if ((double) this._Crawling < (double) this._CrawlingMax)
        return;
      sarah.Anim.Play("crawl1");
      this._Crawling = this._CrawlingMax;
      Main.Instance.MainThreads.Remove(new Action(this.Goal7));
      this.HOle.SetActive(true);
      this.AddGoal(4, true);
    }
  }

  public void EnterHole()
  {
    Main.Instance.GameplayMenu.TheScreenFader.FadeOut(2f, new Action(this.EnterHole_2));
  }

  public void EnterHole_2()
  {
    Main.Instance.GameplayMenu.TheScreenFader.FadeIn(1f);
    this.CompleteGoal(4);
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person sarah = Main.Instance.CityCharacters.Sarah;
    Person sephie = Main.Instance.CityCharacters.Merussy;
    sarah.PlaceAt(this.SPOTS[10]);
    sarah.enabled = true;
    sarah.navMesh.enabled = true;
    sephie.navMesh.enabled = false;
    sephie.AddMoveBlocker("aaaaa");
    sephie.PlaceAt(this.SPOTS[11]);
    Main.Instance.Player.PlaceAt(this.SPOTS[12]);
    this.HOle.SetActive(false);
    Main.RunInSeconds((Action) (() => _gameplay.DisplaySubtitle("Come this way, I found some weird ancient technology", this.VoiceLines[31 /*0x1F*/], (Action) (() =>
    {
      sarah.ThisPersonInt.EndTheChat();
      sephie.RemoveMoveBlocker("aaaaa");
      sephie.navMesh.enabled = true;
      sarah.StartScheduleTask(new Person.ScheduleTask()
      {
        IDName = "SarahGoToTrain",
        RunTo = true,
        ActionPlace = this.SPOTS[13],
        OnArrive = (Action) (() =>
        {
          sarah.PlaceAt(this.SPOTS[13]);
          Main.Instance.MainThreads.Add(new Action(this.Goal8));
        })
      });
      sephie.StartScheduleTask(new Person.ScheduleTask()
      {
        IDName = "SephieGoToTrain",
        RunTo = false,
        ActionPlace = this.SPOTS[14],
        OnArrive = (Action) (() =>
        {
          sephie.PlaceAt(this.SPOTS[14]);
          this._SephieArrivedAtTrain = true;
        })
      });
    }), sarah)), 2f);
  }

  public void Goal8()
  {
    Person sarah = Main.Instance.CityCharacters.Sarah;
    if (!this._SephieArrivedAtTrain || (double) Vector3.Distance(Main.Instance.Player.transform.position, sarah.transform.position) >= 3.0)
      return;
    Main.Instance.MainThreads.Remove(new Action(this.Goal8));
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person sephie = Main.Instance.CityCharacters.Merussy;
    _gameplay.DisplaySubtitle("Check it out, what the heck is this huge machine", this.VoiceLines[32 /*0x20*/], (Action) (() => _gameplay.DisplaySubtitle("This is a fucking steam train", this.VoiceLines[10], (Action) (() => _gameplay.DisplaySubtitle("There's nothing \"technology\" about it", this.VoiceLines[11], (Action) (() => _gameplay.DisplaySubtitle("Well it does run on coal instead of electricity, which is kinda convenient right now", this.VoiceLines[12], (Action) (() => _gameplay.DisplaySubtitle("So it is a train after all, and runs only on coal?", this.VoiceLines[33], (Action) (() => _gameplay.DisplaySubtitle("That's amazing!", this.VoiceLines[34], (Action) (() => _gameplay.DisplaySubtitle("Maybe my sweetie here could use it later to find land for a new city", this.VoiceLines[35], (Action) (() => _gameplay.DisplaySubtitle("Oh gawd this connects with the outside, that's a major safety threat", this.VoiceLines[13], (Action) (() => _gameplay.DisplaySubtitle("I have to get War here asap to setup defences", this.VoiceLines[14], (Action) (() => _gameplay.DisplaySubtitle("Let's get out of here now, this dust is what gives you lung cancer", this.VoiceLines[15], (Action) (() => _gameplay.DisplaySubtitle("And Sarah, I really should upgrade your vocal cords, they are starting to sound bad", this.VoiceLines[37], (Action) (() =>
    {
      sarah.ThisPersonInt.EndTheChat();
      this.EndMission();
    }), sephie)), sephie)), sephie)), sephie)), sarah)), sarah)), sarah)), sephie)), sephie)), sephie)), sarah);
  }

  public void EndMission()
  {
    Main.Instance.GameplayMenu.TheScreenFader.FadeOut(2f, new Action(this.EndMission_2));
  }

  public void EndMission_2()
  {
    Main.Instance.GameplayMenu.TheScreenFader.FadeIn(1f);
    this.CompleteGoal(5);
    this.CompleteMission();
    Main.RunInSeconds((Action) (() =>
    {
      (Main.Instance.AllMissions[10] as Mis_Zea1).StartIfItCan();
      Main.Instance.AllMissions[12].InitMission();
    }), 10f);
    Main.Instance.CanSaveFlags_remove("SarahMission");
    Person sarah = Main.Instance.CityCharacters.Sarah;
    Person sephie = Main.Instance.CityCharacters.Merussy;
    sarah.navMesh.enabled = false;
    sarah.State = Person_State.Work;
    sarah.PlaceAt(Vector3.zero);
    sarah.ThisPersonInt.RemoveBlocker("quest");
    sarah.RemoveMoveBlocker("quest");
    sarah.RemoveMoveBlocker("asdasd");
    sephie.navMesh.enabled = false;
    sephie.State = Person_State.Free;
    sephie.PlaceAt(this.SPOTS[3]);
    sephie.ThisPersonInt.RemoveBlocker("quest");
    UnityEngine.Object.Destroy((UnityEngine.Object) sarah.UndressClothe(sarah.CurrentHat));
    UnityEngine.Object.Destroy((UnityEngine.Object) sephie.UndressClothe(sephie.CurrentHat));
    Main.RunInSeconds((Action) (() =>
    {
      sarah.navMesh.enabled = true;
      sarah.enabled = true;
      sephie.navMesh.enabled = true;
      if (!sephie.CurrentTaskIsNull())
        sephie.CompleteScheduleTask();
      else
        sephie.ScheduleDecide();
      sarah.CompleteScheduleTask(false);
      (Main.Instance.AllMissions[1] as Mis_MedTutorial).SarahPatrol.StartPatrol(sarah);
      sarah.ScheduleDecide();
    }), 1f);
    Main.Instance.Player.PlaceAt(this.SPOTS[4]);
    this.LabExitDoor.Locked = false;
    this.LabEntranceDoor.Locked = false;
    Main.Instance.Player.ProxSeen.gameObject.SetActive(true);
  }
}
