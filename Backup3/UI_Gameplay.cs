// Decompiled with JetBrains decompiler
// Type: UI_Gameplay
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#nullable disable
public class UI_Gameplay : UI_Menu
{
  public bool GameplayStarted;
  public GameObject[] DisableOnOpen;
  public Text HealthText;
  public Image HealthSlider;
  public Image ArousalSlider;
  public Image ArousalHeartSlider;
  public Text FoodText;
  public Image FoodSlider;
  public Text EnergyText;
  public Image EnergySlider;
  public Text ScatText;
  public Image ScatSlider;
  public Text NewQuest;
  public Text NewQuestTitle;
  public Text[] NewGoals;
  public Text[] NewGoalsQuantities;
  public GameObject[] LevelUpUIs;
  public Image[] LevelUpUIs_Image;
  public Text[] LevelUpUIs_Text;
  public GameObject[] LevelUpUIs_LevelUp;
  public Sprite[] LevelUpSprites;
  public GameObject AmmoUI;
  public Text AmmoText;
  public Image AmmoSlider;
  public GameObject WarningIcon;
  public GameObject HomeIcon;
  public GameObject WeaponReloadUI;
  public Image WeaponReloadSlider;
  public Text WeaponReloadText;
  public ScreenFader TheScreenFader;
  public GameObject QLeave;
  public GameObject Crossair;
  public Text PickupText;
  public Image PromptIcon;
  [Header("   Chat")]
  public Color ChatUnselectedColor;
  public Color ChatSelectedColor;
  public GameObject[] ChatOptions;
  public Text[] ChatOptions_text;
  public Image[] ChatOptions_img;
  public int SavedSelectedOption;
  public int SelectedOption;
  public int OptionsCount;
  public Action[] ChatOptions_code;
  public GameObject Subtitle;
  public Text SubtitleText;
  public Person PersonChattingTo;
  public GameObject MultiOptions;
  public GameObject[] ItemOptions;
  public Text[] ItemOptions_text;
  public GameObject NewMultiOption;
  public Text NewMultiOption_text;
  public WeaponSystem PlayerWeaponSystem;
  public Color AvailablePerk;
  public GameObject EscMenu;
  public GameObject CantSaveMsg;
  public GameObject CantSaveMsg2;
  public Button SaveButton;
  public GameObject TextInputMenu;
  public Text TextInputMenu_title;
  public InputField TextInputMenu_input;
  public MonoBehaviour TextInputMenu_script;
  public string TextInputMenu_function;
  private bool _Increasing;
  public bool InSubtitle;
  public bool SoundedVoiceLine;
  public Mission CurrentMission;
  public List<Mission> CurrentMissions;
  public float MissionUITimer;
  public float[] GoalUITimers;
  public bool[] GoalUIPerm;
  private bool _atleastone;
  private float[] _LevelUpTimers;
  public bool ChangedExpression;
  public float SubTitleTimer;
  public Action AfterSubtitle;
  public bool _StartCallingAfterSubtitle;
  public GameObject MessageBox;
  public Text MessageBox_text;
  [Header("Journal")]
  public GameObject JournalMenu;
  public GameObject[] JournalBGImages;
  public GameObject JournalOptionsList;
  public AudioClip JournalSound1;
  public AudioClip JournalPerkSound;
  public GameObject Journal_Inventory;
  public GameObject Journal_Acheivements;
  public GameObject Journal_missions;
  public GameObject Journal_Levelup;
  public GameObject Journal_HowTo;
  public GameObject Journal_Gallery;
  public GameObject Journal_Relationships;
  public GameObject Journal_Crafting;
  public GameObject Journal_Map;
  public GameObject Journal_Building;
  public GameObject Journal_Population;
  public GameObject Journal_WorldMap;
  public GameObject Journal_ArmyManagement;
  public GameObject Journal_WorkerManagement;
  public GameObject Journal_CivilianManagement;
  public GameObject Journal_RoyalManagement;
  public RectTransform AcheivementsContent;
  public GameObject AcheivementEntry;
  public List<GameObject> AcheivementEntries = new List<GameObject>();
  public RectTransform InvContent;
  public GameObject InvEntry;
  public List<GameObject> InvEntries = new List<GameObject>();
  public GameObject Inv_female;
  public GameObject Inv_male;
  public RectTransform StatesContent;
  public GameObject StatesEntry;
  public List<GameObject> StatesEntries = new List<GameObject>();
  public RectTransform MissionsContent;
  public GameObject MissionsEntry;
  public List<GameObject> MissionsEntries = new List<GameObject>();
  public RectTransform GoalsContent;
  public GameObject GoalsEntry;
  public List<GameObject> GoalsEntries = new List<GameObject>();
  public GameObject[] LevelUpContents;
  public GameObject ScatPerks;
  public Sprite UnselectedButton;
  public Sprite SelectedButton;
  public Image[] MenuButtons;
  public Image[] LvlUPButtons;
  public Image[] LvlUPAmounts;
  public Text[] LvlUPLevels;
  public GameObject PerkDesc;
  public Text PerkDescText;
  public MouseRotator[] MouseRotate;
  public Button[] SexButtons;
  [Header("   Gallery")]
  public Mis_Acheiv_Posters Posters;
  public Sprite[] BitchNotes10;
  public Sprite[] BitchNotes20;
  public Sprite[] BitchNotes50;
  public Sprite[] BitchNotes100;
  public Sprite[] BitchNotes1000;
  public Sprite[] BitchNotesProt;
  public Sprite[] PostersBC;
  public Sprite[] PostersBCLeg;
  public Sprite[] PostersBCBEL;
  public Sprite[] PostersBCCap;
  public bool[] HasBitchNotes10;
  public bool[] HasBitchNotes20;
  public bool[] HasBitchNotes50;
  public bool[] HasBitchNotes100;
  public bool[] HasBitchNotes1000;
  public bool[] HasBitchNotesProt;
  public bool[] HasPostersBC;
  public bool[] HasPostersBCLeg;
  public bool[] HasPostersBCBEL;
  public bool[] HasPostersBCCap;
  public GameObject[] GalleryLists;
  public Image[] Gallery_10;
  public Image[] Gallery_20;
  public Image[] Gallery_50;
  public Image[] Gallery_100;
  public Image[] Gallery_1000;
  public Image[] Gallery_Prot;
  public Image[] Gallery_BC;
  public Image[] Gallery_BCLeg;
  public Image[] Gallery_BCBEL;
  public Image[] Gallery_BCCap;
  public GameObject[] Army_tabs;
  public RectTransform ArmyOrdersContent;
  public GameObject ArmyOrders_entry;
  public List<GameObject> Orders_entries = new List<GameObject>();
  public RectTransform ArmyPatrolsContent;
  public GameObject ArmyPatrols_entry;
  public List<GameObject> Patrols_entries = new List<GameObject>();
  public RectTransform ArmyTrainContent;
  public GameObject ArmyTrain_entry;
  public List<GameObject> ArmyTrain_entries = new List<GameObject>();
  public Toggle DisplayArmySpots;
  public GameObject ARMY_NoNPCS;
  public GameObject ARMY_NoTrainNPCS;
  public RectTransform Pop_content;
  public GameObject Pop_Entry;
  public List<GameObject> Pop_Entries = new List<GameObject>();
  [Header(" Trader")]
  public GameObject TraderMenu;
  public Text TraderPlayerMoney;
  public RectTransform TraderBackPackContent;
  public GameObject TraderBackPackEntry;
  public List<GameObject> TraderBackPackEntries = new List<GameObject>();
  public RectTransform TraderContainterContent;
  public GameObject TraderContainterEntry;
  public List<GameObject> TraderContainterEntries = new List<GameObject>();
  [Header(" Storage")]
  public GameObject ContainerStorage;
  public Int_Storage CurrentOpenStorage;
  public RectTransform BackPackContent;
  public GameObject BackPackEntry;
  public List<GameObject> BackPackEntries = new List<GameObject>();
  public RectTransform ContainterContent;
  public GameObject ContainterEntry;
  public List<GameObject> ContainterEntries = new List<GameObject>();
  public Text BackPackAmount;
  public Text ContainerAmount;
  public Text TraderBackPackAmount;
  public List<Action> OnCloseContainer = new List<Action>();
  public GameObject AddMoneyBtn;
  public GameObject AddMoneyMenu;
  public Slider AddMoneySlider;
  public Text AddMoneySliderText;
  public Text AddMoneyCurrentText;
  public bool ShownHunger;
  public bool ShownToilet;
  public bool ShownSleep;
  public Text NotificationText;
  public GameObject NotificationPanel;
  public float NotifFadeDuration = 1f;
  public CanvasGroup NotifCanvasGroup;
  public List<string> notifications = new List<string>();
  public int currentNotificationIndex = -1;
  private Coroutine currentCoroutine;
  public Text BitchNotesText;
  public GameObject UnsavedWarning;
  public List<Person> Relationships = new List<Person>();
  public GameObject NoRels;
  public RectTransform RelsContent;
  public GameObject RelsEntry;
  public List<GameObject> RelsEntries = new List<GameObject>();
  public Image PersonPfp;
  public Text PersonDesc;
  public Image NegativeSlider;
  public Image PositiveSlider;
  public GameObject ShortDesc;
  public Text ShortPersonDesc;
  public Image ShortNegativeSlider;
  public Image ShortPositiveSlider;
  public int _SelectedRelsPerson;
  public GameObject MeleeOptionsUI;
  public Text MeleeOptionText;
  public Image MeleeOptionSlider;
  public GameObject OpenWorldUI;
  public List<GameObject> DisableOnOpenWorld = new List<GameObject>();
  public bl_WorldGenerate WorldGenerate;
  public bl_SectionGenerate2 WorldGenerate2;
  public static bool OWGenerating;
  public bool _isLoadingASection;
  public int _SetionLoading;
  public GameObject SleepMenu;
  public Button[] SleepButtons;
  [Header("Notes")]
  public GameObject NoteReader;
  public Text NoteText;
  public RectTransform NoteContent;
  public RectTransform PlayerPosMap;
  public RectTransform MapImage;
  public Transform WorldX;
  public Transform WorldY;
  public RectTransform MainMis_Green_PosMap;
  public RectTransform MainMis_Red_PosMap;
  public RectTransform MainMis_Blue_PosMap;
  public RectTransform SecondMis_White_PosMap;
  public Transform[] MapTrackers;
  public RectTransform CraftList;
  public GameObject CraftRecipeEntry;
  public List<GameObject> SpawnedCraftRecipes = new List<GameObject>();
  public int SelectedRecipe;
  public int SelectedRecipeType;
  public Image[] RecipeTypesImg;
  public Text NeededResearch;
  public Text NeededResearch2;
  public Text SelectedReceiptMainTitle;
  public Text SelectedReceiptOutcomeType;
  public Text NeedsBackpackLabel;
  public Button CraftButton;
  public RectTransform CraftIngredientList;
  public GameObject CraftIngredientEntry;
  public List<GameObject> SpawnedCraftRecipeEntries;
  public RectTransform CraftItemsList;
  public GameObject CraftItemEntry;
  public List<GameObject> SpawnedCraftItemEntries;
  public bl_CraftRecipes TheSelectedReceipt;
  public List<GameObject> PlayerItems = new List<GameObject>();
  public List<GameObject> SelectedItems = new List<GameObject>();
  public GameObject MissingItems;
  public GameObject Toomanyitmes;
  public GameObject[] DisableWhenMissionsSklipped;
  public bool _ShowSkipMenu;
  public GameObject SkipToLatestMissions_Check;
  public GameObject SkipToLatestMissions2_Check;
  public GameObject[] MissionsOf;
  public List<misc_misentry> MissEntries = new List<misc_misentry>();
  public RectTransform Build_CraftList;
  public GameObject Build_CraftRecipeEntry;
  public List<GameObject> Build_SpawnedCraftRecipes = new List<GameObject>();
  public int Build_SelectedRecipe;
  public int Build_SelectedRecipeType;
  public Image[] Build_RecipeTypesImg;
  public Text Build_NeededResearch;
  public Text Build_NeededResearch2;
  public Text Build_SelectedReceiptMainTitle;
  public Text Build_SelectedReceiptOutcomeType;
  public Text Build_NeedsBackpackLabel;
  public Button Build_CraftButton;
  public RectTransform Build_CraftIngredientList;
  public GameObject Build_CraftIngredientEntry;
  public List<GameObject> Build_SpawnedCraftRecipeEntries;
  public bl_CraftRecipes Build_TheSelectedReceipt;
  public GameObject _BuildindPlan;
  public int_ConstructionPlan ThisPlan;
  public int_ConstructionPlan.e_BuildSnapType CurrentSnapType;
  public LayerMask PlacePlanLayers;
  public GameObject LatestPlacedPlan;
  public bool _CanBuild = true;
  public bool IsSnapping;
  public bl_ConstructionSnapSpot _CurrentSnap;
  public int SelectedPlanRotation;
  public GameObject CancelPlanButton;
  public float SpeedrunTimer;
  public Text SpeedrunLabel;
  public GameObject MissingModsNotif;
  public CanvasGroup MissingModsNotif_cg;

  public UI_Gameplay() => this.MenuName = "Gameplay";

  public void Start()
  {
    this._LevelUpTimers = new float[this.LevelUpUIs.Length];
    this.ClearLevelUpsUI();
    this.ChatOptions_code = new Action[this.ChatOptions.Length];
    this.Subtitle.SetActive(false);
    for (int index = 0; index < this.DisableOnOpen.Length; ++index)
    {
      if ((UnityEngine.Object) this.DisableOnOpen[index] != (UnityEngine.Object) null)
        this.DisableOnOpen[index].SetActive(false);
    }
  }

  public override void Open()
  {
    this.GameplayStarted = true;
    FirstPersonCharacter.AllowMouseCursor = false;
    base.Open();
    this.UpdateHealth();
    this.UpdateArousal();
    this.UpdateAmmo();
    this.RemoveAllChatOptions();
    this.CloseJournal();
    this.CloseStorage();
    this.NotificationPanel.SetActive(false);
    this.CloseEscMenu();
    this.HideNote();
    this.EmptyNotifs();
    this.TextInputMenu.SetActive(false);
    Main.Instance.Player.UserControl.FirstPerson = Main.Instance.Player.UserControl.FirstPerson;
  }

  public void UpdateHealth()
  {
    this.HealthText.text = Main.Instance.Player.TheHealth.currentHealth.ToString("0");
    this.HealthSlider.fillAmount = Main.Instance.Player.TheHealth.currentHealth / Main.Instance.Player.TheHealth.maxHealth;
  }

  public void UpdateNeeds()
  {
    this.FoodText.text = Main.Instance.Player.Hunger.ToString("0");
    this.FoodSlider.fillAmount = Main.Instance.Player.Hunger / Main.Instance.Player.HungerMax;
    this.EnergyText.text = Main.Instance.Player.Energy.ToString("0");
    this.EnergySlider.fillAmount = Main.Instance.Player.Energy / Main.Instance.Player.EnergyMax;
    this.ScatText.text = Main.Instance.Player.Toilet.ToString("0");
    this.ScatSlider.fillAmount = Main.Instance.Player.Toilet / Main.Instance.Player.ToiletMax;
  }

  public void UpdateArousal()
  {
    this.ArousalHeartSlider.fillAmount = this.ArousalSlider.fillAmount = Main.Instance.Player.Arousal;
    if ((double) this.ArousalHeartSlider.fillAmount > 0.75)
      return;
    this.ArousalHeartSlider.transform.localScale = new Vector3(0.467f, 0.467f, 0.467f);
  }

  public void UpdateAmmo()
  {
    if ((UnityEngine.Object) Main.Instance.Player.WeaponInv.CurrentWeapon == (UnityEngine.Object) null || Main.Instance.Player.WeaponInv.CurrentWeapon.type == WeaponType.Melee)
    {
      this.AmmoUI.SetActive(false);
    }
    else
    {
      this.AmmoUI.SetActive(true);
      this.AmmoText.text = Main.Instance.Player.WeaponInv.CurrentWeapon.currentAmmo.ToString() + "/" + Main.Instance.Player.WeaponInv.CurrentWeapon.ammoCapacity.ToString();
      this.AmmoSlider.fillAmount = (float) Main.Instance.Player.WeaponInv.CurrentWeapon.currentAmmo / (float) Main.Instance.Player.WeaponInv.CurrentWeapon.ammoCapacity;
    }
  }

  public void ShowTextInput(string text, MonoBehaviour script, string function)
  {
    Main.Instance.Player.AddMoveBlocker("texting");
    this.TextInputMenu_script = script;
    this.TextInputMenu_function = function;
    this.TextInputMenu.SetActive(true);
    Main.Instance.GameplayMenu.AllowCursor();
    this.TextInputMenu_input.text = string.Empty;
    this.TextInputMenu_title.text = "Enter " + text;
  }

  public void Click_TextInputMenu_done()
  {
    Main.Instance.Player.RemoveMoveBlocker("texting");
    this.TextInputMenu.SetActive(false);
    Main.Instance.GameplayMenu.DisallowCursor();
    if (!((UnityEngine.Object) this.TextInputMenu_script != (UnityEngine.Object) null))
      return;
    this.TextInputMenu_script.Invoke(this.TextInputMenu_function, 0.0f);
  }

  public void AllowCursor()
  {
    FirstPersonCharacter.AllowMouseCursor = true;
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
  }

  public void DisallowCursor()
  {
    FirstPersonCharacter.AllowMouseCursor = false;
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
  }

  public void OpenEscMenu()
  {
    Main.Instance.GarbageCollect();
    this.AllowCursor();
    Time.timeScale = 0.0f;
    this.EscMenu.SetActive(true);
    if (!Main.Instance.Player.CanMove)
    {
      Main.Instance.CanSaveFlags.Add("CantMoveNow");
      Main.Instance.CanSaveFlags = Main.Instance.CanSaveFlags;
    }
    Main.Instance.Player.AddMoveBlocker("MainMenu");
  }

  public void CloseEscMenu()
  {
    this.DisallowCursor();
    Time.timeScale = 1f;
    this.EscMenu.SetActive(false);
    Main.Instance.Player.RemoveMoveBlocker("MainMenu");
    Main.Instance.CanSaveFlags.Remove("CantMoveNow");
    Main.Instance.CanSaveFlags = Main.Instance.CanSaveFlags;
  }

