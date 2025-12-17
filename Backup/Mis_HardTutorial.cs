// Decompiled with JetBrains decompiler
// Type: Mis_HardTutorial
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

#nullable disable
public class Mis_HardTutorial : Mission
{
  public Int_Door CellDoor;
  public Int_Door SexChairCellDoor;
  public RandomNPCHere TempGuard_Spawn;
  public RandomNPCHere SecondGuard_Spawn;
  public RandomNPCHere FirstGuard_Spawn;
  public Person FirstGuard;
  public Person TempGuard;
  public Transform FrontOfPlayerCell;
  public Transform MineEntrancePlace;
  public Transform DancingPlace;
  public Transform SexChairPlace;
  public AudioClip[] VoiceLines;
  public AudioClip[] VoiceLinesMines;
  public AudioClip[] VoiceLinesTraining;
  public AudioClip[] VoiceLinesDance;
  public AudioClip[] VoiceLines_Greeting;
  public AudioClip[] VoiceLines_Yesterday;
  public AudioClip[] VoiceLines_Today;
  public AudioClip[] VoiceLines_Feed;
  public Transform PPDoorSpot;
  public Transform PPDoorStandSpot;
  public Transform PPDoorPlayerSpot;
  public Transform PPDoorGuardAfterSpot;
  public Mis_Mines MineMission;
  public Mis_Dance DanceMission;
  public Mis_Sex SexMission;
  [Header(" -- Day")]
  public List<Person> SpawnedPrisioners_day = new List<Person>();
  public List<Person> SpawnedPrisioners_night = new List<Person>();
  public List<Person> SpawnedGuards = new List<Person>();
  public List<GameObject> EnabledeAtNight = new List<GameObject>();
  [Header(" -- sex")]
  public Int_SexMachine SexChair;
  public GameObject Day4DisableAfter;
  public GameObject Day4Stuff;
  public Interactible[] SuckDildos;
  public int_DildoPole PlayerDildo;
  [Header(" -- dance")]
  public Interactible Couch;
  public Transform ResetPosition;
  public Transform ResetPosition_Default;
  public Transform ResetPosition_Dance;
  public bool WaitingToCloseJournal;
  public float FeedTimer;
  public Interactible[] Poles;
  public GameObject OfficerHat;
  [Header("Punishment")]
  public Interactible int_Punishment;
  public Interactible NightPunishment;
  public Transform PlayerCellSexSpot;
  public Transform GuardSpotOutsideCellNewDay;
  public Person PunishmentDummy;
  public bl_LocalLOD UpperFloor;
  public int _PickedOption;
  public int _PreviousChoice;
  public int _CurrentDay;
  public Action Call_AfterSucc;
  public bl_HangZone PlayerCell;
  public Transform Day4GuardWaitSpot;
  public GameObject NonRemoveGag;
  public SpawnedSexScene TransferedSex;
  public Transform tempguarddes;
  public bl_HangZone _prevZone;

  public void ResetPlayer() => Main.Instance.Player.PlaceAt(this.ResetPosition);

