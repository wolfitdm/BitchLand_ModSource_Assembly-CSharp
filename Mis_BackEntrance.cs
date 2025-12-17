// Decompiled with JetBrains decompiler
// Type: Mis_BackEntrance
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#nullable disable
public class Mis_BackEntrance : Mission
{
  [Space]
  public int SceneToLoad;
  public GameObject[] Objs;
  public AudioClip[] VoiceLines;
  public GameObject[] ZeaClothes;
  public GameObject[] SiaClothes;
  private List<GameObject> _ppl = new List<GameObject>();
  public int_ConstructionPlan _ThePlan;

  public bool MissionCanStart() => Main.Instance.AllMissions[12].CompletedMission;

  public override void InitMission()
  {
    if (!this.MissionCanStart() || this._Inited)
      return;
    base.InitMission();
    this.CurrentGoal = this.Goals[0];
    if (!this.CurrentGoal.Completed)
      this.PrepareStart();
    else
      this.CompletedMission = true;
    if (!this.CompletedMission)
    {
      Main.Instance.GameplayMenu.DisplayGoal(this.CurrentGoal, true);
      Main.Instance.GameplayMenu.MapTrackers[0] = Main.Instance.CityCharacters.Sia.transform;
    }
    else
    {
      if (Main.Instance.AllMissions[14].CompletedMission)
        return;
      Main.Instance.AllMissions[14].InitMission();
    }
  }

  public void PrepareStart()
  {
    Main.Instance.GameplayMenu.StartMission((Mission) this);
    Person sia = Main.Instance.CityCharacters.Sia;
    Person zea = Main.Instance.CityCharacters.Zea;
    if ((UnityEngine.Object) sia.HavingSex_Scene != (UnityEngine.Object) null)
      sia.HavingSex_Scene.SafeSexEnd();
    if ((UnityEngine.Object) sia.InteractingWith != (UnityEngine.Object) null)
      sia.InteractingWith.StopInteracting(sia);
    sia.ThisPersonInt.StartTalkFunc = "InteractWithSia";
    sia.ThisPersonInt.StartTalkMono = (MonoBehaviour) this;
    sia.AddMoveBlocker("siaback");
    sia.navMesh.enabled = false;
    sia.enabled = false;
    sia.PlaceAt(this.Objs[0].transform);
    sia.gameObject.SetActive(true);
    sia.ThisPersonInt.InteractBlockers.Clear();
    sia.ThisPersonInt.CanInteract = true;
    if ((UnityEngine.Object) sia.WorkJob != (UnityEngine.Object) null)
      sia.WorkJob.enabled = false;
    sia.CurrentScheduleTask = (Person.ScheduleTask) null;
    sia.FreeScheduleTasks.Clear();
    sia.WorkScheduleTasks.Clear();
    sia.State = Person_State.Work;
    sia.Anim.Play("crossarms_00");
    sia.ChangeUniform(this.SiaClothes);
    if ((UnityEngine.Object) zea.HavingSex_Scene != (UnityEngine.Object) null)
      zea.HavingSex_Scene.SafeSexEnd();
    if ((UnityEngine.Object) zea.InteractingWith != (UnityEngine.Object) null)
      zea.InteractingWith.StopInteracting(sia);
    zea.AddMoveBlocker("siaback");
    zea.navMesh.enabled = false;
    zea.enabled = false;
    zea.PlaceAt(this.Objs[1].transform);
    zea.gameObject.SetActive(true);
    if ((UnityEngine.Object) zea.WorkJob != (UnityEngine.Object) null)
      zea.WorkJob.enabled = false;
    zea.CurrentScheduleTask = (Person.ScheduleTask) null;
    zea.FreeScheduleTasks.Clear();
    zea.WorkScheduleTasks.Clear();
    zea.State = Person_State.Work;
    zea.ThisPersonInt.AddBlocker("siaback");
    zea.Anim.Play(zea.A_Standing);
    zea.ChangeUniform(this.ZeaClothes);
    this.AddGoal(0, true);
  }

