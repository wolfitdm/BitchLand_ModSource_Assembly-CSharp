// Decompiled with JetBrains decompiler
// Type: Mis_Army2
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#nullable disable
public class Mis_Army2 : Mission
{
  public AudioClip[] VoiceLines;
  public Mis_Army MisArmy1;
  public Mis_Army2_refs MisRefs;
  public int MissionScene;
  public GameObject MissionPlace;
  public GameObject WindPlace;
  public Int_Drive Truck;
  public GameObject FakeTruck;
  public Transform[] EnterTruckSpots;
  public Interactible driverSeat;
  public Interactible CoSeat;
  public GameObject BriefTrigger;
  public Transform Breifing1_WarSpot;
  public Transform Breifing1_ZeaSpot;
  public Transform Breifing1_Spot1;
  public Transform Breifing1_Spot2;
  public Transform Breifing1_Spot3;
  public Transform Breifing1_PlayerSpot;
  public Person Sia;
  public Person Companion1;
  public Person Companion2;
  public GameObject CompSpawner;
  public Transform DriveStartSpot;
  public BL_MapArea MiddleZoneMusic;
  public BL_MapArea ThirdZoneMusic;
  public Transform ResapwnSpot;
  [Header("-------")]
  public Transform Breifing2_WarSpot;
  public Transform Breifing2_ZeaSpot;
  public Transform Breifing2_Spot1;
  public Transform Breifing2_Spot2;
  public Transform Breifing2_Spot3;
  public Transform Breifing2_PlayerSpot;
  [Header("-------")]
  public Transform Breifing3_WarSpot;
  public Transform Breifing3_ZeaSpot;
  public Transform Breifing3_Spot1;
  public Transform Breifing3_Spot2;
  public Transform Breifing3_Spot3;
  [Header("-------")]
  public GameObject ESBTank;
  public Transform ESBTank_Turret;
  public RayCastShoot ESBTankShoot;
  public RandomNPCHere EsbSpawner;
  [Header("part 2")]
  public Transform StandSpot;
  [Header("part 3")]
  public Transform something;
  public bool DEBUGTESTING;
  public bool HasDoneMiddleChat;
  public bool HasEnteredMiddleArea;
  public Transform EnterTruckPart2Spot;
  public GameObject Trigger1;
  public GameObject Trigger2;
  public GameObject Trigger3;
  public Int_Door HouseDoor;
  public Person TheESB;
  public List<GameObject> SpawnedEsbs = new List<GameObject>();
  public GameObject Bombs;
  public GameObject TankShoot;
  public Transform TankHead;
  public Transform TankCannon;
  public Transform TruckParkSpot;
  public Weapon CarGun;
  public Transform RotateRoot;
  public List<Person> EsbFightings;
  public Person EsbFighting;
  public bl_NPCEnterTrigger SeeField;
  [Header("part 3")]
  public Transform P3_WakeUp;
  public Transform P3_SiaSpot;
  public Transform SiaSpot;

  public void SetComp1(Person person)
  {
    this.Companion1 = person;
    this.Companion1.navMesh.enabled = false;
    this.Companion1.gameObject.SetActive(false);
    this.Companion1.NoEnergyLoss = true;
    this.Companion1.CantBeForced = true;
    this.Companion1.CantBeHit = true;
    this.Companion1.Favor = 10000;
  }

  public void SetComp2(Person person)
  {
    this.Companion2 = person;
    this.Companion2.navMesh.enabled = false;
    this.Companion2.gameObject.SetActive(false);
    this.Companion2.NoEnergyLoss = true;
    this.Companion2.CantBeForced = true;
    this.Companion2.CantBeHit = true;
    this.Companion2.Favor = 10000;
  }

