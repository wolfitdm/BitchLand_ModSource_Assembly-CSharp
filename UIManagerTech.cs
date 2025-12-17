// Decompiled with JetBrains decompiler
// Type: UIManagerTech
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#nullable disable
public class UIManagerTech : MonoBehaviour
{
  [Header("What Menu Is Active?")]
  public bool simpleMenu;
  public bool advancedMenu = true;
  [Header("Simple Panels")]
  [Tooltip("The UI Panel holding the Home Screen elements")]
  public GameObject homeScreen;
  [Tooltip("The UI Panel holding the credits")]
  public GameObject creditsScreen;
  [Tooltip("The UI Panel holding the settings")]
  public GameObject systemScreen;
  [Tooltip("The UI Panel holding the CANCEL or ACCEPT Options for New Game")]
  public GameObject newGameScreen;
  [Tooltip("The UI Panel holding the YES or NO Options for Load Game")]
  public GameObject loadGameScreen;
  [Tooltip("The Loading Screen holding loading bar")]
  public GameObject loadingScreen;
  [Header("COLORS - Tint")]
  public Image[] panelGraphics;
  public Image[] blurs;
  public Color tint;
  [Header("ADVANDED - Panels")]
  [Tooltip("The UI Panel holding the New Account Screen elements")]
  public GameObject newAccountScreen;
  [Tooltip("The UI Panel holding the Delete Account Screen elements")]
  public GameObject deleteAccountScreen;
  [Tooltip("The UI Panel holding Log-In Buttons")]
  public GameObject loginScreen;
  [Tooltip("The UI Panel holding account and load menu")]
  public GameObject databaseScreen;
  [Tooltip("The UI Menu Bar at the edge of the screen")]
  public GameObject menuBar;
  [Header("ADVANDED - UI Elements & User Data")]
  [Tooltip("The Main Canvas Gameobject")]
  public CanvasScaler mainCanvas;
  [Tooltip("The dropdown menu containing all the resolutions that your game can adapt to")]
  public TMP_Dropdown ResolutionDropDown;
  private Resolution[] resolutions;
  [Tooltip("The text object in the Settings Panel displaying the current quality setting enabled")]
  public TMP_Text qualityText;
  [Tooltip("The icon showing the current quality selected in the Settings Panels")]
  public Animator qualityDisplay;
  private string[] qualityNames;
  private int tempQualityLevel;
  [Tooltip("The volume slider UI element in the Settings Screen")]
  public Slider audioSlider;
  [Tooltip("If a message is displaying indiciating FAILURE, this is the color of that error text")]
  public Color errorColor;
  [Tooltip("If a message is displaying indiciating SUCCESS, this is the color of that success text")]
  public Color successColor;
  public float messageDisplayLength = 2f;
  public Slider uiScaleSlider;
  private float xScale;
  private float yScale;
  [Header("Menu Bar")]
  public bool showMenuBar = true;
  [Tooltip("The Arrow at the corner of the screen activating and de-activating the menu bar")]
  public GameObject menuBarButton;
  [Tooltip("The date and time display text at the bottom of the screen")]
  public TMP_Text dateDisplay;
  public TMP_Text timeDisplay;
  public bool showDate = true;
  public bool showTime = true;
  [Header("Loading Screen Elements")]
  [Tooltip("The name of the scene loaded when a 'NEW GAME' is started")]
  public string newSceneName;
  [Tooltip("The loading bar Slider UI element in the Loading Screen")]
  public Slider loadingBar;
  private string loadSceneName;
  [Header("Register Account")]
  public TMP_InputField username;
  public TMP_InputField password;
  public TMP_InputField confPassword;
  public TMP_Text error_NewAccount;
  public TMP_Text messageDisplayDatabase;
  public string newAccountMessageDisplay = "ACCOUNT CREATED";
  private string Username;
  private string Password;
  private string ConfPassword;
  private string form;
  private string m_Path;
  private string[] Characters = new string[64 /*0x40*/]
  {
    "a",
    "b",
    "c",
    "d",
    "e",
    "f",
    "g",
    "h",
    "i",
    "j",
    "k",
    "l",
    "m",
    "n",
    "o",
    "p",
    "q",
    "r",
    "s",
    "t",
    "u",
    "v",
    "w",
    "x",
    "y",
    "z",
    "A",
    "B",
    "C",
    "D",
    "E",
    "F",
    "G",
    "H",
    "I",
    "J",
    "K",
    "L",
    "M",
    "N",
    "O",
    "P",
    "Q",
    "R",
    "S",
    "T",
    "U",
    "V",
    "W",
    "X",
    "Y",
    "Z",
    "1",
    "2",
    "3",
    "4",
    "5",
    "6",
    "7",
    "8",
    "9",
    "0",
    "_",
    "-"
  };
  [Header("Login Account")]
  public TMP_InputField logUsername;
  public TMP_InputField logPassword;
  private string logUsernameString;
  private string logPasswordString;
  private string[] Lines;
  private string DecryptedPass;
  public TMP_Text error_LogIn;
  public TMP_Text profileDisplay;
  public string loginMessageDisplay = "LOGGED IN";
  [Header("Delete Account")]
  public TMP_InputField delUsername;
  public TMP_InputField delPassword;
  private string delUsernameString;
  private string delPasswordString;
  private string[] delLines;
  private string delDecryptedPass;
  public TMP_Text error_Delete;
  public string deletedMessageDisplay = "ACCOUNT DELETED";
  [Header("Settings Screen")]
  public TMP_Text textSpeakers;
  public TMP_Text textSubtitleLanguage;
  public List<string> speakers = new List<string>();
  public List<string> subtitleLanguage = new List<string>();
  [Header("Starting Options Values")]
  public int speakersDefault;
  public int subtitleLanguageDefault;
  [Header("List Indexing")]
  private int speakersIndex;
  private int subtitleLanguageIndex;
  [Header("Debug")]
  [Tooltip("If this is true, pressing 'R' will reload the scene.")]
  public bool reloadSceneButton = true;
  private Transform tempParent;

