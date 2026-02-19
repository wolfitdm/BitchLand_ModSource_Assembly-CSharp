// Decompiled with JetBrains decompiler
// Type: UI_NewGame
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UI_NewGame : UI_Menu
{
  public Person Prisioner;
  public Animation LightANim;
  public GameObject NewGameThings;
  public GameObject[] DestroyWhenStartLoading;
  public Person[] PeopleInMenu;
  public Transform[] StartingPositions;
  public Image[] EasyImages;
  public Text[] EasyTexts;
  public Image[] MediumImages;
  public Text[] MediumTexts;
  public Image[] HardImages;
  public Text[] HardTexts;
  public GameObject[] HardClothing;
  public GameObject[] MedClothing;
  public GameObject[] EasyClothing;
  public GameObject[] HardMaleClothing;
  public GameObject[] MedMaleClothing;
  public GameObject[] EasyMaleClothing;
  public BaseType[] PersonTypes;
  public GameObject SmallLoading;
  public GameObject ExtraLoading;
  public GameObject ExtraLoadingFirstTime;
  public Slider ExtraLoadingSliderEpic;
  public Slider ExtraLoadingSlider;
  public Text ExtraLoadingText;
  public Text ExtraLoadingTextTitle;
  public GameObject[] EnableWhenNewGame;
  public GameObject[] EnableAfterNewGame;
  public GameObject HardGameplayStuff;
  public GameObject MedGameplayStuff;
  public GameObject Med_PeopleToSpawn;
  public GameObject Hard_PeopleToSpawn;
  public GameObject Med_PeopleToSpawn_Specials;
  public GameObject Hard_PeopleToSpawn_Specials;
  public Girl Player;
  public Girl Sarah;
  public int DificultySelected;
  public List<string> DefaultIDs = new List<string>();
  public int _LoadingCounter;
  public Vector3 LightsAngle;
  public bool SpawnedPeople;
  public GameObject HardWarning;

  public UI_NewGame() => this.MenuName = "NewGame";

  public void Start()
  {
    this.LightANim[this.LightANim.clip.name].speed = 0.25f;
    this.Prisioner.StartRagdoll();
  }

  public override void Open()
  {
    base.Open();
    Main.Instance.Lights.SetActive(true);
    Main.Instance.Menus[0].PeopleDisableWhileOpen[1].gameObject.SetActive(true);
    for (int index = 0; index < this.PeopleEnableWhileOpen.Count; ++index)
    {
      this.PeopleEnableWhileOpen[index].enabled = false;
      this.PeopleEnableWhileOpen[index].SetHighLod();
    }
    this.Player.AttatchRightBoobToRightHand(this.Sarah.RightHandStuff);
  }

  public override void Close() => base.Close();

  public void Click_Easy()
  {
    this.DificultySelected = 1;
    Main.Instance.OpenMenu("CustomizePlayer");
  }

  public void Click_Medium()
  {
    this.DificultySelected = 2;
    Main.Instance.OpenMenu("CustomizePlayer");
  }

  public void Click_Hard()
  {
    this.DificultySelected = 3;
    Main.Instance.OpenMenu("CustomizePlayer");
  }

  public void Click_Finally() => this.Click_Finally2();

  public void Click_Finally2()
  {
    switch (this.DificultySelected)
    {
      case 1:
        this.StartEasy();
        break;
      case 2:
        this.StartMed();
        break;
      case 3:
        this.StartHard();
        break;
    }
  }

  public void EnableLight()
  {
    Main.Instance.Lights.SetActive(true);
    Main.Instance.MainThreads.Remove(new Action(this.EnableLight));
  }

  public void StartEasy()
  {
    Main.Instance.Home_Area.OnEnter();
    Main.Instance.MainThreads.Add(new Action(this.EnableLight));
    Main.Instance.Player.transform.position = this.StartingPositions[0].position;
    Main.Instance.Player.transform.rotation = this.StartingPositions[0].rotation;
    Main.Instance.Player.PersonType = this.PersonTypes[0];
    if (Main.Instance.Player is Girl)
      Main.Instance.Player.StartingClothes.AddRange((IEnumerable<GameObject>) this.EasyClothing);
    else
      Main.Instance.Player.StartingClothes.AddRange((IEnumerable<GameObject>) this.EasyMaleClothing);
    Main.Instance.Player.TheHealth.maxHealth = 150f;
    Main.Instance.Player.TheHealth.startingHealth = 150f;
    Main.Instance.Player.Arousal = 0.2f;
    Main.Instance.GameplayMenu.StartMission(Main.Instance.AllMissions[2]);
    this.FinallyStartGamePlay();
  }

  public void StartMed()
  {
    Main.Instance.Default_Area.OnEnter();
    Main.Instance.MainThreads.Add(new Action(this.EnableLight));
    Main.Instance.Player.transform.position = this.StartingPositions[1].position;
    Main.Instance.Player.transform.rotation = this.StartingPositions[1].rotation;
    Main.Instance.Player.PersonType = this.PersonTypes[1];
    if (Main.Instance.Player is Girl)
      Main.Instance.Player.StartingClothes.AddRange((IEnumerable<GameObject>) this.MedClothing);
    else
      Main.Instance.Player.StartingClothes.AddRange((IEnumerable<GameObject>) this.MedMaleClothing);
    Main.Instance.Player.TheHealth.maxHealth = 100f;
    Main.Instance.Player.TheHealth.startingHealth = 75f;
    Main.Instance.Player.DirtySkin = true;
    Main.Instance.GameplayMenu.StartMission(Main.Instance.AllMissions[1]);
    this.FinallyStartGamePlay();
  }

  public void StartHard()
  {
    Main.Instance.CapturedBuilding1_Area.OnEnter();
    Person player = Main.Instance.Player;
    Main.Instance.DayCycle.sunLight.transform.SetParent((Transform) null);
    Main.RunInNextFrame((Action) (() => RenderSettings.ambientLight = Main.Instance.CapturedBuilding1_Area.AmbientLight), 10);
    player.transform.position = this.StartingPositions[2].position;
    player.transform.rotation = this.StartingPositions[2].rotation;
    GameObject gameObject = new GameObject();
    gameObject.transform.SetPositionAndRotation(this.StartingPositions[2].position, this.StartingPositions[2].rotation);
    Main.Instance.PlayerWakeupPlaces.Clear();
    Main.Instance.PlayerWakeupPlaces.Add(gameObject.transform);
    player.PersonType = this.PersonTypes[2];
    if (player is Girl)
      player.StartingClothes.AddRange((IEnumerable<GameObject>) this.HardClothing);
    else
      player.StartingClothes.AddRange((IEnumerable<GameObject>) this.HardMaleClothing);
    player.DyedHairColor = new Color(1f, 0.957f, 0.761f);
    player.TheHealth.maxHealth = 100f;
    player.TheHealth.startingHealth = 32f;
    player.Arousal = 0.7f;
    player.DirtySkin = true;
    Main.Instance.GameplayMenu.StartMission(Main.Instance.AllMissions[0]);
    this.FinallyStartGamePlay();
  }

  public void GenerateDefaultsIDsForThisInstance()
  {
    this.DefaultIDs.Clear();
    Main.RunInNextFrame((Action) (() =>
    {
      for (int index = 0; index < Main.Instance.SpawnedObjects.Count; ++index)
      {
        if ((UnityEngine.Object) Main.Instance.SpawnedObjects[index] != (UnityEngine.Object) null)
        {
          string worldSaveId = Main.Instance.SpawnedObjects[index].WorldSaveID;
          if (worldSaveId.Length > 0)
            this.DefaultIDs.Add(worldSaveId);
        }
      }
    }));
  }

  public void FinallyStartGamePlay()
  {
    this._LoadingCounter = 0;
    this.SmallLoading.SetActive(true);
    Main.Instance.MainThreads.Add(new Action(this.FinallyStartGamePlay_LoadingCounter));
  }

  public void FinallyStartGamePlay_LoadingCounter()
  {
    if (this._LoadingCounter++ <= 3)
      return;
    this.FinallyStartGamePlay_StartLoading();
    Main.Instance.MainThreads.Remove(new Action(this.FinallyStartGamePlay_LoadingCounter));
  }

  public void FinallyStartGamePlay_StartLoading()
  {
    if ((UnityEngine.Object) this.NewGameThings != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.NewGameThings);
    if ((UnityEngine.Object) Main.Instance.CustomizeMenu.CustomizeRoom != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) Main.Instance.CustomizeMenu.CustomizeRoom);
    if (this.DestroyWhenStartLoading != null)
    {
      for (int index = 0; index < this.DestroyWhenStartLoading.Length; ++index)
      {
        if ((UnityEngine.Object) this.DestroyWhenStartLoading[index] != (UnityEngine.Object) null)
          UnityEngine.Object.Destroy((UnityEngine.Object) this.DestroyWhenStartLoading[index]);
      }
    }
    if (this.EnableWhenNewGame != null)
    {
      for (int index = 0; index < this.EnableWhenNewGame.Length; ++index)
      {
        if ((UnityEngine.Object) this.EnableWhenNewGame[index] != (UnityEngine.Object) null)
          this.EnableWhenNewGame[index].SetActive(true);
      }
    }
    if (this.DificultySelected == 3)
    {
      if ((UnityEngine.Object) this.HardGameplayStuff != (UnityEngine.Object) null)
        this.HardGameplayStuff.SetActive(true);
    }
    else if ((UnityEngine.Object) this.MedGameplayStuff != (UnityEngine.Object) null)
      this.MedGameplayStuff.SetActive(true);
    Main.Instance.ActionWhenNav((Action) (() =>
    {
      Debug.Log((object) "1-------------");
      this.SmallLoading.SetActive(false);
      if (this.EnableAfterNewGame != null)
      {
        for (int index = 0; index < this.EnableAfterNewGame.Length; ++index)
        {
          if ((UnityEngine.Object) this.EnableAfterNewGame[index] != (UnityEngine.Object) null)
            this.EnableAfterNewGame[index].SetActive(true);
        }
      }
      if ((UnityEngine.Object) Main.Instance.DayCycle != (UnityEngine.Object) null)
        Main.Instance.DayCycle.ResetMidday();
      Main.Instance.Player.gameObject.SetActive(true);
      int num = 0;
      if ((UnityEngine.Object) Main.Instance.CustomizeMenu != (UnityEngine.Object) null)
      {
        num = Main.Instance.CustomizeMenu.GenderSettings.value;
        Main.Instance.GlobalVars.Set("GenderSettings", num.ToString());
      }
      switch (num)
      {
        case 0:
          Person.GenderChance = 0.5f;
          break;
        case 1:
          Person.GenderChance = 0.0f;
          break;
        case 2:
          Person.GenderChance = 1f;
          break;
        case 3:
          Person.GenderChance = 0.1f;
          break;
        case 4:
          Person.GenderChance = 0.9f;
          break;
      }
      Debug.Log((object) ("2------------- " + this.DificultySelected.ToString()));
      if (this.DificultySelected == 3)
      {
        RandomNPCHere[] componentsInChildren = this.Hard_PeopleToSpawn.GetComponentsInChildren<RandomNPCHere>(true);
        for (int index = 0; index < componentsInChildren.Length; ++index)
        {
          componentsInChildren[index].SpawnAnyGender = num == 0 || num == 3 || num == 4;
          componentsInChildren[index].SpawnFemale = num == 1;
        }
        if ((UnityEngine.Object) this.Hard_PeopleToSpawn != (UnityEngine.Object) null)
          this.Hard_PeopleToSpawn.SetActive(true);
        if ((UnityEngine.Object) this.Hard_PeopleToSpawn_Specials != (UnityEngine.Object) null)
          this.Hard_PeopleToSpawn_Specials.SetActive(true);
      }
      else
      {
        Debug.Log((object) "3-------------");
        RandomNPCHere[] randomNpcHereArray = !((UnityEngine.Object) this.Med_PeopleToSpawn != (UnityEngine.Object) null) ? UnityEngine.Object.FindObjectsOfType<RandomNPCHere>(true) : this.Med_PeopleToSpawn.GetComponentsInChildren<RandomNPCHere>(true);
        for (int index = 0; index < randomNpcHereArray.Length; ++index)
        {
          randomNpcHereArray[index].SpawnAnyGender = num == 0 || num == 3 || num == 4;
          randomNpcHereArray[index].SpawnFemale = num == 1;
        }
        if ((UnityEngine.Object) this.Med_PeopleToSpawn != (UnityEngine.Object) null)
          this.Med_PeopleToSpawn.SetActive(true);
        if ((UnityEngine.Object) this.Med_PeopleToSpawn_Specials != (UnityEngine.Object) null)
          this.Med_PeopleToSpawn_Specials.SetActive(true);
        Debug.Log((object) "4-------------");
      }
      Main.Instance.PreloadCam.SetActive(false);
      this.SpawnedPeople = true;
      for (int index = 0; index < Main.Instance.OnAfterSpawnPeople.Count; ++index)
        Main.Instance.OnAfterSpawnPeople[index]();
      Main.RunInNextFrame((Action) (() =>
      {
        Main.Instance.OpenMenu("Gameplay");
        Main.RunInSeconds((Action) (() =>
        {
          Main.Instance.PreloadCam.GetComponent<Camera>().cullingMask = 4;
          Main.Instance.PreloadCam.SetActive(true);
          Main.RunInNextFrame((Action) (() => Main.Instance.PreloadCam.SetActive(false)), 2);
        }), 1f);
      }));
      this.GenerateDefaultsIDsForThisInstance();
    }));
    Main.RunInNextFrame(new Action(Main.Instance.GenerateNav));
    if (UI_Settings._SpeedrunValue == 0)
      return;
    Main.Instance.GameplayMenu.SpeedrunLabel.gameObject.SetActive(true);
    Main.Instance.GameplayMenu.SpeedrunTimer = 0.0f;
    Main.Instance.MainThreads.Add(new Action(Main.Instance.GameplayMenu.SpeedrunThread));
    Main.Instance.CanSaveFlags_add("Speedrun");
    switch (UI_Settings._SpeedrunValue - 1)
    {
      case 1:
        Mission allMission1 = Main.Instance.AllMissions[1];
        for (int goal = 0; goal < allMission1.Goals.Count - 1; ++goal)
          allMission1.CompleteGoal(goal);
        allMission1.InitMission();
        Mis_MedTutorial misMedTutorial = (Mis_MedTutorial) allMission1;
        Main.Instance.MainThreads.Remove(new Action(misMedTutorial.Goal0));
        Main.Instance.MainThreads.Remove(new Action(misMedTutorial.Goal0));
        Main.Instance.MainThreads.Remove(new Action(misMedTutorial.Goal1));
        Main.Instance.MainThreads.Remove(new Action(misMedTutorial.Goal1));
        Main.Instance.MainThreads.Remove(new Action(misMedTutorial.Goal2));
        Main.Instance.MainThreads.Remove(new Action(misMedTutorial.Goal2));
        Main.Instance.MainThreads.Remove(new Action(misMedTutorial.Goal3));
        Main.Instance.MainThreads.Remove(new Action(misMedTutorial.Goal3));
        Main.Instance.MainThreads.Remove(new Action(misMedTutorial.Goal4));
        Main.Instance.MainThreads.Remove(new Action(misMedTutorial.Goal4));
        Mission allMission2 = Main.Instance.AllMissions[3];
        for (int goal = 0; goal < allMission2.Goals.Count; ++goal)
          allMission2.CompleteGoal(goal);
        allMission2.InitMission();
        for (int index = 0; index < Main.Instance.GameplayMenu.DisableWhenMissionsSklipped.Length; ++index)
          Main.Instance.GameplayMenu.DisableWhenMissionsSklipped[index].SetActive(false);
        break;
      case 2:
        foreach (Component component in UnityEngine.Object.FindObjectsOfType<int_money>())
          component.gameObject.SetActive(false);
        break;
    }
  }

  public void OpenMenuInNextFrame()
  {
    Main.Instance.OpenMenu("Gameplay");
    Main.Instance.MainThreads.Remove(new Action(this.OpenMenuInNextFrame));
  }

  public void Click_ConfirmHardMode()
  {
    this.HardWarning.SetActive(false);
    this.Click_Hard();
  }

  public void Click_CheckHardMode()
  {
    if (Main.Instance.FirstRunThisVersion)
      this.HardWarning.SetActive(true);
    else
      this.Click_Hard();
  }
}
