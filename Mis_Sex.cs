// Decompiled with JetBrains decompiler
// Type: Mis_Sex
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class Mis_Sex : Mission
{
  public AudioClip[] VoiceLines;
  public Mis_HardTutorial HardTut;
  public Interactible[] SexChairs;
  public Interactible[] MultiToDisable;
  public Int_Door SexChairCellDoor;
  public Interactible SexMachineFirstGuard;
  public Interactible FirstPreparator;
  public Transform OutsideSpot;
  public bool SecondTime;
  public float SexTimer;
  private bool _DoorClosed;
  public GameObject ListenCol;
  public bl_HangZone _prevZone;

  public override void InitMission()
  {
    base.InitMission();
    this.SexChairCellDoor.Locked = true;
    this.CurrentGoal = this.Goals[0];
    if (!this.CurrentGoal.Completed)
    {
      if (!Main.Instance.MainThreads.Contains(new Action(this.Goal0)))
        Main.Instance.MainThreads.Add(new Action(this.Goal0));
    }
    else
    {
      this.FirstPreparator.PlayerCanInteract = false;
      this.SexChairCellDoor.Locked = false;
      this.CurrentGoal = this.Goals[1];
      if (!this.CurrentGoal.Completed)
      {
        Main.Instance.MainThreads.Add(new Action(this.Goal1));
      }
      else
      {
        this.SexChairCellDoor.Locked = true;
        for (int index = 0; index < this.SexChairs.Length; ++index)
          this.SexChairs[index].PlayerCanInteract = false;
        for (int index = 0; index < this.MultiToDisable.Length; ++index)
          this.MultiToDisable[index].PlayerCanInteract = false;
        this.CurrentGoal = this.Goals[2];
        if (!this.CurrentGoal.Completed)
        {
          this.HardTut.FirstGuard.StartScheduleTask(new Person.ScheduleTask()
          {
            IDName = "outside",
            ActionPlace = this.OutsideSpot,
            OnArrive = (Action) (() => Main.Instance.MainThreads.Add(new Action(this.ThreadWaitForplayer_sex2)))
          });
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
            this.CompletedMission = true;
            return;
          }
        }
      }
    }
    Main.Instance.GameplayMenu.DisplayGoal(this.CurrentGoal, true);
  }

  public void Goal0()
  {
    if (!this.FirstPreparator.BeingUsed)
      return;
    this.SexTimer += Time.deltaTime;
    Main.Instance.GameplayMenu.WeaponReloadSlider.fillAmount = this.SexTimer / 20f;
    if ((double) this.SexTimer <= 20.0)
      return;
    Main.Instance.GameplayMenu.WeaponReloadUI.SetActive(false);
    this.CompleteGoal(0);
    Main.Instance.GameplayMenu.DisplaySubtitle("Normally all this machine does, is get you hot and ready", this.VoiceLines[1], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("But you came just from sitting on it", this.VoiceLines[2], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("What a fucking slut", this.VoiceLines[3], (Action) (() =>
    {
      Main.Instance.GameplayMenu.EndChat();
      this.SexChairCellDoor.Locked = false;
      this.SexChairCellDoor.OpenDoor();
      Main.RunInSeconds((Action) (() =>
      {
        this.SexTimer = 0.0f;
        this.AddGoal(1, true);
        Main.Instance.MainThreads.Add(new Action(this.Goal1));
        if (this.FirstPreparator.BeingUsed)
          this.FirstPreparator.StopInteracting();
        this.FirstPreparator.PlayerCanInteract = false;
        Main.Instance.GameplayMenu.DisplaySubtitle("Put your ass in there and enjoy yourself", this.VoiceLines[12], new Action(Main.Instance.GameplayMenu.EndChat), this.HardTut.FirstGuard);
      }), 2f);
    }), this.HardTut.FirstGuard)), this.HardTut.FirstGuard)), this.HardTut.FirstGuard);
    Main.Instance.MainThreads.Remove(new Action(this.Goal0));
  }

  public void Goal1()
  {
    this.HardTut.FirstGuard.Masturbating = false;
    for (int index1 = 0; index1 < this.SexChairs.Length; ++index1)
    {
      if (this.SexChairs[index1].BeingUsed)
      {
        if (!this._DoorClosed)
        {
          this._DoorClosed = true;
          this.SexChairCellDoor.CloseDoor();
          this.SexChairCellDoor.Locked = true;
          Main.Instance.GameplayMenu.WeaponReloadUI.SetActive(true);
        }
        this.HardTut.FirstGuard.Masturbating = true;
        this.HardTut.FirstGuard.transform.LookAt(Main.Instance.Player.transform);
        this.SexTimer += Time.deltaTime;
        Main.Instance.GameplayMenu.WeaponReloadSlider.fillAmount = this.SexTimer / 60f;
        if ((double) this.SexTimer > 60.0)
        {
          Main.Instance.GameplayMenu.WeaponReloadUI.SetActive(false);
          this.CompleteGoal(1);
          for (int index2 = 0; index2 < this.SexChairs.Length; ++index2)
          {
            this.SexChairs[index2].StopInteracting();
            this.SexChairs[index2].PlayerCanInteract = false;
          }
          for (int index3 = 0; index3 < this.MultiToDisable.Length; ++index3)
            this.MultiToDisable[index3].PlayerCanInteract = false;
          this.HardTut.FirstGuard.Masturbating = false;
          Main.Instance.GameplayMenu.DisplaySubtitle("Good enough for today", this.VoiceLines[4], (Action) (() =>
          {
            Main.Instance.GameplayMenu.EndChat();
            this._DoorClosed = true;
            this.SexChairCellDoor.Locked = false;
            this.SexChairCellDoor.OpenDoor();
            this.ListenCol.SetActive(true);
            Main.Instance.CanSaveFlags_add("HardQuestSex");
          }), this.HardTut.FirstGuard);
          Main.Instance.MainThreads.Remove(new Action(this.Goal1));
          break;
        }
      }
    }
  }

  public void aftermachine()
  {
    this.ListenCol.SetActive(false);
    Main.Instance.Player.AddMoveBlocker("HardMode_Listen1");
    Main.Instance.GameplayMenu.DisplaySubtitle("In the future when you'll build your own city", this.VoiceLines[5], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("make sure to make the sex machine room bigger than this one", this.VoiceLines[6], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("and then put me working there", this.VoiceLines[7], (Action) (() =>
    {
      this.AddGoal(2, true);
      Main.Instance.GameplayMenu.DisplaySubtitle("Anyway, Come with me", this.VoiceLines[9], (Action) (() =>
      {
        Main.Instance.CanSaveFlags_remove("HardQuestSex");
        Main.Instance.GameplayMenu.EndChat();
        Main.Instance.Player.RemoveMoveBlocker("HardMode_Listen1");
        this.HardTut.FirstGuard.StartScheduleTask(new Person.ScheduleTask()
        {
          IDName = "outside",
          ActionPlace = this.OutsideSpot,
          OnArrive = (Action) (() => Main.Instance.MainThreads.Add(new Action(this.ThreadWaitForplayer_sex2)))
        });
      }), this.HardTut.FirstGuard);
    }), this.HardTut.FirstGuard)), this.HardTut.FirstGuard)), this.HardTut.FirstGuard);
  }

  public void ThreadWaitForplayer_sex2()
  {
    if ((double) Main.Instance.Player.transform.position.y - (double) this.HardTut.FirstGuard.transform.position.y >= 0.10000000149011612 || (double) Main.Instance.Player.transform.position.y - (double) this.HardTut.FirstGuard.transform.position.y <= -0.10000000149011612 || (double) Vector2.Distance(new Vector2(Main.Instance.Player.transform.position.x, Main.Instance.Player.transform.position.z), new Vector2(this.HardTut.FirstGuard.transform.position.x, this.HardTut.FirstGuard.transform.position.z)) >= 3.0)
      return;
    this.CompleteGoal(2);
    this._DoorClosed = true;
    this.SexChairCellDoor.CloseDoor();
    this.SexChairCellDoor.Locked = true;
    Main.Instance.GameplayMenu.DisplaySubtitle("Feel free to hang out here for the rest of the day", this.VoiceLines[10], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("Once you wanna end the day, just go back to your cell and sleep", this.VoiceLines[11], (Action) (() =>
    {
      Main.Instance.GameplayMenu.EndChat();
      this.AddGoal(3);
      Main.Instance.MainThreads.Add(new Action(this.Goal3));
      this.HardTut.FirstGuard.StartScheduleTask(new Person.ScheduleTask()
      {
        IDName = "machine",
        ActionPlace = this.SexMachineFirstGuard.NavMeshInteractSpot,
        OnArrive = (Action) (() => this.SexMachineFirstGuard.Interact(this.HardTut.FirstGuard))
      });
    }), this.HardTut.FirstGuard)), this.HardTut.FirstGuard);
    Main.Instance.MainThreads.Remove(new Action(this.ThreadWaitForplayer_sex2));
  }

  public void ActivateChair()
  {
    if (this.SexChairCellDoor.Open)
    {
      this.SexChairCellDoor.Interact(this.HardTut.FirstGuard);
      this.SexChairCellDoor.Locked = true;
    }
    this.CompleteGoal(0);
  }

  public void FirstTalk()
  {
    Main.Instance.GameplayMenu.DisplaySubtitle("This is a Preparator stand. Use it", this.VoiceLines[0], (Action) (() =>
    {
      Main.Instance.GameplayMenu.EndChat();
      if (!Main.Instance.MainThreads.Contains(new Action(this.Goal0)))
        Main.Instance.MainThreads.Add(new Action(this.Goal0));
      Main.Instance.GameplayMenu.WeaponReloadUI.SetActive(true);
      Main.Instance.GameplayMenu.WeaponReloadSlider.fillAmount = 0.0f;
    }), this.HardTut.FirstGuard);
  }

  public void Goal3()
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
    Main.Instance.MainThreads.Remove(new Action(this.Goal3));
    this.CompleteGoal(3);
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
}