  public void MoveToFront(GameObject currentObj)
  {
    this.tempParent = currentObj.transform;
    this.tempParent.SetAsLastSibling();
  }

  private void Start()
  {
    this.homeScreen.SetActive(true);
    if ((UnityEngine.Object) this.newAccountScreen != (UnityEngine.Object) null)
      this.newAccountScreen.SetActive(false);
    if ((UnityEngine.Object) this.deleteAccountScreen != (UnityEngine.Object) null)
      this.deleteAccountScreen.SetActive(false);
    if ((UnityEngine.Object) this.loginScreen != (UnityEngine.Object) null)
      this.loginScreen.SetActive(false);
    if ((UnityEngine.Object) this.databaseScreen != (UnityEngine.Object) null)
      this.databaseScreen.SetActive(false);
    if ((UnityEngine.Object) this.creditsScreen != (UnityEngine.Object) null)
      this.creditsScreen.SetActive(false);
    if ((UnityEngine.Object) this.systemScreen != (UnityEngine.Object) null)
      this.systemScreen.SetActive(false);
    if ((UnityEngine.Object) this.loadingScreen != (UnityEngine.Object) null)
      this.loadingScreen.SetActive(false);
    if ((UnityEngine.Object) this.loadGameScreen != (UnityEngine.Object) null)
      this.loadGameScreen.SetActive(false);
    if ((UnityEngine.Object) this.newGameScreen != (UnityEngine.Object) null)
      this.newGameScreen.SetActive(false);
    if (this.advancedMenu)
    {
      this.m_Path = Application.dataPath;
      this.UpdateAccountValues();
    }
    if ((UnityEngine.Object) this.menuBar != (UnityEngine.Object) null && !this.showMenuBar)
    {
      this.menuBar.gameObject.SetActive(false);
      this.menuBarButton.gameObject.SetActive(false);
    }
    for (int index = 0; index < this.panelGraphics.Length; ++index)
      this.panelGraphics[index].color = this.tint;
    for (int index = 0; index < this.blurs.Length; ++index)
      this.blurs[index].material.SetColor("_Color", this.tint);
    this.qualityNames = QualitySettings.names;
    this.resolutions = Screen.resolutions;
    if ((UnityEngine.Object) this.ResolutionDropDown != (UnityEngine.Object) null)
    {
      for (int index = 0; index < this.resolutions.Length; ++index)
      {
        this.ResolutionDropDown.options.Add(new TMP_Dropdown.OptionData(this.ResToString(this.resolutions[index])));
        this.ResolutionDropDown.value = index;
        this.ResolutionDropDown.onValueChanged.AddListener((UnityAction<int>) (_param1 => Screen.SetResolution(this.resolutions[this.ResolutionDropDown.value].width, this.resolutions[this.ResolutionDropDown.value].height, true)));
      }
    }
    if (PlayerPrefs.GetInt("firsttime") == 0)
    {
      PlayerPrefs.SetInt("firsttime", 1);
      PlayerPrefs.SetFloat("volume", 1f);
    }
    if ((UnityEngine.Object) this.audioSlider != (UnityEngine.Object) null)
      this.audioSlider.value = PlayerPrefs.GetFloat("volume");
    this.speakersIndex = this.speakersDefault;
    this.subtitleLanguageIndex = this.subtitleLanguageDefault;
    this.textSpeakers.text = this.speakers[this.speakersDefault];
    this.textSubtitleLanguage.text = this.subtitleLanguage[this.subtitleLanguageDefault];
  }

