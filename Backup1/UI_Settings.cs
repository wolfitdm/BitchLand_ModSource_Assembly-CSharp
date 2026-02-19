// Decompiled with JetBrains decompiler
// Type: UI_Settings
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UI_Settings : UI_Menu
{
  public GameObject MianMenuCam;
  public Dropdown MajorQuality;
  public Toggle DayCycle;
  public Toggle Moans;
  [Obsolete]
  public Toggle ScatContent;
  public Toggle RunByDefault;
  public Toggle SimpleCam;
  public Dropdown ShadowQualityDrop;
  public Toggle Shadows;
  public Toggle Shadows_Low;
  public Toggle Effects;
  public Toggle PhysicsAll;
  public Toggle PhysicsSex;
  public Slider Sensityfyft;
  public Slider FOVSlider;
  public Text FOVLabel;
  public Dropdown resoluotn;
  public Toggle FullscreenToofgle;
  public Toggle PlayerLookAtCam;
  public Toggle DoAutosave;
  public Dropdown AutosaveTimer;
  public Dropdown VSyncDrop;
  public Slider MusicSlider;
  public Dropdown CameraSide;
  public static float CurrentMouseSensitivity = 1f;
  public bool Fullscreenshouldbe;
  public Toggle ToggleDotCrossAir;
  public GameObject DotCrossAir;
  public Dropdown BellyBulgeDrop;
  public InputField CustomResX;
  public InputField CustomResY;
  public bool PostEnabled = true;
  public static float TargetFOV;
  public GameObject ResCheck;
  public Text ResCheckTimer_text;
  public float ResCheckTimer;
  public DynamicResolution DynResComp;
  public bool DynRes;
  public InputField[] KeyBinds;
  public char[] AllowedKeys;
  public GameObject[] NormalSettingsMenus;
  public GameObject FetishesMenu;
  public GameObject MiscMenu;
  public GameObject ModsMenu;
  public GameObject SpeedrunMenu;
  public RectTransform ModsContent;
  public GameObject ModEntry;
  public GameObject NoModArrows;
  public bool ModsDownloaded;
  public GameObject ModsRoot;
  public Slider[] ModsProgress;
  public Toggle ToggleChasFetish;
  public static int BellyBulgeValue;
  public Text[] SpeedrunTimeLabels;
  public static int _SpeedrunValue;
  [Header("Invert ----")]
  public Toggle ClickInvert;
  public Dropdown InvertX_3rd;
  public Dropdown InvertY_3rd;
  public Dropdown InvertX_1st;
  public Dropdown InvertY_1st;
  public Dropdown InvertX_Car;
  public Dropdown InvertY_Car;
  public Dropdown InvertX_Turret;
  public Dropdown InvertY_Turret;
  public static bool Inverted_Click;
  public static bool Inverted_X_3rd;
  public static bool Inverted_Y_3rd;
  public static bool Inverted_X_1st;
  public static bool Inverted_Y_1st;
  public static bool Inverted_X_car;
  public static bool Inverted_Y_car;
  public static bool Inverted_X_tur;
  public static bool Inverted_Y_tur;

  private UI_Settings() => this.MenuName = "Settings";

  public void SetCustomRes()
  {
    int result1 = 0;
    int result2 = 0;
    int.TryParse(this.CustomResX.text, out result1);
    if (result1 < 300)
      result1 = 300;
    int.TryParse(this.CustomResY.text, out result2);
    if (result2 < 300)
      result2 = 300;
    Screen.SetResolution(result1, result2, Screen.fullScreen);
    this.DoResolutionCheck();
  }

  public override void Open()
  {
    base.Open();
    FirstPersonCharacter.AllowMouseCursor = true;
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
    if (!Main.Instance.GameplayMenu.GameplayStarted)
      this.MianMenuCam.SetActive(true);
    Text captionText = this.resoluotn.captionText;
    int num = Screen.width;
    string str1 = num.ToString();
    num = Screen.height;
    string str2 = num.ToString();
    string str3 = str1 + " x " + str2;
    captionText.text = str3;
    this.Fullscreenshouldbe = Screen.fullScreen;
    if (Main.Instance.FreeWorldPatch)
      this.Click_NormalSettings();
    else
      this.Click_Mods();
  }

  public void Update()
  {
    if (Input.GetKeyUp(KeyCode.Escape))
      this.Click_Bakc();
    if (!this.ResCheck.activeSelf)
      return;
    this.ResCheckTimer_text.text = "(" + this.ResCheckTimer.ToString("0") + ")";
    this.ResCheckTimer -= Time.deltaTime;
    if ((double) this.ResCheckTimer >= 0.0)
      return;
    this.ResCheck_No();
  }

  public void Click_Bakc()
  {
    if (Main.Instance.GameplayMenu.GameplayStarted)
      Main.Instance.OpenMenu("Gameplay");
    else
      Main.Instance.OpenMenu("MainMenu");
  }

  public void Click_Scat()
  {
  }

  public void Click_Shadows()
  {
    QualitySettings.shadows = this.Shadows.isOn ? ShadowQuality.All : ShadowQuality.Disable;
    QualitySettings.shadowDistance = 30f;
    QualitySettings.shadowResolution = ShadowResolution.High;
    if (!this.Shadows_Low.isOn)
      return;
    this.Shadows_Low.SetIsOnWithoutNotify(false);
  }

  public void Click_Shadows_Low()
  {
    QualitySettings.shadows = this.Shadows_Low.isOn ? ShadowQuality.HardOnly : ShadowQuality.Disable;
    QualitySettings.shadowDistance = 10f;
    QualitySettings.shadowResolution = ShadowResolution.Low;
    if (!this.Shadows.isOn)
      return;
    this.Shadows.SetIsOnWithoutNotify(false);
  }

  public void Drop_Shadows()
  {
    switch (this.ShadowQualityDrop.value)
    {
      case 0:
        QualitySettings.shadows = ShadowQuality.All;
        QualitySettings.shadowDistance = 30f;
        QualitySettings.shadowResolution = ShadowResolution.High;
        break;
      case 1:
        QualitySettings.shadows = ShadowQuality.HardOnly;
        QualitySettings.shadowDistance = 10f;
        QualitySettings.shadowResolution = ShadowResolution.Low;
        break;
      case 2:
        QualitySettings.shadows = ShadowQuality.Disable;
        break;
    }
  }

  public void Click_Effects()
  {
    this.PostEnabled = !this.PostEnabled;
    Main.Instance.PostProcessingCam.SetActive(this.PostEnabled);
  }

  public void Click_RunByDefault()
  {
    bl_ThirdPersonUserControl.RunByDefault = this.RunByDefault.isOn;
    int num = bl_ThirdPersonUserControl.RunByDefault ? 1 : 0;
    this.SaveAllSettings();
  }

  public void Click_SimpleCam()
  {
  }

  public void Click_CursorSensistivityChange()
  {
    UI_Settings.CurrentMouseSensitivity = this.Sensityfyft.value;
    this.SaveAllSettings();
  }

  public void Click_CursorFOVChange()
  {
    UI_Settings.TargetFOV = this.FOVSlider.value;
    this.FOVLabel.text = UI_Settings.TargetFOV.ToString();
    if ((UnityEngine.Object) Main.Instance.MainMenuCam != (UnityEngine.Object) null)
      Main.Instance.MainMenuCam.fieldOfView = UI_Settings.TargetFOV;
    Main.Instance.PlayerCam.fieldOfView = UI_Settings.TargetFOV;
    Main.Instance.PostProcessingCam.GetComponent<Camera>().fieldOfView = UI_Settings.TargetFOV;
    this.SaveAllSettings();
  }

  public void Click_ResolutionCHange()
  {
    switch (this.resoluotn.value)
    {
      case 0:
        Screen.SetResolution(1280, 720, Screen.fullScreen);
        break;
      case 1:
        Screen.SetResolution(1920, 1080, Screen.fullScreen);
        break;
      case 2:
        Screen.SetResolution(1024, 576, Screen.fullScreen);
        break;
      case 3:
        Screen.SetResolution(720, 480, Screen.fullScreen);
        break;
      case 4:
        Screen.SetResolution(2560, 1440, Screen.fullScreen);
        break;
      case 5:
        Screen.SetResolution(2560, 1600, Screen.fullScreen);
        break;
    }
    this.DoResolutionCheck();
  }

  public void DoResolutionCheck()
  {
    this.ResCheckTimer = 5f;
    this.ResCheck.SetActive(true);
  }

  public void ResCheck_Yes()
  {
    this.ResCheck.SetActive(false);
    this.SaveAllSettings();
  }

  public void ResCheck_No()
  {
    this.ResCheckTimer = 5f;
    this.resoluotn.value = 0;
    this.ResCheck.SetActive(false);
    this.SaveAllSettings();
  }

  public void Click_DayCycle() => Main.Instance.DayCycle.enabled = this.DayCycle.isOn;

  public void Clikc_fullscreeecn()
  {
    this.Fullscreenshouldbe = !this.Fullscreenshouldbe;
    Screen.fullScreen = this.Fullscreenshouldbe;
  }

  public void OnMajorQuality() => QualitySettings.SetQualityLevel(this.MajorQuality.value);

  public void OnPlayerLookAtCam()
  {
    if (this.PlayerLookAtCam.isOn)
    {
      Main.Instance.Player.LookAtPlayer.playerTransform = Main.Instance.Player.UserControl.m_Cam;
      Main.Instance.Player.LookAtPlayer.enabled = true;
      Main.Instance.Player.LookAtPlayer.Disable = false;
      Main.Instance.Player.LookAtPlayer.OnlyEyes = false;
      if (!((UnityEngine.Object) Main.Instance.MalePlayer != (UnityEngine.Object) null))
        return;
      Main.Instance.MalePlayer.LookAtPlayer.playerTransform = Main.Instance.Player.UserControl.m_Cam;
      Main.Instance.MalePlayer.LookAtPlayer.enabled = true;
      Main.Instance.MalePlayer.LookAtPlayer.Disable = false;
      Main.Instance.MalePlayer.LookAtPlayer.OnlyEyes = false;
    }
    else
    {
      Main.Instance.Player.LookAtPlayer.enabled = false;
      Main.Instance.Player.LookAtPlayer.Disable = true;
      if (!((UnityEngine.Object) Main.Instance.MalePlayer != (UnityEngine.Object) null))
        return;
      Main.Instance.MalePlayer.LookAtPlayer.enabled = false;
      Main.Instance.MalePlayer.LookAtPlayer.Disable = true;
    }
  }

  public void Click_Moans()
  {
    Main.Instance.MoansEnabled = this.Moans.isOn;
    this.SaveAllSettings();
  }

  public void Click_PhysicsAll()
  {
    Main.Instance.PhysicsAllEnabled = this.PhysicsAll.isOn;
    if (this.PhysicsAll.isOn)
    {
      this.PhysicsSex.isOn = true;
      this.PhysicsSex.interactable = false;
    }
    else
    {
      this.PhysicsSex.interactable = true;
      for (int index = 0; index < Main.Instance.SpawnedPeople.Count; ++index)
      {
        if ((UnityEngine.Object) Main.Instance.SpawnedPeople[index] != (UnityEngine.Object) null && Main.Instance.SpawnedPeople[index] is Girl)
          ((Girl) Main.Instance.SpawnedPeople[index]).GirlPhysics = false;
      }
    }
    this.SaveAllSettings();
  }

  public void Click_PhysicsSex()
  {
    Main.Instance.PhysicsSexEnabled = this.PhysicsSex.isOn;
    this.SaveAllSettings();
  }

  public void Click_CameraSide()
  {
    Main.Instance.Player.UserControl.ThirdCamPositionTypeOnSettings = (bl_ThirdPersonUserControl.e_ThirdCamPositionType) this.CameraSide.value;
    Main.Instance.Player.UserControl.ThirdCamPositionType = (bl_ThirdPersonUserControl.e_ThirdCamPositionType) this.CameraSide.value;
    this.SaveAllSettings();
  }

  public void Click_DynRes()
  {
    this.DynRes = !this.DynRes;
    this.DynResComp.enabled = this.DynRes;
  }

  public void SaveAllSettings()
  {
    PlayerPrefs.SetFloat("CurrentMouseSensitivity", UI_Settings.CurrentMouseSensitivity);
    PlayerPrefs.SetFloat("TargetFOV", UI_Settings.TargetFOV);
    PlayerPrefs.SetInt("MoansEnabled", Main.Instance.MoansEnabled ? 1 : 2);
    PlayerPrefs.SetInt("PhysicsAllEnabled", Main.Instance.PhysicsAllEnabled ? 1 : 2);
    PlayerPrefs.SetInt("PhysicsSexEnabled", Main.Instance.PhysicsSexEnabled ? 1 : 2);
    PlayerPrefs.SetInt("RunByDefault", bl_ThirdPersonUserControl.RunByDefault ? 1 : 2);
    PlayerPrefs.SetInt("CamSide", this.CameraSide.value);
    PlayerPrefs.SetInt("ResolutionX", Screen.width);
    PlayerPrefs.SetInt("ResolutionY", Screen.height);
    PlayerPrefs.SetFloat("Music", Main.Instance.MusicPlayer.volume);
    PlayerPrefs.SetInt("AutosavedEnabled", this.DoAutosave.isOn ? 1 : 0);
    PlayerPrefs.SetInt("AutosavedTimer", this.AutosaveTimer.value);
    PlayerPrefs.SetInt("VSync", this.VSyncDrop.value);
    PlayerPrefs.SetInt("Invert_Click", UI_Settings.Inverted_Click ? 1 : 0);
    PlayerPrefs.SetInt("Invert_X_3rd", UI_Settings.Inverted_X_3rd ? 1 : 0);
    PlayerPrefs.SetInt("Invert_Y_3rd", UI_Settings.Inverted_Y_3rd ? 1 : 0);
    PlayerPrefs.SetInt("Invert_X_1st", UI_Settings.Inverted_X_1st ? 1 : 0);
    PlayerPrefs.SetInt("Invert_Y_1st", UI_Settings.Inverted_Y_1st ? 1 : 0);
    PlayerPrefs.SetInt("Invert_X_car", UI_Settings.Inverted_X_car ? 1 : 0);
    PlayerPrefs.SetInt("Invert_Y_car", UI_Settings.Inverted_Y_car ? 1 : 0);
    PlayerPrefs.SetInt("Invert_X_turret", UI_Settings.Inverted_X_tur ? 1 : 0);
    PlayerPrefs.SetInt("Invert_Y_turret", UI_Settings.Inverted_Y_tur ? 1 : 0);
    PlayerPrefs.SetInt("SettingsSaved", 1);
  }

  public void ApplyAllSettings()
  {
    if (PlayerPrefs.GetInt("SettingsSaved") != 1)
      return;
    Main.Instance.MoansEnabled = PlayerPrefs.GetInt("MoansEnabled") != 2;
    this.Moans.SetIsOnWithoutNotify(Main.Instance.MoansEnabled);
    Main.Instance.PhysicsSexEnabled = PlayerPrefs.GetInt("PhysicsSexEnabled") != 2;
    this.PhysicsSex.SetIsOnWithoutNotify(Main.Instance.PhysicsSexEnabled);
    Main.Instance.PhysicsAllEnabled = PlayerPrefs.GetInt("PhysicsAllEnabled") != 2;
    this.PhysicsAll.SetIsOnWithoutNotify(Main.Instance.PhysicsAllEnabled);
    UI_Settings.TargetFOV = PlayerPrefs.GetFloat("TargetFOV");
    if ((double) UI_Settings.TargetFOV < 30.0)
      UI_Settings.TargetFOV = 60f;
    if ((double) UI_Settings.TargetFOV > 100.0)
      UI_Settings.TargetFOV = 60f;
    this.FOVSlider.SetValueWithoutNotify(UI_Settings.TargetFOV);
    this.FOVLabel.text = UI_Settings.TargetFOV.ToString();
    if ((UnityEngine.Object) Main.Instance.MainMenuCam != (UnityEngine.Object) null)
      Main.Instance.MainMenuCam.fieldOfView = UI_Settings.TargetFOV;
    Main.Instance.PlayerCam.fieldOfView = UI_Settings.TargetFOV;
    if ((UnityEngine.Object) Main.Instance.PostProcessingCam != (UnityEngine.Object) null)
      Main.Instance.PostProcessingCam.GetComponent<Camera>().fieldOfView = UI_Settings.TargetFOV;
    UI_Settings.CurrentMouseSensitivity = PlayerPrefs.GetFloat("CurrentMouseSensitivity");
    if ((double) UI_Settings.CurrentMouseSensitivity == 0.0)
      UI_Settings.CurrentMouseSensitivity = 1f;
    this.Sensityfyft.SetValueWithoutNotify(UI_Settings.CurrentMouseSensitivity);
    bl_ThirdPersonUserControl.RunByDefault = PlayerPrefs.GetInt("RunByDefault") != 2;
    this.RunByDefault.SetIsOnWithoutNotify(bl_ThirdPersonUserControl.RunByDefault);
    Debug.Log((object) ("CamSide " + PlayerPrefs.GetInt("CamSide").ToString()));
    this.CameraSide.SetValueWithoutNotify(PlayerPrefs.GetInt("CamSide"));
    Main.Instance.Player.UserControl.ThirdCamPositionTypeOnSettings = (bl_ThirdPersonUserControl.e_ThirdCamPositionType) this.CameraSide.value;
    Main.Instance.Player.UserControl.ThirdCamPositionType = (bl_ThirdPersonUserControl.e_ThirdCamPositionType) this.CameraSide.value;
    int width = PlayerPrefs.GetInt("ResolutionX");
    int height = PlayerPrefs.GetInt("ResolutionY");
    if (width > 0 && height > 0)
    {
      if (height > width)
      {
        int num = width;
        width = height;
        height = num;
      }
      Screen.SetResolution(width, height, Screen.fullScreen);
    }
    Main.Instance.MusicPlayer.volume = PlayerPrefs.GetFloat("Music");
    if ((double) Main.Instance.MusicPlayer.volume == 0.0)
      Main.Instance.MusicPlayer.volume = 1f;
    if (!PlayerPrefs.HasKey("AutosavedEnabled"))
      PlayerPrefs.SetInt("AutosavedEnabled", 1);
    bool flag = PlayerPrefs.GetInt("AutosavedEnabled") == 1;
    this.DoAutosave.SetIsOnWithoutNotify(flag);
    this.AutosaveTimer.interactable = Main.Instance.AutosaveEnable = flag;
    this.AutosaveTimer.SetValueWithoutNotify(PlayerPrefs.GetInt("AutosavedTimer"));
    switch (this.AutosaveTimer.value)
    {
      case 0:
        Main.Instance.AutoSaveTimerMax = 300f;
        break;
      case 1:
        Main.Instance.AutoSaveTimerMax = 600f;
        break;
      case 2:
        Main.Instance.AutoSaveTimerMax = 1800f;
        break;
    }
    this.VSyncDrop.SetValueWithoutNotify(PlayerPrefs.GetInt("VSync"));
    QualitySettings.vSyncCount = this.VSyncDrop.value;
    this.ClickInvert.SetIsOnWithoutNotify(PlayerPrefs.GetInt("Invert_Click") == 1);
    this.InvertX_3rd.SetValueWithoutNotify(PlayerPrefs.GetInt("Invert_X_3rd"));
    this.InvertY_3rd.SetValueWithoutNotify(PlayerPrefs.GetInt("Invert_Y_3rd"));
    this.InvertX_1st.SetValueWithoutNotify(PlayerPrefs.GetInt("Invert_X_1st"));
    this.InvertY_1st.SetValueWithoutNotify(PlayerPrefs.GetInt("Invert_Y_1st"));
    this.InvertX_Car.SetValueWithoutNotify(PlayerPrefs.GetInt("Invert_X_car"));
    this.InvertY_Car.SetValueWithoutNotify(PlayerPrefs.GetInt("Invert_Y_car"));
    this.InvertX_Turret.SetValueWithoutNotify(PlayerPrefs.GetInt("Invert_X_turret"));
    this.InvertY_Turret.SetValueWithoutNotify(PlayerPrefs.GetInt("Invert_Y_turret"));
    UI_Settings.Inverted_Click = this.ClickInvert.isOn;
    UI_Settings.Inverted_X_3rd = this.InvertX_3rd.value == 1;
    UI_Settings.Inverted_Y_3rd = this.InvertY_3rd.value == 1;
    UI_Settings.Inverted_X_1st = this.InvertX_1st.value == 1;
    UI_Settings.Inverted_Y_1st = this.InvertY_1st.value == 1;
    UI_Settings.Inverted_X_car = this.InvertX_Car.value == 1;
    UI_Settings.Inverted_Y_car = this.InvertY_Car.value == 1;
    UI_Settings.Inverted_X_tur = this.InvertX_Turret.value == 1;
    UI_Settings.Inverted_Y_tur = this.InvertY_Turret.value == 1;
  }

  public void ChangeKeyBind(int index)
  {
    char ch;
    if (this.KeyBinds[index].text.Length != 0)
    {
      ch = this.KeyBinds[index].text.ToUpper()[0];
      for (int index1 = 0; index1 < this.AllowedKeys.Length; ++index1)
      {
        if ((int) ch == (int) this.AllowedKeys[index1])
          goto label_6;
      }
    }
    this.KeyBinds[index].text = "A";
    ch = 'A';
label_6:
    Main.Instance.KeyBinds[index] = (KeyCode) ((int) ch - 65 + 97);
  }

  public void Click_Toggle_DotCrossAir() => this.DotCrossAir.SetActive(this.ToggleDotCrossAir.isOn);

  public void Slide_Music()
  {
    Main.Instance.MusicPlayer.volume = this.MusicSlider.value;
    this.SaveAllSettings();
  }

  public void CloseAllMenus()
  {
    Debug.Log((object) ("YesTodayIJustCantBotherToDoAnArrayAndKeepTrackOfTheIndexForEachWithAnEnum" + "AndAlsoCantBotherToDoEachButtonClickFunctionIntoASingleFunctionThatTakesAnIntegerAsParameter")[1]);
    this.NormalSettingsMenus[0].SetActive(false);
    this.NormalSettingsMenus[1].SetActive(false);
    this.FetishesMenu.SetActive(false);
    this.MiscMenu.SetActive(false);
    this.ModsMenu.SetActive(false);
    this.SpeedrunMenu.SetActive(false);
  }

  public void Click_NormalSettings()
  {
    this.CloseAllMenus();
    this.NormalSettingsMenus[0].SetActive(true);
    this.NormalSettingsMenus[1].SetActive(true);
  }

  public void Click_Fetishes()
  {
    this.CloseAllMenus();
    this.FetishesMenu.SetActive(true);
  }

  public void Click_Misc()
  {
    this.CloseAllMenus();
    this.MiscMenu.SetActive(true);
  }

  public void Click_Mods()
  {
    this.CloseAllMenus();
    this.ModsMenu.SetActive(true);
    this.NoModArrows.SetActive(!Main.Instance.FreeWorldPatch);
  }

  public void RefreshMods()
  {
    string[] directories = Directory.GetDirectories(Main.AssetsFolder + "/Mods/");
    float y = 85f;
    for (int index1 = 0; index1 < directories.Length; ++index1)
    {
      string path = directories[index1] + "/info.txt";
      if (File.Exists(path))
      {
        string[] strArray = File.ReadAllLines(path);
        string str1 = string.Empty;
        string str2 = string.Empty;
        bool flag = false;
        for (int index2 = 0; index2 < strArray.Length; ++index2)
        {
          string upperInvariant = strArray[index2].ToUpperInvariant();
          if (upperInvariant.StartsWith("TITLE:"))
            str1 = strArray[index2].Remove(0, 6);
          else if (upperInvariant.StartsWith("DESCRIPTION:"))
            str2 = strArray[index2].Remove(0, 12);
          else if (upperInvariant.StartsWith("ENABLED:"))
            flag = upperInvariant.Remove(0, 8) == "TRUE";
        }
        misc_ModEntry component = UnityEngine.Object.Instantiate<GameObject>(this.ModEntry, this.ModEntry.transform.parent).GetComponent<misc_ModEntry>();
        component.gameObject.SetActive(true);
        component.ModFolder = directories[index1];
        component.Title.text = str1;
        component.Desc.text = str2;
        component.ModEnabled.SetIsOnWithoutNotify(flag);
        y += 85f;
      }
    }
    this.ModsContent.sizeDelta = new Vector2(0.0f, y);
  }

  public void Click_DownloadMods2()
  {
    try
    {
      Application.OpenURL("https://discord.gg/S7hcQvYzmJ");
    }
    catch
    {
    }
  }

  public void Click_OpenModsFolder()
  {
    Application.OpenURL("file://" + Main.AssetsFolder + "/Mods/");
  }

  public void Click_DownloadMods()
  {
    if (this.ModsDownloaded)
      return;
    Main.Instance.FreeWorldPatch = true;
    this.ModsDownloaded = true;
    this.ModsRoot.SetActive(true);
    for (int index = 0; index < this.ModsProgress.Length; ++index)
      this.ModsProgress[index].gameObject.SetActive(true);
    Main.Instance.MainThreads.Add(new Action(this.DownloadSliderMove));
  }

  public void DownloadSliderMove()
  {
    for (int index = 0; index < this.ModsProgress.Length; ++index)
      this.ModsProgress[index].value += Time.deltaTime / (float) (index + 1);
    if ((double) this.ModsProgress[this.ModsProgress.Length - 1].value < 1.0)
      return;
    Main.Instance.MainThreads.Remove(new Action(this.DownloadSliderMove));
    for (int index = 0; index < this.ModsProgress.Length; ++index)
      this.ModsProgress[index].gameObject.SetActive(false);
  }

  public void Click_FetishChasity() => Main.Instance.FetishChas = this.ToggleChasFetish.isOn;

  public void OnBellyBulgeDrop()
  {
    switch (this.BellyBulgeDrop.value)
    {
      case 0:
        UI_Settings.BellyBulgeValue = 0;
        break;
      case 1:
        UI_Settings.BellyBulgeValue = 1;
        break;
      case 2:
        UI_Settings.BellyBulgeValue = 2;
        break;
    }
  }

  public void Click_Speedrun()
  {
    this.CloseAllMenus();
    this.SpeedrunMenu.SetActive(true);
    if (PlayerPrefs.HasKey("Speedrun_1"))
      this.SpeedrunTimeLabels[0].text = PlayerPrefs.GetString("Speedrun_1");
    if (PlayerPrefs.HasKey("Speedrun_2"))
      this.SpeedrunTimeLabels[1].text = PlayerPrefs.GetString("Speedrun_2");
    if (!PlayerPrefs.HasKey("Speedrun_3"))
      return;
    this.SpeedrunTimeLabels[2].text = PlayerPrefs.GetString("Speedrun_3");
  }

  public void Click_SpeedHard()
  {
    UI_Settings._SpeedrunValue = 1;
    if (Main.Instance.GameplayMenu.GameplayStarted)
      Main.Instance.GameplayMenu.Click_ExitToMainMenu_Yes();
    else
      Main.Instance.NewGameMenu.Click_Hard();
  }

  public void Click_SpeedMed()
  {
    UI_Settings._SpeedrunValue = 2;
    if (Main.Instance.GameplayMenu.GameplayStarted)
      Main.Instance.GameplayMenu.Click_ExitToMainMenu_Yes();
    else
      Main.Instance.NewGameMenu.Click_Medium();
  }

  public void Click_Speed1000()
  {
    UI_Settings._SpeedrunValue = 3;
    if (Main.Instance.GameplayMenu.GameplayStarted)
      Main.Instance.GameplayMenu.Click_ExitToMainMenu_Yes();
    else
      Main.Instance.NewGameMenu.Click_Medium();
  }

  public void OnDoAutosave()
  {
    this.AutosaveTimer.interactable = Main.Instance.AutosaveEnable = this.DoAutosave.isOn;
    this.SaveAllSettings();
  }

  public void OnAutosaveTimer()
  {
    switch (this.AutosaveTimer.value)
    {
      case 0:
        Main.Instance.AutoSaveTimerMax = 300f;
        break;
      case 1:
        Main.Instance.AutoSaveTimerMax = 600f;
        break;
      case 2:
        Main.Instance.AutoSaveTimerMax = 1800f;
        break;
    }
    this.SaveAllSettings();
  }

  public void OnVSyncDropChange()
  {
    QualitySettings.vSyncCount = this.VSyncDrop.value;
    this.SaveAllSettings();
  }

  public void OnDropdownInverts()
  {
    UI_Settings.Inverted_Click = this.ClickInvert.isOn;
    UI_Settings.Inverted_X_3rd = this.InvertX_3rd.value == 1;
    UI_Settings.Inverted_Y_3rd = this.InvertY_3rd.value == 1;
    UI_Settings.Inverted_X_1st = this.InvertX_1st.value == 1;
    UI_Settings.Inverted_Y_1st = this.InvertY_1st.value == 1;
    UI_Settings.Inverted_X_car = this.InvertX_Car.value == 1;
    UI_Settings.Inverted_Y_car = this.InvertY_Car.value == 1;
    UI_Settings.Inverted_X_tur = this.InvertX_Turret.value == 1;
    UI_Settings.Inverted_Y_tur = this.InvertY_Turret.value == 1;
    this.SaveAllSettings();
  }

  public static int LeftMouseButton => !UI_Settings.Inverted_Click ? 0 : 1;

  public static int RightMouseButton => !UI_Settings.Inverted_Click ? 1 : 0;
}