  public void Update()
  {
    if (this.InSubtitle)
    {
      if (this.SoundedVoiceLine)
        this.InChatWaitVoiceLine_Thread();
      else
        this.InChatWaitTimer_Thread();
    }
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      if (this.EscMenu.activeSelf)
        this.CloseEscMenu();
      else
        this.OpenEscMenu();
    }
    this.UpdateArousal();
    if ((double) this.ArousalHeartSlider.fillAmount > 0.75)
    {
      if (this._Increasing)
      {
        this.ArousalHeartSlider.transform.localScale += new Vector3(0.01f * Time.deltaTime, 0.01f * Time.deltaTime, 0.0f);
        if ((double) this.ArousalHeartSlider.transform.localScale.x > 0.5)
          this._Increasing = false;
      }
      else
      {
        this.ArousalHeartSlider.transform.localScale -= new Vector3(1f / 1000f * Time.deltaTime, 1f / 1000f * Time.deltaTime, 0.0f);
        if ((double) this.ArousalHeartSlider.transform.localScale.x < 0.40099999308586121)
          this._Increasing = true;
      }
    }
    if (this.JournalMenu.activeSelf && this.Journal_Inventory.activeSelf)
      this.UpdateNeeds();
    if (!this.MissingModsNotif.activeInHierarchy)
      return;
    this.MissingModsNotif_cg.alpha -= Time.deltaTime * 0.05f;
    if ((double) this.MissingModsNotif_cg.alpha > 0.0)
      return;
    this.MissingModsNotif.SetActive(false);
    this.MissingModsNotif_cg.alpha = 1f;
  }

  public void StartMission(Mission mission)
  {
    this.CurrentMission = mission;
    this.CurrentMissions.Add(mission);
    this.NewQuest.gameObject.SetActive(true);
    this.NewQuestTitle.gameObject.SetActive(true);
    this.NewQuest.color = new Color(this.NewQuest.color.r, this.NewQuest.color.g, this.NewQuest.color.b, 0.0f);
    this.NewQuestTitle.color = new Color(this.NewQuestTitle.color.r, this.NewQuestTitle.color.g, this.NewQuestTitle.color.b, 0.0f);
    this.NewQuest.text = "New Mission:";
    this.NewQuestTitle.text = mission.Title;
    mission.InitMission();
    this.MissionUITimer = 0.0f;
    Main.Instance.MainThreads.Add(new Action(this.DisplayingMission));
  }

  public void CompleteMission(Mission mission)
  {
    this.NewQuest.gameObject.SetActive(true);
    this.NewQuestTitle.gameObject.SetActive(true);
    this.NewQuest.color = new Color(this.NewQuest.color.r, this.NewQuest.color.g, this.NewQuest.color.b, 0.0f);
    this.NewQuestTitle.color = new Color(this.NewQuestTitle.color.r, this.NewQuestTitle.color.g, this.NewQuestTitle.color.b, 0.0f);
    this.NewQuest.text = "Mission Completed:";
    this.NewQuestTitle.text = mission.Title;
    mission.CompletedMission = true;
    this.MissionUITimer = 0.0f;
    Main.Instance.MainThreads.Add(new Action(this.DisplayingMission));
  }

  public void FailMission(Mission mission)
  {
    this.NewQuest.gameObject.SetActive(true);
    this.NewQuestTitle.gameObject.SetActive(true);
    this.NewQuest.color = new Color(this.NewQuest.color.r, this.NewQuest.color.g, this.NewQuest.color.b, 0.0f);
    this.NewQuestTitle.color = new Color(this.NewQuestTitle.color.r, this.NewQuestTitle.color.g, this.NewQuestTitle.color.b, 0.0f);
    this.NewQuest.text = "Mission Failed:";
    this.NewQuestTitle.text = mission.Title;
    mission.CompletedMission = true;
    this.MissionUITimer = 0.0f;
    Main.Instance.MainThreads.Add(new Action(this.DisplayingMission));
  }

  public void DisplayGoal(MissionGoal goal, bool showPermanent = false)
  {
    int index;
    for (index = 0; index < this.NewGoals.Length; ++index)
    {
      if (this.NewGoals[index].text == goal.Title)
        goto label_8;
    }
    index = 0;
    while (this.NewGoals[index].gameObject.activeSelf)
    {
      ++index;
      if (index == this.NewGoals.Length)
      {
        index = 0;
        break;
      }
    }
label_8:
    this.NewGoals[index].gameObject.SetActive(true);
    this.NewGoals[index].color = new Color(this.NewGoals[index].color.r, this.NewGoals[index].color.g, this.NewGoals[index].color.b, 0.0f);
    this.NewGoals[index].text = goal.Title;
    Transform[] transformArray = new Transform[2]
    {
      this.NewGoals[index].transform.Find("C"),
      this.NewGoals[index].transform.Find("F")
    };
    transformArray[0].gameObject.SetActive(goal.Completed);
    transformArray[1].gameObject.SetActive(goal.Failed);
    this.GoalUIPerm[index] = showPermanent;
    this.GoalUITimers[index] = 0.0f;
    Main.Instance.MainThreads.Add(new Action(this.DisplayingGoal));
  }

  public void DisplayGoalSimple(string goal, bool completed)
  {
    this.NewGoals[6].gameObject.SetActive(true);
    this.NewGoals[6].color = new Color(this.NewGoals[6].color.r, this.NewGoals[6].color.g, this.NewGoals[6].color.b, 0.0f);
    this.NewGoals[6].text = goal;
    Transform[] transformArray = new Transform[2]
    {
      this.NewGoals[6].transform.Find("C"),
      this.NewGoals[6].transform.Find("F")
    };
    transformArray[0].gameObject.SetActive(completed);
    transformArray[1].gameObject.SetActive(false);
    this.GoalUIPerm[6] = false;
    this.GoalUITimers[6] = 0.0f;
    Main.Instance.MainThreads.Add(new Action(this.DisplayingGoal));
  }

  public void DisplayingMission()
  {
    this.MissionUITimer += Time.deltaTime;
    if ((double) this.MissionUITimer < 3.0)
    {
      Text newQuest = this.NewQuest;
      newQuest.color = newQuest.color + new Color(0.0f, 0.0f, 0.0f, Time.deltaTime / 3f);
      Text newQuestTitle = this.NewQuestTitle;
      newQuestTitle.color = newQuestTitle.color + new Color(0.0f, 0.0f, 0.0f, Time.deltaTime / 3f);
    }
    if ((double) this.MissionUITimer > 5.0)
    {
      Text newQuest = this.NewQuest;
      newQuest.color = newQuest.color - new Color(0.0f, 0.0f, 0.0f, Time.deltaTime / 3f);
      Text newQuestTitle = this.NewQuestTitle;
      newQuestTitle.color = newQuestTitle.color - new Color(0.0f, 0.0f, 0.0f, Time.deltaTime / 3f);
    }
    if ((double) this.MissionUITimer <= 8.0)
      return;
    this.NewQuest.gameObject.SetActive(false);
    this.NewQuestTitle.gameObject.SetActive(false);
    Main.Instance.MainThreads.Remove(new Action(this.DisplayingMission));
  }

  public void DisplayingGoal()
  {
    this._atleastone = false;
    for (int index = 0; index < this.GoalUITimers.Length; ++index)
    {
      if (this.NewGoals[index].gameObject.activeSelf)
      {
        this._atleastone = true;
        this.GoalUITimers[index] += Time.deltaTime;
        if ((double) this.GoalUITimers[index] < 3.0)
        {
          Text newGoal = this.NewGoals[index];
          newGoal.color = newGoal.color + new Color(0.0f, 0.0f, 0.0f, Time.deltaTime / 3f);
        }
        if ((double) this.GoalUITimers[index] > 10.0 && !this.GoalUIPerm[index])
        {
          Text newGoal = this.NewGoals[index];
          newGoal.color = newGoal.color - new Color(0.0f, 0.0f, 0.0f, Time.deltaTime / 3f);
        }
        if ((double) this.GoalUITimers[index] > 13.0 && !this.GoalUIPerm[index])
          this.NewGoals[index].gameObject.SetActive(false);
      }
    }
    if (this._atleastone)
      return;
    Main.Instance.MainThreads.Remove(new Action(this.DisplayingGoal));
  }

  public void ClearLevelUpsUI()
  {
    for (int index = 0; index < this.LevelUpUIs.Length; ++index)
    {
      this.LevelUpUIs[index].SetActive(false);
      this.LevelUpUIs_LevelUp[index].SetActive(false);
    }
  }

  public void AddSexXp(int totalAmount, bool levelup)
  {
    int index = 0;
    while (this.LevelUpUIs[index].activeSelf)
    {
      ++index;
      if (index == this.LevelUpUIs.Length)
      {
        index = 0;
        break;
      }
    }
    this.LevelUpUIs[index].SetActive(true);
    this.LevelUpUIs_Image[index].sprite = this.LevelUpSprites[0];
    this.LevelUpUIs_Text[index].text = "+" + totalAmount.ToString() + "xp";
    this.LevelUpUIs_Image[index].fillAmount = (float) Main.Instance.Player.SexXpThisLvl / (float) Main.Instance.Player.SexXpThisLvlMax;
    this.LevelUpUIs_LevelUp[index].SetActive(levelup);
    switch (index)
    {
      case 0:
        this._LevelUpTimers[0] = 0.0f;
        Main.Instance.MainThreads.Add(new Action(this.LevelUpTimerSlot0));
        break;
      case 1:
        this._LevelUpTimers[1] = 0.0f;
        Main.Instance.MainThreads.Add(new Action(this.LevelUpTimerSlot1));
        break;
      case 2:
        this._LevelUpTimers[2] = 0.0f;
        Main.Instance.MainThreads.Add(new Action(this.LevelUpTimerSlot2));
        break;
    }
  }

  public void AddWorkerXp(int totalAmount, bool levelup)
  {
    int index = 0;
    while (this.LevelUpUIs[index].activeSelf)
    {
      ++index;
      if (index == this.LevelUpUIs.Length)
      {
        index = 0;
        break;
      }
    }
    this.LevelUpUIs[index].SetActive(true);
    this.LevelUpUIs_Image[index].sprite = this.LevelUpSprites[1];
    this.LevelUpUIs_Text[index].text = "+" + totalAmount.ToString() + "xp";
    this.LevelUpUIs_Image[index].fillAmount = (float) Main.Instance.Player.WorkXpThisLvl / (float) Main.Instance.Player.WorkXpThisLvlMax;
    this.LevelUpUIs_LevelUp[index].SetActive(levelup);
    switch (index)
    {
      case 0:
        this._LevelUpTimers[0] = 0.0f;
        Main.Instance.MainThreads.Add(new Action(this.LevelUpTimerSlot0));
        break;
      case 1:
        this._LevelUpTimers[1] = 0.0f;
        Main.Instance.MainThreads.Add(new Action(this.LevelUpTimerSlot1));
        break;
      case 2:
        this._LevelUpTimers[2] = 0.0f;
        Main.Instance.MainThreads.Add(new Action(this.LevelUpTimerSlot2));
        break;
    }
  }

  public void AddArmyXp(int totalAmount, bool levelup)
  {
    int index = 0;
    while (this.LevelUpUIs[index].activeSelf)
    {
      ++index;
      if (index == this.LevelUpUIs.Length)
      {
        index = 0;
        break;
      }
    }
    this.LevelUpUIs[index].SetActive(true);
    this.LevelUpUIs_Image[index].sprite = this.LevelUpSprites[2];
    this.LevelUpUIs_Text[index].text = "+" + totalAmount.ToString() + "xp";
    this.LevelUpUIs_Image[index].fillAmount = (float) Main.Instance.Player.ArmyXpThisLvl / (float) Main.Instance.Player.ArmyXpThisLvlMax;
    this.LevelUpUIs_LevelUp[index].SetActive(levelup);
    switch (index)
    {
      case 0:
        this._LevelUpTimers[0] = 0.0f;
        Main.Instance.MainThreads.Add(new Action(this.LevelUpTimerSlot0));
        break;
      case 1:
        this._LevelUpTimers[1] = 0.0f;
        Main.Instance.MainThreads.Add(new Action(this.LevelUpTimerSlot1));
        break;
      case 2:
        this._LevelUpTimers[2] = 0.0f;
        Main.Instance.MainThreads.Add(new Action(this.LevelUpTimerSlot2));
        break;
    }
  }

  public void LevelUpTimerSlot0()
  {
    this._LevelUpTimers[0] += Time.deltaTime;
    if ((double) this._LevelUpTimers[0] <= 5.0)
      return;
    this.LevelUpUIs[0].SetActive(false);
    Main.Instance.MainThreads.Remove(new Action(this.LevelUpTimerSlot0));
  }

  public void LevelUpTimerSlot1()
  {
    this._LevelUpTimers[1] += Time.deltaTime;
    if ((double) this._LevelUpTimers[1] <= 5.0)
      return;
    this.LevelUpUIs[1].SetActive(false);
    Main.Instance.MainThreads.Remove(new Action(this.LevelUpTimerSlot1));
  }

  public void LevelUpTimerSlot2()
  {
    this._LevelUpTimers[2] += Time.deltaTime;
    if ((double) this._LevelUpTimers[2] <= 5.0)
      return;
    this.LevelUpUIs[2].SetActive(false);
    Main.Instance.MainThreads.Remove(new Action(this.LevelUpTimerSlot2));
  }

  public void EnterChatWith(Person person, MonoBehaviour scriptWithChat, string chatStartFunction)
  {
    this.EndSubtitle();
    this.PersonChattingTo = person;
    if ((UnityEngine.Object) scriptWithChat != (UnityEngine.Object) null)
      scriptWithChat.Invoke(chatStartFunction, 0.0f);
    person.AddMoveBlocker("Chat");
    Main.Instance.Player.AddMoveBlocker("Chat");
    Main.RunInNextFrame((Action) (() => Main.Instance.Player.UpdateAnim()));
    if (!person.Interacting && !person.LookAtPlayer.canSeePlayer)
    {
      person.transform.LookAt(Main.Instance.Player.transform);
      person.transform.localEulerAngles = new Vector3(0.0f, person.transform.localEulerAngles.y, 0.0f);
    }
    Main.Instance.Player.WeaponInv.enabled = false;
    Main.Instance.GameplayMenu.SleepMenu.SetActive(false);
  }

  public void EndChat()
  {
    this.Subtitle.SetActive(false);
    if ((UnityEngine.Object) this.PersonChattingTo != (UnityEngine.Object) null)
    {
      this.PersonChattingTo.RemoveMoveBlocker("Chat");
      this.PersonChattingTo.ThisPersonInt.RestrainedCheck();
      this.PersonChattingTo = (Person) null;
    }
    Main.Instance.Player.RemoveMoveBlocker("Chat");
    Main.Instance.Player.WeaponInv.enabled = true;
    Main.Instance.GameplayMenu.ShortDesc.SetActive(false);
    this.AfterSubtitle = (Action) null;
  }

  public void EnableMove()
  {
    if ((UnityEngine.Object) this.PersonChattingTo != (UnityEngine.Object) null)
    {
      this.PersonChattingTo.RemoveMoveBlocker("Chat");
      this.PersonChattingTo.ThisPersonInt.StopInteracting();
    }
    Main.Instance.Player.Interacting = false;
    Main.Instance.Player.RemoveMoveBlocker("Chat");
    Main.Instance.Player.WeaponInv.enabled = true;
    Main.Instance.GameplayMenu.ShortDesc.SetActive(false);
  }

  public void DisplaySubtitle(
    string subText,
    AudioClip voiceLine,
    Action after = null,
    Person personSaying = null,
    e_BlendShapes expression = e_BlendShapes.Max,
    float lipsyncTime = 0.0f,
    e_BlendShapes expressionAtEnd = e_BlendShapes.Max)
  {
    this.Subtitle.SetActive(true);
    this.SubtitleText.text = subText;
    this.AfterSubtitle = after;
    if ((UnityEngine.Object) personSaying != (UnityEngine.Object) null && personSaying is Guy)
      voiceLine = (AudioClip) null;
    if ((UnityEngine.Object) voiceLine != (UnityEngine.Object) null)
    {
      if ((UnityEngine.Object) this.PersonChattingTo == (UnityEngine.Object) null || (UnityEngine.Object) personSaying != (UnityEngine.Object) null)
        this.PersonChattingTo = personSaying;
      if ((UnityEngine.Object) this.PersonChattingTo != (UnityEngine.Object) null)
      {
        this.PersonChattingTo.PersonAudio.pitch = this.PersonChattingTo.VoicePitch;
        Debug.Log((object) "Playing Voice Line");
        this.PersonChattingTo.PersonAudio.PlayOneShot(voiceLine);
      }
      else
        Main.Instance.MusicPlayer.PlayOneShot(voiceLine);
      this.InSubtitle = true;
      this.SoundedVoiceLine = true;
    }
    else
    {
      this.SubTitleTimer = 3f;
      if (subText.Length <= 20)
        this.SubTitleTimer = 2f;
      if (subText.Length >= 60)
        this.SubTitleTimer = 4f;
      this.InSubtitle = true;
      this.SoundedVoiceLine = false;
    }
    if (expression != e_BlendShapes.Max)
    {
      this.ChangedExpression = true;
      this.PersonChattingTo.ResetAllShapes();
      this.PersonChattingTo.ApplyFaceBlendShapeData(Main.Instance.BlendShapesDatas[(int) expression]);
    }
    if (!((UnityEngine.Object) this.PersonChattingTo != (UnityEngine.Object) null) || !(this.PersonChattingTo is Girl) || !((UnityEngine.Object) this.PersonChattingTo.MainBody != (UnityEngine.Object) null))
      return;
    Main.Instance.LipSync.skinnedMeshRenderer = this.PersonChattingTo.MainBody;
    Main.Instance.LipSync.InitFor(subText, (UnityEngine.Object) voiceLine == (UnityEngine.Object) null ? this.SubTitleTimer : voiceLine.length + lipsyncTime, expressionAtEnd);
  }

  public void EndSubtitle()
  {
    this.InSubtitle = false;
    this.SoundedVoiceLine = false;
    if (this.ChangedExpression)
      this.PersonChattingTo.ApplyFaceBlendShapeData(Main.Instance.BlendShapesDatas[0]);
    this.ChangedExpression = false;
    if (this.AfterSubtitle == null || this._StartCallingAfterSubtitle)
      return;
    this._StartCallingAfterSubtitle = true;
    this.AfterSubtitle();
    this._StartCallingAfterSubtitle = false;
  }

  public void InChatWaitVoiceLine_Thread()
  {
    if (!((UnityEngine.Object) this.PersonChattingTo == (UnityEngine.Object) null) && this.PersonChattingTo.PersonAudio.isPlaying)
      return;
    this.EndSubtitle();
  }

  public void InChatWaitTimer_Thread()
  {
    this.SubTitleTimer -= Time.fixedUnscaledDeltaTime;
    if ((double) this.SubTitleTimer > 0.0)
      return;
    this.EndSubtitle();
  }

  public void AddChatOption(string chattext, Action onOption)
  {
    for (int index = 0; index < this.ChatOptions.Length; ++index)
    {
      if (!this.ChatOptions[index].activeSelf)
      {
        this.ChatOptions[index].SetActive(true);
        this.ChatOptions_text[index].text = (index + 1).ToString() + " - " + chattext;
        this.ChatOptions_img[index].color = this.ChatUnselectedColor;
        this.ChatOptions_code[index] = onOption;
        ++this.OptionsCount;
        break;
      }
    }
  }

  public void SelectChatOption(int option)
  {
    for (int index1 = 0; index1 < this.ChatOptions.Length; ++index1)
    {
      if (this.ChatOptions[index1].activeSelf)
      {
        this.ChatOptions_img[index1].color = this.ChatUnselectedColor;
        char[] charArray = this.ChatOptions_text[index1].text.ToCharArray();
        charArray[2] = '-';
        this.ChatOptions_text[index1].text = string.Empty;
        for (int index2 = 0; index2 < charArray.Length; ++index2)
          this.ChatOptions_text[index1].text += charArray[index2].ToString();
      }
    }
    this.SelectedOption = option;
    this.ChatOptions_img[option].color = this.ChatSelectedColor;
    char[] charArray1 = this.ChatOptions_text[option].text.ToCharArray();
    charArray1[2] = '>';
    this.ChatOptions_text[option].text = string.Empty;
    for (int index = 0; index < charArray1.Length; ++index)
      this.ChatOptions_text[option].text += charArray1[index].ToString();
  }

  public void OpenedChatOptionsThread()
  {
    if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.KeypadEnter) || Input.GetKeyUp(KeyCode.E) || Input.GetKeyUp(KeyCode.F))
    {
      for (int index = 0; index < this.ChatOptions.Length; ++index)
      {
        if (this.ChatOptions[index].activeSelf && this.ChatOptions_img[index].color == this.ChatSelectedColor)
        {
          this.RemoveAllChatOptions();
          this.ChatOptions_code[index]();
          return;
        }
      }
    }
    for (int index = 0; index < this.ChatOptions.Length; ++index)
    {
      if (Input.GetKeyUp((KeyCode) (49 + index)))
      {
        this.RemoveAllChatOptions();
        this.ChatOptions_code[index]();
        return;
      }
    }
    if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
    {
      if (--this.SelectedOption == -1)
        this.SelectedOption = this.OptionsCount - 1;
      this.SelectChatOption(this.SelectedOption);
    }
    else
    {
      if (!Input.GetKeyUp(KeyCode.S) && !Input.GetKeyUp(KeyCode.DownArrow))
        return;
      if (++this.SelectedOption == this.OptionsCount)
        this.SelectedOption = 0;
      this.SelectChatOption(this.SelectedOption);
    }
  }

  public void RemoveAllChatOptions()
  {
    this.SavedSelectedOption = this.SelectedOption;
    this.SelectedOption = 0;
    this.OptionsCount = 0;
    Main.Instance.MainThreads.Remove(new Action(this.OpenedChatOptionsThread));
    for (int index = 0; index < this.ChatOptions.Length; ++index)
      this.ChatOptions[index].SetActive(false);
  }

  public void ShowMessageBox(string daText)
  {
    this.MessageBox_text.text = daText;
    this.MessageBox.SetActive(true);
    FirstPersonCharacter.AllowMouseCursor = true;
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
  }

  public void CloseMessageBox()
  {
    this.MessageBox_text.text = string.Empty;
    this.MessageBox.SetActive(false);
    FirstPersonCharacter.AllowMouseCursor = false;
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
  }

  public void CloseAllJournalMenus()
  {
    this.Journal_Inventory.SetActive(false);
    this.Journal_Acheivements.SetActive(false);
    this.Journal_missions.SetActive(false);
    this.Journal_Levelup.SetActive(false);
    this.Journal_HowTo.SetActive(false);
    this.Journal_Relationships.SetActive(false);
    this.Journal_Crafting.SetActive(false);
    this.Journal_Map.SetActive(false);
    this.Journal_Gallery.SetActive(false);
    this.Journal_Building.SetActive(false);
    this.Journal_Population.SetActive(false);
    this.Journal_WorldMap.SetActive(false);
    this.Journal_ArmyManagement.SetActive(false);
    this.AddMoneyBtn.SetActive(false);
    this.AddMoneyMenu.SetActive(false);
    Main.Instance.GarbageCollect();
  }

  public void OpenGallery()
  {
    this.CloseAllJournalMenus();
    this.Journal_Gallery.SetActive(true);
    for (int index = 0; index < this.MenuButtons.Length; ++index)
      this.MenuButtons[index].sprite = this.UnselectedButton;
    this.MenuButtons[5].sprite = this.SelectedButton;
    this.SelectNotes10();
  }

  public void Open_ArmyManagementTable()
  {
    this.OpenJournal();
    this.CloseAllJournalMenus();
    this.JournalOptionsList.SetActive(false);
    this.Journal_ArmyManagement.SetActive(true);
    for (int index = 0; index < this.JournalBGImages.Length; ++index)
      this.JournalBGImages[index].SetActive(false);
    this.JournalBGImages[1].SetActive(true);
    this.Army_SelectOrders();
  }

  public void Army_SelectOrders()
  {
    this.Army_tabs[0].SetActive(true);
    this.Army_tabs[1].SetActive(false);
    this.Army_tabs[2].SetActive(false);
    for (int index = 0; index < this.Orders_entries.Count; ++index)
    {
      if ((UnityEngine.Object) this.Orders_entries[index] != (UnityEngine.Object) null)
        UnityEngine.Object.Destroy((UnityEngine.Object) this.Orders_entries[index]);
    }
    for (int index = 0; index < Main.Instance.SpawnedPeople_World.Count; ++index)
    {
      Person person = Main.Instance.SpawnedPeople_World[index];
      if ((UnityEngine.Object) person != (UnityEngine.Object) null && person.PersonType.ThisType == Person_Type.Army)
      {
        bl_J_PopulationEntry component = UnityEngine.Object.Instantiate<GameObject>(this.ArmyOrders_entry, (Transform) this.ArmyOrdersContent).GetComponent<bl_J_PopulationEntry>();
        component.gameObject.SetActive(true);
        this.Orders_entries.Add(component.gameObject);
        component.ARMY_DisplayForPerson(person);
      }
    }
    this.ARMY_NoNPCS.SetActive(this.Orders_entries.Count == 0);
    this.ArmyOrdersContent.sizeDelta = new Vector2(0.0f, (float) (this.Orders_entries.Count * 24));
  }

  public void Army_SelectPatrol()
  {
    this.Army_tabs[0].SetActive(false);
    this.Army_tabs[1].SetActive(true);
    this.Army_tabs[2].SetActive(false);
    List<int_PatrolSpot> intPatrolSpotList = new List<int_PatrolSpot>();
    intPatrolSpotList.AddRange((IEnumerable<int_PatrolSpot>) UnityEngine.Object.FindObjectsOfType<int_PatrolSpot>(true));
    List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();
    options.Add(new Dropdown.OptionData()
    {
      text = "<None>"
    });
    for (int index = 0; index < intPatrolSpotList.Count; ++index)
      options.Add(new Dropdown.OptionData()
      {
        text = intPatrolSpotList[index].InteractText
      });
    for (int index = 0; index < this.Patrols_entries.Count; ++index)
    {
      if ((UnityEngine.Object) this.Patrols_entries[index] != (UnityEngine.Object) null)
        UnityEngine.Object.Destroy((UnityEngine.Object) this.Patrols_entries[index]);
    }
    for (int index1 = 0; index1 < Main.Instance.AllPatrols.Count; ++index1)
    {
      bl_J_PopulationEntry component = UnityEngine.Object.Instantiate<GameObject>(this.ArmyPatrols_entry, (Transform) this.ArmyPatrolsContent).GetComponent<bl_J_PopulationEntry>();
      component.gameObject.SetActive(true);
      this.Patrols_entries.Add(component.gameObject);
      component.NoteText.text = Main.Instance.AllPatrols[index1].Name;
      component.ThisPatrol = index1;
      for (int index2 = 0; index2 < component.Dropsdowns.Length; ++index2)
      {
        component.Dropsdowns[index2].ClearOptions();
        component.Dropsdowns[index2].AddOptions(options);
        if ((UnityEngine.Object) Main.Instance.AllPatrols[index1].Spots[index2] == (UnityEngine.Object) null)
        {
          component.Dropsdowns[index2].SetValueWithoutNotify(0);
        }
        else
        {
          for (int index3 = 0; index3 < intPatrolSpotList.Count; ++index3)
          {
            if ((UnityEngine.Object) intPatrolSpotList[index3] != (UnityEngine.Object) null && intPatrolSpotList[index3].InteractText == Main.Instance.AllPatrols[index1].Spots[index2].parent.name)
              component.Dropsdowns[index2].SetValueWithoutNotify(index3 + 1);
          }
        }
      }
    }
    this.ArmyPatrolsContent.sizeDelta = new Vector2(0.0f, (float) (this.Patrols_entries.Count * 24 + 24));
  }

  public void Click_AddNewArmyPatrol()
  {
    bl_Patrol blPatrol = new bl_Patrol()
    {
      Name = "(New Patrol)"
    };
    blPatrol.Spots.AddRange((IEnumerable<Transform>) new Transform[5]);
    Main.Instance.AllPatrols.Add(blPatrol);
    this.Army_SelectPatrol();
  }

  public void Army_SelectTrain()
  {
    this.Army_tabs[0].SetActive(false);
    this.Army_tabs[1].SetActive(false);
    this.Army_tabs[2].SetActive(true);
    for (int index = 0; index < this.ArmyTrain_entries.Count; ++index)
    {
      if ((UnityEngine.Object) this.ArmyTrain_entries[index] != (UnityEngine.Object) null)
        UnityEngine.Object.Destroy((UnityEngine.Object) this.ArmyTrain_entries[index]);
    }
    for (int index = 0; index < Main.Instance.SpawnedPeople_World.Count; ++index)
    {
      Person person = Main.Instance.SpawnedPeople_World[index];
      if ((UnityEngine.Object) person != (UnityEngine.Object) null && person.PersonType.ThisType == Person_Type.Prisioner)
      {
        bl_J_PopulationEntry component = UnityEngine.Object.Instantiate<GameObject>(this.ArmyTrain_entry, (Transform) this.ArmyTrainContent).GetComponent<bl_J_PopulationEntry>();
        component.gameObject.SetActive(true);
        this.ArmyTrain_entries.Add(component.gameObject);
        component.ARMY_Train_DisplayForPerson(person);
      }
    }
    this.ARMY_NoTrainNPCS.SetActive(this.ArmyTrain_entries.Count == 0);
    this.ArmyTrainContent.sizeDelta = new Vector2(0.0f, (float) (this.ArmyTrain_entries.Count * 24));
  }

  public void On_DisplayArmySpots() => this.SetDisplayArmySpots(this.DisplayArmySpots.isOn);

  public void SetDisplayArmySpots(bool value)
  {
    this.DisplayArmySpots.SetIsOnWithoutNotify(value);
    Main.Instance.GlobalVars.Add("DisplayArmySpots", value ? "1" : "0");
    List<int_PatrolSpot> intPatrolSpotList = new List<int_PatrolSpot>();
    intPatrolSpotList.AddRange((IEnumerable<int_PatrolSpot>) UnityEngine.Object.FindObjectsOfType<int_PatrolSpot>(true));
    for (int index = 0; index < intPatrolSpotList.Count; ++index)
      intPatrolSpotList[index].gameObject.SetActive(value);
  }

  public void Open_WorkerManagementTable()
  {
    this.OpenJournal();
    this.CloseAllJournalMenus();
    this.JournalOptionsList.SetActive(false);
    for (int index = 0; index < this.JournalBGImages.Length; ++index)
      this.JournalBGImages[index].SetActive(false);
    this.JournalBGImages[2].SetActive(true);
  }

  public void SelectNotes10()
  {
    Main.Instance.MusicPlayer.PlayOneShot(this.JournalSound1);
    for (int index = 0; index < this.GalleryLists.Length; ++index)
      this.GalleryLists[index].SetActive(false);
    this.GalleryLists[0].SetActive(true);
    for (int index = 0; index < this.Gallery_10.Length; ++index)
    {
      if (this.HasBitchNotes10[index])
      {
        this.Gallery_10[index].sprite = this.BitchNotes10[index];
        this.Gallery_10[index].color = new Color(1f, 1f, 1f, 1f);
      }
      else
      {
        this.Gallery_10[index].sprite = (Sprite) null;
        this.Gallery_10[index].color = new Color(1f, 1f, 1f, 0.2f);
      }
    }
  }

  public void SelectNotes20()
  {
    Main.Instance.MusicPlayer.PlayOneShot(this.JournalSound1);
    for (int index = 0; index < this.GalleryLists.Length; ++index)
      this.GalleryLists[index].SetActive(false);
    this.GalleryLists[1].SetActive(true);
    for (int index = 0; index < this.Gallery_20.Length; ++index)
    {
      if (this.HasBitchNotes20[index])
      {
        this.Gallery_20[index].sprite = this.BitchNotes20[index];
        this.Gallery_20[index].color = new Color(1f, 1f, 1f, 1f);
      }
      else
      {
        this.Gallery_20[index].sprite = (Sprite) null;
        this.Gallery_20[index].color = new Color(1f, 1f, 1f, 0.2f);
      }
    }
  }

  public void SelectNotes50()
  {
    Main.Instance.MusicPlayer.PlayOneShot(this.JournalSound1);
    for (int index = 0; index < this.GalleryLists.Length; ++index)
      this.GalleryLists[index].SetActive(false);
    this.GalleryLists[2].SetActive(true);
    for (int index = 0; index < this.Gallery_50.Length; ++index)
    {
      if (this.HasBitchNotes50[index])
      {
        this.Gallery_50[index].sprite = this.BitchNotes50[index];
        this.Gallery_50[index].color = new Color(1f, 1f, 1f, 1f);
      }
      else
      {
        this.Gallery_50[index].sprite = (Sprite) null;
        this.Gallery_50[index].color = new Color(1f, 1f, 1f, 0.2f);
      }
    }
  }

  public void SelectNotes100()
  {
    Main.Instance.MusicPlayer.PlayOneShot(this.JournalSound1);
    for (int index = 0; index < this.GalleryLists.Length; ++index)
      this.GalleryLists[index].SetActive(false);
    this.GalleryLists[3].SetActive(true);
    for (int index = 0; index < this.Gallery_100.Length; ++index)
    {
      if (this.HasBitchNotes100[index])
      {
        this.Gallery_100[index].sprite = this.BitchNotes100[index];
        this.Gallery_100[index].color = new Color(1f, 1f, 1f, 1f);
      }
      else
      {
        this.Gallery_100[index].sprite = (Sprite) null;
        this.Gallery_100[index].color = new Color(1f, 1f, 1f, 0.2f);
      }
    }
  }

  public void SelectNotes1000()
  {
    Main.Instance.MusicPlayer.PlayOneShot(this.JournalSound1);
    for (int index = 0; index < this.GalleryLists.Length; ++index)
      this.GalleryLists[index].SetActive(false);
    this.GalleryLists[4].SetActive(true);
    for (int index = 0; index < this.Gallery_1000.Length; ++index)
    {
      if (this.HasBitchNotes1000[index])
      {
        this.Gallery_1000[index].sprite = this.BitchNotes1000[index];
        this.Gallery_1000[index].color = new Color(1f, 1f, 1f, 1f);
      }
      else
      {
        this.Gallery_1000[index].sprite = (Sprite) null;
        this.Gallery_1000[index].color = new Color(1f, 1f, 1f, 0.2f);
      }
    }
  }

  public void SelectNotesProt()
  {
    Main.Instance.MusicPlayer.PlayOneShot(this.JournalSound1);
    for (int index = 0; index < this.GalleryLists.Length; ++index)
      this.GalleryLists[index].SetActive(false);
    this.GalleryLists[5].SetActive(true);
    for (int index = 0; index < this.Gallery_Prot.Length; ++index)
    {
      if (this.HasBitchNotesProt[index])
      {
        this.Gallery_Prot[index].sprite = this.BitchNotesProt[index];
        this.Gallery_Prot[index].color = new Color(1f, 1f, 1f, 1f);
      }
      else
      {
        this.Gallery_Prot[index].sprite = (Sprite) null;
        this.Gallery_Prot[index].color = new Color(1f, 1f, 1f, 0.2f);
      }
    }
  }

  public void SelectPosters1()
  {
    Main.Instance.MusicPlayer.PlayOneShot(this.JournalSound1);
    for (int index = 0; index < this.GalleryLists.Length; ++index)
      this.GalleryLists[index].SetActive(false);
    this.GalleryLists[6].SetActive(true);
    for (int index = 0; index < this.Gallery_BC.Length; ++index)
    {
      if (this.HasPostersBC[index])
      {
        this.Gallery_BC[index].sprite = this.PostersBC[index];
        this.Gallery_BC[index].color = new Color(1f, 1f, 1f, 1f);
      }
      else
      {
        this.Gallery_BC[index].sprite = (Sprite) null;
        this.Gallery_BC[index].color = new Color(1f, 1f, 1f, 0.2f);
      }
    }
  }

  public void SelectPosters2()
  {
    Main.Instance.MusicPlayer.PlayOneShot(this.JournalSound1);
    for (int index = 0; index < this.GalleryLists.Length; ++index)
      this.GalleryLists[index].SetActive(false);
    this.GalleryLists[7].SetActive(true);
    for (int index = 0; index < this.Gallery_BCLeg.Length; ++index)
    {
      if (this.HasPostersBCLeg[index])
      {
        this.Gallery_BCLeg[index].sprite = this.PostersBCLeg[index];
        this.Gallery_BCLeg[index].color = new Color(1f, 1f, 1f, 1f);
      }
      else
      {
        this.Gallery_BCLeg[index].sprite = (Sprite) null;
        this.Gallery_BCLeg[index].color = new Color(1f, 1f, 1f, 0.2f);
      }
    }
  }

  public void SelectPosters3()
  {
    Main.Instance.MusicPlayer.PlayOneShot(this.JournalSound1);
    for (int index = 0; index < this.GalleryLists.Length; ++index)
      this.GalleryLists[index].SetActive(false);
    this.GalleryLists[8].SetActive(true);
    for (int index = 0; index < this.Gallery_BCBEL.Length; ++index)
    {
      if (this.HasPostersBCBEL[index])
      {
        this.Gallery_BCBEL[index].sprite = this.PostersBCBEL[index];
        this.Gallery_BCBEL[index].color = new Color(1f, 1f, 1f, 1f);
      }
      else
      {
        this.Gallery_BCBEL[index].sprite = (Sprite) null;
        this.Gallery_BCBEL[index].color = new Color(1f, 1f, 1f, 0.2f);
      }
    }
  }

  public void SelectPosters4()
  {
    Main.Instance.MusicPlayer.PlayOneShot(this.JournalSound1);
    for (int index = 0; index < this.GalleryLists.Length; ++index)
      this.GalleryLists[index].SetActive(false);
    this.GalleryLists[9].SetActive(true);
    for (int index = 0; index < this.Gallery_BCCap.Length; ++index)
    {
      if (this.HasPostersBCCap[index])
      {
        this.Gallery_BCCap[index].sprite = this.PostersBCCap[index];
        this.Gallery_BCCap[index].color = new Color(1f, 1f, 1f, 1f);
      }
      else
      {
        this.Gallery_BCCap[index].sprite = (Sprite) null;
        this.Gallery_BCCap[index].color = new Color(1f, 1f, 1f, 0.2f);
      }
    }
  }

  public void OpenedJournal()
  {
    if (!Main.Instance.CancelKey())
      return;
    this.CloseJournal();
    this.CloseStorage();
  }

  public void OpenJournal()
  {
    Main.Instance.Player.AddMoveBlocker("Journal");
    Main.Instance.MainThreads.Add(new Action(this.OpenedJournal));
    this.HideDescription();
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
    Main.Instance.Player.UserControl.TheCam.enabled = false;
    Main.Instance.Player.UserControl.CanMove = false;
    this.JournalBGImages[0].SetActive(true);
    for (int index = 1; index < this.JournalBGImages.Length; ++index)
      this.JournalBGImages[index].SetActive(false);
    this.JournalOptionsList.SetActive(true);
    this.JournalMenu.SetActive(true);
    this.SelectLevelUp();
  }

  public void CloseJournal()
  {
    this.JournalMenu.SetActive(false);
    Main.Instance.Player.RemoveMoveBlocker("Journal");
    if (Main.Instance.MainThreads.Contains(new Action(this.OpenedJournal)))
      Main.Instance.MainThreads.Remove(new Action(this.OpenedJournal));
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
    Main.Instance.Player.UserControl.TheCam.enabled = true;
    Main.Instance.Player.UserControl.CanMove = true;
    Main.Instance.MusicPlayer.PlayOneShot(this.JournalSound1);
  }

  public void SelectAcheivements()
  {
    this.CloseAllJournalMenus();
    this.Journal_Acheivements.SetActive(true);
    for (int index = 0; index < this.MenuButtons.Length; ++index)
      this.MenuButtons[index].sprite = this.UnselectedButton;
    this.MenuButtons[3].sprite = this.SelectedButton;
    Main.Instance.MusicPlayer.PlayOneShot(this.JournalSound1);
  }

  public void SelectLevelUp()
  {
    this.CloseAllJournalMenus();
    this.Journal_Levelup.SetActive(true);
    for (int index = 0; index < this.MenuButtons.Length; ++index)
      this.MenuButtons[index].sprite = this.UnselectedButton;
    this.MenuButtons[2].sprite = this.SelectedButton;
    this.LvlUPAmounts[0].fillAmount = (float) Main.Instance.Player.WorkXpThisLvl / (float) Main.Instance.Player.WorkXpThisLvlMax;
    this.LvlUPLevels[0].text = "Lvl " + Main.Instance.Player.WorkSkills.ToString();
    this.LvlUPAmounts[1].fillAmount = (float) Main.Instance.Player.ArmyXpThisLvl / (float) Main.Instance.Player.ArmyXpThisLvlMax;
    this.LvlUPLevels[1].text = "Lvl " + Main.Instance.Player.ArmySkills.ToString();
    this.LvlUPAmounts[2].fillAmount = (float) Main.Instance.Player.SexXpThisLvl / (float) Main.Instance.Player.SexXpThisLvlMax;
    this.LvlUPLevels[2].text = "Lvl " + Main.Instance.Player.SexSkills.ToString();
    this.SelectLvl_Sex();
  }

  public void SelectMissions()
  {
    this.CloseAllJournalMenus();
    this.Journal_missions.SetActive(true);
    for (int index = 0; index < this.MenuButtons.Length; ++index)
      this.MenuButtons[index].sprite = this.UnselectedButton;
    this.MenuButtons[0].sprite = this.SelectedButton;
    for (int index = 0; index < this.MissionsEntries.Count; ++index)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.MissionsEntries[index]);
    this.Click_SelectMissionsOf(1);
    this.Journal_ShowGoal(this.CurrentMission);
  }

  public void SelectInventory()
  {
    this.CloseAllJournalMenus();
    this.Journal_Inventory.SetActive(true);
    for (int index = 0; index < this.MenuButtons.Length; ++index)
      this.MenuButtons[index].sprite = this.UnselectedButton;
    this.MenuButtons[1].sprite = this.SelectedButton;
    for (int index = 0; index < this.InvEntries.Count; ++index)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.InvEntries[index]);
    this.InvEntries.Clear();
    this.BitchNotesText.text = Main.Instance.Player.Money.ToString();
    for (int index = 0; index < Main.Instance.Player.WeaponInv.weapons.Count; ++index)
    {
      if ((UnityEngine.Object) Main.Instance.Player.WeaponInv.weapons[index] != (UnityEngine.Object) null)
      {
        misc_invItem component = UnityEngine.Object.Instantiate<GameObject>(this.InvEntry, this.InvEntry.transform.parent).GetComponent<misc_invItem>();
        component.Title.text = Main.Instance.Player.WeaponInv.weapons[index].name;
        component.ThisWeapomn = Main.Instance.Player.WeaponInv.weapons[index];
        component.gameObject.SetActive(true);
        this.InvEntries.Add(component.gameObject);
      }
    }
    for (int index = 0; index < Main.Instance.Player.EquippedClothes.Count; ++index)
    {
      switch (Main.Instance.Player.EquippedClothes[index].BodyPart)
      {
        case DressableType.Hair:
        case DressableType.Head:
        case DressableType.Body:
          continue;
        default:
          if (!Main.Instance.Player.EquippedClothes[index].HideFromInv)
          {
            misc_invItem component = UnityEngine.Object.Instantiate<GameObject>(this.InvEntry, this.InvEntry.transform.parent).GetComponent<misc_invItem>();
            component.Title.text = Main.Instance.Player.EquippedClothes[index].name;
            component.ThisDressable = Main.Instance.Player.EquippedClothes[index];
            if (Main.Instance.Player.EquippedClothes[index].BodyPart == DressableType.BackPack)
              component.OpenBtn.SetActive(true);
            else if ((UnityEngine.Object) Main.Instance.Player.CurrentBackpack != (UnityEngine.Object) null && !component.ThisDressable.CantBeDroppedByPlayer)
              component.SendBtn.SetActive(true);
            if (component.ThisDressable.CantBeDroppedByPlayer)
              component.DropBtn.interactable = false;
            component.gameObject.SetActive(true);
            this.InvEntries.Add(component.gameObject);
            continue;
          }
          continue;
      }
    }
    for (int index = 0; index < Main.Instance.Player.Storage_Hands.StorageItems.Count; ++index)
    {
      misc_invItem component = UnityEngine.Object.Instantiate<GameObject>(this.InvEntry, this.InvEntry.transform.parent).GetComponent<misc_invItem>();
      component.Title.text = "(Hands) " + Main.Instance.Player.Storage_Hands.StorageItems[index].name;
      component.ThisDressable = (Dressable) null;
      component.ThisItem = Main.Instance.Player.Storage_Hands.StorageItems[index];
      component.ThisStorage = Main.Instance.Player.Storage_Hands;
      component.DropBtn.interactable = true;
      component.gameObject.SetActive(true);
      this.InvEntries.Add(component.gameObject);
    }
    for (int index = 0; index < Main.Instance.Player.Storage_Vag.StorageItems.Count; ++index)
    {
      misc_invItem component = UnityEngine.Object.Instantiate<GameObject>(this.InvEntry, this.InvEntry.transform.parent).GetComponent<misc_invItem>();
      component.Title.text = "(Vagina) " + Main.Instance.Player.Storage_Vag.StorageItems[index].name;
      component.ThisDressable = (Dressable) null;
      component.ThisItem = Main.Instance.Player.Storage_Vag.StorageItems[index];
      component.ThisStorage = Main.Instance.Player.Storage_Vag;
      component.DropBtn.interactable = true;
      component.gameObject.SetActive(true);
      this.InvEntries.Add(component.gameObject);
    }
    for (int index = 0; index < Main.Instance.Player.Storage_Anal.StorageItems.Count; ++index)
    {
      misc_invItem component = UnityEngine.Object.Instantiate<GameObject>(this.InvEntry, this.InvEntry.transform.parent).GetComponent<misc_invItem>();
      component.Title.text = "(Anal) " + Main.Instance.Player.Storage_Anal.StorageItems[index].name;
      component.ThisDressable = (Dressable) null;
      component.ThisItem = Main.Instance.Player.Storage_Anal.StorageItems[index];
      component.ThisStorage = Main.Instance.Player.Storage_Anal;
      component.DropBtn.interactable = true;
      component.gameObject.SetActive(true);
      this.InvEntries.Add(component.gameObject);
    }
    this.InvContent.sizeDelta = new Vector2(0.0f, (float) (this.InvEntries.Count * 40 + 50));
    for (int index = 0; index < this.StatesEntries.Count; ++index)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.StatesEntries[index]);
    for (int index = 0; index < Main.Instance.Player.States.Length; ++index)
    {
      if (Main.Instance.Player.States[index])
      {
        GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.StatesEntry, this.StatesEntry.transform.parent);
        gameObject.transform.Find("text").GetComponent<Text>().text = Main.Instance.States_Data[index].Name + (Main.Instance.States_Data[index].Effect.Length == 0 ? string.Empty : " (" + Main.Instance.States_Data[index].Effect + ")");
        gameObject.SetActive(true);
        this.StatesEntries.Add(gameObject);
      }
    }
    Main.Instance.MusicPlayer.PlayOneShot(this.JournalSound1);
  }

  public void SelectLvl_Sex()
  {
    for (int index = 0; index < this.LvlUPButtons.Length; ++index)
      this.LvlUPButtons[index].sprite = this.UnselectedButton;
    this.LvlUPButtons[2].sprite = this.SelectedButton;
    for (int index = 0; index < this.LevelUpContents.Length; ++index)
      this.LevelUpContents[index].SetActive(false);
    this.LevelUpContents[0].SetActive(true);
    this.LevelUpContents[0].transform.parent.GetComponent<RectTransform>().localPosition = Vector3.zero;
    this.ScatPerks.SetActive(Main.Instance.ScatContent);
    Main.Instance.MusicPlayer.PlayOneShot(this.JournalSound1);
  }

  public void SelectLvl_Work()
  {
    for (int index = 0; index < this.LvlUPButtons.Length; ++index)
      this.LvlUPButtons[index].sprite = this.UnselectedButton;
    this.LvlUPButtons[0].sprite = this.SelectedButton;
    for (int index = 0; index < this.LevelUpContents.Length; ++index)
      this.LevelUpContents[index].SetActive(false);
    this.LevelUpContents[1].SetActive(true);
    this.LevelUpContents[0].transform.parent.GetComponent<RectTransform>().localPosition = Vector3.zero;
    Main.Instance.MusicPlayer.PlayOneShot(this.JournalSound1);
  }

  public void SelectLvl_Army()
  {
    for (int index = 0; index < this.LvlUPButtons.Length; ++index)
      this.LvlUPButtons[index].sprite = this.UnselectedButton;
    this.LvlUPButtons[1].sprite = this.SelectedButton;
    for (int index = 0; index < this.LevelUpContents.Length; ++index)
      this.LevelUpContents[index].SetActive(false);
    this.LevelUpContents[2].SetActive(true);
    this.LevelUpContents[0].transform.parent.GetComponent<RectTransform>().localPosition = Vector3.zero;
    Main.Instance.MusicPlayer.PlayOneShot(this.JournalSound1);
  }

  public void SelectHowTo()
  {
    this.CloseAllJournalMenus();
    this.Journal_HowTo.SetActive(true);
    for (int index = 0; index < this.MenuButtons.Length; ++index)
      this.MenuButtons[index].sprite = this.UnselectedButton;
    this.MenuButtons[4].sprite = this.SelectedButton;
    Main.Instance.MusicPlayer.PlayOneShot(this.JournalSound1);
  }

  public void Journal_ShowGoal(Mission mission)
  {
    Main.Instance.MusicPlayer.PlayOneShot(this.JournalSound1);
    for (int index = 0; index < this.GoalsEntries.Count; ++index)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.GoalsEntries[index]);
    if ((UnityEngine.Object) mission == (UnityEngine.Object) null)
      return;
    for (int index = 0; index < mission.Goals.Count; ++index)
    {
      GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.GoalsEntry, this.GoalsEntry.transform.parent);
      misc_misentry component = gameObject.GetComponent<misc_misentry>();
      component.Title.text = mission.Goals[index].Title;
      component.Check.SetActive(mission.Goals[index].Completed);
      component.Fail.SetActive(mission.Goals[index].Failed);
      gameObject.SetActive(true);
      this.GoalsEntries.Add(gameObject);
    }
  }

  public void ShowDescription(int value)
  {
    this.PerkDesc.SetActive(true);
    this.PerkDesc.GetComponent<RectTransform>().position = Input.mousePosition;
    switch (value)
    {
      case 0:
        this.PerkDescText.text = "Scat Nutrition lvl 1\n\nYou become used to the taste and smell";
        break;
      case 1:
        this.PerkDescText.text = "Scat Nutrition lvl 2\n\nYou like the taste and it smells wonderfully";
        break;
      case 2:
        this.PerkDescText.text = "Scat is Best Nutrition\n\nYou love the taste and smell\nIt feeds you better than any other food";
        break;
      case 3:
        this.PerkDescText.text = "Compressed Scat Meals\n\nAble of crafting [compressed scat meals] in a kitchen\nFor long duration snacks";
        break;
      case 4:
        this.PerkDescText.text = "Scat from other people is Love\n\nScat from others is extra nutricious\n+ Increases Arousal";
        break;
      case 5:
        this.PerkDescText.text = "Intestinal control\n\nAble of carrying more inside you, and for longer";
        break;
      case 6:
        this.PerkDescText.text = "Scat Arousal\n\nAbility of scat usage during arousal activities\nAny other scat activity will also increase arousal";
        break;
      case 7:
        this.PerkDescText.text = "Intestinal Pleasure\n\nIntestinal pain turns into pleasure\nEvacuating will cause unconditional orgasm";
        break;
    }
    Main.Instance.MusicPlayer.PlayOneShot(this.JournalSound1);
  }

  public void HideDescription() => this.PerkDesc.SetActive(false);

  public void ShowDescription(string desc)
  {
    this.PerkDesc.SetActive(true);
    this.PerkDesc.GetComponent<RectTransform>().position = Input.mousePosition;
    this.PerkDescText.text = desc;
    Main.Instance.MusicPlayer.PlayOneShot(this.JournalSound1);
  }

  public void Select_Population()
  {
    this.CloseAllJournalMenus();
    this.Journal_Population.SetActive(true);
    this.J_RefreshPopulation();
  }

  public void Select_WorldMap()
  {
    this.CloseAllJournalMenus();
    this.Journal_WorldMap.SetActive(true);
  }

  public void J_RefreshPopulation()
  {
    for (int index = 0; index < this.Pop_Entries.Count; ++index)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.Pop_Entries[index]);
    this.Pop_Entries.Clear();
    List<Person> personList = new List<Person>();
    personList.AddRange((IEnumerable<Person>) Main.Instance.SpawnedPeople);
    personList.AddRange((IEnumerable<Person>) Main.Instance.SpawnedPeople_World);
