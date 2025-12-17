// Decompiled with JetBrains decompiler
// Type: Mis_Zea2
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#nullable disable
public class Mis_Zea2 : Mission
{
  [Space]
  [Space]
  public int SceneToLoad;
  public AudioClip[] VoiceLines;
  public GameObject[] ZeaClothes;
  public Mis_ZeaMistake ZeaMista;
  public Transform[] SpawnSpots;
  public bl_sceneticsound MainWindZone;
  public Transform[] F8Spots;
  public Animation TruckAnim;
  public AudioSource TruckEngine;
  public Rigidbody TruckRigid;
  public MeshRenderer[] Lights;
  public GameObject ZeaBedPrompt;
  public GameObject[] HeadQuarters_BeforeAndAfter;
  public Material MatLightOff;
  public Material MatLightOn;
  public Mis_Army2 Army2;
  public Interactible[] Ints;
  public GameObject[] Objs;
  public BL_MapArea[] Areas;
  public List<GameObject> _ppl = new List<GameObject>();
  public bool UsingTurret;
  public bool ReachedEndOfTrip;

  public bool MissionCanStart()
  {
    return Main.Instance.AllMissions[11].CompletedMission && Main.Instance.AllMissions[10].CompletedMission;
  }

  public override void InitMission()
  {
    if (!this.MissionCanStart() || this._Inited)
      return;
    base.InitMission();
    this.CurrentGoal = this.Goals[0];
    if (!this.CurrentGoal.Completed)
      this.OnStartMission();
    else
      this.CompletedMission = true;
    if (!this.CompletedMission)
    {
      Main.Instance.GameplayMenu.DisplayGoal(this.CurrentGoal, true);
      Main.Instance.GameplayMenu.MapTrackers[0] = Main.Instance.CityCharacters.Zea.transform;
    }
    else
    {
      if (Main.Instance.AllMissions[13].CompletedMission)
        return;
      Main.Instance.AllMissions[13].InitMission();
    }
  }

  public void OnStartMission()
  {
    this.AddGoal(0, true);
    this.PrepareZea();
    Main.Instance.CityCharacters.Zea.transform.position = this.SpawnSpots[0].position;
    Main.Instance.CityCharacters.Zea.transform.rotation = this.SpawnSpots[0].rotation;
  }

  public void PrepareZea()
  {
    Person zea = Main.Instance.CityCharacters.Zea;
    if (zea.HavingSex)
      zea.HavingSex_Scene.SafeSexEnd();
    if ((UnityEngine.Object) zea.InteractingWith != (UnityEngine.Object) null)
      zea.InteractingWith.StopInteracting();
    zea.State = Person_State.Work;
    zea.AddMoveBlocker("Quest2");
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
    zea.States[16 /*0x10*/] = false;
    zea.States[17] = false;
    zea.States[18] = false;
    zea.States[19] = false;
    zea.States[23] = false;
    zea.States[24] = false;
    zea.States[25] = false;
    zea.DirtySkin = false;
    zea.SetBodyTexture();
    (zea as Girl).PregnancyPercent = 0.0f;
    zea.WeaponInv.SetActiveWeapon(1);
    if (!this.Goals[0].Completed)
    {
      zea.ThisPersonInt.InteractText = "(Starts mission) Talk to Zea";
      zea.ThisPersonInt.StartTalkFunc = "ChatZea";
      zea.ThisPersonInt.StartTalkMono = (MonoBehaviour) this;
    }
    zea.navMesh.enabled = false;
    zea.enabled = false;
    zea.Anim.Play("ZeaBedSit2");
  }