  public override void InitMission()
  {
    base.InitMission();
    Main.Instance.Player.States[26] = true;
    if (!Main.Instance.LoadedGame)
    {
      Main.Instance.ActionWhenPplSpawn((Action) (() => Main.RunInNextFrame((Action) (() =>
      {
        this.FirstGuard = this.FirstGuard_Spawn.PersonGenerated;
        this.FirstGuard.CantBeForced = true;
        this.FirstGuard.CantBeHit = true;
        this.FirstGuard.NoEnergyLoss = true;
        Main.Instance.GlobalVars.Set("Hard_FirstGuard", this.FirstGuard.WorldSaveID);
      }), 2)));
    }
    else
    {
      if (Main.Instance.GlobalVars.ContainsKey("Hard_FirstGuard"))
      {
        string globalVar = Main.Instance.GlobalVars["Hard_FirstGuard"];
        for (int index = 0; index < Main.Instance.SpawnedPeople.Count; ++index)
        {
          if (Main.Instance.SpawnedPeople[index].WorldSaveID == globalVar)
          {
            this.FirstGuard = Main.Instance.SpawnedPeople[index];
            this.FirstGuard.HasCondomPut = true;
            this.FirstGuard.CantBeForced = true;
            this.FirstGuard.CantBeHit = true;
            this.FirstGuard.NoEnergyLoss = true;
            break;
          }
        }
      }
      if (Main.Instance.NewGameMenu.DificultySelected == 3)
      {
        for (int index = 0; index < Main.Instance.SpawnedPeople.Count; ++index)
        {
          string Key1 = "Hardmode_DayNPC_" + Main.Instance.SpawnedPeople[index].WorldSaveID;
          if (Main.Instance.GlobalVars.GetKeyIndex(Key1) == -1)
          {
            string Key2 = "Hardmode_NightNPC_" + Main.Instance.SpawnedPeople[index].WorldSaveID;
            if (Main.Instance.GlobalVars.GetKeyIndex(Key2) != -1)
              this.AddToNightCaptured(Main.Instance.SpawnedPeople[index]);
          }
          else
            this.AddToDayCaptured(Main.Instance.SpawnedPeople[index]);
        }
      }
    }
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
            this.CellDoor.Locked = false;
            if (Main.Instance.GlobalVars.ContainsKey("HardMode_CurrentDay"))
              this.CurrentDay = int.Parse(Main.Instance.GlobalVars["HardMode_CurrentDay"]);
            if (Main.Instance.GlobalVars.ContainsKey("HardMode_PreviousChoice"))
              this.PreviousChoice = int.Parse(Main.Instance.GlobalVars["HardMode_PreviousChoice"]);
            if (Main.Instance.GlobalVars.ContainsKey("HardMode_PickedOption"))
              this.PickedOption = int.Parse(Main.Instance.GlobalVars["HardMode_PickedOption"]);
            this.CurrentGoal = this.Goals[4];
            if (!this.CurrentGoal.Completed)
            {
              if (this.CurrentDay >= 3)
              {
                this.Day4Stuff.SetActive(true);
                this.SexMission.SecondTime = true;
                this.DanceMission.SecondTime = true;
                this.MineMission.SecondTime = true;
              }
              this.HandlePickedOption();
            }
            else
            {
              this.CompletedMission = true;
              return;
            }
          }
        }
      }
    }
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
      Main.Instance.CanSaveFlags_add("HardQuest1");
      this.FirstGuard = this.FirstGuard_Spawn.PersonGenerated;
      Main.Instance.GlobalVars.Set("Hard_FirstGuard", this.FirstGuard.WorldSaveID);
      this.FirstGuard.ThisPersonInt.AddBlocker("HardQuest1");
      this.FirstGuard.Personality = Personality_Type.Casual;
      this.FirstGuard.PersonalityData = Main.Instance.Personalities[0];
      this.FirstGuard.PersonalityData.OnSpawn(this.FirstGuard);
      if (this.FirstGuard is Girl)
      {
        ((Girl) this.FirstGuard).PregnancyPercent = 0.0f;
        ((Girl) this.FirstGuard).Futa = true;
        ((Girl) this.FirstGuard).GirlPhysics = false;
      }
      this.FirstGuard.CantBeForced = true;
      this.FirstGuard.CantBeHit = true;
      this.FirstGuard.NoEnergyLoss = true;
      this.FirstGuard.navMesh.speed = 1f;
      this.FirstGuard.WeaponInv.SetActiveWeapon(1);
      this.FirstGuard.Penis.transform.localScale = new Vector3(3f, 3f, 3f);
      this.FirstGuard.HasPenis = true;
      this.FirstGuard.Fertility = 0.0f;
      this.FirstGuard.StoryModeFertility = 1f;
      this.FirstGuard.PutPenis();
      this.FirstGuard.HasCondomPut = true;
      this.FirstGuard.Energy = this.FirstGuard.EnergyMax;
      this.FirstGuard.Fetishes.Clear();
      this.FirstGuard.Fetishes.Add(e_Fetish.Machine);
      this.FirstGuard.Fetishes.Add(e_Fetish.Sadist);
      this.FirstGuard.Fetishes.Add(e_Fetish.Clean);
      this.FirstGuard.StartScheduleTask(new Person.ScheduleTask()
      {
        IDName = "1",
        ActionPlace = this.PPDoorStandSpot,
        OnArrive = (Action) (() =>
        {
          Main.Instance.OpenMenu("Gameplay");
          Main.Instance.GameplayMenu.EnterChatWith(this.FirstGuard, (MonoBehaviour) this, "Chat1");
        })
      });
    }
  }

  public void Goal5()
  {
    this.FeedTimer -= Time.deltaTime;
    Main.Instance.GameplayMenu.WeaponReloadSlider.fillAmount = this.FeedTimer / 20f;
    if ((double) this.FeedTimer >= 0.0)
      return;
    Main.Instance.GameplayMenu.WeaponReloadUI.SetActive(false);
    Main.Instance.GameplayMenu.WeaponReloadUI.transform.SetParent(Main.Instance.GameplayMenu.transform);
    Main.Instance.MainThreads.Remove(new Action(this.Goal5));
    Main.Instance.SexScene.EndSexScene();
    this.CellDoor.ScriptToRun_OnInteract = new MonoBehaviour[0];
    this.CellDoor.ScriptFunctionToRun_OnInteract = new string[0];
    this.CellDoor.InteractText = "Open";
    this.CellDoor.Locked = false;
    this.CellDoor.Locked = true;
    this.Chat1_aftersucc();
  }

  public void FeedingTime()
  {
    Main.Instance.SexScene.SpawnSexScene(2, 3, this.FirstGuard, Main.Instance.Player, canControl: false).On_ClothingToggle(true);
    Main.Instance.SexScene.CanExitSexScene = false;
    if (this.FirstGuard is Girl)
      ((Girl) this.FirstGuard).GirlPhysics = false;
    this.FeedTimer = 20f;
    Main.Instance.GameplayMenu.WeaponReloadUI.SetActive(true);
    Main.Instance.GameplayMenu.WeaponReloadUI.transform.SetParent(Main.Instance.SexScene.transform);
    Main.Instance.MainThreads.Add(new Action(this.Goal5));
  }

  public void Chat1()
  {
    if (this.FirstGuard is Girl)
      ((Girl) this.FirstGuard).GirlPhysics = false;
    this.FirstGuard.transform.SetPositionAndRotation(this.PPDoorStandSpot.position, this.PPDoorStandSpot.rotation);
    Main.Instance.GameplayMenu.DisplaySubtitle("Wake up bitch, it's feeding time", this.VoiceLines[8], new Action(Main.Instance.GameplayMenu.EndChat));
    this.CellDoor.InteractText = "Suck   (Right-click or E)";
    this.CellDoor.InteractIcon = 0;
    this.CellDoor.ScriptToRun_OnInteract = new MonoBehaviour[1]
    {
      (MonoBehaviour) this
    };
    this.CellDoor.ScriptFunctionToRun_OnInteract = new string[1]
    {
      "FeedingTime"
    };
  }

  public void Chat1_aftersucc()
  {
    Main.Instance.CanSaveFlags_remove("HardQuest1");
    this.FirstGuard.CompleteScheduleTask();
    this.FirstGuard.navMesh.isStopped = true;
    Main.Instance.SexScene.CanExitSexScene = true;
    Main.Instance.CanSaveFlags_remove("Hard_NewDay");
    this.FirstGuard.transform.SetPositionAndRotation(this.PPDoorGuardAfterSpot.position, this.PPDoorGuardAfterSpot.rotation);
    Main.Instance.Player.transform.SetPositionAndRotation(this.PPDoorPlayerSpot.position, this.PPDoorPlayerSpot.rotation);
    this.Chat1_3();
  }

  public void Chat1_2()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    _gameplay.RemoveAllChatOptions();
    _gameplay.AddChatOption("The mines", (Action) (() =>
    {
      Main.Instance.GlobalVars.Set("HardMode_PreviousChoice", "0");
      Main.Instance.GlobalVars.Set("HardMode_FirstSelection", "0");
      Main.Instance.GlobalVars.Set("HardMode_PickedOption", "0");
      _gameplay.DisplaySubtitle("The mines huh?  Feeling dirty I see", this.VoiceLines[1], new Action(this.Chat2));
      this.PickedOption = 0;
    }));
    _gameplay.AddChatOption("Sex training", (Action) (() =>
    {
      Main.Instance.GlobalVars.Set("HardMode_PreviousChoice", "1");
      Main.Instance.GlobalVars.Set("HardMode_FirstSelection", "1");
      Main.Instance.GlobalVars.Set("HardMode_PickedOption", "1");
      _gameplay.DisplaySubtitle("I would have picked the same", this.VoiceLines[2], new Action(this.Chat2));
      this.PickedOption = 1;
    }));
    _gameplay.AddChatOption("Dancing", (Action) (() =>
    {
      Main.Instance.GlobalVars.Set("HardMode_PreviousChoice", "2");
      Main.Instance.GlobalVars.Set("HardMode_FirstSelection", "2");
      Main.Instance.GlobalVars.Set("HardMode_PickedOption", "2");
      _gameplay.DisplaySubtitle("Suprising", this.VoiceLines[3], new Action(this.Chat2));
      this.PickedOption = 2;
    }));
    _gameplay.SelectChatOption(0);
    Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
  }

  public void Chat1_3()
  {
    Main.Instance.GameplayMenu.DisplaySubtitle("Welcome to BL's training center", this.VoiceLines[5], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("You'll stay here for only 5 days", this.VoiceLines[6], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("With some luck they'll let you stay after that", this.VoiceLines[7], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("For now, do you want to start with sex training, dancing or going to the mines?", this.VoiceLines[0], new Action(this.Chat1_2), this.FirstGuard)), this.FirstGuard)), this.FirstGuard)), this.FirstGuard);
  }

  public void Chat2()
  {
    Main.Instance.GameplayMenu.DisplaySubtitle("Come now slut", this.VoiceLines[4], new Action(Main.Instance.GameplayMenu.EndChat), this.FirstGuard);
    this.CellDoor.Locked = false;
    this.CellDoor.Interact(this.FirstGuard);
    this.FirstGuard.RemovePenis();
    this.FirstGuard.WeaponInv.SetActiveWeapon(1);
    this.SecondGuard_Spawn.PersonGenerated.WeaponInv.SetActiveWeapon(0);
    this.AddGoal(4, true);
    this.HandlePickedOption();
  }

  public void HandlePickedOption()
  {
    this.PreviousChoice = this.PickedOption;
    Main.Instance.GlobalVars.Set("HardMode_PreviousChoice", this.PreviousChoice.ToString());
    switch (this.PickedOption)
    {
      case 0:
        this.FirstGuard.StartScheduleTask(new Person.ScheduleTask()
        {
          IDName = "2",
          ActionPlace = this.MineEntrancePlace,
          OnArrive = (Action) (() =>
          {
            this.FirstGuard.transform.eulerAngles = this.MineEntrancePlace.eulerAngles;
            Main.Instance.MainThreads.Add(new Action(this.ThreadWaitForplayer_mines));
          })
        });
        break;
      case 1:
        this.FirstGuard.StartScheduleTask(new Person.ScheduleTask()
        {
          IDName = "3",
          ActionPlace = this.SexChairPlace,
          OnArrive = (Action) (() =>
          {
            this.FirstGuard.transform.eulerAngles = this.SexChairPlace.eulerAngles;
            Main.Instance.MainThreads.Add(new Action(this.ThreadWaitForplayer_trainign));
          })
        });
        break;
      case 2:
        this.FirstGuard.StartScheduleTask(new Person.ScheduleTask()
        {
          IDName = "4",
          ActionPlace = this.DancingPlace,
          OnArrive = (Action) (() => Main.Instance.MainThreads.Add(new Action(this.ThreadWaitForplayer_dance)))
        });
        break;
    }
  }

  public void ThreadWaitForplayer_trainign()
  {
    if ((double) Main.Instance.Player.transform.position.y - (double) this.FirstGuard.transform.position.y >= 0.10000000149011612 || (double) Main.Instance.Player.transform.position.y - (double) this.FirstGuard.transform.position.y <= -0.10000000149011612 || (double) Vector2.Distance(new Vector2(Main.Instance.Player.transform.position.x, Main.Instance.Player.transform.position.z), new Vector2(this.FirstGuard.transform.position.x, this.FirstGuard.transform.position.z)) >= 3.0)
      return;
    this.CompleteGoal(4);
    this.CompleteMission();
    this.SexMission.FirstTalk();
    Main.Instance.MainThreads.Remove(new Action(this.ThreadWaitForplayer_trainign));
  }

  public void ThreadWaitForplayer_mines()
  {
    if ((double) Main.Instance.Player.transform.position.y - (double) this.FirstGuard.transform.position.y >= 0.10000000149011612 || (double) Main.Instance.Player.transform.position.y - (double) this.FirstGuard.transform.position.y <= -0.10000000149011612 || (double) Vector2.Distance(new Vector2(Main.Instance.Player.transform.position.x, Main.Instance.Player.transform.position.z), new Vector2(this.FirstGuard.transform.position.x, this.FirstGuard.transform.position.z)) >= 3.0)
      return;
    this.CompleteGoal(4);
    this.CompleteMission();
    if (this.MineMission.SecondTime)
    {
      Main.Instance.GameplayMenu.DisplaySubtitle("You know the deal", this.VoiceLinesMines[3], new Action(Main.Instance.GameplayMenu.EndChat), this.FirstGuard);
      this.MineMission.EntranceDoors[0].Locked = false;
      this.MineMission.EntranceDoors[1].Locked = false;
      this.MineMission.ExitDoors[0].Locked = true;
      this.MineMission.ExitDoors[1].Locked = true;
      Int_ResourceMining[] objectsOfType = UnityEngine.Object.FindObjectsOfType<Int_ResourceMining>();
      int num1 = 0;
      for (int index = 0; index < objectsOfType.Length; ++index)
        num1 += objectsOfType[index].OreCount;
      int num2 = num1 < 60 ? (num1 > 5 ? num1 - 5 : 1) : 60;
      this.MineMission.TotalResourcesGiven = 0;
      this.MineMission.TotalResourcesToGive = num2;
      this.MineMission.Goals[4].Title = $"Find and bring {num2.ToString()} resources to the Storage room";
      this.MineMission.AddGoal(4, true);
      this.MineMission.StorageGuardInt.InteractBlockers.Clear();
      this.MineMission.StorageGuardInt.CanInteract = true;
    }
    else
      Main.Instance.GameplayMenu.DisplaySubtitle("Go in there, at your left room get yourself a Pickaxe and some light.  And then go bring some resources to the room at your right", this.VoiceLinesMines[0], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("Come back only when you can't carry anymore, or else", this.VoiceLinesMines[1], new Action(Main.Instance.GameplayMenu.EndChat), this.FirstGuard)), this.FirstGuard);
    Main.Instance.MainThreads.Remove(new Action(this.ThreadWaitForplayer_mines));
  }

  public void ThreadWaitForplayer_dance()
  {
    if ((double) Main.Instance.Player.transform.position.y - (double) this.FirstGuard.transform.position.y >= 0.20000000298023224 || (double) Main.Instance.Player.transform.position.y - (double) this.FirstGuard.transform.position.y <= -0.20000000298023224 || (double) Vector2.Distance(new Vector2(Main.Instance.Player.transform.position.x, Main.Instance.Player.transform.position.z), new Vector2(this.FirstGuard.transform.position.x, this.FirstGuard.transform.position.z)) >= 3.0)
      return;
    this.CompleteGoal(4);
    this.CompleteMission();
    if (this.MineMission.SecondTime)
    {
      Main.Instance.GameplayMenu.DisplaySubtitle("You know the deal", this.VoiceLinesMines[0], new Action(Main.Instance.GameplayMenu.EndChat), this.FirstGuard);
      this.FirstGuard.StartScheduleTask(new Person.ScheduleTask()
      {
        IDName = "5_2",
        ActionPlace = this.Couch.NavMeshInteractSpot,
        OnArrive = (Action) (() => this.Couch.Interact(this.FirstGuard))
      });
    }
    else
      Main.Instance.GameplayMenu.DisplaySubtitle("Watch how the others do it, now dance better", this.VoiceLinesDance[0], (Action) (() =>
      {
        this.FirstGuard.StartScheduleTask(new Person.ScheduleTask()
        {
          IDName = "5",
          ActionPlace = this.Couch.NavMeshInteractSpot,
          OnArrive = (Action) (() => this.Couch.Interact(this.FirstGuard))
        });
        Main.Instance.GameplayMenu.EndChat();
      }), this.FirstGuard);
    Main.Instance.MainThreads.Remove(new Action(this.ThreadWaitForplayer_dance));
  }

  public void SpawnPrisioner1(Person prisioner) => prisioner.A_Standing = "Sitting Dazed";

  public void SpawnPrisioner2(Person prisioner) => prisioner.A_Standing = "Fallen Idle";

  public void SpawnPrisioner3(Person prisioner)
  {
    Main.Instance.CityCharacters.SetPerson(prisioner);
    prisioner.A_Standing = "sit_03";
  }

  public void SpawnPrisioner4(Person prisioner) => prisioner.A_Standing = "Mast1";

  public void SpawnPrisioner5(Person prisioner) => prisioner.A_Standing = "idle_10";

  public void SpawnPrisioner6(Person prisioner) => prisioner.A_Standing = "crossarms_00";

  public void SpawnPrisioner7(Person prisioner) => prisioner.A_Standing = "liedown_04";

  public void SpawnPrisioner8(Person prisioner) => prisioner.A_Standing = "liedown_03";

  public void SpawnPrisioner9(Person prisioner) => prisioner.A_Standing = "pose_03";

  public void SpawnPrisioner10(Person prisioner) => prisioner.A_Standing = "Sitting Dazed";

  public void SpawnPrisioner11(Person prisioner) => prisioner.A_Standing = "booty";

  public void SpawnPrisioner12(Person prisioner)
  {
    string[] strArray = new string[5]
    {
      "sit_03",
      "sit_05",
      "sit_02",
      "Push Up",
      "Situps"
    };
    prisioner.A_Standing = strArray[UnityEngine.Random.Range(0, strArray.Length)];
  }

  public void SpawnPrisioner13(Person prisioner)
  {
    string[] strArray = new string[5]
    {
      "booty",
      "Snake Hip Hop Dance 2",
      "Dancing Twerk",
      "Belly Dance",
      "Bellydancing"
    };
    prisioner.A_Standing = strArray[UnityEngine.Random.Range(0, strArray.Length)];
    this.AddToDayGuard(prisioner);
  }

  public void SpawnPrisionerPole1(Person prisioner)
  {
    this.AddToDayGuard(prisioner);
    this.Poles[0].Interact(prisioner);
  }

  public void SpawnPrisionerPole2(Person prisioner)
  {
    this.AddToDayGuard(prisioner);
    this.Poles[1].Interact(prisioner);
  }

  public override void CompleteMission()
  {
    base.CompleteMission();
    switch (this.PickedOption)
    {
      case 0:
        Main.Instance.GameplayMenu.StartMission((Mission) this.MineMission);
        break;
      case 1:
        Main.Instance.GameplayMenu.StartMission((Mission) this.SexMission);
        break;
      case 2:
        Main.Instance.GameplayMenu.StartMission((Mission) this.DanceMission);
        break;
    }
  }

  public void OnFirstGuardSpawn(Person firstGuard)
  {
    firstGuard.Hips.localScale = new Vector3(1.1f, 1f, 1.1f);
    firstGuard.UpperThighLeft.localScale = new Vector3(1f, 1f, 1f);
    firstGuard.UpperThighRight.localScale = new Vector3(1f, 1f, 1f);
    if ((UnityEngine.Object) firstGuard.CurrentHat != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) firstGuard.UndressClothe(firstGuard.CurrentHat));
    firstGuard.DressClothe(this.OfficerHat);
    for (int index = 0; index < firstGuard.CurrentAnys.Count; ++index)
      UnityEngine.Object.Destroy((UnityEngine.Object) firstGuard.UndressClothe(firstGuard.CurrentAnys[index]));
  }

  public void CellPunishment() => this.int_Punishment.Interact(Main.Instance.Player);

  public void SetDayTime()
  {
    Main.Instance.DayCycle.ResetMidday();
    for (int index = 0; index < this.SpawnedGuards.Count; ++index)
      this.SpawnedGuards[index].gameObject.SetActive(true);
    for (int index = 0; index < this.SpawnedPrisioners_day.Count; ++index)
      this.SpawnedPrisioners_day[index].gameObject.SetActive(true);
    for (int index = 0; index < this.SpawnedPrisioners_night.Count; ++index)
      this.SpawnedPrisioners_night[index].gameObject.SetActive(false);
    for (int index = 0; index < this.EnabledeAtNight.Count; ++index)
      this.EnabledeAtNight[index].gameObject.SetActive(false);
  }

  public void SetNightTime()
  {
    Main.Instance.DayCycle.ResetMidnight();
    this.CellDoor.CloseDoor();
    this.CellDoor.Locked = true;
    for (int index = 0; index < this.SpawnedGuards.Count; ++index)
      this.SpawnedGuards[index].gameObject.SetActive(false);
    for (int index = 0; index < this.SpawnedPrisioners_day.Count; ++index)
      this.SpawnedPrisioners_day[index].gameObject.SetActive(false);
    for (int index = 0; index < this.SpawnedPrisioners_night.Count; ++index)
      this.SpawnedPrisioners_night[index].gameObject.SetActive(true);
    for (int index = 0; index < this.EnabledeAtNight.Count; ++index)
      this.EnabledeAtNight[index].gameObject.SetActive(true);
  }

  public void AddToDayGuard(Person person)
  {
    this.SpawnedGuards.Add(person);
    Main.Instance.GlobalVars.Set("Hardmode_DayNPC_" + person.WorldSaveID, "1");
  }

  public void AddToDayCaptured(Person person)
  {
    this.SpawnedPrisioners_day.Add(person);
    Main.Instance.GlobalVars.Set("Hardmode_DayNPC_" + person.WorldSaveID, "1");
  }

  public void AddToNightCaptured(Person person)
  {
    this.SpawnedPrisioners_night.Add(person);
    person.gameObject.SetActive(false);
    Main.Instance.GlobalVars.Set("Hardmode_NightNPC_" + person.WorldSaveID, "1");
  }

  public void StartNewDay()
  {
    Main.Instance.CanSaveFlags_add("Hard_NewDay");
    this.SetDayTime();
    this.FirstGuard.AddMoveBlocker("HardRepos");
    this.FirstGuard.transform.position = this.GuardSpotOutsideCellNewDay.position;
    Main.RunInNextFrame((Action) (() =>
    {
      this.FirstGuard.RemoveMoveBlocker("HardRepos");
      this.FirstGuard.StartScheduleTask(new Person.ScheduleTask()
      {
        IDName = "2",
        ActionPlace = this.PPDoorStandSpot,
        OnArrive = (Action) (() =>
        {
          this.FirstGuard.transform.SetPositionAndRotation(this.PPDoorGuardAfterSpot.position, this.PPDoorGuardAfterSpot.rotation);
          Main.Instance.GameplayMenu.EnterChatWith(this.FirstGuard, (MonoBehaviour) this, "Chat_day" + this.CurrentDay.ToString());
        })
      });
    }), 3);
    ++this.CurrentDay;
    Main.Instance.GlobalVars.Set("HardMode_CurrentDay", this.CurrentDay.ToString());
    this.Goals[4].Completed = false;
    Main.Instance.GameplayMenu.ShowNotification($"Day {(this.CurrentDay + 1).ToString()} out of 5");
    if (this.CurrentDay != 3)
      return;
    this.Day4Stuff.SetActive(true);
    this.SexMission.SecondTime = true;
    this.DanceMission.SecondTime = true;
    this.MineMission.SecondTime = true;
    for (int index = 0; index < this.SpawnedPrisioners_day.Count; ++index)
    {
      Person pp = this.SpawnedPrisioners_day[index];
      if (!pp.TheHealth.Incapacitated && !pp.TheHealth.dead && pp.PersonType.ThisType == Person_Type.Prisioner)
      {
        for (int i = 0; i < this.SuckDildos.Length; i++)
        {
          if ((UnityEngine.Object) this.SuckDildos[i].PersonGoingToUse == (UnityEngine.Object) null)
          {
            this.SuckDildos[i].PersonGoingToUse = pp;
            pp.State = Person_State.Work;
            if ((UnityEngine.Object) pp.InteractingWith != (UnityEngine.Object) null)
              pp.InteractingWith.StopInteracting(pp);
            pp.CompleteScheduleTask(false);
            Main.RunInNextFrame((Action) (() => this.SuckDildos[i].Interact(pp)), 5);
            break;
          }
        }
      }
    }
  }

  public void PlayerIntoPunishmentDummy()
  {
    if ((UnityEngine.Object) Main.Instance.Player.CurrentHair != (UnityEngine.Object) null)
      this.PunishmentDummy.DressClothe(Main.Instance.Player.CurrentHair.OriginalPrefab);
    if (Main.Instance.Player.HasPenis)
    {
      this.PunishmentDummy.Penis.transform.localScale = Main.Instance.Player.Penis.transform.localScale;
      this.PunishmentDummy.PutPenis();
    }
    this.PunishmentDummy.NaturalSkinColor = Main.Instance.Player.NaturalSkinColor;
    this.PunishmentDummy.NaturalHairColor = Main.Instance.Player.NaturalHairColor;
    this.PunishmentDummy.DyedHairColor = Main.Instance.Player.DyedHairColor;
    this.PunishmentDummy.RefreshColors();
    for (int index = 0; index < this.PunishmentDummy.AllBodyBones.Length; ++index)
    {
      this.PunishmentDummy.AllBodyBones[index].localPosition = Main.Instance.Player.AllBodyBones[index].localPosition;
      this.PunishmentDummy.AllBodyBones[index].localScale = Main.Instance.Player.AllBodyBones[index].localScale;
    }
    for (int index = 0; index < this.PunishmentDummy.AllFaceBones.Length; ++index)
    {
      this.PunishmentDummy.AllFaceBones[index].localPosition = Main.Instance.Player.AllFaceBones[index].localPosition;
      this.PunishmentDummy.AllFaceBones[index].localScale = Main.Instance.Player.AllFaceBones[index].localScale;
    }
    this.PunishmentDummy.transform.parent.gameObject.SetActive(true);
    Main.Instance.Player.transform.position = this.PunishmentDummy.transform.position - new Vector3(0.0f, 0.3f, 0.0f);
    Main.RunInNextFrame((Action) (() =>
    {
      Main.Instance.Player.transform.position = this.PunishmentDummy.transform.position - new Vector3(0.0f, 0.3f, 0.0f);
      Main.Instance.Player.gameObject.SetActive(false);
    }), 3);
    Main.Instance.CapturedBuilding1_Area.OnEnter();
    Main.RunInNextFrame(new Action(this.PunishmentDummy.StartRagdoll), 5);
    this.PunishmentDummy.RagdollManager.OnBecomeNOTRagdoll();
  }

  public void PlayerIntoPunishmentDummy_Hide()
  {
    this.PunishmentDummy.gameObject.SetActive(false);
    this.PunishmentDummy.transform.parent.gameObject.SetActive(false);
    Main.Instance.Player.gameObject.SetActive(true);
  }

  public void SleepInNightTime()
  {
    Main.Instance.Player.AddMoveBlocker("HardMode_Sleep");
    Main.Instance.GameplayMenu.Crossair.transform.parent.gameObject.SetActive(false);
    this.CellDoor.CloseDoor();
    this.CellDoor.Locked = true;
    Main.Instance.GameplayMenu.TheScreenFader.FadeOut(1f, (Action) (() =>
    {
      Main.Instance.Player.Energy = 0.0f;
      Main.Instance.Player.SleepOnFloor();
      Main.Instance.GameplayMenu.WeaponReloadUI.SetActive(false);
      Main.RunInNextFrame((Action) (() =>
      {
        Main.Instance.GameplayMenu.TheScreenFader.FadeIn(2f);
        Main.RunInSeconds((Action) (() => Main.Instance.GameplayMenu.TheScreenFader.FadeOut(2f, (Action) (() => Main.RunInNextFrame((Action) (() =>
        {
          Main.Instance.GameplayMenu.TheScreenFader.FadeIn(2f);
          if ((UnityEngine.Object) Main.Instance.Player.InteractingWith != (UnityEngine.Object) null)
          {
            Main.Instance.Player.InteractingWith.StopInteracting(Main.Instance.Player);
            Main.Instance.Player.SleepOnFloor();
          }
          Main.Instance.GameplayMenu.Crossair.transform.parent.gameObject.SetActive(true);
          Main.Instance.GameplayMenu.WeaponReloadUI.SetActive(true);
          Main.Instance.Player.Energy = Main.Instance.Player.EnergyMax - Main.Instance.Player.EnergyMax / 5f;
          this.StartNewDay();
          Main.Instance.CurrentArea = (BL_MapArea) null;
          Main.Instance.CapturedBuilding1_Area.OnEnter();
          Main.Instance.Player.RemoveMoveBlocker("HardMode_Sleep");
        }), 2)))), 10f);
      }), 2);
    }));
  }

  public int PickedOption
  {
    get => this._PickedOption;
    set
    {
      this._PickedOption = value;
      Main.Instance.GlobalVars.Set("HardMode_PickedOption", this._PickedOption.ToString());
    }
  }

  public int PreviousChoice
  {
    get => this._PreviousChoice;
    set
    {
      this._PreviousChoice = value;
      Main.Instance.GlobalVars.Set("HardMode_PreviousChoice", this._PreviousChoice.ToString());
    }
  }

  public int CurrentDay
  {
    get => this._CurrentDay;
    set
    {
      this._CurrentDay = value;
      Main.Instance.GlobalVars.Set("HardMode_CurrentDay", this._CurrentDay.ToString());
    }
  }

  public void Chat_day1()
  {
    ++this.PickedOption;
    if (this.PickedOption >= 3)
      this.PickedOption = 0;
    Main.Instance.GameplayMenu.DisplaySubtitle("Good morning sunshine", this.VoiceLines_Greeting[0], (Action) (() =>
    {
      switch (this.PreviousChoice)
      {
        case 0:
          Main.Instance.GameplayMenu.DisplaySubtitle("Yesterday you did the mines", this.VoiceLines_Yesterday[0], new Action(this.Chat_day1_Today), this.FirstGuard);
          break;
        case 1:
          Main.Instance.GameplayMenu.DisplaySubtitle("Yesterday you did the sex training", this.VoiceLines_Yesterday[1], new Action(this.Chat_day1_Today), this.FirstGuard);
          break;
        case 2:
          Main.Instance.GameplayMenu.DisplaySubtitle("Yesterday you danced", this.VoiceLines_Yesterday[2], new Action(this.Chat_day1_Today), this.FirstGuard);
          break;
      }
    }), this.FirstGuard);
  }

  public void Chat_day1_Today()
  {
    switch (this.PickedOption)
    {
      case 0:
        Main.Instance.GameplayMenu.DisplaySubtitle("So today is back to the mines day", this.VoiceLines_Today[0], new Action(this.Chat_day1_Feed), this.FirstGuard);
        break;
      case 1:
        Main.Instance.GameplayMenu.DisplaySubtitle("So today is sex day", this.VoiceLines_Today[1], new Action(this.Chat_day1_Feed), this.FirstGuard);
        break;
      case 2:
        Main.Instance.GameplayMenu.DisplaySubtitle("So today is dancing day", this.VoiceLines_Today[2], new Action(this.Chat_day1_Feed), this.FirstGuard);
        break;
    }
  }

  public void Chat_day1_Feed()
  {
    Main.Instance.GameplayMenu.DisplaySubtitle("But first, breakfast time", this.VoiceLines_Feed[0], (Action) (() =>
    {
      Main.Instance.GameplayMenu.EndChat();
      this.FirstGuard.transform.SetPositionAndRotation(this.PPDoorStandSpot.position, this.PPDoorStandSpot.rotation);
      this.CellDoor.InteractText = "Suck   (Right-click or E)";
      this.CellDoor.InteractIcon = 0;
      this.CellDoor.ScriptToRun_OnInteract = new MonoBehaviour[1]
      {
        (MonoBehaviour) this
      };
      this.CellDoor.ScriptFunctionToRun_OnInteract = new string[1]
      {
        "FeedingTime2"
      };
      this.Call_AfterSucc = new Action(this.Day2_aftersucc);
    }), this.FirstGuard);
  }

  public void FeedingTime2()
  {
    Main.Instance.SexScene.SpawnSexScene(2, 3, this.FirstGuard, Main.Instance.Player, canControl: false).On_ClothingToggle(true);
    Main.Instance.SexScene.CanExitSexScene = false;
    if (this.FirstGuard is Girl)
      ((Girl) this.FirstGuard).GirlPhysics = false;
    this.FeedTimer = 20f;
    Main.Instance.GameplayMenu.WeaponReloadUI.SetActive(true);
    Main.Instance.GameplayMenu.WeaponReloadUI.transform.SetParent(Main.Instance.SexScene.transform);
    Main.Instance.MainThreads.Add(new Action(this.FeedingThread));
  }

  public void FeedingThread()
  {
    this.FeedTimer -= Time.deltaTime;
    Main.Instance.GameplayMenu.WeaponReloadSlider.fillAmount = this.FeedTimer / 20f;
    if ((double) this.FeedTimer >= 0.0)
      return;
    Main.Instance.GameplayMenu.WeaponReloadUI.SetActive(false);
    Main.Instance.GameplayMenu.WeaponReloadUI.transform.SetParent(Main.Instance.GameplayMenu.transform);
    Main.Instance.MainThreads.Remove(new Action(this.FeedingThread));
    Main.Instance.SexScene.EndSexScene();
    this.CellDoor.ScriptToRun_OnInteract = new MonoBehaviour[0];
    this.CellDoor.ScriptFunctionToRun_OnInteract = new string[0];
    this.CellDoor.InteractText = "Open";
    this.CellDoor.Locked = false;
    this.CellDoor.Locked = true;
    this.Call_AfterSucc();
  }

  public void Day2_aftersucc()
  {
    this.FirstGuard.CompleteScheduleTask();
    this.FirstGuard.navMesh.isStopped = true;
    Main.Instance.SexScene.CanExitSexScene = true;
    Main.Instance.CanSaveFlags_remove("Hard_NewDay");
    Main.Instance.GameplayMenu.DisplaySubtitle("Come now slut", this.VoiceLines[4], new Action(Main.Instance.GameplayMenu.EndChat), this.FirstGuard);
    this.CellDoor.Locked = false;
    this.CellDoor.Interact(this.FirstGuard);
    this.FirstGuard.RemovePenis();
    this.HandlePickedOption_day();
  }

  public void HandlePickedOption_day()
  {
    this.PreviousChoice = this.PickedOption;
    switch (this.PickedOption)
    {
      case 0:
        this.FirstGuard.StartScheduleTask(new Person.ScheduleTask()
        {
          IDName = "2",
          ActionPlace = this.MineEntrancePlace,
          OnArrive = (Action) (() =>
          {
            this.FirstGuard.transform.eulerAngles = this.MineEntrancePlace.eulerAngles;
            Main.Instance.MainThreads.Add(new Action(this.ThreadWaitForplayer_mines));
          })
        });
        break;
      case 1:
        this.FirstGuard.StartScheduleTask(new Person.ScheduleTask()
        {
          IDName = "3",
          ActionPlace = this.SexChairPlace,
          OnArrive = (Action) (() =>
          {
            this.FirstGuard.transform.eulerAngles = this.SexChairPlace.eulerAngles;
            Main.Instance.MainThreads.Add(new Action(this.ThreadWaitForplayer_trainign));
          })
        });
        break;
      case 2:
        this.FirstGuard.StartScheduleTask(new Person.ScheduleTask()
        {
          IDName = "4",
          ActionPlace = this.DancingPlace,
          OnArrive = (Action) (() => Main.Instance.MainThreads.Add(new Action(this.ThreadWaitForplayer_dance)))
        });
        break;
    }
  }

  public void Chat_day2()
  {
    Main.Instance.GameplayMenu.DisplaySubtitle("Breakfast is here", this.VoiceLines_Greeting[1], (Action) (() =>
    {
      Main.Instance.GameplayMenu.EndChat();
      this.FirstGuard.transform.SetPositionAndRotation(this.PPDoorStandSpot.position, this.PPDoorStandSpot.rotation);
      this.CellDoor.InteractText = "Suck   (Right-click or E)";
      this.CellDoor.InteractIcon = 0;
      this.CellDoor.ScriptToRun_OnInteract = new MonoBehaviour[1]
      {
        (MonoBehaviour) this
      };
      this.CellDoor.ScriptFunctionToRun_OnInteract = new string[1]
      {
        "FeedingTime2"
      };
      this.Call_AfterSucc = new Action(this.Chat_day3_AfterSucc);
    }), this.FirstGuard);
  }

  public void Chat_day2_Today()
  {
    switch (this.PickedOption)
    {
      case 0:
        Main.Instance.GameplayMenu.DisplaySubtitle("So today is back to the mines day", this.VoiceLines_Today[0], new Action(this.Day2_aftersucc), this.FirstGuard);
        break;
      case 1:
        Main.Instance.GameplayMenu.DisplaySubtitle("So today is sex day", this.VoiceLines_Today[1], new Action(this.Day2_aftersucc), this.FirstGuard);
        break;
      case 2:
        Main.Instance.GameplayMenu.DisplaySubtitle("So today is dancing day", this.VoiceLines_Today[2], new Action(this.Day2_aftersucc), this.FirstGuard);
        break;
    }
  }

  public void Chat_day3_AfterSucc()
  {
    ++this.PickedOption;
    if (this.PickedOption >= 3)
      this.PickedOption = 0;
    switch (this.PreviousChoice)
    {
      case 0:
        Main.Instance.GameplayMenu.DisplaySubtitle("Yesterday you did the mines", this.VoiceLines_Yesterday[0], new Action(this.Chat_day2_Today), this.FirstGuard);
        break;
      case 1:
        Main.Instance.GameplayMenu.DisplaySubtitle("Yesterday you did the sex training", this.VoiceLines_Yesterday[1], new Action(this.Chat_day2_Today), this.FirstGuard);
        break;
      case 2:
        Main.Instance.GameplayMenu.DisplaySubtitle("Yesterday you danced", this.VoiceLines_Yesterday[2], new Action(this.Chat_day2_Today), this.FirstGuard);
        break;
    }
  }

  public void Chat_day3()
  {
    Main.Instance.GameplayMenu.DisplaySubtitle("Wake the fuck up", this.VoiceLines_Greeting[2], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("Today we're helping the science division with an experiment", this.VoiceLines_Feed[1], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("To summarize it, when people kiss for longer than 6 seconds, the brain makes some love quemicals", this.VoiceLines_Feed[2], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("And since kissing and sucking dick are both done with the mouth", this.VoiceLines_Feed[3], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("you're gonna be sucking dick all morning", this.VoiceLines_Feed[4], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("But first, breakfast time", this.VoiceLines_Greeting[6], (Action) (() =>
    {
      Main.Instance.GameplayMenu.EndChat();
      this.FirstGuard.transform.SetPositionAndRotation(this.PPDoorStandSpot.position, this.PPDoorStandSpot.rotation);
      this.CellDoor.InteractText = "Suck   (Right-click or E)";
      this.CellDoor.InteractIcon = 0;
      this.CellDoor.ScriptToRun_OnInteract = new MonoBehaviour[1]
      {
        (MonoBehaviour) this
      };
      this.CellDoor.ScriptFunctionToRun_OnInteract = new string[1]
      {
        "FeedingTime2"
      };
      this.Call_AfterSucc = new Action(this.Chat_day4_AfterSucc);
    }), this.FirstGuard)), this.FirstGuard)), this.FirstGuard)), this.FirstGuard)), this.FirstGuard)), this.FirstGuard);
  }

  public void Chat_day4_AfterSucc()
  {
    this.FirstGuard.ThisPersonInt.AddBlocker("day4");
    this.FirstGuard.ThisPersonInt.RemoveBlocker("HardQuest1");
    Main.Instance.Player.States[26] = true;
    Main.Instance.Player.SetBodyTexture();
    this.NonRemoveGag.SetActive(true);
    Main.Instance.GameplayMenu.DisplaySubtitle("I'mma give you this gag first, equip it", this.VoiceLines[16 /*0x10*/], (Action) (() =>
    {
      Main.Instance.GameplayMenu.EndChat();
      this.CellDoor.OpenDoor();
      this.CellDoor.Locked = false;
      this.FirstGuard.StartScheduleTask(new Person.ScheduleTask()
      {
        IDName = "day4",
        ActionPlace = this.Day4GuardWaitSpot,
        OnArrive = (Action) (() =>
        {
          this.CellDoor.Locked = false;
          this.FirstGuard.transform.SetPositionAndRotation(this.Day4GuardWaitSpot.position, this.Day4GuardWaitSpot.rotation);
          Main.Instance.GameplayMenu.DisplaySubtitle("Oh well, looks like there aren't enough dildos for everyone", this.VoiceLines[9], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("Good thing I got this one right here just for you", this.VoiceLines[10], (Action) (() =>
          {
            Main.Instance.GameplayMenu.EndChat();
            this.FirstGuard.ThisPersonInt.RemoveBlocker("day4");
            this.FirstGuard.ThisPersonInt.StartTalkMono = (MonoBehaviour) this;
            this.FirstGuard.ThisPersonInt.StartTalkFunc = "Day4_InteractWithGuard1";
            this.FirstGuard.ThisPersonInt.InteractText = "Suck";
          }), this.FirstGuard)), this.FirstGuard);
        })
      });
    }), this.FirstGuard);
  }

  public void Day4_InteractWithGuard1()
  {
    if ((UnityEngine.Object) this.NonRemoveGag != (UnityEngine.Object) null)
    {
      Main.Instance.GameplayMenu.DisplaySubtitle("Equip the gag first", this.VoiceLines[17], new Action(Main.Instance.GameplayMenu.EndChat), this.FirstGuard);
    }
    else
    {
      Main.Instance.Player.States[23] = true;
      Main.Instance.Player.SetBodyTexture();
      this.CellDoor.CloseDoor();
      Main.Instance.Player.AddMoveBlocker("Day4");
      Main.Instance.SexScene.SpawnSexScene(2, 3, this.FirstGuard, Main.Instance.Player, canControl: false).On_ClothingToggle(true);
      Main.Instance.SexScene.CanExitSexScene = false;
      Main.Instance.SexScene.gameObject.SetActive(false);
      Main.Instance.GameplayMenu.gameObject.SetActive(true);
      Main.Instance.SexScene.SpeedSlider.value = Main.Instance.SexScene.SpeedSlider.maxValue;
      Main.RunInSeconds((Action) (() => Main.Instance.GameplayMenu.TheScreenFader.FadeOut(5f, (Action) (() =>
      {
        Main.RunInNextFrame((Action) (() => Main.Instance.GameplayMenu.TheScreenFader.FadeIn(2f)), 2);
        Main.Instance.SexScene.EndSexScene();
        Main.Instance.Player.Anim.Play("sit_04");
        this.TempGuard.gameObject.SetActive(true);
        this.TempGuard.SetDestination(this.tempguarddes);
        Main.Instance.GameplayMenu.DisplaySubtitle("You must be tired", this.VoiceLines[11], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("Here's a little snack", this.VoiceLines[12], (Action) (() =>
        {
          Main.Instance.GameplayMenu.EndChat();
          this.FirstGuard.SetDestination(this.SexMission.OutsideSpot);
          Main.Instance.SexScene.SpawnSexScene(4, 3, this.TempGuard, Main.Instance.Player, canControl: false).On_ClothingToggle(true);
          Main.Instance.SexScene.CanExitSexScene = false;
          Main.Instance.SexScene.gameObject.SetActive(false);
          Main.Instance.GameplayMenu.gameObject.SetActive(true);
          Main.RunInSeconds((Action) (() => Main.Instance.GameplayMenu.TheScreenFader.FadeOut(5f, (Action) (() =>
          {
            Main.RunInNextFrame((Action) (() => Main.Instance.GameplayMenu.TheScreenFader.FadeIn(2f)), 2);
            Main.RunInSeconds((Action) (() =>
            {
              this.FirstGuard.SetDestination(this.Day4GuardWaitSpot);
              this.FirstGuard.StartScheduleTask(new Person.ScheduleTask()
              {
                IDName = "goodjob",
                ActionPlace = this.Day4GuardWaitSpot,
                OnArrive = (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("Good job", this.VoiceLines[13], (Action) (() =>
                {
                  this.TempGuard.Orgasm();
                  Main.Instance.GameplayMenu.DisplaySubtitle("Now's a little break for lunch time", this.VoiceLines[14], (Action) (() =>
                  {
                    Main.Instance.GameplayMenu.EndChat();
                    Main.Instance.SexScene.EndSexScene();
                    this.TempGuard.SetDestination(this.SexChairPlace);
                    this.TransferedSex = Main.Instance.SexScene.SpawnSexScene(2, 4, this.FirstGuard, Main.Instance.Player, canControl: false);
                    this.TransferedSex.On_ClothingToggle(true);
                    Main.Instance.SexScene.CanExitSexScene = false;
                    Main.Instance.SexScene.gameObject.SetActive(false);
                    Main.Instance.GameplayMenu.gameObject.SetActive(true);
                    Main.RunInSeconds((Action) (() => Main.Instance.GameplayMenu.TheScreenFader.FadeOut(5f, (Action) (() =>
                    {
                      this.TempGuard.gameObject.SetActive(false);
                      Main.RunInNextFrame((Action) (() => Main.Instance.GameplayMenu.TheScreenFader.FadeIn(2f)), 2);
                      this.TransferedSex.StartPose(2, 6);
                      for (int index = 0; index < this.SuckDildos.Length; ++index)
                      {
                        Interactible part = (this.SuckDildos[index] as MultiInteractible).Parts[0];
                        Person interactingPerson = part.InteractingPerson;
                        if ((UnityEngine.Object) interactingPerson != (UnityEngine.Object) null && (double) UnityEngine.Random.Range(0.0f, 1f) > 0.5)
                        {
                          interactingPerson.AddMoveBlocker("quest");
                          part.StopInteracting();
                          interactingPerson.SleepOnFloor();
                          part.InteractingPerson = interactingPerson;
                        }
                      }
                      Main.RunInSeconds((Action) (() => Main.Instance.GameplayMenu.TheScreenFader.FadeOut(5f, (Action) (() =>
                      {
                        Main.RunInNextFrame((Action) (() => Main.Instance.GameplayMenu.TheScreenFader.FadeIn(2f)), 2);
                        for (int index = 0; index < this.SuckDildos.Length; ++index)
                        {
                          Interactible part = (this.SuckDildos[index] as MultiInteractible).Parts[0];
                          Person interactingPerson = part.InteractingPerson;
                          if ((UnityEngine.Object) interactingPerson != (UnityEngine.Object) null)
                          {
                            part.StopInteracting();
                            interactingPerson.gameObject.SetActive(false);
                            interactingPerson.transform.position = new Vector3(-69f, 0.0f, 10f);
                          }
                        }
                        Main.Instance.GameplayMenu.DisplaySubtitle("Alright", this.VoiceLines[15], (Action) (() =>
                        {
                          this.FirstGuard.RemovePenis();
                          Main.Instance.GameplayMenu.DisplaySubtitle("You're free for the rest of the day", this.VoiceLines[18], new Action(this.Chat_day4_AfterLunch), this.FirstGuard);
                        }), this.FirstGuard);
                      }))), 7f);
                    }))), 7f);
                  }), this.FirstGuard);
                }), this.FirstGuard))
              });
            }), 2f);
          }))), 5f);
        }), this.FirstGuard)), this.FirstGuard);
      }))), 5f);
    }
  }

  public void OnTempGuardSpawn(Person tempGuard)
  {
    this.TempGuard = tempGuard;
    tempGuard.Hips.localScale = new Vector3(1f, 1f, 1f);
    tempGuard.UpperThighLeft.localScale = new Vector3(1f, 1f, 1f);
    tempGuard.UpperThighRight.localScale = new Vector3(1f, 1f, 1f);
    for (int index = 0; index < tempGuard.CurrentAnys.Count; ++index)
      UnityEngine.Object.Destroy((UnityEngine.Object) tempGuard.UndressClothe(tempGuard.CurrentAnys[index]));
    if (tempGuard is Girl)
    {
      ((Girl) tempGuard).PregnancyPercent = 0.0f;
      ((Girl) tempGuard).Futa = true;
    }
    tempGuard.HasPenis = true;
    tempGuard.CantBeForced = true;
    tempGuard.CantBeHit = true;
    tempGuard.navMesh.speed = 1f;
    tempGuard.WeaponInv.SetActiveWeapon(1);
    tempGuard.Penis.transform.localScale = new Vector3(3f, 3f, 3f);
    tempGuard.PutPenis();
    tempGuard.HasCondomPut = true;
    tempGuard.Energy = tempGuard.EnergyMax;
    tempGuard.NoEnergyLoss = true;
    this.TempGuard.gameObject.SetActive(false);
  }

  public void Chat_day4_Today()
  {
    switch (this.PickedOption)
    {
      case 0:
        Main.Instance.GameplayMenu.DisplaySubtitle("So today is back to the mines day", this.VoiceLines_Today[0], new Action(this.Chat_day4_AfterLunch), this.FirstGuard);
        break;
      case 1:
        Main.Instance.GameplayMenu.DisplaySubtitle("So today is sex day", this.VoiceLines_Today[1], new Action(this.Chat_day4_AfterLunch), this.FirstGuard);
        break;
      case 2:
        Main.Instance.GameplayMenu.DisplaySubtitle("So today is dancing day", this.VoiceLines_Today[2], new Action(this.Chat_day4_AfterLunch), this.FirstGuard);
        break;
    }
  }

  public void Chat_day4_AfterLunch()
  {
    this.FirstGuard.ThisPersonInt.StartTalkMono = (MonoBehaviour) null;
    this.FirstGuard.ThisPersonInt.AddBlocker("sssssssss");
    Main.Instance.SexScene.CanExitSexScene = true;
    Main.Instance.SexScene.gameObject.SetActive(true);
    Main.Instance.GameplayMenu.gameObject.SetActive(false);
    Main.Instance.SexScene.EndSexScene();
    Main.Instance.GameplayMenu.EndChat();
    Main.Instance.Player.RemoveMoveBlocker("Day4");
    this.Day4DisableAfter.SetActive(false);
    Main.Instance.Player.SleepOnFloor();
    if (Main.Instance.Player.MainBody.materials.Length == 7)
    {
      Material[] destinationArray = new Material[6];
      Array.Copy((Array) Main.Instance.Player.MainBody.materials, (Array) destinationArray, 6);
      Main.Instance.Player.MainBody.materials = destinationArray;
    }
    Main.RunInSeconds((Action) (() =>
    {
      if (Main.Instance.Player.MainBody.materials.Length != 7)
        return;
      Material[] destinationArray = new Material[6];
      Array.Copy((Array) Main.Instance.Player.MainBody.materials, (Array) destinationArray, 6);
      Main.Instance.Player.MainBody.materials = destinationArray;
    }), 6f);
    this.CellDoor.Locked = false;
    this.FirstGuard.RemovePenis();
    this.FirstGuard.SetDestination(this.DanceMission.GuardUseDoorSpot);
    Main.Instance.MainThreads.Add(new Action(this.Day4SleepEnd));
  }

  public void Day4SleepEnd()
  {
    if ((UnityEngine.Object) Main.Instance.Player.CurrentZone == (UnityEngine.Object) this.PlayerCell && (UnityEngine.Object) Main.Instance.Player.CurrentZone != (UnityEngine.Object) this._prevZone)
      Main.Instance.GameplayMenu.ShowNotification("X to sleep");
    this._prevZone = Main.Instance.Player.CurrentZone;
    if (!((UnityEngine.Object) Main.Instance.Player.CurrentZone == (UnityEngine.Object) this.PlayerCell) || !Main.Instance.Player._IsSleeping)
      return;
    Main.Instance.Player.Energy = Main.Instance.Player.EnergyMax;
    this.FirstGuard.Energy = this.FirstGuard.EnergyMax;
    Main.Instance.MainThreads.Remove(new Action(Main.Instance.Player.Sleeping));
    Main.Instance.Player.Interacting = false;
    Main.Instance.Player.AddMoveBlocker("Hard_SexEndDay");
    Main.Instance.Player.Anim.Play("FloorSleep1");
    Main.Instance.MainThreads.Remove(new Action(this.Day4SleepEnd));
    this.FirstGuard.CompleteScheduleTask(false);
    this.FirstGuard.CurrentScheduleTask = (Person.ScheduleTask) null;
    if ((UnityEngine.Object) this.FirstGuard.InteractingWith != (UnityEngine.Object) null)
      this.FirstGuard.InteractingWith.StopInteracting();
    this.FirstGuard.AddMoveBlocker("Hard_SexEndDay");
    this.CellDoor.CloseDoor();
    this.CellDoor.Locked = true;
    Main.Instance.GameplayMenu.TheScreenFader.FadeOut(4f, (Action) (() => Main.RunInNextFrame((Action) (() =>
    {
      Main.Instance.GameplayMenu.TheScreenFader.FadeIn(1f);
      Main.Instance.Player.RemoveMoveBlocker("Hard_SexEndDay");
      this.FirstGuard.transform.position = this.GuardSpotOutsideCellNewDay.position;
      this.FirstGuard.RemoveMoveBlocker("Hard_SexEndDay");
      this.SleepInNightTime();
      Main.Instance.CurrentArea = (BL_MapArea) null;
      Main.Instance.CapturedBuilding1_Area.OnEnter();
      this.PlayerDildo.CanLeave = false;
      this.PlayerDildo.Interact(Main.Instance.Player);
      this.PlayerDildo.CanLeave = false;
    }), 3)));
  }

  public void Chat_day4()
  {
    Debug.LogError((object) nameof (Chat_day4));
    Main.Instance.GameplayMenu.DisplaySubtitle("Today's your last day in here", this.VoiceLines_Greeting[3], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("Enjoy this meal while you can", this.VoiceLines_Greeting[4], (Action) (() =>
    {
      Main.Instance.GameplayMenu.DisplaySubtitle("I've saved extra sauce just for you", this.VoiceLines_Greeting[5], (Action) (() => Main.Instance.GameplayMenu.EndChat()), this.FirstGuard);
      Main.Instance.GameplayMenu.EndChat();
      this.CellDoor.InteractText = "Suck   (Right-click or E)";
      this.CellDoor.InteractIcon = 0;
      this.CellDoor.ScriptToRun_OnInteract = new MonoBehaviour[1]
      {
        (MonoBehaviour) this
      };
      this.CellDoor.ScriptFunctionToRun_OnInteract = new string[1]
      {
        "FeedingTime3"
      };
      this.Call_AfterSucc = new Action(this.AfterSuccLastDay);
    }), this.FirstGuard)), this.FirstGuard);
  }

  public void FeedingTime3()
  {
    Main.Instance.SexScene.SpawnSexScene(2, 3, this.FirstGuard, Main.Instance.Player, canControl: false).On_ClothingToggle(true);
    Main.Instance.SexScene.CanExitSexScene = false;
    Main.Instance.SexScene.SpeedSlider.value = Main.Instance.SexScene.SpeedSlider.maxValue;
    if (this.FirstGuard is Girl)
      ((Girl) this.FirstGuard).GirlPhysics = false;
    this.FeedTimer = 20f;
    Main.Instance.GameplayMenu.WeaponReloadUI.SetActive(true);
    Main.Instance.GameplayMenu.WeaponReloadUI.transform.SetParent(Main.Instance.SexScene.transform);
    Main.Instance.MainThreads.Add(new Action(this.FeedingThread));
  }

  public void AfterSuccLastDay()
  {
    Main.Instance.GameplayMenu.DisplaySubtitle("Today is back to the mines day", this.VoiceLines_Today[0], (Action) (() =>
    {
      this.CellDoor.Locked = false;
      this.CellDoor.OpenDoor();
      Main.Instance.GameplayMenu.DisplaySubtitle("Oh, Looks like I forgot to put the lid on you yesterday", this.VoiceLines_Feed[5], (Action) (() =>
      {
        Main.Instance.Player.DressClothe(Main.Instance.AllPrefabs[177]);
        Main.Instance.GameplayMenu.ShowNotification("Equipped gag lid");
        Main.Instance.GameplayMenu.EndChat();
        this.FirstGuard.StartScheduleTask(new Person.ScheduleTask()
        {
          IDName = "mineslastday",
          ActionPlace = this.MineEntrancePlace,
          OnArrive = (Action) (() =>
          {
            this.FirstGuard.transform.eulerAngles = this.MineEntrancePlace.eulerAngles;
            Main.Instance.MainThreads.Add(new Action(this.ThreadWaitForplayer_mines));
          })
        });
      }), this.FirstGuard);
    }), this.FirstGuard);
  }

  public void int_Vent()
  {
  }

  public void Escape(int escapeSpot)
  {
    Main.Instance.NewGameMenu.SmallLoading.SetActive(true);
    if (UI_Settings._SpeedrunValue != 0)
    {
      Main.Instance.MainThreads.Remove(new Action(Main.Instance.GameplayMenu.SpeedrunThread));
      UI_Settings._SpeedrunValue = 0;
      float num = PlayerPrefs.GetFloat("Speedrun_1_f");
      if ((double) num == 0.0 || (double) num > (double) Main.Instance.GameplayMenu.SpeedrunTimer)
      {
        PlayerPrefs.SetFloat("Speedrun_1_f", Main.Instance.GameplayMenu.SpeedrunTimer);
        PlayerPrefs.SetString("Speedrun_1", Main.Instance.GameplayMenu.SpeedrunLabel.text);
      }
      Main.RunInNextFrame((Action) (() => SceneManager.LoadScene(1)), 5);
    }
    else
      Main.RunInNextFrame((Action) (() =>
      {
        Main.LoadMedFromHard = true;
        Main.Instance.CurrentSavePath = Main.AssetsFolder + "/HardToMedTransfer/";
        if (Directory.Exists(Main.Instance.CurrentSavePath))
          Directory.Delete(Main.Instance.CurrentSavePath, true);
        Directory.CreateDirectory(Main.Instance.CurrentSavePath);
        if (Main.Instance.Player is Girl)
          Main.Instance.Player.SaveToFile(Main.Instance.CurrentSavePath + "Player.chr");
        else
          Main.Instance.Player.SaveToFile(Main.Instance.CurrentSavePath + "Player_m.chr");
        this.FirstGuard.SaveToFile(Main.Instance.CurrentSavePath + "FirstGuard.chr");
        Main.Instance.Player.PersonType = Main.Instance.PersonTypes[0];
        if (!Main.Instance.GlobalVars.ContainsKey("GenderSettings"))
          Main.Instance.GlobalVars.Set("GenderSettings", "0");
        if (!Main.Instance.GlobalVars.ContainsKey("FutaChance"))
          Main.Instance.GlobalVars.Set("FutaChance", "0.25");
        File.WriteAllLines(Main.Instance.CurrentSavePath + "data.txt", new string[4]
        {
          "10.e",
          Main.Instance.GlobalVars["GenderSettings"],
          Main.Instance.GlobalVars["FutaChance"],
          escapeSpot.ToString()
        });
        SceneManager.LoadScene(1);
      }), 5);
  }
}