  public void IncreaseIndex(int i)
  {
    switch (i)
    {
      case 0:
        if (this.speakersIndex != this.speakers.Count - 1)
          ++this.speakersIndex;
        else
          this.speakersIndex = 0;
        this.textSpeakers.text = this.speakers[this.speakersIndex];
        break;
      case 1:
        if (this.subtitleLanguageIndex != this.subtitleLanguage.Count - 1)
          ++this.subtitleLanguageIndex;
        else
          this.subtitleLanguageIndex = 0;
        this.textSubtitleLanguage.text = this.subtitleLanguage[this.subtitleLanguageIndex];
        break;
    }
  }

  public void DecreaseIndex(int i)
  {
    switch (i)
    {
      case 0:
        if (this.speakersIndex == 0)
          this.speakersIndex = this.speakers.Count;
        --this.speakersIndex;
        this.textSpeakers.text = this.speakers[this.speakersIndex];
        break;
      case 1:
        if (this.subtitleLanguageIndex == 0)
          this.subtitleLanguageIndex = this.subtitleLanguage.Count;
        --this.subtitleLanguageIndex;
        this.textSubtitleLanguage.text = this.subtitleLanguage[this.subtitleLanguageIndex];
        break;
    }
  }

  public void SetTint()
  {
    for (int index = 0; index < this.panelGraphics.Length; ++index)
      this.panelGraphics[index].color = this.tint;
    for (int index = 0; index < this.blurs.Length; ++index)
      this.blurs[index].material.SetColor("_Color", this.tint);
  }

  private void Update()
  {
    if (this.reloadSceneButton && Input.GetKeyDown(KeyCode.Delete))
      SceneManager.LoadScene("Tech Demo Scene");
    this.SetTint();
    if (!this.showMenuBar)
      return;
    DateTime now = DateTime.Now;
    if (this.showTime)
    {
      TMP_Text timeDisplay = this.timeDisplay;
      string[] strArray = new string[5];
      int num = now.Hour;
      strArray[0] = num.ToString();
      strArray[1] = ":";
      num = now.Minute;
      strArray[2] = num.ToString();
      strArray[3] = ":";
      num = now.Second;
      strArray[4] = num.ToString();
      string str = string.Concat(strArray);
      timeDisplay.text = str;
    }
    else if (!this.showTime)
      this.timeDisplay.text = "";
    if (this.showDate)
    {
      this.dateDisplay.text = DateTime.Now.ToString("yyyy/MM/dd");
    }
    else
    {
      if (this.showDate)
        return;
      this.dateDisplay.text = "";
    }
  }

  public void MessageDisplayDatabase(string message, Color col)
  {
    this.StartCoroutine(this.MessageDisplay(message, col));
  }

  private IEnumerator MessageDisplay(string message, Color col)
  {
    this.messageDisplayDatabase.color = col;
    this.messageDisplayDatabase.text = message;
    yield return (object) new WaitForSeconds(this.messageDisplayLength);
    this.messageDisplayDatabase.text = "";
  }

  public void UIScaler()
  {
    this.xScale = 1920f * this.uiScaleSlider.value;
    this.yScale = 1080f * this.uiScaleSlider.value;
    this.mainCanvas.referenceResolution = new Vector2(this.xScale, this.yScale);
  }

  public void CheckSettings()
  {
    this.tempQualityLevel = QualitySettings.GetQualityLevel();
    if (this.tempQualityLevel == 0)
    {
      this.qualityText.text = this.qualityNames[0];
      this.qualityDisplay.SetTrigger("Low");
    }
    else if (this.tempQualityLevel == 1)
    {
      this.qualityText.text = this.qualityNames[1];
      this.qualityDisplay.SetTrigger("Medium");
    }
    else if (this.tempQualityLevel == 2)
    {
      this.qualityText.text = this.qualityNames[2];
      this.qualityDisplay.SetTrigger("High");
    }
    else
    {
      if (this.tempQualityLevel != 3)
        return;
      this.qualityText.text = this.qualityNames[3];
      this.qualityDisplay.SetTrigger("Ultra");
    }
  }