  public void InteractWithSia()
  {
    this.CompleteGoal(0);
    Main.Instance.CanSaveFlags_add("siaback");
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person _sia = Main.Instance.CityCharacters.Sia;
    Person _zea = Main.Instance.CityCharacters.Zea;
    Main.Instance.Player.AddMoveBlocker("siaback");
    _gameplay.CanBuild = false;
    _gameplay.DisplaySubtitle("Yo", this.VoiceLines[0], (Action) (() => _gameplay.DisplaySubtitle("Let's go to the end of the train tunnel and setup some defences there", this.VoiceLines[1], (Action) (() =>
    {
      _sia.ThisPersonInt.EndTheChat();
      _sia.ThisPersonInt.AddBlocker("siaback");
      Main.Instance.NewGameMenu.SmallLoading.SetActive(true);
      Main.Instance.GameplayMenu.TheScreenFader.FadeOut(3f, (Action) (() => Main.RunInNextFrame((Action) (() =>
      {
        Main.Instance.DayCycle.enabled = false;
        Main.Instance.DayCycle.ResetMidday();
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
            _sia.PlaceAt(this.Objs[2].transform);
            _zea.PlaceAt(this.Objs[3].transform);
            Main.Instance.Player.PlaceAt(this.Objs[4].transform);
            Main.Instance.Player.UserControl.ResetSpot = this.Objs[4].transform;
            _sia.gameObject.SetActive(true);
            _zea.gameObject.SetActive(true);
            Main.Instance.Player.gameObject.SetActive(true);
            _sia.enabled = true;
            _zea.enabled = true;
            Main.Instance.Player.RemoveMoveBlocker("siaback");
            _sia.RemoveMoveBlocker("siaback");
            _zea.RemoveMoveBlocker("siaback");
            if ((UnityEngine.Object) _sia.WeaponInv.CurrentWeapon != (UnityEngine.Object) null)
              _sia.WeaponInv.CurrentWeapon.Holdster();
            if ((UnityEngine.Object) _zea.WeaponInv.CurrentWeapon != (UnityEngine.Object) null)
              _zea.WeaponInv.CurrentWeapon.Holdster();
            _sia.StartScheduleTask(new Person.ScheduleTask()
            {
              IDName = "siaDest",
              ActionPlace = this.Objs[5].transform,
              OnArrive = (Action) (() =>
              {
                _sia.PlaceAt(this.Objs[5].transform);
                Main.Instance.MainThreads.Add(new Action(this.WaitPLayerSia));
                this.AddGoal(1, true);
              })
            });
            _zea.StartScheduleTask(new Person.ScheduleTask()
            {
              IDName = "zeaDest",
              ActionPlace = this.Objs[6].transform,
              OnArrive = (Action) (() => _zea.PlaceAt(this.Objs[6].transform))
            });
            Main.RunInSeconds((Action) (() => _gameplay.DisplaySubtitle("This side of the city is pretty green don'tcha think?", this.VoiceLines[21], (Action) (() => _gameplay.DisplaySubtitle("Oh I love it", this.VoiceLines[22], (Action) (() =>
            {
              _zea.ThisPersonInt.EndTheChat();
              Main.RunInSeconds((Action) (() => _gameplay.DisplaySubtitle("Have you seen the new growth pods in the clinic?", this.VoiceLines[25], (Action) (() => _gameplay.DisplaySubtitle("What's that?", this.VoiceLines[26], (Action) (() => _gameplay.DisplaySubtitle("So Sephie made these new pods where you put a newborn in", this.VoiceLines[27], (Action) (() => _gameplay.DisplaySubtitle("and they'll instantly turn adult", this.VoiceLines[28], (Action) (() => _gameplay.DisplaySubtitle("Huh? How does that work?", this.VoiceLines[29], (Action) (() => _gameplay.DisplaySubtitle("I don't know, it's not like this reality is fiction anyway, nothing really matters here", this.VoiceLines[30], (Action) (() => _gameplay.DisplaySubtitle("What are you even talking about, are you okay?", this.VoiceLines[31 /*0x1F*/], (Action) (() => _gameplay.DisplaySubtitle("Oh wait, you're just high again", this.VoiceLines[32 /*0x20*/], (Action) (() => _zea.ThisPersonInt.EndTheChat()), _zea)), _zea)), _sia)), _zea)), _sia)), _sia)), _zea)), _sia)), 5f);
            }), _zea)), _sia)), 3f);
          }));
          Main.Instance.GenerateNav();
        }), 4);
      }), 4)));
    }), _sia)), _sia);
  }

  public void WaitPLayerSia()
  {
    Person _sia = Main.Instance.CityCharacters.Sia;
    if ((double) Vector3.Distance(_sia.transform.position, Main.Instance.Player.transform.position) >= 3.0)
      return;
    Main.Instance.MainThreads.Remove(new Action(this.WaitPLayerSia));
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    this.CompleteGoal(1);
    _gameplay.DisplaySubtitle("Alright, open your journal", this.VoiceLines[2], (Action) (() => _gameplay.DisplaySubtitle("go into Building", this.VoiceLines[3], (Action) (() => _gameplay.DisplaySubtitle("and select \"City Air Defences\"", this.VoiceLines[4], (Action) (() =>
    {
      _sia.ThisPersonInt.EndTheChat();
      Main.Instance.GameplayMenu.LatestPlacedPlan = (GameObject) null;
      Main.Instance.MainThreads.Add(new Action(this.PlanCheck));
      _gameplay.CanBuild = true;
      this.AddGoal(2, true);
    }), _sia)), _sia)), _sia);
  }

  public void PlanCheck()
  {
    if (!((UnityEngine.Object) Main.Instance.GameplayMenu._BuildindPlan != (UnityEngine.Object) null))
      return;
    Main.Instance.MainThreads.Remove(new Action(this.PlanCheck));
    UI_Gameplay gameplayMenu = Main.Instance.GameplayMenu;
    Person _sia = Main.Instance.CityCharacters.Sia;
    gameplayMenu.CanBuild = false;
    this.CompleteGoal(2);
    this.AddGoal(3, true);
    gameplayMenu.DisplaySubtitle("Now place it where you want it to be built", this.VoiceLines[5], (Action) (() =>
    {
      _sia.ThisPersonInt.EndTheChat();
      Main.Instance.MainThreads.Add(new Action(this.PlanPlacedCheck));
    }), _sia);
  }

  public void PlanPlacedCheck()
  {
    if (!((UnityEngine.Object) Main.Instance.GameplayMenu.LatestPlacedPlan != (UnityEngine.Object) null) || !(Main.Instance.GameplayMenu.LatestPlacedPlan.name == "PLAN_Struct_RadioTower"))
      return;
    Main.Instance.MainThreads.Remove(new Action(this.PlanPlacedCheck));
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person _sia = Main.Instance.CityCharacters.Sia;
    this.CompleteGoal(3);
    _gameplay.DisplaySubtitle("Next you'll need to put the resources it needs in it", this.VoiceLines[6], (Action) (() =>
    {
      this.AddGoal(4, true);
      this.Objs[7].SetActive(true);
      _gameplay.DisplaySubtitle("Lucky for you, we have them in these boxes right here", this.VoiceLines[7], (Action) (() => _gameplay.DisplaySubtitle("just transfer them to it", this.VoiceLines[8], (Action) (() =>
      {
        if ((UnityEngine.Object) Main.Instance.Player.CurrentBackpack == (UnityEngine.Object) null)
          _gameplay.DisplaySubtitle("Since you don't have a backpack right now,", this.VoiceLines[23], (Action) (() => _gameplay.DisplaySubtitle("you'll need to pick up one item at a time to your hand", this.VoiceLines[24], (Action) (() => _sia.ThisPersonInt.EndTheChat()), _sia)), _sia);
        else
          _sia.ThisPersonInt.EndTheChat();
        this._ThePlan = Main.Instance.GameplayMenu.LatestPlacedPlan.GetComponentInChildren<int_ConstructionPlan>();
        Main.Instance.MainThreads.Add(new Action(this.ResourceCheck));
      }), _sia)), _sia);
    }), _sia);
  }

  public void ResourceCheck()
  {
    if ((UnityEngine.Object) this._ThePlan == (UnityEngine.Object) null)
    {
      Main.Instance.MainThreads.Remove(new Action(this.ResourceCheck));
      Main.Instance.GameplayMenu.LatestPlacedPlan = (GameObject) null;
      Main.Instance.MainThreads.Add(new Action(this.PlanCheck));
      Main.Instance.GameplayMenu.CanBuild = true;
      this.AddGoal(2, true);
    }
    else
    {
      if (!this._ThePlan.AllResourcesIn)
        return;
      Main.Instance.MainThreads.Remove(new Action(this.ResourceCheck));
      UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
      Person _sia = Main.Instance.CityCharacters.Sia;
      Person _zea = Main.Instance.CityCharacters.Zea;
      this.Objs[7].SetActive(false);
      this.CompleteGoal(4);
      this.AddGoal(5, true);
      _gameplay.DisplaySubtitle("Great", this.VoiceLines[19], (Action) (() => _gameplay.DisplaySubtitle("Now we build", this.VoiceLines[20], (Action) (() =>
      {
        _sia.StartScheduleTask(new Person.ScheduleTask()
        {
          IDName = "siabuild",
          ActionPlace = this._ThePlan.NavMeshInteractSpot,
          OnArrive = (Action) (() =>
          {
            this._ThePlan.Interact(_sia);
            _gameplay.DisplaySubtitle("You can join to build it faster", this.VoiceLines[9], (Action) (() =>
            {
              _sia.ThisPersonInt.EndTheChat();
              Main.Instance.MainThreads.Add(new Action(this.BuildCheck));
              Main.RunInSeconds((Action) (() => _gameplay.DisplaySubtitle("Normally we have the worker class to build things", this.VoiceLines[10], (Action) (() => _gameplay.DisplaySubtitle("But this is army business, so we build these instead", this.VoiceLines[11], (Action) (() => _sia.ThisPersonInt.EndTheChat()), _sia)), _sia)), 3f);
            }), _sia);
          })
        });
        _zea.StartScheduleTask(new Person.ScheduleTask()
        {
          IDName = "zeabuilft",
          ActionPlace = this._ThePlan.NavMeshInteractSpot,
          OnArrive = (Action) (() => this._ThePlan.Interact(_zea))
        });
      }), _sia)), _sia);
    }
  }

  public void BuildCheck()
  {
    if (!((UnityEngine.Object) this._ThePlan == (UnityEngine.Object) null))
      return;
    Main.Instance.MainThreads.Remove(new Action(this.BuildCheck));
    UI_Gameplay _gameplay = Main.Instance.GameplayMenu;
    Person _sia = Main.Instance.CityCharacters.Sia;
    Person _zea = Main.Instance.CityCharacters.Zea;
    _sia.AddMoveBlocker("siaback");
    _zea.AddMoveBlocker("siaback");
    this.CompleteGoal(5);
    _gameplay.CanBuild = true;
    _gameplay.DisplaySubtitle("This is disguised as a shitty radio tower", this.VoiceLines[12], (Action) (() => _gameplay.DisplaySubtitle("but this is actually a medium range scanner", this.VoiceLines[13], (Action) (() => _gameplay.DisplaySubtitle("and it also pulsates \"anti air waves\"", this.VoiceLines[14], (Action) (() => _gameplay.DisplaySubtitle("whatever that is", this.VoiceLines[15], (Action) (() => _gameplay.DisplaySubtitle("it's another of Sephie's inventions", this.VoiceLines[16 /*0x10*/], (Action) (() => _gameplay.DisplaySubtitle("I won't even try to understand how any of it works, as long as it works", this.VoiceLines[17], (Action) (() => _gameplay.DisplaySubtitle("Anyway, Let's head back now", this.VoiceLines[18], (Action) (() =>
    {
      _sia.ThisPersonInt.EndTheChat();
      Main.Instance.GameplayMenu.TheScreenFader.FadeOut(3f, (Action) (() =>
      {
        Main.RunInNextFrame((Action) (() => Main.Instance.GameplayMenu.TheScreenFader.FadeIn(1f)));
        this.CompleteMission();
        Main.Instance.CanSaveFlags_remove("siaback");
        Main.Instance.SaveGame(true);
        _sia.gameObject.SetActive(false);
        _zea.gameObject.SetActive(false);
        _sia.PlaceAt(this.Objs[0].transform);
        _zea.PlaceAt(this.Objs[0].transform);
        Main.Instance.Player.PlaceAt(this.Objs[8].transform);
        Main.Instance.Player.SleepOnFloor();
        Main.Instance.GameplayMenu.ShowNotification("The next day...");
        Main.Instance.Player.UserControl.ResetSpot = Main.Instance.Player.UserControl.OriginalResetSpot;
        _sia.RemoveMoveBlocker("siaback");
        _zea.RemoveMoveBlocker("siaback");
        Main.RunInNextFrame((Action) (() =>
        {
          _sia.gameObject.SetActive(true);
          _sia.CurrentScheduleTask = (Person.ScheduleTask) null;
          _sia.WorkJob._StartWorkFor(_sia);
          for (int index = 0; index < this._ppl.Count; ++index)
            this._ppl[index].gameObject.SetActive(true);
        }), 4);
        Main.RunInSeconds((Action) (() => Main.Instance.AllMissions[14].InitMission()), 10f);
      }));
    }), _sia)), _sia)), _sia)), _sia)), _sia)), _sia)), _sia);
  }
}
