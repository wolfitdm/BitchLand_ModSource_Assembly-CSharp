// Decompiled with JetBrains decompiler
// Type: Mis_Mines
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Mis_Mines : Mission
{
  public Transform StorageGuardPlace;
  public Person MineStorageGuard;
  public Interactible StorageGuardInt;
  public AudioClip[] VoiceLines;
  public AudioClip[] VoiceLines_End;
  public int_Lockable[] EntranceDoors;
  public int_Lockable[] ExitDoors;
  public int TotalResourcesGiven;
  public int TotalResourcesToGive;
  public GameObject SexRoomStuff;
  public bool SecondTime;
  private bool ShownEnd;
  public Transform[] EndSpots;
  public Transform ItemsSpot;
  public float FeedTimer;

  public override void InitMission()
  {
    base.InitMission();
    Main.Instance.MainThreads.Add(new Action(this.SpawnMineStorageGuard_InNextFrame));
    this.EntranceDoors[0].Locked = false;
    this.EntranceDoors[1].Locked = false;
    this.CurrentGoal = this.Goals[0];
    if (!this.CurrentGoal.Completed)
    {
      Main.Instance.MainThreads.Add(new Action(this.Goal0));
    }
    else
    {
      this.EntranceDoors[0].Locked = true;
      this.EntranceDoors[1].Locked = true;
      this.CurrentGoal = this.Goals[1];
      if (!this.CurrentGoal.Completed)
      {
        Main.Instance.MainThreads.Add(new Action(this.Goal1));
      }
      else
      {
        this.CurrentGoal = this.Goals[2];
        if (this.CurrentGoal.Completed)
        {
          this.ExitDoors[0].Locked = false;
          this.ExitDoors[1].Locked = false;
          this.CurrentGoal = this.Goals[3];
          if (this.CurrentGoal.Completed)
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
    if (!((UnityEngine.Object) Main.Instance.Player.CurrentHat != (UnityEngine.Object) null) || !((UnityEngine.Object) Main.Instance.Player.CurrentBackpack != (UnityEngine.Object) null))
      return;
    for (int index = 0; index < Main.Instance.Player.WeaponInv.weapons.Count; ++index)
    {
      if ((UnityEngine.Object) Main.Instance.Player.WeaponInv.weapons[index] != (UnityEngine.Object) null && Main.Instance.Player.WeaponInv.weapons[index].GetComponent<Weapon>().auto == Auto.PickAxe)
      {
        this.CompleteGoal(0);
        Main.Instance.MainThreads.Remove(new Action(this.Goal0));
        this.AddGoal(1, true);
        Main.Instance.MainThreads.Add(new Action(this.Goal1));
        this.EntranceDoors[0].Locked = true;
        this.EntranceDoors[1].Locked = true;
        break;
      }
    }
  }

  public void Goal1()
  {
    if (!((UnityEngine.Object) Main.Instance.Player.CurrentHat != (UnityEngine.Object) null) || !Main.Instance.Player.CurrentHat.GetComponent<HelmetWithLamp>().MainLight.enabled)
      return;
    this.CompleteGoal(1);
    Main.Instance.MainThreads.Remove(new Action(this.Goal1));
    this.AddGoal(2, true);
  }

  public void SpawnMineStorageGuard(Person person) => this.MineStorageGuard = person;

  public void SpawnMineStorageGuard_InNextFrame()
  {
    Debug.LogError((object) nameof (SpawnMineStorageGuard_InNextFrame));
    this.MineStorageGuard.AddMoveBlocker("StorageGuard");
    this.MineStorageGuard.transform.position = this.StorageGuardPlace.position;
    this.MineStorageGuard.transform.rotation = this.StorageGuardPlace.rotation;
    this.MineStorageGuard.DirtySkin = true;
    UnityEngine.Object.Destroy((UnityEngine.Object) this.MineStorageGuard.ThisPersonInt);
    if ((UnityEngine.Object) this.StorageGuardInt == (UnityEngine.Object) null)
    {
      this.StorageGuardInt = this.MineStorageGuard.gameObject.AddComponent<Interactible>();
      this.StorageGuardInt.DefaultInteractIcon = 12;
      this.StorageGuardInt.InteractIcon = 12;
      this.StorageGuardInt.InteractText = "Give Resources";
      this.StorageGuardInt.InteractBlockers.Clear();
      this.StorageGuardInt.CanInteract = true;
      this.StorageGuardInt.ScriptToRun_OnInteract = new MonoBehaviour[1]
      {
        (MonoBehaviour) this
      };
      this.StorageGuardInt.ScriptFunctionToRun_OnInteract = new string[1]
      {
        "InteractStorageGuard"
      };
    }
    Main.Instance.MainThreads.Remove(new Action(this.SpawnMineStorageGuard_InNextFrame));
  }

  public void InteractStorageGuard()
  {
    this.StorageGuardInt.StopInteracting();
    this.StorageGuardInt.InteractBlockers.Clear();
    this.StorageGuardInt.CanInteract = true;
    if ((UnityEngine.Object) Main.Instance.Player.CurrentBackpack == (UnityEngine.Object) null)
    {
      Main.Instance.GameplayMenu.DisplaySubtitle("Well?  Why your hands empty?  Go mine some shit", this.VoiceLines[1], (Action) (() =>
      {
        Main.Instance.GameplayMenu.EndChat();
        Main.Instance.Player.Interacting = false;
        Main.Instance.Player.InteractingWith = (Interactible) null;
        this.StorageGuardInt.InteractBlockers.Clear();
        this.StorageGuardInt.CanInteract = true;
      }), this.MineStorageGuard);
      this.StorageGuardInt.InteractBlockers.Clear();
      this.StorageGuardInt.CanInteract = true;
    }
    else
    {
      List<GameObject> ofItems = Main.Instance.Player.CurrentBackpack.ThisStorage.GetOfItems("IronOre", "GoldOre", "CoalOre", "ConcreteOre");
      if (ofItems.Count == 0)
      {
        Main.Instance.GameplayMenu.DisplaySubtitle("Well?  Why your hands empty?  Go mine some shit", this.VoiceLines[1], (Action) (() =>
        {
          Main.Instance.GameplayMenu.EndChat();
          Main.Instance.Player.Interacting = false;
          Main.Instance.Player.InteractingWith = (Interactible) null;
          this.StorageGuardInt.InteractBlockers.Clear();
          this.StorageGuardInt.CanInteract = true;
        }), this.MineStorageGuard);
        this.StorageGuardInt.InteractBlockers.Clear();
        this.StorageGuardInt.CanInteract = true;
      }
      else
      {
        this.TotalResourcesGiven += ofItems.Count;
        for (int index = 0; index < ofItems.Count; ++index)
        {
          Main.Instance.Player.CurrentBackpack.ThisStorage.RemoveItem(ofItems[index]);
          UnityEngine.Object.Destroy((UnityEngine.Object) ofItems[index]);
        }
        if (this.SecondTime)
        {
          if (this.TotalResourcesGiven >= this.TotalResourcesToGive)
          {
            Main.Instance.GameplayMenu.DisplaySubtitle("That's good for today, go rest", this.VoiceLines[2], (Action) (() =>
            {
              Main.Instance.GameplayMenu.EndChat();
              Main.Instance.Player.Interacting = false;
              Main.Instance.Player.InteractingWith = (Interactible) null;
            }), this.MineStorageGuard);
            this.StorageGuardInt.AddBlocker("ENDHARDMODE");
            this.CompleteGoal(4);
            this.ExitDoors[0].Locked = false;
            this.ExitDoors[1].Locked = false;
          }
          else
          {
            Main.Instance.GameplayMenu.ShowNotification($"Gave {this.TotalResourcesGiven.ToString()}/{this.TotalResourcesToGive.ToString()} Resource ores");
            Main.Instance.GameplayMenu.DisplaySubtitle("Good but not enough yet", this.VoiceLines[0], (Action) (() =>
            {
              Main.Instance.GameplayMenu.EndChat();
              Main.Instance.Player.Interacting = false;
              Main.Instance.Player.InteractingWith = (Interactible) null;
              this.StorageGuardInt.InteractBlockers.Clear();
              this.StorageGuardInt.CanInteract = true;
            }), this.MineStorageGuard);
            this.StorageGuardInt.InteractBlockers.Clear();
            this.StorageGuardInt.CanInteract = true;
          }
        }
        else if (this.TotalResourcesGiven >= 30)
        {
          Main.Instance.GameplayMenu.DisplaySubtitle("That's good for today, go rest", this.VoiceLines[2], (Action) (() =>
          {
            Main.Instance.GameplayMenu.EndChat();
            Main.Instance.Player.Interacting = false;
            Main.Instance.Player.InteractingWith = (Interactible) null;
          }), this.MineStorageGuard);
          this.StorageGuardInt.AddBlocker("EndMines1");
          this.CompleteGoal(2);
          this.AddGoal(3, true);
          this.PrepareForExit();
          (Main.Instance.AllMissions[0] as Mis_HardTutorial).SetNightTime();
          this.ExitDoors[0].Locked = false;
          this.ExitDoors[1].Locked = false;
          Main.Instance.SaveGame(true);
        }
        else
        {
          Main.Instance.GameplayMenu.ShowNotification($"Gave {this.TotalResourcesGiven.ToString()}/30 Resource ores");
          Main.Instance.GameplayMenu.DisplaySubtitle("Good but not enough yet", this.VoiceLines[0], (Action) (() =>
          {
            Main.Instance.GameplayMenu.EndChat();
            Main.Instance.Player.Interacting = false;
            Main.Instance.Player.InteractingWith = (Interactible) null;
            this.StorageGuardInt.InteractBlockers.Clear();
            this.StorageGuardInt.CanInteract = true;
          }), this.MineStorageGuard);
          this.StorageGuardInt.InteractBlockers.Clear();
          this.StorageGuardInt.CanInteract = true;
        }
      }
    }
  }

  public void OnEndBuildTrigger()
  {
    if (this.ShownEnd)
      return;
    this.ShownEnd = true;
    Main.Instance.GameplayMenu.ShowMessageBox("Using First person mode here makes it easier to see things (TAB key)");
  }

  public void PrepareForExit()
  {
  }

  public void InteractWithExitDoor()
  {
    if (this.ExitDoors[0].Locked)
      return;
    this.ExitDoors[0].Locked = true;
    this.ExitDoors[1].Locked = true;
    this.EntranceDoors[0].Locked = true;
    this.EntranceDoors[1].Locked = true;
    GameObject[] array = Main.Instance.Player.WeaponInv.weapons.ToArray();
    Main.Instance.Player.WeaponInv.DropAllWeapons();
    for (int index = 0; index < array.Length; ++index)
      UnityEngine.Object.Destroy((UnityEngine.Object) array[index]);
    Main.Instance.Player.States[2] = true;
    Main.Instance.Player.SetBodyTexture();
    Main.RunInNextFrame(new Action(this.InteractWithExitDoor2), 6);
  }

  public void InteractWithExitDoor2()
  {
    this.ExitDoors[0].Locked = false;
    this.ExitDoors[1].Locked = false;
    if (this.SecondTime)
    {
      Main.Instance.Player.AddMoveBlocker("Cutscene_Hardmode_punishment");
      Main.Instance.Player.Anim.Play("AGIA_Idle_generic_01");
      Main.Instance.Player.UserControl.ThirdCamPositionType = bl_ThirdPersonUserControl.e_ThirdCamPositionType.Back;
      Mis_HardTutorial _hardmis = (Mis_HardTutorial) Main.Instance.AllMissions[0];
      Main.RunInSeconds((Action) (() =>
      {
        Main.Instance.Player.UserControl.FirstPerson = false;
        Main.Instance.GameplayMenu.DisplaySubtitle("Congratulations, clap clap", this.VoiceLines_End[0], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("Sarah is here to pick you up like you just finished a school day", this.VoiceLines_End[1], (Action) (() =>
        {
          for (int index = 0; index < Main.Instance.Player.EquippedClothes.Count; ++index)
          {
            if (Main.Instance.Player.EquippedClothes[index].name == "LeftNipRotors")
            {
              UnityEngine.Object.Destroy((UnityEngine.Object) Main.Instance.Player.UndressClothe(Main.Instance.Player.EquippedClothes[index]));
              break;
            }
          }
          Main.Instance.GameplayMenu.ShowNotification("Equipped Left nipple piercing");
          Main.Instance.Player.DressClothe(Main.Instance.Prefabs_Any[14]);
          Main.Instance.GameplayMenu.DisplaySubtitle("Lemme give you a little souvenier", this.VoiceLines_End[2], (Action) (() =>
          {
            Main.Instance.GameplayMenu.DisplaySubtitle("After this go wash yourself you piece'a shit", this.VoiceLines_End[3], new Action(Main.Instance.GameplayMenu.EndChat), _hardmis.FirstGuard);
            Main.Instance.GameplayMenu.TheScreenFader.FadeOut(5f, (Action) (() => Main.RunInNextFrame((Action) (() =>
            {
              Main.Instance.GameplayMenu.TheScreenFader.FadeIn(1f);
              _hardmis.DanceMission.OutDoorDoors[0].Locked = false;
              _hardmis.DanceMission.OutDoorDoors[0].OpenDoor();
              _hardmis.DanceMission.OutDoorDoors[1].Locked = false;
              _hardmis.DanceMission.OutDoorDoors[1].OpenDoor();
              Main.Instance.Player._Rigidbody.isKinematic = true;
              Main.Instance.Player.AddMoveBlocker("hard end");
              Main.Instance.Player.transform.SetPositionAndRotation(this.EndSpots[0].position, this.EndSpots[0].rotation);
              _hardmis.FirstGuard.AddMoveBlocker("hard end");
              _hardmis.FirstGuard.transform.SetPositionAndRotation(this.EndSpots[1].position, this.EndSpots[1].rotation);
              Main.Instance.CityCharacters.Sarah.AddMoveBlocker("hard end");
              Main.Instance.CityCharacters.Sarah.transform.SetPositionAndRotation(this.EndSpots[2].position, this.EndSpots[2].rotation);
              Main.Instance.CityCharacters.Sarah.transform.parent = (Transform) null;
              Main.Instance.CityCharacters.Sarah.gameObject.SetActive(true);
              List<Dressable> dressableList = new List<Dressable>();
              dressableList.AddRange((IEnumerable<Dressable>) Main.Instance.Player.EquippedClothes);
              for (int index = 0; index < dressableList.Count; ++index)
              {
                switch (dressableList[index].BodyPart)
                {
                  case DressableType.Any:
                    if (dressableList[index].name == "Piercing (Left Nipple)")
                      break;
                    goto case DressableType.Shoes;
                  case DressableType.Shoes:
                  case DressableType.Pants:
                  case DressableType.Top:
                  case DressableType.UnderwearTop:
                  case DressableType.UnderwearLower:
                  case DressableType.Garter:
                  case DressableType.Socks:
                  case DressableType.Hat:
                  case DressableType.BackPack:
                    if ((UnityEngine.Object) dressableList[index] != (UnityEngine.Object) null)
                    {
                      GameObject gameObject = Main.Instance.Player.UndressClothe(dressableList[index]);
                      if ((UnityEngine.Object) gameObject != (UnityEngine.Object) null)
                      {
                        UnityEngine.Object.Destroy((UnityEngine.Object) gameObject);
                        break;
                      }
                      break;
                    }
                    break;
                }
              }
              Main.Instance.Player.DyedHairColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
              Main.Instance.Player.RefreshColors();
              Main.RunInSeconds((Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("I hope they weren't too harsh in there", this.VoiceLines_End[5], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("Don't worry. We feed her well", this.VoiceLines_End[6], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("Come visit anytime, bye bye", this.VoiceLines_End[7], (Action) (() =>
              {
                Main.Instance.GameplayMenu.EndChat();
                _hardmis.Escape(0);
              }), _hardmis.FirstGuard)), _hardmis.FirstGuard)), Main.Instance.CityCharacters.Sarah)), 2f);
            }), 2)));
          }), _hardmis.FirstGuard);
        }), _hardmis.FirstGuard)), _hardmis.FirstGuard);
      }), 2f);
    }
    else
    {
      this.CompleteGoal(3);
      Main.Instance.Player.AddMoveBlocker("Cutscene_Hardmode_punishment");
      Main.Instance.Player.Anim.Play("AGIA_Idle_generic_01");
      Main.Instance.Player.UserControl.ThirdCamPositionType = bl_ThirdPersonUserControl.e_ThirdCamPositionType.Back;
      Mis_HardTutorial _hardmis = (Mis_HardTutorial) Main.Instance.AllMissions[0];
      Main.RunInSeconds((Action) (() =>
      {
        Main.Instance.Player.UserControl.FirstPerson = false;
        Main.Instance.GameplayMenu.DisplaySubtitle("What a great day of work, innit?", this.VoiceLines[6], (Action) (() =>
        {
          if ((UnityEngine.Object) Main.Instance.Player.CurrentHat != (UnityEngine.Object) null || (UnityEngine.Object) Main.Instance.Player.CurrentBackpack != (UnityEngine.Object) null || (UnityEngine.Object) Main.Instance.Player.WeaponInv.CurrentWeapon != (UnityEngine.Object) null)
            Main.Instance.GameplayMenu.DisplaySubtitle("And why the fuck do you still have that gear on you?", this.VoiceLines[7], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("You should have taken that off still inside there", this.VoiceLines[8], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("Here's your punishment, no sex tonight", this.VoiceLines[9], (Action) (() =>
            {
              Main.Instance.GameplayMenu.EndChat();
              Main.Instance.GameplayMenu.TheScreenFader.FadeOut(4f, (Action) (() =>
              {
                _hardmis.PlayerIntoPunishmentDummy();
                Main.Instance.GameplayMenu.TheScreenFader.FadeIn(1f);
                Main.RunInSeconds((Action) (() => Main.Instance.GameplayMenu.TheScreenFader.FadeOut(4f, (Action) (() =>
                {
                  if ((UnityEngine.Object) Main.Instance.Player.CurrentHat != (UnityEngine.Object) null)
                    Main.Instance.Player.UndressClothe(Main.Instance.Player.CurrentHat).transform.position = this.ItemsSpot.position;
                  if ((UnityEngine.Object) Main.Instance.Player.CurrentBackpack != (UnityEngine.Object) null)
                    Main.Instance.Player.UndressClothe((Dressable) Main.Instance.Player.CurrentBackpack).transform.position = this.ItemsSpot.position;
                  _hardmis.PlayerIntoPunishmentDummy_Hide();
                  Main.Instance.Player.SleepOnFloor();
                  Main.Instance.Player.UserControl.ThirdCamPositionType = Main.Instance.Player.UserControl.ThirdCamPositionTypeOnSettings;
                  Main.Instance.GameplayMenu.TheScreenFader.FadeIn(1f);
                  (Main.Instance.AllMissions[0] as Mis_HardTutorial).StartNewDay();
                  Main.Instance.CurrentArea = (BL_MapArea) null;
                  Main.Instance.CapturedBuilding1_Area.OnEnter();
                  Main.Instance.Player.RemoveMoveBlocker("Cutscene_Hardmode_punishment");
                  Main.Instance.Player.Anim.enabled = true;
                }))), 10f);
              }));
            }), _hardmis.FirstGuard)), _hardmis.FirstGuard)), _hardmis.FirstGuard);
          else
            Main.Instance.GameplayMenu.DisplaySubtitle("Here's your reward", this.VoiceLines[10], (Action) (() =>
            {
              Main.Instance.GameplayMenu.EndChat();
              Main.Instance.GameplayMenu.TheScreenFader.FadeOut(4f, (Action) (() =>
              {
                Main.Instance.GameplayMenu.TheScreenFader.blackScreen.color = Color.clear;
                Main.Instance.Player.transform.position = _hardmis.PlayerCellSexSpot.position;
                Main.Instance.Player.transform.rotation = _hardmis.PlayerCellSexSpot.rotation;
                _hardmis.FirstGuard.transform.position = _hardmis.PlayerCellSexSpot.position;
                _hardmis.FirstGuard.transform.rotation = _hardmis.PlayerCellSexSpot.rotation;
                Main.Instance.CapturedBuilding1_Area.OnEnter();
                Main.Instance.Player.RemoveMoveBlocker("Cutscene_Hardmode_punishment");
                Main.Instance.Player.Anim.enabled = true;
                _hardmis.UpperFloor.OnTriggerEnter(Main.Instance.Player.MainCol);
                Main.Instance.SexScene.SpawnSexScene(4, 0, _hardmis.FirstGuard, Main.Instance.Player, canControl: false).On_ClothingToggle(true);
                Main.Instance.SexScene.CanExitSexScene = false;
                Main.Instance.SexScene.SpeedSlider.value = Main.Instance.SexScene.SpeedSlider.maxValue;
                Main.RunInSeconds((Action) (() =>
                {
                  Main.Instance.SexScene.EndSexScene();
                  Main.Instance.GameplayMenu.Root.SetActive(true);
                  Main.Instance.GameplayMenu.TheScreenFader.blackScreen.color = Color.black;
                  _hardmis.FirstGuard.transform.position = _hardmis.GuardSpotOutsideCellNewDay.position;
                  _hardmis.SleepInNightTime();
                  Main.Instance.CurrentArea = (BL_MapArea) null;
                  Main.Instance.CapturedBuilding1_Area.OnEnter();
                }), 15f);
              }));
            }), _hardmis.FirstGuard);
        }), _hardmis.FirstGuard);
      }), 2f);
    }
  }

  public void GuardSex()
  {
    this.FeedTimer -= Time.deltaTime;
    Main.Instance.GameplayMenu.WeaponReloadSlider.fillAmount = this.FeedTimer / 20f;
    if ((double) this.FeedTimer >= 0.0)
      return;
    Main.Instance.GameplayMenu.WeaponReloadUI.SetActive(false);
    Main.Instance.GameplayMenu.WeaponReloadUI.transform.SetParent(Main.Instance.GameplayMenu.transform);
    Main.Instance.MainThreads.Remove(new Action(this.GuardSex));
    Main.Instance.SexScene.EndSexScene();
    Main.Instance.Player.Energy = Main.Instance.Player.EnergyMax / 2f;
    Main.Instance.Player.SleepOnFloor();
  }
}
