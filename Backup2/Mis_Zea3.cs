// Decompiled with JetBrains decompiler
// Type: Mis_Zea3
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#nullable disable
public class Mis_Zea3 : Mission
{
  [Space]
  [Space]
  public Mis_Zea2 Zea2;
  public AudioSource BattleMusic;
  public GameObject[] ElyClothes;
  public GameObject[] ZeaClothesEly;
  public GameObject[] SadieClothes;
  public AudioClip[] VoiceLines;
  public AudioClip[] Musics;
  public Material[] Skys;
  public GameObject[] BoardNames;
  public GameObject[] Cameras;
  public GameObject[] OnWar;
  [Header(" - Ely")]
  public Transform[] Ely_spots;
  public BL_MapArea[] Areas;
  public bool TalkedAboutMom;
  private string _c_line = string.Empty;
  private AudioClip _c_clip;
  public AudioSource ElyMusicPlayer;
  public bool TESTIMG;
  [Header(" - War")]
  public GameObject[] WarClothes;
  public Texture WarEye;
  public Texture WarIris;
  public Texture WarBody;
  public float WarWalkTimer;
  public Vector3 OriginalPlayerScale;
  public float XAXIS;
  public float XAXISMAX = 324.7f;
  public float XAXISMIN = 350f;
  public bl_HangZone Lab;
  public List<GameObject> ESBSToDespawn = new List<GameObject>();
  public Animation TankAnim;
  public AudioSource TankEngine;
  public Rigidbody TankRigid;
  public List<GameObject> _ppl = new List<GameObject>();
  public BL_MapArea TankTripSkyArea;
  public int TankTripState;
  public float _TankTime;
  public bool ReachedEndOfTrip;
  public bool BridgeDown;
  public bool ExitedCity;
  public List<Person> SpawnedESBs = new List<Person>();
  public GameObject TankBulletPrefab;
  public AudioClip[] FireSounds;
  public Person ESBEntrance;

  public void PrepareSadie()
  {
  }

  public bool MissionCanStart() => Main.Instance.AllMissions[14].CompletedMission;

  public override void InitMission()
  {
    if (!this.MissionCanStart() || this._Inited)
      return;
    base.InitMission();
    this.CurrentGoal = this.Goals[0];
    if (!this.CurrentGoal.Completed)
      this.StartSephiePart();
    else
      this.CompletedMission = true;
    if (!this.CompletedMission)
    {
      Main.Instance.GameplayMenu.DisplayGoal(this.CurrentGoal, true);
      Main.Instance.GameplayMenu.MapTrackers[0] = Main.Instance.CityCharacters.Merussy.transform;
    }
    else
    {
      Mis_ZeaMistake objectOfType = UnityEngine.Object.FindObjectOfType<Mis_ZeaMistake>();
      for (int index = 0; index < objectOfType.PreDamage.Length; ++index)
      {
        if ((UnityEngine.Object) objectOfType.PreDamage[index] != (UnityEngine.Object) null)
          objectOfType.PreDamage[index].SetActive(false);
      }
      for (int index = 0; index < objectOfType.AfterDamage.Length; ++index)
      {
        if ((UnityEngine.Object) objectOfType.AfterDamage[index] != (UnityEngine.Object) null)
          objectOfType.AfterDamage[index].SetActive(false);
      }
      for (int index = 0; index < objectOfType.AfterDamageFixed.Length; ++index)
      {
        if ((UnityEngine.Object) objectOfType.AfterDamageFixed[index] != (UnityEngine.Object) null)
          objectOfType.AfterDamageFixed[index].SetActive(true);
      }
      for (int index = 0; index < objectOfType.DisableSirenObjs.Length; ++index)
        objectOfType.DisableSirenObjs[index].SetActive(false);
      for (int index = 0; index < objectOfType.EnableSirenObjsAfterFix.Length; ++index)
        objectOfType.EnableSirenObjsAfterFix[index].SetActive(true);
      Main.Instance.CityCharacters.War.gameObject.SetActive(false);
    }
  }