  private string ResToString(Resolution res)
  {
    int num = res.width;
    string str1 = num.ToString();
    num = res.height;
    string str2 = num.ToString();
    return $"{str1} x {str2}";
  }

  public void AudioSlider()
  {
    AudioListener.volume = this.audioSlider.value;
    PlayerPrefs.SetFloat("volume", this.audioSlider.value);
  }

  public void Quit() => Application.Quit();

  public void QualityChange(int x)
  {
    if (x == 0)
    {
      QualitySettings.SetQualityLevel(x, true);
      this.qualityText.text = this.qualityNames[0];
    }
    else if (x == 1)
    {
      QualitySettings.SetQualityLevel(x, true);
      this.qualityText.text = this.qualityNames[1];
    }
    else if (x == 2)
    {
      QualitySettings.SetQualityLevel(x, true);
      this.qualityText.text = this.qualityNames[2];
    }
    if (x != 3)
      return;
    QualitySettings.SetQualityLevel(x, true);
    this.qualityText.text = this.qualityNames[3];
  }

  public void LoadNewLevel()
  {
    if (!(this.newSceneName != ""))
      return;
    this.StartCoroutine(this.LoadAsynchronously(this.newSceneName));
  }

  public void LoadSavedLevel()
  {
    if (!(this.loadSceneName != ""))
      return;
    this.StartCoroutine(this.LoadAsynchronously(this.newSceneName));
  }

  private IEnumerator LoadAsynchronously(string sceneName)
  {
    AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
    while (!operation.isDone)
    {
      this.loadingBar.value = Mathf.Clamp01(operation.progress / 0.9f);
      yield return (object) null;
    }
  }

  public void UpdateAccountValues()
  {
    this.Username = this.username.text;
    this.Password = this.password.text;
    this.ConfPassword = this.confPassword.text;
    this.logUsernameString = this.logUsername.text;
    this.logPasswordString = this.logPassword.text;
    this.delUsernameString = this.delUsername.text;
    this.delPasswordString = this.delPassword.text;
  }

  public void ConfirmNewAccount()
  {
    bool flag1 = false;
    bool flag2 = false;
    bool flag3 = false;
    if (this.Username != "")
    {
      if (!File.Exists($"{this.m_Path}_{this.Username}.txt"))
      {
        flag1 = true;
      }
      else
      {
        this.error_NewAccount.color = this.errorColor;
        this.error_NewAccount.text = "USERNAME ALREADY TAKEN";
      }
    }
    else
    {
      this.error_NewAccount.color = this.errorColor;
      this.error_NewAccount.text = "INVALID USERNAME";
    }
    if (this.Password != "")
    {
      if (this.Password.Length > 5)
      {
        flag2 = true;
      }
      else
      {
        this.error_NewAccount.color = this.errorColor;
        this.error_NewAccount.text = "PASSWORD IS TOO SHORT";
      }
    }
    else
    {
      this.error_NewAccount.color = this.errorColor;
      this.error_NewAccount.text = "INVALID PASSWORD";
    }
    if (this.ConfPassword != "")
    {
      if (this.ConfPassword == this.Password)
      {
        flag3 = true;
      }
      else
      {
        this.error_NewAccount.color = this.errorColor;
        this.error_NewAccount.text = "PASSWORDS MUST MATCH";
      }
    }
    else
    {
      this.error_NewAccount.color = this.errorColor;
      this.error_NewAccount.text = "INVALID PASSWORD";
    }
    if (!flag1 || !flag2 || !flag3)
      return;
    bool flag4 = true;
    int num1 = 1;
    foreach (int num2 in this.Password)
    {
      if (flag4)
      {
        this.Password = "";
        flag4 = false;
      }
      ++num1;
      int num3 = num1;
      this.Password += ((char) (num2 * num3)).ToString();
    }
    this.form = this.Username + Environment.NewLine + Environment.NewLine + this.Password;
    File.WriteAllText($"{this.m_Path}_{this.Username}.txt", this.form);
    this.Username = "";
    this.Password = "";
    this.username.text = "";
    this.password.text = "";
    this.confPassword.text = "";
    this.error_NewAccount.text = "";
    this.DecryptedPass = "";
    this.MessageDisplayDatabase(this.newAccountMessageDisplay, this.successColor);
    MonoBehaviour.print((object) "Registration Complete");
    this.databaseScreen.SetActive(true);
    this.newAccountScreen.SetActive(false);
  }

