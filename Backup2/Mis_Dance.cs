// Decompiled with JetBrains decompiler
// Type: Mis_Dance
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Mis_Dance : Mission
{
  public Mis_HardTutorial HardTut;
  public Interactible DancePole;
  public GameObject EnableOnMission;
  public Transform PlayerOutsideBuildingSpot;
  public Transform GuardUseDoorSpot;
  public Transform GuardOutsideBuildingSpot;
  public Int_Door[] OutDoorDoors;
  public AudioClip[] VoiceLines;
  public Transform Guard_CellSpot;
  public Int_Door RoomCellDoor;
  public Transform GuardClubWaitSpot;
  public GameObject EnterCellTrigger;
  public float UsePoleTimer;
  public Int_Door[] LockOnMission;
  public bool SecondTime;
  private float _FollowTimer;
  public AudioSource Club2Music;
  public List<Person> PossibleClients = new List<Person>();
  public Person Client;
  public Transform RoomSexSpot;
  public bool ClientArrivedAtRoom;
  public SpawnedSexScene _sex;
  public GameObject Goal7Trigger;
  public bl_HangZone _prevZone;

  public override void InitMission()
  {
    base.InitMission();
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
          Main.Instance.MainThreads.Add(new Action(this.Goal1));
        }
        else
        {
          this.OutDoorDoors[0].Locked = false;
          this.OutDoorDoors[1].Locked = false;
          this.OutDoorDoors[0].OpenDoor();
          this.OutDoorDoors[1].OpenDoor();
          this.EnableOnMission.SetActive(true);
          this.LockOnMission[0].CloseDoor();
          this.LockOnMission[1].CloseDoor();
          this.LockOnMission[0].Locked = true;
          this.LockOnMission[1].Locked = true;
          this.CurrentGoal = this.Goals[3];
          if (!this.CurrentGoal.Completed)
          {
            this.MedWorldOpen();
          }
          else
          {
            this.CurrentGoal = this.Goals[4];
            if (!this.CurrentGoal.Completed)
            {
              this.UsePoleTimer = 10f;
              Main.Instance.MainThreads.Add(new Action(this.Goal4));
            }
            else
            {
              this.RoomCellDoor.Locked = false;
              this.RoomCellDoor.OpenDoor();
              this.HardTut.ResetPosition = this.HardTut.ResetPosition_Dance;
              this.CurrentGoal = this.Goals[5];
              if (!this.CurrentGoal.Completed)
              {
                this.UsePoleTimer = 15f;
                Main.Instance.MainThreads.Add(new Action(this.Goal5));
              }
              else
              {
                this.CurrentGoal = this.Goals[6];
                if (!this.CurrentGoal.Completed)
                {
                  this.UsePoleTimer = 0.0f;
                }
                else
                {
                  this.CurrentGoal = this.Goals[7];
                  if (!this.CurrentGoal.Completed)
                  {
                    Main.Instance.MainThreads.Add(new Action(this.Goal8));
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
        }
      }
    }
    Main.Instance.GameplayMenu.DisplayGoal(this.CurrentGoal, true);
  }

  public void Goal0()
  {
    if (!((UnityEngine.Object) Main.Instance.Player.InteractingWith == (UnityEngine.Object) this.DancePole))
      return;
    Main.Instance.GameplayMenu.WeaponReloadUI.SetActive(true);
    this.UsePoleTimer += Time.deltaTime;
    Main.Instance.GameplayMenu.WeaponReloadSlider.fillAmount = this.UsePoleTimer / 20f;
    if ((double) this.UsePoleTimer <= 20.0)
      return;
    Main.Instance.GameplayMenu.WeaponReloadUI.SetActive(false);
    this.CompleteGoal(0);
    Main.Instance.MainThreads.Remove(new Action(this.Goal0));
    this.AddGoal(1, true);
    Main.Instance.MainThreads.Add(new Action(this.Goal1));
  }

  public void Goal1()
  {
    if (!((UnityEngine.Object) Main.Instance.Player.InteractingWith == (UnityEngine.Object) null))
      return;
    this.CompleteGoal(1);
    Main.Instance.MainThreads.Remove(new Action(this.Goal1));
    this.HardTut.FirstGuard.navMesh.stoppingDistance = 1.5f;
    this._FollowTimer = 0.0f;
    this.HardTut.FirstGuard.StartScheduleTask(new Person.ScheduleTask()
    {
      IDName = "6",
      RunTo = true,
      ActionPlace = Main.Instance.Player.transform,
      WhileGoing = (Action) (() =>
      {
        this._FollowTimer += Time.deltaTime;
        if ((double) this._FollowTimer <= 1.0)
          return;
        this._FollowTimer = 0.0f;
        this.HardTut.FirstGuard.SetDestination(Main.Instance.Player.transform);
      }),
      OnArrive = (Action) (() =>
      {
        this.HardTut.FirstGuard.transform.LookAt(Main.Instance.Player.transform);
        Main.Instance.OpenMenu("Gameplay");
        Main.Instance.GameplayMenu.EnterChatWith(this.HardTut.FirstGuard, (MonoBehaviour) this, "Chat1");
      })
    });
  }

  public void Chat1()
  {
    this.HardTut.ResetPosition = this.HardTut.ResetPosition_Dance;
    Main.Instance.GameplayMenu.DisplaySubtitle("Quite the professional dancer aren't you?", this.VoiceLines[0], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("Sloppy as fuck, but looks like you're ready enough to go straight into work", this.VoiceLines[1], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("Come with me", this.VoiceLines[2], (Action) (() =>
    {
      Main.Instance.GameplayMenu.EndChat();
      this.AddGoal(2, true);
      this.DancePole.GetComponent<Collider>().enabled = false;
      this.HardTut.FirstGuard.navMesh.stoppingDistance = 0.1f;
      this.HardTut.FirstGuard.StartScheduleTask(new Person.ScheduleTask()
      {
        IDName = "7",
        ActionPlace = this.GuardUseDoorSpot,
        OnArrive = (Action) (() =>
        {
          if ((UnityEngine.Object) this.OutDoorDoors[0].Audio != (UnityEngine.Object) null)
          {
            this.OutDoorDoors[0].Audio.clip = Main.Instance.DoorMove;
            this.OutDoorDoors[0].Audio.Play();
          }
          this.OutDoorDoors[0].Locked = false;
          this.OutDoorDoors[1].Locked = false;
          this.OutDoorDoors[0].OpenDoor();
          this.OutDoorDoors[1].OpenDoor();
          this.EnableOnMission.SetActive(true);
          this.LockOnMission[0].CloseDoor();
          this.LockOnMission[1].CloseDoor();
          this.LockOnMission[0].Locked = true;
          this.LockOnMission[1].Locked = true;
          Main.Instance.MainThreads.Add(new Action(this.Goal2));
        })
      });
    }))))));
  }

  public void Goal2()
  {
    if ((double) Main.Instance.Player.transform.position.y - (double) this.HardTut.FirstGuard.transform.position.y >= 0.10000000149011612 || (double) Main.Instance.Player.transform.position.y - (double) this.HardTut.FirstGuard.transform.position.y <= -0.10000000149011612 || (double) Vector2.Distance(new Vector2(Main.Instance.Player.transform.position.x, Main.Instance.Player.transform.position.z), new Vector2(this.HardTut.FirstGuard.transform.position.x, this.HardTut.FirstGuard.transform.position.z)) >= 2.0)
      return;
    this.CompleteGoal(2);
    Main.Instance.MainThreads.Remove(new Action(this.Goal2));
    this.AddGoal(3, true);
    this.MedWorldOpen();
  }

  public void MedWorldOpen()
  {
    Main.RunInNextFrame((Action) (() => Main.RunInNextFrame((Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("Don't you dare trying to escape, I'll shoot you on the spot", this.VoiceLines[3], (Action) (() =>
    {
      Main.Instance.GameplayMenu.EndChat();
      this.RoomCellDoor.Locked = false;
      this.RoomCellDoor.OpenDoor();
      this.HardTut.FirstGuard.StartScheduleTask(new Person.ScheduleTask()
      {
        IDName = "dance1",
        ActionPlace = this.Guard_CellSpot,
        OnArrive = (Action) (() =>
        {
          this.HardTut.FirstGuard.transform.position = this.Guard_CellSpot.position;
          this.HardTut.FirstGuard.transform.eulerAngles = this.Guard_CellSpot.eulerAngles;
          this.EnterCellTrigger.SetActive(true);
          Main.Instance.CanSaveFlags_add("Hard_Listen2");
        })
      });
    }), this.HardTut.FirstGuard)))));
  }

  public void PlayerEnteredCellRoom()
  {
    this.RoomCellDoor.CloseDoor();
    this.RoomCellDoor.Locked = true;
    this.EnterCellTrigger.SetActive(false);
    this.Club2Music.volume = 0.1f;
    Main.Instance.GameplayMenu.DisplaySubtitle("Here's how this works", this.VoiceLines[5], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("You'll dance in the poles until a client requests you", this.VoiceLines[6], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("After the client is tired of you, you get paid", this.VoiceLines[7], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("Once you've earned 100 Bitch notes, you can come back home", this.VoiceLines[8], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("Enjoy your day", this.VoiceLines[9], (Action) (() =>
    {
      Main.Instance.GameplayMenu.EndChat();
      this.UsePoleTimer = UnityEngine.Random.Range(20f, 30f);
      Main.Instance.CanSaveFlags_remove("Hard_Listen2");
      this.CompleteGoal(3);
      this.AddGoal(4, true);
      Main.Instance.MainThreads.Add(new Action(this.Goal4));
      this.Club2Music.volume = 1f;
      this.HardTut.FirstGuard.navMesh.stoppingDistance = 1f;
      this.HardTut.FirstGuard.StartScheduleTask(new Person.ScheduleTask()
      {
        IDName = "dance_wait",
        ActionPlace = this.GuardClubWaitSpot,
        OnArrive = (Action) (() =>
        {
          this.HardTut.FirstGuard.transform.position = this.GuardClubWaitSpot.position;
          this.HardTut.FirstGuard.transform.eulerAngles = this.GuardClubWaitSpot.eulerAngles;
        })
      });
    }), this.HardTut.FirstGuard)), this.HardTut.FirstGuard)), this.HardTut.FirstGuard)), this.HardTut.FirstGuard)), this.HardTut.FirstGuard);
  }

  public void Goal4()
  {
    this.UsePoleTimer -= Time.deltaTime;
    if ((double) this.UsePoleTimer >= 0.0)
      return;
    this.CompleteGoal(4);
    this.AddGoal(5, true);
    Main.Instance.MainThreads.Remove(new Action(this.Goal4));
    Main.Instance.MainThreads.Add(new Action(this.Goal5));
    this.UsePoleTimer = UnityEngine.Random.Range(10f, 20f);
    this.RoomCellDoor.Locked = false;
    this.RoomCellDoor.OpenDoor();
  }

  public void Goal5()
  {
    if (!Main.Instance.Player.Interacting || !Main.Instance.Player.InteractingWith.name.StartsWith("DancePole"))
      return;
    this.UsePoleTimer -= Time.deltaTime;
    if ((double) this.UsePoleTimer >= 0.0)
      return;
    Main.Instance.CanSaveFlags_add("HardDanceClient");
    this.Client = this.PossibleClients[UnityEngine.Random.Range(0, this.PossibleClients.Count)];
    Main.Instance.MainThreads.Remove(new Action(this.Goal5));
    this.Client.State = Person_State.Work;
    Person.ScheduleTask _task = new Person.ScheduleTask()
    {
      IDName = "clientrequest",
      ActionPlace = Main.Instance.Player.InteractingWith.ReferenceSpots[0],
      OnArrive = (Action) (() =>
      {
        this.CompleteGoal(5);
        this.AddGoal(6, true);
        this.ClientArrivedAtRoom = false;
        Main.Instance.MainThreads.Add(new Action(this.Goal6));
        this.UsePoleTimer = 0.0f;
        if ((UnityEngine.Object) Main.Instance.Player.InteractingWith != (UnityEngine.Object) null)
          Main.Instance.Player.InteractingWith.StopInteracting(Main.Instance.Player);
        Main.Instance.GameplayMenu.DisplaySubtitle("Hey you, come with me", this.VoiceLines[10], (Action) (() =>
        {
          Main.Instance.GameplayMenu.EndChat();
          Main.RunInNextFrame((Action) (() => this.Client.StartScheduleTask(new Person.ScheduleTask()
          {
            IDName = "clientsex",
            ActionPlace = this.RoomSexSpot,
            OnArrive = (Action) (() => this.ClientArrivedAtRoom = true)
          })), 2);
        }));
      })
    };
    this.Client.StartScheduleTask(_task);
    Main.RunInNextFrame((Action) (() =>
    {
      if (!this.Client.CurrentTaskIsNull())
        return;
      this.Client.StartScheduleTask(_task);
    }), 2);
    Main.RunInNextFrame((Action) (() =>
    {
      if (!this.Client.CurrentTaskIsNull())
        return;
      this.Client.StartScheduleTask(_task);
    }), 5);
    Main.RunInNextFrame((Action) (() =>
    {
      if (!this.Client.CurrentTaskIsNull())
        return;
      this.Client.StartScheduleTask(_task);
    }), 20);
    Main.RunInNextFrame((Action) (() =>
    {
      if (!this.Client.CurrentTaskIsNull())
        return;
      this.Client.transform.position = Main.Instance.Player.InteractingWith.ReferenceSpots[0].position;
      this.CompleteGoal(5);
      this.AddGoal(6, true);
      this.ClientArrivedAtRoom = false;
      Main.Instance.MainThreads.Add(new Action(this.Goal6));
      this.UsePoleTimer = 0.0f;
      Main.Instance.GameplayMenu.DisplaySubtitle("Hey you, come with me", this.VoiceLines[10], (Action) (() =>
      {
        Main.Instance.GameplayMenu.EndChat();
        Main.RunInNextFrame((Action) (() => this.Client.StartScheduleTask(new Person.ScheduleTask()
        {
          IDName = "clientsex",
          ActionPlace = this.RoomSexSpot,
          OnArrive = (Action) (() => this.ClientArrivedAtRoom = true)
        })), 2);
      }));
    }), 50);
  }

  public void Goal6()
  {
    if (!this.ClientArrivedAtRoom || (double) Main.Instance.Player.transform.position.y - (double) this.Client.transform.position.y >= 0.10000000149011612 || (double) Main.Instance.Player.transform.position.y - (double) this.Client.transform.position.y <= -0.10000000149011612 || (double) Vector2.Distance(new Vector2(Main.Instance.Player.transform.position.x, Main.Instance.Player.transform.position.z), new Vector2(this.Client.transform.position.x, this.Client.transform.position.z)) >= 2.0)
      return;
    this.CompleteGoal(6);
    Main.Instance.MainThreads.Remove(new Action(this.Goal6));
    Main.Instance.MainThreads.Add(new Action(this.Goal6_2));
    this._sex = Main.Instance.SexScene.SpawnSexScene(4, 0, this.Client, Main.Instance.Player, canControl: false);
    this._sex.On_ClothingToggle(false);
    this._sex.TimerForRandomPoseChange = true;
    this._sex.TimerMax = 10f;
    this._sex.TimerPoseChange = this._sex.TimerMax;
    Main.Instance.SexScene.CanExitSexScene = false;
    Main.Instance.SexScene.SpeedSlider.value = Main.Instance.SexScene.SpeedSlider.maxValue;
  }

  public void Goal6_2()
  {
    this.UsePoleTimer += Time.deltaTime;
    if ((double) this.UsePoleTimer <= 30.0)
      return;
    this.UsePoleTimer = 0.0f;
    Main.Instance.MainThreads.Remove(new Action(this.Goal6_2));
    this.CompleteGoal(6);
    Main.Instance.SexScene.EndSexScene();
    Main.Instance.SexScene.CanExitSexScene = true;
    this.Client.State = Person_State.Free;
    this.Client.CompleteScheduleTask(true);
    this.Client = (Person) null;
    Main.Instance.CanSaveFlags_remove("HardDanceClient");
    Main.Instance.GameplayMenu.ShowNotification("(J) Level up Perks to earn more Bitch notes $");
    Main.Instance.GameplayMenu.ShowNotification("Received 50 Bitch Notes");
    Main.Instance.Player.Money += 50;
    if (Main.Instance.Player.Money >= 100)
    {
      this.AddGoal(7, true);
      this.Goal7Trigger.SetActive(true);
    }
    else
    {
      this.AddGoal(5, true);
      this.UsePoleTimer = UnityEngine.Random.Range(10f, 20f);
      Main.Instance.MainThreads.Add(new Action(this.Goal5));
      this.UsePoleTimer = UnityEngine.Random.Range(10f, 20f);
    }
  }

  public void Goal7()
  {
    Main.Instance.GameplayMenu.ShowNotification($"Removed {Main.Instance.Player.Money.ToString()} Bitch notes");
    Main.Instance.Player.Money = 0;
    Main.Instance.Player.AddMoveBlocker("HardDanceListen2");
    Main.Instance.GameplayMenu.DisplaySubtitle("You're done for today, go back to your cell and sleep", this.VoiceLines[0], (Action) (() =>
    {
      Main.Instance.Player.RemoveMoveBlocker("HardDanceListen2");
      Main.Instance.MainThreads.Add(new Action(this.Goal8));
      Main.Instance.GameplayMenu.EndChat();
      this.HardTut.FirstGuard.StartScheduleTask(new Person.ScheduleTask()
      {
        IDName = "machine",
        ActionPlace = this.HardTut.SexMission.SexMachineFirstGuard.NavMeshInteractSpot,
        OnArrive = (Action) (() => this.HardTut.SexMission.SexMachineFirstGuard.Interact(this.HardTut.FirstGuard))
      });
    }), this.HardTut.FirstGuard);
  }

  public void Goal8()
  {
    if ((UnityEngine.Object) Main.Instance.Player.CurrentZone == (UnityEngine.Object) this.HardTut.PlayerCell && (UnityEngine.Object) Main.Instance.Player.CurrentZone != (UnityEngine.Object) this._prevZone)
      Main.Instance.GameplayMenu.ShowNotification("X to sleep");
    this._prevZone = Main.Instance.Player.CurrentZone;
    if (!((UnityEngine.Object) Main.Instance.Player.CurrentZone == (UnityEngine.Object) this.HardTut.PlayerCell) || !Main.Instance.Player._IsSleeping)
      return;
    Main.Instance.Player.Energy = Main.Instance.Player.EnergyMax;
    this.HardTut.FirstGuard.Energy = this.HardTut.FirstGuard.EnergyMax;
    Main.Instance.MainThreads.Remove(new Action(Main.Instance.Player.Sleeping));
    Main.Instance.Player.Interacting = false;
    Main.Instance.Player.AddMoveBlocker("Hard_SexEndDay");
    Main.Instance.Player.Anim.Play("FloorSleep1");
    Main.Instance.MainThreads.Remove(new Action(this.Goal8));
    this.CompleteGoal(7);
    this.CompleteMission();
    this.HardTut.FirstGuard.CompleteScheduleTask(false);
    this.HardTut.FirstGuard.CurrentScheduleTask = (Person.ScheduleTask) null;
    if ((UnityEngine.Object) this.HardTut.FirstGuard.InteractingWith != (UnityEngine.Object) null)
      this.HardTut.FirstGuard.InteractingWith.StopInteracting();
    this.HardTut.FirstGuard.AddMoveBlocker("Hard_SexEndDay");
    this.HardTut.CellDoor.CloseDoor();
    this.HardTut.CellDoor.Locked = true;
    Main.Instance.GameplayMenu.TheScreenFader.FadeOut(4f, (Action) (() => Main.RunInNextFrame((Action) (() =>
    {
      Main.Instance.GameplayMenu.TheScreenFader.FadeIn(1f);
      Main.Instance.Player.RemoveMoveBlocker("Hard_SexEndDay");
      this.HardTut.FirstGuard.transform.position = this.HardTut.GuardSpotOutsideCellNewDay.position;
      this.HardTut.FirstGuard.RemoveMoveBlocker("Hard_SexEndDay");
      this.HardTut.SleepInNightTime();
      Main.Instance.CurrentArea = (BL_MapArea) null;
      Main.Instance.CapturedBuilding1_Area.OnEnter();
    }), 3)));
  }

  public void PlayerTryingToEscape()
  {
    for (int index = 0; index < Main.Instance.SpawnedPeople.Count; ++index)
    {
      if ((UnityEngine.Object) Main.Instance.SpawnedPeople[index] != (UnityEngine.Object) null && (UnityEngine.Object) Main.Instance.SpawnedPeople[index].PersonType != (UnityEngine.Object) null && Main.Instance.SpawnedPeople[index].PersonType.ThisType == Person_Type.Army)
        Main.Instance.SpawnedPeople[index].StartFighting(Main.Instance.Player);
    }
  }
}
