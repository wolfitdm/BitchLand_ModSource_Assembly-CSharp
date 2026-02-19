// Decompiled with JetBrains decompiler
// Type: Mis_ZeaMistake
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class Mis_ZeaMistake : Mission
{
  [Space]
  public AudioClip[] VoiceLines;
  public GameObject[] Objs;
  public GameObject[] PreDamage;
  public GameObject[] AfterDamage;
  public GameObject[] AfterDamageFixed;
  public Transform[] SewerSpawnSpots;
  public GameObject[] Bullets;
  public GameObject[] DisableSirenObjs;
  public GameObject[] EnableSirenObjs;
  public GameObject[] EnableSirenObjsAfterFix;
  public AudioSource[] SirenSounds;
  public Int_Door[] DoorsToCloseAndLock;
  public int_Lockable[] LocksToLock;
  public GameObject NoBack;
  public List<Person> _OrgClubPpl = new List<Person>();
  public List<Person> _OrgPlazaPpl = new List<Person>();
  public List<Person> _OrgStreetPpl = new List<Person>();
  public float WaitTimer;

  public bool MissionCanStart() => Main.Instance.AllMissions[13].CompletedMission;

  public override void InitMission()
  {
    if (this._Inited)
      return;
    base.InitMission();
    this.CurrentGoal = this.Goals[0];
    if (!this.CurrentGoal.Completed)
      this.PrepareZea();
    else
      this.CompletedMission = true;
    if (!this.CompletedMission)
    {
      Main.Instance.GameplayMenu.DisplayGoal(this.CurrentGoal, true);
      Main.Instance.GameplayMenu.MapTrackers[0] = Main.Instance.CityCharacters.Zea.transform;
    }
    else
    {
      for (int index = 0; index < this.PreDamage.Length; ++index)
        this.PreDamage[index].SetActive(false);
      for (int index = 0; index < this.AfterDamage.Length; ++index)
        this.AfterDamage[index].SetActive(true);
      this.AfterDamage[4].SetActive(false);
      if (Main.Instance.AllMissions[15].CompletedMission)
        return;
      Main.Instance.AllMissions[15].InitMission();
    }
  }

  public void PrepareSephieLab()
  {
    Person merussy = Main.Instance.CityCharacters.Merussy;
    this.Objs[0].SetActive(true);
    Int_Door componentInChildren1 = this.Objs[6].GetComponentInChildren<Int_Door>();
    componentInChildren1.CloseDoor();
    componentInChildren1.Locked = true;
    Int_Door componentInChildren2 = this.Objs[7].GetComponentInChildren<Int_Door>();
    componentInChildren2.CloseDoor();
    componentInChildren2.Locked = true;
    merussy.State = Person_State.Work;
    merussy.AddMoveBlocker("ZeaMistake");
    merussy.enabled = false;
    merussy.navMesh.enabled = false;
    merussy.PlaceAt(this.Objs[2].transform);
    merussy.ThisPersonInt.AddBlocker("ZeaMistake");
    this.CompleteGoal(2);
    this.AddGoal(3, true);
  }

  public void TriggerSephie()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person merussy = Main.Instance.CityCharacters.Merussy;
    this.Objs[1].SetActive(true);
    Main.Instance.Player.AddMoveBlocker("ZeaMistake_Lab");
    _gameplay.DisplaySubtitle("You again, what are you doing here?", this.VoiceLines[4], (Action) (() =>
    {
      _gameplay.RemoveAllChatOptions();
      _gameplay.AddChatOption("Uh...I don't know", (Action) (() => this.SephieTalkedWith(0)));
      _gameplay.AddChatOption("I'm looking for a thing", (Action) (() => this.SephieTalkedWith(1)));
      _gameplay.AddChatOption("I'm looking for box 200", (Action) (() => this.SephieTalkedWith(2)));
      _gameplay.AddChatOption("Zea sent me here to find something", (Action) (() => this.SephieTalkedWith(1)));
      _gameplay.AddChatOption("Zea sent me here to find box 200", (Action) (() => this.SephieTalkedWith(2)));
      _gameplay.SelectChatOption(0);
      Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
    }), merussy);
  }

  public void SephieTalkedWith(int sephieChoice)
  {
    UI_Gameplay gameplayMenu = Main.Instance.GameplayMenu;
    Person _sephie = Main.Instance.CityCharacters.Merussy;
    Action after = (Action) (() =>
    {
      _sephie.ThisPersonInt.EndTheChat();
      Main.Instance.GameplayMenu.TheScreenFader.FadeOut(2f, (Action) (() =>
      {
        Main.RunInNextFrame((Action) (() => Main.Instance.GameplayMenu.TheScreenFader.FadeIn(1f)));
        this.Objs[4].GetComponent<int_Lockable>().Locked = true;
        this.Objs[21].SetActive(true);
        Main.Instance.Player.PlaceAt(this.Objs[3].transform);
        Main.Instance.Player.RemoveMoveBlocker("ZeaMistake_Lab");
        this.FailGoal(3);
        this.AddGoal(4, true);
        for (int index = 0; index < Main.Instance.SpawnedPeople.Count; ++index)
        {
          if ((UnityEngine.Object) Main.Instance.SpawnedPeople[index] != (UnityEngine.Object) null && !Main.Instance.SpawnedPeople[index].IsPlayer && (UnityEngine.Object) Main.Instance.SpawnedPeople[index].PersonType != (UnityEngine.Object) null && Main.Instance.SpawnedPeople[index].PersonType.ThisType != Person_Type.Clean)
            Main.Instance.SpawnedPeople[index].gameObject.SetActive(false);
        }
        for (int index = 0; index < this.DoorsToCloseAndLock.Length; ++index)
        {
          this.DoorsToCloseAndLock[index].CloseDoor();
          this.DoorsToCloseAndLock[index].Locked = true;
        }
        _sephie.State = Person_State.Free;
        _sephie.RemoveMoveBlocker("ZeaMistake");
        _sephie.enabled = true;
        _sephie.navMesh.enabled = true;
        _sephie.ThisPersonInt.RemoveBlocker("ZeaMistake");
      }));
    });
    switch (sephieChoice)
    {
      case 0:
        gameplayMenu.DisplaySubtitle("Oh yeah? Get outta here", this.VoiceLines[5], after, _sephie);
        break;
      case 1:
        gameplayMenu.DisplaySubtitle("There's no such thing here, get out", this.VoiceLines[6], after, _sephie);
        break;
      case 2:
        gameplayMenu.DisplaySubtitle("No such thing exists, there aren't even that many boxes here, so get out", this.VoiceLines[7], after, _sephie);
        break;
    }
  }

  public void TriggerLab() => this.PrepareSephieLab();

  public void TriggerSirens()
  {
    Debug.LogError((object) "Sirens Triggered");
    Main.RunInSeconds((Action) (() =>
    {
      this.FailGoal(4);
      this.AddGoal(5, true);
    }), 10f);
    this.NoBack.SetActive(true);
    Main.Instance.Player.UserControl.ResetSpot = this.NoBack.transform;
    for (int index = 0; index < this.DisableSirenObjs.Length; ++index)
      this.DisableSirenObjs[index].SetActive(false);
    for (int index = 0; index < this.EnableSirenObjs.Length; ++index)
      this.EnableSirenObjs[index].SetActive(true);
    for (int index = 0; index < this.SirenSounds.Length; ++index)
      this.PlaySoundSequence(this.SirenSounds[index]);
    this.Objs[8].GetComponent<MeshRenderer>().materials[1].EnableKeyword("_EMISSION");
    this.StartCoroutine(this.EnableObjectsCoroutine());
    Main.Instance.Player.TheHealth.canDie = false;
  }

  private void PlaySoundSequence(AudioSource audioSource)
  {
    audioSource.PlayOneShot(this.VoiceLines[1]);
    this.StartCoroutine(this.WaitForSoundToFinish(this.VoiceLines[1].length - 1f, (Action) (() =>
    {
      audioSource.PlayOneShot(this.VoiceLines[2]);
      this.StartCoroutine(this.WaitForSoundToFinish(this.VoiceLines[2].length, (Action) (() =>
      {
        audioSource.clip = this.VoiceLines[3];
        audioSource.loop = true;
        audioSource.Play();
      })));
    })));
  }

  private IEnumerator WaitForSoundToFinish(float soundLength, Action callback)
  {
    yield return (object) new WaitForSeconds(soundLength);
    Action action = callback;
    if (action != null)
      action();
  }

  private IEnumerator EnableObjectsCoroutine()
  {
    yield return (object) new WaitForSeconds(6f);
    GameObject[] gameObjectArray = this.Bullets;
    for (int index = 0; index < gameObjectArray.Length; ++index)
    {
      gameObjectArray[index].SetActive(true);
      yield return (object) new WaitForSeconds(0.1f);
    }
    gameObjectArray = (GameObject[]) null;
  }

  public void TriggerSewers()
  {
    Main.Instance.CityCharacters.Zea.gameObject.SetActive(false);
    Main.Instance.Player.UserControl.FirstPerson = true;
    this.NoBack.SetActive(false);
    Main.Instance.Player.UserControl.ResetSpot = Main.Instance.CityCharacters.Sia.transform;
    for (int index = 0; index < this.SirenSounds.Length; ++index)
      this.SirenSounds[index].volume = 0.03f;
    for (int index = 0; index < this.LocksToLock.Length; ++index)
      this.LocksToLock[index].Locked = true;
    this.Bullets[0].SetActive(false);
    this.CompleteGoal(5);
    this.Objs[11].SetActive(true);
    this.Objs[18].SetActive(true);
    bl_HangZone component1 = this.Objs[19].GetComponent<bl_HangZone>();
    bl_HangZone component2 = this.Objs[20].GetComponent<bl_HangZone>();
    bl_HangZone component3 = this.Objs[22].GetComponent<bl_HangZone>();
    bl_HangZone component4 = this.Objs[23].GetComponent<bl_HangZone>();
    List<Person> personList = new List<Person>();
    personList.AddRange((IEnumerable<Person>) component2.PeopleInZone);
    this._OrgPlazaPpl.AddRange((IEnumerable<Person>) component2.PeopleInZone);
    personList.AddRange((IEnumerable<Person>) component3.PeopleInZone);
    this._OrgStreetPpl.AddRange((IEnumerable<Person>) component3.PeopleInZone);
    personList.AddRange((IEnumerable<Person>) component4.PeopleInZone);
    this._OrgClubPpl.AddRange((IEnumerable<Person>) component4.PeopleInZone);
    this.Objs[17].SetActive(false);
    this.Objs[41].SetActive(false);
    for (int index = 0; index < personList.Count; ++index)
    {
      if (!personList[index].IsPlayer)
      {
        bl_HangZone currentZone = personList[index].CurrentZone;
        component1.EnterZone(personList[index]);
        try
        {
          currentZone.ExitZone(personList[index]);
        }
        catch
        {
        }
        personList[index].transform.position = this.SewerSpawnSpots[UnityEngine.Random.Range(0, this.SewerSpawnSpots.Length)].position;
        personList[index].gameObject.SetActive(true);
        personList[index].CurrentScheduleTask = (Person.ScheduleTask) null;
        personList[index].FreeScheduleTasks.Clear();
        personList[index].WorkScheduleTasks.Clear();
        personList[index].State = Person_State.Free;
        if ((UnityEngine.Object) personList[index].WorkJob != (UnityEngine.Object) null)
          personList[index].WorkJob.enabled = false;
        personList[index].ThisPersonInt.SetDefaultChat();
        personList[index].ThisPersonInt.SetDefaultInteraction();
        if ((UnityEngine.Object) personList[index].HavingSex_Scene != (UnityEngine.Object) null)
          personList[index].HavingSex_Scene.SafeSexEnd();
        if ((UnityEngine.Object) personList[index].InteractingWith != (UnityEngine.Object) null)
          personList[index].InteractingWith.StopInteracting(personList[index]);
        personList[index].ScheduleDecide();
      }
    }
    Person sia = Main.Instance.CityCharacters.Sia;
    Person hadley = Main.Instance.CityCharacters.Hadley;
    if ((UnityEngine.Object) sia.HavingSex_Scene != (UnityEngine.Object) null)
      sia.HavingSex_Scene.SafeSexEnd();
    if ((UnityEngine.Object) sia.InteractingWith != (UnityEngine.Object) null)
      sia.InteractingWith.StopInteracting(sia);
    sia.AddMoveBlocker("zeamista");
    sia.navMesh.enabled = false;
    sia.enabled = false;
    sia.ThisPersonInt.AddBlocker("zeamista");
    sia.ProxSeen.gameObject.SetActive(false);
    if ((UnityEngine.Object) sia.WorkJob != (UnityEngine.Object) null)
      sia.WorkJob.enabled = false;
    if ((UnityEngine.Object) hadley.HavingSex_Scene != (UnityEngine.Object) null)
      hadley.HavingSex_Scene.SafeSexEnd();
    if ((UnityEngine.Object) hadley.InteractingWith != (UnityEngine.Object) null)
      hadley.InteractingWith.StopInteracting(hadley);
    hadley.AddMoveBlocker("zeamista");
    hadley.navMesh.enabled = false;
    hadley.enabled = false;
    hadley.ThisPersonInt.AddBlocker("zeamista");
    hadley.ProxSeen.gameObject.SetActive(false);
    sia.PlaceAt(this.Objs[9].transform);
    sia.gameObject.SetActive(true);
    hadley.PlaceAt(this.Objs[10].transform);
    hadley.gameObject.SetActive(true);
    Person carol = Main.Instance.CityCharacters.Carol;
    if ((UnityEngine.Object) carol.CurrentHat != (UnityEngine.Object) null)
      carol.CurrentHat.gameObject.SetActive(false);
    Main.Instance.CityCharacters.Zea.gameObject.SetActive(false);
  }

  public void SewerChatTrigged()
  {
    Main.Instance.CityCharacters.Zea.gameObject.SetActive(false);
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person _sia = Main.Instance.CityCharacters.Sia;
    Person _hadley = Main.Instance.CityCharacters.Hadley;
    Main.Instance.Player.AddMoveBlocker("zeamistswerwer");
    _sia.LookAtPlayer.NonplayerTarget = _hadley.Head;
    _gameplay.DisplaySubtitle("Hey we haven't had a bombardment in a pretty long time", this.VoiceLines[8], (Action) (() =>
    {
      _hadley.LookAtPlayer.NonplayerTarget = _sia.Head;
      _gameplay.DisplaySubtitle("I just hope that they don't hit my shack again", this.VoiceLines[9], (Action) (() =>
      {
        _gameplay.RemoveAllChatOptions();
        _gameplay.AddChatOption("Sia! What's going on!?", new Action(this.SewerChat2));
        _gameplay.AddChatOption("Hey gals wazzap", new Action(this.SewerChat2));
        _gameplay.SelectChatOption(0);
        Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
      }), _hadley);
    }), _sia);
  }

  public void SewerChat2()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person _sia = Main.Instance.CityCharacters.Sia;
    Person _hadley = Main.Instance.CityCharacters.Hadley;
    _hadley.LookAtPlayer.NonplayerTarget = (Transform) null;
    _sia.LookAtPlayer.NonplayerTarget = (Transform) null;
    _gameplay.DisplaySubtitle("Who knows what's going on", this.VoiceLines[10], (Action) (() => _gameplay.DisplaySubtitle("Well nothing we can do now but wait until it's safe outside again", this.VoiceLines[11], (Action) (() =>
    {
      _hadley.LookAtPlayer.NonplayerTarget = _sia.Head;
      _sia.LookAtPlayer.NonplayerTarget = _hadley.Head;
      _hadley.Anim.Play("Mast2");
      _gameplay.DisplaySubtitle("Let's fuck until then, right here, with everyone's watching~", this.VoiceLines[12], (Action) (() => _gameplay.DisplaySubtitle("Hell yeah!", this.VoiceLines[13], (Action) (() => _gameplay.DisplaySubtitle("But I can't, it's work time", this.VoiceLines[14], (Action) (() =>
      {
        Main.Instance.CityCharacters.Zea.gameObject.SetActive(false);
        _hadley.LookAtPlayer.NonplayerTarget = (Transform) null;
        _sia.LookAtPlayer.NonplayerTarget = (Transform) null;
        _sia.ThisPersonInt.EndTheChat();
        this.AddGoal(6);
        this.WaitTimer = 60f;
        Main.Instance.MainThreads.Add(new Action(this.SewerTimerThread));
        bl_HangZone component = this.Objs[19].GetComponent<bl_HangZone>();
        component.EnterZone(_sia);
        component.EnterZone(_hadley);
        _sia.enabled = true;
        _sia.RemoveMoveBlocker("zeamista");
        _sia.State = Person_State.Free;
        _hadley.enabled = true;
        _hadley.RemoveMoveBlocker("zeamista");
        Main.Instance.Player.RemoveMoveBlocker("zeamistswerwer");
      }), _sia)), _sia)), _hadley);
    }), _sia)), _sia);
  }

  public void PrepareZea()
  {
    Main.Instance.GameplayMenu.StartMission((Mission) this);
    this.AddGoal(0, true);
    Person zea = Main.Instance.CityCharacters.Zea;
    zea.AddMoveBlocker("zeamista");
    zea.navMesh.enabled = false;
    zea.enabled = false;
    zea.PlaceAt(this.Objs[12].transform);
    zea.gameObject.SetActive(true);
    zea.Anim.Play("sit_sad");
    (zea as Girl).PregnancyPercent = 0.0f;
    zea.ThisPersonInt.InteractBlockers.Clear();
    zea.ThisPersonInt.CanInteract = true;
    zea.LookAtPlayer.Disable = true;
    zea.LookAtPlayer.DontBlockSides = true;
    zea.ThisPersonInt.StartTalkMono = (MonoBehaviour) this;
    zea.ThisPersonInt.StartTalkFunc = "ChatZea1";
    zea.ChangeUniform(UnityEngine.Object.FindObjectOfType<Mis_Zea3>().ZeaClothesEly);
  }

  public void ChatZea1()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person _zea = Main.Instance.CityCharacters.Zea;
    Main.Instance.CanSaveFlags_add("ZeaMis");
    Main.Instance.MapAreas[0].LocalMusics[4] = Main.Instance.MapAreas[0].LocalMusics[3];
    this.CompleteGoal(0);
    Main.Instance.Player.AddMoveBlocker("zeamist1");
    _zea.LookAtPlayer.Disable = false;
    _zea.PlaceAt(this.Objs[12].transform);
    _gameplay.DisplaySubtitle("I've done something...", this.VoiceLines[15], (Action) (() =>
    {
      _zea.PlaceAt(this.Objs[12].transform);
      _gameplay.DisplaySubtitle("...really bad", this.VoiceLines[16], (Action) (() => _gameplay.DisplaySubtitle("I-I didn't knew it was gonna be like this", this.VoiceLines[17], (Action) (() => _gameplay.DisplaySubtitle("I uhm... I feel weird", this.VoiceLines[18], (Action) (() => _gameplay.DisplaySubtitle("Can you...lay here with me for a bit", this.VoiceLines[19], (Action) (() =>
      {
        _zea.PersonAudio.PlayOneShot(this.VoiceLines[38]);
        _zea.ThisPersonInt.EndTheChat();
        _zea.ThisPersonInt.SetDefaultChat();
        _zea.ThisPersonInt.AddBlocker("zeamista");
        this.AddGoal(1, true);
        Main.Instance.Player.RemoveMoveBlocker("zeamist1");
        this.Objs[13].SetActive(true);
        _zea.PlaceAt(this.Objs[14].transform);
        _zea.Anim.Play("liedown_04");
        _zea.LookAtPlayer.OnlyEyes = true;
      }), _zea)), _zea)), _zea)), _zea);
    }), _zea);
  }

  public void LayInBed()
  {
    this.CompleteGoal(1);
    this.Objs[13].SetActive(false);
    Main.Instance.Player.AddMoveBlocker("zeamist2");
    Main.Instance.Player._Rigidbody.isKinematic = true;
    Main.Instance.Player.Anim.Play("liedown_01");
    Main.Instance.Player.PlaceAt(this.Objs[15].transform);
    Main.Instance.Player.UserControl.FirstPerson = true;
    Main.Instance.Player.UserControl.Pivot.localPosition = Vector3.zero;
    Transform transform1 = new GameObject("1stpersonspot").transform;
    transform1.SetParent(Main.Instance.Player.UserControl.FirstPersonViewSpot);
    transform1.localPosition = new Vector3(0.0f, -0.0389f, 0.0618f);
    transform1.localEulerAngles = Vector3.zero;
    Main.Instance.Player.UserControl.TheCam.m_Target = transform1;
    Person zea = Main.Instance.CityCharacters.Zea;
    Transform transform2 = new GameObject("_zeaHeadSpot").transform;
    transform2.SetParent(zea.Head);
    transform2.localPosition = new Vector3(0.1056f, 0.071f, -0.0048f);
    transform2.localEulerAngles = new Vector3(292.9009f, 288.286865f, 148.851334f);
    zea.RightArmIK.enabled = true;
    zea.RightArmIK.Target.SetParent(transform2);
    zea.RightArmIK.Target.localPosition = Vector3.zero;
    zea.RightArmIK.Target.localEulerAngles = Vector3.zero;
    zea.RightArmIK.Pole.localPosition = new Vector3(0.245f, -0.013f, -0.771f);
    this.Invoke("ZeaChatInBed", 15f);
    Main.RunInSeconds((Action) (() =>
    {
      if (!(Main.Instance.Player is Girl))
        return;
      (Main.Instance.Player as Girl).TempDisableConstantPhysics = true;
    }), 1f);
  }

  public void ZeaChatInBed()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person _zea = Main.Instance.CityCharacters.Zea;
    _gameplay.DisplaySubtitle("Did you knew that before the war there was people who used to make music bands", this.VoiceLines[20], (Action) (() => _gameplay.DisplaySubtitle("and they'd make pretty damn cool music", this.VoiceLines[21], (Action) (() => _gameplay.DisplaySubtitle("like this one", this.VoiceLines[22], (Action) (() =>
    {
      Transform transform = new GameObject("_zeahandspot").transform;
      transform.SetParent(_zea.Head);
      transform.localPosition = new Vector3(-0.308f, -0.134f, 0.087f);
      transform.localEulerAngles = new Vector3(314.99f, 49.1609955f, 351.393f);
      _zea.LeftArmIK.enabled = true;
      _zea.LeftArmIK.Target.SetParent(transform);
      _zea.LeftArmIK.Target.localPosition = Vector3.zero;
      _zea.LeftArmIK.Target.localEulerAngles = Vector3.zero;
      _zea.LeftArmIK.Pole.localPosition = new Vector3(-0.25f, 0.212f, -0.078f);
      this.Objs[17].SetActive(true);
      this.Objs[17].transform.SetParent(_zea.LeftHandStuff);
      this.Objs[17].transform.localPosition = new Vector3(-0.0814f, -0.0277f, 0.0024f);
      this.Objs[17].transform.localEulerAngles = new Vector3(70.84326f, 37.6999474f, 332.538055f);
      this.Objs[17].transform.localScale = new Vector3(0.8665475f, 0.8665475f, 0.8665475f);
      _zea.ThisPersonInt.EndTheChat();
      _zea.PersonAudio.PlayOneShot(this.VoiceLines[37]);
      this.Invoke("ZeaChatInBed2", 28.5f);
    }), _zea)), _zea)), _zea);
  }

  public void ZeaChatInBed2()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person _zea = Main.Instance.CityCharacters.Zea;
    Transform _lookspot = new GameObject("fghgghfgfhj").transform;
    _lookspot.SetParent(_zea.Head);
    _lookspot.localPosition = new Vector3(-0.0545f, -0.0057f, 0.3733f);
    _zea.LeftArmIK.enabled = false;
    _zea.LookAtPlayer.playerTransform = _lookspot;
    _gameplay.DisplaySubtitle("Sadly the rest of the tape is damaged", this.VoiceLines[23], (Action) (() => _gameplay.DisplaySubtitle("I got more music tapes around", this.VoiceLines[24], (Action) (() =>
    {
      _zea.LookAtPlayer.playerTransform = Main.Instance.Player.UserControl.m_Cam;
      _gameplay.DisplaySubtitle("This one was my favourite tho", this.VoiceLines[25], (Action) (() => _gameplay.DisplaySubtitle("", this.VoiceLines[44], (Action) (() => _gameplay.DisplaySubtitle("Oh right! There's no time to waste", this.VoiceLines[26], (Action) (() =>
      {
        _zea.LookAtPlayer.playerTransform = _lookspot;
        _gameplay.DisplaySubtitle("I've got an headache", this.VoiceLines[27], (Action) (() =>
        {
          _zea.LookAtPlayer.playerTransform = Main.Instance.Player.UserControl.m_Cam;
          _gameplay.DisplaySubtitle("But you must go", this.VoiceLines[28], (Action) (() =>
          {
            _zea.LookAtPlayer.playerTransform = _lookspot;
            _gameplay.DisplaySubtitle("I uhm", this.VoiceLines[29], (Action) (() => _gameplay.DisplaySubtitle("There's a thing you must find", this.VoiceLines[30], (Action) (() => _gameplay.DisplaySubtitle("In Sephie's lab", this.VoiceLines[31], (Action) (() => _gameplay.DisplaySubtitle("Go there and look for uhm...\"Box 200\"", this.VoiceLines[32], (Action) (() =>
            {
              _zea.LookAtPlayer.playerTransform = Main.Instance.Player.UserControl.m_Cam;
              _gameplay.DisplaySubtitle("And take your time looking for it!", this.VoiceLines[33], (Action) (() => _gameplay.DisplaySubtitle("", this.VoiceLines[44], (Action) (() =>
              {
                _zea.LookAtPlayer.playerTransform = _lookspot;
                _gameplay.DisplaySubtitle("I uhm, don't deserve to go", this.VoiceLines[34], (Action) (() => _gameplay.DisplaySubtitle("I'll rest here", this.VoiceLines[35], (Action) (() =>
                {
                  _zea.LookAtPlayer.playerTransform = Main.Instance.Player.UserControl.m_Cam;
                  _zea.ThisPersonInt.EndTheChat();
                  Main.Instance.GameplayMenu.QLeave.SetActive(true);
                  Main.Instance.GameplayMenu.QLeave.transform.Find("a/Text").GetComponent<Text>().text = "Stand up";
                  Main.Instance.MainThreads.Add(new Action(this.QStand_ZeaBed_Thread));
                }), _zea)), _zea);
              }), _zea)), _zea);
            }), _zea)), _zea)), _zea)), _zea);
          }), _zea);
        }), _zea);
      }), _zea)), _zea, e_BlendShapes.o_face)), _zea, expressionAtEnd: e_BlendShapes.o_face);
    }), _zea)), _zea);
  }

  public void QStand_ZeaBed_Thread()
  {
    if (!Main.Instance.CancelKey())
      return;
    Main.Instance.Player.PersonAudio.PlayOneShot(this.VoiceLines[38]);
    Main.Instance.MainThreads.Remove(new Action(this.QStand_ZeaBed_Thread));
    Main.Instance.GameplayMenu.QLeave.SetActive(false);
    Main.Instance.Player.PlaceAt(this.Objs[16].transform);
    Main.Instance.Player.RemoveMoveBlocker("zeamist2");
    Main.Instance.Player._Rigidbody.isKinematic = false;
    Main.Instance.Player.UserControl.TheCam.m_Target = Main.Instance.Player.transform;
    Main.Instance.Player.UserControl.FirstPerson = false;
    if (Main.Instance.Player is Girl)
      (Main.Instance.Player as Girl).TempDisableConstantPhysics = false;
    Person zea = Main.Instance.CityCharacters.Zea;
    zea.RightArmIK.enabled = false;
    zea.Anim.Play("liedown_02");
    zea.transform.position = new Vector3(-49.403f, 3.699f, 35.821f);
    zea.transform.eulerAngles = new Vector3(357.300446f, 340.129364f, 0.0f);
    this.AddGoal(2, true);
    this.Objs[5].SetActive(true);
    Main.Instance.GameplayMenu.DisplaySubtitle("bye", this.VoiceLines[36], new Action(zea.ThisPersonInt.EndTheChat), zea);
  }

  public void SewerTimerThread()
  {
    this.WaitTimer -= Time.deltaTime;
    if ((double) this.WaitTimer >= 0.0)
      return;
    Main.Instance.CityCharacters.Zea.gameObject.SetActive(false);
    Main.Instance.MainThreads.Remove(new Action(this.SewerTimerThread));
    this.CompleteGoal(6);
    this.AddGoal(7, true);
    Main.Instance.Player.UserControl.ResetSpot = Main.Instance.Player.UserControl.OriginalResetSpot;
    if ((UnityEngine.Object) this.Objs[40] != (UnityEngine.Object) null)
    {
      Rigidbody componentInChildren1 = this.Objs[40].GetComponentInChildren<Rigidbody>(true);
      if ((UnityEngine.Object) componentInChildren1 != (UnityEngine.Object) null && componentInChildren1.isKinematic)
      {
        BackPack componentInChildren2 = this.Objs[40].GetComponentInChildren<BackPack>(true);
        if ((UnityEngine.Object) componentInChildren2 != (UnityEngine.Object) null && !componentInChildren2.Equipped)
          this.Objs[40].PlaceAt(this.Objs[39].transform);
      }
    }
    for (int index = 0; index < this.SirenSounds.Length; ++index)
      this.SirenSounds[index].enabled = false;
    for (int index = 0; index < this.LocksToLock.Length; ++index)
      this.LocksToLock[index].Locked = false;
    this.Objs[21].SetActive(false);
    this.Objs[8].GetComponent<MeshRenderer>().materials[1].DisableKeyword("_EMISSION");
    this.EnableSirenObjs[7].SetActive(false);
    for (int index = 0; index < this.PreDamage.Length; ++index)
      this.PreDamage[index].SetActive(false);
    for (int index = 0; index < this.AfterDamage.Length; ++index)
      this.AfterDamage[index].SetActive(true);
    Main.Instance.CityCharacters.Zea.gameObject.SetActive(false);
  }

  public void TriggerZeaGone()
  {
    this.FailGoal(7);
    Main.Instance.CityCharacters.Zea.gameObject.SetActive(false);
    Main.Instance.MusicPlayer.volume = 1f;
    Main.Instance.MusicPlayer.pitch = 1f;
    Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[45]);
    Person _sia = Main.Instance.CityCharacters.Sia;
    _sia.State = Person_State.Work;
    _sia.CurrentScheduleTask = (Person.ScheduleTask) null;
    _sia.WorkScheduleTasks.Clear();
    _sia.FreeScheduleTasks.Clear();
    if ((UnityEngine.Object) _sia.HavingSex_Scene != (UnityEngine.Object) null)
      _sia.HavingSex_Scene.SafeSexEnd();
    if ((UnityEngine.Object) _sia.InteractingWith != (UnityEngine.Object) null)
      _sia.InteractingWith.StopInteracting(_sia);
    _sia.gameObject.SetActive(false);
    _sia.PlaceAt(this.Objs[24].transform);
    _sia.ThisPersonInt.AddBlocker("zeamistaoutside");
    for (int index = 0; index < _sia.WeaponInv.weapons.Count; ++index)
    {
      if ((UnityEngine.Object) _sia.WeaponInv.weapons[index] != (UnityEngine.Object) null)
      {
        _sia.WeaponInv.SetActiveWeapon(index);
        break;
      }
    }
    Main.RunInNextFrame((Action) (() =>
    {
      _sia.PlaceAt(this.Objs[24].transform);
      _sia.gameObject.SetActive(true);
      Main.Instance.MainThreads.Add(new Action(this.CheckForSiaTalk));
      _sia.StartScheduleTask(new Person.ScheduleTask()
      {
        IDName = "_siaDest",
        ActionPlace = this.Objs[25].transform,
        OnArrive = (Action) (() => _sia.PlaceAt(this.Objs[25].transform))
      });
    }), 2);
  }

  public void CheckForSiaTalk()
  {
    Person _sia = Main.Instance.CityCharacters.Sia;
    if ((double) Vector3.Distance(_sia.transform.position, Main.Instance.Player.transform.position) >= 2.0)
      return;
    Main.Instance.CityCharacters.Zea.gameObject.SetActive(false);
    Main.Instance.Player.AddMoveBlocker("siatalk2");
    _sia.AddMoveBlocker("siatalk2");
    Main.Instance.MainThreads.Remove(new Action(this.CheckForSiaTalk));
    Main.Instance.GameplayMenu.DisplaySubtitle("Oh no", this.VoiceLines[39], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("This is...", this.VoiceLines[40], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("...big problem", this.VoiceLines[41], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("", (AudioClip) null, (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("I think this time we should go talk with dad", this.VoiceLines[42], (Action) (() => Main.Instance.GameplayMenu.DisplaySubtitle("top floor in building 4", this.VoiceLines[43], (Action) (() =>
    {
      this.Objs[26].SetActive(false);
      this.Objs[27].SetActive(true);
      Main.Instance.Player.RemoveMoveBlocker("siatalk2");
      _sia.RemoveMoveBlocker("siatalk2");
      _sia.ThisPersonInt.EndTheChat();
      Main.Instance.CityCharacters.Zea.gameObject.SetActive(false);
      Main.RunInSeconds((Action) (() => this.AddGoal(8, true)), 3f);
    }), _sia, e_BlendShapes.Scared)), _sia, e_BlendShapes.Scared)), _sia, e_BlendShapes.Scared)), _sia, e_BlendShapes.Scared)), _sia, e_BlendShapes.Scared)), _sia, e_BlendShapes.Scared);
  }

  public void OpenDadDoor()
  {
    Debug.LogError((object) "OpenDadDoor()");
    this.CompleteGoal(8);
    Main.Instance.MusicPlayer.volume = 0.6f;
    Main.Instance.MusicPlayer.pitch = 1f;
    Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[46]);
    Main.Instance.Player.AddMoveBlocker("dad");
    Main.Instance.Player.PlaceAt(this.Objs[28].transform);
    this.Objs[29].SetActive(true);
    this.Objs[27].SetActive(false);
    this.Objs[31].SetActive(true);
    this.Invoke("MeetDad2", 4f);
    Main.Instance.CityCharacters.Zea.gameObject.SetActive(false);
  }

  public void MeetDad2()
  {
    this.Objs[29].SetActive(false);
    this.Objs[30].SetActive(true);
    this.Invoke("MeetDad3", 9f);
  }

  public void MeetDad3()
  {
    this.Objs[30].SetActive(false);
    this.Objs[32].SetActive(true);
    this.Invoke("StartDadTalk", 5f);
  }

  public void StartDadTalk()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person _dad = Main.Instance.CityCharacters.Dad;
    _gameplay.DisplaySubtitle("Welcome back", this.VoiceLines[47], (Action) (() => _gameplay.DisplaySubtitle("We haven't had a chance to talk since you've been back", this.VoiceLines[48], (Action) (() => _gameplay.DisplaySubtitle("So, the ESB blew up the army building, again", this.VoiceLines[61], (Action) (() => _gameplay.DisplaySubtitle("That's always their target", this.VoiceLines[62], (Action) (() => _gameplay.DisplaySubtitle("That's what they do in preparation to invade us", this.VoiceLines[73], (Action) (() => _gameplay.DisplaySubtitle("But we are gonna suprise them by invading them instead", this.VoiceLines[74], (Action) (() => _gameplay.DisplaySubtitle("The ESB are not an enemy btw", this.VoiceLines[63], (Action) (() => _gameplay.DisplaySubtitle("We have worse enemies to focus on", this.VoiceLines[64], (Action) (() => _gameplay.DisplaySubtitle("But we should deal with the ESB by now anyway", this.VoiceLines[65], (Action) (() => _gameplay.DisplaySubtitle("they haven't been necessary for a while", this.VoiceLines[66], (Action) (() => _gameplay.DisplaySubtitle("But don't forget what they did, and then multiply it by 4 billion", this.VoiceLines[67], (Action) (() => _gameplay.DisplaySubtitle("for the next time, when we fight a real enemy", this.VoiceLines[68], (Action) (() => _gameplay.DisplaySubtitle("I will get War to setup a small team to counterattack the ESB", this.VoiceLines[69], (Action) (() => _gameplay.DisplaySubtitle("More than that won't be necessary", this.VoiceLines[70], (Action) (() => _gameplay.DisplaySubtitle("Go and sleep for some hours, and then go see Sephie", this.VoiceLines[71], (Action) (() => _gameplay.DisplaySubtitle("She will show you how a small team is all you need", this.VoiceLines[72], (Action) (() =>
    {
      Main.Instance.GameplayMenu.EndChat();
      _dad.gameObject.SetActive(false);
      this.Objs[32].SetActive(false);
      Main.Instance.Player.RemoveMoveBlocker("dad");
      Main.Instance.Player.PlaceAt(this.Objs[37].transform);
      this.PrepareWarAfterDad();
      Main.Instance.CityCharacters.Zea.gameObject.SetActive(false);
    }), _dad)), _dad)), _dad)), _dad)), _dad)), _dad)), _dad)), _dad)), _dad)), _dad)), _dad)), _dad)), _dad)), _dad)), _dad)), _dad);
  }

  public void PrepareWarAfterDad()
  {
    this.AddGoal(9, true);
    this.Objs[34].SetActive(true);
    Person _war = Main.Instance.CityCharacters.War;
    _war.State = Person_State.Work;
    _war.CurrentScheduleTask = (Person.ScheduleTask) null;
    _war.AddMoveBlocker("talk2");
    _war.Anim.Play(_war.A_Standing);
    _war.navMesh.enabled = false;
    _war.PlaceAt(this.Objs[33].transform);
    _war.gameObject.SetActive(true);
    _war.ThisPersonInt.AddBlocker("dad");
    Main.RunInNextFrame((Action) (() =>
    {
      _war.State = Person_State.Work;
      _war.CurrentScheduleTask = (Person.ScheduleTask) null;
      _war.Anim.Play(_war.A_Standing);
      _war.navMesh.enabled = false;
      _war.PlaceAt(this.Objs[33].transform);
      _war.gameObject.SetActive(true);
    }), 3);
  }

  public void WarChat()
  {
    this.Objs[35].SetActive(true);
    this.CompleteGoal(9);
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person _war = Main.Instance.CityCharacters.War;
    _gameplay.DisplaySubtitle("Do you remember those defences we built at the end of the tunnel?", this.VoiceLines[50], (Action) (() => _gameplay.DisplaySubtitle("They are what makes attacks like this impossible", this.VoiceLines[51], (Action) (() => _gameplay.DisplaySubtitle("Unless the enemy finds most of them are disables them first", this.VoiceLines[52], (Action) (() => _gameplay.DisplaySubtitle("I can understand if they find one by accident", this.VoiceLines[53], (Action) (() => _gameplay.DisplaySubtitle("And so, that's why we had dozens of them around the city", this.VoiceLines[54], (Action) (() => _gameplay.DisplaySubtitle("So, How did the enemy managed to find all of them at the same time?", this.VoiceLines[55], (Action) (() => _gameplay.DisplaySubtitle("Is there something you might know, that I don't?", this.VoiceLines[56], (Action) (() =>
    {
      _gameplay.RemoveAllChatOptions();
      _gameplay.AddChatOption("I don't know anything ma'am", new Action(this.WarChat2));
      _gameplay.AddChatOption("Zea might have had something to do with it...", new Action(this.WarChat2));
      _gameplay.SelectChatOption(0);
      Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.OpenedChatOptionsThread));
    }), _war)), _war)), _war)), _war)), _war)), _war)), _war);
  }

  public void WarChat2()
  {
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person _war = Main.Instance.CityCharacters.War;
    _gameplay.DisplaySubtitle("...", this.VoiceLines[44], (Action) (() => _gameplay.DisplaySubtitle("I know that she didn't do it on purpose", this.VoiceLines[57], (Action) (() => _gameplay.DisplaySubtitle("Be careful of falling for the enemy's tricks yourself next time", this.VoiceLines[58], (Action) (() => _gameplay.DisplaySubtitle("Well I was looking in the rumble and I found this", this.VoiceLines[59], (Action) (() =>
    {
      Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[38]);
      GameObject gameObject = Main.Spawn(this.Objs[36], saveable: true);
      gameObject.GetComponentInChildren<Rigidbody>().isKinematic = true;
      gameObject.transform.SetParent(_war.LeftHandStuff);
      gameObject.transform.localPosition = new Vector3(0.068f, -0.078f, 0.0f);
      gameObject.transform.localEulerAngles = new Vector3(0.0f, 349.874359f, 180f);
      gameObject.transform.SetParent((Transform) null);
      _war.enabled = false;
      _war.Anim.Play("handpose");
      _gameplay.DisplaySubtitle("it's all that's left", this.VoiceLines[60], (Action) (() =>
      {
        this.Objs[35].SetActive(false);
        Main.Instance.MusicPlayer.PlayOneShot(this.VoiceLines[38]);
        _war.ThisPersonInt.EndTheChat();
        this.AddGoal(10, true);
        Main.Instance.MainThreads.Add(new Action(this.CheckForSleepThread));
        Main.Instance.CityCharacters.Zea.gameObject.SetActive(false);
      }), _war);
    }), _war)), _war)), _war)), _war);
  }

  public void CheckForSleepThread()
  {
    if (!Main.Instance.Player._IsSleeping)
      return;
    this.CompleteGoal(10);
    this.CompleteMission();
    Main.Instance.CanSaveFlags_remove("ZeaMis");
    Main.Instance.SaveGame(true);
    Main.Instance.MainThreads.Remove(new Action(this.CheckForSleepThread));
    for (int index = 0; index < Main.Instance.SpawnedPeople.Count; ++index)
    {
      if ((UnityEngine.Object) Main.Instance.SpawnedPeople[index] != (UnityEngine.Object) null && !Main.Instance.SpawnedPeople[index].IsPlayer)
        Main.Instance.SpawnedPeople[index].gameObject.SetActive(true);
    }
    for (int index = 0; index < this.DoorsToCloseAndLock.Length; ++index)
    {
      this.DoorsToCloseAndLock[index].Locked = false;
      this.DoorsToCloseAndLock[index].OpenDoor();
    }
    this.Objs[4].GetComponent<int_Lockable>().Locked = false;
    Person zea = Main.Instance.CityCharacters.Zea;
    zea.gameObject.SetActive(false);
    Person sia = Main.Instance.CityCharacters.Sia;
    sia.CurrentZone = (bl_HangZone) null;
    sia.ThisPersonInt.RemoveBlocker("zeamista");
    Person carol = Main.Instance.CityCharacters.Carol;
    if ((UnityEngine.Object) carol.CurrentHat != (UnityEngine.Object) null)
      carol.CurrentHat.gameObject.SetActive(true);
    Main.Instance.CityCharacters.Hadley.ThisPersonInt.RemoveBlocker("zeamista");
    bl_HangZone _club1 = this.Objs[23].GetComponent<bl_HangZone>();
    bl_HangZone _plaza = this.Objs[20].GetComponent<bl_HangZone>();
    bl_HangZone _mainStreet = this.Objs[22].GetComponent<bl_HangZone>();
    for (int index = 0; index < this._OrgClubPpl.Count; ++index)
    {
      if ((UnityEngine.Object) this._OrgClubPpl[index] != (UnityEngine.Object) null && !this._OrgClubPpl[index].IsPlayer)
        this._OrgClubPpl[index].gameObject.SetActive(false);
    }
    for (int index = 0; index < this._OrgPlazaPpl.Count; ++index)
    {
      if ((UnityEngine.Object) this._OrgPlazaPpl[index] != (UnityEngine.Object) null && !this._OrgPlazaPpl[index].IsPlayer)
        this._OrgPlazaPpl[index].gameObject.SetActive(false);
    }
    for (int index = 0; index < this._OrgStreetPpl.Count; ++index)
    {
      if ((UnityEngine.Object) this._OrgStreetPpl[index] != (UnityEngine.Object) null && !this._OrgStreetPpl[index].IsPlayer)
        this._OrgStreetPpl[index].gameObject.SetActive(false);
    }
    Main.RunInSeconds((Action) (() =>
    {
      List<Person> orgClubPpl = this._OrgClubPpl;
      for (int index = 0; index < orgClubPpl.Count; ++index)
      {
        if (!orgClubPpl[index].IsPlayer)
        {
          orgClubPpl[index].gameObject.SetActive(false);
          bl_HangZone currentZone = orgClubPpl[index].CurrentZone;
          _club1.EnterZone(orgClubPpl[index]);
          try
          {
            currentZone.ExitZone(orgClubPpl[index]);
          }
          catch
          {
          }
          orgClubPpl[index].transform.position = _club1.Location.position;
          orgClubPpl[index].gameObject.SetActive(true);
          orgClubPpl[index].CurrentScheduleTask = (Person.ScheduleTask) null;
          orgClubPpl[index].FreeScheduleTasks.Clear();
          orgClubPpl[index].WorkScheduleTasks.Clear();
          orgClubPpl[index].State = Person_State.Free;
          if ((UnityEngine.Object) orgClubPpl[index].HavingSex_Scene != (UnityEngine.Object) null)
            orgClubPpl[index].HavingSex_Scene.SafeSexEnd();
          if ((UnityEngine.Object) orgClubPpl[index].InteractingWith != (UnityEngine.Object) null)
            orgClubPpl[index].InteractingWith.StopInteracting(orgClubPpl[index]);
          if ((UnityEngine.Object) orgClubPpl[index].WorkJob != (UnityEngine.Object) null)
          {
            orgClubPpl[index].WorkJob.enabled = true;
            orgClubPpl[index].WorkJob._StartWorkFor(orgClubPpl[index]);
          }
          orgClubPpl[index].ScheduleDecide();
        }
      }
      List<Person> orgPlazaPpl = this._OrgPlazaPpl;
      for (int index = 0; index < orgPlazaPpl.Count; ++index)
      {
        if (!orgPlazaPpl[index].IsPlayer)
        {
          orgPlazaPpl[index].gameObject.SetActive(false);
          bl_HangZone currentZone = orgPlazaPpl[index].CurrentZone;
          _plaza.EnterZone(orgPlazaPpl[index]);
          try
          {
            currentZone.ExitZone(orgPlazaPpl[index]);
          }
          catch
          {
          }
          orgPlazaPpl[index].transform.position = _plaza.Location.position;
          orgPlazaPpl[index].gameObject.SetActive(true);
          orgPlazaPpl[index].CurrentScheduleTask = (Person.ScheduleTask) null;
          orgPlazaPpl[index].FreeScheduleTasks.Clear();
          orgPlazaPpl[index].WorkScheduleTasks.Clear();
          orgPlazaPpl[index].State = Person_State.Free;
          if ((UnityEngine.Object) orgPlazaPpl[index].HavingSex_Scene != (UnityEngine.Object) null)
            orgPlazaPpl[index].HavingSex_Scene.SafeSexEnd();
          if ((UnityEngine.Object) orgPlazaPpl[index].InteractingWith != (UnityEngine.Object) null)
            orgPlazaPpl[index].InteractingWith.StopInteracting(orgPlazaPpl[index]);
          if ((UnityEngine.Object) orgPlazaPpl[index].WorkJob != (UnityEngine.Object) null)
          {
            orgPlazaPpl[index].WorkJob.enabled = true;
            orgPlazaPpl[index].WorkJob._StartWorkFor(orgPlazaPpl[index]);
          }
          orgPlazaPpl[index].ScheduleDecide();
        }
      }
      List<Person> orgStreetPpl = this._OrgStreetPpl;
      for (int index = 0; index < orgStreetPpl.Count; ++index)
      {
        if (!orgStreetPpl[index].IsPlayer)
        {
          orgStreetPpl[index].gameObject.SetActive(false);
          bl_HangZone currentZone = orgStreetPpl[index].CurrentZone;
          _mainStreet.EnterZone(orgStreetPpl[index]);
          try
          {
            currentZone.ExitZone(orgStreetPpl[index]);
          }
          catch
          {
          }
          orgStreetPpl[index].transform.position = _mainStreet.Location.position;
          orgStreetPpl[index].gameObject.SetActive(true);
          orgStreetPpl[index].CurrentScheduleTask = (Person.ScheduleTask) null;
          orgStreetPpl[index].FreeScheduleTasks.Clear();
          orgStreetPpl[index].WorkScheduleTasks.Clear();
          orgStreetPpl[index].State = Person_State.Free;
          if ((UnityEngine.Object) orgStreetPpl[index].HavingSex_Scene != (UnityEngine.Object) null)
            orgStreetPpl[index].HavingSex_Scene.SafeSexEnd();
          if ((UnityEngine.Object) orgStreetPpl[index].InteractingWith != (UnityEngine.Object) null)
            orgStreetPpl[index].InteractingWith.StopInteracting(orgStreetPpl[index]);
          if ((UnityEngine.Object) orgStreetPpl[index].WorkJob != (UnityEngine.Object) null)
          {
            orgStreetPpl[index].WorkJob.enabled = true;
            orgStreetPpl[index].WorkJob._StartWorkFor(orgStreetPpl[index]);
          }
          orgStreetPpl[index].ScheduleDecide();
        }
      }
    }), 1f);
    zea.gameObject.SetActive(false);
    Main.RunInSeconds((Action) (() =>
    {
      Main.Instance.AllMissions[15].InitMission();
      Main.Instance.CityCharacters.Zea.gameObject.SetActive(false);
    }), 10f);
  }
}
