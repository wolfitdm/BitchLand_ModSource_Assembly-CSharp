// Decompiled with JetBrains decompiler
// Type: Mis_Army
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class Mis_Army : Mission
{
  public AudioClip[] VoiceLines;
  public AudioClip[] ZeaVoiceLines;
  public GameObject MinigunPrefab;
  public Person War;
  public Person Zea;
  public Transform War_DefaultSpot;
  public string War_MainIdleAnim;
  public Transform War_ShootingRangeSpot;
  public Transform War_CrawlSpot;
  public Health Sack;
  public GameObject CrawlTrigger;
  public bool RoomsTrigger;
  public GameObject EnableOnMission;
  public GameObject EnableOnMission_part2;
  public Transform ZeaPosition;
  public GameObject Trigger_Zea;
  public Mis_Army2 ArmyMission2;
  public GameObject[] ZeaClothes;
  public GameObject[] FemaleLockerItems;
  public GameObject[] MaleLockerItems;
  private Weapon _SelectedWeapon;
  public bl_ThirdPersonUserControl.MeleeWeaponOptions _CurrentMeleeStance;
  public Transform ZeaSitPlace;
  public Interactible ZeaSit;
  public bool CameNaked;
  public Int_Storage Locker27;
  public GameObject LockerArea;

  public override void InitMission()
  {
    base.InitMission();
    if ((UnityEngine.Object) this.Zea != (UnityEngine.Object) null)
      this.Zea.gameObject.SetActive(false);
    this.CurrentGoal = this.Goals[0];
    if (!this.CurrentGoal.Completed)
    {
      Main.Instance.CanSaveFlags.Add("ArmyMissionGoal1");
      Main.Instance.CanSaveFlags = Main.Instance.CanSaveFlags;
      this.EnableOnMission.SetActive(true);
      this.War.StartScheduleTask(new Person.ScheduleTask()
      {
        IDName = "0",
        RunTo = true,
        ActionPlace = this.War_ShootingRangeSpot,
        OnArrive = (Action) (() =>
        {
          this.War.transform.SetPositionAndRotation(this.War_ShootingRangeSpot.position, this.War_ShootingRangeSpot.rotation);
          Main.Instance.GameplayMenu.DisplaySubtitle("Grab a gun", this.VoiceLines[2], new Action(this.War.ThisPersonInt.EndTheChat), this.War);
          Main.Instance.MainThreads.Add(new Action(this.Goal0));
        })
      });
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
              this.CurrentGoal = this.Goals[5];
              if (!this.CurrentGoal.Completed)
              {
                Main.Instance.MainThreads.Add(new Action(this.Goal5));
              }
              else
              {
                this.CurrentGoal = this.Goals[6];
                if (!this.CurrentGoal.Completed)
                {
                  Main.Instance.MainThreads.Add(new Action(this.Goal6));
                }
                else
                {
                  this.CurrentGoal = this.Goals[7];
                  if (!this.CurrentGoal.Completed)
                  {
                    Main.Instance.MainThreads.Add(new Action(this.Goal7));
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
                      if (!this.CurrentGoal.Completed)
                      {
                        Main.Instance.MainThreads.Add(new Action(this.Goal9));
                      }
                      else
                      {
                        this.CurrentGoal = this.Goals[10];
                        if (!this.CurrentGoal.Completed)
                        {
                          Main.Instance.MainThreads.Add(new Action(this.Goal10));
                        }
                        else
                        {
                          this.CurrentGoal = this.Goals[11];
                          if (!this.CurrentGoal.Completed)
                          {
                            Main.Instance.MainThreads.Add(new Action(this.Goal11));
                          }
                          else
                          {
                            this.CurrentGoal = this.Goals[12];
                            if (this.CurrentGoal.Completed)
                            {
                              this.CurrentGoal = this.Goals[13];
                              if (this.CurrentGoal.Completed)
                              {
                                this.CurrentGoal = this.Goals[14];
                                if (!this.CurrentGoal.Completed)
                                {
                                  this.InitZea();
                                }
                                else
                                {
                                  this.Trigger_Zea.SetActive(false);
                                  Main.Instance.CanSaveFlags.Add("ArmyMissionGoal2");
                                  Main.Instance.CanSaveFlags = Main.Instance.CanSaveFlags;
                                  this.CurrentGoal = this.Goals[15];
                                  if (!this.CurrentGoal.Completed)
                                  {
                                    this.InitZea();
                                    this.EnableOnMission_part2.SetActive(true);
                                  }
                                  else
                                  {
                                    this.CurrentGoal = this.Goals[16];
                                    if (this.CurrentGoal.Completed)
                                    {
                                      this.CurrentGoal = this.Goals[17];
                                      if (this.CurrentGoal.Completed)
                                      {
                                        this.CurrentGoal = this.Goals[18];
                                        if (this.CurrentGoal.Completed)
                                        {
                                          this.CurrentGoal = this.Goals[19];
                                          if (this.CurrentGoal.Completed)
                                          {
                                            Main.Instance.CanSaveFlags.Remove("ArmyMissionGoal2");
                                            Main.Instance.CanSaveFlags = Main.Instance.CanSaveFlags;
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

  public void InitZea()
  {
    this.EnableOnMission.SetActive(false);
    Main.Instance.CanSaveFlags_remove("ArmyMissionGoal1");
    if ((UnityEngine.Object) this.Zea.InteractingWith != (UnityEngine.Object) null)
      this.Zea.InteractingWith.StopInteracting();
    if (this.Zea.HavingSex)
      this.Zea.HavingSex_Scene.SafeSexEnd();
    this.Zea.State = Person_State.Work;
    this.Zea.ThisPersonInt.AddBlocker("Quest");
    this.Zea.AddMoveBlocker("ArmyQuest");
    Main.RunInNextFrame((Action) (() =>
    {
      this.Zea.navMesh.enabled = false;
      this.Zea.gameObject.SetActive(false);
      this.Zea.navMesh.enabled = false;
      Main.RunInNextFrame((Action) (() =>
      {
        this.Zea.transform.position = this.ZeaPosition.position;
        this.Zea.transform.rotation = this.ZeaPosition.rotation;
        this.Zea.gameObject.SetActive(true);
        this.Trigger_Zea.SetActive(true);
        this.Zea.ChangeUniform(this.ZeaClothes);
        this.Zea.States[26] = false;
        this.Zea.States[33] = false;
        this.Zea.States[12] = false;
        this.Zea.States[13] = false;
        this.Zea.States[14] = false;
        this.Zea.States[15] = false;
        this.Zea.States[16] = false;
        this.Zea.States[17] = false;
        this.Zea.States[18] = false;
        this.Zea.States[19] = false;
        this.Zea.States[23] = false;
        this.Zea.States[24] = false;
        this.Zea.States[25] = false;
        this.Zea.SetBodyTexture();
      }), 4);
    }), 4);
  }

  public void EnterBarracks()
  {
    this.Trigger_Zea.SetActive(false);
    Main.Instance.GameplayMenu.EnterChatWith(this.Zea, (MonoBehaviour) this, "Chat_Zea");
  }

  public void Goal0()
  {
    if (!((UnityEngine.Object) Main.Instance.Player.WeaponInv.CurrentWeapon != (UnityEngine.Object) null))
      return;
    Main.Instance.GameplayMenu.DisplaySubtitle("Shoot that Sack in the middle of the range", this.VoiceLines[3], new Action(this.War.ThisPersonInt.EndTheChat), this.War);
    this.CompleteGoal(0);
    Main.Instance.MainThreads.Remove(new Action(this.Goal0));
    this.AddGoal(1, true);
    Main.Instance.MainThreads.Add(new Action(this.Goal1));
  }

  public void Goal1()
  {
    if (!this.Sack.dead)
      return;
    Main.Instance.GameplayMenu.DisplaySubtitle("Grab another gun", this.VoiceLines[4], new Action(this.War.ThisPersonInt.EndTheChat), this.War);
    this.CompleteGoal(1);
    Main.Instance.MainThreads.Remove(new Action(this.Goal1));
    this.AddGoal(2, true);
    Main.Instance.MainThreads.Add(new Action(this.Goal2));
  }

  public void Goal2()
  {
    if (!((UnityEngine.Object) Main.Instance.Player.WeaponInv.weapons[0] != (UnityEngine.Object) null) || !((UnityEngine.Object) Main.Instance.Player.WeaponInv.weapons[1] != (UnityEngine.Object) null))
      return;
    this._SelectedWeapon = Main.Instance.Player.WeaponInv.CurrentWeapon;
    Main.Instance.GameplayMenu.DisplaySubtitle("Switch to your other weapon", this.VoiceLines[5], new Action(this.War.ThisPersonInt.EndTheChat), this.War);
    this.CompleteGoal(2);
    Main.Instance.MainThreads.Remove(new Action(this.Goal2));
    this.AddGoal(3, true);
    Main.Instance.MainThreads.Add(new Action(this.Goal3));
  }

  public void Goal3()
  {
    if (!((UnityEngine.Object) Main.Instance.Player.WeaponInv.CurrentWeapon != (UnityEngine.Object) null) || !((UnityEngine.Object) Main.Instance.Player.WeaponInv.CurrentWeapon != (UnityEngine.Object) this._SelectedWeapon))
      return;
    Main.Instance.GameplayMenu.DisplaySubtitle("Drop all your weapons", this.VoiceLines[6], new Action(this.War.ThisPersonInt.EndTheChat), this.War);
    this.CompleteGoal(3);
    Main.Instance.MainThreads.Remove(new Action(this.Goal3));
    this.AddGoal(4, true);
    Main.Instance.MainThreads.Add(new Action(this.Goal4));
  }

  public void Goal4()
  {
    if (!((UnityEngine.Object) Main.Instance.Player.WeaponInv.weapons[0] == (UnityEngine.Object) null) || !((UnityEngine.Object) Main.Instance.Player.WeaponInv.weapons[1] == (UnityEngine.Object) null))
      return;
    Main.Instance.GameplayMenu.DisplaySubtitle("Okay, near the boxes, pickup a shovel", this.VoiceLines[7], new Action(this.War.ThisPersonInt.EndTheChat), this.War);
    this.CompleteGoal(4);
    Main.Instance.MainThreads.Remove(new Action(this.Goal4));
    this.AddGoal(5, true);
    Main.Instance.MainThreads.Add(new Action(this.Goal5));
  }

  public void Goal5()
  {
    if (!((UnityEngine.Object) Main.Instance.Player.WeaponInv.CurrentWeapon != (UnityEngine.Object) null) || Main.Instance.Player.WeaponInv.CurrentWeapon.type != WeaponType.Melee)
      return;
    this._CurrentMeleeStance = Main.Instance.Player.UserControl.MeleeWeaponOption;
    Main.Instance.GameplayMenu.DisplaySubtitle("Switch attack stances", this.VoiceLines[8], new Action(this.War.ThisPersonInt.EndTheChat), this.War);
    this.CompleteGoal(5);
    Main.Instance.MainThreads.Remove(new Action(this.Goal5));
    this.AddGoal(6, true);
    Main.Instance.MainThreads.Add(new Action(this.Goal6));
  }

  public void Goal6()
  {
    if (Main.Instance.Player.UserControl.MeleeWeaponOption == this._CurrentMeleeStance)
      return;
    Main.Instance.GameplayMenu.DisplaySubtitle("Equip one of those helmets there", this.VoiceLines[9], new Action(this.War.ThisPersonInt.EndTheChat), this.War);
    this.CompleteGoal(6);
    Main.Instance.MainThreads.Remove(new Action(this.Goal6));
    this.AddGoal(7, true);
    Main.Instance.MainThreads.Add(new Action(this.Goal7));
  }

  public void Goal7()
  {
    if (!((UnityEngine.Object) Main.Instance.Player.CurrentHat != (UnityEngine.Object) null))
      return;
    Main.Instance.GameplayMenu.DisplaySubtitle("Drop the shovel and helmet from your inventory", this.VoiceLines[10], new Action(this.War.ThisPersonInt.EndTheChat), this.War);
    this.CompleteGoal(7);
    Main.Instance.MainThreads.Remove(new Action(this.Goal7));
    this.AddGoal(8, true);
    Main.Instance.MainThreads.Add(new Action(this.Goal8));
  }

  public void Goal8()
  {
    if (!((UnityEngine.Object) Main.Instance.Player.CurrentHat == (UnityEngine.Object) null) || !((UnityEngine.Object) Main.Instance.Player.WeaponInv.CurrentWeapon == (UnityEngine.Object) null))
      return;
    Main.Instance.GameplayMenu.DisplaySubtitle("Switch attack stance", this.VoiceLines[8], new Action(this.War.ThisPersonInt.EndTheChat), this.War);
    this.CompleteGoal(8);
    Main.Instance.MainThreads.Remove(new Action(this.Goal8));
    this.AddGoal(9, true);
    Main.Instance.MainThreads.Add(new Action(this.Goal9));
  }

  public void Goal9()
  {
    if (Main.Instance.Player.UserControl.MeleeOption == bl_ThirdPersonUserControl.MeleeOptions.None)
      return;
    this.CompleteGoal(9);
    Main.Instance.MainThreads.Remove(new Action(this.Goal9));
    this.AddGoal(10, true);
    Main.Instance.MainThreads.Add(new Action(this.Goal10));
  }

  public void Goal10()
  {
    if (Main.Instance.Player.UserControl.MeleeOption != bl_ThirdPersonUserControl.MeleeOptions.None)
      return;
    Main.Instance.GameplayMenu.DisplaySubtitle("Come this way", this.VoiceLines[1], new Action(this.War.ThisPersonInt.EndTheChat), this.War);
    this.War.StartScheduleTask(new Person.ScheduleTask()
    {
      IDName = "0",
      RunTo = true,
      ActionPlace = this.War_CrawlSpot,
      OnArrive = (Action) (() =>
      {
        this.War.transform.SetPositionAndRotation(this.War_CrawlSpot.position, this.War_CrawlSpot.rotation);
        Main.Instance.GameplayMenu.DisplaySubtitle("Crawl under this, and come out the other side", this.VoiceLines[11], new Action(this.War.ThisPersonInt.EndTheChat), this.War);
        this.AddGoal(11, true);
        Main.Instance.MainThreads.Add(new Action(this.Goal11));
      })
    });
    this.CompleteGoal(10);
    Main.Instance.MainThreads.Remove(new Action(this.Goal10));
  }

  public void Goal11()
  {
    if (Main.Instance.Player.UserControl.m_Character.StandState != bl_ThirdPersonCharacter.bl_StandState.Crawling)
      return;
    this.CompleteGoal(11);
    Main.Instance.MainThreads.Remove(new Action(this.Goal11));
    this.CrawlTrigger.SetActive(true);
    this.AddGoal(12, true);
  }

  public void Goal12()
  {
    this.CompleteGoal(12);
    this.CrawlTrigger.SetActive(false);
    this.RoomsTrigger = true;
    this.AddGoal(13, true);
    Main.Instance.MainThreads.Add(new Action(this.Goal13));
  }

  public void Goal13()
  {
    if (Main.Instance.Player.UserControl.m_Character.StandState != bl_ThirdPersonCharacter.bl_StandState.Standing)
      return;
    Main.Instance.GameplayMenu.DisplaySubtitle("Congrats, Go upstairs and get dressed with our uniform", this.VoiceLines[14], new Action(this.War.ThisPersonInt.EndTheChat), Main.Instance.Player);
    this.CompleteGoal(13);
    Main.Instance.MainThreads.Remove(new Action(this.Goal13));
    this.InitZea();
    this.AddGoal(14, true);
  }

  public void OnSpawn_Zea(Person person)
  {
    Main.Instance.CityCharacters.SetPerson(person);
    this.Zea = person;
    this.Zea.Favor = 100;
    this.Zea.transform.localScale = new Vector3(0.95f, 0.95f, 0.95f);
    this.Zea.gameObject.SetActive(false);
  }

  public void Init_War(Person person)
  {
    Main.Instance.CityCharacters.SetPerson(person);
    this.War = person;
    this.War.ThisPersonInt.StartTalkMono = (MonoBehaviour) this;
    this.War.ThisPersonInt.StartTalkFunc = "Chat_War";
    this.War.WeaponInv.PickupWeapon(UnityEngine.Object.Instantiate<GameObject>(this.MinigunPrefab));
    this.War.WeaponInv.startingWeaponIndex = 1;
    (this.War as Girl).PhisicsOnlyOnInSex = true;
    (this.War as Girl).GirlPhysics = false;
    this.War.A_Walking = "HumanoidWalk";
  }

  public void Chat_War()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person person = _gameplay.PersonChattingTo;
    _gameplay.RemoveAllChatOptions();
    _gameplay.AddChatOption("What's your name?", (Action) (() =>
    {
      Main.Instance.GameplayMenu.EnableMove();
      _gameplay.DisplaySubtitle("How the fuck did you forgot me!? Stop joking", this.VoiceLines[12], new Action(person.ThisPersonInt.EndTheChat), this.War);
    }));
    _gameplay.AddChatOption("You're hot, let's have sex", (Action) (() =>
    {
      Main.Instance.GameplayMenu.EnableMove();
      _gameplay.DisplaySubtitle("Not now", this.VoiceLines[13], new Action(person.ThisPersonInt.EndTheChat), this.War);
    }));
    if (!this.Goals[0].Completed)
      _gameplay.AddChatOption("I'd like to get basic training, and then work here", (Action) (() =>
      {
        if (Main.Instance.AllMissions[3].Goals[5].Completed && !Main.Instance.AllMissions[3].Goals[7].Completed)
        {
          Main.Instance.GameplayMenu.ShowNotification("Can't start this mission at this moment.  Advance in the [Stripclub] first.");
          Main.Instance.GameplayMenu.EnableMove();
        }
        else
        {
          Main.Instance.AllMissions[16].CompleteGoal(1);
          Main.Instance.GameplayMenu.DisplaySubtitle("Are you brain damaged!?  How the fuck did you forgot basic training?", this.VoiceLines[0], (Action) (() =>
          {
            Main.Instance.GameplayMenu.EnableMove();
            Main.Instance.AllMissions[1].CompleteGoal(5);
            Main.Instance.GameplayMenu.StartMission((Mission) this);
            Main.Instance.GameplayMenu.DisplaySubtitle("Come this way", this.VoiceLines[1], new Action(person.ThisPersonInt.EndTheChat), this.War);
          }), this.War);
        }
      }));
    _gameplay.SelectChatOption(0);
    Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
  }

  public void Chat_Zea()
  {
    UI_Gameplay gameplayMenu = Main.Instance.GameplayMenu;
    Person personChattingTo = gameplayMenu.PersonChattingTo;
    gameplayMenu.EnterChatWith(this.Zea, (MonoBehaviour) this, "Chat_Zea2");
    Main.Instance.Player.UserControl.FirstPerson = true;
    Main.Instance.Player.UserControl.LateUpdate();
    this.EnableOnMission_part2.SetActive(true);
    Main.Instance.CanSaveFlags.Add("ArmyMissionGoal2");
    Main.Instance.CanSaveFlags = Main.Instance.CanSaveFlags;
  }

  public void Chat_Zea2()
  {
    UI_Gameplay gameplayMenu = Main.Instance.GameplayMenu;
    bool flag = false;
    if (Main.Instance.GlobalVars.ContainsKey("MeetZea"))
      flag = bool.Parse(Main.Instance.GlobalVars["MeetZea"]);
    if (!flag)
      gameplayMenu.DisplaySubtitle("Hey Hi there!  I'm Zea, you're also new here?  Guess we're roommates then", this.ZeaVoiceLines[0], new Action(this.Chat_Zea3), this.Zea, e_BlendShapes.Smile);
    else
      gameplayMenu.DisplaySubtitle("Hey Hi there!  Looks like we're roommates here too", this.ZeaVoiceLines[1], new Action(this.Chat_Zea3), this.Zea, e_BlendShapes.Smile);
    this.Zea.PlayerKnowsName = true;
    this.Zea.ThisPersonInt.SetDefaultInteraction();
    Main.Instance.GlobalVars.Add("MeetZea", "True");
  }

  public void Chat_Zea3()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person person = _gameplay.PersonChattingTo;
    _gameplay.DisplaySubtitle("Your locker number is... 27!  Just next to mine", this.ZeaVoiceLines[2], (Action) (() => _gameplay.DisplaySubtitle("Get dressed at your locker and then come back down, we have a mission to go ASAPi!", this.ZeaVoiceLines[3], (Action) (() =>
    {
      _gameplay.RemoveAllChatOptions();
      _gameplay.SubtitleText.text = string.Empty;
      _gameplay.AddChatOption("It's ASAP, not ASAPi", (Action) (() =>
      {
        Main.Instance.GameplayMenu.EnableMove();
        _gameplay.DisplaySubtitle("But it sounds cuter like that", this.ZeaVoiceLines[4], new Action(person.ThisPersonInt.EndTheChat), this.Zea, e_BlendShapes.Smile);
        this.CompleteGoal(14);
        this.AddGoal(15, true);
        this.LockerArea.SetActive(true);
        this.Zea.RemoveMoveBlocker("ArmyQuest");
        this.Zea.navMesh.enabled = true;
        this.Zea.StartScheduleTask(new Person.ScheduleTask()
        {
          IDName = "ZeaSit",
          ActionPlace = this.ZeaSitPlace,
          OnArrive = (Action) (() =>
          {
            this.ZeaSit.Interact(this.Zea);
            this.RepositionZea();
          })
        });
      }));
      _gameplay.SelectChatOption(0);
      Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
    }), this.Zea, e_BlendShapes.Smile)), this.Zea, e_BlendShapes.Smug);
  }

  public void EnterLockerArea()
  {
    this.LockerArea.SetActive(false);
    this.CompleteGoal(15);
    this.AddGoal(16, true);
    this.Locker27.gameObject.SetActive(true);
    Main.Instance.MainThreads.Add(new Action(this.Goal16));
    if (!((UnityEngine.Object) Main.Instance.Player.CurrentTop == (UnityEngine.Object) null) || !((UnityEngine.Object) Main.Instance.Player.CurrentPants == (UnityEngine.Object) null))
    {
      this.CameNaked = false;
      Main.Instance.GameplayMenu.DisplaySubtitle("Before anything else, get undressed", this.ZeaVoiceLines[5], new Action(this.Zea.ThisPersonInt.EndTheChat), this.Zea);
    }
    else
      this.CameNaked = true;
  }

  public void Goal16()
  {
    if (!((UnityEngine.Object) Main.Instance.Player.CurrentTop == (UnityEngine.Object) null) || !((UnityEngine.Object) Main.Instance.Player.CurrentPants == (UnityEngine.Object) null))
      return;
    this.CompleteGoal(16);
    Main.Instance.MainThreads.Remove(new Action(this.Goal16));
    this.AddGoal(17, true);
    this.Locker27.gameObject.SetActive(true);
    this.Locker27.Locked = false;
    if (Main.Instance.Player is Girl)
    {
      for (int index = 0; index < this.FemaleLockerItems.Length; ++index)
        this.Locker27.AddItem(Main.Spawn(this.FemaleLockerItems[index]));
    }
    else
    {
      for (int index = 0; index < this.MaleLockerItems.Length; ++index)
        this.Locker27.AddItem(Main.Spawn(this.MaleLockerItems[index]));
    }
    this.RepositionZea();
    Main.Instance.GameplayMenu.DisplaySubtitle("Dress everything that's in the locker", this.ZeaVoiceLines[6], new Action(this.Zea.ThisPersonInt.EndTheChat), this.Zea);
  }

  public void RepositionZea() => this.Zea.transform.position = this.ZeaSit.transform.position;

  public void OnUseLocker()
  {
    if (this.CurrentGoal != this.Goals[17])
      return;
    this.CompleteGoal(17);
    this.AddGoal(18, true);
    Main.Instance.MainThreads.Add(new Action(this.Goal18));
    this.RepositionZea();
    Main.Instance.GameplayMenu.DisplaySubtitle("You can use my backpack", this.ZeaVoiceLines[7], new Action(this.Zea.ThisPersonInt.EndTheChat), this.Zea);
  }

  public void Goal18()
  {
    if (!((UnityEngine.Object) Main.Instance.Player.CurrentBackpack != (UnityEngine.Object) null))
      return;
    this.CompleteGoal(18);
    Main.Instance.MainThreads.Remove(new Action(this.Goal18));
    this.AddGoal(19, true);
    Main.Instance.MainThreads.Add(new Action(this.Goal19));
    if (this.CameNaked)
      return;
    this.RepositionZea();
    Main.Instance.GameplayMenu.DisplaySubtitle("You can put inside the backpack, the clothing you dropped", this.ZeaVoiceLines[8], new Action(this.Zea.ThisPersonInt.EndTheChat), this.Zea);
  }

  public void Goal19()
  {
    if (!this.CameNaked && (!((UnityEngine.Object) Main.Instance.Player.CurrentBackpack != (UnityEngine.Object) null) || Main.Instance.Player.CurrentBackpack.ThisStorage.StorageItems.Count == 0))
      return;
    this.CompleteGoal(19);
    Main.Instance.MainThreads.Remove(new Action(this.Goal19));
    this.EnableOnMission_part2.SetActive(false);
    Main.Instance.CanSaveFlags.Remove("ArmyMissionGoal2");
    Main.Instance.CanSaveFlags = Main.Instance.CanSaveFlags;
    this.CompleteMission();
    Main.Instance.GameplayMenu.StartMission((Mission) this.ArmyMission2);
    Main.Instance.GameplayMenu.DisplaySubtitle("Let's go!", this.ZeaVoiceLines[9], new Action(this.Zea.ThisPersonInt.EndTheChat), this.Zea);
  }
}
