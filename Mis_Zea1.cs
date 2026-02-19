// Decompiled with JetBrains decompiler
// Type: Mis_Zea1
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class Mis_Zea1 : Mission
{
  [Header(" --------- Zea")]
  public AudioClip[] VoiceLines;
  public GameObject HangingTshirt;
  public Interactible AnaSpot;
  public Transform[] SpawnSpots;
  public Transform[] GoSpots;
  public int CurrentIndex;
  public GameObject[] ZeaClothes;
  public GameObject[] AnaClothes;
  public GameObject[] ZeaClothesAfter;
  public Transform[] SleepSpot;
  private float _FollowTimer;
  private bool _HasSaid;
  public GameObject[] DisableDuring;
  public AudioSource ExtMusic;
  public GameObject SlumsExitBlockers;
  public GameObject VendingExitBlockers;

  public void StartIfItCan()
  {
    Debug.LogError((object) "StartIfItCan()");
    if (!this.MissionCanStart())
      return;
    Main.Instance.GameplayMenu.StartMission((Mission) this);
  }

  public override void InitMission()
  {
    Debug.LogError((object) "Mis_Zea1 InitMission()");
    if (!this.MissionCanStart() || this._Inited)
      return;
    base.InitMission();
    this.CurrentGoal = this.Goals[0];
    if (!this.CurrentGoal.Completed)
    {
      this.OnStartMission();
    }
    else
    {
      this.CurrentGoal = this.Goals[1];
      if (!this.CurrentGoal.Completed)
      {
        this.PrepareZea();
      }
      else
      {
        this.CurrentGoal = this.Goals[2];
        if (!this.CurrentGoal.Completed)
        {
          this.PrepareZea();
        }
        else
        {
          this.HangingTshirt.SetActive(true);
          this.CompletedMission = true;
        }
      }
    }
    if (!this.CompletedMission)
    {
      Main.Instance.GameplayMenu.DisplayGoal(this.CurrentGoal, true);
      Main.Instance.GameplayMenu.MapTrackers[0] = Main.Instance.CityCharacters.Zea.transform;
    }
    else
    {
      (Main.Instance.AllMissions[11] as Mis_Mines_Med).StartIfItCan();
      if (Main.Instance.AllMissions[12].CompletedMission)
        return;
      Main.Instance.AllMissions[12].InitMission();
    }
  }

  public void OnStartMission()
  {
    this.PrepareZea();
    Main.Instance.CityCharacters.Zea.transform.position = this.SpawnSpots[0].position;
    Main.Instance.CityCharacters.Zea.transform.rotation = this.SpawnSpots[0].rotation;
    for (int index = 0; index < this.DisableDuring.Length; ++index)
      this.DisableDuring[index].SetActive(false);
  }

  public void PrepareZea()
  {
    Person zea = Main.Instance.CityCharacters.Zea;
    if (zea.HavingSex)
      zea.HavingSex_Scene.SafeSexEnd();
    if ((UnityEngine.Object) zea.InteractingWith != (UnityEngine.Object) null)
      zea.InteractingWith.StopInteracting();
    zea.State = Person_State.Work;
    zea.AddMoveBlocker("QuestTshirt");
    zea.ThisPersonInt.StartTalkFunc = "ChatZea";
    zea.ThisPersonInt.StartTalkMono = (MonoBehaviour) this;
    zea.gameObject.SetActive(true);
    zea.WorkScheduleTasks.Clear();
    zea.CurrentScheduleTask = (Person.ScheduleTask) null;
    zea.navMesh.destination = zea.transform.position;
    zea.A_Standing = "PistolIdle";
    zea.ChangeUniform(this.ZeaClothes);
    zea.States[26] = false;
    zea.States[33] = false;
    zea.States[12] = false;
    zea.States[13] = false;
    zea.States[14] = false;
    zea.States[15] = false;
    zea.States[16] = false;
    zea.States[17] = false;
    zea.States[18] = false;
    zea.States[19] = false;
    zea.States[23] = false;
    zea.States[24] = false;
    zea.States[25] = false;
    zea.DirtySkin = false;
    zea.SetBodyTexture();
    zea.WeaponInv.SetActiveWeapon(1);
  }

  public void ChatZea()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person person = Main.Instance.CityCharacters.Zea;
    if (Main.Instance.AllMissions[11].Goals[0].Completed && !Main.Instance.AllMissions[11].CompletedMission)
    {
      _gameplay.DisplaySubtitle("Finish your other mission first lol", this.VoiceLines[36], new Action(person.ThisPersonInt.EndTheChat), person);
    }
    else
    {
      switch (this.CurrentGoalIndex)
      {
        case 1:
        case 2:
        case 3:
        case 4:
        case 5:
          _gameplay.DisplaySubtitle("Keep looking", this.VoiceLines[5], (Action) (() => person.ThisPersonInt.EndTheChat()), person);
          break;
        case 6:
          if ((UnityEngine.Object) Main.Instance.Player.CurrentBackpack != (UnityEngine.Object) null)
          {
            _gameplay.DisplaySubtitle("Gimme a shirt, in your hand", this.VoiceLines[35], (Action) (() => person.ThisPersonInt.EndTheChat()), person);
            break;
          }
          _gameplay.DisplaySubtitle("Keep looking", this.VoiceLines[5], (Action) (() => person.ThisPersonInt.EndTheChat()), person);
          break;
        case 7:
          if (!this.Goals[6].Completed)
            break;
          GameObject _choosen = Main.Instance.Player.Storage_Hands.StorageItems[0];
          Main.Instance.Player.Storage_Hands.RemoveItem(_choosen);
          _choosen.SetActive(false);
          Main.Instance.MainThreads.Remove(new Action(_choosen.GetComponentInChildren<int_PickupToHand>().HoldingThread));
          Main.Instance.GameplayMenu.QLeave.SetActive(false);
          Main.Instance.GameplayMenu.QLeave.transform.Find("a/Text").GetComponent<Text>().text = "Leave";
          Main.Instance.MainThreads.Remove(new Action(this.Goal6));
          person.ThisPersonInt.AddBlocker("quest");
          this.CompleteGoal(7);
          Main.Instance.GameplayMenu.DisplaySubtitle("This one's fine whatever, give me the tshirt now", this.VoiceLines[26], (Action) (() =>
          {
            this.AnaSpot.StopInteracting();
            GameObject gameObject = Main.Instance.CityCharacters.Ana.UndressClothe(Main.Instance.CityCharacters.Ana.CurrentTop);
            person.WeaponInv.SetActiveWeapon(1);
            gameObject.GetComponentInChildren<int_PickupToHand>().EquipToHand(person);
            Main.Instance.GameplayMenu.DisplaySubtitle(" ", this.VoiceLines[25], (Action) (() =>
            {
              Main.Instance.CityCharacters.Ana.DressClothe(_choosen);
              Main.Instance.GameplayMenu.DisplaySubtitle("How dare you rub those dirty tits all over my tshirt", this.VoiceLines[27], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("Let's go", this.VoiceLines[4], (Action) (() =>
              {
                person.ThisPersonInt.EndTheChat();
                this.AddGoal(8, true);
                Main.Instance.CityCharacters.Zea.StartScheduleTask(new Person.ScheduleTask()
                {
                  IDName = "zeatshirtfinal",
                  RunTo = true,
                  ActionPlace = this.GoSpots[6],
                  OnArrive = (Action) (() =>
                  {
                    person.transform.position = this.GoSpots[6].position;
                    person.transform.rotation = this.GoSpots[6].rotation;
                    Main.Instance.MainThreads.Add(new Action(this.Goal7));
                    person.CompleteScheduleTask();
                  })
                });
              }), person)), person);
            }), person);
          }), person);
          break;
        case 8:
          break;
        default:
          if (!this._Inited)
            Main.Instance.GameplayMenu.StartMission((Mission) this);
          this.CompleteGoal(0);
          Main.Instance.CanSaveFlags_add("Zea1Mission");
          _gameplay.DisplaySubtitle("Heyyo, I need your help", this.VoiceLines[0], (Action) (() => _gameplay.DisplaySubtitle("I've heard someone in the city found a band tshirt from back then", this.VoiceLines[1], (Action) (() => _gameplay.DisplaySubtitle("That tshirt was already old before the bombs, so it's crazy it's still around", this.VoiceLines[2], (Action) (() => _gameplay.DisplaySubtitle("I MUST have that tshirt before it get's turned into an ass cleaning torn cloth", this.VoiceLines[3], (Action) (() => _gameplay.DisplaySubtitle("Let's go!", this.VoiceLines[4], (Action) (() =>
          {
            this.AddGoal(1, true);
            person.ThisPersonInt.EndTheChat();
            person.ResetAllShapes();
            person.RemoveMoveBlocker("QuestTshirt");
            person.A_Standing = "lookaround";
            person.LookAtPlayer.Disable = true;
            Main.Instance.CityCharacters.Zea.StartScheduleTask(new Person.ScheduleTask()
            {
              IDName = "zeatshirt1",
              RunTo = true,
              ActionPlace = this.GoSpots[0],
              OnArrive = (Action) (() =>
              {
                person.transform.position = this.GoSpots[0].position;
                person.transform.rotation = this.GoSpots[0].rotation;
                Main.RunInSeconds((Action) (() =>
                {
                  Main.Instance.CityCharacters.Zea.navMesh.stoppingDistance = 1.5f;
                  this._FollowTimer = 0.0f;
                  Main.Instance.CityCharacters.Zea.StartScheduleTask(new Person.ScheduleTask()
                  {
                    IDName = "zeatshirt2",
                    RunTo = true,
                    ActionPlace = Main.Instance.Player.transform,
                    WhileGoing = (Action) (() =>
                    {
                      this._FollowTimer += Time.deltaTime;
                      if ((double) this._FollowTimer <= 1.0)
                        return;
                      this._FollowTimer = 0.0f;
                      Main.Instance.CityCharacters.Zea.SetDestination(Main.Instance.Player.transform);
                    }),
                    OnArrive = (Action) (() =>
                    {
                      Main.Instance.CityCharacters.Zea.transform.LookAt(Main.Instance.Player.transform);
                      if ((UnityEngine.Object) Main.Instance.SexScene.PlayerSex != (UnityEngine.Object) null)
                        Main.Instance.SexScene.PlayerSex.SafeSexEnd();
                      Main.Instance.OpenMenu("Gameplay");
                      Main.Instance.GameplayMenu.EnterChatWith(Main.Instance.CityCharacters.Zea, (MonoBehaviour) this, "ZeaChat2");
                    })
                  });
                }), 8f);
              })
            });
          }), person)), person, e_BlendShapes.Smug)), person)), person, e_BlendShapes.None)), person, e_BlendShapes.Smug);
          break;
      }
    }
  }

  public void ZeaChat2()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person person = Main.Instance.CityCharacters.Zea;
    this.CompleteGoal(1);
    person.A_Standing = "PistolIdle";
    person.LookAtPlayer.Disable = false;
    if ((UnityEngine.Object) (Main.Instance.AllMissions[3] as Mis_Prost).BarMusic != (UnityEngine.Object) null)
      (Main.Instance.AllMissions[3] as Mis_Prost).BarMusic.volume = 0.05f;
    _gameplay.DisplaySubtitle("I don't see it here, let's go to the plaza, I'll follow you, quick", this.VoiceLines[6], (Action) (() =>
    {
      person.A_Standing = "lookaround";
      person.LookAtPlayer.Disable = true;
      person.ThisPersonInt.EndTheChat();
      this.AddGoal(2, true);
      if ((UnityEngine.Object) (Main.Instance.AllMissions[3] as Mis_Prost).BarMusic != (UnityEngine.Object) null)
        (Main.Instance.AllMissions[3] as Mis_Prost).BarMusic.volume = 1f;
      Main.RunInSeconds((Action) (() =>
      {
        person.RandActionTimer = 0.0f;
        person.StartScheduleTask(new Person.ScheduleTask()
        {
          IDName = "zeaFollowPlayer",
          ActionPlace = Main.Instance.Player.transform,
          OnArrive = (Action) (() =>
          {
            if ((double) Vector3.Distance(Main.Instance.Player.transform.position, this.GoSpots[1].position) < 5.0)
            {
              person.SetDestination(this.GoSpots[1]);
              Main.Instance.CityCharacters.Zea.StartScheduleTask(new Person.ScheduleTask()
              {
                IDName = "zeatshirt3",
                RunTo = true,
                ActionPlace = this.GoSpots[1],
                OnArrive = (Action) (() =>
                {
                  person.transform.position = this.GoSpots[1].position;
                  person.transform.rotation = this.GoSpots[1].rotation;
                  Main.RunInSeconds((Action) (() =>
                  {
                    Main.Instance.CityCharacters.Zea.navMesh.stoppingDistance = 1.5f;
                    this._FollowTimer = 0.0f;
                    Main.Instance.CityCharacters.Zea.StartScheduleTask(new Person.ScheduleTask()
                    {
                      IDName = "zeatshirt4",
                      RunTo = true,
                      ActionPlace = Main.Instance.Player.transform,
                      WhileGoing = (Action) (() =>
                      {
                        this._FollowTimer += Time.deltaTime;
                        if ((double) this._FollowTimer <= 1.0)
                          return;
                        this._FollowTimer = 0.0f;
                        Main.Instance.CityCharacters.Zea.SetDestination(Main.Instance.Player.transform);
                      }),
                      OnArrive = (Action) (() =>
                      {
                        Main.Instance.CityCharacters.Zea.transform.LookAt(Main.Instance.Player.transform);
                        person.A_Standing = "PistolIdle";
                        person.LookAtPlayer.Disable = false;
                        if ((UnityEngine.Object) Main.Instance.SexScene.PlayerSex != (UnityEngine.Object) null)
                          Main.Instance.SexScene.PlayerSex.SafeSexEnd();
                        Main.Instance.OpenMenu("Gameplay");
                        this.CompleteGoal(2);
                        _gameplay.DisplaySubtitle("Darn it, not here too, let's check the vending street", this.VoiceLines[7], (Action) (() => _gameplay.DisplaySubtitle("But, let's get there safely throu High street", this.VoiceLines[8], (Action) (() =>
                        {
                          this._HasSaid = false;
                          person.A_Standing = "lookaround";
                          person.LookAtPlayer.Disable = true;
                          person.ThisPersonInt.EndTheChat();
                          this.AddGoal(3, true);
                          person.RandActionTimer = 0.0f;
                          person.StartScheduleTask(new Person.ScheduleTask()
                          {
                            IDName = "zeaFollowPlayer3",
                            ActionPlace = Main.Instance.Player.transform,
                            OnArrive = (Action) (() =>
                            {
                              if ((double) Vector3.Distance(Main.Instance.Player.transform.position, this.GoSpots[2].position) < 20.0)
                              {
                                person.SetDestination(this.GoSpots[2]);
                                Main.Instance.CityCharacters.Zea.StartScheduleTask(new Person.ScheduleTask()
                                {
                                  IDName = "zeatshirt5",
                                  RunTo = true,
                                  ActionPlace = this.GoSpots[2],
                                  OnArrive = (Action) (() =>
                                  {
                                    person.transform.position = this.GoSpots[2].position;
                                    person.transform.rotation = this.GoSpots[2].rotation;
                                    Main.RunInSeconds((Action) (() =>
                                    {
                                      Main.Instance.CityCharacters.Zea.navMesh.stoppingDistance = 1.5f;
                                      this._FollowTimer = 0.0f;
                                      Main.Instance.CityCharacters.Zea.StartScheduleTask(new Person.ScheduleTask()
                                      {
                                        IDName = "zeatshirt6",
                                        RunTo = true,
                                        ActionPlace = Main.Instance.Player.transform,
                                        WhileGoing = (Action) (() =>
                                        {
                                          this._FollowTimer += Time.deltaTime;
                                          if ((double) this._FollowTimer <= 1.0)
                                            return;
                                          this._FollowTimer = 0.0f;
                                          Main.Instance.CityCharacters.Zea.SetDestination(Main.Instance.Player.transform);
                                        }),
                                        OnArrive = (Action) (() =>
                                        {
                                          Main.Instance.CityCharacters.Zea.transform.LookAt(Main.Instance.Player.transform);
                                          this.VendingExitBlockers.SetActive(true);
                                          if ((UnityEngine.Object) Main.Instance.SexScene.PlayerSex != (UnityEngine.Object) null)
                                            Main.Instance.SexScene.PlayerSex.SafeSexEnd();
                                          Main.Instance.OpenMenu("Gameplay");
                                          this.CompleteGoal(3);
                                          _gameplay.DisplaySubtitle("Holy fucking shit it's not here too!", this.VoiceLines[9], (Action) (() =>
                                          {
                                            person.WeaponInv.SetActiveWeapon(0);
                                            Main.Instance.Player.PersonAudio.pitch = 1f;
                                            Main.Instance.Player.PersonAudio.PlayOneShot(this.VoiceLines[24]);
                                            _gameplay.DisplaySubtitle("We'll have to check in the slums then", this.VoiceLines[10], (Action) (() =>
                                            {
                                              person.ThisPersonInt.EndTheChat();
                                              this.AddGoal(4, true);
                                              this.Invoke("GoToSlums", 0.0f);
                                            }), person);
                                          }), person);
                                        })
                                      });
                                    }), 8f);
                                  })
                                });
                              }
                              else
                              {
                                person.CurrentScheduleTask.State = 1;
                                person.Do_Schedule_GoingToTargetThread = true;
                              }
                            }),
                            WhileGoing = (Action) (() =>
                            {
                              person.RandActionTimer += Time.deltaTime;
                              if ((double) person.RandActionTimer <= 0.25)
                                return;
                              person.RandActionTimer = 0.0f;
                              if ((UnityEngine.Object) Main.Instance.Player.CurrentZone != (UnityEngine.Object) null && Main.Instance.Player.CurrentZone.UnSafe)
                              {
                                if (!this._HasSaid)
                                  this.EnterAlley();
                                person.navMesh.isStopped = true;
                              }
                              else
                              {
                                float num = Vector3.Distance(Main.Instance.Player.transform.position, this.transform.position);
                                if ((double) num > 1.0)
                                  person.SetDestination(Main.Instance.Player.transform);
                                else
                                  person.navMesh.isStopped = true;
                                person.navMesh.speed = (double) num > 4.0 ? 4f : 1f;
                              }
                            })
                          });
                        }), person)), person);
                      })
                    });
                  }), 8f);
                })
              });
            }
            else
            {
              person.CurrentScheduleTask.State = 1;
              person.Do_Schedule_GoingToTargetThread = true;
            }
          }),
          WhileGoing = (Action) (() =>
          {
            person.RandActionTimer += Time.deltaTime;
            if ((double) person.RandActionTimer <= 0.25)
              return;
            person.RandActionTimer = 0.0f;
            if ((UnityEngine.Object) Main.Instance.Player.CurrentZone != (UnityEngine.Object) null && Main.Instance.Player.CurrentZone.UnSafe)
            {
              if (!this._HasSaid)
                this.EnterAlley();
              person.navMesh.isStopped = true;
            }
            else
            {
              float num = Vector3.Distance(Main.Instance.Player.transform.position, this.transform.position);
              if ((double) num > 1.0)
                person.SetDestination(Main.Instance.Player.transform);
              else
                person.navMesh.isStopped = true;
              person.navMesh.speed = (double) num > 4.0 ? 4f : 1f;
            }
          })
        });
      }), 2f);
    }), person);
  }

  public void EnterAlley()
  {
    this._HasSaid = true;
    UI_Gameplay gameplayMenu = Main.Instance.GameplayMenu;
    Person zea = Main.Instance.CityCharacters.Zea;
    Main.Instance.Player.PersonAudio.pitch = zea.VoicePitch;
    Main.Instance.Player.PersonAudio.PlayOneShot(this.VoiceLines[11]);
    AudioClip voiceLine = this.VoiceLines[11];
    Action after = new Action(zea.ThisPersonInt.EndTheChat);
    Person personSaying = zea;
    gameplayMenu.DisplaySubtitle("That's the back alley, I don't wanna go there", voiceLine, after, personSaying);
  }

  public void GoToSlums()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person person = Main.Instance.CityCharacters.Zea;
    person.A_Standing = person.A_Standing_Org;
    person.AP_Standing = "lookaround";
    person.ProxSeen.gameObject.SetActive(false);
    Main.Instance.Player.ProxSeen.gameObject.SetActive(false);
    person.RandActionTimer = 0.0f;
    person.StartScheduleTask(new Person.ScheduleTask()
    {
      IDName = "zeaFollowPlayer7",
      ActionPlace = Main.Instance.Player.transform,
      OnArrive = (Action) (() =>
      {
        if ((double) Vector3.Distance(Main.Instance.Player.transform.position, this.GoSpots[3].position) < 30.0)
        {
          person.SetDestination(this.GoSpots[3]);
          Main.Instance.CityCharacters.Zea.StartScheduleTask(new Person.ScheduleTask()
          {
            IDName = "zeatshirt8",
            RunTo = true,
            ActionPlace = this.GoSpots[3],
            OnArrive = (Action) (() =>
            {
              person.transform.position = this.GoSpots[3].position;
              person.transform.rotation = this.GoSpots[3].rotation;
              Main.RunInSeconds((Action) (() =>
              {
                Main.Instance.CityCharacters.Zea.navMesh.stoppingDistance = 1.5f;
                this._FollowTimer = 0.0f;
                Main.Instance.CityCharacters.Zea.StartScheduleTask(new Person.ScheduleTask()
                {
                  IDName = "zeatshirt9",
                  RunTo = true,
                  ActionPlace = Main.Instance.Player.transform,
                  WhileGoing = (Action) (() =>
                  {
                    this._FollowTimer += Time.deltaTime;
                    if ((double) this._FollowTimer <= 1.0)
                      return;
                    this._FollowTimer = 0.0f;
                    Main.Instance.CityCharacters.Zea.SetDestination(Main.Instance.Player.transform);
                  }),
                  OnArrive = (Action) (() =>
                  {
                    Main.Instance.CityCharacters.Zea.transform.LookAt(Main.Instance.Player.transform);
                    if ((UnityEngine.Object) Main.Instance.SexScene.PlayerSex != (UnityEngine.Object) null)
                      Main.Instance.SexScene.PlayerSex.SafeSexEnd();
                    Main.Instance.OpenMenu("Gameplay");
                    this.CompleteGoal(4);
                    this.SlumsExitBlockers.SetActive(true);
                    _gameplay.DisplaySubtitle("Dammit, the final place to check is the back alley, I Hate that place", this.VoiceLines[12], (Action) (() =>
                    {
                      person.ThisPersonInt.EndTheChat();
                      this.AddGoal(5, true);
                      Main.Instance.CityCharacters.Ana.State = Person_State.Work;
                      Main.Instance.CityCharacters.Ana.ChangeUniform(this.AnaClothes);
                      this.AnaSpot.gameObject.SetActive(true);
                      this.AnaSpot.Interact(Main.Instance.CityCharacters.Ana);
                      Main.Instance.CityCharacters.Ana.ThisPersonInt.AddBlocker("tshirtquest");
                      person.RandActionTimer = 0.0f;
                      person.StartScheduleTask(new Person.ScheduleTask()
                      {
                        IDName = "zeaFollowPlayer3",
                        ActionPlace = Main.Instance.Player.transform,
                        OnArrive = (Action) (() =>
                        {
                          if ((double) Vector3.Distance(Main.Instance.Player.transform.position, this.GoSpots[4].position) < 5.0)
                          {
                            person.SetDestination(this.GoSpots[5]);
                            Main.Instance.CityCharacters.Zea.StartScheduleTask(new Person.ScheduleTask()
                            {
                              IDName = "zeatshirt5",
                              RunTo = true,
                              ActionPlace = this.GoSpots[5],
                              OnArrive = (Action) (() =>
                              {
                                person.AP_Standing = "PistolIdle";
                                person.transform.position = this.GoSpots[5].position;
                                person.transform.LookAt(Main.Instance.CityCharacters.Ana.transform);
                                this.CompleteGoal(5);
                                person.ThisPersonInt.AddBlocker("quest");
                                _gameplay.DisplaySubtitle("You, I haven't seen you in forever", this.VoiceLines[13], (Action) (() =>
                                {
                                  person.WeaponInv.SetActiveWeapon(0);
                                  person.LookAtPlayer.Disable = false;
                                  person.LookAtPlayer.NonplayerTarget = Main.Instance.CityCharacters.Ana.Head;
                                  Main.Instance.CityCharacters.Ana.LookAtPlayer.NonplayerTarget = person.Head;
                                  _gameplay.DisplaySubtitle("So this shithole is where you've been hanging, what happened to you?", this.VoiceLines[14], (Action) (() => _gameplay.DisplaySubtitle("Anyway, I need that tshirt, I can give you my top in exchange", this.VoiceLines[15], (Action) (() => _gameplay.DisplaySubtitle("That little top isn't gonna warm me in the cold nights, I want something better", this.VoiceLines[16], (Action) (() => _gameplay.DisplaySubtitle("Oh my fucking gawd, in the name of the glorious pussy", this.VoiceLines[17], (Action) (() =>
                                  {
                                    person.AP_Standing = "PistolCombatIdle";
                                    _gameplay.DisplaySubtitle("just gimme that already before I shoot you", this.VoiceLines[18], (Action) (() =>
                                    {
                                      _gameplay.RemoveAllChatOptions();
                                      _gameplay.AddChatOption("Yoooo chill, I'll go find something to trade it with", (Action) (() =>
                                      {
                                        Main.Instance.GameplayMenu.EnableMove();
                                        this.Invoke("BiteMe", 0.0f);
                                      }));
                                      _gameplay.AddChatOption("Hell yeah shoot her!", (Action) (() =>
                                      {
                                        Main.Instance.GameplayMenu.EnableMove();
                                        this.Invoke("BiteMe", 0.0f);
                                      }));
                                      _gameplay.SelectChatOption(0);
                                      Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
                                    }), person);
                                  }), person)), Main.Instance.CityCharacters.Ana)), person)), person);
                                }), person);
                              })
                            });
                          }
                          else
                          {
                            person.CurrentScheduleTask.State = 1;
                            person.Do_Schedule_GoingToTargetThread = true;
                          }
                        }),
                        WhileGoing = (Action) (() =>
                        {
                          person.RandActionTimer += Time.deltaTime;
                          if ((double) person.RandActionTimer <= 0.25)
                            return;
                          person.RandActionTimer = 0.0f;
                          float num = Vector3.Distance(Main.Instance.Player.transform.position, this.transform.position);
                          if ((double) num > 1.0)
                            person.SetDestination(Main.Instance.Player.transform);
                          else
                            person.navMesh.isStopped = true;
                          person.navMesh.speed = (double) num > 4.0 ? 4f : 1f;
                        })
                      });
                    }), person);
                  })
                });
              }), 8f);
            })
          });
        }
        else
        {
          person.CurrentScheduleTask.State = 1;
          person.Do_Schedule_GoingToTargetThread = true;
        }
      }),
      WhileGoing = (Action) (() =>
      {
        person.RandActionTimer += Time.deltaTime;
        if ((double) person.RandActionTimer <= 0.25)
          return;
        person.RandActionTimer = 0.0f;
        float num = Vector3.Distance(Main.Instance.Player.transform.position, this.transform.position);
        if ((double) num > 1.0)
          person.SetDestination(Main.Instance.Player.transform);
        else
          person.navMesh.isStopped = true;
        person.navMesh.speed = (double) num > 4.0 ? 4f : 1f;
      })
    });
  }

  public void BiteMe()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person person = Main.Instance.CityCharacters.Zea;
    _gameplay.DisplaySubtitle("You're gonna get a lot of enemies if you shoot me", this.VoiceLines[19], (Action) (() =>
    {
      this.AnaSpot.StopInteracting();
      int_basicSit anaSpot = (int_basicSit) this.AnaSpot;
      anaSpot.Sit_Anim[0].Anim = "boobs1";
      anaSpot.Sit_Anim[0].AttatchBoobs = true;
      this.AnaSpot.Interact(Main.Instance.CityCharacters.Ana);
      _gameplay.DisplaySubtitle("Bite me", this.VoiceLines[20], (Action) (() => _gameplay.DisplaySubtitle("Fine go find something to trade it with, anything is fine really", this.VoiceLines[21], (Action) (() => _gameplay.DisplaySubtitle("While I keep an eye on her", this.VoiceLines[22], (Action) (() => _gameplay.DisplaySubtitle("My top is too clean for your dirty tits anyway", this.VoiceLines[23], (Action) (() =>
      {
        person.AP_Standing = "PistolIdle";
        person.ThisPersonInt.EndTheChat();
        this.SlumsExitBlockers.SetActive(false);
        this.VendingExitBlockers.SetActive(false);
        this.AddGoal(6, true);
        person.ThisPersonInt.RemoveBlocker("quest");
        Main.Instance.MainThreads.Add(new Action(this.Goal6));
      }), person)), person)), person)), person);
    }), Main.Instance.CityCharacters.Ana);
  }

  public void Goal6()
  {
    if (Main.Instance.Player.Storage_Hands.StorageItems.Count > 0)
    {
      GameObject clothing = Main.Instance.Player.Storage_Hands.StorageItems[0].GetComponentInChildren<int_PickableClothingPackage>().Clothing;
      if (this.Goals[6].Completed || !((UnityEngine.Object) clothing != (UnityEngine.Object) null) || clothing.GetComponent<Dressable>().BodyPart != DressableType.Top)
        return;
      this.CompleteGoal(6);
      this.AddGoal(7, true);
    }
    else
    {
      if (!this.Goals[6].Completed)
        return;
      this.FailGoal(6);
      this.FailGoal(7);
      this.AddGoal(6, true);
    }
  }

  public void Goal7()
  {
    if ((double) Vector3.Distance(Main.Instance.Player.transform.position, Main.Instance.CityCharacters.Zea.transform.position) >= 2.0)
      return;
    Main.Instance.MainThreads.Remove(new Action(this.Goal7));
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person person = Main.Instance.CityCharacters.Zea;
    person.transform.LookAt(Main.Instance.Player.transform);
    person.transform.eulerAngles = new Vector3(0.0f, person.transform.eulerAngles.y, 0.0f);
    person.LookAtPlayer.NonplayerTarget = (Transform) null;
    if ((UnityEngine.Object) (Main.Instance.AllMissions[3] as Mis_Prost).BarMusic != (UnityEngine.Object) null)
    {
      this.ExtMusic = (Main.Instance.AllMissions[3] as Mis_Prost).BarMusic.transform.Find("ExteriorClubMusic").GetComponent<AudioSource>();
      this.ExtMusic.volume = 0.0f;
    }
    Main.Instance.Player.PersonAudio.pitch = person.VoicePitch;
    Main.Instance.Player.PersonAudio.PlayOneShot(this.VoiceLines[25]);
    GameObject storageItem = person.Storage_Hands.StorageItems[0];
    person.Storage_Hands.RemoveItem(storageItem);
    UnityEngine.Object.Destroy((UnityEngine.Object) storageItem);
    person.ChangeUniform(this.ZeaClothesAfter);
    person.A_Standing = "SSIdle";
    _gameplay.DisplaySubtitle("Finally, Look at this", this.VoiceLines[28], (Action) (() =>
    {
      this.CompleteGoal(8);
      this.CompleteMission();
      _gameplay.DisplaySubtitle("I look normal, I feel normal", this.VoiceLines[29], (Action) (() => _gameplay.DisplaySubtitle("it feels like I'm in a time from before the bombs", this.VoiceLines[30], (Action) (() =>
      {
        person.A_Standing = "PistolIdle";
        _gameplay.DisplaySubtitle("I'mma treasure this tshirt, and this moment", this.VoiceLines[31], (Action) (() => _gameplay.DisplaySubtitle("Thank you so much!", this.VoiceLines[32], (Action) (() =>
        {
          person.ResetAllShapes();
          person.A_Standing = "hipsSway2";
          _gameplay.DisplaySubtitle("Come here, I have a special something for you too", this.VoiceLines[33], (Action) (() =>
          {
            person.A_Standing = "PistolIdle";
            person.ThisPersonInt.EndTheChat();
            person.ThisPersonInt.RemoveBlocker("quest");
            person.ThisPersonInt.SetDefaultChat();
            Main.Instance.CanSaveFlags_remove("Zea1Mission");
            this.ExtMusic.volume = 1f;
            this.HangingTshirt.SetActive(true);
            Main.Instance.SexScene.SpawnSexScene(2, 11, Main.Instance.Player, Main.Instance.CityCharacters.Zea).OnSexEnd = (Action) (() =>
            {
              person.gameObject.SetActive(false);
              Main.Instance.Player.PlaceAt(this.SleepSpot[0]);
              Main.Instance.Player.SleepOnFloor();
              Main.Instance.GameplayMenu.ShowNotification("The next day...");
              Main.RunInSeconds((Action) (() => Main.Instance.AllMissions[11].InitMission()), 4f);
              Main.RunInSeconds((Action) (() => Main.Instance.AllMissions[12].InitMission()), 6f);
            });
          }), person, e_BlendShapes.Smug);
        }), person, e_BlendShapes.Crazy)), person, e_BlendShapes.None);
      }), person, e_BlendShapes.None)), person, e_BlendShapes.Smug);
    }), person, e_BlendShapes.None);
  }

  public bool MissionCanStart()
  {
    if (Main.Instance.AllMissions[8].CompletedMission && (Main.Instance.AllMissions[3].Goals[7].Completed || Main.Instance.Player is Guy) && !Main.Instance.CityCharacters.Zea.HavingSex)
      return true;
    Debug.LogError((object) ("MissionCanStart() " + Main.Instance.AllMissions[8].CompletedMission.ToString() + " " + Main.Instance.AllMissions[3].Goals[7].Completed.ToString() + " " + (!Main.Instance.CityCharacters.Zea.HavingSex).ToString()));
    return false;
  }

  public void Out_1()
  {
    Main.Instance.Player.transform.position = this.GoSpots[7].position;
    Main.Instance.Player.transform.rotation = this.GoSpots[7].rotation;
    Main.Instance.Player.PersonAudio.pitch = 1f;
    Main.Instance.Player.PersonAudio.PlayOneShot(this.VoiceLines[34]);
  }

  public void Out_2()
  {
    Main.Instance.Player.transform.position = this.GoSpots[8].position;
    Main.Instance.Player.transform.rotation = this.GoSpots[8].rotation;
    Main.Instance.Player.PersonAudio.pitch = 1f;
    Main.Instance.Player.PersonAudio.PlayOneShot(this.VoiceLines[34]);
  }

  public void Out_3()
  {
    Main.Instance.Player.transform.position = this.GoSpots[9].position;
    Main.Instance.Player.transform.rotation = this.GoSpots[9].rotation;
    Main.Instance.Player.PersonAudio.pitch = 1f;
    Main.Instance.Player.PersonAudio.PlayOneShot(this.VoiceLines[34]);
  }
}