  public void LoginButton()
  {
    bool flag1 = false;
    bool flag2 = false;
    if (this.logUsernameString != "")
    {
      if (File.Exists($"{this.m_Path}_{this.logUsernameString}.txt"))
      {
        flag1 = true;
        this.Lines = File.ReadAllLines($"{this.m_Path}_{this.logUsernameString}.txt");
      }
      else
      {
        this.error_LogIn.color = this.errorColor;
        this.error_LogIn.text = "INVALID USERNAME";
      }
    }
    else
    {
      this.error_LogIn.color = this.errorColor;
      this.error_LogIn.text = "PLEASE ENTER USERNAME";
    }
    if (this.logPasswordString != "")
    {
      if (File.Exists($"{this.m_Path}_{this.logUsernameString}.txt"))
      {
        int num1 = 1;
        foreach (int num2 in this.Lines[2])
        {
          ++num1;
          int num3 = num1;
          this.DecryptedPass += ((char) (num2 / num3)).ToString();
        }
        if (this.logPasswordString == this.DecryptedPass)
        {
          flag2 = true;
        }
        else
        {
          this.error_LogIn.color = this.errorColor;
          this.error_LogIn.text = "PASSWORD INCORRECT";
        }
      }
      else
      {
        this.error_LogIn.color = this.errorColor;
        this.error_LogIn.text = "PASSWORD INCORRECT";
      }
    }
    else
    {
      this.error_LogIn.color = this.errorColor;
      this.error_LogIn.text = "PLEASE ENTER PASSWORD";
    }
    if (!flag1 || !flag2)
      return;
    this.profileDisplay.text = this.logUsernameString;
    this.logUsernameString = "";
    this.logPasswordString = "";
    this.logUsername.text = "";
    this.logPassword.text = "";
    this.error_LogIn.text = "";
    this.DecryptedPass = "";
    this.MessageDisplayDatabase(this.loginMessageDisplay, this.successColor);
    MonoBehaviour.print((object) "Login Successful");
    this.databaseScreen.SetActive(true);
    this.loginScreen.SetActive(false);
  }

  public void ConfirmDeleteAccount()
  {
    bool flag1 = false;
    bool flag2 = false;
    if (this.delUsernameString != "" && this.profileDisplay.text != this.delUsernameString)
    {
      if (File.Exists($"{this.m_Path}_{this.delUsernameString}.txt"))
      {
        flag1 = true;
        this.Lines = File.ReadAllLines($"{this.m_Path}_{this.delUsernameString}.txt");
      }
      else
      {
        this.error_Delete.color = this.errorColor;
        this.error_Delete.text = "INVALID USERNAME";
      }
    }
    else
    {
      this.error_Delete.color = this.errorColor;
      this.error_Delete.text = "ENTER VALID USERNAME";
    }
    if (this.delPasswordString != "")
    {
      if (File.Exists($"{this.m_Path}_{this.delUsernameString}.txt"))
      {
        int num1 = 1;
        foreach (int num2 in this.Lines[2])
        {
          ++num1;
          int num3 = num1;
          this.DecryptedPass += ((char) (num2 / num3)).ToString();
        }
        if (this.delPasswordString == this.DecryptedPass)
        {
          flag2 = true;
        }
        else
        {
          this.error_Delete.color = this.errorColor;
          this.error_Delete.text = "PASSWORD INCORRECT";
        }
      }
      else
      {
        this.error_Delete.color = this.errorColor;
        this.error_Delete.text = "PASSWORD INCORRECT";
      }
    }
    else
    {
      this.error_Delete.color = this.errorColor;
      this.error_Delete.text = "PLEASE ENTER PASSWORD";
    }
    if (!flag1 || !flag2)
      return;
    File.Delete($"{this.m_Path}_{this.delUsernameString}.txt");
    this.delUsernameString = "";
    this.delPasswordString = "";
    this.delUsername.text = "";
    this.delPassword.text = "";
    this.error_Delete.text = "";
    this.DecryptedPass = "";
    this.MessageDisplayDatabase(this.deletedMessageDisplay, this.successColor);
    MonoBehaviour.print((object) "Deletion Successful");
    this.deleteAccountScreen.SetActive(false);
    this.databaseScreen.SetActive(true);
  }
}