  public void StartElyCutscene()
  {
    this.Zea2.HeadQuarters_BeforeAndAfter[2].SetActive(true);
    Main.Instance.GameplayMenu.TheScreenFader.FadeOut(7f, (Action) (() =>
    {
      UnityEngine.Object.FindObjectOfType<Mis_Zea2_refs>().jumpoverspots[11].gameObject.SetActive(false);
      Main.Instance.Player.gameObject.SetActive(true);
      Main.Instance.PlayerCam.transform.root.gameObject.SetActive(true);
      Main.Instance.Player.RemoveMoveBlocker("asdasd");
      Main.Instance.Player.Interacting = false;
      Main.Instance.Player.InteractingWith = (Interactible) null;
      Main.Instance.Player.TheHealth.maxHealth = 1000f;
      Main.Instance.Player.TheHealth.currentHealth = 759f;
      Main.Instance.GameplayMenu.UpdateHealth();
      this.Areas[0].OnEnter();
      Main.Instance.MusicPlayer.Stop();
      Main.Instance.MusicPlayer.clip = (AudioClip) null;
      this.Zea2.HeadQuarters_BeforeAndAfter[0].SetActive(false);
      this.Zea2.HeadQuarters_BeforeAndAfter[1].SetActive(false);
      for (int index = 0; index < this.BoardNames.Length; ++index)
        this.BoardNames[index].SetActive(false);
      Main.Instance.Player.AddMoveBlocker("ElyTalk");
      Person ely = Main.Instance.CityCharacters.Ely;
      ely.LOD.gameObject.SetActive(false);
      ely.enabled = false;
      ely.ChangeUniform(this.ElyClothes);
      ely.State = Person_State.Work;
      ely.WorkScheduleTasks.Clear();
      ely.CurrentScheduleTask = (Person.ScheduleTask) null;
      ely.AddMoveBlocker("ElyTalk");
      ely.PlaceAt(this.Ely_spots[5]);
      ely.Anim.Play("Anim_ElySit1");
      ely.LookAtPlayer.enabled = true;
      ely.LookAtPlayer.playerTransform = Main.Instance.Player.Head;
      ely.LookAtPlayer.DontBlockSides = false;
      ely.SetHighLod();
      ely.ThisPersonInt.AddBlocker("ElyChat");
      Person _zea = Main.Instance.CityCharacters.Zea;
      _zea.gameObject.SetActive(true);
      _zea.LOD.gameObject.SetActive(false);
      _zea.enabled = false;
      _zea.State = Person_State.Work;
      _zea.WorkScheduleTasks.Clear();
      _zea.CurrentScheduleTask = (Person.ScheduleTask) null;
      _zea.ChangeUniform(this.ZeaClothesEly);
      _zea.AddMoveBlocker("ElyTalk");
      _zea.PlaceAt(this.Ely_spots[6]);
      _zea.Anim.Play("Anim_Zea3_Greet");
      _zea.SetHighLod();
      _zea.LookAtPlayer.ExtraRot = true;
      _zea.LookAtPlayer.AddHeadRotation = new Vector3(10f, 0.0f, 0.0f);
      _zea.LookAtPlayer.playerTransform = this.Ely_spots[0];
      _zea.LookAtPlayer.DontBlockSides = true;
      _zea.ThisPersonInt.AddBlocker("ElyChat");
      (_zea as Girl).PregnancyPercent = 0.0f;
      Main.RunInSeconds((Action) (() =>
      {
        Main.Instance.MusicPlayer.Stop();
        Main.Instance.MusicPlayer.volume = 1f;
        Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[105]);
        Main.Instance.GameplayMenu.TheScreenFader.FadeIn(10f);
        this.Ely_spots[0].gameObject.SetActive(true);
        _zea.LookAtPlayer.OnlyEyes = false;
        Main.RunInSeconds((Action) (() =>
        {
          _zea.LookAtPlayer.OnlyEyes = false;
          UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
          _gameplay.DisplaySubtitle("Hey, welcome back", this.VoiceLines[0], (Action) (() =>
          {
            _gameplay.RemoveAllChatOptions();
            _gameplay.AddChatOption("Zea! You survived!?", (Action) (() => _gameplay.DisplaySubtitle("Yeah, looks like I did", this.VoiceLines[1], (Action) (() =>
            {
              _zea.LookAtPlayer.playerTransform = this.Ely_spots[7];
              _gameplay.DisplaySubtitle("I uhm...", this.VoiceLines[2], (Action) (() => _gameplay.DisplaySubtitle("I ended up running away as soon as you left", this.VoiceLines[3], (Action) (() =>
              {
                _zea.ThisPersonInt.EndTheChat();
                Main.Instance.GameplayMenu.QLeave.SetActive(true);
                Main.Instance.GameplayMenu.QLeave.transform.Find("a/Text").GetComponent<Text>().text = "Stand up";
                Main.Instance.MainThreads.Add(new Action(this.QStand_Ely_Thread));
                _zea.LookAtPlayer.ExtraRot = false;
                _zea.LookAtPlayer.AddHeadRotation = Vector3.zero;
                _zea.LookAtPlayer.playerTransform = Main.Instance.Player.Head;
                _zea.LookAtPlayer.DontBlockSides = false;
                _zea.enabled = true;
                _zea.StartScheduleTask(new Person.ScheduleTask()
                {
                  IDName = "_zeaDest",
                  ActionPlace = this.Ely_spots[2],
                  OnArrive = (Action) (() => _zea.PlaceAt(this.Ely_spots[2]))
                });
              }), _zea, lipsyncTime: 0.5f)), _zea);
            }), _zea, lipsyncTime: 0.8f)));
            _gameplay.SelectChatOption(0);
            Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
          }), _zea);
        }), 7f);
      }), 3f);
    }));
  }

  public void QStand_Ely_Thread()
  {
    if (!Main.Instance.CancelKey())
      return;
    Main.Instance.MainThreads.Remove(new Action(this.QStand_Ely_Thread));
    this.QStand_Ely();
  }

  public void QStand_Ely()
  {
    this.Zea2.MainWindZone.enabled = false;
    this.Zea2.MainWindZone.Sound.Stop();
    Main.Instance.GameplayMenu.QLeave.SetActive(false);
    this.Ely_spots[0].gameObject.SetActive(false);
    Main.Instance.MusicPlayer.volume = 1f;
    Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[105]);
    Main.Instance.Player.PlaceAt(this.Ely_spots[1]);
    Main.Instance.Player.RemoveMoveBlocker("ElyTalk");
    Main.Instance.Player.UserControl.ResetSpot = this.Ely_spots[1];
  }

  public void OnSitChair()
  {
    Main.Instance.GameplayMenu.QLeave.SetActive(false);
    Main.RunInNextFrame((Action) (() =>
    {
      Main.Instance.Player.UserControl.FirstPerson = true;
      Main.Instance.Player.UserControl.Pivot.localPosition = new Vector3(0.0f, 1.3f, -0.15f);
      if (!this.TalkedAboutMom)
        Main.Instance.MainThreads.Add(new Action(this.AfterMomTalk_Check));
      else
        this.ElyStartTalking();
    }), 3);
  }

  public void AfterMomTalk_Check()
  {
    if (!this.TalkedAboutMom)
      return;
    Main.Instance.MainThreads.Remove(new Action(this.AfterMomTalk_Check));
    this.ElyStartTalking();
  }

  public void PlayerEnteredChatZone()
  {
    this.Zea2.MainWindZone.enabled = false;
    this.Zea2.MainWindZone.Sound.Stop();
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person ely = Main.Instance.CityCharacters.Ely;
    Person _zea = Main.Instance.CityCharacters.Zea;
    Action after = (Action) (() => _gameplay.DisplaySubtitle("She's the leader of the ESB", this.VoiceLines[5], (Action) (() => _gameplay.DisplaySubtitle("ESB are just her initials by the way", this.VoiceLines[6], (Action) (() =>
    {
      this.TalkedAboutMom = true;
      _zea.ThisPersonInt.EndTheChat();
      this.AddGoal(3, true);
    }), _zea)), _zea));
    if (Main.Instance.FreeWorldPatch)
      _gameplay.DisplaySubtitle("This is my mom, Ely", this.VoiceLines[4], after, _zea);
    else
      _gameplay.DisplaySubtitle("This is my (censored)\"friend\", Ely", (AudioClip) null, after, _zea);
  }

  public void ElyStartTalking()
  {
    this.Zea2.MainWindZone.enabled = false;
    this.Zea2.MainWindZone.Sound.Stop();
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person _ely = Main.Instance.CityCharacters.Ely;
    Person _zea = Main.Instance.CityCharacters.Zea;
    this.ElyMusicPlayer.Play();
    this.ElyMusicPlayer.volume = 0.0f;
    this.CompleteGoal(3);
    _ely.LookAtPlayer.playerTransform = Main.Instance.Player.UserControl.m_Cam;
    if (this.TESTIMG)
    {
      this.Invoke("StartWarCutscene", 0.0f);
    }
    else
    {
      string _string;
      AudioClip _clip;
      _gameplay.DisplaySubtitle("We don't have much time", this.VoiceLines[7], (Action) (() => _gameplay.DisplaySubtitle("I must explain you plenty of things you need to know", this.VoiceLines[8], (Action) (() => _gameplay.DisplaySubtitle("For the future of Bitchland", this.VoiceLines[9], (Action) (() => _gameplay.DisplaySubtitle("Before you and Zea were born, when the bombs fell", this.VoiceLines[10], (Action) (() => _gameplay.DisplaySubtitle("your dad saw an oppurtunity to create a new civilization", this.VoiceLines[11], (Action) (() => _gameplay.DisplaySubtitle("that's more sexually free from what it classically was", this.VoiceLines[12], (Action) (() => _gameplay.DisplaySubtitle("Most things in the city are decided by your dad", this.VoiceLines[13], (Action) (() =>
      {
        _ely.Anim.Play("Anim_ElySit2");
        _ely.LookAtPlayer.NonplayerTarget = this.Ely_spots[8];
        _zea.StartScheduleTask(new Person.ScheduleTask()
        {
          IDName = "_zeawrite1",
          ActionPlace = this.Ely_spots[11],
          OnArrive = (Action) (() =>
          {
            this.BoardNames[0].SetActive(true);
            _zea.enabled = false;
            _zea.PlaceAt(this.Ely_spots[11]);
            _zea.Anim.Play("Anim_WallWrite");
            Main.RunInSeconds((Action) (() => this.BoardNames[1].SetActive(true)), 1f);
            Main.RunInSeconds((Action) (() => this.BoardNames[2].SetActive(true)), 2f);
            Main.RunInSeconds((Action) (() => this.BoardNames[3].SetActive(true)), 3f);
            Main.RunInSeconds((Action) (() => this.BoardNames[4].SetActive(true)), 4f);
            Main.RunInSeconds((Action) (() =>
            {
              _zea.enabled = true;
              _zea.StartScheduleTask(new Person.ScheduleTask()
              {
                IDName = "_zeaDest",
                ActionPlace = this.Ely_spots[2],
                OnArrive = (Action) (() => _zea.PlaceAt(this.Ely_spots[2]))
              });
            }), 5f);
          })
        });
        if (Main.Instance.FreeWorldPatch)
        {
          _string = "But he's very easily manipulated by his wifes";
          _clip = this.VoiceLines[14];
        }
        else
        {
          _string = "But he's very easily manipulated by his (censored)\"friends\"";
          _clip = (AudioClip) null;
        }
        _gameplay.DisplaySubtitle(_string, _clip, (Action) (() =>
        {
          _ely.Anim.Play("Anim_ElySit1");
          _gameplay.DisplaySubtitle("They are called the Main 5", this.VoiceLines[15], (Action) (() =>
          {
            _ely.LookAtPlayer.NonplayerTarget = (Transform) null;
            _gameplay.DisplaySubtitle("And I am one of them", this.VoiceLines[16 /*0x10*/], (Action) (() =>
            {
              _ely.LookAtPlayer.NonplayerTarget = this.Ely_spots[8];
              _ely.Anim.Play("Anim_ElySit2");
              _gameplay.DisplaySubtitle("Each of us used to manage a class of people", this.VoiceLines[17], (Action) (() =>
              {
                _ely.Anim.Play("Anim_ElySit1");
                if (Main.Instance.FreeWorldPatch)
                {
                  _string = "The first wife was Jeanne, she managed the so called training class";
                  _clip = this.VoiceLines[18];
                }
                else
                {
                  _string = "The first (censored)\"friend\" was Jeanne, she managed the so called training class";
                  _clip = (AudioClip) null;
                }
                _gameplay.DisplaySubtitle(_string, _clip, (Action) (() =>
                {
                  _ely.LookAtPlayer.NonplayerTarget = (Transform) null;
                  _gameplay.DisplaySubtitle("I used to manage the workers", this.VoiceLines[19], (Action) (() =>
                  {
                    _ely.LookAtPlayer.NonplayerTarget = this.Ely_spots[8];
                    _gameplay.DisplaySubtitle("War managed the army", this.VoiceLines[20], (Action) (() => _gameplay.DisplaySubtitle("Sephie managed the civilians", this.VoiceLines[21], (Action) (() => _gameplay.DisplaySubtitle("and Rit somehow managed us, the royals", this.VoiceLines[22], (Action) (() =>
                    {
                      _ely.LookAtPlayer.NonplayerTarget = (Transform) null;
                      _gameplay.DisplaySubtitle("Zea told me there's a new girl called Sarah, who's been managing most classes while we are gone", this.VoiceLines[23], (Action) (() => _gameplay.DisplaySubtitle("Never seen her yet", this.VoiceLines[24], (Action) (() =>
                      {
                        this.ElyMusicPlayer.volume = 0.025f;
                        _ely.LookAtPlayer.NonplayerTarget = this.Ely_spots[8];
                        _ely.Anim.Play("Anim_ElySit2");
                        _gameplay.DisplaySubtitle("Anyway, each of us has an idea of how much sexually free should the civilization be", this.VoiceLines[25], (Action) (() =>
                        {
                          _ely.Anim.Play("Anim_ElySit1");
                          _ely.LookAtPlayer.NonplayerTarget = (Transform) null;
                          if (Main.Instance.FreeWorldPatch)
                          {
                            _string = "I value romance and order, a lot more then the other wives";
                            _clip = this.VoiceLines[26];
                          }
                          else
                          {
                            _string = "I value romance and order, a lot more then the other (censored)\"friends\"";
                            _clip = (AudioClip) null;
                          }
                          _gameplay.DisplaySubtitle(_string, _clip, (Action) (() =>
                          {
                            this.ElyMusicPlayer.volume = 0.05f;
                            _ely.LookAtPlayer.NonplayerTarget = this.Ely_spots[8];
                            _gameplay.DisplaySubtitle("Rit was an odd one, but she was more on my side than the rest", this.VoiceLines[27], (Action) (() => _gameplay.DisplaySubtitle("War and Sephie are more in line with your dad", this.VoiceLines[28], (Action) (() =>
                            {
                              this.ElyMusicPlayer.volume = 0.07f;
                              _ely.LookAtPlayer.NonplayerTarget = (Transform) null;
                              _gameplay.DisplaySubtitle("Except sometimes they are stupid, they can't even think for themselves", this.VoiceLines[29], (Action) (() => _gameplay.DisplaySubtitle("War in particular, follows your dad's orders like a dog", this.VoiceLines[30], (Action) (() =>
                              {
                                this.ElyMusicPlayer.volume = 0.1f;
                                _gameplay.DisplaySubtitle("And Jeanne was the worse one", this.VoiceLines[31 /*0x1F*/], (Action) (() => _gameplay.DisplaySubtitle("First with prostitution everywhere, and later with just sex everywhere", this.VoiceLines[32 /*0x20*/], (Action) (() =>
                                {
                                  this.ElyMusicPlayer.volume = 0.125f;
                                  _gameplay.DisplaySubtitle("free sex anytime, no longer was there any romance to it", this.VoiceLines[33], (Action) (() =>
                                  {
                                    _ely.LookAtPlayer.NonplayerTarget = this.Ely_spots[8];
                                    _gameplay.DisplaySubtitle("That maniacal bitch, has no sense of individual connection", this.VoiceLines[34], (Action) (() => _gameplay.DisplaySubtitle("Sephie didn't helped much too", this.VoiceLines[35], (Action) (() => _gameplay.DisplaySubtitle("She created the futanari, and many other sexual inventions", this.VoiceLines[36], (Action) (() =>
                                    {
                                      if (Main.Instance.FreeWorldPatch)
                                      {
                                        _string = "All at the expense of discusting experiments with people";
                                        _clip = this.VoiceLines[37];
                                      }
                                      else
                                      {
                                        _string = "(censored)\"All thanks to the power of friendship\"";
                                        _clip = (AudioClip) null;
                                      }
                                      _gameplay.DisplaySubtitle(_string, _clip, (Action) (() =>
                                      {
                                        _ely.LookAtPlayer.NonplayerTarget = (Transform) null;
                                        _gameplay.DisplaySubtitle("People with dreams, memories, relationships, feelings", this.VoiceLines[38], (Action) (() => _gameplay.DisplaySubtitle("Sephie says she sees things \"scientifically\", it's bullshit if you ask me", this.VoiceLines[39], (Action) (() =>
                                        {
                                          _ely.LookAtPlayer.NonplayerTarget = this.Ely_spots[8];
                                          _gameplay.DisplaySubtitle("But one day all of the sudden, Jeanne lost her mind", this.VoiceLines[40], (Action) (() => _gameplay.DisplaySubtitle("She killed Rit, and very likely was going after me too", this.VoiceLines[41], (Action) (() =>
                                          {
                                            _ely.LookAtPlayer.NonplayerTarget = (Transform) null;
                                            _gameplay.DisplaySubtitle("I assume because our ideals didn't alined, but I don't know, it was so sudden", this.VoiceLines[42], (Action) (() => _gameplay.DisplaySubtitle("She just had a complete personality change one day", this.VoiceLines[43], (Action) (() =>
                                            {
                                              _ely.LookAtPlayer.NonplayerTarget = this.Ely_spots[8];
                                              _gameplay.DisplaySubtitle("Before anything could happen to me, I escaped the city and came to lead the ESB", this.VoiceLines[44], (Action) (() =>
                                              {
                                                _ely.LookAtPlayer.NonplayerTarget = (Transform) null;
                                                _gameplay.DisplaySubtitle("My plan is to return the city to a more normal civilization", this.VoiceLines[46], (Action) (() => _gameplay.DisplaySubtitle("We can make the world more open to sex like your dad's original vision", this.VoiceLines[47], (Action) (() => _gameplay.DisplaySubtitle("But not like how Jeanne wants it, she's madness itself", this.VoiceLines[48 /*0x30*/], (Action) (() => _gameplay.DisplaySubtitle("Civilization will fall if things go her way", this.VoiceLines[49], (Action) (() =>
                                                {
                                                  _ely.LookAtPlayer.NonplayerTarget = this.Ely_spots[8];
                                                  _gameplay.DisplaySubtitle("I know your dad very well, even with treason, if I explain things to him, he'll forgive me", this.VoiceLines[50], (Action) (() =>
                                                  {
                                                    if (Main.Instance.FreeWorldPatch)
                                                    {
                                                      _string = "But even if your dad won't listen to us, maybe Rit's child will listen";
                                                      _clip = this.VoiceLines[51];
                                                    }
                                                    else
                                                    {
                                                      _string = "But even if your dad won't listen to us, maybe Rit's (censored)\"friend\" will listen";
                                                      _clip = (AudioClip) null;
                                                    }
                                                    _gameplay.DisplaySubtitle(_string, _clip, (Action) (() =>
                                                    {
                                                      _ely.LookAtPlayer.NonplayerTarget = (Transform) null;
                                                      if (Main.Instance.FreeWorldPatch)
                                                      {
                                                        _string = "Each of us had a child back then";
                                                        _clip = this.VoiceLines[52];
                                                      }
                                                      else
                                                      {
                                                        _string = "Each of us had a censored)\"friend\" back then";
                                                        _clip = (AudioClip) null;
                                                      }
                                                      _gameplay.DisplaySubtitle(_string, _clip, (Action) (() =>
                                                      {
                                                        _ely.LookAtPlayer.NonplayerTarget = this.Ely_spots[8];
                                                        _gameplay.DisplaySubtitle("Zea's mine", this.VoiceLines[53], (Action) (() => _gameplay.DisplaySubtitle("Sia is War's", this.VoiceLines[54], (Action) (() => _gameplay.DisplaySubtitle("Maylenne is Sephie's", this.VoiceLines[55], (Action) (() =>
                                                        {
                                                          _ely.LookAtPlayer.NonplayerTarget = (Transform) null;
                                                          _gameplay.DisplaySubtitle("You, you are Jeanne's", this.VoiceLines[56], (Action) (() =>
                                                          {
                                                            if (Main.Instance.FreeWorldPatch)
                                                            {
                                                              _string = "And for the life of me, I can't remember who is Rit's child";
                                                              _clip = this.VoiceLines[57];
                                                            }
                                                            else
                                                            {
                                                              _string = "And for the life of me, I can't remember who is Rit's (censored)\"friend\"";
                                                              _clip = (AudioClip) null;
                                                            }
                                                            _gameplay.DisplaySubtitle(_string, _clip, (Action) (() =>
                                                            {
                                                              this.ElyMusicPlayer.volume = 0.1f;
                                                              if (Main.Instance.FreeWorldPatch)
                                                              {
                                                                _string = "But once your dad retires, it's Rit's child that will lead bitchland";
                                                                _clip = this.VoiceLines[58];
                                                              }
                                                              else
                                                              {
                                                                _string = "But once your dad retires, it's Rit's (censored)\"friend\" that will lead bitchland";
                                                                _clip = (AudioClip) null;
                                                              }
                                                              _gameplay.DisplaySubtitle(_string, _clip, (Action) (() =>
                                                              {
                                                                this.ElyMusicPlayer.volume = 0.07f;
                                                                _gameplay.DisplaySubtitle("So we must find them and put some sense in their head before it's too late", this.VoiceLines[59], (Action) (() =>
                                                                {
                                                                  this.ElyMusicPlayer.volume = 0.05f;
                                                                  _gameplay.DisplaySubtitle("Go on your dad's office when he's not there", this.VoiceLines[60], (Action) (() =>
                                                                  {
                                                                    this.ElyMusicPlayer.volume = 0.02f;
                                                                    _gameplay.DisplaySubtitle("look at photos, there should be lots of them", this.VoiceLines[61], (Action) (() =>
                                                                    {
                                                                      this.ElyMusicPlayer.volume = 0.0f;
                                                                      _zea.LookAtPlayer.playerTransform = this.Ely_spots[9];
                                                                      _ely.LookAtPlayer.playerTransform = this.Ely_spots[9];
                                                                      if (Main.Instance.FreeWorldPatch)
                                                                      {
                                                                        _string = "And find who is Rit's child";
                                                                        _clip = this.VoiceLines[58];
                                                                      }
                                                                      else
                                                                      {
                                                                        _string = "And find who is Rit's (censored)\"friend\"";
                                                                        _clip = (AudioClip) null;
                                                                      }
                                                                      _gameplay.DisplaySubtitle(_string, _clip, (Action) (() =>
                                                                      {
                                                                        _ely.ThisPersonInt.EndTheChat();
                                                                        this.Invoke("StartWarCutscene", 0.0f);
                                                                      }), _ely, e_BlendShapes.Serious);
                                                                    }), _ely);
                                                                  }), _ely);
                                                                }), _ely);
                                                              }), _ely);
                                                            }), _ely);
                                                          }), _ely);
                                                        }), _ely)), _ely)), _ely);
                                                      }), _ely);
                                                    }), _ely, e_BlendShapes.Neutral);
                                                  }), _ely, e_BlendShapes.Smile);
                                                }), _ely)), _ely, e_BlendShapes.Angry)), _ely)), _ely, e_BlendShapes.Neutral);
                                              }), _ely, e_BlendShapes.Sad);
                                            }), _ely, e_BlendShapes.Neutral)), _ely);
                                          }), _ely, e_BlendShapes.Neutral)), _ely, e_BlendShapes.Shocked);
                                        }), _ely)), _ely);
                                      }), _ely);
                                    }), _ely, e_BlendShapes.Neutral)), _ely)), _ely, e_BlendShapes.Angry);
                                  }), _ely, e_BlendShapes.Neutral);
                                }), _ely)), _ely, e_BlendShapes.Angry);
                              }), _ely)), _ely);
                            }), _ely)), _ely);
                          }), _ely);
                        }), _ely, e_BlendShapes.Neutral);
                      }), _ely)), _ely);
                    }), _ely)), _ely)), _ely);
                  }), _ely);
                }), _ely);
              }), _ely);
            }), _ely);
          }), _ely);
        }), _ely);
      }), _ely)), _ely)), _ely)), _ely)), _ely)), _ely)), _ely);
    }
  }

  public void ElyStartTalking_obsolete()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person _ely = Main.Instance.CityCharacters.Ely;
    Person _zea = Main.Instance.CityCharacters.Zea;
    this.CompleteGoal(2);
    _gameplay.DisplaySubtitle("We have to talk about Bitchland as you know it", this.VoiceLines[7], (Action) (() => _gameplay.DisplaySubtitle("it didn't used to be like this", this.VoiceLines[8], (Action) (() => _gameplay.DisplaySubtitle("Your dad, decides everything in bitchland", this.VoiceLines[9], (Action) (() => _gameplay.DisplaySubtitle("but he's very easily manipulated by the \"Main 5\"", this.VoiceLines[10], (Action) (() => _gameplay.DisplaySubtitle("which are his wives", this.VoiceLines[11], (Action) (() => _gameplay.DisplaySubtitle("and I am one of them", this.VoiceLines[12], (Action) (() =>
    {
      _ely.Anim.Play("Anim_ElySit2");
      _ely.LookAtPlayer.playerTransform = this.Ely_spots[8];
      _zea.StartScheduleTask(new Person.ScheduleTask()
      {
        IDName = "_zeawrite1",
        ActionPlace = this.Ely_spots[11],
        OnArrive = (Action) (() =>
        {
          this.BoardNames[0].SetActive(true);
          _zea.enabled = false;
          _zea.PlaceAt(this.Ely_spots[11]);
          _zea.Anim.Play("Anim_WallWrite");
          Main.RunInSeconds((Action) (() => this.BoardNames[1].SetActive(true)), 1f);
          Main.RunInSeconds((Action) (() => this.BoardNames[2].SetActive(true)), 2f);
          Main.RunInSeconds((Action) (() => this.BoardNames[3].SetActive(true)), 3f);
          Main.RunInSeconds((Action) (() => this.BoardNames[4].SetActive(true)), 4f);
          Main.RunInSeconds((Action) (() =>
          {
            _zea.enabled = true;
            _zea.StartScheduleTask(new Person.ScheduleTask()
            {
              IDName = "_zeaDest",
              ActionPlace = this.Ely_spots[2],
              OnArrive = (Action) (() => _zea.PlaceAt(this.Ely_spots[2]))
            });
          }), 5f);
        })
      });
      _gameplay.DisplaySubtitle("Each of us has a statue in the city so you must have a basic idea of all of us by now", this.VoiceLines[13], (Action) (() =>
      {
        _ely.Anim.Play("Anim_ElySit1");
        _gameplay.DisplaySubtitle("The first wife was Jeanne, she managed the so called \"training\" class", this.VoiceLines[14], (Action) (() =>
        {
          if (Main.Instance.FreeWorldPatch)
          {
            this._c_line = "They are being brainwashed, that's what they are";
            this._c_clip = this.VoiceLines[15];
          }
          else
          {
            this._c_line = "(nothing here)";
            this._c_clip = (AudioClip) null;
          }
          _gameplay.DisplaySubtitle(this._c_line, this._c_clip, (Action) (() =>
          {
            _ely.LookAtPlayer.playerTransform = Main.Instance.Player.UserControl.m_Cam;
            _gameplay.DisplaySubtitle("I used to manage the worker class", this.VoiceLines[16 /*0x10*/], (Action) (() => _gameplay.DisplaySubtitle("But I very much prefered if instead I'd manage the army", this.VoiceLines[17], (Action) (() =>
            {
              Main.Instance.MusicPlayer.volume = 0.025f;
              _gameplay.DisplaySubtitle("Since I plan and organize better than War", this.VoiceLines[18], (Action) (() =>
              {
                Main.Instance.MusicPlayer.Stop();
                Main.Instance.MusicPlayer.Play();
                Main.Instance.MusicPlayer.volume = 0.05f;
                _gameplay.DisplaySubtitle("But your dad picked her because she follows his orders like a dog", this.VoiceLines[19], (Action) (() =>
                {
                  Main.Instance.MusicPlayer.volume = 0.07f;
                  _ely.Anim.Play("Anim_ElySit2");
                  _ely.LookAtPlayer.playerTransform = this.Ely_spots[8];
                  _gameplay.DisplaySubtitle("Your dad's 4th wife is Sephie, managing the civilian class", this.VoiceLines[20], (Action) (() =>
                  {
                    Main.Instance.MusicPlayer.volume = 0.1f;
                    _ely.Anim.Play("Anim_ElySit1");
                    _ely.LookAtPlayer.playerTransform = Main.Instance.Player.UserControl.m_Cam;
                    _gameplay.DisplaySubtitle("Which originally were scientists, architects, normal people, with normal jobs", this.VoiceLines[21], (Action) (() =>
                    {
                      Main.Instance.MusicPlayer.volume = 0.125f;
                      _gameplay.DisplaySubtitle("But things had started changing", this.VoiceLines[22], (Action) (() =>
                      {
                        _ely.LookAtPlayer.playerTransform = this.Ely_spots[8];
                        if (Main.Instance.FreeWorldPatch)
                        {
                          this._c_line = "Because Jeanne was manipulating your dad";
                          this._c_clip = this.VoiceLines[23];
                        }
                        else
                        {
                          this._c_line = "(nothing here)";
                          this._c_clip = (AudioClip) null;
                        }
                        _gameplay.DisplaySubtitle(this._c_line, this._c_clip, (Action) (() => _gameplay.DisplaySubtitle("into turning the civilian class to prostitution", this.VoiceLines[24], (Action) (() =>
                        {
                          _ely.LookAtPlayer.playerTransform = Main.Instance.Player.UserControl.m_Cam;
                          _gameplay.DisplaySubtitle("sex everywhere, free sex anytime, no longer was there any romance to it", this.VoiceLines[25], (Action) (() =>
                          {
                            _ely.LookAtPlayer.playerTransform = this.Ely_spots[8];
                            if (Main.Instance.FreeWorldPatch)
                            {
                              this._c_line = "That maniacal bitch, was turning everything into a crazy sex world";
                              this._c_clip = this.VoiceLines[26];
                            }
                            else
                            {
                              this._c_line = "That maniacal bitch, was turning everything into a (Consensual) crazy sex world";
                              this._c_clip = this.VoiceLines[26];
                            }
                            _gameplay.DisplaySubtitle(this._c_line, this._c_clip, (Action) (() => _gameplay.DisplaySubtitle("Sephie didn't helped much too", this.VoiceLines[27], (Action) (() => _gameplay.DisplaySubtitle("She created the futanari, and many other sexual inventions", this.VoiceLines[28], (Action) (() =>
                            {
                              if (Main.Instance.FreeWorldPatch)
                              {
                                this._c_line = "All at the expense of discusting experiments with real people";
                                this._c_clip = this.VoiceLines[29];
                              }
                              else
                              {
                                this._c_line = "(nothing here)";
                                this._c_clip = (AudioClip) null;
                              }
                              _gameplay.DisplaySubtitle(this._c_line, this._c_clip, (Action) (() =>
                              {
                                _ely.LookAtPlayer.playerTransform = this.Ely_spots[8];
                                if (Main.Instance.FreeWorldPatch)
                                {
                                  this._c_line = "People with dreams, memories, relationships, feelings";
                                  this._c_clip = this.VoiceLines[30];
                                }
                                else
                                {
                                  this._c_line = "(nothing here)";
                                  this._c_clip = (AudioClip) null;
                                }
                                _gameplay.DisplaySubtitle(this._c_line, this._c_clip, (Action) (() => _gameplay.DisplaySubtitle("Things finally started improving when Rit showed up", this.VoiceLines[31 /*0x1F*/], (Action) (() => _gameplay.DisplaySubtitle("She's very odd tho, I still don't understand her", this.VoiceLines[32 /*0x20*/], (Action) (() => _gameplay.DisplaySubtitle("We found her in a pre-war bunker", this.VoiceLines[33], (Action) (() =>
                                {
                                  _ely.Anim.Play("Anim_ElySit2");
                                  _gameplay.DisplaySubtitle("And very quickly she became your dad's fifth wife", this.VoiceLines[34], (Action) (() =>
                                  {
                                    _ely.LookAtPlayer.playerTransform = Main.Instance.Player.UserControl.m_Cam;
                                    _ely.Anim.Play("Anim_ElySit1");
                                    _gameplay.DisplaySubtitle("And he made her manage the royal class", this.VoiceLines[35], (Action) (() => _gameplay.DisplaySubtitle("She must have been someone he already knew before the bombs", this.VoiceLines[36], (Action) (() =>
                                    {
                                      _ely.LookAtPlayer.playerTransform = this.Ely_spots[8];
                                      _gameplay.DisplaySubtitle("And you know what I found the oddest about her?", this.VoiceLines[37], (Action) (() => _gameplay.DisplaySubtitle("her personality wasn't strong, unlike me or any of the others", this.VoiceLines[38], (Action) (() => _gameplay.DisplaySubtitle("She was weak, she wasn't the right person for a position like that", this.VoiceLines[39], (Action) (() =>
                                      {
                                        _ely.LookAtPlayer.playerTransform = Main.Instance.Player.UserControl.m_Cam;
                                        _gameplay.DisplaySubtitle("Your dad always liked strong willed women", this.VoiceLines[40], (Action) (() => _gameplay.DisplaySubtitle("Very very odd", this.VoiceLines[41], (Action) (() =>
                                        {
                                          _ely.LookAtPlayer.playerTransform = this.Ely_spots[8];
                                          _gameplay.DisplaySubtitle("Jeanne was slowly getting mad and jealous of her", this.VoiceLines[42], (Action) (() => _gameplay.DisplaySubtitle("She used to be the main wife, but now it was all about Rit", this.VoiceLines[43], (Action) (() => _gameplay.DisplaySubtitle("leaving us behind, busy with our tasks", this.VoiceLines[44], (Action) (() =>
                                          {
                                            _ely.LookAtPlayer.playerTransform = Main.Instance.Player.UserControl.m_Cam;
                                            _gameplay.DisplaySubtitle("And one day, boom, Rit was dead", this.VoiceLines[45], (Action) (() => _gameplay.DisplaySubtitle("I believe Jeanne did it", this.VoiceLines[46], (Action) (() => _gameplay.DisplaySubtitle("And out of caution that she was gonna kill me too, I ran away from the city", this.VoiceLines[47], (Action) (() =>
                                            {
                                              _ely.LookAtPlayer.playerTransform = this.Ely_spots[8];
                                              _gameplay.DisplaySubtitle("I had already started creating the ESB in secret", this.VoiceLines[48 /*0x30*/], (Action) (() => _gameplay.DisplaySubtitle("Because I always plan ahead", this.VoiceLines[49], (Action) (() => _gameplay.DisplaySubtitle("It might not seem like it, but I still love your dad very much", this.VoiceLines[50], (Action) (() =>
                                              {
                                                _ely.LookAtPlayer.playerTransform = Main.Instance.Player.UserControl.m_Cam;
                                                _gameplay.DisplaySubtitle("He's a good person with good intentions for the world", this.VoiceLines[51], (Action) (() => _gameplay.DisplaySubtitle("And I know him, even with treason, if I explain things to him, he'll forgive me", this.VoiceLines[52], (Action) (() =>
                                                {
                                                  _ely.LookAtPlayer.playerTransform = this.Ely_spots[8];
                                                  _gameplay.DisplaySubtitle("My plan is to return the city to normal civilization", this.VoiceLines[53], (Action) (() => _gameplay.DisplaySubtitle("And I get it, that we can make the world more open to sex, but not like Jeanne wants it", this.VoiceLines[54], (Action) (() =>
                                                  {
                                                    _ely.LookAtPlayer.playerTransform = Main.Instance.Player.UserControl.m_Cam;
                                                    _gameplay.DisplaySubtitle("She's madness itself", this.VoiceLines[55], (Action) (() => _gameplay.DisplaySubtitle("Even if your dad won't listen to us", this.VoiceLines[56], (Action) (() => _gameplay.DisplaySubtitle("Maybe Rit's child will listen", this.VoiceLines[57], (Action) (() =>
                                                    {
                                                      if (Main.Instance.FreeWorldPatch)
                                                      {
                                                        this._c_line = "Once your dad retires, it's Rit's child that will lead bitchland";
                                                        this._c_clip = this.VoiceLines[58];
                                                      }
                                                      else
                                                      {
                                                        this._c_line = "Once your dad retires, it's Rit's Offspring that will lead the city";
                                                        this._c_clip = (AudioClip) null;
                                                      }
                                                      _gameplay.DisplaySubtitle(this._c_line, this._c_clip, (Action) (() =>
                                                      {
                                                        _ely.LookAtPlayer.playerTransform = this.Ely_spots[8];
                                                        if (Main.Instance.FreeWorldPatch)
                                                        {
                                                          this._c_line = "All of us had a child";
                                                          this._c_clip = this.VoiceLines[59];
                                                        }
                                                        else
                                                        {
                                                          this._c_line = "(nothing here)";
                                                          this._c_clip = (AudioClip) null;
                                                        }
                                                        _gameplay.DisplaySubtitle(this._c_line, this._c_clip, (Action) (() =>
                                                        {
                                                          if (Main.Instance.FreeWorldPatch)
                                                          {
                                                            this._c_line = "Zea is my daughter";
                                                            this._c_clip = this.VoiceLines[60];
                                                          }
                                                          else
                                                          {
                                                            this._c_line = "(nothing here)";
                                                            this._c_clip = (AudioClip) null;
                                                          }
                                                          _gameplay.DisplaySubtitle(this._c_line, this._c_clip, (Action) (() =>
                                                          {
                                                            if (Main.Instance.FreeWorldPatch)
                                                            {
                                                              this._c_line = "Sia is War's";
                                                              this._c_clip = this.VoiceLines[61];
                                                            }
                                                            else
                                                            {
                                                              this._c_line = "(nothing here)";
                                                              this._c_clip = (AudioClip) null;
                                                            }
                                                            _gameplay.DisplaySubtitle(this._c_line, this._c_clip, (Action) (() =>
                                                            {
                                                              if (Main.Instance.FreeWorldPatch)
                                                              {
                                                                this._c_line = "Maylenne from the clinic is Sephie's";
                                                                this._c_clip = this.VoiceLines[62];
                                                              }
                                                              else
                                                              {
                                                                this._c_line = "(nothing here)";
                                                                this._c_clip = (AudioClip) null;
                                                              }
                                                              _gameplay.DisplaySubtitle(this._c_line, this._c_clip, (Action) (() =>
                                                              {
                                                                _ely.LookAtPlayer.playerTransform = Main.Instance.Player.UserControl.m_Cam;
                                                                if (Main.Instance.FreeWorldPatch)
                                                                {
                                                                  this._c_line = "You, you are Jeanne's";
                                                                  this._c_clip = this.VoiceLines[63 /*0x3F*/];
                                                                }
                                                                else
                                                                {
                                                                  this._c_line = "(nothing here)";
                                                                  this._c_clip = (AudioClip) null;
                                                                }
                                                                _gameplay.DisplaySubtitle(this._c_line, this._c_clip, (Action) (() => _gameplay.DisplaySubtitle("Probably, I can't remember exactly", this.VoiceLines[0], (Action) (() =>
                                                                {
                                                                  _ely.LookAtPlayer.playerTransform = this.Ely_spots[8];
                                                                  _gameplay.DisplaySubtitle("My memory is fuzzy, I also can't remember who exactly is Rit's child", this.VoiceLines[64 /*0x40*/], (Action) (() => _gameplay.DisplaySubtitle("Which is weird, it's like some memories I had just got deleted one day", this.VoiceLines[0], (Action) (() =>
                                                                  {
                                                                    Main.Instance.MusicPlayer.volume = 0.1f;
                                                                    _gameplay.DisplaySubtitle("Go on your dad's office when he's not there", this.VoiceLines[65], (Action) (() =>
                                                                    {
                                                                      Main.Instance.MusicPlayer.volume = 0.05f;
                                                                      _ely.LookAtPlayer.playerTransform = Main.Instance.Player.UserControl.m_Cam;
                                                                      _gameplay.DisplaySubtitle("look at photos, there should be lots of them in there", this.VoiceLines[66], (Action) (() =>
                                                                      {
                                                                        Main.Instance.MusicPlayer.volume = 0.0f;
                                                                        _zea.LookAtPlayer.playerTransform = this.Ely_spots[9];
                                                                        _ely.LookAtPlayer.playerTransform = this.Ely_spots[9];
                                                                        _gameplay.DisplaySubtitle("And find who is Rit's child", this.VoiceLines[67], (Action) (() =>
                                                                        {
                                                                          _ely.ThisPersonInt.EndTheChat();
                                                                          this.Invoke("StartWarCutscene", 0.0f);
                                                                        }), _ely);
                                                                      }), _ely);
                                                                    }), _ely);
                                                                  }), _ely)), _ely);
                                                                }), _ely)), _ely);
                                                              }), _ely);
                                                            }), _ely);
                                                          }), _ely);
                                                        }), _ely);
                                                      }), _ely);
                                                    }), _ely)), _ely)), _ely);
                                                  }), _ely)), _ely);
                                                }), _ely)), _ely);
                                              }), _ely)), _ely)), _ely);
                                            }), _ely)), _ely)), _ely);
                                          }), _ely)), _ely)), _ely);
                                        }), _ely)), _ely);
                                      }), _ely)), _ely)), _ely);
                                    }), _ely)), _ely);
                                  }), _ely, e_BlendShapes.None);
                                }), _ely)), _ely)), _ely)), _ely);
                              }), _ely);
                            }), _ely)), _ely, e_BlendShapes.Angry)), _ely);
                          }), _ely);
                        }), _ely)), _ely);
                      }), _ely);
                    }), _ely);
                  }), _ely);
                }), _ely);
              }), _ely);
            }), _ely)), _ely, e_BlendShapes.Neutral);
          }), _ely);
        }), _ely);
      }), _ely);
    }), _ely)), _ely)), _ely)), _ely)), _ely)), _ely);
  }

  public void StartWarCutscene()
  {
    this.Zea2.MainWindZone.enabled = false;
    this.Zea2.MainWindZone.Sound.Stop();
    this.Zea2.HeadQuarters_BeforeAndAfter[0].SetActive(false);
    this.Zea2.HeadQuarters_BeforeAndAfter[1].SetActive(false);
    this.Zea2.HeadQuarters_BeforeAndAfter[2].SetActive(true);
    this.Zea2.HeadQuarters_BeforeAndAfter[3].SetActive(true);
    Person _war = Main.Instance.CityCharacters.War;
    Main.Instance.CityCharacters.Zea.gameObject.SetActive(true);
    if ((UnityEngine.Object) Main.Instance.Player.InteractingWith != (UnityEngine.Object) null)
      Main.Instance.Player.InteractingWith.StopInteracting(Main.Instance.Player);
    Main.Instance.Player.AddMoveBlocker("WarCutscene");
    Main.Instance.Player.PlaceAt(this.Ely_spots[3]);
    Main.Instance.Player._Rigidbody.isKinematic = true;
    this.OnWar[0].SetActive(false);
    this.OnWar[1].SetActive(true);
    Main.Instance.MusicPlayer.volume = 1f;
    Main.Instance.MusicPlayer.PlayOneShot(Main.Instance.DoorMove);
    Main.Instance.MusicPlayer.volume = 0.0f;
    Main.Instance.MusicPlayer.mute = true;
    Main.Instance.MusicPlayer.pitch = 1f;
    Main.Instance.MusicPlayer.enabled = false;
    Main.Instance.MusicPlayer.Stop();
    Main.Instance.MusicPlayer.PlayOneShot(Main.Instance.DoorMove);
    this.ElyMusicPlayer.Stop();
    this.ElyMusicPlayer.enabled = true;
    this.ElyMusicPlayer.volume = 0.35f;
    this.ElyMusicPlayer.pitch = 1f;
    this.ElyMusicPlayer.loop = false;
    this.ElyMusicPlayer.clip = this.Musics[2];
    this.ElyMusicPlayer.Play();
    _war.SetHighLod();
    _war.LOD.gameObject.SetActive(false);
    _war.LodRen.gameObject.SetActive(false);
    _war.ThisPersonInt.AddBlocker("warmad");
    _war.AddMoveBlocker("Cutscene");
    _war.gameObject.SetActive(true);
    _war.enabled = false;
    _war.navMesh.enabled = false;
    _war.States[8] = true;
    _war.States[0] = true;
    _war.SetBodyTexture();
    _war.DirtySkin = true;
    _war.ForeArmLeft.parent.localScale = Vector3.zero;
    Color _teeth = new Color(0.5754717f, 0.3067373f, 0.3067373f, 1f);
    Color _eyeBalls = new Color(0.9433962f, 0.734247f, 0.734247f, 1f);
    Color _iris = new Color(0.5849056f, 0.007357304f, 0.0f, 1f);
    _war.MainBody.materials[2].color = _teeth;
    _war.MainBody.materials[3].color = _eyeBalls;
    _war.MainBody.materials[3].mainTexture = this.WarEye;
    _war.MainBody.materials[6].color = _iris;
    _war.MainBody.materials[6].mainTexture = this.WarIris;
    _war.MainBody.materials[0].mainTexture = this.WarBody;
    Main.RunInNextFrame((Action) (() =>
    {
      _war.MainBody.materials[2].color = _teeth;
      _war.MainBody.materials[3].color = _eyeBalls;
      _war.MainBody.materials[3].mainTexture = this.WarEye;
      _war.MainBody.materials[6].color = _iris;
      _war.MainBody.materials[6].mainTexture = this.WarIris;
      _war.MainBody.materials[0].mainTexture = this.WarBody;
    }), 10);
    _war.PlaceAt(this.Ely_spots[10]);
    _war.Anim.Play("warinjured1");
    _war.LookAtPlayer.Disable = false;
    _war.LookAtPlayer.NonplayerTarget = this.Ely_spots[12];
    for (int index = 0; index < _war.WeaponInv.weapons.Count; ++index)
    {
      if ((UnityEngine.Object) _war.WeaponInv.weapons[index] != (UnityEngine.Object) null)
      {
        _war.WeaponInv.weapons[index].SetActive(false);
        _war.WeaponInv.weapons[index].GetComponent<Weapon>().ActualWeaponModel.gameObject.SetActive(false);
      }
    }
    this.OnWar[2].SetActive(true);
    this.OnWar[2].transform.SetParent(_war.RightHandStuff);
    this.OnWar[2].transform.localPosition = new Vector3(0.226320431f, -0.4597537f, -0.03206368f);
    this.OnWar[2].transform.localEulerAngles = new Vector3(338.9048f, 93.85465f, 82.9336f);
    this.OnWar[3].SetActive(true);
    this.OnWar[3].transform.SetParent(_war.ShoulderLeft);
    this.OnWar[3].transform.localPosition = new Vector3(0.0972f, 0.0505f, 0.0087f);
    this.OnWar[3].transform.localEulerAngles = new Vector3(326.673737f, 351.809357f, 124.25766f);
    (_war as Girl).NoBoobPhysicsOnThisOne = true;
    Main.RunInNextFrame((Action) (() => this.Cameras[0].gameObject.SetActive(true)), 2);
    this.Invoke("WarCutscene3", 5f);
  }

  public void WarCutscene2()
  {
    this.Cameras[0].gameObject.SetActive(false);
    this.Cameras[1].gameObject.SetActive(true);
    this.Invoke("WarCutscene3", 2f);
  }

  public void WarCutscene3()
  {
    this.Cameras[0].gameObject.SetActive(false);
    this.Cameras[1].gameObject.SetActive(false);
    this.Cameras[2].gameObject.SetActive(true);
    Time.timeScale = 0.3f;
    Main.Instance.CityCharacters.War.LookAtPlayer.NonplayerTarget = this.Ely_spots[13];
    this.Invoke("WarCutscene4", 2.75f);
  }

  public void WarCutscene4()
  {
    Time.timeScale = 0.9f;
    UI_Gameplay gameplayMenu = Main.Instance.GameplayMenu;
    Person war = Main.Instance.CityCharacters.War;
    Person zea = Main.Instance.CityCharacters.Zea;
    this.Cameras[2].gameObject.SetActive(false);
    this.Cameras[3].gameObject.SetActive(true);
    war.Anim.Play("warinjured2");
    zea.transform.position = new Vector3(1862.005f, 102.998535f, 1705.875f);
    zea.transform.eulerAngles = new Vector3(0.0f, 99.132f, 0.0f);
    this.Invoke("WarCutscene5", 2f);
  }

  public void WarCutscene5()
  {
    Person war = Main.Instance.CityCharacters.War;
    Person zea = Main.Instance.CityCharacters.Zea;
    Person ely = Main.Instance.CityCharacters.Ely;
    war.PlaceAt(this.Ely_spots[14]);
    war.LookAtPlayer.Disable = true;
    this.OnWar[2].transform.localPosition = new Vector3(0.293f, -0.419f, -0.038f);
    this.OnWar[2].transform.localEulerAngles = new Vector3(328.900574f, 95.2965546f, 82.2968445f);
    this.Cameras[3].gameObject.SetActive(false);
    this.Cameras[4].gameObject.SetActive(true);
    Main.Instance.Player.UserControl.FirstPerson = false;
    zea.LookAtPlayer.Disable = true;
    ely.LookAtPlayer.Disable = true;
    zea.enabled = false;
    zea.Anim.Play("jumpaway");
    ely.Anim.Play("elydeath");
    this.Invoke("WarCutscene6", 0.9f);
  }

  public void WarCutscene6()
  {
    Person war = Main.Instance.CityCharacters.War;
    this.OnWar[2].transform.GetChild(0).gameObject.SetActive(true);
    this.Ely_spots[74].gameObject.SetActive(true);
    war.Anim.Play("warinjured3");
    this.Invoke("WarCutscene7", 1.3f);
  }

  public void WarCutscene7()
  {
    Person war = Main.Instance.CityCharacters.War;
    this.OnWar[2].transform.GetChild(0).gameObject.SetActive(false);
    this.AddGoal(4, true);
    this.Invoke("WarCutscene8", 1.7f);
  }

  public void WarCutscene8()
  {
    Person _war = Main.Instance.CityCharacters.War;
    Main.Instance.Player.RemoveMoveBlocker("WarCutscene");
    Main.Instance.Player._Rigidbody.isKinematic = false;
    this.Cameras[4].gameObject.SetActive(false);
    this.OnWar[2].SetActive(false);
    _war.A_Walking = "Orc Walk2";
    _war.enabled = true;
    _war.RemoveMoveBlocker("Cutscene");
    this.WarWalkTimer = 0.0f;
    Main.Instance.MainThreads.Add(new Action(this.MusicRepeaterWar));
    _war.StartScheduleTask(new Person.ScheduleTask()
    {
      IDName = "war follw player",
      ActionPlace = Main.Instance.Player.transform,
      RunTo = false,
      WhileGoing = (Action) (() =>
      {
        if ((double) this.WarWalkTimer < 40.0)
        {
          this.WarWalkTimer += Time.deltaTime;
          if ((double) this.WarWalkTimer >= 4.0)
          {
            _war.CurrentScheduleTask.RunTo = true;
            _war.navMesh.speed = 6.5f;
            this.WarWalkTimer = 50f;
          }
        }
        _war.RandActionTimer += Time.deltaTime;
        if ((double) _war.RandActionTimer <= 0.20000000298023224)
          return;
        _war.RandActionTimer = 0.0f;
        if ((double) Vector3.Distance(Main.Instance.Player.transform.position, _war.transform.position) > 1.0)
          _war.SetDestination(_war.CurrentScheduleTask.ActionPlace);
        else
          this.OnWarCatchPlayer();
      }),
      OnArrive = (Action) (() => _war.gameObject.SetActive(false))
    });
  }

  public void MusicRepeaterWar()
  {
    if (this.ElyMusicPlayer.isPlaying)
      return;
    Main.Instance.MainThreads.Remove(new Action(this.MusicRepeaterWar));
    this.ElyMusicPlayer.clip = this.Musics[3];
    this.ElyMusicPlayer.loop = true;
    this.ElyMusicPlayer.Play();
  }

  public void OnWarCatchPlayer()
  {
    Person war = Main.Instance.CityCharacters.War;
    Main.Instance.MusicPlayer.mute = false;
    Main.Instance.MusicPlayer.volume = 1f;
    Main.Instance.MusicPlayer.pitch = 1f;
    Main.Instance.MusicPlayer.enabled = true;
    Main.Instance.MusicPlayer.Stop();
    Main.Instance.MusicPlayer.PlayOneShot(Main.Instance.PunchSounds[9]);
    this.FailGoal(4);
    Main.Instance.Player.UserControl.FirstPerson = true;
    Main.Instance.Player.AddMoveBlocker("WarFight");
    Main.Instance.Player._Rigidbody.isKinematic = true;
    Main.Instance.Player.transform.SetParent(war.RightHandStuff);
    this.OriginalPlayerScale = Main.Instance.Player.transform.localScale;
    if (Main.Instance.Player is Girl)
      Main.Instance.Player.transform.localScale = Vector3.one;
    else
      Main.Instance.Player.transform.localScale = new Vector3(0.89f, 0.89f, 0.89f);
    Main.Instance.Player.transform.localPosition = new Vector3(-0.225f, -1.149f, -1.036f);
    Main.Instance.Player.transform.localEulerAngles = new Vector3(343.901276f, 271.601959f, 316.765167f);
    Main.Instance.Player.Anim.enabled = false;
    war.CompleteScheduleTask();
    war.CurrentScheduleTask = (Person.ScheduleTask) null;
    war.AddMoveBlocker("fight");
    war.enabled = false;
    war.navMesh.enabled = false;
    war.Anim.Play("warstrangle2");
    war.BlendShape("k02_open1", 0.0f);
    war.BlendShape("k02_warai2", 86.1f);
    this.Cameras[6].transform.SetParent(war.RightHandStuff);
    this.Cameras[6].transform.localPosition = new Vector3(0.0541f, -0.0007f, 0.0952f);
    this.Cameras[6].transform.localEulerAngles = new Vector3(6.78316832f, 270.238953f, 315.215179f);
    this.Cameras[6].SetActive(true);
    war.LookAtPlayer.Disable = false;
    war.LookAtPlayer.OnlyEyes = true;
    war.LookAtPlayer.NonplayerTarget = this.Cameras[6].transform;
    Main.Instance.MainThreads.Add(new Action(this.HealthDecreaseThread));
    Main.Instance.GameplayMenu.HealthSlider.color = new Color(0.7735849f, 0.0f, 0.0f, 1f);
    this.OnWar[3].transform.localEulerAngles = new Vector3(345.408783f, 357.889526f, 119.209625f);
    this.Ely_spots[75].gameObject.SetActive(true);
    if (!((UnityEngine.Object) Main.Instance.Player.RightArmIK != (UnityEngine.Object) null))
      return;
    if (Main.Instance.Player is Girl)
    {
      Main.Instance.Player.RightArmIK.enabled = true;
      Main.Instance.Player.RightArmIK.Target.SetParent(this.OnWar[3].transform.GetChild(0));
      Main.Instance.Player.RightArmIK.Target.localEulerAngles = Vector3.zero;
      Main.Instance.Player.RightArmIK.Target.localPosition = Vector3.zero;
      Main.Instance.Player.RightHandStuff.parent.Find("cf_J_Hand_Index01_R").localEulerAngles = new Vector3(0.0f, 0.0f, -58f);
      Main.Instance.Player.RightHandStuff.parent.Find("cf_J_Hand_Little01_R").localEulerAngles = new Vector3(0.0f, 0.0f, -58f);
      Main.Instance.Player.RightHandStuff.parent.Find("cf_J_Hand_Middle01_R").localEulerAngles = new Vector3(0.0f, 0.0f, -58f);
      Main.Instance.Player.RightHandStuff.parent.Find("cf_J_Hand_Ring01_R").localEulerAngles = new Vector3(0.0f, 0.0f, -58f);
      Main.Instance.Player.RightHandStuff.parent.Find("cf_J_Hand_Index01_R/cf_J_Hand_Index02_R").localEulerAngles = new Vector3(0.0f, 0.0f, -90f);
      Main.Instance.Player.RightHandStuff.parent.Find("cf_J_Hand_Little01_R/cf_J_Hand_Little02_R").localEulerAngles = new Vector3(0.0f, 0.0f, -90f);
      Main.Instance.Player.RightHandStuff.parent.Find("cf_J_Hand_Middle01_R/cf_J_Hand_Middle02_R").localEulerAngles = new Vector3(0.0f, 0.0f, -90f);
      Main.Instance.Player.RightHandStuff.parent.Find("cf_J_Hand_Ring01_R/cf_J_Hand_Ring02_R").localEulerAngles = new Vector3(0.0f, 0.0f, -90f);
      Main.Instance.Player.RightHandStuff.parent.Find("cf_J_Hand_Index01_R/cf_J_Hand_Index02_R/cf_J_Hand_Index03_R").localEulerAngles = new Vector3(0.0f, 0.0f, -50f);
      Main.Instance.Player.RightHandStuff.parent.Find("cf_J_Hand_Little01_R/cf_J_Hand_Little02_R/cf_J_Hand_Little03_R").localEulerAngles = new Vector3(0.0f, 0.0f, -50f);
      Main.Instance.Player.RightHandStuff.parent.Find("cf_J_Hand_Middle01_R/cf_J_Hand_Middle02_R/cf_J_Hand_Middle03_R").localEulerAngles = new Vector3(0.0f, 0.0f, -50f);
      Main.Instance.Player.RightHandStuff.parent.Find("cf_J_Hand_Ring01_R/cf_J_Hand_Ring02_R/cf_J_Hand_Ring03_R").localEulerAngles = new Vector3(0.0f, 0.0f, -50f);
      Main.Instance.Player.RightArmIK.Pole.localPosition = new Vector3(0.425f, 1.034f, -0.445f);
    }
    else
    {
      Main.Instance.Player.RightArmIK.enabled = true;
      Main.Instance.Player.RightArmIK.Target.SetParent(this.OnWar[3].transform.GetChild(0));
      Main.Instance.Player.RightArmIK.Target.localPosition = new Vector3(-0.0495f, -0.0229f, -0.0153f);
      Main.Instance.Player.RightArmIK.Target.localEulerAngles = new Vector3(0.0f, 0.0f, 43.1671257f);
      Main.Instance.Player.RightArmIK.Pole.localPosition = new Vector3(0.425f, 1.034f, -0.445f);
    }
  }

  public void HealthDecreaseThread()
  {
    Main.Instance.Player.TheHealth.currentHealth -= Time.deltaTime * 150f;
    if ((double) Main.Instance.Player.TheHealth.currentHealth <= 1.0)
    {
      Main.Instance.MainThreads.Remove(new Action(this.HealthDecreaseThread));
      Main.Instance.Player.TheHealth.currentHealth = 0.0f;
      Main.Instance.GameplayMenu.UpdateHealth();
      this.PlayerWarEnd();
    }
    else
    {
      Main.Instance.GameplayMenu.UpdateHealth();
      this.XAXIS = this.OnWar[3].transform.localEulerAngles.x;
      if (Input.GetKey(KeyCode.A))
      {
        if ((double) this.OnWar[3].transform.localEulerAngles.x >= (double) this.XAXISMIN)
          return;
        this.OnWar[3].transform.localEulerAngles += new Vector3(10f, 0.0f, 0.0f);
      }
      else
      {
        if (!Input.GetKey(KeyCode.D) || (double) this.OnWar[3].transform.localEulerAngles.x <= (double) this.XAXISMAX)
          return;
        this.OnWar[3].transform.localEulerAngles -= new Vector3(10f, 0.0f, 0.0f);
      }
    }
  }

  public void PlayerWarEnd()
  {
    Person war = Main.Instance.CityCharacters.War;
    Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[105]);
    war.Anim.enabled = false;
    this.Ely_spots[75].gameObject.SetActive(false);
    this.Cameras[6].GetComponent<Animation>().Play();
    Main.Instance.Player.gameObject.SetActive(false);
    this.Invoke("ghhjhjkgkhjgkhjg", 1f);
  }

  public void MusicLowerThread3()
  {
    this.ElyMusicPlayer.volume -= Time.deltaTime / 5f;
    if ((double) this.ElyMusicPlayer.volume > 0.0)
      return;
    Main.Instance.MainThreads.Remove(new Action(this.MusicLowerThread3));
    this.ElyMusicPlayer.Stop();
  }

  public void ghhjhjkgkhjgkhjg()
  {
    Person _war = Main.Instance.CityCharacters.War;
    this.Cameras[6].transform.SetParent((Transform) null);
    _war.Anim.enabled = true;
    _war.Anim.Play("Death");
    Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[105]);
    Main.Instance.MainThreads.Add(new Action(this.MusicLowerThread3));
    this.Ely_spots[76].gameObject.SetActive(true);
    this.Ely_spots[78].gameObject.SetActive(true);
    string _string;
    AudioClip _clip;
    Main.Instance.GameplayMenu.TheScreenFader.FadeOut(7f, (Action) (() =>
    {
      this.Ely_spots[64 /*0x40*/].gameObject.SetActive(false);
      this.Ely_spots[56].gameObject.SetActive(true);
      this.Ely_spots[57].gameObject.SetActive(true);
      foreach (bl_PlayAnim blPlayAnim in UnityEngine.Object.FindObjectsOfType<bl_PlayAnim>(true))
        blPlayAnim.Start();
      _war.gameObject.SetActive(false);
      Main.Instance.CityCharacters.Ely.gameObject.SetActive(false);
      Main.RunInSeconds((Action) (() =>
      {
        UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
        Person _dad = Main.Instance.CityCharacters.Dad;
        Person _sephie = Main.Instance.CityCharacters.Merussy;
        Person _zea = Main.Instance.CityCharacters.Zea;
        _zea.gameObject.SetActive(true);
        _dad.gameObject.SetActive(true);
        _dad.transform.SetParent((Transform) null);
        _sephie.gameObject.SetActive(true);
        Main.Instance.GameplayMenu.TheScreenFader.FadeIn(15f);
        this.Cameras[6].SetActive(false);
        Main.Instance.Player.gameObject.SetActive(true);
        Main.Instance.Player.transform.SetParent((Transform) null);
        Main.Instance.Player._Rigidbody.isKinematic = true;
        Main.Instance.Player.PlaceAt(this.Ely_spots[77]);
        Main.Instance.Player.Anim.enabled = true;
        Main.Instance.Player.RightArmIK.enabled = false;
        Main.Instance.Player.RightArmIK.Target.SetParent(Main.Instance.Player.transform);
        Main.Instance.Player.Anim.Play("PodFloat");
        Main.RunInNextFrame((Action) (() => Main.Instance.Player.UserControl.Pivot.localPosition = new Vector3(0.0f, 1.7f, -0.2f)), 3);
        Main.Instance.CityCharacters.Merussy.AddMoveBlocker("zea3end");
        _zea.AddMoveBlocker("zea3end");
        Main.Instance.CityCharacters.Dad.PlaceAt(this.Ely_spots[79]);
        Main.Instance.CityCharacters.Merussy.PlaceAt(this.Ely_spots[80 /*0x50*/]);
        _zea.PlaceAt(this.Ely_spots[81]);
        Main.Instance.CityCharacters.Merussy.enabled = true;
        _zea.enabled = false;
        _zea.Anim.enabled = true;
        _zea.Anim.Play("uwushy");
        Main.RunInSeconds((Action) (() =>
        {
          Main.Instance.GameplayMenu.HealthSlider.color = new Color(1f, 1f, 1f, 1f);
          Main.Instance.Player.TheHealth.currentHealth = 30f;
          Main.Instance.Player.TheHealth.maxHealth = 100f;
          Main.Instance.GameplayMenu.UpdateHealth();
          _gameplay.DisplaySubtitle("Heavy lung damage", this.VoiceLines[106], (Action) (() => _gameplay.DisplaySubtitle("had to replace them with some tin ones", this.VoiceLines[107], (Action) (() => _gameplay.DisplaySubtitle("Just my luck", this.VoiceLines[108], (Action) (() => _gameplay.DisplaySubtitle("Not the noisy kind I hope", this.VoiceLines[109], (Action) (() => _gameplay.DisplaySubtitle("Of course not, lol", this.VoiceLines[110], (Action) (() => _gameplay.DisplaySubtitle("The rest should heal on it's own", this.VoiceLines[111], (Action) (() => _gameplay.DisplaySubtitle("if we put Zea in the auxilary we can heal her by tomorrow-", this.VoiceLines[112 /*0x70*/], (Action) (() => _gameplay.DisplaySubtitle("No, we don't need her awake yet", this.VoiceLines[113], (Action) (() => _gameplay.DisplaySubtitle("Let her stay here until we finish a few other things", this.VoiceLines[114], (Action) (() => _gameplay.DisplaySubtitle("But she could help with-", this.VoiceLines[115], (Action) (() => _gameplay.DisplaySubtitle("It won't help, I got this", this.VoiceLines[116], (Action) (() => _gameplay.DisplaySubtitle("Well if you say so", this.VoiceLines[117], (Action) (() =>
          {
            if (Main.Instance.FreeWorldPatch)
            {
              _string = "Hey dad, I'm sorry...";
              _clip = this.VoiceLines[118];
            }
            else
            {
              _string = "Hey (censored)\"friend\", I'm sorry...";
              _clip = (AudioClip) null;
            }
            _gameplay.DisplaySubtitle(_string, _clip, (Action) (() =>
            {
              if (Main.Instance.FreeWorldPatch)
              {
                _string = "I was only doing what mom told me to do";
                _clip = this.VoiceLines[119];
              }
              else
              {
                _string = "I was only doing what (censored)\"friend\" told me to do";
                _clip = (AudioClip) null;
              }
              _gameplay.DisplaySubtitle(_string, _clip, (Action) (() => _gameplay.DisplaySubtitle("She promised a world like back then", this.VoiceLines[120], (Action) (() =>
              {
                _gameplay.DisplaySubtitle("The world back then wasn't as great as you imagine it", this.VoiceLines[121], (Action) (() => _gameplay.DisplaySubtitle("otherwise bombs would never have fell", this.VoiceLines[122], (Action) (() => _sephie.ThisPersonInt.EndTheChat()), _dad)), _dad);
                Main.Instance.GameplayMenu.TheScreenFader.FadeOut(7f, (Action) (() =>
                {
                  _zea.gameObject.SetActive(false);
                  _dad.gameObject.SetActive(false);
                  Main.RunInSeconds((Action) (() =>
                  {
                    Main.Instance.Player.TheHealth.currentHealth = Main.Instance.Player.TheHealth.maxHealth;
                    Main.Instance.GameplayMenu.UpdateHealth();
                    Main.Instance.GameplayMenu.TheScreenFader.FadeIn(5f);
                    _sephie.PlaceAt(this.Ely_spots[82]);
                    Main.RunInSeconds((Action) (() => _gameplay.DisplaySubtitle("Yo good morning", this.VoiceLines[123], (Action) (() => _gameplay.DisplaySubtitle("Two weeks have past", this.VoiceLines[124], (Action) (() => _gameplay.DisplaySubtitle("You're all good now", this.VoiceLines[125], (Action) (() =>
                    {
                      _sephie.ThisPersonInt.EndTheChat();
                      _sephie.ThisPersonInt.RemoveBlocker("SephiePills");
                      _sephie.ThisPersonInt.SetDefaultChat();
                      Main.Instance.Player.UserControl.ResetSpot = Main.Instance.Player.UserControl.OriginalResetSpot;
                      _sephie.RemoveMoveBlocker("zea3end");
                      Main.Instance.Player.PlaceAt(this.Ely_spots[83]);
                      Main.Instance.Player.RemoveMoveBlocker("WarFight");
                      Main.Instance.Player._Rigidbody.isKinematic = false;
                      Main.Instance.Player.UserControl.FirstPerson = false;
                      Main.Instance.Player.transform.localScale = this.OriginalPlayerScale;
                      Main.Instance.GameplayMenu.ShowMessageBox("You've played all missions for this build!\n\nThere's still much more content for you to play throu, in case you've only done the missions so far.\n\nFollow me on Patreon for next updates :3\nPatreon.com/Breakfast5");
                      this.CompleteMission();
                      this.Zea2.MainWindZone.enabled = true;
                      Skybox component = Main.Instance.Player.UserControl.m_Cam.gameObject.GetComponent<Skybox>();
                      if ((UnityEngine.Object) component != (UnityEngine.Object) null)
                        UnityEngine.Object.Destroy((UnityEngine.Object) component);
                      for (int index = 0; index < this._ppl.Count; ++index)
                        this._ppl[index].gameObject.SetActive(true);
                      Main.Instance.CityCharacters.Sarah.LOD.enabled = true;
                      Main.Instance.CityCharacters.Sarah.LodRen.gameObject.SetActive(true);
                      Main.Instance.CityCharacters.Sarah.enabled = true;
                      Main.Instance.CityCharacters.Sarah.MoveBlockers.Clear();
                      Main.Instance.CityCharacters.Sarah.AddMoveBlocker("reset");
                      Main.Instance.CityCharacters.Sarah.RemoveMoveBlocker("reset");
                      this.Ely_spots[35].gameObject.SetActive(false);
                      this.Ely_spots[34].gameObject.SetActive(true);
                      Mis_ZeaMistake objectOfType = UnityEngine.Object.FindObjectOfType<Mis_ZeaMistake>();
                      for (int index = 0; index < objectOfType.PreDamage.Length; ++index)
                      {
                        if ((UnityEngine.Object) objectOfType.PreDamage[index] != (UnityEngine.Object) null)
                          objectOfType.PreDamage[index].SetActive(false);
                      }
                      for (int index = 0; index < objectOfType.AfterDamage.Length; ++index)
                      {
                        if ((UnityEngine.Object) objectOfType.AfterDamage[index] != (UnityEngine.Object) null)
                          objectOfType.AfterDamage[index].SetActive(false);
                      }
                      for (int index = 0; index < objectOfType.AfterDamageFixed.Length; ++index)
                      {
                        if ((UnityEngine.Object) objectOfType.AfterDamageFixed[index] != (UnityEngine.Object) null)
                          objectOfType.AfterDamageFixed[index].SetActive(true);
                      }
                      if (UI_Settings._SpeedrunValue != 0)
                      {
                        Main.Instance.MainThreads.Remove(new Action(Main.Instance.GameplayMenu.SpeedrunThread));
                        UI_Settings._SpeedrunValue = 0;
                        float num = PlayerPrefs.GetFloat("Speedrun_2_f");
                        if ((double) num == 0.0 || (double) num > (double) Main.Instance.GameplayMenu.SpeedrunTimer)
                        {
                          PlayerPrefs.SetFloat("Speedrun_2_f", Main.Instance.GameplayMenu.SpeedrunTimer);
                          PlayerPrefs.SetString("Speedrun_2", Main.Instance.GameplayMenu.SpeedrunLabel.text);
                        }
                        Main.RunInNextFrame((Action) (() => SceneManager.LoadScene(1)), 5);
                      }
                      else
                      {
                        SceneManager.MoveGameObjectToScene(Main.Instance.Player.gameObject, Main.Instance.gameObject.scene);
                        SceneManager.MoveGameObjectToScene(Main.Instance.CityCharacters.Zea.gameObject, Main.Instance.gameObject.scene);
                        SceneManager.UnloadSceneAsync(this.Zea2.SceneToLoad);
                        for (int index = 0; index < this.ESBSToDespawn.Count; ++index)
                        {
                          if ((UnityEngine.Object) this.ESBSToDespawn[index] != (UnityEngine.Object) null)
                            UnityEngine.Object.Destroy((UnityEngine.Object) this.ESBSToDespawn[index]);
                        }
                        _zea.gameObject.SetActive(false);
                        Main.RunInSeconds((Action) (() => _zea.gameObject.SetActive(false)), 1f);
                        Person sia = Main.Instance.CityCharacters.Sia;
                        sia.ThisPersonInt.RemoveBlocker("zeamistaoutside");
                        sia.ApplyFaceBlendShapeData(Main.Instance.BlendShapesDatas[0]);
                        Main.Instance.CanSaveFlags_remove("Zea3Mission");
                        Main.Instance.SaveGame(true);
                      }
                    }), _sephie)), _sephie)), _sephie)), 2f);
                  }), 3f);
                }));
              }), _zea)), _zea);
            }), _zea);
          }), _sephie)), _dad)), _sephie)), _dad)), _dad)), _sephie)), _sephie)), _sephie)), _dad)), _dad)), _sephie)), _sephie);
        }), 1f);
      }), 2f);
    }));
  }

  public void StartSephiePart()
  {
    Main.Instance.GameplayMenu.StartMission((Mission) this);
    this.AddGoal(0, true);
    Main.Instance.GameplayMenu.MapTrackers[2] = Main.Instance.CityCharacters.Merussy.transform;
    Person merussy = Main.Instance.CityCharacters.Merussy;
    merussy.gameObject.SetActive(true);
    merussy.ThisPersonInt.StartTalkFunc = "ChatSephie";
    merussy.ThisPersonInt.StartTalkMono = (MonoBehaviour) this;
    Main.Instance.CityCharacters.Zea.gameObject.SetActive(false);
  }

  public void ChatSephie()
  {
    this.CompleteGoal(0);
    Main.Instance.CanSaveFlags_add("Zea3Mission");
    Main.Instance.MapAreas[0].LocalMusics[4] = Main.Instance.MapAreas[0].LocalMusics[3];
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person _sephie = Main.Instance.CityCharacters.Merussy;
    _sephie.ThisPersonInt.AddBlocker("SephiePills");
    _sephie.AddMoveBlocker("Sephiepills");
    Main.Instance.GameplayMenu.TheScreenFader.FadeOut(1f, (Action) (() =>
    {
      Main.RunInNextFrame((Action) (() => Main.Instance.GameplayMenu.TheScreenFader.FadeIn(1f)));
      _sephie.PlaceAt(this.Ely_spots[16 /*0x10*/]);
      Main.Instance.Player.PlaceAt(this.Ely_spots[17]);
      Main.Instance.Player.AddMoveBlocker("Pils");
      this.Ely_spots[18].SetParent(_sephie.RightHandStuff);
      this.Ely_spots[18].localPosition = new Vector3(0.0518f, -0.0155f, 0.0005f);
      this.Ely_spots[18].localEulerAngles = new Vector3(84.56253f, 280.584f, 193.228348f);
      this.Ely_spots[18].gameObject.SetActive(true);
      this.Ely_spots[20].gameObject.SetActive(true);
      this.Ely_spots[21].gameObject.SetActive(true);
      _sephie.LookAtPlayer.NonplayerTarget = this.Ely_spots[21];
      _sephie.enabled = false;
      _sephie.Anim.Play("ShowIdle");
      Main.RunInSeconds((Action) (() => _gameplay.DisplaySubtitle("These are e-1k pills", this.VoiceLines[69], (Action) (() => _gameplay.DisplaySubtitle("Do you know what they are?", this.VoiceLines[70], (Action) (() =>
      {
        _gameplay.RemoveAllChatOptions();
        _gameplay.AddChatOption("Yes", (Action) (() => _gameplay.DisplaySubtitle("Are you sure?", this.VoiceLines[71], (Action) (() => _gameplay.DisplaySubtitle("A reminder then", this.VoiceLines[72], new Action(this.SephieChat2), _sephie)), _sephie)));
        _gameplay.AddChatOption("No", (Action) (() => _gameplay.DisplaySubtitle("Really? You've taken them in the past", this.VoiceLines[73], new Action(this.SephieChat2), _sephie)));
        _gameplay.SelectChatOption(0);
        Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
      }), _sephie)), _sephie)), 2f);
    }));
  }

  public void SephieChat2()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person _sephie = Main.Instance.CityCharacters.Merussy;
    _gameplay.DisplaySubtitle("These give you super strength, and health points", this.VoiceLines[74], (Action) (() => _gameplay.DisplaySubtitle("But never take more than one", this.VoiceLines[75], (Action) (() => _gameplay.DisplaySubtitle("Your heart will explode", this.VoiceLines[76], (Action) (() => _gameplay.DisplaySubtitle("Go ahead, take one, just one", this.VoiceLines[77], (Action) (() =>
    {
      _sephie.ThisPersonInt.EndTheChat();
      Main.Instance.Player.UserControl.TheCam.m_Target = Main.Instance.Player.transform;
      _sephie.LookAtPlayer.NonplayerTarget = (Transform) null;
      Main.Instance.Player.RemoveMoveBlocker("Pils");
      Main.Instance.Player.UserControl.FirstPerson = true;
      this.Ely_spots[21].gameObject.SetActive(false);
      this.AddGoal(1, true);
      this.Ely_spots[19].gameObject.SetActive(true);
      this.Ely_spots[19].SetParent((Transform) null);
    }), _sephie)), _sephie)), _sephie)), _sephie);
  }

  public void InteractWithPills()
  {
    this.CompleteGoal(1);
    UI_Gameplay gameplayMenu = Main.Instance.GameplayMenu;
    Person _sephie = Main.Instance.CityCharacters.Merussy;
    this.Ely_spots[19].gameObject.SetActive(false);
    this.Ely_spots[18].gameObject.SetActive(false);
    _sephie.enabled = true;
    _sephie.RemoveMoveBlocker("Sephiepills");
    Main.Instance.Player.TheHealth.maxHealth = 1000f;
    Main.Instance.MainThreads.Add(new Action(this.HealthIncreaseThread));
    Main.Instance.GameplayMenu.HealthSlider.color = new Color(0.1273585f, 0.9377292f, 1f, 1f);
    this.Ely_spots[20].gameObject.SetActive(false);
    Main.Instance.GameplayMenu.MapTrackers[0] = Main.Instance.CityCharacters.War.transform;
    _sephie.ThisPersonInt.SetDefaultChat();
    AudioClip voiceLine = this.VoiceLines[78];
    Action after = (Action) (() =>
    {
      _sephie.ThisPersonInt.EndTheChat();
      _sephie.ThisPersonInt.SetDefaultChat();
      this.AddGoal(2, true);
      Person war = Main.Instance.CityCharacters.War;
      war.gameObject.SetActive(true);
      war.AddMoveBlocker("zea3");
      war.navMesh.enabled = false;
      war.PlaceAt(this.Ely_spots[22]);
      war.Anim.Play(war.A_Standing);
      war.ThisPersonInt.AddBlocker("zea3");
      Main.Instance.MainThreads.Add(new Action(this.InteractWithWar));
      this.Ely_spots[28].gameObject.SetActive(false);
      this.Ely_spots[24].gameObject.SetActive(true);
    });
    Person personSaying = _sephie;
    gameplayMenu.DisplaySubtitle("Alright you're good to go", voiceLine, after, personSaying);
  }

  public void HealthIncreaseThread()
  {
    Main.Instance.Player.TheHealth.currentHealth += Time.deltaTime * 70f;
    if ((double) Main.Instance.Player.TheHealth.currentHealth > (double) Main.Instance.Player.TheHealth.maxHealth)
    {
      Main.Instance.MainThreads.Remove(new Action(this.HealthIncreaseThread));
      Main.Instance.Player.TheHealth.currentHealth = Main.Instance.Player.TheHealth.maxHealth;
    }
    Main.Instance.GameplayMenu.UpdateHealth();
  }

  public void InteractWithWar()
  {
    Person _war = Main.Instance.CityCharacters.War;
    if ((double) Vector3.Distance(_war.transform.position, Main.Instance.Player.transform.position) >= 4.0)
      return;
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Main.Instance.MainThreads.Remove(new Action(this.InteractWithWar));
    this.CompleteGoal(2);
    _gameplay.DisplaySubtitle("We found the ESB headquarters", this.VoiceLines[79], (Action) (() => _gameplay.DisplaySubtitle("And their leader is still in there", this.VoiceLines[80 /*0x50*/], (Action) (() => _gameplay.DisplaySubtitle("We are attacking now", this.VoiceLines[81], (Action) (() =>
    {
      bool flag = false;
      for (int index = 0; index < Main.Instance.Player.WeaponInv.weapons.Count; ++index)
      {
        if ((UnityEngine.Object) Main.Instance.Player.WeaponInv.weapons[index] != (UnityEngine.Object) null && Main.Instance.Player.WeaponInv.weapons[index].GetComponent<Weapon>().type == WeaponType.Raycast)
        {
          flag = true;
          break;
        }
      }
      if (flag)
      {
        _war.ThisPersonInt.EndTheChat();
        this.Goals[2].Title = "Enter Tank";
        this.AddGoal(2, true);
        this.Ely_spots[24].GetComponent<Interactible>().RemoveBlocker("mission");
        _war.StartScheduleTask(new Person.ScheduleTask()
        {
          IDName = "_wartanbkest",
          ActionPlace = this.Ely_spots[29],
          RunTo = true,
          OnArrive = (Action) (() => _war.gameObject.SetActive(false))
        });
      }
      else
        _gameplay.DisplaySubtitle("Go get a gun and come here asap", this.VoiceLines[104], (Action) (() =>
        {
          _war.ThisPersonInt.EndTheChat();
          this.Goals[2].Title = "Find a gun";
          this.AddGoal(2, true);
          Main.Instance.MainThreads.Add(new Action(this.FindGunThread));
        }), _war);
    }), _war)), _war)), _war);
  }

  public void FindGunThread()
  {
    for (int index = 0; index < Main.Instance.Player.WeaponInv.weapons.Count; ++index)
    {
      if ((UnityEngine.Object) Main.Instance.Player.WeaponInv.weapons[index] != (UnityEngine.Object) null && Main.Instance.Player.WeaponInv.weapons[index].GetComponent<Weapon>().type == WeaponType.Raycast)
      {
        Main.Instance.MainThreads.Remove(new Action(this.FindGunThread));
        this.CompleteGoal(2);
        this.Goals[2].Title = "Enter Tank";
        this.AddGoal(2, true);
        this.Ely_spots[24].GetComponent<Interactible>().RemoveBlocker("mission");
        Person _war = Main.Instance.CityCharacters.War;
        _war.StartScheduleTask(new Person.ScheduleTask()
        {
          IDName = "_wartanbkest",
          ActionPlace = this.Ely_spots[29],
          RunTo = true,
          OnArrive = (Action) (() => _war.gameObject.SetActive(false))
        });
      }
    }
  }

  public void EnterTank()
  {
    this.Zea2.MainWindZone.enabled = false;
    this.Zea2.MainWindZone.Sound.Stop();
    Person war = Main.Instance.CityCharacters.War;
    this.CompleteGoal(2);
    this.Ely_spots[23].gameObject.SetActive(true);
    Main.Instance.Player.AddMoveBlocker("InTank");
    Main.Instance.Player._Rigidbody.isKinematic = true;
    Main.Instance.Player.PlaceAt(this.Ely_spots[25]);
    Main.Instance.Player.Anim.Play("sit_00");
    Main.Instance.Player.transform.SetParent(this.Ely_spots[25]);
    war.AddMoveBlocker("InTruck");
    war.gameObject.SetActive(true);
    war.PlaceAt(this.Ely_spots[26]);
    war.enabled = false;
    war.navMesh.enabled = false;
    war.Anim.Play("sit_drive");
    war.transform.SetParent(this.Ely_spots[26]);
    Main.Instance.Player.UserControl.FirstPerson = true;
    Main.Instance.Player.UserControl.Pivot.localPosition = Vector3.zero;
    Transform transform = new GameObject("1stpersonspot").transform;
    transform.SetParent(Main.Instance.Player.UserControl.FirstPersonViewSpot);
    transform.localPosition = new Vector3(0.0f, 0.0066f, -0.0752f);
    transform.localEulerAngles = Vector3.zero;
    Main.Instance.Player.UserControl.TheCam.m_Target = transform;
    this.Invoke("InsideTankChat1", 2f);
  }

  public void InsideTankChat1()
  {
    this.Zea2.MainWindZone.enabled = false;
    this.Zea2.MainWindZone.Sound.Stop();
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person _war = Main.Instance.CityCharacters.War;
    _gameplay.DisplaySubtitle("It's just like riding a bicycle", this.VoiceLines[82], (Action) (() => _gameplay.DisplaySubtitle("There is no time to waste", this.VoiceLines[84], (Action) (() => _gameplay.DisplaySubtitle("We are going to storm throu everything, to get to their leader", this.VoiceLines[85], (Action) (() => _gameplay.DisplaySubtitle("Anyone else in the way doesn't matter", this.VoiceLines[86], (Action) (() =>
    {
      this.Ely_spots[27].gameObject.SetActive(true);
      _war.LookAtPlayer.NonplayerTarget = this.Ely_spots[27];
      _gameplay.DisplaySubtitle("Get on that turret", this.VoiceLines[83], (Action) (() =>
      {
        _war.ThisPersonInt.EndTheChat();
        _war.LookAtPlayer.NonplayerTarget = (Transform) null;
        Main.Instance.Player.Interacting = false;
        Main.Instance.Player.MoveBlockers.Clear();
        this.Goals[2].Title = "(look up) Use Turret";
        this.AddGoal(2, true);
      }), _war);
    }), _war)), _war)), _war)), _war);
  }

  public void InteractWithTurret()
  {
    this.Zea2.MainWindZone.enabled = false;
    this.Zea2.MainWindZone.Sound.Stop();
    this.CompleteGoal(2);
    this.Ely_spots[27].gameObject.SetActive(false);
    this.Ely_spots[23].gameObject.SetActive(false);
    this.Ely_spots[30].gameObject.SetActive(false);
    this.Ely_spots[31 /*0x1F*/].gameObject.SetActive(true);
    this.Ely_spots[31 /*0x1F*/].GetComponentInChildren<Int_Turret>().Interact(Main.Instance.Player);
    Main.Instance.Player.Interacting = false;
    Main.Instance.Player.AddMoveBlocker("Quest");
    this.Ely_spots[34].gameObject.SetActive(false);
    this.Ely_spots[35].gameObject.SetActive(true);
    Person _sarah = Main.Instance.CityCharacters.Sarah;
    _sarah.PlaceAt(this.Ely_spots[36]);
    _sarah.LodRen.gameObject.SetActive(false);
    _sarah.LOD.enabled = false;
    _sarah.SetLowLod();
    _sarah.enabled = false;
    _sarah.Anim.enabled = true;
    Main.RunInSeconds((Action) (() => _sarah.Anim.Play("waveGate")), 1f);
    Main.RunInSeconds((Action) (() => _sarah.Anim.Play("waveGate")), 2f);
    Animation _anim = this.TankAnim;
    _anim.enabled = true;
    _anim["tankcity"].time = 0.0f;
    _anim.Play("tankcity");
    this.TankEngine.gameObject.SetActive(true);
    this.TankTripState = 0;
    Main.Instance.MainThreads.Add(new Action(this.WhileTrip));
    Main.RunInNextFrame((Action) (() =>
    {
      _anim.enabled = true;
      _anim["tankcity"].time = 0.0f;
      _anim.Play("tankcity");
    }));
    Main.RunInNextFrame((Action) (() =>
    {
      _anim.enabled = true;
      _anim["tankcity"].time = 0.0f;
      _anim.Play("tankcity");
    }), 2);
    Main.RunInNextFrame((Action) (() =>
    {
      _anim.enabled = true;
      _anim["tankcity"].time = 0.0f;
      _anim.Play("tankcity");
    }), 3);
    Main.RunInNextFrame((Action) (() =>
    {
      _anim.enabled = true;
      _anim["tankcity"].time = 0.0f;
      _anim.Play("tankcity");
    }), 5);
    this._ppl.Clear();
    for (int index = 0; index < Main.Instance.SpawnedPeople.Count; ++index)
    {
      if ((UnityEngine.Object) Main.Instance.SpawnedPeople[index] != (UnityEngine.Object) null && !Main.Instance.SpawnedPeople[index].IsPlayer && (UnityEngine.Object) Main.Instance.SpawnedPeople[index].PersonType != (UnityEngine.Object) null && Main.Instance.SpawnedPeople[index].PersonType.ThisType != Person_Type.Clean && Main.Instance.SpawnedPeople[index].gameObject.activeInHierarchy)
      {
        this._ppl.Add(Main.Instance.SpawnedPeople[index].gameObject);
        Main.Instance.SpawnedPeople[index].gameObject.SetActive(false);
      }
    }
    _sarah.gameObject.SetActive(true);
    this.Invoke("ShowLoadingSmall", 9f);
    this.Invoke("StartFading1", 13f);
  }

  public void ShowLoadingSmall()
  {
    this.Zea2.MainWindZone.enabled = false;
    this.Zea2.MainWindZone.Sound.Stop();
    Main.Instance.NewGameMenu.SmallLoading.SetActive(true);
  }

  public void StartFading1()
  {
    Main.Instance.GameplayMenu.TheScreenFader.FadeOut(1.5f, (Action) (() => this.StartLoadingOtherPlace()));
  }

  public void StartLoadingOtherPlace()
  {
    Main.RunInNextFrame((Action) (() =>
    {
      Main.Instance.DayCycle.enabled = false;
      Main.Instance.DayCycle.ResetMidday();
      SceneManager.LoadScene(this.Zea2.SceneToLoad, LoadSceneMode.Additive);
      Main.RunInNextFrame((Action) (() =>
      {
        Main.Instance.OnFinallyGenerate.Clear();
        Main.Instance.OnAfterFinallyGenerate.Clear();
        Main.Instance.OnFinallyGenerate.Add((Action) (() =>
        {
          Main.Instance.GameplayMenu.TheScreenFader.FadeIn(1f);
          Main.Instance.NewGameMenu.SmallLoading.SetActive(false);
          this.Ely_spots[24].PlaceAt(this.Ely_spots[32 /*0x20*/]);
          this.Ely_spots[37].gameObject.SetActive(true);
          this.Zea2.MainWindZone.enabled = false;
          this.Zea2.MainWindZone.Sound.Stop();
          Main.RunInNextFrame((Action) (() =>
          {
            this.TankAnim["tanktrip"].time = 0.0f;
            this.TankAnim.Play("tanktrip");
          }));
          Main.RunInNextFrame((Action) (() =>
          {
            this.TankAnim["tanktrip"].time = 0.0f;
            this.TankAnim.Play("tanktrip");
          }), 2);
          Main.RunInNextFrame((Action) (() =>
          {
            this.TankAnim["tanktrip"].time = 0.0f;
            this.TankAnim.Play("tanktrip");
          }), 3);
          Main.RunInNextFrame((Action) (() =>
          {
            this.TankAnim["tanktrip"].time = 0.0f;
            this.TankAnim.Play("tanktrip");
          }), 5);
          Main.RunInSeconds((Action) (() => this.ExitedCity = true), 5f);
          Main.Instance.Player.UserControl.m_Cam.gameObject.AddComponent<Skybox>().material = this.Skys[1];
          this.Ely_spots[33].gameObject.AddComponent<Skybox>().material = this.Skys[1];
          this.TankTripSkyArea.OnEnter();
          this.Ely_spots[40].gameObject.SetActive(true);
          this.Ely_spots[53].gameObject.SetActive(true);
          this.Ely_spots[56].gameObject.SetActive(false);
          this.Ely_spots[58].gameObject.SetActive(false);
          this.Ely_spots[59].gameObject.SetActive(true);
          this.BattleMusic.Play();
          this.BattleMusic.volume = 0.0f;
          Main.Instance.MainThreads.Add(new Action(this.MusicThread));
        }));
        Main.Instance.GenerateNav();
      }), 4);
    }), 4);
  }

  public void MusicThread()
  {
    this.BattleMusic.volume += Time.deltaTime * 0.1f;
    if ((double) this.BattleMusic.volume < 1.0)
      return;
    Main.Instance.MainThreads.Remove(new Action(this.MusicThread));
  }

  public void WhileTrip()
  {
    this.TankEngine.pitch = (float) (0.30000001192092896 + (double) this.TankRigid.velocity.magnitude / 20.0);
    this._TankTime = this.TankAnim["tanktrip"].time;
    switch (this.TankTripState)
    {
      case 0:
        if ((double) this._TankTime <= 9.8999996185302734)
          break;
        ++this.TankTripState;
        this.TankFire();
        break;
      case 1:
        if ((double) this._TankTime <= 11.0)
          break;
        ++this.TankTripState;
        this.Ely_spots[39].gameObject.SetActive(true);
        break;
      case 2:
        if ((double) this._TankTime <= 15.5)
          break;
        ++this.TankTripState;
        break;
      case 3:
        if ((double) this._TankTime <= 30.0)
          break;
        ++this.TankTripState;
        this.Ely_spots[52].gameObject.SetActive(true);
        break;
      case 4:
        if ((double) this._TankTime <= 42.0)
          break;
        ++this.TankTripState;
        this.Ely_spots[41].gameObject.SetActive(true);
        this.Ely_spots[61].gameObject.SetActive(true);
        break;
      case 5:
        if ((double) this._TankTime <= 60.0)
          break;
        ++this.TankTripState;
        Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[90]);
        break;
      case 6:
        if ((double) this._TankTime <= 65.0)
          break;
        ++this.TankTripState;
        this.Ely_spots[42].gameObject.SetActive(true);
        this.Ely_spots[62].gameObject.SetActive(true);
        this.Ely_spots[63 /*0x3F*/].gameObject.SetActive(true);
        break;
      case 7:
        if ((double) this._TankTime <= 75.0)
          break;
        ++this.TankTripState;
        this.Ely_spots[60].gameObject.SetActive(true);
        break;
      case 8:
        if ((double) this._TankTime <= 88.0)
          break;
        ++this.TankTripState;
        this.Ely_spots[59].GetComponent<Animation>().Play();
        this.Ely_spots[59].Find("Plane.000/Plane.004").gameObject.SetActive(false);
        this.Ely_spots[59].Find("Plane.002/Plane.003").gameObject.SetActive(false);
        this.Ely_spots[64 /*0x40*/].gameObject.SetActive(true);
        break;
      case 9:
        if ((double) this._TankTime <= 92.0)
          break;
        ++this.TankTripState;
        Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[90]);
        break;
      case 10:
        if ((double) this._TankTime <= 94.0)
          break;
        ++this.TankTripState;
        Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[90]);
        break;
      case 11:
        if ((double) this._TankTime <= 95.0)
          break;
        ++this.TankTripState;
        Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[90]);
        break;
      case 12:
        if ((double) this._TankTime <= 98.5999984741211)
          break;
        ++this.TankTripState;
        Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[96 /*0x60*/]);
        break;
      case 13:
        if ((double) this._TankTime <= 100.0)
          break;
        ++this.TankTripState;
        this.Ely_spots[38].gameObject.SetActive(true);
        break;
      case 14:
        if ((double) this._TankTime <= 101.0)
          break;
        ++this.TankTripState;
        Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[90]);
        break;
      case 15:
        if ((double) this._TankTime <= 104.0)
          break;
        ++this.TankTripState;
        Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[90]);
        break;
      case 16 /*0x10*/:
        if ((double) this._TankTime <= 117.0)
          break;
        ++this.TankTripState;
        Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[90]);
        break;
      case 17:
        if ((double) this._TankTime <= 122.0)
          break;
        ++this.TankTripState;
        this.Ely_spots[73].gameObject.SetActive(true);
        break;
      case 18:
        if ((double) this._TankTime <= 129.69999694824219)
          break;
        ++this.TankTripState;
        Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[90]);
        break;
      case 19:
        if ((double) this._TankTime <= 132.80000305175781)
          break;
        ++this.TankTripState;
        Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[92]);
        this.Ely_spots[43].gameObject.SetActive(false);
        this.Ely_spots[44].gameObject.SetActive(true);
        break;
      case 20:
        if ((double) this._TankTime <= 134.30000305175781)
          break;
        ++this.TankTripState;
        Main.Instance.MusicPlayer.volume = 0.4f;
        Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[94]);
        this.Ely_spots[45].localEulerAngles = new Vector3();
        break;
      case 21:
        if ((double) this._TankTime <= 134.80000305175781)
          break;
        ++this.TankTripState;
        Main.Instance.MusicPlayer.volume = 1f;
        Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[93]);
        this.Ely_spots[46].gameObject.SetActive(false);
        this.Ely_spots[47].gameObject.SetActive(true);
        break;
      case 22:
        if ((double) this._TankTime <= 137.5)
          break;
        ++this.TankTripState;
        Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[88]);
        this.Ely_spots[48 /*0x30*/].gameObject.SetActive(false);
        this.Zea2.HeadQuarters_BeforeAndAfter[1].SetActive(true);
        this.Zea2.HeadQuarters_BeforeAndAfter[3].SetActive(true);
        break;
      case 23:
        if ((double) this._TankTime <= 138.60000610351563)
          break;
        ++this.TankTripState;
        Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[91]);
        this.Ely_spots[49].GetComponent<Animation>().Play();
        break;
      case 24:
        if ((double) this._TankTime <= 140.80000305175781)
          break;
        ++this.TankTripState;
        Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[87]);
        this.Ely_spots[50].gameObject.SetActive(false);
        this.Ely_spots[51].gameObject.SetActive(true);
        break;
      case 25:
        if ((double) this._TankTime <= 142.0)
          break;
        ++this.TankTripState;
        this.Tank2ndPart();
        Main.Instance.MainThreads.Remove(new Action(this.WhileTrip));
        break;
    }
  }

  public void BridgeDownFunc()
  {
    UI_Gameplay gameplayMenu = Main.Instance.GameplayMenu;
    Person war = Main.Instance.CityCharacters.War;
    gameplayMenu.DisplaySubtitle("Bridge ahead", this.VoiceLines[0], (Action) (() => { }), Main.Instance.CityCharacters.Sia);
    gameplayMenu.DisplaySubtitle("Not anymore", this.VoiceLines[0], (Action) (() => { }), war);
  }

  public void ESBSpawn(Person person)
  {
    this.SpawnedESBs.Add(person);
    person.LOD.enabled = false;
    person.LodRen.gameObject.SetActive(false);
    person.SetLowLod();
    person._ShootBlind = true;
    person.CombatDistance = 10000f;
    Person component = this.Ely_spots[24].GetComponent<Person>();
    person.StartFighting(component);
    for (int index = 0; index < person.WeaponInv.weapons.Count; ++index)
    {
      if ((UnityEngine.Object) person.WeaponInv.weapons[index] != (UnityEngine.Object) null)
      {
        person.WeaponInv.weapons[index].GetComponentInChildren<Weapon>().fireSounds = this.FireSounds;
        person.WeaponInv.weapons[index].GetComponentInChildren<Weapon>().WeaponAudioSource.spatialBlend = 0.0f;
      }
    }
  }

  public void ESBSpawn_2(Person person)
  {
    this.ESBSpawn(person);
    person.AddMoveBlocker("asdasd");
    person.navMesh.enabled = false;
    person.transform.SetParent(this.Ely_spots[41]);
  }

  public void ESBSpawn_3(Person person)
  {
    this.ESBSpawn(person);
    person.AddMoveBlocker("asdasd");
    person.navMesh.enabled = false;
    person.transform.SetParent(this.Ely_spots[42]);
  }

  public void RunOver(Person person)
  {
    person.TheHealth.ChangeHealth(-999f, true, Main.Instance.Player);
  }

  public void TankFire()
  {
    UnityEngine.Object.Instantiate<GameObject>(this.TankBulletPrefab, this.Ely_spots[55].position, this.Ely_spots[55].rotation).SendMessage("MultiplyInitialForce", (object) 3, SendMessageOptions.DontRequireReceiver);
    this.Ely_spots[54].gameObject.SetActive(true);
    this.Ely_spots[54].GetComponent<ParticleSystem>().Play();
    Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[95]);
  }

  public void MusicLowerThread()
  {
    this.BattleMusic.volume -= Time.deltaTime * 0.5f;
    if ((double) this.BattleMusic.volume > 0.10000000149011612)
      return;
    Main.Instance.MainThreads.Remove(new Action(this.MusicLowerThread));
    this.BattleMusic.volume = 0.1f;
  }

  public void Tank2ndPart()
  {
    this.Zea2.MainWindZone.enabled = false;
    this.Zea2.MainWindZone.Sound.Stop();
    UI_Gameplay gameplayMenu = Main.Instance.GameplayMenu;
    Person war = Main.Instance.CityCharacters.War;
    Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[89]);
    Main.Instance.MainThreads.Add(new Action(this.MusicLowerThread));
    for (int index = 0; index < this.SpawnedESBs.Count; ++index)
      this.SpawnedESBs[index].gameObject.SetActive(false);
    this.Ely_spots[24].gameObject.SetActive(false);
    this.Ely_spots[23].PlaceAt(this.Ely_spots[65]);
    this.Ely_spots[23].gameObject.SetActive(true);
    if ((UnityEngine.Object) Main.Instance.Player.InteractingWith != (UnityEngine.Object) null)
      Main.Instance.Player.InteractingWith.StopInteracting();
    Main.Instance.Player.gameObject.SetActive(true);
    Main.Instance.Player.Anim.Play("sit_00");
    war.Anim.Play("sit_drive");
    Main.Instance.Player.UserControl.FirstPerson = true;
    Main.Instance.Player.UserControl.Pivot.localPosition = Vector3.zero;
    Transform transform = Main.Instance.Player.UserControl.FirstPersonViewSpot.Find("1stpersonspot");
    Main.Instance.Player.UserControl.TheCam.m_Target = transform;
    war.LookAtPlayer.NonplayerTarget = this.Ely_spots[18];
    this.Ely_spots[18].SetParent(war.RightHandStuff);
    this.Ely_spots[18].localPosition = new Vector3(0.0618f, -0.0256f, 0.0264f);
    this.Ely_spots[18].localEulerAngles = new Vector3(345.501282f, 2.85843587f, 24.3728466f);
    this.Invoke("WarTalk2", 4f);
  }

  public void WarTalk2()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person _war = Main.Instance.CityCharacters.War;
    _war.LookAtPlayer.Disable = true;
    _war.LookAtPlayer.enabled = false;
    _war.Anim.Play("WarTakePills");
    this.Ely_spots[53].gameObject.SetActive(false);
    this.Ely_spots[24].GetComponent<Interactible>().AddBlocker("quest");
    _gameplay.DisplaySubtitle("Just like that old song used to say", this.VoiceLines[97], (Action) (() =>
    {
      this.Ely_spots[18].gameObject.SetActive(true);
      _gameplay.DisplaySubtitle("It's a fine day to die", this.VoiceLines[98], (Action) (() =>
      {
        _war.ThisPersonInt.EndTheChat();
        this.Invoke("ExitTank1", 2f);
      }), _war);
    }), _war);
  }

  public void ExitTank1()
  {
    this.Zea2.MainWindZone.enabled = false;
    this.Zea2.MainWindZone.Sound.Stop();
    this.BattleMusic.Stop();
    this.Areas[1].OnEnter();
    this.Zea2.SpawnSpots[28].gameObject.SetActive(true);
    Person war = Main.Instance.CityCharacters.War;
    Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[89]);
    Main.Instance.Player.TheHealth.NoLoseRespawn = true;
    Main.Instance.Player.transform.SetParent((Transform) null);
    Main.Instance.Player.PlaceAt(this.Ely_spots[67]);
    Main.Instance.Player.Anim.Play(Main.Instance.Player.A_Standing);
    Main.Instance.Player.AddMoveBlocker("warstrangle");
    war.transform.SetParent((Transform) null);
    war.PlaceAt(this.Ely_spots[68]);
    this.Ely_spots[69].gameObject.SetActive(true);
    this.Ely_spots[18].gameObject.SetActive(false);
    this.Ely_spots[23].gameObject.SetActive(false);
    this.Ely_spots[24].gameObject.SetActive(true);
    this.TankAnim.enabled = false;
    this.TankAnim.clip = (AnimationClip) null;
    this.TankAnim.RemoveClip("tanktrip");
    this.TankAnim.RemoveClip("tankcity");
    this.TankAnim.enabled = false;
    this.Ely_spots[24].localPosition = new Vector3(1799.87f, 103.01f, 1713.7f);
    this.Ely_spots[24].localEulerAngles = new Vector3(0.0f, 79.65f, 0.0f);
    Main.Instance.Player.UserControl.ResetSpot = this.Ely_spots[67];
    Main.Instance.PlayerWakeupPlaces.Clear();
    Main.Instance.PlayerWakeupPlaces.Add(this.Ely_spots[67]);
  }

  public void EsbInsideSpawn(Person person)
  {
    this.ESBEntrance = person;
    Person _war = Main.Instance.CityCharacters.War;
    UI_Gameplay gameplayMenu = Main.Instance.GameplayMenu;
    person.AddMoveBlocker("asdasd");
    person.enabled = false;
    person.Anim.Play("RifleCombatIdle");
    person.transform.localScale = Vector3.one;
    person.VoicePitch = 1.05f;
    AudioClip voiceLine = this.VoiceLines[99];
    Action after = new Action(person.ThisPersonInt.EndTheChat);
    Person personSaying = person;
    gameplayMenu.DisplaySubtitle("Stop right there!", voiceLine, after, personSaying);
    _war.enabled = true;
    _war.RemoveMoveBlocker("InTruck");
    _war.A_Walking = "Orc Walk2";
    _war.StartScheduleTask(new Person.ScheduleTask()
    {
      IDName = "_wargotoesb",
      ActionPlace = this.Ely_spots[70],
      RunTo = false,
      OnArrive = (Action) (() =>
      {
        person.WeaponInv.DropAllWeapons();
        _war.enabled = false;
        _war.Anim.Play("warstrangle1");
        person.Anim.Play("strangle1");
        person.transform.SetParent(_war.RightHandStuff);
        person.transform.localPosition = new Vector3(-0.818f, -0.257f, -1.196f);
        person.transform.localEulerAngles = new Vector3(1.449432f, 306.370422f, 279.1677f);
        person.PersonAudio.PlayOneShot(this.VoiceLines[100]);
        this.Invoke("RagdollESB", 2.5f);
        this.Invoke("WarStrangle1End", 3f);
      })
    });
  }

  public void RagdollESB()
  {
    this.ESBEntrance.transform.SetParent((Transform) null);
    this.ESBEntrance.TheHealth.Die();
  }

  public void WarStrangle1End()
  {
    Person _war = Main.Instance.CityCharacters.War;
    _war.enabled = true;
    _war.StartScheduleTask(new Person.ScheduleTask()
    {
      IDName = "_wargotoesb2",
      ActionPlace = this.Ely_spots[71],
      RunTo = true,
      OnArrive = (Action) (() =>
      {
        _war.gameObject.SetActive(false);
        Main.Instance.Player.UserControl.TheCam.m_Target = Main.Instance.Player.transform;
        Main.Instance.Player.UserControl.FirstPerson = false;
        Main.Instance.Player.RemoveMoveBlocker("warstrangle");
        Main.Instance.Player.RemoveMoveBlocker("Quest");
        Main.Instance.Player._Rigidbody.isKinematic = false;
        Interactible component = this.Ely_spots[72].GetComponent<Interactible>();
        this.Ely_spots[72].localEulerAngles = new Vector3(0.0f, 90f, 0.0f);
        component.RemoveBlocker("zea2");
        component.CanInteract = true;
      })
    });
  }

  public void OpenLightDoor()
  {
    Interactible component = this.Ely_spots[72].GetComponent<Interactible>();
    component.AddBlocker("zea3");
    Main.Instance.MusicPlayer.PlayOneShot(Main.Instance.DoorMove);
    component.GetComponent<Animation>().Play();
    this.Zea2.MainWindZone.enabled = false;
    this.Zea2.MainWindZone.Sound.Stop();
  }
}