  public override void InitMission()
  {
    Debug.LogError((object) "Mis_Army2 InitMission()");
    base.InitMission();
    this.CurrentGoal = this.Goals[0];
    if (!this.CurrentGoal.Completed)
    {
      this.CompSpawner.SetActive(true);
      Main.RunInNextFrame((Action) (() =>
      {
        this.MisArmy1.War.navMesh.enabled = false;
        this.MisArmy1.War.transform.SetPositionAndRotation(this.Breifing1_WarSpot.position, this.Breifing1_WarSpot.rotation);
        this.MisArmy1.War.AddMoveBlocker("huh?");
        this.Sia = Main.Instance.CityCharacters.Sia;
        if ((UnityEngine.Object) this.Sia.InteractingWith != (UnityEngine.Object) null)
          this.Sia.InteractingWith.StopInteracting();
        this.Sia.State = Person_State.Work;
        this.Sia.CompleteScheduleTask(false);
        this.Sia.navMesh.enabled = false;
        this.Sia.transform.SetPositionAndRotation(this.Breifing1_Spot1.position, this.Breifing1_Spot1.rotation);
        if ((UnityEngine.Object) this.Sia.WeaponInv.CurrentWeapon != (UnityEngine.Object) null)
          this.Sia.WeaponInv.CurrentWeapon.Holdster();
        this.Companion1.transform.SetPositionAndRotation(this.Breifing1_Spot2.position, this.Breifing1_Spot2.rotation);
        this.Companion1.gameObject.SetActive(true);
        this.Companion1.State = Person_State.Work;
        if ((UnityEngine.Object) this.Companion1.WeaponInv.CurrentWeapon != (UnityEngine.Object) null)
          this.Companion1.WeaponInv.CurrentWeapon.Holdster();
        this.Companion2.transform.SetPositionAndRotation(this.Breifing1_Spot3.position, this.Breifing1_Spot3.rotation);
        this.Companion2.gameObject.SetActive(true);
        this.Companion2.State = Person_State.Work;
        if ((UnityEngine.Object) this.Companion2.WeaponInv.CurrentWeapon != (UnityEngine.Object) null)
          this.Companion2.WeaponInv.CurrentWeapon.Holdster();
        this.BriefTrigger.SetActive(true);
        this.MisArmy1.Zea.State = Person_State.Work;
        this.MisArmy1.Zea.StartScheduleTask(new Person.ScheduleTask()
        {
          IDName = "ZeaBrief",
          ActionPlace = this.Breifing1_ZeaSpot,
          OnArrive = (Action) (() => this.MisArmy1.Zea.transform.SetPositionAndRotation(this.Breifing1_ZeaSpot.position, this.Breifing1_ZeaSpot.rotation))
        });
      }), 5);
    }
    else
    {
      this.CurrentGoal = this.Goals[1];
      if (this.CurrentGoal.Completed)
      {
        this.CurrentGoal = this.Goals[2];
        if (this.CurrentGoal.Completed)
        {
          this.CurrentGoal = this.Goals[3];
          if (this.CurrentGoal.Completed)
          {
            this.CurrentGoal = this.Goals[4];
            if (this.CurrentGoal.Completed)
            {
              this.CurrentGoal = this.Goals[5];
              if (this.CurrentGoal.Completed)
              {
                this.CurrentGoal = this.Goals[6];
                if (this.CurrentGoal.Completed)
                {
                  this.CurrentGoal = this.Goals[7];
                  if (this.CurrentGoal.Completed)
                  {
                    this.CurrentGoal = this.Goals[9];
                    if (this.CurrentGoal.Completed)
                    {
                      this.CurrentGoal = this.Goals[10];
                      if (this.CurrentGoal.Completed)
                      {
                        this.CurrentGoal = this.Goals[11];
                        if (this.CurrentGoal.Completed)
                        {
                          this.CurrentGoal = this.Goals[12];
                          if (this.CurrentGoal.Completed)
                          {
                            this.CurrentGoal = this.Goals[13];
                            if (this.CurrentGoal.Completed)
                            {
                              int num = this.CurrentGoal.Failed ? 1 : 0;
                            }
                            this.BriefTrigger.SetActive(false);
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
        }
      }
    }
    if (!this.CompletedMission)
      Main.Instance.GameplayMenu.DisplayGoal(this.CurrentGoal, true);
    else
      Main.RunInSeconds((Action) (() => (Main.Instance.AllMissions[10] as Mis_Zea1).StartIfItCan()), 5f);
  }

  public void EnterTruck1()
  {
    if (this.DEBUGTESTING)
      this.War_TurnOnCar();
    if (!this.Goals[1].Completed)
    {
      this.CompleteGoal(1);
      Main.Instance.MainThreads.Add(new Action(this.WaitForTruckFullThread));
      if (!this.MisArmy1.War.Interacting)
        this.Truck.SitOnSeat(this.MisArmy1.War, 1);
      if (!this.MisArmy1.Zea.Interacting)
        this.Truck.SitOnSeat(this.MisArmy1.Zea, 2);
      if (!Main.Instance.CityCharacters.Sia.Interacting)
        this.Truck.SitOnSeat(this.Sia, 3);
      if ((UnityEngine.Object) this.Companion1 != (UnityEngine.Object) null && !this.Companion1.Interacting)
        this.Truck.SitOnSeat(this.Companion1, 4);
      if ((UnityEngine.Object) this.Companion2 != (UnityEngine.Object) null && !this.Companion2.Interacting)
        this.Truck.SitOnSeat(this.Companion2, 5);
      this.MisArmy1.War.ThisPersonInt.AddBlocker("Quest");
    }
    else
    {
      this.MisArmy1.War.ThisPersonInt.RemoveBlocker("Quest");
      this.Truck.MyRigidbody.isKinematic = false;
      this.CompleteGoal(12);
      this.AddGoal(13, true);
      this.Trigger3.SetActive(true);
      this.ThirdZoneMusic.OnEnter();
      this.CarGun.enabled = true;
      this.CarGun.WeaponAudioSource.enabled = true;
      this.SeeField.transform.parent.gameObject.SetActive(true);
      if (!this.MisArmy1.War.Interacting)
        this.Truck.SitOnSeat(this.MisArmy1.War, 1);
      if (!this.MisArmy1.Zea.Interacting)
        this.Truck.SitOnSeat(this.MisArmy1.Zea, 2);
      if (!this.Sia.Interacting)
        this.Truck.SitOnSeat(this.Sia, 3);
      if (!this.Companion1.Interacting)
        this.Truck.SitOnSeat(this.Companion1, 4);
      if (this.Companion2.Interacting)
        return;
      this.Truck.SitOnSeat(this.Companion2, 5);
    }
  }

  public void WaitForTruckFullThread()
  {
    for (int index = 0; index < this.Truck.PeopleSeated.Length; ++index)
    {
      if ((UnityEngine.Object) this.Truck.PeopleSeated[index] == (UnityEngine.Object) null)
        return;
    }
    Main.Instance.MainThreads.Remove(new Action(this.WaitForTruckFullThread));
    this.War_TurnOnCar();
  }

  public void SpawnMissionPlace()
  {
    Main.Instance.Player.gameObject.SetActive(false);
    Main.Instance.GameplayMenu.SaveButton.interactable = false;
    Main.Instance.GameplayMenu.CantSaveMsg.SetActive(true);
    Main.Instance.NewGameMenu.SmallLoading.SetActive(true);
    Main.RunInNextFrame((Action) (() => SceneManager.LoadScene(this.MissionScene, LoadSceneMode.Additive)), 4);
    Main.Instance.DayCycle.enabled = false;
    Main.Instance.DayCycle.ResetMidday();
  }

  public void AfterLoadingMiss()
  {
    this.MisRefs = UnityEngine.Object.FindObjectOfType<Mis_Army2_refs>();
    this.Bombs = this.MisRefs.Bombs;
    this.DriveStartSpot = this.MisRefs.DriveStartSpot;
    this.ResapwnSpot = this.MisRefs.ResapwnSpot;
    this.Breifing2_WarSpot = this.MisRefs.Breifing2_WarSpot;
    this.Breifing2_ZeaSpot = this.MisRefs.Breifing2_ZeaSpot;
    this.Breifing2_Spot1 = this.MisRefs.Breifing2_Spot1;
    this.Breifing2_Spot2 = this.MisRefs.Breifing2_Spot2;
    this.Breifing2_Spot3 = this.MisRefs.Breifing2_Spot3;
    this.Breifing2_PlayerSpot = this.MisRefs.Breifing2_PlayerSpot;
    this.Breifing3_WarSpot = this.MisRefs.Breifing3_WarSpot;
    this.Breifing3_ZeaSpot = this.MisRefs.Breifing3_ZeaSpot;
    this.Breifing3_Spot1 = this.MisRefs.Breifing3_Spot1;
    this.Breifing3_Spot2 = this.MisRefs.Breifing3_Spot2;
    this.Breifing3_Spot3 = this.MisRefs.Breifing3_Spot3;
    this.ESBTank = this.MisRefs.ESBTank;
    this.EsbSpawner = this.MisRefs.EsbSpawner;
    this.EnterTruckPart2Spot = this.MisRefs.EnterTruckPart2Spot;
    this.Trigger1 = this.MisRefs.Trigger1;
    this.Trigger2 = this.MisRefs.Trigger2;
    this.Trigger3 = this.MisRefs.Trigger3;
    this.HouseDoor = this.MisRefs.HouseDoor;
    this.TankHead = this.MisRefs.TankHead;
    this.TankCannon = this.MisRefs.TankCannon;
    this.TruckParkSpot = this.MisRefs.TruckParkSpot;
    this.Truck.transform.SetPositionAndRotation(this.DriveStartSpot.position, this.DriveStartSpot.rotation);
    this.Truck.MyRigidbody.isKinematic = false;
    Main.Instance.PlayerWakeupPlaces.Clear();
    Main.Instance.PlayerWakeupPlaces.Add(this.ResapwnSpot);
    Main.Instance.NewGameMenu.SmallLoading.SetActive(false);
  }

  public void War_TurnOnCar()
  {
    this.DEBUGTESTING = false;
    Main.Instance.GameplayMenu.DisplaySubtitle("Did you forgot how to turn a car on too?", this.VoiceLines[1], (Action) (() =>
    {
      this.AddGoal(2, true);
      Main.Instance.GameplayMenu.Subtitle.SetActive(false);
      Main.Instance.MainThreads.Add(new Action(this.Goal3));
      if (this.Truck.EngineOn)
        return;
      Main.Instance.GameplayMenu.ShowNotification("Press T to toggle engine");
    }));
  }

  public void ZeaStatueChat()
  {
    Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[5]);
    Main.Instance.GameplayMenu.DisplaySubtitle("Hey War, uhm, you've been looking a bit diferent from your memorial on high street", this.VoiceLines[5], (Action) (() =>
    {
      Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[6]);
      Main.Instance.GameplayMenu.DisplaySubtitle("Your hair's a mess nowdays", this.VoiceLines[6], (Action) (() =>
      {
        Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[7]);
        Main.Instance.GameplayMenu.DisplaySubtitle("I had less things to care about 20 years ago", this.VoiceLines[7], (Action) (() =>
        {
          Main.Instance.GameplayMenu.Subtitle.SetActive(false);
          if (this.HasEnteredMiddleArea && !this.HasDoneMiddleChat)
            this.MiddleZoneMusic.OnEnter();
          this.HasDoneMiddleChat = true;
        }), Main.Instance.CityCharacters.Sarah);
      }), Main.Instance.CityCharacters.Sarah);
    }), Main.Instance.CityCharacters.Sarah);
  }

  public void EnterMiddleArea()
  {
    if (this.HasDoneMiddleChat && !this.HasEnteredMiddleArea)
      this.MiddleZoneMusic.OnEnter();
    this.HasEnteredMiddleArea = true;
  }

  public void BrieffingStart()
  {
    Main.Instance.CanSaveFlags.Add("Quest Army2");
    Main.Instance.GameplayMenu.EnterChatWith(this.MisArmy1.War, (MonoBehaviour) null, (string) null);
    Main.Instance.Player.UserControl.FirstPerson = true;
    this.CompleteGoal(0);
    Main.Instance.GameplayMenu.DisplaySubtitle("Well now that everyone has been here this entire time, and paid attention to the whole plan I just described, let's go.", this.VoiceLines[0], (Action) (() =>
    {
      this.MisArmy1.War.ThisPersonInt.EndTheChat();
      this.AddGoal(1, true);
      this.FakeTruck.SetActive(false);
      this.Truck.gameObject.SetActive(true);
      this.WindPlace.SetActive(false);
      this.MisArmy1.War.ThisPersonInt.EndTheChat();
      this.MisArmy1.War.ThisPersonInt.AddBlocker("Quest");
      this.MisArmy1.War.StartScheduleTask(new Person.ScheduleTask()
      {
        IDName = "WarGoToTruck",
        ActionPlace = this.EnterTruckSpots[0],
        OnArrive = (Action) (() => this.Truck.SitOnSeat(this.MisArmy1.War, 1))
      });
      this.MisArmy1.Zea.ThisPersonInt.AddBlocker("Quest");
      this.MisArmy1.Zea.StartScheduleTask(new Person.ScheduleTask()
      {
        IDName = "ZeaGoToTruck",
        ActionPlace = this.EnterTruckSpots[1],
        OnArrive = (Action) (() => this.Truck.SitOnSeat(this.MisArmy1.Zea, 2))
      });
      this.Sia.ThisPersonInt.AddBlocker("Quest");
      this.Sia.StartScheduleTask(new Person.ScheduleTask()
      {
        IDName = "GoToTruck",
        ActionPlace = this.EnterTruckSpots[1],
        OnArrive = (Action) (() => this.Truck.SitOnSeat(this.Sia, 3))
      });
      this.Companion1.ThisPersonInt.AddBlocker("Quest");
      this.Companion1.StartScheduleTask(new Person.ScheduleTask()
      {
        IDName = "WarGoToTruck",
        ActionPlace = this.EnterTruckSpots[1],
        OnArrive = (Action) (() => this.Truck.SitOnSeat(this.Companion1, 4))
      });
      this.Companion2.ThisPersonInt.AddBlocker("Quest");
      this.Companion2.StartScheduleTask(new Person.ScheduleTask()
      {
        IDName = "WarGoToTruck",
        ActionPlace = this.EnterTruckSpots[1],
        OnArrive = (Action) (() => this.Truck.SitOnSeat(this.Companion2, 5))
      });
    }), this.MisArmy1.War);
  }

  public void Goal3()
  {
    if (!this.Truck.EngineOn)
      return;
    this.CompleteGoal(2);
    Main.Instance.MainThreads.Remove(new Action(this.Goal3));
    this.AddGoal(3, true);
    this.Invoke("FadeToBlack", 1f);
  }

  public void FadeToBlack()
  {
    Main.Instance.GameplayMenu.TheScreenFader.FadeOut(4f, (Action) (() =>
    {
      this.SpawnMissionPlace();
      this.Unfade();
    }));
  }

  public void Unfade()
  {
    Main.Instance.GameplayMenu.TheScreenFader.FadeIn(1f);
    Main.RunInSeconds(new Action(this.WarTalkInCar1), 4f);
    Main.RunInSeconds(new Action(this.WarTalkInCar2), 50f);
  }

  public void WarTalkInCar1()
  {
    Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[3]);
    Main.Instance.GameplayMenu.DisplaySubtitle("Obviously since this is an old vehicle, the brakes don't work very well, so use the handbrake instead", this.VoiceLines[3], (Action) (() =>
    {
      Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[4]);
      Main.Instance.GameplayMenu.DisplaySubtitle("in case you'll need it", this.VoiceLines[4], (Action) (() =>
      {
        Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[8]);
        Main.Instance.GameplayMenu.DisplaySubtitle("Also, this truck sucks, so slow down before doing turns, unless you want to get us killed", this.VoiceLines[8], (Action) (() => Main.Instance.GameplayMenu.Subtitle.SetActive(false)), Main.Instance.CityCharacters.Sarah);
      }), Main.Instance.CityCharacters.Sarah);
    }), Main.Instance.CityCharacters.Sarah);
  }

  public void WarTalkInCar2()
  {
    Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[2]);
    Main.Instance.GameplayMenu.DisplaySubtitle("There's a chance we might find enemy forces until there, if you see them, don't go straight at them", this.VoiceLines[2], (Action) (() => this.ZeaStatueChat()), Main.Instance.CityCharacters.Sarah);
  }

  public void EnterTrigger1()
  {
    this.CompleteGoal(3);
    this.AddGoal(4, true);
  }

  public void HouseDoorOpened()
  {
    if (this.HouseDoor.Locked || !this.Goals[6].Completed || this.Goals[7].Completed)
      return;
    this.CompleteGoal(7);
    this.AddGoal(8, true);
    this.AddGoal(9, true);
    Main.Instance.MainThreads.Add(new Action(this.Goal8_9Check));
    this.Truck.transform.position = this.TruckParkSpot.transform.position;
    this.Truck.transform.rotation = this.TruckParkSpot.transform.rotation;
  }

  public void Goal8_9Check()
  {
    if (this.TheESB.TheHealth.dead)
    {
      this.FailGoal(8);
      this.FailGoal(9);
    }
    else
    {
      if (!this.TheESB.TheHealth.Incapacitated)
        return;
      this.CompleteGoal(8);
      this.CompleteGoal(9);
    }
    this.AddGoal(10, true);
    Main.Instance.MainThreads.Remove(new Action(this.Goal8_9Check));
    Main.Instance.MainThreads.Add(new Action(this.Goal10));
    Main.Instance.MainThreads.Add(new Action(this.Goal11));
  }

  public void ESBSpawn(Person esb)
  {
    this.TheESB = esb;
    esb.Personality = Personality_Type.Broken;
    esb.PersonalityData = Main.Instance.Personalities[4];
    esb.ThisPersonInt.AddBlocker("Quest");
    if (esb.Favor < 25)
      esb.Favor = 25;
    this.SpawnedEsbs.Add(esb.gameObject);
  }

  public void ESBSpawn2(Person esb)
  {
    esb.LOD.enabled = false;
    esb.LodRen.gameObject.SetActive(false);
    esb.SetLowLod();
    esb.CombatDistance = 2500f;
    esb._ShootBlind = true;
    esb.StartFighting(this.Truck.transform.Find("Collider").GetComponent<Person>());
    this.SpawnedEsbs.Add(esb.gameObject);
  }

  public void Goal10()
  {
    if (!Main.Instance.Player.Interacting || !((UnityEngine.Object) Main.Instance.Player.InteractingWith.GetComponent<int_Dragable>() != (UnityEngine.Object) null))
      return;
    this.CompleteGoal(10);
    this.AddGoal(11, true);
    if (!Main.Instance.MainThreads.Contains(new Action(this.Goal10)))
      return;
    Main.Instance.MainThreads.Remove(new Action(this.Goal10));
  }

  public void Goal11()
  {
    if ((double) Main.Instance.Player.transform.position.z > -4249.0)
      return;
    if (Main.Instance.MainThreads.Contains(new Action(this.Goal10)))
    {
      this.CompleteGoal(10);
      Main.Instance.MainThreads.Remove(new Action(this.Goal10));
    }
    this.CompleteGoal(11);
    this.AddGoal(12, true);
    Main.Instance.MainThreads.Remove(new Action(this.Goal11));
    Main.RunInSeconds(new Action(this.WarTrap), 1f);
  }

  public void WarTrap()
  {
    this.Bombs.SetActive(true);
    Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[20]);
    Main.Instance.GameplayMenu.DisplaySubtitle("It's a trap!", this.VoiceLines[20], (Action) (() => Main.Instance.GameplayMenu.Subtitle.SetActive(false)), Main.Instance.CityCharacters.Sarah);
    this.Truck.RemoveBlocker("quest");
    this.MisArmy1.War.StartScheduleTask(new Person.ScheduleTask()
    {
      IDName = "WarGoToTruck",
      RunTo = true,
      ActionPlace = this.EnterTruckPart2Spot,
      OnArrive = (Action) (() => this.Truck.SitOnSeat(this.MisArmy1.War, 1))
    });
    this.MisArmy1.Zea.StartScheduleTask(new Person.ScheduleTask()
    {
      IDName = "ZeaGoToTruck",
      RunTo = true,
      ActionPlace = this.EnterTruckPart2Spot,
      OnArrive = (Action) (() => this.Truck.SitOnSeat(this.MisArmy1.Zea, 2))
    });
    this.Sia.StartScheduleTask(new Person.ScheduleTask()
    {
      IDName = "GoToTruck",
      RunTo = true,
      ActionPlace = this.EnterTruckPart2Spot,
      OnArrive = (Action) (() => this.Truck.SitOnSeat(this.Sia, 3))
    });
    this.Companion1.StartScheduleTask(new Person.ScheduleTask()
    {
      IDName = "WarGoToTruck",
      RunTo = true,
      ActionPlace = this.EnterTruckPart2Spot,
      OnArrive = (Action) (() => this.Truck.SitOnSeat(this.Companion1, 4))
    });
    this.Companion2.StartScheduleTask(new Person.ScheduleTask()
    {
      IDName = "WarGoToTruck",
      RunTo = true,
      ActionPlace = this.EnterTruckPart2Spot,
      OnArrive = (Action) (() => this.Truck.SitOnSeat(this.Companion2, 5))
    });
  }

  public void EnterTrigger2()
  {
    this.CompleteGoal(4);
    this.AddGoal(5, true);
    this.Truck.MyRigidbody.isKinematic = true;
    this.Truck.transform.localEulerAngles = new Vector3(0.0f, this.Truck.transform.localEulerAngles.y, 0.0f);
    Main.Instance.MainThreads.Add(new Action(this.ExitTruckThread));
    Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[9]);
    Main.Instance.GameplayMenu.DisplaySubtitle("I'm suprised all of us got here alive, with that driving of your's", this.VoiceLines[9], (Action) (() => Main.Instance.GameplayMenu.Subtitle.SetActive(false)), Main.Instance.CityCharacters.Sarah);
    this.MisArmy1.War.MoveBlockers.Clear();
    this.MisArmy1.War.StartScheduleTask(new Person.ScheduleTask()
    {
      IDName = "WarGoToLine",
      ActionPlace = this.Breifing2_WarSpot,
      OnArrive = (Action) (() =>
      {
        this.MisArmy1.War.transform.position = this.Breifing2_WarSpot.position;
        this.MisArmy1.War.transform.rotation = this.Breifing2_WarSpot.rotation;
        Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[10]);
        Main.Instance.GameplayMenu.DisplaySubtitle("This is an enemy radio station", this.VoiceLines[10], (Action) (() =>
        {
          Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[11]);
          Main.Instance.GameplayMenu.DisplaySubtitle("We must disable it, and make preperations to take it", this.VoiceLines[11], (Action) (() =>
          {
            Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[12]);
            Main.Instance.GameplayMenu.DisplaySubtitle("This much equipment is precious to us", this.VoiceLines[12], (Action) (() =>
            {
              Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[13]);
              Main.Instance.GameplayMenu.DisplaySubtitle("Before that", this.VoiceLines[13], (Action) (() =>
              {
                Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[14]);
                Main.Instance.GameplayMenu.DisplaySubtitle("Inside this house there is a fearing ESB hiding", this.VoiceLines[14], (Action) (() =>
                {
                  Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[15]);
                  Main.Instance.GameplayMenu.DisplaySubtitle("Make no mistake. Any ESB is always a danger that can kill us", this.VoiceLines[15], (Action) (() =>
                  {
                    Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[16]);
                    Main.Instance.GameplayMenu.DisplaySubtitle("Surround the house, and one of you volunteer to enter it", this.VoiceLines[16], (Action) (() =>
                    {
                      Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[17]);
                      Main.Instance.GameplayMenu.DisplaySubtitle("Once inside, Capture this ESB", this.VoiceLines[17], (Action) (() =>
                      {
                        Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[18]);
                        Main.Instance.GameplayMenu.DisplaySubtitle("We shall turn them into a new citizen for our great civilization", this.VoiceLines[18], (Action) (() =>
                        {
                          Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[19]);
                          Main.Instance.GameplayMenu.DisplaySubtitle("Today our enemy. Tomorrow our companion.", this.VoiceLines[19], (Action) (() =>
                          {
                            Main.Instance.GameplayMenu.Subtitle.SetActive(false);
                            Main.Instance.CityCharacters.War.transform.LookAt(this.HouseDoor.transform.position);
                            Main.Instance.CityCharacters.War.transform.localEulerAngles = new Vector3(0.0f, Main.Instance.CityCharacters.War.transform.localEulerAngles.y, 0.0f);
                            this.HouseDoor.Locked = false;
                            this.EsbSpawner.Start();
                            this.MisArmy1.Zea.WeaponInv.SetActiveWeapon(0);
                            this.Sia.WeaponInv.SetActiveWeapon(0);
                            this.Companion1.WeaponInv.SetActiveWeapon(0);
                            this.Companion2.WeaponInv.SetActiveWeapon(0);
                            this.CompleteGoal(6);
                            this.AddGoal(7, true);
                            this.MisArmy1.Zea.StartScheduleTask(new Person.ScheduleTask()
                            {
                              IDName = "asdasd",
                              ActionPlace = this.Breifing3_ZeaSpot,
                              RunTo = true,
                              OnArrive = (Action) (() => this.MisArmy1.Zea.transform.LookAt(this.EsbSpawner.transform))
                            });
                            this.Sia.StartScheduleTask(new Person.ScheduleTask()
                            {
                              IDName = "GoToLine",
                              ActionPlace = this.Breifing3_Spot1,
                              OnArrive = (Action) (() => this.Sia.transform.LookAt(this.EsbSpawner.transform))
                            });
                            this.Companion1.StartScheduleTask(new Person.ScheduleTask()
                            {
                              IDName = "WarGoToLine",
                              ActionPlace = this.Breifing3_Spot2,
                              RunTo = true,
                              OnArrive = (Action) (() => this.Companion1.transform.LookAt(this.EsbSpawner.transform))
                            });
                            this.Companion2.StartScheduleTask(new Person.ScheduleTask()
                            {
                              IDName = "WarGoToLine",
                              ActionPlace = this.Breifing3_Spot3,
                              RunTo = true,
                              OnArrive = (Action) (() => this.Companion2.transform.LookAt(this.EsbSpawner.transform))
                            });
                          }), Main.Instance.CityCharacters.War);
                        }), Main.Instance.CityCharacters.War);
                      }), Main.Instance.CityCharacters.War);
                    }), Main.Instance.CityCharacters.War);
                  }), Main.Instance.CityCharacters.War);
                }), Main.Instance.CityCharacters.War);
              }), Main.Instance.CityCharacters.War);
            }), Main.Instance.CityCharacters.War);
          }), Main.Instance.CityCharacters.War);
        }), Main.Instance.CityCharacters.War);
      })
    });
    this.MisArmy1.Zea.StartScheduleTask(new Person.ScheduleTask()
    {
      IDName = "ZeaGoToLine",
      ActionPlace = this.Breifing2_ZeaSpot,
      RunTo = true,
      OnArrive = (Action) (() =>
      {
        this.MisArmy1.Zea.WeaponInv.SetActiveWeapon(1);
        this.Breifing2_ZeaSpot.GetComponentInChildren<int_basicSit>().Interact(this.MisArmy1.Zea);
      })
    });
    this.Sia.StartScheduleTask(new Person.ScheduleTask()
    {
      IDName = "GoToLine",
      ActionPlace = this.Breifing2_Spot1,
      OnArrive = (Action) (() =>
      {
        this.Sia.WeaponInv.SetActiveWeapon(1);
        this.Breifing2_Spot1.GetComponentInChildren<int_basicSit>().Interact(this.Sia);
      })
    });
    this.Companion1.StartScheduleTask(new Person.ScheduleTask()
    {
      IDName = "WarGoToLine",
      ActionPlace = this.Breifing2_Spot2,
      RunTo = true,
      OnArrive = (Action) (() =>
      {
        this.Companion1.WeaponInv.SetActiveWeapon(1);
        this.Breifing2_Spot2.GetComponentInChildren<int_basicSit>().Interact(this.Companion1);
      })
    });
    this.Companion2.StartScheduleTask(new Person.ScheduleTask()
    {
      IDName = "WarGoToLine",
      ActionPlace = this.Breifing2_Spot3,
      RunTo = true,
      OnArrive = (Action) (() =>
      {
        this.Companion2.WeaponInv.SetActiveWeapon(1);
        this.Breifing2_Spot3.GetComponentInChildren<int_basicSit>().Interact(this.Companion2);
      })
    });
  }

  public void ExitTruckThread()
  {
    if (!Input.GetKeyUp(KeyCode.Q))
      return;
    this.Truck.transform.position = this.TruckParkSpot.transform.position;
    this.Truck.transform.rotation = this.TruckParkSpot.transform.rotation;
    Main.Instance.MainThreads.Remove(new Action(this.ExitTruckThread));
    this.CompleteGoal(5);
    this.AddGoal(6, true);
    for (int index = 0; index < this.Truck.PeopleSeated.Length; ++index)
      this.Truck.StopInteracting(this.Truck.PeopleSeated[index]);
    this.Truck.AddBlocker("quest");
    Main.Instance.Player.UserControl.ResetSpot = Main.Instance.CityCharacters.War.transform;
  }

  public void TankLookAt()
  {
    this.TankHead.LookAt(this.Truck.transform);
    this.TankHead.localEulerAngles = new Vector3(0.0f, this.TankHead.localEulerAngles.y, 0.0f);
    this.TankCannon.LookAt(this.Truck.transform);
    this.TankCannon.localEulerAngles = new Vector3(this.TankCannon.localEulerAngles.x, 0.0f, 0.0f);
  }

  public void EnterTrigger3()
  {
    Main.Instance.MainThreads.Add(new Action(this.TankLookAt));
    this.ESBTank.SetActive(true);
    Main.Instance.MusicPlayer.pitch = 1f;
    Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[21]);
    Main.Instance.GameplayMenu.DisplaySubtitle("Tank ahead!", this.VoiceLines[21], (Action) (() =>
    {
      Main.Instance.GameplayMenu.Subtitle.SetActive(false);
      Main.RunInSeconds((Action) (() =>
      {
        this.FailGoal(13, true);
        this.TankShoot.SetActive(true);
        Main.Instance.MainThreads.Remove(new Action(this.TankLookAt));
        Main.Instance.Default_Area.OnEnter();
        Main.Instance.Player.UserControl.ResetSpot = Main.Instance.Player.UserControl.OriginalResetSpot;
        Main.Instance.MusicPlayer.pitch = 1f;
        Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[22]);
        Main.Instance.GameplayMenu.TheScreenFader.FadeOut(1f, (Action) (() =>
        {
          SceneManager.UnloadSceneAsync(2);
          Main.Instance.PlayerWakeupPlaces.Clear();
          Main.Instance.PlayerWakeupPlaces.AddRange((IEnumerable<Transform>) Main.Instance.OrgPlayerWakeupPlaces);
          this.Truck.transform.position = Vector3.zero;
          for (int index = 0; index < this.Truck.PeopleSeated.Length; ++index)
          {
            if ((UnityEngine.Object) this.Truck.PeopleSeated[index] != (UnityEngine.Object) null)
              this.Truck.StopInteracting(this.Truck.PeopleSeated[index]);
          }
          this.Companion1.gameObject.SetActive(false);
          this.Companion2.gameObject.SetActive(false);
          Main.Instance.CityCharacters.War.transform.position = Main.Instance.CityCharacters.WarPos;
          Main.Instance.CityCharacters.Zea.transform.position = Main.Instance.CityCharacters.ZeaPos;
          Main.Instance.CityCharacters.War.StopFighting(false);
          Main.Instance.CityCharacters.Zea.StopFighting(false);
          Main.Instance.CityCharacters.Sia.StopFighting(false);
          Main.Instance.CityCharacters.War.CurrentScheduleTask = (Person.ScheduleTask) null;
          Main.Instance.CityCharacters.Zea.CurrentScheduleTask = (Person.ScheduleTask) null;
          Main.Instance.CityCharacters.Sia.CurrentScheduleTask = (Person.ScheduleTask) null;
          Main.Instance.CityCharacters.War.SetDestination(Main.Instance.CityCharacters.War.transform.position);
          Main.Instance.CityCharacters.Zea.SetDestination(Main.Instance.CityCharacters.Zea.transform.position);
          Main.Instance.CityCharacters.Sia.SetDestination(Main.Instance.CityCharacters.Sia.transform.position);
          Main.Instance.CityCharacters.War.Do_Schedule_GoingToTargetThread = false;
          Main.Instance.CityCharacters.Zea.Do_Schedule_GoingToTargetThread = false;
          Main.Instance.CityCharacters.Sia.Do_Schedule_GoingToTargetThread = false;
          for (int index = 0; index < this.SpawnedEsbs.Count; ++index)
          {
            if ((UnityEngine.Object) this.SpawnedEsbs[index] != (UnityEngine.Object) null)
              this.SpawnedEsbs[index].SetActive(false);
          }
          this.Truck.gameObject.SetActive(false);
          this.FakeTruck.SetActive(true);
          this.StartPart3();
        }));
      }), 3f);
    }), Main.Instance.CityCharacters.Sarah);
  }

  public void CanSeeESBS()
  {
    if ((UnityEngine.Object) this.EsbFighting == (UnityEngine.Object) null)
      Main.Instance.MainThreads.Remove(new Action(this.CanSeeESBS));
    else if (this.EsbFighting.TheHealth.dead || this.EsbFighting.TheHealth.Incapacitated || !this.EsbFighting.gameObject.activeInHierarchy)
    {
      this.EsbFightings.Remove(this.EsbFighting);
      if (this.EsbFightings.Count == 0)
      {
        this.EsbFighting = (Person) null;
        Main.Instance.MainThreads.Remove(new Action(this.CanSeeESBS));
      }
      else
        this.EsbFighting = this.EsbFightings[0];
    }
    else
    {
      this.RotateRoot.LookAt(this.EsbFighting.Torso.transform);
      this.CarGun.AIFiring();
    }
  }

  public void NPC_SEE()
  {
    if (!((UnityEngine.Object) this.SeeField.LatestInteraction != (UnityEngine.Object) null) || (UnityEngine.Object) this.SeeField.LatestInteraction.PersonType != (UnityEngine.Object) Main.Instance.PersonTypes[1] || this.EsbFightings.Contains(this.SeeField.LatestInteraction))
      return;
    this.EsbFightings.Add(this.SeeField.LatestInteraction);
    if (!((UnityEngine.Object) this.EsbFighting == (UnityEngine.Object) null))
      return;
    this.EsbFighting = this.SeeField.LatestInteraction;
    Main.Instance.MainThreads.Add(new Action(this.CanSeeESBS));
  }

  public void NPC_NOSEE()
  {
    if (!((UnityEngine.Object) this.SeeField.LatestInteraction != (UnityEngine.Object) null) || !this.EsbFightings.Contains(this.SeeField.LatestInteraction))
      return;
    this.EsbFightings.Remove(this.SeeField.LatestInteraction);
    if (this.EsbFightings.Count == 0)
    {
      this.EsbFighting = (Person) null;
      Main.Instance.MainThreads.Remove(new Action(this.CanSeeESBS));
    }
    else
      this.EsbFighting = this.EsbFightings[0];
  }

  public void StartPart3() => this.Invoke("StartPart3_3", 2f);

  public void StartPart3_3()
  {
    this.FailGoal(13);
    Main.Instance.GameplayMenu.TheScreenFader.FadeIn(3f);
    Main.Instance.Player.transform.position = this.P3_WakeUp.position;
    Main.Instance.Player.transform.rotation = this.P3_WakeUp.rotation;
    if ((UnityEngine.Object) this.Sia != (UnityEngine.Object) null)
    {
      this.Sia.transform.position = this.P3_SiaSpot.position;
      this.Sia.transform.rotation = this.P3_SiaSpot.rotation;
      this.Sia.AddMoveBlocker("EvaRef");
      this.Sia.Masturbating = true;
    }
    Main.Instance.Player.Energy = 0.0f;
    Main.Instance.Player.SleepOnFloor();
    Main.Instance.GameplayMenu.SleepMenu.SetActive(false);
    this.Invoke("StartPart3_2", 3f);
  }

  public void StartPart3_2()
  {
    if ((UnityEngine.Object) this.Sia == (UnityEngine.Object) null)
    {
      Main.Instance.GameplayMenu.SaveButton.interactable = true;
      Main.Instance.GameplayMenu.CantSaveMsg.SetActive(false);
      this.CompleteMission();
      Main.RunInSeconds((Action) (() => (Main.Instance.AllMissions[10] as Mis_Zea1).StartIfItCan()), 10f);
    }
    else
    {
      Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[23]);
      Main.Instance.GameplayMenu.DisplaySubtitle("You woke up", this.VoiceLines[23], (Action) (() =>
      {
        Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[24]);
        Main.Instance.GameplayMenu.DisplaySubtitle("Just as I was about to make an eva reference", this.VoiceLines[24], (Action) (() =>
        {
          Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[25]);
          Main.Instance.GameplayMenu.DisplaySubtitle("Guess I'll do it anyway~", this.VoiceLines[25], (Action) (() =>
          {
            this.Sia.Orgasm();
            this.Sia.Masturbating = false;
            Main.Instance.GameplayMenu.Subtitle.SetActive(false);
            this.Sia.RemoveMoveBlocker("EvaRef");
            this.Sia.State = Person_State.Work;
            Main.Instance.GameplayMenu.SleepMenu.SetActive(true);
            this.MisArmy1.Zea.ThisPersonInt.RemoveBlocker("Quest");
            this.MisArmy1.War.ThisPersonInt.RemoveBlocker("Quest");
            this.Sia.ThisPersonInt.RemoveBlocker("Quest");
            Main.Instance.GameplayMenu.SaveButton.interactable = true;
            Main.Instance.GameplayMenu.CantSaveMsg.SetActive(false);
            this.CompleteMission();
            Main.Instance.CanSaveFlags.Remove("Quest Army2");
            Main.Instance.CanSaveFlags = Main.Instance.CanSaveFlags;
            this.Sia.StartScheduleTask(new Person.ScheduleTask()
            {
              IDName = "asdasd",
              ActionPlace = this.SiaSpot,
              OnArrive = (Action) (() =>
              {
                this.SiaSpot.GetComponent<Interactible>().Interact(this.Sia);
                this.Sia.WorkJob._StartWorkFor(this.Sia);
              })
            });
            Main.RunInSeconds((Action) (() =>
            {
              if ((Main.Instance.AllMissions[10] as Mis_Zea1).MissionCanStart())
              {
                (Main.Instance.AllMissions[10] as Mis_Zea1).StartIfItCan();
              }
              else
              {
                if (Main.Instance.AllMissions[3].Goals[0].Completed)
                  return;
                Main.Instance.GameplayMenu.DisplayGoal(Main.Instance.AllMissions[16].Goals[0], true);
              }
            }), 10f);
            Main.Instance.SaveGame(true);
            Main.Instance.GameplayMenu.ShowNotification("Autosaved");
          }), this.Sia);
        }), this.Sia);
      }), this.Sia);
    }
  }
}
