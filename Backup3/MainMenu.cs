// Decompiled with JetBrains decompiler
// Type: MainMenu
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class MainMenu : UI_Menu
{
  public GameObject Copied;
  public Image CopiedSprite;
  public Text CopiedText;
  public float FadeTimer;
  public bool CopiedTimer;
  public Vector3 LightsAngle;
  public GameObject[] DisableOnOpen;
  public BL_MapArea MainmenuArea;
  public int FirstRunMenu;
  public List<Transform> MainMenuPositions = new List<Transform>();
  public List<GameObject> MainMenuAnimations = new List<GameObject>();
  public GameObject MainMenuPos;
  public Transform MainMenuCam;
  public GameObject BuildIsOld;
  [Multiline]
  public string Patrons;
  public float PatronsLen;
  public Text[] PatronTexts;
  public patronlistmover[] PatronScripts;
  public GameObject[] DebugLogWarnings;
  public Text[] DebugLogButtonTexts;
  public int SpecificBG = -1;
  public Text[] VersionTexts;
  public GameObject ChangeLogMenu;
  public GameObject BuildTitlePrefab;
  public GameObject BuildBodyPrefab;
  public List<GameObject> ChangeLogEntries = new List<GameObject>();
  public Transform DisplayGirlsRoot;
  public InputField CurrentGirlText;
  public int CurrentDisplayGirl;
  public List<Transform> DisplayGirls = new List<Transform>();
  public GameObject[] _Clothes;
  public GameObject ModsButton;

  private MainMenu() => this.MenuName = nameof (MainMenu);

  public void Blick_DebugLob()
  {
    for (int index = 0; index < this.DebugLogButtonTexts.Length; ++index)
      this.DebugLogWarnings[index].SetActive(!this.DebugLogWarnings[index].activeSelf);
  }

  public void CLick_CloseDebugLog()
  {
    for (int index = 0; index < this.DebugLogWarnings.Length; ++index)
      this.DebugLogWarnings[index].SetActive(false);
  }

  public void PlaceMainMenuOnRand()
  {
    bool flag = PlayerPrefs.GetInt("FirstRun8.5", 0) == 0;
    int index = flag ? this.FirstRunMenu : UnityEngine.Random.Range(0, this.MainMenuPositions.Count);
    PlayerPrefs.SetInt("FirstRun8.5", 1);
    if (PlayerPrefs.GetInt("FirstRun10.e", 0) == 0)
      Main.Instance.FirstRunThisVersion = true;
    PlayerPrefs.SetInt("FirstRun10.e", 1);
    if (this.SpecificBG != -1)
      index = this.SpecificBG;
    Transform mainMenuPosition = this.MainMenuPositions[index];
    this.MainMenuCam.SetPositionAndRotation(mainMenuPosition.position, mainMenuPosition.rotation);
    mainmenu_animsetup component1 = mainMenuPosition.GetComponent<mainmenu_animsetup>();
    if ((UnityEngine.Object) component1 != (UnityEngine.Object) null)
      component1.Init();
    this.MainMenuPos = this.MainMenuAnimations[UnityEngine.Random.Range(0, this.MainMenuAnimations.Count)];
    this.MainMenuPos.SetActive(true);
    this.MainMenuPos.transform.SetPositionAndRotation(mainMenuPosition.position, mainMenuPosition.rotation);
    mainmenu_animsetup component2 = this.MainMenuPos.GetComponent<mainmenu_animsetup>();
    if ((UnityEngine.Object) component2 != (UnityEngine.Object) null)
      component2.Init();
    this.CurrentDisplayGirl = flag ? this.DisplayGirls.Count : UnityEngine.Random.Range(0, this.DisplayGirls.Count);
    this.NextDisplayGirl();
  }

  public void Start()
  {
    this.Patrons = File.ReadAllText(Main.AssetsFolder + "/Patrons.txt");
    this.UpdateVersionTexts();
    for (int index = 0; index < this.PatronTexts.Length; ++index)
    {
      this.PatronScripts[index].Top = this.PatronsLen;
      this.PatronTexts[index].text = this.Patrons;
    }
    for (int index = 0; index < this.DisableOnOpen.Length; ++index)
      this.DisableOnOpen[index].SetActive(false);
    this.LoadMenuGirls();
    this.PlaceMainMenuOnRand();
  }

  public override void Open()
  {
    base.Open();
    this.MainmenuArea.OnEnter();
    Main.RunInNextFrame((Action) (() => this.PeopleDisableWhileOpen[1].gameObject.SetActive(false)));
    Main.Instance.Lights.SetActive(true);
    Main.Instance.Lights.transform.localEulerAngles = this.LightsAngle;
    Time.timeScale = 1f;
    DateTime result = new DateTime();
    DateTime.TryParse("2026/06/01", out result);
    this.BuildIsOld.SetActive(result < DateTime.Now);
    this.ModsButton.SetActive(!Main.Instance.FreeWorldPatch);
    switch (UI_Settings._SpeedrunValue)
    {
      case 1:
        Main.Instance.SettingsMenu.Click_SpeedHard();
        break;
      case 2:
        Main.Instance.SettingsMenu.Click_SpeedMed();
        break;
      case 3:
        Main.Instance.SettingsMenu.Click_Speed1000();
        break;
    }
  }

  public void Click_NewGame()
  {
    Main.Instance.OpenMenu("NewGame");
    for (int index = 0; index < this.MainMenuAnimations.Count; ++index)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.MainMenuAnimations[index]);
  }

  public void Click_LoadGame() => Main.Instance.OpenMenu("LoadGame");

  public void Click_Settings() => Main.Instance.OpenMenu("Settings");

  public void Click_Exit() => Application.Quit();

  public void Click_Patreon()
  {
    try
    {
      GUIUtility.systemCopyBuffer = "https://www.patreon.com/breakfast5";
      this.FadeTimer = 4f;
      this.CopiedTimer = true;
      this.Copied.SetActive(true);
    }
    catch
    {
    }
    try
    {
      Application.OpenURL("https://www.patreon.com/breakfast5");
    }
    catch
    {
    }
  }

  public void Update()
  {
    if (!this.CopiedTimer)
      return;
    this.FadeTimer -= Time.deltaTime;
    this.CopiedSprite.color = new Color(this.CopiedSprite.color.r, this.CopiedSprite.color.g, this.CopiedSprite.color.b, this.FadeTimer / 4f);
    this.CopiedText.color = new Color(this.CopiedText.color.r, this.CopiedText.color.g, this.CopiedText.color.b, this.FadeTimer / 4f);
    if ((double) this.FadeTimer >= 0.0)
      return;
    this.CopiedTimer = false;
    this.Copied.SetActive(false);
  }

  public void UpdateVersionTexts()
  {
    for (int index = 0; index < this.VersionTexts.Length; ++index)
      this.VersionTexts[index].text = "10.e";
  }

  public void Click_ChangeLog()
  {
    this.ChangeLogMenu.SetActive(!this.ChangeLogMenu.activeInHierarchy);
    if (this.ChangeLogMenu.activeInHierarchy)
    {
      string[] strArray = File.ReadAllLines(Application.dataPath + "/../Change-log.txt");
      string str = string.Empty;
      int num = 0;
      int y = 0;
      for (int index = 0; index < strArray.Length; ++index)
      {
        if (strArray[index].Length > 0 && strArray[index][0] == '(')
        {
          if (str.Length != 0)
          {
            GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BuildBodyPrefab, this.BuildBodyPrefab.transform.parent);
            gameObject.GetComponent<Text>().text = str;
            gameObject.SetActive(true);
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(100f, (float) (num * 13));
            this.ChangeLogEntries.Add(gameObject);
            y += num * 13;
            str = string.Empty;
            num = 0;
          }
          GameObject gameObject1 = UnityEngine.Object.Instantiate<GameObject>(this.BuildTitlePrefab, this.BuildTitlePrefab.transform.parent);
          gameObject1.GetComponent<Text>().text = strArray[index];
          gameObject1.SetActive(true);
          this.ChangeLogEntries.Add(gameObject1);
          y += 28;
        }
        else
        {
          str = str + strArray[index] + "\n";
          ++num;
        }
      }
      RectTransform component = this.BuildTitlePrefab.transform.parent.GetComponent<RectTransform>();
      component.sizeDelta = new Vector2(component.sizeDelta.x, (float) y);
    }
    else
    {
      for (int index = 0; index < this.ChangeLogEntries.Count; ++index)
        UnityEngine.Object.Destroy((UnityEngine.Object) this.ChangeLogEntries[index]);
    }
  }

  public void LoadMenuGirls()
  {
    string[] files = Directory.GetFiles(Main.AssetsFolder + "/Characters/MainMenu/", "*.png");
    int index = 0;
    while (index < files.Length)
    {
      this.DisplayGirls.Add(new GameObject(Path.GetFileNameWithoutExtension(files[index++])).transform);
      this.DisplayGirls[index].SetParent(this.DisplayGirlsRoot);
      this.DisplayGirls[index].localEulerAngles = Vector3.zero;
      this.DisplayGirls[index].localPosition = Vector3.zero;
    }
  }

  public void NextDisplayGirl()
  {
    this.HideDisplayGirl();
    ++this.CurrentDisplayGirl;
    if (this.CurrentDisplayGirl >= this.DisplayGirls.Count)
      this.CurrentDisplayGirl = 0;
    this.PutDisplayGirl();
  }

  public void PrevDisplayGirl()
  {
    this.HideDisplayGirl();
    --this.CurrentDisplayGirl;
    if (this.CurrentDisplayGirl < 0)
      this.CurrentDisplayGirl = this.DisplayGirls.Count - 1;
    this.PutDisplayGirl();
  }

  public void HideDisplayGirl()
  {
    if (this.CurrentDisplayGirl > 0)
    {
      if (this.DisplayGirls.Count <= this.CurrentDisplayGirl || !((UnityEngine.Object) this.DisplayGirls[this.CurrentDisplayGirl] != (UnityEngine.Object) null) || this.DisplayGirls[this.CurrentDisplayGirl].childCount == 0)
        return;
      this.DisplayGirls[this.CurrentDisplayGirl].GetChild(0).gameObject.SetActive(false);
      this.DisplayGirls[this.CurrentDisplayGirl].GetChild(0).gameObject.GetComponent<Girl>().GirlPhysics = false;
    }
    else
      this.DisplayGirls[0].gameObject.SetActive(false);
  }

  public void PutDisplayGirl()
  {
    Transform displayGirl = this.DisplayGirls[this.CurrentDisplayGirl];
    Girl _girl;
    if (displayGirl.childCount == 0)
    {
      _girl = Main.Spawn(Main.Instance.PersonPrefab, this.DisplayGirls[this.CurrentDisplayGirl]).GetComponent<Girl>();
      _girl.LoadFromFile(Main.AssetsFolder + "/Characters/MainMenu/" + displayGirl.name + ".png");
      _girl.transform.localEulerAngles = Vector3.zero;
      _girl.transform.localPosition = Vector3.zero;
      _girl.AddMoveBlocker("mainmenudisplay");
      _girl.LodRen.gameObject.SetActive(false);
      _girl.SetHighLod();
      _girl.Anim.applyRootMotion = false;
      _girl.LookAtPlayer.enabled = true;
      _girl.LookAtPlayer.playerTransform = this.MainMenuCam;
      _girl.LookAtPlayer.DontBlockSides = true;
      _girl.A_Standing = "boobs1";
      this.CurrentGirlText.text = displayGirl.name;
      _girl.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
      string path = Main.AssetsFolder + "/Characters/MainMenu/" + displayGirl.name + ".txt";
      bool flag = false;
      if (File.Exists(path))
      {
        foreach (string readAllLine in File.ReadAllLines(path))
        {
          string[] strArray1 = readAllLine.Split("=", StringSplitOptions.None);
          switch (strArray1[0])
          {
            case "anim":
              flag = true;
              _girl.A_Standing = strArray1[1];
              break;
            case "clothes":
              string[] strArray2 = strArray1[1].Split(";", StringSplitOptions.None);
              this._Clothes = new GameObject[strArray2.Length];
              for (int index1 = 0; index1 < strArray2.Length; ++index1)
              {
                string[] strArray3 = strArray2[index1].Split(":", StringSplitOptions.None);
                for (int index2 = 0; index2 < Main.Instance.AllPrefabs.Count; ++index2)
                {
                  if (strArray3[0] == Main.Instance.AllPrefabs[index2].name)
                  {
                    this._Clothes[index1] = Main.Instance.AllPrefabs[index2];
                    if (strArray3.Length > 1 && (UnityEngine.Object) this._Clothes[index1].GetComponentInChildren<int_PickableClothingPackage>(true) != (UnityEngine.Object) null)
                    {
                      GameObject gameObject = Main.Spawn(this._Clothes[index1], Main.Instance.DisabledObjects);
                      int_PickableClothingPackage componentInChildren = gameObject.GetComponentInChildren<int_PickableClothingPackage>(true);
                      if ((UnityEngine.Object) componentInChildren != (UnityEngine.Object) null)
                        componentInChildren.ClothingData = ":" + strArray3[1] + ":RGBA(0.000, 0.000, 0.000, 0.000)";
                      this._Clothes[index1] = gameObject;
                      break;
                    }
                    break;
                  }
                }
              }
              _girl.ChangeUniform(this._Clothes);
              break;
            case "extraheadrot":
              _girl.LookAtPlayer.ExtraRot = true;
              _girl.LookAtPlayer.AddHeadRotation = Main.ParseVector3(strArray1[1]);
              break;
            case "eyes":
              if (bool.Parse(strArray1[1]))
              {
                _girl.LookAtPlayer.OnlyEyes = true;
                break;
              }
              _girl.LookAtPlayer.OnlyEyes = false;
              break;
            case "face":
              _girl.ApplyFaceBlendShapeData(Main.Instance.BlendShapesDatas[int.Parse(strArray1[1])]);
              break;
            case "name":
              this.CurrentGirlText.text = strArray1[1];
              displayGirl.name = strArray1[1];
              break;
            case "pos":
              _girl.transform.localPosition = Main.ParseVector3(strArray1[1]);
              break;
            case "rot":
              _girl.transform.localEulerAngles = Main.ParseVector3(strArray1[1]);
              break;
            case "scale":
              _girl.transform.localScale = Main.ParseVector3(strArray1[1]);
              break;
          }
        }
      }
      if (!flag || flag && _girl.A_Standing == "boobs1")
      {
        mminit_1 component = this.MainMenuPos.GetComponent<mminit_1>();
        component.TheGirl = _girl;
        component.Init();
      }
      else
        Main.RunInNextFrame((Action) (() =>
        {
          if (!_girl.gameObject.activeSelf)
            return;
          _girl.GirlPhysics = true;
        }));
      this.DisplayGirls[0].gameObject.SetActive(false);
    }
    else
    {
      _girl = displayGirl.GetComponentInChildren<Girl>(true);
      _girl.gameObject.SetActive(true);
      this.CurrentGirlText.text = displayGirl.name;
      Main.RunInNextFrame((Action) (() =>
      {
        if (!(_girl.A_Standing != "boobs1") || !_girl.gameObject.activeSelf)
          return;
        _girl.GirlPhysics = true;
      }));
    }
  }

  public void Click_Mods() => Main.Instance.OpenMenu("Settings");
}