label_4:
    for (int index = 0; index < personList.Count; ++index)
    {
      if ((UnityEngine.Object) personList[index] == (UnityEngine.Object) null || personList[index].IsPlayer || !personList[index].gameObject.activeSelf || (double) Vector3.Distance(Main.Instance.Player.transform.position, personList[index].transform.position) > 50.0)
      {
        personList.RemoveAt(index);
        goto label_4;
      }
    }
    this.Pop_content.sizeDelta = new Vector2(0.0f, (float) (personList.Count * 24 + 24));
    personList.Sort((Comparison<Person>) ((a, b) => Vector3.Distance(Main.Instance.Player.transform.position, a.transform.position).CompareTo(Vector3.Distance(Main.Instance.Player.transform.position, b.transform.position))));
    for (int index = 0; index < personList.Count; ++index)
    {
      GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Pop_Entry, this.Pop_Entry.transform.parent);
      gameObject.SetActive(true);
      this.Pop_Entries.Add(gameObject);
      gameObject.GetComponent<bl_J_PopulationEntry>().DisplayForPerson(personList[index]);
    }
  }

  public void Perk_ScatNut1()
  {
    if (Main.Instance.Player.SexSkills >= 1)
    {
      --Main.Instance.Player.SexSkills;
      this.LvlUPAmounts[2].fillAmount = (float) Main.Instance.Player.SexXpThisLvl / (float) Main.Instance.Player.SexXpThisLvlMax;
      this.LvlUPLevels[2].text = "Lvl " + Main.Instance.Player.SexSkills.ToString();
      this.SexButtons[0].image.color = Color.white;
      this.SexButtons[1].interactable = true;
      this.SexButtons[1].image.color = this.AvailablePerk;
      Main.Instance.MusicPlayer.PlayOneShot(this.JournalPerkSound, 3f);
    }
    else
      this.PerkDescText.text = "Costs 1 Sex level";
  }

  public void Perk_ScatNut2()
  {
    if (Main.Instance.Player.SexSkills >= 2)
    {
      Main.Instance.Player.SexSkills -= 2;
      this.LvlUPAmounts[2].fillAmount = (float) Main.Instance.Player.SexXpThisLvl / (float) Main.Instance.Player.SexXpThisLvlMax;
      this.LvlUPLevels[2].text = "Lvl " + Main.Instance.Player.SexSkills.ToString();
      this.SexButtons[1].image.color = Color.white;
      this.SexButtons[2].interactable = true;
      this.SexButtons[2].image.color = this.AvailablePerk;
      Main.Instance.MusicPlayer.PlayOneShot(this.JournalPerkSound, 3f);
    }
    else
      this.PerkDescText.text = "Costs 2 Sex levels";
  }

  public void Perk_ScatNut3()
  {
    if (Main.Instance.Player.SexSkills >= 3)
    {
      Main.Instance.Player.SexSkills -= 3;
      this.LvlUPAmounts[2].fillAmount = (float) Main.Instance.Player.SexXpThisLvl / (float) Main.Instance.Player.SexXpThisLvlMax;
      this.LvlUPLevels[2].text = "Lvl " + Main.Instance.Player.SexSkills.ToString();
      this.SexButtons[2].image.color = Color.white;
      this.SexButtons[3].interactable = true;
      this.SexButtons[4].interactable = true;
      this.SexButtons[3].image.color = this.AvailablePerk;
      this.SexButtons[4].image.color = this.AvailablePerk;
      Main.Instance.MusicPlayer.PlayOneShot(this.JournalPerkSound, 3f);
    }
    else
      this.PerkDescText.text = "Costs 3 Sex levels";
  }

  public void Perk_ScatNutOthers()
  {
    if (Main.Instance.Player.SexSkills >= 4)
    {
      Main.Instance.Player.SexSkills -= 4;
      this.LvlUPAmounts[2].fillAmount = (float) Main.Instance.Player.SexXpThisLvl / (float) Main.Instance.Player.SexXpThisLvlMax;
      this.LvlUPLevels[2].text = "Lvl " + Main.Instance.Player.SexSkills.ToString();
      this.SexButtons[4].image.color = Color.white;
      this.SexButtons[5].interactable = true;
      this.SexButtons[6].interactable = true;
      this.SexButtons[5].image.color = this.AvailablePerk;
      this.SexButtons[6].image.color = this.AvailablePerk;
      Main.Instance.MusicPlayer.PlayOneShot(this.JournalPerkSound, 3f);
    }
    else
      this.PerkDescText.text = "Costs 4 Sex levels";
  }

  public void Perk_ScatCompressed()
  {
    if (Main.Instance.Player.SexSkills >= 5)
    {
      Main.Instance.Player.SexSkills -= 5;
      this.LvlUPAmounts[2].fillAmount = (float) Main.Instance.Player.SexXpThisLvl / (float) Main.Instance.Player.SexXpThisLvlMax;
      this.LvlUPLevels[2].text = "Lvl " + Main.Instance.Player.SexSkills.ToString();
      this.SexButtons[3].image.color = Color.white;
      Main.Instance.MusicPlayer.PlayOneShot(this.JournalPerkSound, 3f);
    }
    else
      this.PerkDescText.text = "Costs 5 Sex levels";
  }

  public void Perk_ScatIntestineControl()
  {
    if (Main.Instance.Player.SexSkills >= 6)
    {
      Main.Instance.Player.SexSkills -= 6;
      this.LvlUPAmounts[2].fillAmount = (float) Main.Instance.Player.SexXpThisLvl / (float) Main.Instance.Player.SexXpThisLvlMax;
      this.LvlUPLevels[2].text = "Lvl " + Main.Instance.Player.SexSkills.ToString();
      this.SexButtons[5].image.color = Color.white;
      Main.Instance.MusicPlayer.PlayOneShot(this.JournalPerkSound, 3f);
    }
    else
      this.PerkDescText.text = "Costs 6 Sex levels";
  }

  public void Perk_ScatArousal()
  {
    if (Main.Instance.Player.SexSkills >= 7)
    {
      Main.Instance.Player.SexSkills -= 7;
      this.LvlUPAmounts[2].fillAmount = (float) Main.Instance.Player.SexXpThisLvl / (float) Main.Instance.Player.SexXpThisLvlMax;
      this.LvlUPLevels[2].text = "Lvl " + Main.Instance.Player.SexSkills.ToString();
      this.SexButtons[6].image.color = Color.white;
      this.SexButtons[7].interactable = true;
      this.SexButtons[7].image.color = this.AvailablePerk;
      Main.Instance.MusicPlayer.PlayOneShot(this.JournalPerkSound, 3f);
    }
    else
      this.PerkDescText.text = "Costs 7 Sex levels";
  }

  public void Perk_ScatIntestinePleasure()
  {
    if (Main.Instance.Player.SexSkills >= 8)
    {
      Main.Instance.Player.SexSkills -= 8;
      this.LvlUPAmounts[2].fillAmount = (float) Main.Instance.Player.SexXpThisLvl / (float) Main.Instance.Player.SexXpThisLvlMax;
      this.LvlUPLevels[2].text = "Lvl " + Main.Instance.Player.SexSkills.ToString();
      this.SexButtons[7].image.color = Color.white;
      Main.Instance.MusicPlayer.PlayOneShot(this.JournalPerkSound, 3f);
    }
    else
      this.PerkDescText.text = "Costs 8 Sex levels";
  }

  public void Perk_Prost_profit1()
  {
  }

  public void Perk_Prost_profit2()
  {
  }

  public void Perk_Prost_Skill3_steal()
  {
  }

  public void Perk_Prost_Skill4_kill()
  {
  }

  public void Perk_Service_1()
  {
  }

  public void Perk_Service_2()
  {
  }

  public void Perk_Sex_FasterGasm()
  {
  }

  public void Perk_Sex_LongerGasm()
  {
  }

  public void Perk_Sex_VMuscleRelax()
  {
  }

  public void Perk_Sex_ItemStorage1()
  {
  }

  public void Perk_Sex_ItemStorage2()
  {
  }

  public void Perk_Sex_Smell()
  {
  }

  public void Perk_Sex_GatherJuice()
  {
  }

  public void Perk_Sex_CraftPotion()
  {
  }

  public void Perk_Army_LessJam()
  {
  }

  public void Perk_Army_2Weapons()
  {
  }

  public void Perk_Army_Damage()
  {
  }

  public void Perk_Army_Stealth()
  {
  }

  public void RefreshContainer()
  {
    if (this.TraderMenu.activeSelf)
      this.OpenTrader(this.CurrentOpenStorage);
    else
      this.OpenContainer(this.CurrentOpenStorage);
  }

  public void CloseStorage()
  {
    this.AddMoneyBtn.SetActive(false);
    this.AddMoneyMenu.SetActive(false);
    if (this.TraderMenu.activeSelf)
    {
      this.CloseTrader();
    }
    else
    {
      if (!this.ContainerStorage.activeSelf)
        return;
      if ((UnityEngine.Object) Main.Instance.Player.HavingSex_Scene != (UnityEngine.Object) null)
      {
        Main.Instance.SexScene.EndSexScene();
      }
      else
      {
        this.ContainerStorage.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Main.Instance.Player.UserControl.TheCam.IsDisabled = false;
        Main.Instance.Player.RemoveMoveBlocker("Container");
        if (Main.Instance.MainThreads.Contains(new Action(this.OpenedJournal)))
          Main.Instance.MainThreads.Remove(new Action(this.OpenedJournal));
        if ((UnityEngine.Object) this.CurrentOpenStorage != (UnityEngine.Object) null && (UnityEngine.Object) this.CurrentOpenStorage.Sound != (UnityEngine.Object) null && (UnityEngine.Object) this.CurrentOpenStorage.OpenSound != (UnityEngine.Object) null)
        {
          this.CurrentOpenStorage.Sound.clip = this.CurrentOpenStorage.CloseSound;
          this.CurrentOpenStorage.Sound.Play();
        }
        for (int index = 0; index < this.OnCloseContainer.Count; ++index)
          this.OnCloseContainer[index]();
        this.OnCloseContainer.Clear();
        Main.Instance.GarbageCollect();
      }
    }
  }

  public void OpenContainer(Int_Storage Storage)
  {
    this.AddMoneyMenu.SetActive(false);
    int num1 = 0;
    int num2 = 0;
    this.CurrentOpenStorage = Storage;
    if ((UnityEngine.Object) this.CurrentOpenStorage != (UnityEngine.Object) null)
      this.AddMoneyBtn.SetActive(this.CurrentOpenStorage.AllowMoney);
    this.CancelPlanButton.SetActive(Storage is int_ConstructionPlan);
    Main.Instance.Player.AddMoveBlocker("Container");
    for (int index = 0; index < this.MouseRotate.Length; ++index)
      this.MouseRotate[index].enabled = false;
    for (int index = 0; index < this.BackPackEntries.Count; ++index)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.BackPackEntries[index]);
    for (int index = 0; index < this.ContainterEntries.Count; ++index)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.ContainterEntries[index]);
    this.ContainerStorage.SetActive(true);
    if ((UnityEngine.Object) Main.Instance.Player.CurrentBackpack != (UnityEngine.Object) null || !Main.Instance.Player.Storage_Hands.Empty || !Main.Instance.Player.Storage_Vag.Empty || !Main.Instance.Player.Storage_Anal.Empty)
    {
      List<GameObject> gameObjectList = new List<GameObject>();
      gameObjectList.AddRange((IEnumerable<GameObject>) Main.Instance.Player.Storage_Hands.StorageItems);
      gameObjectList.AddRange((IEnumerable<GameObject>) Main.Instance.Player.Storage_Vag.StorageItems);
      gameObjectList.AddRange((IEnumerable<GameObject>) Main.Instance.Player.Storage_Anal.StorageItems);
      if ((UnityEngine.Object) Main.Instance.Player.CurrentBackpack != (UnityEngine.Object) null)
      {
        BackPack component = Main.Instance.Player.CurrentBackpack.GetComponent<BackPack>();
        gameObjectList.AddRange((IEnumerable<GameObject>) component.ThisStorage.StorageItems);
      }
      for (int index = 0; index < gameObjectList.Count; ++index)
      {
        if (!((UnityEngine.Object) gameObjectList[index] == (UnityEngine.Object) null))
        {
          misc_invItem component1 = UnityEngine.Object.Instantiate<GameObject>(this.BackPackEntry, this.BackPackEntry.transform.parent).GetComponent<misc_invItem>();
          this.BackPackEntries.Add(component1.gameObject);
          component1.ThisStorage = this.CurrentOpenStorage;
          component1.ThisWeapomn = gameObjectList[index];
          component1.Title.text = gameObjectList[index].name;
          component1.gameObject.SetActive(true);
          if ((UnityEngine.Object) Storage == (UnityEngine.Object) null || (UnityEngine.Object) Storage != (UnityEngine.Object) null && Storage.Full)
            component1.SendBtn.GetComponent<Button>().interactable = false;
          if ((UnityEngine.Object) gameObjectList[index].GetComponent<Dressable>() == (UnityEngine.Object) null)
          {
            component1.EquipBtn.SetActive(false);
            MultiInteractible component2 = gameObjectList[index].GetComponent<MultiInteractible>();
            if ((UnityEngine.Object) component2 != (UnityEngine.Object) null && (UnityEngine.Object) component2.Parts[0].gameObject.GetComponent<int_PickableClothingPackage>() != (UnityEngine.Object) null)
              component1.EquipBtn.SetActive(true);
          }
        }
      }
      this.BackPackAmount.text = !((UnityEngine.Object) Main.Instance.Player.CurrentBackpack != (UnityEngine.Object) null) ? "(No backpack)" : Main.Instance.Player.CurrentBackpack.ThisStorage.StorageItems.Count.ToString() + "/" + Main.Instance.Player.CurrentBackpack.ThisStorage.StorageMax.ToString();
      num1 = gameObjectList.Count;
    }
    else
      this.BackPackAmount.text = "(None)";
    if ((UnityEngine.Object) Storage != (UnityEngine.Object) null)
    {
      if (Storage is int_personStorage)
      {
        int_personStorage intPersonStorage = (int_personStorage) Storage;
        int num3 = 0;
        for (int index = 0; index < intPersonStorage.ThisPerson.EquippedClothes.Count; ++index)
        {
          switch (intPersonStorage.ThisPerson.EquippedClothes[index].BodyPart)
          {
            case DressableType.Hair:
            case DressableType.Head:
            case DressableType.Body:
            case DressableType.Beard:
              continue;
            default:
              if (!intPersonStorage.ThisPerson.EquippedClothes[index].HideFromInv)
              {
                ++num3;
                misc_invItem component = UnityEngine.Object.Instantiate<GameObject>(this.ContainterEntry, this.ContainterEntry.transform.parent).GetComponent<misc_invItem>();
                this.ContainterEntries.Add(component.gameObject);
                component.ThisStorage = this.CurrentOpenStorage;
                component.ThisWeapomn = intPersonStorage.ThisPerson.EquippedClothes[index].gameObject;
                component.Title.text = intPersonStorage.ThisPerson.EquippedClothes[index].name;
                component.gameObject.SetActive(true);
                if ((UnityEngine.Object) Main.Instance.Player.CurrentBackpack == (UnityEngine.Object) null)
                {
                  component.SendBtn.GetComponent<Button>().interactable = false;
                  continue;
                }
                continue;
              }
              continue;
          }
        }
        for (int index = 0; index < intPersonStorage.StorageItems.Count; ++index)
        {
          ++num3;
          misc_invItem component = UnityEngine.Object.Instantiate<GameObject>(this.ContainterEntry, this.ContainterEntry.transform.parent).GetComponent<misc_invItem>();
          this.ContainterEntries.Add(component.gameObject);
          component.ThisStorage = this.CurrentOpenStorage;
          component.ThisWeapomn = intPersonStorage.StorageItems[index];
          component.Title.text = intPersonStorage.StorageItems[index].name;
          component.gameObject.SetActive(true);
          if ((UnityEngine.Object) Main.Instance.Player.CurrentBackpack == (UnityEngine.Object) null)
            component.SendBtn.GetComponent<Button>().interactable = false;
          if ((UnityEngine.Object) intPersonStorage.StorageItems[index].GetComponent<int_money>() != (UnityEngine.Object) null)
          {
            component.SendBtn.GetComponent<Button>().interactable = true;
            component.EquipBtn.GetComponent<Button>().interactable = false;
          }
        }
        this.ContainerAmount.text = num3.ToString();
        num2 = num3;
      }
      else
      {
        for (int index = 0; index < this.CurrentOpenStorage.StorageItems.Count; ++index)
        {
          misc_invItem component3 = UnityEngine.Object.Instantiate<GameObject>(this.ContainterEntry, this.ContainterEntry.transform.parent).GetComponent<misc_invItem>();
          this.ContainterEntries.Add(component3.gameObject);
          component3.ThisStorage = this.CurrentOpenStorage;
          component3.ThisWeapomn = Storage.StorageItems[index];
          component3.Title.text = Storage.StorageItems[index].name;
          component3.gameObject.SetActive(true);
          if ((UnityEngine.Object) Main.Instance.Player.CurrentBackpack == (UnityEngine.Object) null)
            component3.SendBtn.GetComponent<Button>().interactable = false;
          Dressable component4 = this.CurrentOpenStorage.StorageItems[index].GetComponent<Dressable>();
          int_PickableClothingPackage componentInChildren = this.CurrentOpenStorage.StorageItems[index].GetComponentInChildren<int_PickableClothingPackage>();
          if ((UnityEngine.Object) component4 == (UnityEngine.Object) null && (UnityEngine.Object) componentInChildren == (UnityEngine.Object) null)
            component3.EquipBtn.SetActive(false);
        }
        this.ContainerAmount.text = this.CurrentOpenStorage.StorageItems.Count.ToString() + "/" + Storage.StorageMax.ToString();
        num2 = this.CurrentOpenStorage.StorageItems.Count;
      }
    }
    else
      this.ContainerAmount.text = "(None)";
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
    Main.Instance.Player.UserControl.TheCam.IsDisabled = true;
    Main.Instance.MainThreads.Add(new Action(this.OpenedJournal));
    if (num1 > 0)
      this.BackPackContent.sizeDelta = new Vector2(0.0f, (float) (num1 * 40 + 40));
    if (num2 <= 0)
      return;
    this.ContainterContent.sizeDelta = new Vector2(0.0f, (float) (num2 * 40 + 40));
  }

  public void AddMoneyOpen()
  {
    this.AddMoneyMenu.SetActive(!this.AddMoneyMenu.activeSelf);
    if (!this.AddMoneyMenu.activeSelf)
      return;
    this.AddMoneyCurrentText.text = Main.Instance.Player.Money.ToString();
    this.AddMoneySlider.maxValue = (float) Main.Instance.Player.Money;
    this.AddMoneySlider.value = (float) (Main.Instance.Player.Money / 2);
  }

  public void On_AddMoneySliderChange()
  {
    this.AddMoneySliderText.text = this.AddMoneySlider.value.ToString();
  }

  public void Click_AddMoney()
  {
    int num = (int) this.AddMoneySlider.value;
    this.AddMoneySlider.value = 0.0f;
    if (num != 0)
    {
      Main.Instance.Player.Money -= num;
      GameObject gameObject = Main.Spawn(Main.Instance.AllPrefabs[192]);
      int_money component = gameObject.GetComponent<int_money>();
      component.Value = num;
      component.InteractText = gameObject.name = num.ToString() + " Bitch Notes";
      this.CurrentOpenStorage.AddItem(gameObject);
    }
    this.AddMoneyMenu.SetActive(false);
    this.RefreshContainer();
  }

  public void OpenTrader(Int_Storage Storage)
  {
    this.AddMoneyBtn.SetActive(false);
    this.AddMoneyMenu.SetActive(false);
    int num1 = 0;
    int num2 = 0;
    this.CurrentOpenStorage = Storage;
    Main.Instance.Player.AddMoveBlocker("Container");
    for (int index = 0; index < this.MouseRotate.Length; ++index)
      this.MouseRotate[index].enabled = false;
    for (int index = 0; index < this.TraderBackPackEntries.Count; ++index)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.TraderBackPackEntries[index]);
    for (int index = 0; index < this.TraderContainterEntries.Count; ++index)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.TraderContainterEntries[index]);
    this.TraderPlayerMoney.text = Main.Instance.Player.Money.ToString() + " Bitch notes";
    this.TraderMenu.SetActive(true);
    if ((UnityEngine.Object) Main.Instance.Player.CurrentBackpack != (UnityEngine.Object) null)
    {
      BackPack component1 = Main.Instance.Player.CurrentBackpack.GetComponent<BackPack>();
      for (int index = 0; index < component1.ThisStorage.StorageItems.Count; ++index)
      {
        misc_invItem component2 = UnityEngine.Object.Instantiate<GameObject>(this.TraderBackPackEntry, this.TraderBackPackEntry.transform.parent).GetComponent<misc_invItem>();
        this.TraderBackPackEntries.Add(component2.gameObject);
        component2.ThisStorage = this.CurrentOpenStorage;
        component2.ThisWeapomn = component1.ThisStorage.StorageItems[index];
        component2.Title.text = component1.ThisStorage.StorageItems[index].name;
        component2.gameObject.SetActive(true);
        if ((UnityEngine.Object) Storage == (UnityEngine.Object) null || (UnityEngine.Object) Storage != (UnityEngine.Object) null && Storage.Full)
          component2.SendBtn.GetComponent<Button>().interactable = false;
        int_ResourceItem componentInChildren = component1.ThisStorage.StorageItems[index].GetComponentInChildren<int_ResourceItem>(true);
        if ((UnityEngine.Object) componentInChildren == (UnityEngine.Object) null || (UnityEngine.Object) componentInChildren != (UnityEngine.Object) null && !componentInChildren.Sellable)
          component2.SendBtn.GetComponent<Button>().interactable = false;
        if ((UnityEngine.Object) component1.ThisStorage.StorageItems[index].GetComponent<Dressable>() == (UnityEngine.Object) null)
        {
          component2.EquipBtn.SetActive(false);
          MultiInteractible component3 = component1.ThisStorage.StorageItems[index].GetComponent<MultiInteractible>();
          if ((UnityEngine.Object) component3 != (UnityEngine.Object) null && (UnityEngine.Object) component3.Parts[0].gameObject.GetComponent<int_PickableClothingPackage>() != (UnityEngine.Object) null)
            component2.EquipBtn.SetActive(true);
        }
        if ((UnityEngine.Object) componentInChildren != (UnityEngine.Object) null)
          component2.Title.text = "(" + componentInChildren.SellPrice.ToString() + "BN) " + component1.ThisStorage.StorageItems[index].name;
      }
      this.TraderBackPackAmount.text = Main.Instance.Player.CurrentBackpack.ThisStorage.StorageItems.Count.ToString() + "/" + Main.Instance.Player.CurrentBackpack.ThisStorage.StorageMax.ToString();
      num1 = Main.Instance.Player.CurrentBackpack.ThisStorage.StorageItems.Count;
    }
    else
      this.TraderBackPackAmount.text = "(None)";
    if ((UnityEngine.Object) Storage != (UnityEngine.Object) null)
    {
      if (Storage.StorageItems.Count == 0)
        Storage.GetComponent<RandomItemsInStorage>().ResetItems();
      for (int index = 0; index < Storage.StorageItems.Count; ++index)
      {
        misc_invItem component = UnityEngine.Object.Instantiate<GameObject>(this.TraderContainterEntry, this.TraderContainterEntry.transform.parent).GetComponent<misc_invItem>();
        this.TraderContainterEntries.Add(component.gameObject);
        component.ThisStorage = this.CurrentOpenStorage;
        component.ThisWeapomn = Storage.StorageItems[index];
        component.Title.text = Storage.StorageItems[index].name;
        component.gameObject.SetActive(true);
        int_ResourceItem componentInChildren = Storage.StorageItems[index].GetComponentInChildren<int_ResourceItem>(true);
        if ((UnityEngine.Object) componentInChildren == (UnityEngine.Object) null || (UnityEngine.Object) componentInChildren != (UnityEngine.Object) null && !componentInChildren.Sellable)
        {
          component.SendBtn.GetComponent<Button>().interactable = false;
        }
        else
        {
          component.Title.text = "(" + componentInChildren.BuyPrice.ToString() + "BN) " + Storage.StorageItems[index].name;
          if (Main.Instance.Player.Money < componentInChildren.BuyPrice)
            component.SendBtn.GetComponent<Button>().interactable = false;
        }
      }
      num2 = Storage.StorageItems.Count;
    }
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
    Main.Instance.MainThreads.Add(new Action(this.OpenedJournal));
    if (num1 > 0)
      this.TraderBackPackContent.sizeDelta = new Vector2(0.0f, (float) (num1 * 40 + 40));
    if (num2 <= 0)
      return;
    this.TraderContainterContent.sizeDelta = new Vector2(0.0f, (float) (num2 * 40 + 40));
  }

  public void CloseTrader()
  {
    this.AddMoneyBtn.SetActive(false);
    this.AddMoneyMenu.SetActive(false);
    this.TraderMenu.SetActive(false);
    this.CurrentOpenStorage = (Int_Storage) null;
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
    Main.Instance.Player.RemoveMoveBlocker("Container");
    if (Main.Instance.MainThreads.Contains(new Action(this.OpenedJournal)))
      Main.Instance.MainThreads.Remove(new Action(this.OpenedJournal));
    if ((UnityEngine.Object) this.CurrentOpenStorage != (UnityEngine.Object) null && (UnityEngine.Object) this.CurrentOpenStorage.Sound != (UnityEngine.Object) null && (UnityEngine.Object) this.CurrentOpenStorage.OpenSound != (UnityEngine.Object) null)
    {
      this.CurrentOpenStorage.Sound.clip = this.CurrentOpenStorage.CloseSound;
      this.CurrentOpenStorage.Sound.Play();
    }
    Main.Instance.GarbageCollect();
  }

  public void ShowNotification(string message)
  {
    bool flag = true;
    for (int index = 0; index < this.notifications.Count; ++index)
    {
      if (this.notifications[index] == message)
      {
        flag = false;
        break;
      }
    }
    if (flag)
      this.notifications.Add(message);
    if (this.currentNotificationIndex >= 0)
      return;
    this.ShowNextNotification();
  }

  private void ShowNextNotification()
  {
    ++this.currentNotificationIndex;
    if (this.currentNotificationIndex < this.notifications.Count)
    {
      this.NotificationText.text = this.notifications[this.currentNotificationIndex];
      this.NotifCanvasGroup.alpha = 0.0f;
      this.NotificationPanel.SetActive(true);
      this.currentCoroutine = (Coroutine) null;
      if (this.isActiveAndEnabled)
      {
        try
        {
          this.currentCoroutine = this.StartCoroutine(this.FadeInNotification());
        }
        catch
        {
        }
      }
      this.Invoke("HideNotification", 3f);
    }
    else
      this.currentNotificationIndex = -1;
  }

  public void HideNotification()
  {
    if (this.currentCoroutine != null)
      this.StopCoroutine(this.currentCoroutine);
    this.currentCoroutine = this.StartCoroutine(this.FadeOutNotification());
  }

  public void EmptyNotifs()
  {
    this.notifications.Clear();
    this.currentNotificationIndex = -1;
  }

  private IEnumerator FadeInNotification()
  {
    while ((double) this.NotifCanvasGroup.alpha < 1.0)
    {
      this.NotifCanvasGroup.alpha += Time.deltaTime / this.NotifFadeDuration;
      yield return (object) null;
    }
  }

  private IEnumerator FadeOutNotification()
  {
    while ((double) this.NotifCanvasGroup.alpha > 0.0)
    {
      this.NotifCanvasGroup.alpha -= Time.deltaTime / this.NotifFadeDuration;
      yield return (object) null;
    }
    this.NotificationPanel.SetActive(false);
    if (this.currentNotificationIndex >= this.notifications.Count - 1)
    {
      this.currentNotificationIndex = -1;
      this.notifications.Clear();
    }
    else
      this.ShowNextNotification();
  }

  public void Click_Resume() => this.CloseEscMenu();

  public void Click_CloseCantSave()
  {
    this.CantSaveMsg.SetActive(false);
    this.CantSaveMsg2.SetActive(false);
    this.CloseEscMenu();
  }

  public void Click_SaveGame()
  {
    if (!Main.Instance.CanSaveGame)
      return;
    Main.Instance.SaveGame();
    this.CloseEscMenu();
    Main.Instance.GameplayMenu.ShowNotification("Saved Game");
  }

  public void Click_ExitToMainMenu() => this.UnsavedWarning.SetActive(true);

  public void Click_ExitToMainMenu_Yes() => LoadingScene.LoadScene(1);

  public void Click_ExitToMainMenu_No() => this.UnsavedWarning.SetActive(false);

  public static string MetersToFeetAndInches(float meters)
  {
    double num = (double) meters * 39.370098114013672;
    return string.Format("{0}'{1}\"", (object) (int) (num / 12.0), (object) (int) (num % 12.0));
  }

  public void SelectRels()
  {
    this.CloseAllJournalMenus();
    this.Journal_Relationships.SetActive(true);
    for (int index = 0; index < this.MenuButtons.Length; ++index)
      this.MenuButtons[index].sprite = this.UnselectedButton;
    this.MenuButtons[6].sprite = this.SelectedButton;
    Main.Instance.MusicPlayer.PlayOneShot(this.JournalSound1);
    if (this.Relationships.Count == 0)
    {
      this.NoRels.SetActive(true);
    }
    else
    {
      this.NoRels.SetActive(false);
      for (int index = 0; index < this.RelsEntries.Count; ++index)
        UnityEngine.Object.Destroy((UnityEngine.Object) this.RelsEntries[index]);
      for (int index = 0; index < this.Relationships.Count; ++index)
      {
        GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.RelsEntry, this.RelsEntry.transform.parent);
        gameObject.transform.Find("text").GetComponent<Text>().text = this.Relationships[index].Name;
        gameObject.SetActive(true);
        gameObject.GetComponent<misc_OnClickDelegate>().i = index;
        this.RelsEntries.Add(gameObject);
      }
      this.RelsContent.sizeDelta = new Vector2(0.0f, (float) this.RelsEntries.Count * 21.8f);
      this.Rels_selectPErson(0);
    }
  }

  public void Click_retakepicture()
  {
    this.Relationships[this._SelectedRelsPerson].overrideProfilePic();
    this.Rels_selectPErson(this._SelectedRelsPerson);
  }

  public void Rels_selectPErson(int index)
  {
    if (this.Relationships.Count <= index)
      return;
    this._SelectedRelsPerson = index;
    Person relationship = this.Relationships[index];
    string str1 = Main.AssetsFolder + "/Saves/" + relationship.WorldSaveID + ".png";
    Texture2D texture = !File.Exists(str1) ? (Texture2D) UnityEngine.Object.FindObjectOfType<UI_LoadGame>(true).LoadSlotPrefab.GetComponentInChildren<Image>(true).mainTexture : UI_Gameplay.LoadTexture(str1);
    this.PersonPfp.sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, (float) texture.width, (float) texture.height), new Vector2(0.0f, 0.0f));
    string str2 = (relationship.Penis.transform.localScale.x * 10f).ToString("###") + "cm Penis";
    this.PositiveSlider.fillAmount = 0.0f;
    this.NegativeSlider.fillAmount = 0.0f;
    if (relationship.Favor > 0)
      this.PositiveSlider.fillAmount = (float) relationship.Favor / 100f;
    else
      this.NegativeSlider.fillAmount = (float) -relationship.Favor / 100f;
    string str3 = "None";
    if (relationship.Fetishes.Count > 0)
    {
      e_Fetish fetish = relationship.Fetishes[0];
      str3 = fetish.ToString();
      for (int index1 = 1; index1 < relationship.Fetishes.Count; ++index1)
      {
        string str4 = str3;
        fetish = relationship.Fetishes[index1];
        string str5 = fetish.ToString();
        str3 = str4 + ", " + str5;
      }
      if (!Main.Instance.ScatContent)
        str3 = str3.Replace("Scat", "*");
    }
    this.PersonDesc.text = relationship.Name + "\n\n" + (relationship is Girl ? "Female (" : "Male (") + ((UnityEngine.Object) relationship.PersonType != (UnityEngine.Object) null ? relationship.PersonType.ThisType.ToString() : "Classless") + ")\n" + relationship.Personality.ToString() + "\nSexed " + relationship.TimesSexedPlayer.ToString() + " times\n" + str3 + "\n" + (relationship.transform.localScale.y + 0.75f).ToString("##.##") + " Meters " + UI_Gameplay.MetersToFeetAndInches(relationship.transform.localScale.y + 0.75f) + "\n" + (relationship is Girl ? (((Girl) relationship).Futa ? str2 : "No Penis") : str2) + "\n" + (relationship is Girl ? "(" + ((double) relationship.StoryModeFertility == 0.0 ? (object) (relationship.Fertility * 100f).ToString("0.#") : (object) (float) ((double) relationship.StoryModeFertility * 100.0))?.ToString() + "% fertile) " + (((Girl) relationship).Pregnant ? "Pregnancy: " + ((Girl) relationship).PregnancyDisplayPercent : "Not Pregnant") : string.Empty) + "\n" + (relationship is Girl ? "Had " + ((Girl) relationship).HadPregnancies.ToString() + " Pregnancies" : string.Empty);
  }

  public static Texture2D LoadTexture(string FilePath)
  {
    if (File.Exists(FilePath))
    {
      byte[] data = File.ReadAllBytes(FilePath);
      Texture2D tex = new Texture2D(0, 0);
      if (tex.LoadImage(data))
        return tex;
    }
    return (Texture2D) null;
  }

  public void GoToOpenWorld_11() => this.GoToOpenWorld_Section(0);

  public void GoToOpenWorld_Section(int section)
  {
    Main.Instance.OpenWorld = true;
    GameObject gameObject = GameObject.Find("TempCube_OpenWorld (2)");
    if ((UnityEngine.Object) gameObject != (UnityEngine.Object) null)
      gameObject.SetActive(false);
    this._isLoadingASection = false;
    this._SetionLoading = section;
    Main.Instance.CanSaveFlags_add("GeneratingOW");
    Main.Instance.NewGameMenu.SmallLoading.SetActive(true);
    Main.Instance.NewGameMenu.ExtraLoading.SetActive(true);
    Main.Instance.MapAreas[0].LocalMusics[4] = Main.Instance.MapAreas[0].LocalMusics[3];
    if (Main.Instance.WorldSections.Count < this._SetionLoading)
      this._SetionLoading = 0;
    this._isLoadingASection = Main.Instance.WorldSections[this._SetionLoading].PreviouslyGenerated;
    Main.Instance.NewGameMenu.ExtraLoadingFirstTime.SetActive(!this._isLoadingASection);
    Main.Instance.NewGameMenu.ExtraLoadingSliderEpic.value = 0.0f;
    Main.Instance.NewGameMenu.ExtraLoadingSlider.value = 0.0f;
    Main.Instance.NewGameMenu.ExtraLoadingSlider.gameObject.SetActive(true);
    Main.Instance.NewGameMenu.ExtraLoadingSliderEpic = Main.Instance.NewGameMenu.ExtraLoadingSlider;
    Main.Instance.NewGameMenu.ExtraLoadingText.text = string.Empty;
    Main.Instance.NewGameMenu.ExtraLoadingTextTitle.text = "Despawning City";
    Main.RunInNextFrame((Action) (() =>
    {
      for (int index = 0; index < this.DisableOnOpenWorld.Count; ++index)
      {
        if ((UnityEngine.Object) this.DisableOnOpenWorld[index] != (UnityEngine.Object) null)
          UnityEngine.Object.Destroy((UnityEngine.Object) this.DisableOnOpenWorld[index]);
      }
      for (int index = 0; index < Main.Instance.SpawnedPeople.Count; ++index)
      {
        if ((UnityEngine.Object) Main.Instance.SpawnedPeople[index] != (UnityEngine.Object) null)
          Main.Instance.SpawnedPeople[index].gameObject.SetActive(false);
      }
      for (int index = 0; index < Main.Instance.SpawnedObjects.Count; ++index)
      {
        if ((UnityEngine.Object) Main.Instance.SpawnedObjects[index] != (UnityEngine.Object) null)
        {
          if ((UnityEngine.Object) Main.Instance.SpawnedObjects[index].RootObj != (UnityEngine.Object) null && (UnityEngine.Object) Main.Instance.SpawnedObjects[index].RootObj.transform.parent == (UnityEngine.Object) null)
            Main.Instance.SpawnedObjects[index].RootObj.SetActive(false);
          else if ((UnityEngine.Object) Main.Instance.SpawnedObjects[index].transform.parent == (UnityEngine.Object) null)
            Main.Instance.SpawnedObjects[index].gameObject.SetActive(false);
        }
      }
      for (int index = 0; index < Main.Instance.SpawnedPeople.Count; ++index)
      {
        if ((UnityEngine.Object) Main.Instance.SpawnedPeople[index] != (UnityEngine.Object) null && !Main.Instance.SpawnedPeople[index].IsPlayer)
          UnityEngine.Object.Destroy((UnityEngine.Object) Main.Instance.SpawnedPeople[index].gameObject);
      }
      for (int index = 0; index < Main.Instance.SpawnedObjects.Count; ++index)
      {
        if ((UnityEngine.Object) Main.Instance.SpawnedObjects[index] != (UnityEngine.Object) null)
        {
          if ((UnityEngine.Object) Main.Instance.SpawnedObjects[index].RootObj != (UnityEngine.Object) null && (UnityEngine.Object) Main.Instance.SpawnedObjects[index].RootObj.transform.parent == (UnityEngine.Object) null)
            UnityEngine.Object.Destroy((UnityEngine.Object) Main.Instance.SpawnedObjects[index].RootObj.gameObject);
          else if ((UnityEngine.Object) Main.Instance.SpawnedObjects[index].transform.parent == (UnityEngine.Object) null)
            UnityEngine.Object.Destroy((UnityEngine.Object) Main.Instance.SpawnedObjects[index].gameObject);
        }
      }
      foreach (SpawnedSexScene spawnedSexScene in UnityEngine.Object.FindObjectsOfType<SpawnedSexScene>())
        UnityEngine.Object.Destroy((UnityEngine.Object) spawnedSexScene.SpawnedSexSceneStructure.gameObject);
      Main.Instance.NewGameMenu.ExtraLoadingText.text = string.Empty;
      Main.Instance.NewGameMenu.ExtraLoadingTextTitle.text = "Loading Scene";
      Main.RunInNextFrame((Action) (() =>
      {
        SceneManager.LoadScene(5, LoadSceneMode.Additive);
        Main.Instance.NewGameMenu.ExtraLoadingText.text = string.Empty;
        Main.Instance.NewGameMenu.ExtraLoadingTextTitle.text = "Deciding Terrain";
        Main.RunInNextFrame((Action) (() =>
        {
          this.WorldGenerate2 = UnityEngine.Object.FindObjectOfType<bl_SectionGenerate2>();
          if ((UnityEngine.Object) this.WorldGenerate2 == (UnityEngine.Object) null)
          {
            Debug.LogError((object) "huh?");
          }
          else
          {
            if (this._isLoadingASection)
              return;
            UI_Gameplay.OWGenerating = true;
            this.StartCoroutine(this.WorldGenerate2.Generate(Vector3.zero, Main.Instance.WorldSections[0]));
            Main.Instance.MainThreads.Add(new Action(this.WaitingForGenerationThread));
          }
        }), 2);
      }), 3);
    }), 3);
  }

  public void WaitingForGenerationThread()
  {
    if (UI_Gameplay.OWGenerating)
      return;
    Main.Instance.MainThreads.Remove(new Action(this.WaitingForGenerationThread));
    if (this._isLoadingASection)
    {
      Main.Instance.NewGameMenu.ExtraLoadingText.text = string.Empty;
      Main.Instance.NewGameMenu.ExtraLoadingTextTitle.text = "Loading Navigation";
    }
    else
    {
      Main.Instance.NewGameMenu.ExtraLoadingText.text = "0/1";
      Main.Instance.NewGameMenu.ExtraLoadingTextTitle.text = "Generating Navigation";
    }
    Main.RunInNextFrame((Action) (() =>
    {
      Main.Instance.OnFinallyGenerate.Clear();
      Main.Instance.OnAfterFinallyGenerate.Clear();
      Main.Instance.OnFinallyGenerate.Add((Action) (() => this.OpenWorldAfterGenerateNav()));
      if (this._isLoadingASection)
      {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = File.Open(Main.Instance.CurrentSavePath + "Section_" + this._SetionLoading.ToString() + "/navmesh.dat", FileMode.Open);
        FileStream serializationStream = fileStream;
        NavMeshData navMeshData = (NavMeshData) binaryFormatter.Deserialize((Stream) serializationStream);
        fileStream.Close();
        if ((UnityEngine.Object) navMeshData != (UnityEngine.Object) null)
          NavMesh.AddNavMeshData(navMeshData);
        else
          Main.Instance.GenerateNav();
      }
      else
        Main.Instance.GenerateNav();
    }), 4);
  }

  public void Thread_GeneratingOWNav()
  {
    if (Main.GeneratingOWNav)
      return;
    Main.Instance.MainThreads.Remove(new Action(this.Thread_GeneratingOWNav));
    for (int index = 0; index < Main.Instance.OnFinallyGenerate.Count; ++index)
      Main.Instance.OnFinallyGenerate[index]();
    Main.Instance.OnFinallyGenerate.Clear();
    Main.RunInNextFrame((Action) (() =>
    {
      for (int index = 0; index < Main.Instance.OnAfterFinallyGenerate.Count; ++index)
        Main.Instance.OnAfterFinallyGenerate[index]();
      Main.Instance.OnAfterFinallyGenerate.Clear();
    }), 60);
  }

  public void OpenWorldAfterGenerateNav()
  {
    Main.Instance.NewGameMenu.SmallLoading.SetActive(false);
    Main.Instance.NewGameMenu.ExtraLoading.SetActive(false);
    Main.Instance.Player.gameObject.SetActive(true);
    Main.Instance.Player.FootStepsAudio.CurrentTerrain = e_CurrentTerrain.Dirt;
    for (int index = 0; index < bl_WorldStructure.WorldStructures.Count; ++index)
      bl_WorldStructure.WorldStructures[index].SpawnNPCs();
    Main.Instance.CanSaveFlags_remove("GeneratingOW");
  }

  public void GoToCity()
  {
    Debug.Log((object) "GoToCity()");
    Main.Instance.NewGameMenu.SmallLoading.SetActive(true);
  }

  public void GoToOpenWorld() => Main.Instance.Player.SaveOnThisPlay();

  public void Click_CloseOpenWorldMSG()
  {
    FirstPersonCharacter.AllowMouseCursor = false;
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
    this.OpenWorldUI.SetActive(false);
  }

  public void Click_YesGotoOpenWorld()
  {
    this.Click_CloseOpenWorldMSG();
    LoadingScene.LoadScene(2);
  }

  public void Click_YesGotoBLCity()
  {
    this.Click_CloseOpenWorldMSG();
    LoadingScene.LoadScene(1);
  }

  public void Click_SleepUntilMorning()
  {
    Main.Instance.DayCycle.cycleDuration = 2f;
    Main.Instance.DayCycle.enabled = true;
    Main.Instance.MainThreads.Add(new Action(this.CheckTimeSkip_forward));
    Main.Instance.GameplayMenu.SleepMenu.SetActive(false);
    Main.Instance.GameplayMenu.DisallowCursor();
  }

  public void Click_SleepUntilMidnight()
  {
    Main.Instance.DayCycle.cycleDuration = 2f;
    Main.Instance.DayCycle.enabled = true;
    Main.Instance.MainThreads.Add(new Action(this.CheckTimeSkip_night));
    Main.Instance.GameplayMenu.SleepMenu.SetActive(false);
    Main.Instance.GameplayMenu.DisallowCursor();
  }

  public void CheckTimeSkip_forward()
  {
    if (!Main.Instance.DayCycle.DayTimeObjectsEnabled)
      return;
    Main.Instance.DayCycle.timeOfDay = 0.95f;
    Main.Instance.Player.WakeUp();
    Main.Instance.MainThreads.Remove(new Action(this.CheckTimeSkip_forward));
  }

  public void CheckTimeSkip_night()
  {
    if (!Main.Instance.DayCycle.NightTimeObjectsEnabled)
      return;
    Main.Instance.DayCycle.timeOfDay = 0.4f;
    Main.Instance.Player.WakeUp();
    Main.Instance.MainThreads.Remove(new Action(this.CheckTimeSkip_night));
  }

  public void RefreshPerks()
  {
    misc_Perk[] objectsOfType = UnityEngine.Object.FindObjectsOfType<misc_Perk>(true);
    for (int index = 0; index < objectsOfType.Length; ++index)
    {
      if (Main.Instance.Player.Perks.Contains(objectsOfType[index].PerkID))
        objectsOfType[index].Unlock_NoUI();
    }
  }

  public void ShowNote()
  {
    this.NoteReader.SetActive(true);
    Main.Instance.GameplayMenu.AllowCursor();
    Main.Instance.Player.AddMoveBlocker("Reading");
  }

  public void HideNote()
  {
    this.NoteReader.SetActive(false);
    Main.Instance.GameplayMenu.DisallowCursor();
    Main.Instance.Player.RemoveMoveBlocker("Reading");
  }

  public void SelectMap()
  {
    this.CloseAllJournalMenus();
    this.Journal_Map.SetActive(true);
    for (int index = 0; index < this.MenuButtons.Length; ++index)
      this.MenuButtons[index].sprite = this.UnselectedButton;
    this.MenuButtons[9].sprite = this.SelectedButton;
    Main.Instance.MusicPlayer.PlayOneShot(this.JournalSound1);
    this.UpdateMapLocationFor(Main.Instance.Player.transform, (Transform) this.PlayerPosMap);
    this.UpdateMapLocationFor(this.MapTrackers[0], (Transform) this.MainMis_Green_PosMap);
    this.UpdateMapLocationFor(this.MapTrackers[1], (Transform) this.MainMis_Red_PosMap);
    this.UpdateMapLocationFor(this.MapTrackers[2], (Transform) this.MainMis_Blue_PosMap);
    this.UpdateMapLocationFor(this.MapTrackers[3], (Transform) this.SecondMis_White_PosMap);
  }

  public void UpdateMapLocationFor(Transform obj, Transform indicator)
  {
    if (!obj.gameObject.activeInHierarchy)
    {
      indicator.gameObject.SetActive(false);
    }
    else
    {
      indicator.gameObject.SetActive(true);
      Vector3 position = obj.position;
      Vector2 vector2 = new Vector2(Mathf.InverseLerp(this.WorldX.position.x, this.WorldY.position.x, position.x) * this.MapImage.rect.width, Mathf.InverseLerp(this.WorldX.position.z, this.WorldY.position.z, position.z) * this.MapImage.rect.height);
      indicator.localPosition = new Vector3(vector2.x, vector2.y, 0.0f);
      if (indicator.childCount <= 0)
        return;
      indicator.GetChild(0).GetComponent<Text>().text = obj.name;
    }
  }

  public void SelectCrafting()
  {
    this.CloseAllJournalMenus();
    this.Journal_Crafting.SetActive(true);
    for (int index = 0; index < this.MenuButtons.Length; ++index)
      this.MenuButtons[index].sprite = this.UnselectedButton;
    this.MenuButtons[7].sprite = this.SelectedButton;
    Main.Instance.MusicPlayer.PlayOneShot(this.JournalSound1);
    this.SelectedRecipe = 0;
    this.RefreshRecipes(0);
  }

  public void RefreshRecipes(int recipeType)
  {
    Main.Log(nameof (RefreshRecipes));
    this.SelectedRecipeType = recipeType;
    for (int index = 0; index < this.RecipeTypesImg.Length; ++index)
      this.RecipeTypesImg[index].color = Color.white;
    this.RecipeTypesImg[this.SelectedRecipeType].color = new Color(0.5f, 0.5f, 0.5f, 1f);
    for (int index = 0; index < this.SpawnedCraftRecipes.Count; ++index)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.SpawnedCraftRecipes[index]);
    this.SpawnedCraftRecipes.Clear();
    switch (recipeType)
    {
      case 0:
        Main.Instance.RecipesLoaded = Main.Instance.RecipesDressable;
        break;
      case 1:
        Main.Instance.RecipesLoaded = Main.Instance.RecipesDildo;
        break;
      case 2:
        Main.Instance.RecipesLoaded = Main.Instance.RecipesFood;
        break;
      case 3:
        Main.Instance.RecipesLoaded = Main.Instance.RecipesItems;
        break;
      case 4:
        Main.Instance.RecipesLoaded = Main.Instance.RecipesMisc;
        break;
    }
    for (int index = 0; index < Main.Instance.RecipesLoaded.Count; ++index)
    {
      GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.CraftRecipeEntry, this.CraftRecipeEntry.transform.parent);
      gameObject.SetActive(true);
      misc_invItem component = gameObject.GetComponent<misc_invItem>();
      component.ThisEntry = index;
      component.OnClick = new Action<int>(this.SelectRecipe);
      component.Title.text = Main.Instance.RecipesLoaded[index].Name.Split("\n", StringSplitOptions.None)[0];
      if (Main.Instance.RecipesLoaded[index].scat)
        gameObject.SetActive(Main.Instance.ScatContent);
      this.SpawnedCraftRecipes.Add(gameObject);
    }
    this.CraftList.sizeDelta = new Vector2(0.0f, (float) (this.SpawnedCraftRecipes.Count * 41));
    this.SelectRecipe(this.SelectedRecipe);
  }

  public void SelectRecipe(int index)
  {
    Main.Instance.MusicPlayer.PlayOneShot(this.JournalSound1);
    Main.Log("SelectRecipe " + index.ToString());
    this.SelectedRecipe = index < Main.Instance.RecipesLoaded.Count ? index : 0;
    for (int index1 = 0; index1 < this.SpawnedCraftRecipes.Count; ++index1)
      this.SpawnedCraftRecipes[index1].GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
    if (this.SpawnedCraftRecipes.Count == 0)
      return;
    this.SpawnedCraftRecipes[this.SelectedRecipe].GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
    for (int index2 = 0; index2 < this.SpawnedCraftRecipeEntries.Count; ++index2)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.SpawnedCraftRecipeEntries[index2]);
    this.SpawnedCraftRecipeEntries.Clear();
    for (int index3 = 0; index3 < this.SpawnedCraftItemEntries.Count; ++index3)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.SpawnedCraftItemEntries[index3]);
    this.SpawnedCraftItemEntries.Clear();
    this.TheSelectedReceipt = Main.Instance.RecipesLoaded[this.SelectedRecipe];
    this.SelectedReceiptMainTitle.text = this.TheSelectedReceipt.Name;
    this.NeededResearch.text = this.TheSelectedReceipt.ResearchNeeded.Length <= 0 ? string.Empty : "Needs: " + this.TheSelectedReceipt.ResearchNeeded;
    for (int index4 = 0; index4 < this.TheSelectedReceipt.Ingredients.Length; ++index4)
    {
      GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.CraftIngredientEntry, this.CraftIngredientEntry.transform.parent);
      gameObject.SetActive(true);
      misc_invItem component = gameObject.GetComponent<misc_invItem>();
      component.ThisEntry = index4;
      component.OnClick = new Action<int>(this.AutoItems);
      component.Title.text = this.TheSelectedReceipt.Ingredients[index4].IngredientType != e_ResourceType.Unique ? this.TheSelectedReceipt.Ingredients[index4].Amount.ToString() + "x " + this.TheSelectedReceipt.Ingredients[index4].IngredientType.ToString() : this.TheSelectedReceipt.Ingredients[index4].Amount.ToString() + "x " + this.TheSelectedReceipt.Ingredients[index4].Unique;
      this.SpawnedCraftRecipeEntries.Add(gameObject);
    }
    this.CraftIngredientList.sizeDelta = new Vector2(0.0f, (float) (this.SpawnedCraftRecipeEntries.Count * 41));
    this.PlayerItems.Clear();
    List<GameObject> gameObjectList = new List<GameObject>();
    if ((UnityEngine.Object) Main.Instance.Player.CurrentBackpack != (UnityEngine.Object) null)
      gameObjectList.AddRange((IEnumerable<GameObject>) Main.Instance.Player.CurrentBackpack.ThisStorage.StorageItems);
    if ((UnityEngine.Object) Main.Instance.Player.InventoryStorage != (UnityEngine.Object) null)
      gameObjectList.AddRange((IEnumerable<GameObject>) Main.Instance.Player.InventoryStorage.StorageItems);
    if ((UnityEngine.Object) Main.Instance.Player.Storage_Hands != (UnityEngine.Object) null)
      gameObjectList.AddRange((IEnumerable<GameObject>) Main.Instance.Player.Storage_Hands.StorageItems);
    if ((UnityEngine.Object) Main.Instance.Player.Storage_Vag != (UnityEngine.Object) null)
      gameObjectList.AddRange((IEnumerable<GameObject>) Main.Instance.Player.Storage_Vag.StorageItems);
    if ((UnityEngine.Object) Main.Instance.Player.Storage_Anal != (UnityEngine.Object) null)
      gameObjectList.AddRange((IEnumerable<GameObject>) Main.Instance.Player.Storage_Anal.StorageItems);
    for (int index5 = 0; index5 < gameObjectList.Count; ++index5)
    {
      if ((UnityEngine.Object) gameObjectList[index5].GetComponentInChildren<int_ResourceItem>() != (UnityEngine.Object) null)
        this.PlayerItems.Add(gameObjectList[index5]);
    }
    for (int index6 = 0; index6 < this.PlayerItems.Count; ++index6)
    {
      GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.CraftItemEntry, this.CraftItemEntry.transform.parent);
      gameObject.SetActive(true);
      int_ResourceItem componentInChildren = this.PlayerItems[index6].GetComponentInChildren<int_ResourceItem>();
      misc_toogleItem component = gameObject.GetComponent<misc_toogleItem>();
      component.TheText.text = (UnityEngine.Object) componentInChildren == (UnityEngine.Object) null ? this.PlayerItems[index6].name : "(" + componentInChildren.ResourceType.ToString() + ")" + this.PlayerItems[index6].name;
      component.Index = index6;
      component.TheAction = new Action<bool, int>(this.OnSelectItem);
      this.SpawnedCraftItemEntries.Add(gameObject);
    }
    this.CraftItemsList.sizeDelta = new Vector2(0.0f, (float) (this.SpawnedCraftItemEntries.Count * 24));
    this.SelectedItems.Clear();
    this.CheckCanCraft();
  }

  public void AutoItems(int index)
  {
    int num = 0;
    while (num < Main.Instance.RecipesLoaded[this.SelectedRecipe].Ingredients[index].Amount)
      ++num;
  }

  public void OnSelectItem(bool yes, int index)
  {
    Main.Instance.MusicPlayer.PlayOneShot(this.JournalSound1);
    Main.Log("OnSelectItem " + yes.ToString() + " " + index.ToString());
    if (yes)
      this.SelectedItems.Add(this.PlayerItems[index]);
    else
      this.SelectedItems.Remove(this.PlayerItems[index]);
    this.CheckCanCraft();
  }

  public void CheckCanCraft()
  {
    Main.Log(nameof (CheckCanCraft));
    List<GameObject> gameObjectList = new List<GameObject>();
    int num1 = 0;
    int num2 = 0;
    this.CraftButton.interactable = false;
    this.NeededResearch.color = Color.white;
    this.NeededResearch2.text = string.Empty;
    this.MissingItems.SetActive(false);
    this.Toomanyitmes.SetActive(false);
    this.NeedsBackpackLabel.text = string.Empty;
    gameObjectList.AddRange((IEnumerable<GameObject>) this.SelectedItems);
    for (int index1 = 0; index1 < Main.Instance.RecipesLoaded[this.SelectedRecipe].Ingredients.Length; ++index1)
    {
      num1 += Main.Instance.RecipesLoaded[this.SelectedRecipe].Ingredients[index1].Amount;
label_10:
      for (int index2 = 0; index2 < Main.Instance.RecipesLoaded[this.SelectedRecipe].Ingredients[index1].Amount; ++index2)
      {
        if (Main.Instance.RecipesLoaded[this.SelectedRecipe].Ingredients[index1].IngredientType == e_ResourceType.Unique)
        {
          for (int index3 = 0; index3 < gameObjectList.Count; ++index3)
          {
            if (gameObjectList[index3].name == Main.Instance.RecipesLoaded[this.SelectedRecipe].Ingredients[index1].Unique)
            {
              gameObjectList.RemoveAt(index3);
              ++num2;
              goto label_10;
            }
          }
          Main.Log("Unique item not found! " + Main.Instance.RecipesLoaded[this.SelectedRecipe].Ingredients[index1].Unique);
          goto label_26;
        }
      }
    }
    for (int index4 = 0; index4 < Main.Instance.RecipesLoaded[this.SelectedRecipe].Ingredients.Length; ++index4)
    {
label_23:
      for (int index5 = 0; index5 < Main.Instance.RecipesLoaded[this.SelectedRecipe].Ingredients[index4].Amount; ++index5)
      {
        if (Main.Instance.RecipesLoaded[this.SelectedRecipe].Ingredients[index4].IngredientType != e_ResourceType.Unique)
        {
          for (int index6 = 0; index6 < gameObjectList.Count; ++index6)
          {
            int_ResourceItem componentInChildren = gameObjectList[index6].GetComponentInChildren<int_ResourceItem>(true);
            if ((UnityEngine.Object) componentInChildren != (UnityEngine.Object) null && componentInChildren.ResourceType == Main.Instance.RecipesLoaded[this.SelectedRecipe].Ingredients[index4].IngredientType)
            {
              gameObjectList.RemoveAt(index6);
              ++num2;
              goto label_23;
            }
          }
          Main.Log("Type item not found! " + Main.Instance.RecipesLoaded[this.SelectedRecipe].Ingredients[index4].IngredientType.ToString());
          goto label_26;
        }
      }
    }
label_26:
    Main.Log("_itemsFound " + num2.ToString());
    Main.Log("_itemsToFind " + num1.ToString());
    if (num1 > 1)
    {
      int num3 = 1;
      if ((UnityEngine.Object) Main.Instance.Player.CurrentBackpack != (UnityEngine.Object) null)
        num3 += Main.Instance.Player.CurrentBackpack.ThisStorage.StorageMax;
      if (Main.Instance.Player.Perks.Contains("Vaginal Storage"))
        ++num3;
      if (Main.Instance.Player.Perks.Contains("Anal Storage"))
        ++num3;
      this.NeedsBackpackLabel.text = num3 >= num1 ? string.Empty : "Needs bigger Backpack!";
    }
    if (num2 == num1 && this.SelectedItems.Count == num1)
    {
      if (!Main.Instance.RecipesLoaded[this.SelectedRecipe].IsAvailableFor(Main.Instance.Player))
      {
        this.NeededResearch.color = Color.red;
        this.NeededResearch2.text = this.NeededResearch.text;
      }
      else
        this.CraftButton.interactable = true;
    }
    else if (this.SelectedItems.Count > num1)
    {
      this.Toomanyitmes.SetActive(true);
    }
    else
    {
      if (this.SelectedItems.Count == 0)
        return;
      this.MissingItems.SetActive(true);
    }
  }

  public void Click_Craft()
  {
    Main.Log(nameof (Click_Craft));
    this.CheckCanCraft();
    if (!this.CraftButton.interactable)
      return;
    for (int index = 0; index < this.SelectedItems.Count; ++index)
    {
      if ((UnityEngine.Object) Main.Instance.Player.CurrentBackpack != (UnityEngine.Object) null && Main.Instance.Player.CurrentBackpack.ThisStorage.StorageItems.Contains(this.SelectedItems[index]))
      {
        Main.Instance.Player.CurrentBackpack.ThisStorage.RemoveItem(this.SelectedItems[index]);
        UnityEngine.Object.Destroy((UnityEngine.Object) this.SelectedItems[index]);
      }
      else if ((UnityEngine.Object) Main.Instance.Player.InventoryStorage != (UnityEngine.Object) null && Main.Instance.Player.InventoryStorage.StorageItems.Contains(this.SelectedItems[index]))
      {
        Main.Instance.Player.InventoryStorage.RemoveItem(this.SelectedItems[index]);
        UnityEngine.Object.Destroy((UnityEngine.Object) this.SelectedItems[index]);
      }
      else if ((UnityEngine.Object) Main.Instance.Player.Storage_Hands != (UnityEngine.Object) null && Main.Instance.Player.Storage_Hands.StorageItems.Contains(this.SelectedItems[index]))
      {
        Main.Instance.Player.Storage_Hands.RemoveItem(this.SelectedItems[index]);
        UnityEngine.Object.Destroy((UnityEngine.Object) this.SelectedItems[index]);
      }
      else if ((UnityEngine.Object) Main.Instance.Player.Storage_Vag != (UnityEngine.Object) null && Main.Instance.Player.Storage_Vag.StorageItems.Contains(this.SelectedItems[index]))
      {
        Main.Instance.Player.Storage_Vag.RemoveItem(this.SelectedItems[index]);
        UnityEngine.Object.Destroy((UnityEngine.Object) this.SelectedItems[index]);
      }
      else if ((UnityEngine.Object) Main.Instance.Player.Storage_Anal != (UnityEngine.Object) null && Main.Instance.Player.Storage_Anal.StorageItems.Contains(this.SelectedItems[index]))
      {
        Main.Instance.Player.Storage_Anal.RemoveItem(this.SelectedItems[index]);
        UnityEngine.Object.Destroy((UnityEngine.Object) this.SelectedItems[index]);
      }
    }
    for (int index1 = 0; index1 < Main.Instance.RecipesLoaded[this.SelectedRecipe].OutCome.Length; ++index1)
    {
      GameObject prefab;
      for (int index2 = 0; index2 < Main.Instance.AllPrefabs.Count; ++index2)
      {
        if (Main.Instance.AllPrefabs[index2].name == Main.Instance.RecipesLoaded[this.SelectedRecipe].OutCome[index1])
        {
          prefab = Main.Instance.AllPrefabs[index2];
          goto label_26;
        }
      }
      for (int index3 = 0; index3 < Main.Instance.Prefabs_Weapons.Count; ++index3)
      {
        if (Main.Instance.Prefabs_Weapons[index3].name == Main.Instance.RecipesLoaded[this.SelectedRecipe].OutCome[index1])
        {
          prefab = Main.Instance.Prefabs_Weapons[index3].gameObject;
          goto label_26;
        }
      }
      Debug.LogError((object) ("Prefab not found:" + Main.Instance.RecipesLoaded[this.SelectedRecipe].OutCome[0]));
      break;
label_26:
      GameObject gameObject = Main.Spawn(prefab, saveable: true);
      gameObject.transform.position = Main.Instance.Player.transform.position + new Vector3(0.0f, 0.1f, 0.0f);
      if ((UnityEngine.Object) Main.Instance.Player.CurrentBackpack != (UnityEngine.Object) null && !Main.Instance.Player.CurrentBackpack.ThisStorage.Full)
      {
        Main.Instance.Player.CurrentBackpack.ThisStorage.AddItem(gameObject);
        Main.Instance.GameplayMenu.ShowNotification("Crafted: " + gameObject.name + " (Added to Backpack)");
      }
      else
        Main.Instance.GameplayMenu.ShowNotification("Crafted: " + gameObject.name);
      this.RefreshRecipes(this.SelectedRecipeType);
      Main.Instance.MusicPlayer.PlayOneShot(this.JournalPerkSound, 3f);
    }
  }

  public void Click_RecipeType(int index) => this.RefreshRecipes(index);

  public void Click_SkipToLatestMissions()
  {
    this.CloseEscMenu();
    this.OpenJournal();
    this.SelectMissions();
    this._ShowSkipMenu = !this._ShowSkipMenu;
    this.SkipToLatestMissions_Check.SetActive(this._ShowSkipMenu);
    this.SkipToLatestMissions2_Check.SetActive(false);
  }

  public void Click_SkipToLatestMissions2()
  {
    this.CloseEscMenu();
    this.OpenJournal();
    this.SelectMissions();
    this._ShowSkipMenu = !this._ShowSkipMenu;
    this.SkipToLatestMissions_Check.SetActive(false);
    this.SkipToLatestMissions2_Check.SetActive(this._ShowSkipMenu);
  }

  public void Click_Confirm_SkipToLatestMissions()
  {
    this.SkipToLatestMissions_Check.SetActive(false);
    this.SkipToLatestMissions2_Check.SetActive(false);
    this._ShowSkipMenu = false;
    this.CloseJournal();
    Mission allMission1 = Main.Instance.AllMissions[1];
    if (!allMission1.CompletedMission)
    {
      for (int goal = 0; goal < allMission1.Goals.Count; ++goal)
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
    }
    Mission allMission2 = Main.Instance.AllMissions[3];
    if (!allMission2.CompletedMission)
    {
      for (int goal = 0; goal < allMission2.Goals.Count; ++goal)
        allMission2.CompleteGoal(goal);
      allMission2.InitMission();
    }
    Mission allMission3 = Main.Instance.AllMissions[7];
    if (!allMission3.CompletedMission)
    {
      for (int goal = 0; goal < allMission3.Goals.Count; ++goal)
        allMission3.CompleteGoal(goal);
      allMission3.InitMission();
    }
    Mission allMission4 = Main.Instance.AllMissions[8];
    if (!allMission4.CompletedMission)
    {
      for (int goal = 0; goal < allMission4.Goals.Count; ++goal)
        allMission4.CompleteGoal(goal);
      allMission4.InitMission();
    }
    Main.Instance.AllMissions[8].CompleteMission();
    for (int index = 0; index < Main.Instance.GameplayMenu.DisableWhenMissionsSklipped.Length; ++index)
      Main.Instance.GameplayMenu.DisableWhenMissionsSklipped[index].SetActive(false);
  }

  public void Click_Confirm_SkipToLatestMissions2()
  {
    this.Click_Confirm_SkipToLatestMissions();
    Mission allMission1 = Main.Instance.AllMissions[11];
    if (!allMission1.CompletedMission)
    {
      for (int goal = 0; goal < allMission1.Goals.Count; ++goal)
        allMission1.CompleteGoal(goal);
      allMission1.InitMission();
    }
    Mission allMission2 = Main.Instance.AllMissions[10];
    if (!allMission2.CompletedMission)
    {
      for (int goal = 0; goal < allMission2.Goals.Count; ++goal)
        allMission2.CompleteGoal(goal);
      allMission2.InitMission();
    }
    Main.Instance.AllMissions[11].CompleteMission();
  }

  public void Click_SelectMissionFromGraph(int index)
  {
    Mission mission = (Mission) null;
    if (index != -1)
      mission = Main.Instance.AllMissions[index];
    this.Journal_ShowGoal(mission);
  }

  public void Click_SelectMissionsOf(int index)
  {
    this.Journal_ShowGoal((Mission) null);
    for (int index1 = 0; index1 < this.MissionsOf.Length; ++index1)
      this.MissionsOf[index1].SetActive(index1 == index);
    for (int index2 = 0; index2 < this.MissEntries.Count; ++index2)
    {
      if (this.MissEntries[index2].ThisMiss != -1)
      {
        Mission allMission = Main.Instance.AllMissions[this.MissEntries[index2].ThisMiss];
        if ((UnityEngine.Object) allMission != (UnityEngine.Object) null)
        {
          this.MissEntries[index2].Check.SetActive(allMission.CompletedMission);
          if (allMission.CompletedMission && this.MissEntries[index2].UncensoredText != null && this.MissEntries[index2].UncensoredText.Length > 1)
            this.MissEntries[index2].Title.text = this.MissEntries[index2].UncensoredText;
        }
      }
    }
  }

  public void Select_Building()
  {
    this.CloseAllJournalMenus();
    this.Journal_Building.SetActive(true);
    for (int index = 0; index < this.MenuButtons.Length; ++index)
      this.MenuButtons[index].sprite = this.UnselectedButton;
    this.MenuButtons[8].sprite = this.SelectedButton;
    Main.Instance.MusicPlayer.PlayOneShot(this.JournalSound1);
    this.Build_SelectedRecipe = 0;
    this.Build_RefreshRecipes(0);
  }

  public void Build_RefreshRecipes(int recipeType)
  {
    Main.Log(nameof (Build_RefreshRecipes));
    this.Build_SelectedRecipeType = recipeType;
    for (int index = 0; index < this.Build_RecipeTypesImg.Length; ++index)
      this.Build_RecipeTypesImg[index].color = Color.white;
    this.Build_RecipeTypesImg[this.Build_SelectedRecipeType].color = new Color(0.5f, 0.5f, 0.5f, 1f);
    for (int index = 0; index < this.Build_SpawnedCraftRecipes.Count; ++index)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.Build_SpawnedCraftRecipes[index]);
    this.Build_SpawnedCraftRecipes.Clear();
    switch (recipeType)
    {
      case 0:
        Main.Instance.BuildRecs_Loaded = Main.Instance.BuildRecs_Misc;
        break;
      case 1:
        Main.Instance.BuildRecs_Loaded = Main.Instance.BuildRecs_Presets;
        break;
      case 2:
        Main.Instance.BuildRecs_Loaded = Main.Instance.BuildRecs_Furniture;
        break;
      case 3:
        Main.Instance.BuildRecs_Loaded = Main.Instance.BuildRecs_SexFurniture;
        break;
      case 4:
        Main.Instance.BuildRecs_Loaded = Main.Instance.BuildRecs_Defence;
        break;
    }
    for (int index = 0; index < Main.Instance.BuildRecs_Loaded.Count; ++index)
    {
      GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Build_CraftRecipeEntry, this.Build_CraftRecipeEntry.transform.parent);
      gameObject.SetActive(true);
      misc_invItem component = gameObject.GetComponent<misc_invItem>();
      component.ThisEntry = index;
      component.OnClick = new Action<int>(this.Build_SelectRecipe);
      component.Title.text = Main.Instance.BuildRecs_Loaded[index].Name.Split("\n", StringSplitOptions.None)[0];
      if (Main.Instance.BuildRecs_Loaded[index].scat)
        gameObject.SetActive(Main.Instance.ScatContent);
      this.Build_SpawnedCraftRecipes.Add(gameObject);
    }
    this.Build_CraftList.sizeDelta = new Vector2(0.0f, (float) (this.Build_SpawnedCraftRecipes.Count * 41));
    this.Build_SelectRecipe(this.Build_SelectedRecipe);
  }

  public void Build_SelectRecipe(int index)
  {
    Main.Instance.MusicPlayer.PlayOneShot(this.JournalSound1);
    Main.Log("Build_SelectRecipe " + index.ToString());
    this.Build_SelectedRecipe = index < Main.Instance.BuildRecs_Loaded.Count ? index : 0;
    for (int index1 = 0; index1 < this.Build_SpawnedCraftRecipes.Count; ++index1)
      this.Build_SpawnedCraftRecipes[index1].GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
    if (this.Build_SpawnedCraftRecipes.Count == 0)
      return;
    this.Build_SpawnedCraftRecipes[this.Build_SelectedRecipe].GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
    for (int index2 = 0; index2 < this.Build_SpawnedCraftRecipeEntries.Count; ++index2)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.Build_SpawnedCraftRecipeEntries[index2]);
    this.Build_SpawnedCraftRecipeEntries.Clear();
    this.Build_TheSelectedReceipt = Main.Instance.BuildRecs_Loaded[this.Build_SelectedRecipe];
    this.Build_SelectedReceiptMainTitle.text = this.Build_TheSelectedReceipt.Name;
    this.Build_NeededResearch.text = this.Build_TheSelectedReceipt.ResearchNeeded.Length <= 0 ? string.Empty : "Needs: " + this.Build_TheSelectedReceipt.ResearchNeeded;
    for (int index3 = 0; index3 < this.Build_TheSelectedReceipt.Ingredients.Length; ++index3)
    {
      GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Build_CraftIngredientEntry, this.Build_CraftIngredientEntry.transform.parent);
      gameObject.SetActive(true);
      misc_invItem component = gameObject.GetComponent<misc_invItem>();
      component.ThisEntry = index3;
      component.OnClick = new Action<int>(this.AutoItems);
      component.Title.text = this.Build_TheSelectedReceipt.Ingredients[index3].IngredientType != e_ResourceType.Unique ? this.Build_TheSelectedReceipt.Ingredients[index3].Amount.ToString() + "x " + this.Build_TheSelectedReceipt.Ingredients[index3].IngredientType.ToString() : this.Build_TheSelectedReceipt.Ingredients[index3].Amount.ToString() + "x " + this.Build_TheSelectedReceipt.Ingredients[index3].Unique;
      this.Build_SpawnedCraftRecipeEntries.Add(gameObject);
    }
    this.Build_CraftIngredientList.sizeDelta = new Vector2(0.0f, (float) (this.Build_SpawnedCraftRecipeEntries.Count * 41));
    this.Build_CheckCanCraft();
  }

  public void Build_CheckCanCraft()
  {
  }

  public void Click_Build()
  {
    this.CloseJournal();
    for (int index = 0; index < Main.Instance.Prefabs_Plans.Count; ++index)
    {
      if (Main.Instance.Prefabs_Plans[index].name == this.Build_TheSelectedReceipt.OutCome[0])
      {
        this._BuildindPlan = Main.Spawn(Main.Instance.Prefabs_Plans[index]);
        this._BuildindPlan.GetComponentInChildren<Interactible>().AddBlocker("PlanPlacing");
        break;
      }
    }
    if ((UnityEngine.Object) this._BuildindPlan == (UnityEngine.Object) null)
    {
      Debug.LogError((object) ("build plan not found: " + this.Build_TheSelectedReceipt.OutCome[0]));
    }
    else
    {
      int_ConstructionPlan componentInChildren = this._BuildindPlan.GetComponentInChildren<int_ConstructionPlan>();
      this.ThisPlan = componentInChildren;
      if ((UnityEngine.Object) componentInChildren == (UnityEngine.Object) null)
      {
        Debug.LogError((object) ("Invalid Plan: " + this._BuildindPlan.name));
        UnityEngine.Object.Destroy((UnityEngine.Object) this._BuildindPlan);
      }
      else
      {
        componentInChildren.BeingMoved = true;
        componentInChildren.BuildFill.enabled = false;
        this.CurrentSnapType = componentInChildren.BuildSnapType;
        if (componentInChildren.BuildSnapType != int_ConstructionPlan.e_BuildSnapType.Disabled)
        {
          foreach (bl_ObjWithConstructionSnap constructionSnap in UnityEngine.Object.FindObjectsOfType<bl_ObjWithConstructionSnap>())
            constructionSnap.Show(componentInChildren.BuildSnapType);
        }
        Main.RunInNextFrame((Action) (() => Main.Instance.MainThreads.Add(new Action(this.BuildThread))), 5);
      }
    }
  }

  public void HideAllSnaps()
  {
    this._CurrentSnap = (bl_ConstructionSnapSpot) null;
    this.IsSnapping = false;
    this.CurrentSnapType = int_ConstructionPlan.e_BuildSnapType.Disabled;
    foreach (bl_ObjWithConstructionSnap constructionSnap in UnityEngine.Object.FindObjectsOfType<bl_ObjWithConstructionSnap>())
      constructionSnap.Hide();
  }

  public bool CanBuild
  {
    get => this._CanBuild;
    set
    {
      this._CanBuild = value;
      this.MenuButtons[8].GetComponentInChildren<Button>().interactable = value;
    }
  }

  public void BuildThread()
  {
    bool flag = true;
    RaycastHit hitInfo;
    if (Physics.Raycast(Main.Instance.Player.WeaponInv.transform.position, Main.Instance.Player.WeaponInv.transform.TransformDirection(Vector3.forward), out hitInfo, 10f, (int) this.PlacePlanLayers, QueryTriggerInteraction.Collide))
    {
      if (hitInfo.transform.tag == "NoBuild")
      {
        flag = false;
      }
      else
      {
        this._CurrentSnap = hitInfo.transform.GetComponent<bl_ConstructionSnapSpot>();
        if ((UnityEngine.Object) this._CurrentSnap != (UnityEngine.Object) null)
        {
          if (this.CurrentSnapType == int_ConstructionPlan.e_BuildSnapType.Floor)
          {
            this.IsSnapping = true;
            this._BuildindPlan.transform.position = this._CurrentSnap.Spot_Floor.position;
            this._BuildindPlan.transform.rotation = this._CurrentSnap.Spot_Floor.rotation;
            if (Input.GetKeyUp(KeyCode.LeftAlt))
            {
              ++this.SelectedPlanRotation;
              if (this.SelectedPlanRotation > 3)
                this.SelectedPlanRotation = 0;
            }
            this._BuildindPlan.transform.eulerAngles = new Vector3(this._BuildindPlan.transform.eulerAngles.x, this._BuildindPlan.transform.eulerAngles.y + (float) (90 * this.SelectedPlanRotation), this._BuildindPlan.transform.eulerAngles.z);
          }
          else
          {
            this.IsSnapping = true;
            this._BuildindPlan.transform.position = this._CurrentSnap.Spot_Wall.position;
            this._BuildindPlan.transform.rotation = this._CurrentSnap.Spot_Wall.rotation;
            if (Input.GetKeyUp(KeyCode.LeftAlt))
            {
              ++this.SelectedPlanRotation;
              if (this.SelectedPlanRotation > 3)
                this.SelectedPlanRotation = 0;
            }
            this._BuildindPlan.transform.eulerAngles = new Vector3(this._BuildindPlan.transform.eulerAngles.x, this._BuildindPlan.transform.eulerAngles.y + (float) (90 * this.SelectedPlanRotation), this._BuildindPlan.transform.eulerAngles.z);
          }
        }
        else
        {
          this._CurrentSnap = (bl_ConstructionSnapSpot) null;
          this.IsSnapping = false;
          this._BuildindPlan.transform.position = hitInfo.point;
          if ((UnityEngine.Object) this.ThisPlan != (UnityEngine.Object) null && this.ThisPlan.Foundation)
          {
            bl_WorldChunk component = hitInfo.transform.GetComponent<bl_WorldChunk>();
            if ((UnityEngine.Object) component != (UnityEngine.Object) null && component.CanUseFoundations)
              this._BuildindPlan.transform.position = new Vector3(hitInfo.point.x, component.transform.position.y + this.ThisPlan.ExtraBuildHeight, hitInfo.point.z);
          }
          if (Input.GetKey(KeyCode.LeftAlt))
            this._BuildindPlan.transform.eulerAngles = new Vector3(this._BuildindPlan.transform.eulerAngles.x, Main.Instance.PlayerCam.transform.eulerAngles.y, this._BuildindPlan.transform.eulerAngles.z);
        }
      }
    }
    else
    {
      this._CurrentSnap = (bl_ConstructionSnapSpot) null;
      this.IsSnapping = false;
      flag = false;
    }
    if (Main.Instance.CancelKey() || Input.GetMouseButtonUp(UI_Settings.RightMouseButton))
    {
      Main.Instance.MainThreads.Remove(new Action(this.BuildThread));
      UnityEngine.Object.Destroy((UnityEngine.Object) this._BuildindPlan);
      this._BuildindPlan = (GameObject) null;
      this.HideAllSnaps();
    }
    if (!flag || !Input.GetKeyUp(KeyCode.E) && !Input.GetKeyUp(KeyCode.F) && !Input.GetKeyUp(KeyCode.KeypadEnter) && !Input.GetKeyUp(KeyCode.Return) && !Input.GetMouseButtonUp(UI_Settings.LeftMouseButton))
      return;
    this.PlacePlan(this._BuildindPlan);
  }

  public void PlacePlan(GameObject obj)
  {
    int_ConstructionPlan componentInChildren = this._BuildindPlan.GetComponentInChildren<int_ConstructionPlan>();
    this._BuildindPlan.GetComponentInChildren<bl_ObjWithConstructionSnap>();
    bool _placeAnother = false;
    if (this.IsSnapping)
    {
      int currentSnapType = (int) this.CurrentSnapType;
    }
    _placeAnother = componentInChildren.PlanAnotherAfter;
    componentInChildren.BeingMoved = false;
    componentInChildren.GetPlaced();
    this.ThisPlan = (int_ConstructionPlan) null;
    this._BuildindPlan = (GameObject) null;
    Main.Instance.MainThreads.Remove(new Action(this.BuildThread));
    this.HideAllSnaps();
    Main.RunInNextFrame((Action) (() =>
    {
      obj.GetComponentInChildren<Interactible>().RemoveBlocker("PlanPlacing");
      this.LatestPlacedPlan = obj;
      if (_placeAnother)
        this.Click_Build();
      else
        this.SelectedPlanRotation = 0;
    }), 5);
  }

  public void CancelThisPlan()
  {
    int_ConstructionPlan currentOpenStorage = this.CurrentOpenStorage as int_ConstructionPlan;
    currentOpenStorage.RemoveAllItems();
    this.CloseStorage();
    UnityEngine.Object.Destroy((UnityEngine.Object) currentOpenStorage.RootObj.gameObject);
  }

  public void SpeedrunThread()
  {
    this.SpeedrunTimer += Time.deltaTime;
    this.SpeedrunLabel.text = string.Format("{0:00}:{1:00}:{2:00}", (object) Mathf.FloorToInt(this.SpeedrunTimer / 3600f), (object) Mathf.FloorToInt((float) ((double) this.SpeedrunTimer % 3600.0 / 60.0)), (object) Mathf.FloorToInt(this.SpeedrunTimer % 60f));
    switch (UI_Settings._SpeedrunValue)
    {
      case 3:
        if (Main.Instance.Player.Money < 1000)
          break;
        Main.Instance.NewGameMenu.SmallLoading.SetActive(true);
        Main.Instance.MainThreads.Remove(new Action(this.SpeedrunThread));
        UI_Settings._SpeedrunValue = 0;
        float num = PlayerPrefs.GetFloat("Speedrun_3_f");
        if ((double) num == 0.0 || (double) num > (double) Main.Instance.GameplayMenu.SpeedrunTimer)
        {
          PlayerPrefs.SetFloat("Speedrun_3_f", Main.Instance.GameplayMenu.SpeedrunTimer);
          PlayerPrefs.SetString("Speedrun_3", Main.Instance.GameplayMenu.SpeedrunLabel.text);
        }
        Main.RunInNextFrame((Action) (() => SceneManager.LoadScene(1)), 5);
        break;
    }
  }
}