  public void ChatZea()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person _zea = Main.Instance.CityCharacters.Zea;
    Main.Instance.CanSaveFlags_add("Zea2Mission");
    Main.Instance.MapAreas[0].LocalMusics[4] = Main.Instance.MapAreas[0].LocalMusics[3];
    this.CompleteGoal(0);
    _gameplay.DisplaySubtitle("Hey, I need to take a package somewhere", this.VoiceLines[0], (Action) (() => _gameplay.DisplaySubtitle("And you're coming with me", this.VoiceLines[1], (Action) (() => _gameplay.DisplaySubtitle("We can only go at night tho", this.VoiceLines[2], (Action) (() => _gameplay.DisplaySubtitle("Let's wait here until then", this.VoiceLines[3], (Action) (() =>
    {
      this.AddGoal(1, true);
      _zea.ThisPersonInt.EndTheChat();
      this.ZeaBedPrompt.SetActive(true);
      _zea.PersonAudio.PlayOneShot(this.ZeaMista.VoiceLines[38]);
      _zea.ThisPersonInt.EndTheChat();
      _zea.ThisPersonInt.SetDefaultChat();
      _zea.ThisPersonInt.AddBlocker("zea2");
      _zea.PlaceAt(this.ZeaMista.Objs[14].transform);
      _zea.Anim.Play("liedown_04");
      _zea.LookAtPlayer.OnlyEyes = true;
    }), _zea)), _zea)), _zea)), _zea);
  }

  public void OnZeaBed()
  {
    Person zea = Main.Instance.CityCharacters.Zea;
    this.ZeaBedPrompt.SetActive(false);
    Main.Instance.Player.AddMoveBlocker("asdasd");
    Main.Instance.Player.PlaceAt(this.SpawnSpots[31 /*0x1F*/]);
    Main.Instance.SexScene.SpawnSexScene(4, 4, Main.Instance.Player, zea, canControl: false);
    Main.Instance.SexScene.SpeedSlider.value = 1.6f;
    Main.Instance.SexScene.ENextImage.gameObject.SetActive(false);
    Main.Instance.MainThreads.Add(new Action(this.SexEndCheck));
  }

  public void SexEndCheck()
  {
    if (Main.Instance.Player.HavingSex)
      return;
    Main.Instance.MainThreads.Remove(new Action(this.SexEndCheck));
    Person _zea = Main.Instance.CityCharacters.Zea;
    _zea.PlaceAt(this.SpawnSpots[36]);
    this.AddGoal(2, true);
    Main.Instance.SexScene.ENextImage.gameObject.SetActive(true);
    UI_Gameplay gameplayMenu = Main.Instance.GameplayMenu;
    Main.RunInNextFrame((Action) (() => Main.Instance.GameplayMenu.TheScreenFader.FadeIn(1f)));
    Main.Instance.DayCycle.ResetMidnight();
    Main.Instance.MapAreas[2].OnLeave();
    this.CompleteGoal(1);
    Main.Instance.Player.RemoveMoveBlocker("asdasd");
    AudioClip voiceLine = this.VoiceLines[48 /*0x30*/];
    Action after = new Action(_zea.ThisPersonInt.EndTheChat);
    Person personSaying = _zea;
    gameplayMenu.DisplaySubtitle("okay les'go", voiceLine, after, personSaying);
    _zea.StartScheduleTask(new Person.ScheduleTask()
    {
      IDName = "_zeaentertruck",
      ActionPlace = this.SpawnSpots[32 /*0x20*/],
      OnArrive = (Action) (() =>
      {
        this.Army2.FakeTruck.SetActive(false);
        this.SpawnSpots[33].gameObject.SetActive(true);
        _zea.PersonAudio.PlayOneShot(Main.Instance.DoorUnLock);
        this.CompleteGoal(2);
        this.Goals[2].Title = "Enter the Truck";
        this.AddGoal(2, true);
        _zea.AddMoveBlocker("InTruck");
        _zea.PlaceAt(this.SpawnSpots[34]);
        _zea.enabled = false;
        _zea.navMesh.enabled = false;
        _zea.Anim.Play("sit_drive");
        Main.Instance.MapAreas[2].OnLeave();
      })
    });
  }

  public void EnterTruck1()
  {
    this.MainWindZone.enabled = false;
    this.MainWindZone.Sound.Stop();
    Main.Instance.MapAreas[2].OnLeave();
    Person zea = Main.Instance.CityCharacters.Zea;
    this.CompleteGoal(2);
    Main.Instance.Player.AddMoveBlocker("InTruck");
    Main.Instance.Player._Rigidbody.isKinematic = true;
    Main.Instance.Player.PlaceAt(this.SpawnSpots[35]);
    Main.Instance.Player.Anim.Play("sit_00");
    zea.Anim.Play("sit_drive");
    Main.Instance.Player.transform.SetParent(this.SpawnSpots[35]);
    zea.transform.SetParent(this.SpawnSpots[34]);
    this.Invoke("TruckGoToWorld", 2f);
  }

  public void TruckGoToWorld()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person _zea = Main.Instance.CityCharacters.Zea;
    _gameplay.DisplaySubtitle("Yeah it's better if I drive this time", this.VoiceLines[49], (Action) (() =>
    {
      _zea.ThisPersonInt.EndTheChat();
      Main.Instance.NewGameMenu.SmallLoading.SetActive(true);
      Main.Instance.GameplayMenu.TheScreenFader.FadeOut(4f, (Action) (() => Main.RunInNextFrame((Action) (() =>
      {
        Main.Instance.DayCycle.enabled = false;
        Main.Instance.DayCycle.ResetMidday();
        this.F8Spots[2].gameObject.SetActive(true);
        this._ppl.Clear();
        for (int index = 0; index < Main.Instance.SpawnedPeople.Count; ++index)
        {
          if ((UnityEngine.Object) Main.Instance.SpawnedPeople[index] != (UnityEngine.Object) null && (UnityEngine.Object) Main.Instance.SpawnedPeople[index].PersonType != (UnityEngine.Object) null && Main.Instance.SpawnedPeople[index].PersonType.ThisType != Person_Type.Clean && Main.Instance.SpawnedPeople[index].gameObject.activeInHierarchy)
          {
            this._ppl.Add(Main.Instance.SpawnedPeople[index].gameObject);
            Main.Instance.SpawnedPeople[index].gameObject.SetActive(false);
          }
        }
        SceneManager.LoadScene(this.SceneToLoad, LoadSceneMode.Additive);
        Main.RunInNextFrame((Action) (() =>
        {
          Main.Instance.OnFinallyGenerate.Clear();
          Main.Instance.OnAfterFinallyGenerate.Clear();
          Main.Instance.OnFinallyGenerate.Add((Action) (() =>
          {
            Main.RunInNextFrame((Action) (() => Main.Instance.GameplayMenu.TheScreenFader.FadeIn(1f)));
            Main.Instance.NewGameMenu.SmallLoading.SetActive(false);
            this.SpawnSpots[33].PlaceAt(this.SpawnSpots[37]);
            _zea.gameObject.SetActive(true);
            Main.Instance.Player.gameObject.SetActive(true);
            Main.Instance.Player.Anim.Play("sit_00");
            _zea.Anim.Play("sit_drive");
            this.SpawnSpots[33].GetComponent<Animation>().Play();
            this.SpawnSpots[38].gameObject.SetActive(true);
            this.SpawnSpots[39].gameObject.SetActive(false);
            this.TruckRigid = this.SpawnSpots[33].gameObject.AddComponent<Rigidbody>();
            this.TruckRigid.isKinematic = true;
            this.TruckRigid.useGravity = false;
            Main.Instance.MainThreads.Add(new Action(this.WhileTrip));
            Main.RunInSeconds((Action) (() => _gameplay.DisplaySubtitle("do u wanna shoot some stuff on the way there?", this.VoiceLines[50], (Action) (() => _gameplay.DisplaySubtitle("it's fun", this.VoiceLines[51], (Action) (() =>
            {
              _zea.ThisPersonInt.EndTheChat();
              Main.Instance.GameplayMenu.QLeave.SetActive(true);
              Main.Instance.GameplayMenu.QLeave.transform.Find("a/Text").GetComponent<Text>().text = "Use Turret";
            }), _zea)), _zea)), 3f);
          }));
          Main.Instance.GenerateNav();
        }), 4);
      }), 4)));
    }), _zea);
  }

  public void WhileTrip()
  {
    this.TruckEngine.pitch = (float) (0.30000001192092896 + (double) this.TruckRigid.velocity.magnitude / 20.0);
    if (!this.ReachedEndOfTrip && !this.TruckAnim.isPlaying)
    {
      this.ReachedEndOfTrip = true;
      UI_Gameplay gameplayMenu = Main.Instance.GameplayMenu;
      Person _zea = Main.Instance.CityCharacters.Zea;
      Main.Instance.GameplayMenu.QLeave.transform.Find("a/Text").GetComponent<Text>().text = "Leave";
      this.F8Spots[2].gameObject.SetActive(false);
      AudioClip voiceLine = this.VoiceLines[52];
      Action after = (Action) (() => _zea.ThisPersonInt.EndTheChat());
      Person personSaying = _zea;
      gameplayMenu.DisplaySubtitle("We're here", voiceLine, after, personSaying);
    }
    if (!Input.GetKeyUp(KeyCode.Q))
      return;
    if (this.ReachedEndOfTrip)
    {
      Main.Instance.MainThreads.Remove(new Action(this.WhileTrip));
      this.StartBridgeMoment();
    }
    else if (!this.UsingTurret)
    {
      this.UsingTurret = true;
      this.SpawnSpots[40].gameObject.SetActive(true);
      this.SpawnSpots[41].gameObject.SetActive(false);
      this.SpawnSpots[40].GetComponentInChildren<Int_Turret>().Interact(Main.Instance.Player);
      Main.Instance.Player.Interacting = false;
      Main.Instance.GameplayMenu.QLeave.SetActive(true);
      Main.Instance.GameplayMenu.QLeave.transform.Find("a/Text").GetComponent<Text>().text = "Leave Turret";
    }
    else
    {
      this.UsingTurret = false;
      this.SpawnSpots[40].gameObject.SetActive(false);
      this.SpawnSpots[41].gameObject.SetActive(true);
      this.SpawnSpots[40].GetComponentInChildren<Int_Turret>().StopInteracting(Main.Instance.Player);
      Main.Instance.Player.gameObject.SetActive(true);
      Main.Instance.Player._Rigidbody.isKinematic = true;
      Main.Instance.Player.PlaceAt(this.SpawnSpots[35]);
      Main.Instance.Player.Anim.Play("sit_00");
      Main.Instance.Player.Interacting = true;
      Main.Instance.GameplayMenu.QLeave.SetActive(true);
      Main.Instance.GameplayMenu.QLeave.transform.Find("a/Text").GetComponent<Text>().text = "Use Turret";
    }
  }

  public void StartBridgeMoment()
  {
    this.SpawnSpots[33].gameObject.SetActive(true);
    this.SpawnSpots[33].PlaceAt(this.SpawnSpots[1]);
    this.SpawnSpots[33].GetComponentInChildren<Interactible>().AddBlocker("asdasd");
    this.TruckEngine.gameObject.SetActive(false);
    if (!this.UsingTurret)
      Main.Instance.Player.Interacting = false;
    Main.Instance.Player.gameObject.SetActive(true);
    Main.Instance.Player.transform.SetParent((Transform) null);
    Main.Instance.Player.PlaceAt(this.SpawnSpots[3]);
    Main.Instance.Player.MoveBlockers.Clear();
    Main.Instance.Player.CanMove = true;
    Main.Instance.Player._Rigidbody.isKinematic = false;
    Main.Instance.Player.UserControl.ResetSpot = Main.Instance.CityCharacters.Zea.transform;
    Main.Instance.GameplayMenu.QLeave.SetActive(false);
    Person _zea = Main.Instance.CityCharacters.Zea;
    _zea.PlaceAt(this.SpawnSpots[2]);
    _zea.gameObject.SetActive(true);
    _zea.ThisPersonInt.AddBlocker("ElyBridge");
    _zea.State = Person_State.Work;
    _zea.WorkScheduleTasks.Clear();
    _zea.CurrentScheduleTask = (Person.ScheduleTask) null;
    _zea.enabled = true;
    _zea.StartScheduleTask(new Person.ScheduleTask()
    {
      IDName = "_zeaBridgeDest",
      ActionPlace = this.SpawnSpots[4],
      OnArrive = (Action) (() =>
      {
        this.Ints[0].Interact(_zea);
        if (this.Goals[3].Completed)
          return;
        this.AddGoal(3, true);
      })
    });
  }

  public void OnSitFirePlace()
  {
    this.CompleteGoal(3);
    Main.Instance.GameplayMenu.QLeave.SetActive(false);
    Main.RunInNextFrame((Action) (() =>
    {
      Main.Instance.Player.UserControl.FirstPerson = true;
      Main.Instance.Player.UserControl.Pivot.localPosition = new Vector3(-0.019f, 0.687f, -0.153f);
    }), 3);
    Main.RunInSeconds((Action) (() =>
    {
      UI_Gameplay gameplayMenu = Main.Instance.GameplayMenu;
      Person _zea = Main.Instance.CityCharacters.Zea;
      _zea.LookAtPlayer.Disable = false;
      AudioClip voiceLine = this.VoiceLines[4];
      Action after = (Action) (() =>
      {
        _zea.LookAtPlayer.Disable = false;
        _zea.ThisPersonInt.EndTheChat();
        this.AddGoal(4, true);
        this.Objs[0].SetActive(true);
        Main.Instance.Player.Interacting = false;
        Main.Instance.Player.MoveBlockers.Clear();
      });
      Person personSaying = _zea;
      gameplayMenu.DisplaySubtitle("Can you light that fire for me?", voiceLine, after, personSaying);
    }), 3f);
  }

  public void OnLightFire()
  {
    this.CompleteGoal(4);
    this.Objs[0].SetActive(false);
    this.Objs[1].gameObject.SetActive(false);
    this.Objs[2].gameObject.SetActive(true);
    this.Ints[1].ScriptToRun_OnInteract = new MonoBehaviour[0];
    this.Ints[1].ScriptFunctionToRun_OnInteract = new string[0];
    this.Ints[1].Interact(Main.Instance.Player);
    Main.Instance.Player.UserControl.FirstPerson = true;
    Main.Instance.Player.UserControl.Pivot.localPosition = new Vector3(-0.019f, 0.687f, -0.153f);
    Main.Instance.GameplayMenu.QLeave.SetActive(false);
    Main.RunInSeconds((Action) (() =>
    {
      UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
      Person _zea = Main.Instance.CityCharacters.Zea;
      _gameplay.DisplaySubtitle("Good, you still know how to do that", this.VoiceLines[5], (Action) (() =>
      {
        _zea.Anim.CrossFadeInFixedTime("sit_05", 1f);
        _gameplay.DisplaySubtitle("you've forgotten some things recently haven't you?", this.VoiceLines[6], (Action) (() =>
        {
          _gameplay.RemoveAllChatOptions();
          _gameplay.AddChatOption("It seems so", (Action) (() => this.ZeaChat2()));
          _gameplay.AddChatOption("Nah", (Action) (() => this.ZeaChat2()));
          _gameplay.SelectChatOption(0);
          Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
        }), _zea);
      }), _zea);
    }), 3f);
  }

  public void ZeaChat2()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person _zea = Main.Instance.CityCharacters.Zea;
    _zea.LookAtPlayer.playerTransform = this.SpawnSpots[5];
    _gameplay.DisplaySubtitle("Well don't worry about it", this.VoiceLines[7], (Action) (() => _gameplay.DisplaySubtitle("When we were young, you, me and Sadie figured out how to light a fire by ourselves", this.VoiceLines[8], (Action) (() => _gameplay.DisplaySubtitle("At this same place", this.VoiceLines[9], (Action) (() =>
    {
      _zea.Anim.CrossFadeInFixedTime("sit_03", 1f);
      _gameplay.DisplaySubtitle("Sadie even burned her leg", this.VoiceLines[10], (Action) (() => _gameplay.DisplaySubtitle("Permanent scar", this.VoiceLines[11], (Action) (() => _gameplay.DisplaySubtitle("That's life, it's told by our scars", this.VoiceLines[12], (Action) (() =>
      {
        _zea.LookAtPlayer.playerTransform = Main.Instance.Player.UserControl.m_Cam;
        _zea.Anim.CrossFadeInFixedTime("sit_05", 1f);
        _gameplay.DisplaySubtitle("Anyway I really like this bridge", this.VoiceLines[13], (Action) (() =>
        {
          _zea.LookAtPlayer.playerTransform = this.SpawnSpots[5];
          _gameplay.DisplaySubtitle("I have many fun memories here", this.VoiceLines[14], (Action) (() => _gameplay.DisplaySubtitle("it's also like a little window into the time before the bombs fell", this.VoiceLines[15], (Action) (() => _gameplay.DisplaySubtitle("When people used to just live and have fun", this.VoiceLines[16 /*0x10*/], (Action) (() =>
          {
            this.Objs[3].SetActive(true);
            this.Objs[3].transform.SetParent(_zea.RightHandStuff);
            this.Objs[3].transform.localPosition = new Vector3(0.0504f, -0.0388f, 0.0347f);
            this.Objs[3].transform.localEulerAngles = new Vector3(338.488037f, 292.971771f, 353.8826f);
            _zea.LookAtPlayer.playerTransform = Main.Instance.Player.UserControl.m_Cam;
            _zea.Anim.CrossFadeInFixedTime("sit_02", 1f);
            _gameplay.DisplaySubtitle("Well, I got some canned *sardinas*", this.VoiceLines[17], (Action) (() =>
            {
              this.Objs[3].transform.SetParent(this.SpawnSpots[6]);
              this.Objs[3].transform.localPosition = Vector3.zero;
              this.Objs[3].transform.localEulerAngles = Vector3.zero;
              _gameplay.DisplaySubtitle("I'mma leave them cooking here while we go check a place nearby", this.VoiceLines[18], (Action) (() => _gameplay.DisplaySubtitle("It's on the other side of these cars, I'll help you climb them", this.VoiceLines[19], (Action) (() =>
              {
                _zea.ThisPersonInt.EndTheChat();
                Main.Instance.GameplayMenu.TheScreenFader.FadeOut(2f, (Action) (() =>
                {
                  Main.Instance.Player.PersonAudio.PlayOneShot(this.VoiceLines[46]);
                  Main.RunInNextFrame((Action) (() => Main.Instance.GameplayMenu.TheScreenFader.FadeIn(1f)));
                  this.Ints[0].StopInteracting();
                  this.Ints[1].StopInteracting();
                  this.Ints[1].AddBlocker("quest");
                  this.AddGoal(5, true);
                  _zea.PlaceAt(this.SpawnSpots[7]);
                  Main.Instance.Player.PlaceAt(this.SpawnSpots[8]);
                  Main.Instance.Player.UserControl.FirstPerson = false;
                  GameObject gameObject = Main.Spawn(Main.Instance.AllPrefabs[1]);
                  gameObject.GetComponentInChildren<int_PickupToHand>(true).EquipToHand(_zea);
                  this.Objs[4] = gameObject;
                  Main.Instance.Player.UserControl.ResetSpot = this.F8Spots[0];
                  _zea.StartScheduleTask(new Person.ScheduleTask()
                  {
                    IDName = "_zeaBridgeDest2",
                    ActionPlace = this.SpawnSpots[9],
                    RunTo = true,
                    OnArrive = (Action) (() => Main.Instance.MainThreads.Add(new Action(this.Dest1)))
                  });
                  _zea.navMesh.speed = 6f;
                }));
              }), _zea)), _zea);
            }), _zea);
          }), _zea)), _zea)), _zea);
        }), _zea);
      }), _zea)), _zea)), _zea);
    }), _zea)), _zea)), _zea);
  }

  public void Dest1()
  {
    Person zea = Main.Instance.CityCharacters.Zea;
    if ((double) Vector3.Distance(Main.Instance.Player.transform.position, zea.transform.position) >= 5.0)
      return;
    Main.Instance.MainThreads.Remove(new Action(this.Dest1));
    zea.StartScheduleTask(new Person.ScheduleTask()
    {
      IDName = "_zeaBridgeDest3",
      ActionPlace = this.SpawnSpots[10],
      RunTo = true,
      OnArrive = (Action) (() => Main.Instance.MainThreads.Add(new Action(this.Dest2)))
    });
    zea.navMesh.speed = 6f;
  }

  public void Dest2()
  {
    Person zea = Main.Instance.CityCharacters.Zea;
    if ((double) Vector3.Distance(Main.Instance.Player.transform.position, zea.transform.position) >= 5.0)
      return;
    Main.Instance.MainThreads.Remove(new Action(this.Dest2));
    zea.StartScheduleTask(new Person.ScheduleTask()
    {
      IDName = "_zeaBridgeDest3",
      ActionPlace = this.SpawnSpots[11],
      RunTo = true,
      OnArrive = (Action) (() => Main.Instance.MainThreads.Add(new Action(this.Dest3)))
    });
    zea.navMesh.speed = 6f;
  }

  public void Dest3()
  {
    Person zea = Main.Instance.CityCharacters.Zea;
    if ((double) Vector3.Distance(Main.Instance.Player.transform.position, zea.transform.position) >= 5.0)
      return;
    Main.Instance.MainThreads.Remove(new Action(this.Dest3));
    zea.StartScheduleTask(new Person.ScheduleTask()
    {
      IDName = "_zeaBridgeDest3",
      ActionPlace = this.SpawnSpots[12],
      RunTo = true,
      OnArrive = (Action) (() => Main.Instance.MainThreads.Add(new Action(this.Dest4)))
    });
    zea.navMesh.speed = 6f;
  }

  public void Dest4()
  {
    Person zea = Main.Instance.CityCharacters.Zea;
    if ((double) Vector3.Distance(Main.Instance.Player.transform.position, zea.transform.position) >= 5.0)
      return;
    Main.Instance.MainThreads.Remove(new Action(this.Dest4));
    zea.StartScheduleTask(new Person.ScheduleTask()
    {
      IDName = "_zeaBridgeDest3",
      ActionPlace = this.SpawnSpots[13],
      RunTo = true,
      OnArrive = (Action) (() => Main.Instance.MainThreads.Add(new Action(this.Dest5)))
    });
    zea.navMesh.speed = 6f;
  }

  public void Dest5()
  {
    Person zea = Main.Instance.CityCharacters.Zea;
    if ((double) Vector3.Distance(Main.Instance.Player.transform.position, zea.transform.position) >= 5.0)
      return;
    Main.Instance.MainThreads.Remove(new Action(this.Dest5));
    zea.StartScheduleTask(new Person.ScheduleTask()
    {
      IDName = "_zeaBridgeDest3",
      ActionPlace = this.SpawnSpots[14],
      RunTo = true,
      OnArrive = (Action) (() => Main.Instance.MainThreads.Add(new Action(this.Dest6)))
    });
    zea.navMesh.speed = 6f;
  }

  public void Dest6()
  {
    Person zea = Main.Instance.CityCharacters.Zea;
    if ((double) Vector3.Distance(Main.Instance.Player.transform.position, zea.transform.position) >= 5.0)
      return;
    Main.Instance.MainThreads.Remove(new Action(this.Dest6));
    this.HeadQuarters_BeforeAndAfter[0].SetActive(true);
    this.HeadQuarters_BeforeAndAfter[3].SetActive(true);
    this.HeadQuarters_BeforeAndAfter[4].SetActive(true);
    zea.StartScheduleTask(new Person.ScheduleTask()
    {
      IDName = "_zeaBridgeDest3",
      ActionPlace = this.SpawnSpots[15],
      RunTo = true,
      OnArrive = (Action) (() => Main.Instance.MainThreads.Add(new Action(this.Dest7)))
    });
    zea.navMesh.speed = 6f;
  }

  public void Dest7()
  {
    Person _zea = Main.Instance.CityCharacters.Zea;
    if ((double) Vector3.Distance(Main.Instance.Player.transform.position, _zea.transform.position) >= 5.0)
      return;
    Main.Instance.MainThreads.Remove(new Action(this.Dest7));
    Main.Instance.GameplayMenu.DisplaySubtitle("Here's the place, let's go inside", this.VoiceLines[20], (Action) (() =>
    {
      _zea.ThisPersonInt.EndTheChat();
      this.SpawnSpots[16 /*0x10*/].gameObject.SetActive(true);
      this.CompleteGoal(5);
    }), _zea);
  }

  public void InteractEnterBuilding()
  {
    Person _zea = Main.Instance.CityCharacters.Zea;
    this.SpawnSpots[16 /*0x10*/].gameObject.SetActive(false);
    Main.Instance.Player.UserControl.ResetSpot = this.F8Spots[1];
    Main.Instance.Player.PlaceAt(this.SpawnSpots[17]);
    _zea.navMesh.enabled = false;
    _zea.PlaceAt(this.SpawnSpots[18]);
    this.Areas[0].OnEnter();
    this.SpawnSpots[28].gameObject.SetActive(true);
    Main.Instance.MusicPlayer.PlayOneShot(Main.Instance.DoorMove);
    Main.RunInNextFrame((Action) (() => _zea.StartScheduleTask(new Person.ScheduleTask()
    {
      IDName = "_zeaBridgeDest3",
      ActionPlace = this.SpawnSpots[19],
      RunTo = false,
      OnArrive = (Action) (() =>
      {
        _zea.PlaceAt(this.SpawnSpots[19]);
        Main.Instance.MainThreads.Add(new Action(this.DestIn1));
      })
    })), 3);
  }

  public void DestIn1()
  {
    Person _zea = Main.Instance.CityCharacters.Zea;
    if ((double) Vector3.Distance(Main.Instance.Player.transform.position, _zea.transform.position) >= 2.0)
      return;
    Main.Instance.MainThreads.Remove(new Action(this.DestIn1));
    Main.Instance.GameplayMenu.DisplaySubtitle("Ah, The lights are out again", this.VoiceLines[21], (Action) (() =>
    {
      _zea.ThisPersonInt.EndTheChat();
      _zea.StartScheduleTask(new Person.ScheduleTask()
      {
        IDName = "_zeaDestin2",
        ActionPlace = this.SpawnSpots[20],
        OnArrive = (Action) (() =>
        {
          this.SpawnSpots[21].GetComponent<Animation>().Play();
          _zea.PersonAudio.PlayOneShot(Main.Instance.DoorMove);
          _zea.StartScheduleTask(new Person.ScheduleTask()
          {
            IDName = "_zeaDestin3",
            ActionPlace = this.SpawnSpots[22],
            OnArrive = (Action) (() =>
            {
              _zea.PlaceAt(this.SpawnSpots[22]);
              Main.Instance.MainThreads.Add(new Action(this.DestIn2));
            })
          });
        })
      });
    }), _zea);
  }

  public void DestIn2()
  {
    Person _zea = Main.Instance.CityCharacters.Zea;
    if ((double) Vector3.Distance(Main.Instance.Player.transform.position, _zea.transform.position) >= 2.0)
      return;
    Main.Instance.MainThreads.Remove(new Action(this.DestIn2));
    Main.Instance.GameplayMenu.DisplaySubtitle("C'mon you piece of crap", this.VoiceLines[22], (Action) (() =>
    {
      _zea.ThisPersonInt.EndTheChat();
      _zea.enabled = false;
      _zea.Anim.Play("punch_20");
      _zea.PersonAudio.PlayOneShot(Main.Instance.PunchSounds[0]);
      _zea.PersonAudio.PlayOneShot(Main.Instance.MeleeHitSounds[1]);
      Main.RunInSeconds((Action) (() =>
      {
        this.LightsOn(true);
        this.Areas[1].OnEnter();
        this.SpawnSpots[28].gameObject.SetActive(false);
        _zea.enabled = true;
        _zea.StartScheduleTask(new Person.ScheduleTask()
        {
          IDName = "_zeaDestin4",
          ActionPlace = this.SpawnSpots[23],
          OnArrive = (Action) (() =>
          {
            _zea.PlaceAt(this.SpawnSpots[23]);
            Main.Instance.MainThreads.Add(new Action(this.DestIn3));
          })
        });
      }), 1f);
    }), _zea);
  }

  public void LightsOn(bool value)
  {
    for (int index = 0; index < this.Lights.Length; ++index)
    {
      this.Lights[index].transform.GetChild(0).gameObject.SetActive(value);
      if (value)
      {
        Main.Instance.Player.PersonAudio.PlayOneShot(this.VoiceLines[47]);
        this.Lights[index].material.EnableKeyword("_EMISSION");
      }
      else
        this.Lights[index].material.DisableKeyword("_EMISSION");
    }
  }

  public void DestIn3()
  {
    Person _zea = Main.Instance.CityCharacters.Zea;
    if ((double) Vector3.Distance(Main.Instance.Player.transform.position, _zea.transform.position) >= 2.0)
      return;
    Main.Instance.MainThreads.Remove(new Action(this.DestIn3));
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    if ((UnityEngine.Object) this.Objs[4] != (UnityEngine.Object) null)
      this.Objs[4].SetActive(false);
    this.SpawnSpots[24].gameObject.SetActive(true);
    _zea.LookAtPlayer.NonplayerTarget = this.SpawnSpots[24];
    _zea.PersonAudio.PlayOneShot(this.VoiceLines[46]);
    _gameplay.DisplaySubtitle("I can just leave these documents here", this.VoiceLines[23], (Action) (() => _gameplay.DisplaySubtitle("my friends will come pick them up later", this.VoiceLines[24], (Action) (() =>
    {
      _zea.LookAtPlayer.NonplayerTarget = (Transform) null;
      _zea.StartScheduleTask(new Person.ScheduleTask()
      {
        IDName = "_zeaDestin5",
        ActionPlace = this.SpawnSpots[25],
        OnArrive = (Action) (() => Main.Instance.MainThreads.Add(new Action(this.DestIn4)))
      });
      _gameplay.DisplaySubtitle("lemme show you the place around", this.VoiceLines[25], new Action(_zea.ThisPersonInt.EndTheChat), _zea);
    }), _zea)), _zea);
  }

  public void DestIn4()
  {
    Person _zea = Main.Instance.CityCharacters.Zea;
    if ((double) Vector3.Distance(Main.Instance.Player.transform.position, _zea.transform.position) >= 2.0)
      return;
    Main.Instance.MainThreads.Remove(new Action(this.DestIn4));
    _zea.StartScheduleTask(new Person.ScheduleTask()
    {
      IDName = "_zeaDestin5",
      ActionPlace = this.SpawnSpots[26],
      OnArrive = (Action) (() =>
      {
        _zea.PlaceAt(this.SpawnSpots[26]);
        Main.Instance.MainThreads.Add(new Action(this.DestIn5));
      })
    });
  }

  public void DestIn5()
  {
    Person _zea = Main.Instance.CityCharacters.Zea;
    if ((double) Vector3.Distance(Main.Instance.Player.transform.position, _zea.transform.position) >= 2.0)
      return;
    Main.Instance.MainThreads.Remove(new Action(this.DestIn5));
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    _zea.LookAtPlayer.NonplayerTarget = this.SpawnSpots[0];
    _gameplay.DisplaySubtitle("This room is pretty cool", this.VoiceLines[26], (Action) (() => _gameplay.DisplaySubtitle("it's the only one that hasn't been entered yet", this.VoiceLines[27], (Action) (() =>
    {
      _zea.LookAtPlayer.NonplayerTarget = (Transform) null;
      _gameplay.DisplaySubtitle("These kind of places are so cool", this.VoiceLines[28], (Action) (() => _gameplay.DisplaySubtitle("I always tell my friends that live here, to not go inside", this.VoiceLines[29], (Action) (() => _gameplay.DisplaySubtitle("everything from back then is a treasure to me", this.VoiceLines[30], (Action) (() =>
      {
        _zea.StartScheduleTask(new Person.ScheduleTask()
        {
          IDName = "_zeaDesti5_5",
          ActionPlace = this.SpawnSpots[29],
          OnArrive = (Action) (() =>
          {
            _zea.PlaceAt(this.SpawnSpots[29]);
            Main.Instance.MainThreads.Add(new Action(this.DestIn5_5));
          })
        });
        _gameplay.DisplaySubtitle("Alright lemme show you the kitchen", this.VoiceLines[31 /*0x1F*/], new Action(_zea.ThisPersonInt.EndTheChat), _zea);
      }), _zea)), _zea)), _zea);
    }), _zea)), _zea);
  }

  public void DestIn5_5()
  {
    Person _zea = Main.Instance.CityCharacters.Zea;
    if ((double) Vector3.Distance(Main.Instance.Player.transform.position, _zea.transform.position) >= 2.0)
      return;
    Main.Instance.MainThreads.Remove(new Action(this.DestIn5_5));
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    _gameplay.DisplaySubtitle("We usually have snacks here if you're hungry", this.VoiceLines[44], (Action) (() => _gameplay.DisplaySubtitle("But always leave something for the next one", this.VoiceLines[45], (Action) (() =>
    {
      _zea.ThisPersonInt.EndTheChat();
      _zea.StartScheduleTask(new Person.ScheduleTask()
      {
        IDName = "_zeaDestin6",
        ActionPlace = this.SpawnSpots[27],
        OnArrive = (Action) (() =>
        {
          _zea.PlaceAt(this.SpawnSpots[27]);
          Main.Instance.MainThreads.Add(new Action(this.DestIn6));
        })
      });
    }), _zea)), _zea);
  }

  public void DestIn6()
  {
    Person _zea = Main.Instance.CityCharacters.Zea;
    if ((double) Vector3.Distance(Main.Instance.Player.transform.position, _zea.transform.position) >= 2.0)
      return;
    Main.Instance.MainThreads.Remove(new Action(this.DestIn6));
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Main.Instance.Player.UserControl.FirstPerson = true;
    _zea.LookAtPlayer.NonplayerTarget = this.Objs[5].transform;
    _gameplay.DisplaySubtitle("Okay so, here is a keypad", this.VoiceLines[32 /*0x20*/], (Action) (() => _gameplay.DisplaySubtitle("And uhm, how do I describe this to you?", this.VoiceLines[33], (Action) (() =>
    {
      _zea.LookAtPlayer.NonplayerTarget = (Transform) null;
      _gameplay.DisplaySubtitle("Like, if you're around...", this.VoiceLines[34], (Action) (() => _gameplay.DisplaySubtitle("...and there's serious problems going on", this.VoiceLines[35], (Action) (() =>
      {
        _zea.LookAtPlayer.NonplayerTarget = this.Objs[5].transform;
        _gameplay.DisplaySubtitle("come here and insert the numbers 4 2 7", this.VoiceLines[36], (Action) (() => _gameplay.DisplaySubtitle("it's easy to remember", this.VoiceLines[37], (Action) (() =>
        {
          _zea.LookAtPlayer.NonplayerTarget = (Transform) null;
          _gameplay.DisplaySubtitle("it's 27 like your locker number", this.VoiceLines[38], (Action) (() => _gameplay.DisplaySubtitle("and there's 4 lockers in there", this.VoiceLines[39], (Action) (() => _gameplay.DisplaySubtitle("so, 4 and 27", this.VoiceLines[40], (Action) (() => _gameplay.DisplaySubtitle("well then, we should head back", this.VoiceLines[41], (Action) (() => _gameplay.DisplaySubtitle("I don't want my Sardinas to get burnt", this.VoiceLines[42], (Action) (() =>
          {
            this.SpawnSpots[24].gameObject.SetActive(false);
            _gameplay.DisplaySubtitle("Or both burnt and cold", this.VoiceLines[43], (Action) (() =>
            {
              _zea.ThisPersonInt.EndTheChat();
              Main.Instance.GameplayMenu.TheScreenFader.FadeOut(4f, (Action) (() =>
              {
                Main.RunInNextFrame((Action) (() => Main.Instance.GameplayMenu.TheScreenFader.FadeIn(1f)));
                Main.Instance.Player.UserControl.ResetSpot = Main.Instance.Player.UserControl.OriginalResetSpot;
                Main.Instance.Player.PlaceAt(this.SpawnSpots[30]);
                Main.Instance.Player.UserControl.FirstPerson = false;
                this.SpawnSpots[33].gameObject.SetActive(false);
                this.Army2.FakeTruck.SetActive(true);
                Main.Instance.Player.SleepOnFloor();
                Main.Instance.GameplayMenu.ShowNotification("The next day...");
                for (int index = 0; index < this._ppl.Count; ++index)
                  this._ppl[index].SetActive(true);
                _zea.gameObject.SetActive(false);
                this.CompleteMission();
                this.MainWindZone.enabled = true;
                Main.RunInSeconds((Action) (() => Main.Instance.AllMissions[13].InitMission()), 10f);
                SceneManager.MoveGameObjectToScene(Main.Instance.Player.gameObject, Main.Instance.gameObject.scene);
                SceneManager.MoveGameObjectToScene(Main.Instance.CityCharacters.Zea.gameObject, Main.Instance.gameObject.scene);
                SceneManager.UnloadSceneAsync(this.SceneToLoad);
                Main.Instance.CanSaveFlags_remove("Zea2Mission");
                Main.Instance.SaveGame(true);
              }));
            }), _zea);
          }), _zea)), _zea)), _zea)), _zea)), _zea);
        }), _zea)), _zea);
      }), _zea)), _zea);
    }), _zea)), _zea);
  }
}
