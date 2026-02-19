// Decompiled with JetBrains decompiler
// Type: Main
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityStandardAssets.Cameras;

#nullable disable
public class Main : MonoBehaviour
{
  public const string BuildVersion = "10.e";
  public const string BuildVersionInt = "10";
  public const string BuildExpireDate = "2026/01/01";
  public static bool DebugLog;
  public static Main Instance;
  public bool FirstRunThisVersion;
  public KeyCode[] KeyBinds;
  public BaseType[] PersonTypes;
  public GameObject PersonPrefab;
  public GameObject PersonGuyPrefab;
  public GameObject PersonGuy2Prefab;
  public MonoBehaviour Nav;
  public GameObject PreloadCam;
  public UI_Gameplay GameplayMenu;
  public UI_NewGame NewGameMenu;
  public UI_Customize CustomizeMenu;
  public UI_Inventory InventoryMenu;
  public UI_SexScene SexScene;
  public UI_Settings SettingsMenu;
  public UI_LoadCustomNPC LoadCustomNPCMenu;
  public bl_LipSync LipSync;
  public Transform DisabledObjects;
  public RuntimeAnimatorController OrgPlayerController;
  public RuntimeAnimatorController PregPlayerController;
  public RuntimeAnimatorController NPCController;
  public Shader StandardShader;
  public Shader DoubleSidedStandardShader;
  public Camera MainMenuCam;
  public Camera PlayerCam;
  public GameObject PostProcessingCam;
  public AudioSource GlobalAudio;
  public Sprite[] PromptIcons;
  public Sprite[] GoalIcons;
  public string[] DoorKeysNames;
  public Texture[] ESB_markings;
  public Texture[] BL_markings;
  public Texture2D[] Tex_BodySkin;
  public Texture2D[] Tex_FaceSkin;
  public Texture2D Inv1k;
  public Main.bl_Dictionary<string, Texture2D> TexBody_Container2 = new Main.bl_Dictionary<string, Texture2D>();
  public Main.bl_Dictionary<string, Texture2D> TexFace_Container2 = new Main.bl_Dictionary<string, Texture2D>();
  public Main.bl_Dictionary<string, Texture2D> TexBody_ContainerCustom = new Main.bl_Dictionary<string, Texture2D>();
  public Main.bl_Dictionary<string, Texture2D> TexFace_ContainerCustom = new Main.bl_Dictionary<string, Texture2D>();
  public Person.BL_State[] States_Data;
  public Texture[] NeonSignsTextures;
  public List<PersonBlendShapeData> BlendShapesDatas = new List<PersonBlendShapeData>();
  public GameObject SquirtPrefab;
  public GameObject PissPrefab;
  public Material PenisMat;
  public Material StraponMat;
  public bool LoadedGame;
  public bl_Personality[] Personalities;
  public List<string> _CustomBodySkinsName = new List<string>();
  public List<Texture2D> _CustomBodySkins = new List<Texture2D>();
  public List<string> _CustomFaceSkinsName = new List<string>();
  public List<Texture2D> _CustomFaceSkins = new List<Texture2D>();
  public static byte[] OnePixel = new byte[120]
  {
    (byte) 137,
    (byte) 80 /*0x50*/,
    (byte) 78,
    (byte) 71,
    (byte) 13,
    (byte) 10,
    (byte) 26,
    (byte) 10,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 13,
    (byte) 73,
    (byte) 72,
    (byte) 68,
    (byte) 82,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 1,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 1,
    (byte) 8,
    (byte) 6,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 31 /*0x1F*/,
    (byte) 21,
    (byte) 196,
    (byte) 137,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 1,
    (byte) 115,
    (byte) 82,
    (byte) 71,
    (byte) 66,
    (byte) 0,
    (byte) 174,
    (byte) 206,
    (byte) 28,
    (byte) 233,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 4,
    (byte) 103,
    (byte) 65,
    (byte) 77,
    (byte) 65,
    (byte) 0,
    (byte) 0,
    (byte) 177,
    (byte) 143,
    (byte) 11,
    (byte) 252,
    (byte) 97,
    (byte) 5,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 9,
    (byte) 112 /*0x70*/,
    (byte) 72,
    (byte) 89,
    (byte) 115,
    (byte) 0,
    (byte) 0,
    (byte) 14,
    (byte) 195,
    (byte) 0,
    (byte) 0,
    (byte) 14,
    (byte) 195,
    (byte) 1,
    (byte) 199,
    (byte) 111,
    (byte) 168,
    (byte) 100,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 13,
    (byte) 73,
    (byte) 68,
    (byte) 65,
    (byte) 84,
    (byte) 24,
    (byte) 87,
    (byte) 99,
    (byte) 248,
    byte.MaxValue,
    byte.MaxValue,
    byte.MaxValue,
    (byte) 127 /*0x7F*/,
    (byte) 0,
    (byte) 9,
    (byte) 251,
    (byte) 3,
    (byte) 253,
    (byte) 5,
    (byte) 67,
    (byte) 69,
    (byte) 202,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 73,
    (byte) 69,
    (byte) 78,
    (byte) 68,
    (byte) 174,
    (byte) 66,
    (byte) 96 /*0x60*/,
    (byte) 130
  };
  public List<string> FemaleNames = new List<string>();
  public List<string> MaleNames = new List<string>();
  public string[] consonants;
  public string[] vowels;
  public bool MoansEnabled;
  public bool PhysicsAllEnabled;
  public bool PhysicsSexEnabled;
  public bool FreeWorldPatch;
  public GameObject[] ScatContentToDisable;
  public GameObject ScatContentRoot;
  public bool _ScatContent;
  public bool _FetishChas;
  public BL_MapArea CurrentArea;
  public LayerMask VisionLayerMaskWithoutPlayer;
  public LayerMask VisionLayerMask;
  public LayerMask CullLayerMask;
  public AudioSource MusicPlayer;
  public List<GameObject> Prefabs_Plans = new List<GameObject>();
  public List<GameObject> AllPrefabs = new List<GameObject>();
  public GameObject Feet;
  public List<GameObject> Prefabs_Any = new List<GameObject>();
  public List<GameObject> Prefabs_Shoes = new List<GameObject>();
  public List<GameObject> Prefabs_Pants = new List<GameObject>();
  public List<GameObject> Prefabs_Top = new List<GameObject>();
  public List<GameObject> Prefabs_UnderwearTop = new List<GameObject>();
  public List<GameObject> Prefabs_UnderwearLower = new List<GameObject>();
  public List<GameObject> Prefabs_Garter = new List<GameObject>();
  public List<GameObject> Prefabs_Socks = new List<GameObject>();
  public List<GameObject> Prefabs_Hat = new List<GameObject>();
  public List<GameObject> Prefabs_Hair = new List<GameObject>();
  public List<GameObject> Prefabs_MaleHair = new List<GameObject>();
  public List<GameObject> Prefabs_Bodies = new List<GameObject>();
  public List<GameObject> Prefabs_Heads = new List<GameObject>();
  public List<GameObject> Prefabs_Beards = new List<GameObject>();
  public List<Weapon> Prefabs_Weapons = new List<Weapon>();
  public Color[] NaturalEyeColors;
  public Color[] NaturalHairColors;
  public Color[] NaturalSkinColors;
  public Mesh HighPoly_Body;
  public Mesh LowPoly_Body;
  public Material EyeMat;
  public GameObject Lights;
  public Transform MainSunLight;
  public Person Player;
  public Person MalePlayer;
  public Person MalePlayer2;
  public List<Person> PeopleFollowingPlayer = new List<Person>();
  public string[] Fem_Chair_sit_idles;
  public string[] Male_Chair_sit_idles;
  public List<GameObject> Prefabs_ProstSuit1 = new List<GameObject>();
  public List<GameObject> Prefabs_ProstSuit2 = new List<GameObject>();
  public BL_MapArea CapturedBuilding1_Area;
  public BL_MapArea Default_Area;
  public BL_MapArea Home_Area;
  public List<BL_MapArea> MapAreas = new List<BL_MapArea>();
  public List<Mission> AllMissions = new List<Mission>();
  public GameObject PileOfScat;
  public List<GameObject> PileOfScats = new List<GameObject>();
  public List<GameObject> PileOfScatsGoos = new List<GameObject>();
  public List<Transform> OrgPlayerWakeupPlaces = new List<Transform>();
  public List<Transform> PlayerWakeupPlaces = new List<Transform>();
  public List<GameObject> AddableItemsWhenSlumWake = new List<GameObject>();
  public List<GameObject> AddableClothesWhenSlumWake = new List<GameObject>();
  public AudioClip DoorClose;
  public AudioClip DoorMove;
  public AudioClip DoorLock;
  public AudioClip DoorLocked;
  public AudioClip DoorUnLock;
  public AudioClip[] SearchTrashSounds;
  public AudioClip[] PunchSounds;
  public AudioClip[] PunchMissSounds;
  public AudioClip[] MeleeHitSounds;
  public AudioClip[] FemaleForcedStart;
  public AudioClip[] FemaleMoans;
  public AudioClip[] FemaleSleepingMoans;
  public AudioClip[] MaleMoans;
  public AudioClip[] MeatSlapSounds;
  public AudioClip[] SuccSounds;
  public Transform Clinic;
  public bl_CityCharacters CityCharacters;
  public DayNightCycle DayCycle;
  public Main.bl_Dictionary<string, string> GlobalVars = new Main.bl_Dictionary<string, string>();
  public List<bl_HangZone> PossibleStreetHomes = new List<bl_HangZone>();
  public List<bl_HangZone> PossibleHomes = new List<bl_HangZone>();
  [Header("   random face")]
  public Main.RandomFaceRange RangeHead;
  public Main.RandomFaceRange RangeMouthBase;
  public Main.RandomFaceRange RangeMouthSides;
  public Main.RandomFaceRange RangeMouthTop;
  public Main.RandomFaceRange RangeMouthBottom;
  public Main.RandomFaceRange RangeCheeksLow;
  public Main.RandomFaceRange RangeCheeksUp;
  public Main.RandomFaceRange RangeJaw;
  public Main.RandomFaceRange RangeJawLow;
  public Main.RandomFaceRange RangeChin;
  public Main.RandomFaceRange RangeEars;
  public Main.RandomFaceRange RangeEarsLow;
  public Main.RandomFaceRange RangeEarsHigh;
  public Main.RandomFaceRange RangeNose;
  public Main.RandomFaceRange RangeNoseBridge;
  public Main.RandomFaceRange RangeNoseTip;
  public Main.RandomFaceRange RangeNostrils;
  public Main.RandomFaceRange RangeEyes;
  public Main.RandomFaceRange RangeEyesTop;
  public Main.RandomFaceRange RangeEyesLow;
  public Main.RandomFaceRange RangeEyesInner;
  public Main.RandomFaceRange RangeEyesOuter;
  [Header("   random body")]
  public Main.RandomFaceRange RangeBoobs;
  public Main.RandomFaceRange RangeNips;
  public Main.RandomFaceRange RangeAss;
  public Main.RandomFaceRange RangeHips;
  public Main.RandomFaceRange RangeHips2;
  public Main.RandomFaceRange RangeBelly;
  public Main.RandomFaceRange RangeWaist;
  public Main.RandomFaceRange RangeRibcage;
  public Main.RandomFaceRange RangeTorso;
  public Main.RandomFaceRange RangeNeck;
  public Main.RandomFaceRange RangeUpperThighs;
  public Main.RandomFaceRange RangeMidThighs;
  public Main.RandomFaceRange RangeLowerThighs;
  public Main.RandomFaceRange RangeCalves;
  public Main.RandomFaceRange RangeFeet;
  public Main.RandomFaceRange RangeShoulders;
  public Main.RandomFaceRange RangeUpperArms;
  public Main.RandomFaceRange RangeForeArms;
  public Main.RandomFaceRange RangeHands;
  [Header("   random guy face")]
  public Main.RandomFaceRange MaleRangeHead;
  public Main.RandomFaceRange MaleRangeMouth;
  public Main.RandomFaceRange MaleRangeJaw;
  public Main.RandomFaceRange MaleRangeChin;
  public Main.RandomFaceRange MaleRangeNose;
  public Main.RandomFaceRange MaleRangeEyes;
  [Header("   random guy body")]
  [Header("   mats")]
  public Material MatBody;
  public Material MatHead;
  public Material MatEyePupil;
  public Material MatEyeBack;
  public Material MatLash;
  public Material MatThong;
  public Material MatTeeth;
  public Material MaleMatBody;
  public Material MaleMatHead;
  public Material InvMat;
  public Material MatMale2Head;
  public Material MatMale2Lash;
  [Header("   -")]
  public float DayHour;
  public float SkyRot;
  public Material Sky;
  public bool NavGenerated;
  public List<Action> OnFinallyGenerate = new List<Action>();
  public List<Action> OnAfterFinallyGenerate = new List<Action>();
  public List<Action> OnAfterSpawnPeople = new List<Action>();
  public List<Func<Person, int>> OnNpcGenerate = new List<Func<Person, int>>();
  public string StartOnMenu;
  public bool OpenWorld;
  public List<Action> MainThreads = new List<Action>();
  public bool MusicInCombat;
  public float MusicTimer;
  public int Seconds;
  public float Second;
  public bool AutosaveEnable = true;
  public float AutoSaveTimer;
  public float AutoSaveTimerMax = 120f;
  public int _waitedFrames;
  public List<Transform> StaticRoots = new List<Transform>();
  public List<UI_Menu> Menus = new List<UI_Menu>();
  public List<string[]> PlayerData = new List<string[]>();
  public List<Person> SpawnedPeople = new List<Person>();
  public List<SaveableBehaviour> SpawnedObjects = new List<SaveableBehaviour>();
  public List<Person> SpawnedPopulation = new List<Person>();
  public List<GameObject> EnableAfterSave = new List<GameObject>();
  public List<List<Person>> SpawnedPeopleOfType = new List<List<Person>>();
  public string CurrentSavePath;
  public List<string> _CanSaveFlags = new List<string>();
  public static bool LoadMedFromHard;
  public static bool LoadMedFromHard_Escape;
  public List<Mission> _MissionsToinit = new List<Mission>();
  public List<Main.RegisteredCustomBundle> RegisteredCustomBundles = new List<Main.RegisteredCustomBundle>();
  public List<bl_WorkJobManager> AllJobs = new List<bl_WorkJobManager>();
  public List<bl_HangZone> AllHomes = new List<bl_HangZone>();
  public string[] _AllTextLines;
  public int _AllTextLinesStart;
  public GameObject TempStraponPanties;
  [Obsolete]
  public List<bl_CraftRecipes> AllCraftRecipes = new List<bl_CraftRecipes>();
  public List<bl_CraftRecipes> RecipesDressable = new List<bl_CraftRecipes>();
  public List<bl_CraftRecipes> RecipesDildo = new List<bl_CraftRecipes>();
  public List<bl_CraftRecipes> RecipesFood = new List<bl_CraftRecipes>();
  public List<bl_CraftRecipes> RecipesMisc = new List<bl_CraftRecipes>();
  public List<bl_CraftRecipes> RecipesItems = new List<bl_CraftRecipes>();
  public List<bl_CraftRecipes> RecipesLoaded;
  public int SafeIVal;
  public float SafeFVal;
  public int _FSFrameCounter;
  public List<AudioClip> ShitSounds = new List<AudioClip>();
  public static bool AlreadyStartedCombat;
  public List<bl_CraftRecipes> BuildRecs_Misc = new List<bl_CraftRecipes>();
  public List<bl_CraftRecipes> BuildRecs_Sex = new List<bl_CraftRecipes>();
  public List<bl_CraftRecipes> BuildRecs_Food = new List<bl_CraftRecipes>();
  public List<bl_CraftRecipes> BuildRecs_Items = new List<bl_CraftRecipes>();
  public List<bl_CraftRecipes> BuildRecs_Defence = new List<bl_CraftRecipes>();
  public List<bl_CraftRecipes> BuildRecs_Loaded;

  public static void Log(string text, bool error = false)
  {
    if (!Main.DebugLog)
      return;
    if (error)
      Debug.LogError((object) text);
    else
      Debug.Log((object) text);
    File.AppendAllText(Main.AssetsFolder + "/debuglog.txt", text + "\n");
  }

  public static string AssetsFolder => Application.dataPath + "/../Assets";

  public void GetCustomTextures()
  {
    this._CustomBodySkinsName.Clear();
    string[] files1 = Directory.GetFiles(Main.AssetsFolder + "/CustomTextures/Body", "*.png");
    int index1;
    for (index1 = 0; index1 < files1.Length; ++index1)
    {
      if (this._CustomBodySkins.Count - 1 <= index1)
        this._CustomBodySkins.Add(new Texture2D(0, 0));
      this._CustomBodySkins[index1].LoadImage(File.ReadAllBytes(files1[index1]));
      if (this._CustomBodySkins[index1].width != 2048 /*0x0800*/ || this._CustomBodySkins[index1].height != 2048 /*0x0800*/)
      {
        Texture2D texture2D = this.ResizeTexture(this._CustomBodySkins[index1], 2048 /*0x0800*/, 2048 /*0x0800*/);
        this._CustomBodySkins[index1].LoadImage(Main.OnePixel);
        this._CustomBodySkins[index1] = texture2D;
      }
      this._CustomBodySkinsName.Add(Path.GetFileNameWithoutExtension(files1[index1]));
    }
    for (; index1 < this._CustomBodySkins.Count; ++index1)
      this._CustomBodySkins[index1].LoadImage(Main.OnePixel);
    this._CustomFaceSkinsName.Clear();
    string[] files2 = Directory.GetFiles(Main.AssetsFolder + "/CustomTextures/Face", "*.png");
    int index2;
    for (index2 = 0; index2 < files2.Length; ++index2)
    {
      if (this._CustomFaceSkins.Count - 1 <= index2)
        this._CustomFaceSkins.Add(new Texture2D(0, 0));
      this._CustomFaceSkins[index2].LoadImage(File.ReadAllBytes(files2[index2]));
      if (this._CustomFaceSkins[index2].width != 1024 /*0x0400*/ || this._CustomFaceSkins[index2].height != 1024 /*0x0400*/)
      {
        Texture2D texture2D = this.ResizeTexture(this._CustomFaceSkins[index2], 1024 /*0x0400*/, 1024 /*0x0400*/);
        this._CustomFaceSkins[index2].LoadImage(Main.OnePixel);
        this._CustomFaceSkins[index2] = texture2D;
      }
      this._CustomFaceSkinsName.Add(Path.GetFileNameWithoutExtension(files2[index2]));
    }
    for (; index2 < this._CustomFaceSkins.Count; ++index2)
      this._CustomFaceSkins[index2].LoadImage(Main.OnePixel);
  }

  public Texture2D ResizeTexture(Texture2D original, int newWidth, int newHeight)
  {
    Texture2D texture2D = new Texture2D(newWidth, newHeight, original.format, false);
    Color[] colors = new Color[newWidth * newHeight];
    float num1 = (float) original.width / (float) newWidth;
    float num2 = (float) original.height / (float) newHeight;
    for (int index1 = 0; index1 < newHeight; ++index1)
    {
      for (int index2 = 0; index2 < newWidth; ++index2)
      {
        int x = Mathf.FloorToInt((float) index2 * num1);
        int y = Mathf.FloorToInt((float) index1 * num2);
        colors[index1 * newWidth + index2] = original.GetPixel(x, y);
      }
    }
    texture2D.SetPixels(colors);
    texture2D.Apply();
    return texture2D;
  }

  public string GenerateRandomName()
  {
    int num = UnityEngine.Random.Range(1, 3);
    string input = (double) UnityEngine.Random.Range(0.0f, 1f) > 0.5 ? this.vowels[UnityEngine.Random.Range(0, this.vowels.Length)] : string.Empty;
    for (int index = 0; index < num; ++index)
      input = input + this.consonants[UnityEngine.Random.Range(0, this.consonants.Length)] + this.vowels[UnityEngine.Random.Range(0, this.vowels.Length)];
    return this.CapitalizeFirstLetter(input);
  }

  public string CapitalizeFirstLetter(string input)
  {
    if (string.IsNullOrEmpty(input))
      return input;
    char[] charArray = input.ToCharArray();
    charArray[0] = (char) ((uint) charArray[0] - 32U /*0x20*/);
    return new string(charArray);
  }

  public bool ScatContent
  {
    get => this.FreeWorldPatch && this._ScatContent;
    set
    {
      this._ScatContent = value;
      if ((UnityEngine.Object) this.ScatContentRoot != (UnityEngine.Object) null)
        this.ScatContentRoot.SetActive(value);
      for (int index = 0; index < this.ScatContentToDisable.Length; ++index)
        this.ScatContentToDisable[index].SetActive(value);
      int num = value ? 1 : 0;
    }
  }

  public bool FetishChas
  {
    get => this._FetishChas;
    set => this._FetishChas = value;
  }

  public void ActionWhenNav(Action action)
  {
    if (this.NavGenerated)
      action();
    else
      this.OnFinallyGenerate.Add(action);
  }

  public void ActionAfterWhenNav(Action action)
  {
    if (this.NavGenerated)
      action();
    else
      this.OnAfterFinallyGenerate.Add(action);
  }

  public void ActionWhenPplSpawn(Action action)
  {
    if (Main.Instance.NewGameMenu.SpawnedPeople)
      action();
    else
      this.OnAfterSpawnPeople.Add(action);
  }

  public void Start()
  {
    Main.Instance = this;
    this.RandomizeFloatSafes();
    if (File.Exists(Main.AssetsFolder + "/debuglog.txt"))
    {
      Main.DebugLog = true;
      File.WriteAllText(Main.AssetsFolder + "/debuglog.txt", string.Empty);
    }
    this.ReadTextLinesIn("English");
    string[] directories = Directory.GetDirectories(Main.AssetsFolder + "/Mods/");
    Main.Log("Mods Folders> " + directories.Length.ToString());
    for (int index1 = 0; index1 < directories.Length; ++index1)
    {
      string path = directories[index1] + "/info.txt";
      if (File.Exists(path))
      {
        string[] strArray = File.ReadAllLines(path);
        string str1 = string.Empty;
        string str2 = string.Empty;
        bool flag1 = false;
        for (int index2 = 0; index2 < strArray.Length; ++index2)
        {
          string upperInvariant = strArray[index2].ToUpperInvariant();
          if (upperInvariant.StartsWith("TITLE:"))
            str1 = strArray[index2].Remove(0, 6);
          else if (upperInvariant.StartsWith("DESCRIPTION:"))
            str2 = strArray[index2].Remove(0, 12);
          else if (upperInvariant.StartsWith("ENABLED:"))
            flag1 = upperInvariant.Remove(0, 8) == "TRUE";
        }
        misc_ModEntry component = UnityEngine.Object.Instantiate<GameObject>(this.SettingsMenu.ModEntry, this.SettingsMenu.ModEntry.transform.parent).GetComponent<misc_ModEntry>();
        component.gameObject.SetActive(true);
        component.ModFolder = directories[index1];
        component.Title.text = str1;
        component.Desc.text = str2;
        component.ModEnabled.SetIsOnWithoutNotify(flag1);
        if (str1 == "Free world")
        {
          this.FreeWorldPatch = flag1;
          component.EnabledFunction_d = new Func<bool, bool>(this.EnableFreeWorld);
        }
        if (str1 == "Extra Dirty")
        {
          this.ScatContent = flag1;
          component.EnabledFunction_d = new Func<bool, bool>(this.EnableScatContent);
        }
        string[] files = Directory.GetFiles(directories[index1], "*.dll", SearchOption.TopDirectoryOnly);
        for (int index3 = 0; index3 < files.Length; ++index3)
        {
          bool flag2 = false;
          Main.Log("Loading Module: " + files[index3]);
          try
          {
            Assembly assembly = Assembly.LoadFile(files[index3]);
            component.ModDll = assembly;
            if (assembly == (Assembly) null)
            {
              Main.Log("coulnd't load: " + files[index3]);
            }
            else
            {
              foreach (System.Type type in assembly.GetTypes())
              {
                if (type.IsClass && type.Namespace == "BitchLand" && type.Name == "Mod")
                {
                  component.ModComponent = type;
                  try
                  {
                    MethodInfo method = type.GetMethod("Init");
                    if (method != (MethodInfo) null)
                    {
                      flag2 = true;
                      method.Invoke((object) null, (object[]) null);
                    }
                  }
                  catch (Exception ex)
                  {
                    Main.Log($"ERROR: Calling Init() \"{files[index3]}\"\r\n{ex.Message}\r\n{ex.StackTrace}");
                  }
                  try
                  {
                    MethodInfo method = type.GetMethod("EnableMod");
                    component.EnabledFunction = method;
                  }
                  catch (Exception ex)
                  {
                    Main.Log($"ERROR: getting EnableMod() \"{files[index3]}\"\r\n{ex.Message}\r\n{ex.StackTrace}");
                  }
                }
              }
              if (!flag2)
                Main.Log($"Module \"{files[index3]}\"  \"BitchLand.Mod.Init()\" function not found, make sure it's static!");
            }
          }
          catch (Exception ex)
          {
            Main.Log($"ERROR: Loading module \"{files[index3]}\"\r\n{ex.Message}\r\n{ex.StackTrace}");
          }
        }
      }
    }
    for (int index = 0; index < 10; ++index)
      this.SpawnedPeopleOfType.Add(new List<Person>());
    string[] files1 = Directory.GetFiles(Main.AssetsFolder + "/CustomImport/", "*.txt", SearchOption.AllDirectories);
    Main.Log("CustomImport txt files found: " + files1.Length.ToString());
    for (int index = 0; index < files1.Length; ++index)
    {
      try
      {
        this.ReadCustomBundleDataFile(files1[index]);
        Main.Log("no errors found");
      }
      catch (Exception ex)
      {
        Main.Log(ex.Message);
        Main.Log(ex.StackTrace);
      }
    }
    this.GetCustomTextures();
    if (this.StartOnMenu != null && this.StartOnMenu.Length > 0)
      this.OpenMenu(this.StartOnMenu);
    if ((UnityEngine.Object) this.PreloadCam != (UnityEngine.Object) null)
    {
      this.PreloadCam.SetActive(false);
      this.PreloadCam.SetActive(true);
      Main.RunInNextFrame((Action) (() => this.PreloadCam.SetActive(false)), 3);
    }
    if ((UnityEngine.Object) this.SettingsMenu != (UnityEngine.Object) null)
      this.SettingsMenu.ApplyAllSettings();
    if (this.OpenWorld)
    {
      this.NewGameMenu.DificultySelected = 2;
      this.NewGameMenu.FinallyStartGamePlay();
    }
    if (!Main.LoadMedFromHard)
      return;
    Main.LoadMedFromHard = false;
    this.GlobalVars.Add("ReleasedFromHardmode", "1");
    if (Main.LoadMedFromHard_Escape)
      this.GlobalVars.Add("EscapedFromHardmode", "1");
    Main.Instance.NewGameMenu.SmallLoading.SetActive(true);
    this.MainMenuCam.gameObject.SetActive(false);
    Main.RunInNextFrame((Action) (() =>
    {
      string[] strArray = File.ReadAllLines(Main.AssetsFolder + "/HardToMedTransfer/data.txt");
      Main.Instance.CustomizeMenu.GenderSettings.value = int.Parse(strArray[1]);
      Main.Instance.CustomizeMenu.FutaChanceSlider.value = Main.ParseFloat(strArray[2]);
      this.NewGameMenu.DificultySelected = 2;
      this.NewGameMenu.FinallyStartGamePlay();
      if (File.Exists(Main.AssetsFolder + "/HardToMedTransfer/Player.chr"))
      {
        Main.Instance.Player.LoadFromFile(Main.AssetsFolder + "/HardToMedTransfer/Player.chr");
      }
      else
      {
        Main.Instance.Player = Main.Instance.MalePlayer;
        Main.Instance.Player.LoadFromFile(Main.AssetsFolder + "/HardToMedTransfer/Player_m.chr");
      }
      Main.Instance.GameplayMenu.RefreshPerks();
      this.AllMissions[1].Goals[0].Completed = true;
      this.AllMissions[1].Goals[1].Completed = true;
      this.AllMissions[1].Goals[2].Completed = true;
      this.AllMissions[1].Goals[3].Completed = true;
      this.AllMissions[1].Goals[4].Completed = true;
      this.GameplayMenu.StartMission(this.AllMissions[1]);
      this.Default_Area.OnEnter();
      Main.RunInNextFrame((Action) (() => this.SaveGame(true)), 30);
    }), 2);
  }

  public bool EnableFreeWorld(bool value)
  {
    this.FreeWorldPatch = value;
    misc_ModEntry.SaveEnabledFor(Main.AssetsFolder + "/Mods/FreeWorld/", value);
    if (!value)
    {
      misc_ModEntry[] objectsOfType = UnityEngine.Object.FindObjectsOfType<misc_ModEntry>(false);
      for (int index = 0; index < objectsOfType.Length; ++index)
      {
        if (objectsOfType[index].Title.text == "Extra Dirty")
          objectsOfType[index].ModEnabled.isOn = false;
      }
    }
    return false;
  }

  public bool EnableScatContent(bool value)
  {
    this.ScatContent = value;
    misc_ModEntry.SaveEnabledFor(Main.AssetsFolder + "/Mods/ExtraDirty/", value);
    if (value)
    {
      misc_ModEntry[] objectsOfType = UnityEngine.Object.FindObjectsOfType<misc_ModEntry>(false);
      for (int index = 0; index < objectsOfType.Length; ++index)
      {
        if (objectsOfType[index].Title.text == "Free world")
          objectsOfType[index].ModEnabled.isOn = true;
      }
    }
    return false;
  }

  public void Update()
  {
    this.SkyRot += Time.deltaTime / 2f;
    if ((double) this.SkyRot >= 360.0)
      this.SkyRot = 0.0f;
    this.Sky.SetFloat("_Rotation", this.SkyRot);
    this.Second += Time.deltaTime;
    if ((double) this.Second > 1.0)
    {
      this.Second = 0.0f;
      ++this.Seconds;
    }
    if (this.AutosaveEnable && Main.Instance.GameplayMenu.gameObject.activeInHierarchy)
    {
      this.AutoSaveTimer += Time.deltaTime;
      if ((double) this.AutoSaveTimer > (double) this.AutoSaveTimerMax)
      {
        this.AutoSaveTimer = 0.0f;
        if (this.CanSaveGame && (UnityEngine.Object) this.Player.InteractingWith == (UnityEngine.Object) null)
          this.SaveGame(true);
      }
    }
    this.RandomizeFloatSafes();
    for (int index = 0; index < this.MainThreads.Count; ++index)
      this.MainThreads[index]();
    if ((UnityEngine.Object) this.CurrentArea != (UnityEngine.Object) null)
    {
      if (this.MusicInCombat)
      {
        if (Main.Instance.Player.InCombat)
        {
          if (this.MusicPlayer.isPlaying || this.CurrentArea.CombatLocalMusics == null || this.CurrentArea.CombatLocalMusics.Length == 0)
            return;
          this.MusicPlayer.clip = this.CurrentArea.CombatLocalMusics[UnityEngine.Random.Range(0, this.CurrentArea.CombatLocalMusics.Length)];
          this.MusicPlayer.Play();
        }
        else
        {
          this.MusicInCombat = false;
          this.MusicPlayer.Stop();
        }
      }
      else if (Main.Instance.Player.InCombat && this.CurrentArea.CombatLocalMusics != null && this.CurrentArea.CombatLocalMusics.Length != 0)
      {
        this.MusicInCombat = true;
        this.MusicPlayer.Stop();
      }
      else
      {
        if (this.MusicPlayer.isPlaying || this.CurrentArea.LocalMusics == null || this.CurrentArea.LocalMusics.Length == 0)
          return;
        this.MusicPlayer.pitch = (double) this.CurrentArea.MusicPitch == 0.0 ? 1f : this.CurrentArea.MusicPitch;
        this.MusicPlayer.clip = this.CurrentArea.LocalMusics[UnityEngine.Random.Range(0, this.CurrentArea.LocalMusics.Length)];
        this.MusicPlayer.Play();
      }
    }
    else
      this.Default_Area.OnEnter();
  }

  public void GenerateNav()
  {
    if (!this.OpenWorld)
      this.Nav.GetType().GetMethod("BuildNavMesh").Invoke((object) this.Nav, (object[]) null);
    this.MainThreads.Add(new Action(this.WaitNav));
  }

  public void WaitNav()
  {
    if (this.OpenWorld)
    {
      this.NavGenerated = true;
      for (int index = 0; index < this.OnFinallyGenerate.Count; ++index)
        this.OnFinallyGenerate[index]();
      this.OnFinallyGenerate.Clear();
      Main.RunInNextFrame((Action) (() =>
      {
        for (int index = 0; index < this.OnAfterFinallyGenerate.Count; ++index)
          this.OnAfterFinallyGenerate[index]();
        this.OnAfterFinallyGenerate.Clear();
      }), 60);
      this.MainThreads.Remove(new Action(this.WaitNav));
    }
    else
    {
      if (this.Nav.GetType().GetProperty("navMeshData").GetValue((object) this.Nav) == null)
        return;
      this.NavGenerated = true;
      for (int index = 0; index < this.OnFinallyGenerate.Count; ++index)
        this.OnFinallyGenerate[index]();
      this.OnFinallyGenerate.Clear();
      Main.RunInNextFrame((Action) (() =>
      {
        for (int index = 0; index < this.OnAfterFinallyGenerate.Count; ++index)
          this.OnAfterFinallyGenerate[index]();
        this.OnAfterFinallyGenerate.Clear();
      }), 60);
      this.MainThreads.Remove(new Action(this.WaitNav));
      this.Bake();
    }
  }

  public void Bake()
  {
    int num = 0;
    while (num < this.StaticRoots.Count)
      ++num;
    Debug.Log((object) "mesh done");
  }

  public void CombineObjectsWithSameMaterial(Transform staticRoot)
  {
    MeshRenderer[] componentsInChildren = staticRoot.GetComponentsInChildren<MeshRenderer>(true);
    Dictionary<Material, List<MeshFilter>> dictionary = new Dictionary<Material, List<MeshFilter>>();
    foreach (MeshRenderer meshRenderer in componentsInChildren)
    {
      Material sharedMaterial = meshRenderer.sharedMaterial;
      if (!dictionary.ContainsKey(sharedMaterial))
        dictionary[sharedMaterial] = new List<MeshFilter>();
      dictionary[sharedMaterial].Add(meshRenderer.GetComponent<MeshFilter>());
    }
    foreach (KeyValuePair<Material, List<MeshFilter>> keyValuePair in dictionary)
    {
      Material key = keyValuePair.Key;
      List<MeshFilter> meshFilterList = keyValuePair.Value;
      Mesh mesh = new Mesh();
      List<CombineInstance> combineInstanceList = new List<CombineInstance>();
      foreach (MeshFilter meshFilter in meshFilterList)
        combineInstanceList.Add(new CombineInstance()
        {
          mesh = meshFilter.sharedMesh,
          transform = meshFilter.transform.localToWorldMatrix
        });
      mesh.CombineMeshes(combineInstanceList.ToArray());
      GameObject gameObject = new GameObject(key.name);
      gameObject.AddComponent<MeshRenderer>().sharedMaterial = key;
      gameObject.AddComponent<MeshFilter>().sharedMesh = mesh;
      gameObject.transform.SetParent(staticRoot, true);
    }
  }

  public virtual void OpenMenu(string menu)
  {
    this.MainMenuCam.gameObject.SetActive(false);
    this.CloseMenus();
    for (int index = 0; index < this.Menus.Count; ++index)
    {
      if (this.Menus[index].MenuName == menu)
      {
        this.Menus[index].Open();
        break;
      }
    }
    GC.Collect();
  }

  public virtual void CloseMenus()
  {
    for (int index = 0; index < this.Menus.Count; ++index)
    {
      if (this.Menus[index]._IsOpen)
        this.Menus[index].Close();
    }
  }

  public List<string> CanSaveFlags
  {
    get => this._CanSaveFlags;
    set
    {
      this._CanSaveFlags = value;
      Main.Instance.GameplayMenu.CantSaveMsg.SetActive(!this.CanSaveGame);
      Main.Instance.GameplayMenu.SaveButton.interactable = this.CanSaveGame;
    }
  }

  public void CanSaveFlags_add(string entry)
  {
    this._CanSaveFlags.Add(entry);
    Main.Instance.GameplayMenu.CantSaveMsg.SetActive(true);
    Main.Instance.GameplayMenu.SaveButton.interactable = false;
  }

  public void CanSaveFlags_remove(string entry)
  {
    this._CanSaveFlags.Remove(entry);
    Main.Instance.GameplayMenu.CantSaveMsg.SetActive(!this.CanSaveGame);
    Main.Instance.GameplayMenu.SaveButton.interactable = this.CanSaveGame;
  }

  public bool CanSaveGame => this._CanSaveFlags.Count == 0;

  public void SaveGame(bool autosave = false)
  {
    if (UI_Settings._SpeedrunValue != 0)
      return;
    this.AutoSaveTimer = 0.0f;
    if (autosave)
    {
      this.CurrentSavePath = Main.AssetsFolder + "/Temp_autosave/";
      if (Directory.Exists(this.CurrentSavePath))
        Directory.Delete(this.CurrentSavePath, true);
    }
    else
    {
      int num = 0;
      do
      {
        this.CurrentSavePath = $"{Main.AssetsFolder}/Saves/{num++.ToString("0000")}/";
      }
      while (Directory.Exists(this.CurrentSavePath));
    }
    string currentSavePath = this.CurrentSavePath;
    Main.Instance.EnableAfterSave.Clear();
    Directory.CreateDirectory(this.CurrentSavePath);
    File.WriteAllBytes(this.CurrentSavePath + "pic.png", ScreenCapture.CaptureScreenshotAsTexture().EncodeToPNG());
    File.WriteAllLines(this.CurrentSavePath + "defaultsIDs.txt", Main.Instance.NewGameMenu.DefaultIDs.ToArray());
    string str1 = "None";
    for (int index = Main.Instance.AllMissions.Count - 1; index >= 0; --index)
    {
      if ((UnityEngine.Object) Main.Instance.AllMissions[index] != (UnityEngine.Object) null && (Main.Instance.AllMissions[index].Goals[0].Completed || Main.Instance.AllMissions[index].Goals[0].Failed) && !Main.Instance.AllMissions[index].CompletedMission)
      {
        str1 = Main.Instance.AllMissions[index].Title;
        break;
      }
    }
    string path = this.CurrentSavePath + "info.txt";
    string[] contents = new string[6]
    {
      DateTime.Now.ToString(),
      $"({Main.Instance.Player.Personality.ToString()}) {Main.Instance.Player.Name}",
      "Mission: " + str1,
      null,
      null,
      null
    };
    string str2 = Main.Instance.Player.Perks.Count.ToString();
    int num1 = UnityEngine.Object.FindObjectsOfType<misc_Perk>(true).Length;
    string str3 = num1.ToString();
    contents[3] = $"{str2}/{str3} Level up perks";
    contents[4] = "Sex unknown times";
    contents[5] = Main.Instance.Player is Girl ? (Main.Instance.Player as Girl).HadPregnancies.ToString() + " Pregnancies" : "unknown Impregnations";
    File.WriteAllLines(path, contents);
    List<string> stringList1 = new List<string>();
    stringList1.Add("10".ToString());
    List<string> stringList2 = stringList1;
    num1 = Main.Instance.AllMissions.Count;
    string str4 = num1.ToString();
    stringList2.Add(str4);
    for (int index1 = 0; index1 < Main.Instance.AllMissions.Count; ++index1)
    {
      stringList1.Add(Main.Instance.AllMissions[index1].CompletedMission ? "1" : "0");
      if (!Main.Instance.AllMissions[index1].CurrentGoal.isNull())
        stringList1.Add(Main.Instance.AllMissions[index1].CurrentGoal.Index.ToString());
      else
        stringList1.Add("None");
      List<string> stringList3 = stringList1;
      num1 = Main.Instance.AllMissions[index1].Goals.Count;
      string str5 = num1.ToString();
      stringList3.Add(str5);
      for (int index2 = 0; index2 < Main.Instance.AllMissions[index1].Goals.Count; ++index2)
      {
        stringList1.Add(Main.Instance.AllMissions[index1].Goals[index2].Completed ? "1" : "0");
        stringList1.Add(Main.Instance.AllMissions[index1].Goals[index2].Failed ? "1" : "0");
      }
    }
    int num2 = -1;
    List<string> stringList4 = stringList1;
    num1 = Main.Instance.GameplayMenu.CurrentMissions.Count;
    string str6 = num1.ToString();
    stringList4.Add(str6);
    for (int index3 = 0; index3 < Main.Instance.GameplayMenu.CurrentMissions.Count; ++index3)
    {
      for (int index4 = 0; index4 < Main.Instance.AllMissions.Count; ++index4)
      {
        if ((UnityEngine.Object) Main.Instance.AllMissions[index4] == (UnityEngine.Object) Main.Instance.GameplayMenu.CurrentMissions[index3])
        {
          if (num2 == -1 && (UnityEngine.Object) Main.Instance.AllMissions[index4] == (UnityEngine.Object) Main.Instance.GameplayMenu.CurrentMission)
            num2 = index4;
          stringList1.Add(index4.ToString());
          break;
        }
      }
    }
    stringList1.Add(num2.ToString());
    File.WriteAllLines(this.CurrentSavePath + "missions.txt", stringList1.ToArray());
    List<string> stringList5 = new List<string>();
    List<byte> byteList = new List<byte>();
    stringList5.Add("10.e");
    stringList5.Add(Main.Instance.NewGameMenu.DificultySelected.ToString());
    stringList5.Add(Main.Float2Str(this.DayCycle.timeOfDay));
    List<string> stringList6 = stringList5;
    num1 = Main.Instance.GlobalVars.Count;
    string str7 = num1.ToString();
    stringList6.Add(str7);
    for (int index = 0; index < Main.Instance.GlobalVars.Count; ++index)
      stringList5.Add($"{Main.Instance.GlobalVars.Keys[index]};{Main.Instance.GlobalVars.Values[index]}");
    List<string> stringList7 = stringList5;
    num1 = Main.Instance.GameplayMenu.Relationships.Count;
    string str8 = num1.ToString();
    stringList7.Add(str8);
    for (int index = 0; index < Main.Instance.GameplayMenu.Relationships.Count; ++index)
      stringList5.Add(Main.Instance.GameplayMenu.Relationships[index].WorldSaveID);
    if ((UnityEngine.Object) Main.Instance.CurrentArea == (UnityEngine.Object) null)
      stringList5.Add("NULL");
    else
      stringList5.Add(Main.Instance.CurrentArea.name);
    stringList5.Add(this.Seconds.ToString());
    File.WriteAllLines(this.CurrentSavePath + "data.bl", stringList5.ToArray());
    List<string> stringList8 = new List<string>();
    List<string> stringList9 = stringList8;
    num1 = Main.Instance.GameplayMenu.HasBitchNotes10.Length;
    string str9 = num1.ToString();
    stringList9.Add(str9);
    for (int index = 0; index < Main.Instance.GameplayMenu.HasBitchNotes10.Length; ++index)
      stringList8.Add(Main.Instance.GameplayMenu.HasBitchNotes10[index] ? "1" : "0");
    List<string> stringList10 = stringList8;
    num1 = Main.Instance.GameplayMenu.HasBitchNotes20.Length;
    string str10 = num1.ToString();
    stringList10.Add(str10);
    for (int index = 0; index < Main.Instance.GameplayMenu.HasBitchNotes20.Length; ++index)
      stringList8.Add(Main.Instance.GameplayMenu.HasBitchNotes20[index] ? "1" : "0");
    List<string> stringList11 = stringList8;
    num1 = Main.Instance.GameplayMenu.HasBitchNotes50.Length;
    string str11 = num1.ToString();
    stringList11.Add(str11);
    for (int index = 0; index < Main.Instance.GameplayMenu.HasBitchNotes50.Length; ++index)
      stringList8.Add(Main.Instance.GameplayMenu.HasBitchNotes50[index] ? "1" : "0");
    List<string> stringList12 = stringList8;
    num1 = Main.Instance.GameplayMenu.HasBitchNotes100.Length;
    string str12 = num1.ToString();
    stringList12.Add(str12);
    for (int index = 0; index < Main.Instance.GameplayMenu.HasBitchNotes100.Length; ++index)
      stringList8.Add(Main.Instance.GameplayMenu.HasBitchNotes100[index] ? "1" : "0");
    List<string> stringList13 = stringList8;
    num1 = Main.Instance.GameplayMenu.HasBitchNotes1000.Length;
    string str13 = num1.ToString();
    stringList13.Add(str13);
    for (int index = 0; index < Main.Instance.GameplayMenu.HasBitchNotes1000.Length; ++index)
      stringList8.Add(Main.Instance.GameplayMenu.HasBitchNotes1000[index] ? "1" : "0");
    List<string> stringList14 = stringList8;
    num1 = Main.Instance.GameplayMenu.HasBitchNotesProt.Length;
    string str14 = num1.ToString();
    stringList14.Add(str14);
    for (int index = 0; index < Main.Instance.GameplayMenu.HasBitchNotesProt.Length; ++index)
      stringList8.Add(Main.Instance.GameplayMenu.HasBitchNotesProt[index] ? "1" : "0");
    List<string> stringList15 = stringList8;
    num1 = Main.Instance.GameplayMenu.HasPostersBC.Length;
    string str15 = num1.ToString();
    stringList15.Add(str15);
    for (int index = 0; index < Main.Instance.GameplayMenu.HasPostersBC.Length; ++index)
      stringList8.Add(Main.Instance.GameplayMenu.HasPostersBC[index] ? "1" : "0");
    List<string> stringList16 = stringList8;
    num1 = Main.Instance.GameplayMenu.HasPostersBCLeg.Length;
    string str16 = num1.ToString();
    stringList16.Add(str16);
    for (int index = 0; index < Main.Instance.GameplayMenu.HasPostersBCLeg.Length; ++index)
      stringList8.Add(Main.Instance.GameplayMenu.HasPostersBCLeg[index] ? "1" : "0");
    List<string> stringList17 = stringList8;
    num1 = Main.Instance.GameplayMenu.HasPostersBCBEL.Length;
    string str17 = num1.ToString();
    stringList17.Add(str17);
    for (int index = 0; index < Main.Instance.GameplayMenu.HasPostersBCBEL.Length; ++index)
      stringList8.Add(Main.Instance.GameplayMenu.HasPostersBCBEL[index] ? "1" : "0");
    List<string> stringList18 = stringList8;
    num1 = Main.Instance.GameplayMenu.HasPostersBCCap.Length;
    string str18 = num1.ToString();
    stringList18.Add(str18);
    for (int index = 0; index < Main.Instance.GameplayMenu.HasPostersBCCap.Length; ++index)
      stringList8.Add(Main.Instance.GameplayMenu.HasPostersBCCap[index] ? "1" : "0");
    File.WriteAllLines(this.CurrentSavePath + "Collectibles.txt", stringList8.ToArray());
    if (this.Player is Girl)
    {
      this.Player.SaveToFile(this.CurrentSavePath + "Player.chr");
    }
    else
    {
      this.Player.WeaponInv.DropAllWeapons();
      this.Player.SaveToFile(this.CurrentSavePath + "Player_m.chr");
    }
    for (int index = 0; index < this.SpawnedPeople.Count; ++index)
    {
      if (!((UnityEngine.Object) this.SpawnedPeople[index] == (UnityEngine.Object) null) && !this.SpawnedPeople[index].IsPlayer && !this.SpawnedPeople[index].DontSaveInMain)
        this.SpawnedPeople[index].SaveToFile($"{this.CurrentSavePath}{this.SpawnedPeople[index].name}{this.SpawnedPeople[index].WorldSaveID}{(this.SpawnedPeople[index] is Girl ? "_f" : "_m")}.chr");
    }
    for (int index = 0; index < this.SpawnedObjects.Count; ++index)
    {
      if (!((UnityEngine.Object) this.SpawnedObjects[index] == (UnityEngine.Object) null) && !this.SpawnedObjects[index].DontSaveInMain && this.SpawnedObjects[index].CanSave && this.SpawnedObjects[index].gameObject.activeInHierarchy)
      {
        string str19 = "null";
        if (this.SpawnedObjects[index].WorldSaveID != null && this.SpawnedObjects[index].WorldSaveID.Length > 0)
          str19 = this.SpawnedObjects[index].WorldSaveID;
        this.SpawnedObjects[index].SaveToFile($"{this.CurrentSavePath}{str19}_{index.ToString()}.obj");
      }
    }
    for (int index = 0; index < Main.Instance.EnableAfterSave.Count; ++index)
      Main.Instance.EnableAfterSave[index].SetActive(true);
    if (!autosave)
      return;
    string str20 = Main.AssetsFolder + "/Saves/_autosave/";
    if (Directory.Exists(str20))
      Directory.Delete(str20, true);
    if (Directory.Exists(this.CurrentSavePath))
      Directory.Move(this.CurrentSavePath, str20);
    this.CurrentSavePath = str20;
    Main.Instance.GameplayMenu.ShowNotification("Autosaved");
  }

  public List<string> SaveCharacter(Person _person)
  {
    List<string> stringList1 = new List<string>();
    stringList1.Add(_person.Name);
    stringList1.Add(Main.Vector32Str(_person.transform.position));
    stringList1.Add(Main.Vector32Str(_person.transform.eulerAngles));
    stringList1.Add(Main.Vector32Str(_person.transform.localScale));
    stringList1.Add(Main.Color2Str(_person.NaturalEyeColor));
    stringList1.Add(Main.Color2Str(_person.NaturalHairColor));
    stringList1.Add(Main.Color2Str(_person.NaturalSkinColor));
    stringList1.Add(Main.Color2Str(_person.DyedEyeColor));
    stringList1.Add(Main.Color2Str(_person.DyedHairColor));
    stringList1.Add(Main.Color2Str(_person.TannedSkinColor));
    Health component = _person.GetComponent<Health>();
    stringList1.Add(component.dead ? "1" : "0");
    stringList1.Add(component.Incapacitated ? "1" : "0");
    stringList1.Add(component.canDie ? "1" : "0");
    stringList1.Add(Main.Float2Str(component.maxHealth));
    stringList1.Add(Main.Float2Str(component.currentHealth));
    stringList1.Add(_person.EquippedClothes.Count.ToString());
    for (int index = 0; index < _person.EquippedClothes.Count; ++index)
      stringList1.Add(_person.EquippedClothes[index].OriginalPrefab.name);
    stringList1.Add(_person.WeaponInv.weaponIndex.ToString());
    stringList1.Add(_person.WeaponInv.weapons.Count.ToString());
    int num;
    for (int index = 0; index < _person.WeaponInv.weapons.Count; ++index)
    {
      stringList1.Add(_person.WeaponInv.weapons[index].name);
      List<string> stringList2 = stringList1;
      num = _person.WeaponInv.weapons[index].GetComponent<Weapon>().currentAmmo;
      string str = num.ToString();
      stringList2.Add(str);
    }
    Vector3 vector3;
    for (int index = 0; index < _person.AllFaceBones.Length; ++index)
    {
      Transform allFaceBone = _person.AllFaceBones[index];
      List<string> stringList3 = stringList1;
      vector3 = allFaceBone.localPosition;
      string str1 = vector3.ToString();
      stringList3.Add(str1);
      List<string> stringList4 = stringList1;
      vector3 = allFaceBone.localEulerAngles;
      string str2 = vector3.ToString();
      stringList4.Add(str2);
      List<string> stringList5 = stringList1;
      vector3 = allFaceBone.localScale;
      string str3 = vector3.ToString();
      stringList5.Add(str3);
    }
    for (int index = 0; index < _person.AllBodyBones.Length; ++index)
    {
      Transform allBodyBone = _person.AllBodyBones[index];
      List<string> stringList6 = stringList1;
      vector3 = allBodyBone.localPosition;
      string str4 = vector3.ToString();
      stringList6.Add(str4);
      List<string> stringList7 = stringList1;
      vector3 = allBodyBone.localEulerAngles;
      string str5 = vector3.ToString();
      stringList7.Add(str5);
      List<string> stringList8 = stringList1;
      vector3 = allBodyBone.localScale;
      string str6 = vector3.ToString();
      stringList8.Add(str6);
    }
    List<string> stringList9 = stringList1;
    num = (int) _person.State;
    string str7 = num.ToString();
    stringList9.Add(str7);
    List<string> stringList10 = stringList1;
    num = (int) _person.CombatState;
    string str8 = num.ToString();
    stringList10.Add(str8);
    List<string> stringList11 = stringList1;
    num = (int) _person.PostureHeightState;
    string str9 = num.ToString();
    stringList11.Add(str9);
    List<string> stringList12 = stringList1;
    num = (int) _person.PostureState;
    string str10 = num.ToString();
    stringList12.Add(str10);
    return stringList1;
  }

  public void LoadCharacter(Person person, StreamReader data)
  {
    string str1 = data.ReadLine();
    person.Name = str1;
    string str2 = data.ReadLine();
    person.transform.position = new Vector3();
    str2 = data.ReadLine();
    person.transform.eulerAngles = new Vector3();
    str2 = data.ReadLine();
    person.transform.localScale = new Vector3();
    str2 = data.ReadLine();
    person.NaturalEyeColor = new Color();
    str2 = data.ReadLine();
    person.NaturalHairColor = new Color();
    str2 = data.ReadLine();
    person.NaturalSkinColor = new Color();
    str2 = data.ReadLine();
    person.DyedEyeColor = new Color();
    str2 = data.ReadLine();
    person.DyedHairColor = new Color();
    str2 = data.ReadLine();
    person.TannedSkinColor = new Color();
    Health component = person.GetComponent<Health>();
    component.dead = data.ReadLine() == "1";
    component.Incapacitated = data.ReadLine() == "1";
    component.canDie = data.ReadLine() == "1";
    component.maxHealth = Main.ParseFloat(data.ReadLine());
    component.currentHealth = Main.ParseFloat(data.ReadLine());
    int num1 = int.Parse(data.ReadLine());
    int num2 = 0;
    while (num2 < num1)
      ++num2;
  }

  public void LoadGame_old(string filename)
  {
    StreamReader data = new StreamReader((Stream) new MemoryStream(File.ReadAllBytes(filename)));
    int num = 0;
    string str = data.ReadLine();
    if (str != "10.e")
      Debug.LogError((object) ("Save with diferent version! Current Game Version=10.e / Save Version=" + str));
    this.LoadCharacter(this.Player, data);
    while (!data.EndOfStream)
    {
      data.ReadLine();
      ++num;
    }
  }

  public void LoadGame(string directory)
  {
    this.LoadedGame = true;
    this.CurrentSavePath = directory;
    Main.Instance.NewGameMenu.SmallLoading.SetActive(true);
    this.Invoke("LoadGame_2", 0.1f);
  }

  public void LoadGame_2()
  {
    string[] _data = (string[]) null;
    int _dataindex = 0;
    int _saveVersion = 0;
    Main.Instance.NewGameMenu.DificultySelected = 2;
    if (File.Exists(this.CurrentSavePath + "data.bl"))
    {
      _data = File.ReadAllLines(this.CurrentSavePath + "data.bl");
      string str = _data[_dataindex++];
      if (File.Exists(this.CurrentSavePath + "missions.txt"))
      {
        Main.Log("reading missions version check");
        _saveVersion = int.Parse(File.ReadAllLines(this.CurrentSavePath + "missions.txt")[0]);
      }
      string s = _data[_dataindex++];
      Main.Instance.NewGameMenu.DificultySelected = int.Parse(s);
      this.DayCycle.timeOfDay = Main.ParseFloat(_data[_dataindex++]);
      int num = int.Parse(_data[_dataindex++]);
      for (int index = 0; index < num; ++index)
      {
        string[] strArray = _data[_dataindex++].Split(';', StringSplitOptions.None);
        this.GlobalVars.Add(strArray[0], strArray[1]);
      }
    }
    if ((UnityEngine.Object) Main.Instance.NewGameMenu.NewGameThings != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) Main.Instance.NewGameMenu.NewGameThings);
    if ((UnityEngine.Object) Main.Instance.CustomizeMenu.CustomizeRoom != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) Main.Instance.CustomizeMenu.CustomizeRoom);
    if (Main.Instance.NewGameMenu.EnableWhenNewGame != null)
    {
      for (int index = 0; index < Main.Instance.NewGameMenu.EnableWhenNewGame.Length; ++index)
      {
        if ((UnityEngine.Object) Main.Instance.NewGameMenu.EnableWhenNewGame[index] != (UnityEngine.Object) null)
          Main.Instance.NewGameMenu.EnableWhenNewGame[index].SetActive(true);
      }
    }
    if (Main.Instance.NewGameMenu.DestroyWhenStartLoading != null)
    {
      for (int index = 0; index < Main.Instance.NewGameMenu.DestroyWhenStartLoading.Length; ++index)
      {
        if ((UnityEngine.Object) Main.Instance.NewGameMenu.DestroyWhenStartLoading[index] != (UnityEngine.Object) null)
          UnityEngine.Object.Destroy((UnityEngine.Object) Main.Instance.NewGameMenu.DestroyWhenStartLoading[index]);
      }
    }
    Main.Instance.AllJobs = new List<bl_WorkJobManager>();
    Main.Instance.AllJobs.AddRange((IEnumerable<bl_WorkJobManager>) UnityEngine.Object.FindObjectsOfType<bl_WorkJobManager>(true));
    Main.Instance.AllHomes = new List<bl_HangZone>();
    Main.Instance.AllHomes.AddRange((IEnumerable<bl_HangZone>) UnityEngine.Object.FindObjectsOfType<bl_HangZone>(true));
    if (Main.Instance.NewGameMenu.DificultySelected == 3)
    {
      Main.Instance.DayCycle.sunLight.transform.SetParent((Transform) null);
      GameObject gameObject = new GameObject();
      gameObject.transform.SetPositionAndRotation(Main.Instance.NewGameMenu.StartingPositions[2].position, Main.Instance.NewGameMenu.StartingPositions[2].rotation);
      Main.Instance.PlayerWakeupPlaces.Clear();
      Main.Instance.PlayerWakeupPlaces.Add(gameObject.transform);
      if ((UnityEngine.Object) Main.Instance.NewGameMenu.HardGameplayStuff != (UnityEngine.Object) null)
        Main.Instance.NewGameMenu.HardGameplayStuff.SetActive(true);
    }
    else if ((UnityEngine.Object) Main.Instance.NewGameMenu.MedGameplayStuff != (UnityEngine.Object) null)
      Main.Instance.NewGameMenu.MedGameplayStuff.SetActive(true);
    Main.Instance.ActionWhenNav((Action) (() =>
    {
      if (File.Exists(this.CurrentSavePath + "Player.chr"))
      {
        Main.Instance.Player.LoadFromFile(this.CurrentSavePath + "Player.chr");
      }
      else
      {
        Main.Instance.Player = Main.Instance.MalePlayer;
        Main.Instance.Player.LoadFromFile(this.CurrentSavePath + "Player_m.chr");
        FreeLookCam objectOfType = UnityEngine.Object.FindObjectOfType<FreeLookCam>(true);
        objectOfType.m_Target = Main.Instance.Player.transform;
        WeaponSystem componentInChildren = objectOfType.GetComponentInChildren<WeaponSystem>(true);
        componentInChildren.ThisPerson = Main.Instance.Player;
        Main.Instance.Player.WeaponInv = componentInChildren;
        Main.Instance.Player.HasPenis = true;
      }
      Main.Instance.Player.gameObject.SetActive(true);
      Main.Instance.GameplayMenu.RefreshPerks();
      List<Person> _spawnedPpl = new List<Person>();
      foreach (string file in Directory.GetFiles(this.CurrentSavePath, "*_f.chr"))
      {
        Person component = UnityEngine.Object.Instantiate<GameObject>(this.PersonPrefab).GetComponent<Person>();
        component.LoadFromFile(file);
        _spawnedPpl.Add(component);
        component.AddMoveBlocker("LOADING GRRRR");
      }
      string[] files1 = Directory.GetFiles(this.CurrentSavePath, "*_m.chr");
      for (int index = 0; index < files1.Length; ++index)
      {
        if (!(Path.GetFileName(files1[index]) == "Player_m.chr"))
        {
          Person component = UnityEngine.Object.Instantiate<GameObject>(this.PersonGuyPrefab).GetComponent<Person>();
          component.LoadFromFile(files1[index]);
          _spawnedPpl.Add(component);
          component.AddMoveBlocker("LOADING GRRRR");
        }
      }
      Main.RunInSeconds((Action) (() =>
      {
        Main.Instance.PreloadCam.GetComponent<Camera>().cullingMask = 4;
        Main.Instance.PreloadCam.SetActive(true);
        Main.RunInNextFrame((Action) (() => Main.Instance.PreloadCam.SetActive(false)), 5);
      }), 1f);
      string[] files2 = Directory.GetFiles(this.CurrentSavePath, "*.obj");
      string[] strArray1 = File.Exists(this.CurrentSavePath + "defaultsIDs.txt") ? File.ReadAllLines(this.CurrentSavePath + "defaultsIDs.txt") : File.ReadAllLines(Main.AssetsFolder + "/Data/build6defaultsID.txt");
      for (int index1 = 0; index1 < Main.Instance.SpawnedObjects.Count; ++index1)
      {
        if (Main.Instance.SpawnedObjects[index1].WorldSaveID != null && Main.Instance.SpawnedObjects[index1].WorldSaveID.Length > 0)
        {
          for (int index2 = 0; index2 < strArray1.Length; ++index2)
          {
            if (strArray1[index2] == Main.Instance.SpawnedObjects[index1].WorldSaveID && (UnityEngine.Object) Main.Instance.SpawnedObjects[index1].gameObject.GetComponentInChildren<Int_Storage>() == (UnityEngine.Object) null)
              Main.Instance.SpawnedObjects[index1].gameObject.SetActive(false);
          }
        }
      }
label_39:
      for (int index3 = 0; index3 < files2.Length; ++index3)
      {
        GameObject prefab = (GameObject) null;
        string[] Data = File.ReadAllLines(files2[index3]);
        Main.Log("reading file=" + files2[index3]);
        string str = Data[0];
        Main.Log("_curWorldID=" + str);
        if (str == null || str.Length == 0)
        {
          Main.Log("_curWorldID is null");
          if (Data.Length > 3 && Data[1] != null && Data[1].Length != 0)
          {
            for (int index4 = 0; index4 < Main.Instance.AllPrefabs.Count; ++index4)
            {
              if (Main.Instance.AllPrefabs[index4].name == Data[1])
              {
                prefab = Main.Instance.AllPrefabs[index4];
                break;
              }
            }
            if ((UnityEngine.Object) prefab == (UnityEngine.Object) null)
            {
              Debug.LogError((object) ("Error: Prefab not found: " + Data[1]));
            }
            else
            {
              SaveableBehaviour component = Main.Spawn(prefab).GetComponent<SaveableBehaviour>();
              if ((UnityEngine.Object) component != (UnityEngine.Object) null)
                component.SaveableData = Data;
            }
          }
        }
        else
        {
          for (int index5 = 0; index5 < Main.Instance.SpawnedObjects.Count; ++index5)
          {
            if (Main.Instance.SpawnedObjects[index5].WorldSaveID == str)
            {
              Main.Instance.SpawnedObjects[index5].gameObject.SetActive(true);
              Main.Instance.SpawnedObjects[index5].sd_LoadData(Data);
              goto label_39;
            }
          }
          Debug.Log((object) "_curWorldID was NOT found");
        }
      }
      if (Main.Instance.NewGameMenu.DificultySelected == 3)
      {
        if ((UnityEngine.Object) Main.Instance.NewGameMenu.Hard_PeopleToSpawn_Specials != (UnityEngine.Object) null)
          Main.Instance.NewGameMenu.Hard_PeopleToSpawn_Specials.SetActive(true);
      }
      else
      {
        if ((UnityEngine.Object) Main.Instance.NewGameMenu.Med_PeopleToSpawn_Specials != (UnityEngine.Object) null)
          Main.Instance.NewGameMenu.Med_PeopleToSpawn_Specials.SetActive(true);
        int num = int.Parse("10");
        Debug.Log((object) ("Main.BuildVersionInt / _thisVersion " + num.ToString()));
        Debug.Log((object) ("_saveVersion " + _saveVersion.ToString()));
        Debug.Log((object) ("(_saveVersion < _thisVersion) " + (_saveVersion < num).ToString()));
        if (_saveVersion < num)
        {
          List<Transform> transformList = new List<Transform>();
          for (int index = 0; index < Main.Instance.NewGameMenu.Med_PeopleToSpawn.transform.childCount; ++index)
          {
            RandomNPCHere component = Main.Instance.NewGameMenu.Med_PeopleToSpawn.transform.GetChild(index).GetComponent<RandomNPCHere>();
            if ((UnityEngine.Object) component != (UnityEngine.Object) null && component.BuildVersionAdded >= num)
              transformList.Add(component.transform);
          }
          for (int index = 0; index < transformList.Count; ++index)
            transformList[index].SetParent((Transform) null);
        }
      }
      if (Main.Instance.NewGameMenu.EnableAfterNewGame != null)
      {
        for (int index = 0; index < Main.Instance.NewGameMenu.EnableAfterNewGame.Length; ++index)
        {
          if ((UnityEngine.Object) Main.Instance.NewGameMenu.EnableAfterNewGame[index] != (UnityEngine.Object) null)
            Main.Instance.NewGameMenu.EnableAfterNewGame[index].SetActive(true);
        }
      }
      if (File.Exists(this.CurrentSavePath + "data.bl"))
      {
        int num = int.Parse(_data[_dataindex++]);
        for (int index6 = 0; index6 < num; ++index6)
        {
          string str = _data[_dataindex++];
          for (int index7 = 0; index7 < Main.Instance.SpawnedPeople.Count; ++index7)
          {
            if (Main.Instance.SpawnedPeople[index7].WorldSaveID == str)
            {
              Main.Instance.GameplayMenu.Relationships.Add(Main.Instance.SpawnedPeople[index7]);
              break;
            }
          }
        }
        this.Default_Area.OnEnter();
        if (_data.Length > _dataindex)
        {
          string str = _data[_dataindex++];
          if (str.Length != 0)
          {
            for (int index = 0; index < this.MapAreas.Count; ++index)
            {
              if (this.MapAreas[index].name == str)
              {
                this.MapAreas[index].OnEnter();
                break;
              }
            }
          }
          if (_data.Length > _dataindex)
            this.Seconds = int.Parse(_data[_dataindex++]);
        }
      }
      Main.Log("reading missions");
      string[] strArray2 = File.ReadAllLines(this.CurrentSavePath + "missions.txt");
      int num1 = 0;
      string[] strArray3 = strArray2;
      int index8 = num1;
      int num2 = index8 + 1;
      _saveVersion = int.Parse(strArray3[index8]);
      string[] strArray4 = strArray2;
      int index9 = num2;
      int num3 = index9 + 1;
      int num4 = int.Parse(strArray4[index9]);
      Main.Log("_allMissionsCount " + num4.ToString());
      for (int index10 = 0; index10 < num4; ++index10)
      {
        Main.Log("_allMissionsCount i " + index10.ToString());
        Mission allMission = Main.Instance.AllMissions[index10];
        string[] strArray5 = strArray2;
        int index11 = num3;
        int num5 = index11 + 1;
        int num6 = strArray5[index11] == "1" ? 1 : 0;
        allMission.CompletedMission = num6 != 0;
        Main.Log("CompletedMission " + Main.Instance.AllMissions[index10].CompletedMission.ToString());
        string[] strArray6 = strArray2;
        int index12 = num5;
        int num7 = index12 + 1;
        if (strArray6[index12] != "None")
        {
          int index13 = int.Parse(strArray2[num7 - 1]);
          Main.Log("_curgoal " + index13.ToString());
          if (index13 != 0 && index13 < Main.Instance.AllMissions[index10].Goals.Count)
          {
            Main.Instance.AllMissions[index10].CurrentGoal = Main.Instance.AllMissions[index10].Goals[index13];
            Main.Instance.AllMissions[index10].CurrentGoalIndex = index13;
          }
        }
        else
          Main.Log("_curgoal None");
        string[] strArray7 = strArray2;
        int index14 = num7;
        num3 = index14 + 1;
        int num8 = int.Parse(strArray7[index14]);
        Main.Log("_goalsCount " + num8.ToString());
        for (int index15 = 0; index15 < num8; ++index15)
        {
          if (index15 >= Main.Instance.AllMissions[index10].Goals.Count)
          {
            Main.Log($"broke at {index15.ToString()} / {Main.Instance.AllMissions[index10].Goals.Count.ToString()}");
            num3 += 2;
          }
          else
          {
            MissionGoal goal1 = Main.Instance.AllMissions[index10].Goals[index15];
            string[] strArray8 = strArray2;
            int index16 = num3;
            int num9 = index16 + 1;
            int num10 = strArray8[index16] == "1" ? 1 : 0;
            goal1.Completed = num10 != 0;
            MissionGoal goal2 = Main.Instance.AllMissions[index10].Goals[index15];
            string[] strArray9 = strArray2;
            int index17 = num9;
            num3 = index17 + 1;
            int num11 = strArray9[index17] == "1" ? 1 : 0;
            goal2.Failed = num11 != 0;
          }
        }
      }
      Main.Log("end1 _readindex " + num3.ToString());
      int num12 = int.Parse(strArray2[num3++]);
      Main.Log("_curMissionsCount " + num12.ToString());
      this._MissionsToinit.Clear();
      for (int index18 = 0; index18 < num12; ++index18)
      {
        Main.Log("_curMissionsCount i " + index18.ToString());
        int index19 = int.Parse(strArray2[num3++]);
        Main.Instance.GameplayMenu.CurrentMissions.Add(Main.Instance.AllMissions[index19]);
        Main.Log("init AllMissions[" + index19.ToString());
        if (!this._MissionsToinit.Contains(Main.Instance.AllMissions[index19]))
          this._MissionsToinit.Add(Main.Instance.AllMissions[index19]);
      }
      Main.Log("end2 ");
      int index20 = int.Parse(strArray2[num3++]);
      Main.Log("_curMission " + index20.ToString());
      if (index20 != -1)
        Main.Instance.GameplayMenu.CurrentMission = Main.Instance.AllMissions[index20];
      Main.RunInNextFrame((Action) (() =>
      {
        Main.Instance.NewGameMenu.SmallLoading.SetActive(false);
        Main.Instance.OpenMenu("Gameplay");
        for (int index21 = 0; index21 < _spawnedPpl.Count; ++index21)
          _spawnedPpl[index21].RemoveMoveBlocker("LOADING GRRRR");
      }));
    }));
    if (File.Exists(this.CurrentSavePath + "Collectibles.txt"))
    {
      string[] strArray10 = File.ReadAllLines(this.CurrentSavePath + "Collectibles.txt");
      int num13 = int.Parse(strArray10[0]);
      int num14 = 1;
      for (int index = 0; index < num13; ++index)
        Main.Instance.GameplayMenu.HasBitchNotes10[index] = strArray10[num14++] == "1";
      string[] strArray11 = strArray10;
      int index22 = num14;
      int num15 = index22 + 1;
      int num16 = int.Parse(strArray11[index22]);
      for (int index23 = 0; index23 < num16; ++index23)
        Main.Instance.GameplayMenu.HasBitchNotes20[index23] = strArray10[num15++] == "1";
      string[] strArray12 = strArray10;
      int index24 = num15;
      int num17 = index24 + 1;
      int num18 = int.Parse(strArray12[index24]);
      for (int index25 = 0; index25 < num18; ++index25)
        Main.Instance.GameplayMenu.HasBitchNotes50[index25] = strArray10[num17++] == "1";
      string[] strArray13 = strArray10;
      int index26 = num17;
      int num19 = index26 + 1;
      int num20 = int.Parse(strArray13[index26]);
      for (int index27 = 0; index27 < num20; ++index27)
        Main.Instance.GameplayMenu.HasBitchNotes100[index27] = strArray10[num19++] == "1";
      string[] strArray14 = strArray10;
      int index28 = num19;
      int num21 = index28 + 1;
      int num22 = int.Parse(strArray14[index28]);
      for (int index29 = 0; index29 < num22; ++index29)
        Main.Instance.GameplayMenu.HasBitchNotes1000[index29] = strArray10[num21++] == "1";
      string[] strArray15 = strArray10;
      int index30 = num21;
      int num23 = index30 + 1;
      int num24 = int.Parse(strArray15[index30]);
      for (int index31 = 0; index31 < num24; ++index31)
        Main.Instance.GameplayMenu.HasBitchNotesProt[index31] = strArray10[num23++] == "1";
      string[] strArray16 = strArray10;
      int index32 = num23;
      int num25 = index32 + 1;
      int num26 = int.Parse(strArray16[index32]);
      for (int index33 = 0; index33 < num26; ++index33)
        Main.Instance.GameplayMenu.HasPostersBC[index33] = strArray10[num25++] == "1";
      string[] strArray17 = strArray10;
      int index34 = num25;
      int num27 = index34 + 1;
      int num28 = int.Parse(strArray17[index34]);
      for (int index35 = 0; index35 < num28; ++index35)
        Main.Instance.GameplayMenu.HasPostersBCLeg[index35] = strArray10[num27++] == "1";
      string[] strArray18 = strArray10;
      int index36 = num27;
      int num29 = index36 + 1;
      int num30 = int.Parse(strArray18[index36]);
      for (int index37 = 0; index37 < num30; ++index37)
        Main.Instance.GameplayMenu.HasPostersBCBEL[index37] = strArray10[num29++] == "1";
      string[] strArray19 = strArray10;
      int index38 = num29;
      int num31 = index38 + 1;
      int num32 = int.Parse(strArray19[index38]);
      for (int index39 = 0; index39 < num32; ++index39)
        Main.Instance.GameplayMenu.HasPostersBCCap[index39] = strArray10[num31++] == "1";
    }
    Main.Instance.NewGameMenu.GenerateDefaultsIDsForThisInstance();
    Main.RunInNextFrame(new Action(this.GenerateNav), 3);
    Main.RunInNextFrame((Action) (() =>
    {
      for (int index = 0; index < this._MissionsToinit.Count; ++index)
        this._MissionsToinit[index].InitMission();
      this._MissionsToinit.Clear();
    }), 60);
  }

  public static void RunInNextFrame(Action action, int frames = 1)
  {
    Main._runinnextframe runinnextframe = new GameObject().AddComponent<Main._runinnextframe>();
    runinnextframe.TheAction = action;
    runinnextframe.Counter = frames;
  }

  public static Main._runinseconds RunInSeconds(Action action, float seconds)
  {
    Main._runinseconds runinseconds = new GameObject().AddComponent<Main._runinseconds>();
    runinseconds.TheAction = action;
    runinseconds.Counter = seconds;
    return runinseconds;
  }

  public void ReadCustomBundleDataFile(string filename)
  {
    Main.Log("ReadCustomBundleDataFile: " + filename);
    string[] strArray1 = File.ReadAllLines(filename);
    Main.Log("CustomImport txt _lines.Length: " + strArray1.Length.ToString());
    for (int index1 = 0; index1 < strArray1.Length; ++index1)
    {
      if (strArray1[index1].Contains('='))
      {
        string[] strArray2 = strArray1[index1].Split('=', StringSplitOptions.None);
        Main.CustomBundleAssetType assetType = Main.CustomBundleAssetType.Item;
        switch (strArray2[0])
        {
          case "Body":
            assetType = Main.CustomBundleAssetType.Body;
            break;
          case "Head":
            assetType = Main.CustomBundleAssetType.Head;
            break;
          case "Dressable":
            assetType = Main.CustomBundleAssetType.Dressable;
            break;
        }
        this.RegisterCustomBundle(filename.Replace(".txt", ".bundle"), strArray2[1], assetType);
        if (assetType == Main.CustomBundleAssetType.Dressable && strArray2.Length >= 7)
        {
          GameObject gameObject = this.SpawnFromCustomBundle(strArray2[1]);
          Dressable dressable = gameObject.AddComponent<Dressable>();
          dressable.IsCustomImported = true;
          dressable.BodyPart = (DressableType) int.Parse(strArray2[2]);
          dressable.AttatchPos = Main.ParseVector3(strArray2[3]);
          dressable.AttatchRot = Main.ParseVector3(strArray2[4]);
          dressable.AttatchScl = Main.ParseVector3(strArray2[5]);
          dressable.ReverseAxis = (Axis) int.Parse(strArray2[6]);
          Main.Instance.Prefabs_Hair.Add(gameObject);
          gameObject.transform.position = new Vector3(-500f, -1000f, 750f);
          if (strArray2.Length >= 8)
          {
            if (strArray2[7] == "1")
            {
              Renderer[] componentsInChildren = gameObject.GetComponentsInChildren<Renderer>();
              for (int index2 = 0; index2 < componentsInChildren.Length; ++index2)
              {
                if ((UnityEngine.Object) componentsInChildren[index2] != (UnityEngine.Object) null)
                {
                  for (int index3 = 0; index3 < componentsInChildren[index2].materials.Length; ++index3)
                  {
                    if ((UnityEngine.Object) componentsInChildren[index2].materials[index3] != (UnityEngine.Object) null)
                    {
                      try
                      {
                        componentsInChildren[index2].materials[index3].shader = Shader.Find("Standard");
                        componentsInChildren[index2].materials[index3].SetFloat("_Glossiness", 0.0f);
                      }
                      catch
                      {
                      }
                    }
                  }
                }
              }
            }
            else if (strArray2[7] == "2")
            {
              Renderer[] componentsInChildren = gameObject.GetComponentsInChildren<Renderer>();
              for (int index4 = 0; index4 < componentsInChildren.Length; ++index4)
              {
                if ((UnityEngine.Object) componentsInChildren[index4] != (UnityEngine.Object) null)
                {
                  for (int index5 = 0; index5 < componentsInChildren[index4].materials.Length; ++index5)
                  {
                    if ((UnityEngine.Object) componentsInChildren[index4].materials[index5] != (UnityEngine.Object) null)
                    {
                      try
                      {
                        componentsInChildren[index4].materials[index5].shader = Shader.Find("Standard Double Sided");
                      }
                      catch
                      {
                      }
                    }
                  }
                }
              }
            }
          }
        }
      }
    }
  }

  public void RegisterCustomBundle(
    string bundleName,
    string assetName,
    Main.CustomBundleAssetType assetType)
  {
    Main.Log($"RegisterCustomBundle: {assetName} - {bundleName}");
    this.RegisteredCustomBundles.Add(new Main.RegisteredCustomBundle()
    {
      BundleFileName = bundleName,
      AssetName = assetName,
      AssetType = assetType
    });
  }

  public GameObject SpawnFromCustomBundle(string assetName)
  {
    Main.Log("SpawnFromCustomBundle: " + assetName);
    for (int index = 0; index < this.RegisteredCustomBundles.Count; ++index)
    {
      try
      {
        Main.RegisteredCustomBundle registeredCustomBundle = this.RegisteredCustomBundles[index];
        if (registeredCustomBundle.AssetName == assetName)
        {
          if ((UnityEngine.Object) registeredCustomBundle.LoadedAsset == (UnityEngine.Object) null)
          {
            if ((UnityEngine.Object) registeredCustomBundle.LoadedBundle == (UnityEngine.Object) null)
              registeredCustomBundle.LoadedBundle = AssetBundle.LoadFromFile(registeredCustomBundle.BundleFileName);
            registeredCustomBundle.LoadedAsset = registeredCustomBundle.LoadedBundle.LoadAsset<GameObject>(assetName);
          }
          GameObject gameObject = Main.Spawn(registeredCustomBundle.LoadedAsset);
          registeredCustomBundle.LoadedBundle.Unload(false);
          return gameObject;
        }
      }
      catch (Exception ex)
      {
        Main.Log($"SpawnFromCustomBundle ERROR: {ex.Message}\n{ex.StackTrace}");
      }
    }
    return (GameObject) null;
  }

  public bool AssetExistsInBundle(string assetName)
  {
    for (int index = 0; index < this.RegisteredCustomBundles.Count; ++index)
    {
      if (this.RegisteredCustomBundles[index].AssetName == assetName)
        return true;
    }
    return false;
  }

  public void ReadTextLinesIn(string language)
  {
    this._AllTextLines = File.ReadAllLines($"{Main.AssetsFolder}/Data/TextLines/{language}.txt");
    int num = 0;
    while (num < this._AllTextLines.Length)
    {
      if (this._AllTextLines[num++] == "-START")
      {
        this._AllTextLinesStart = num;
        break;
      }
    }
  }

  public static string GetLine(int index)
  {
    int index1 = Main.Instance._AllTextLinesStart + index;
    return index1 >= Main.Instance._AllTextLines.Length ? "LANGUAGE FILE IS MISSING LINES!" : Main.Instance._AllTextLines[index1];
  }

  public static Vector3 ParseVector3(string s)
  {
    string[] strArray = s.Replace("(", "").Replace(")", "").Split(',', StringSplitOptions.None);
    return new Vector3(Main.ParseFloat(strArray[0]), Main.ParseFloat(strArray[1]), Main.ParseFloat(strArray[2]));
  }

  public static Color ParseColor(string s)
  {
    string[] strArray = s.Replace("RGBA(", "").Replace("(", "").Replace(")", "").Split(',', StringSplitOptions.None);
    return new Color(Main.ParseFloat(strArray[0]), Main.ParseFloat(strArray[1]), Main.ParseFloat(strArray[2]), Main.ParseFloat(strArray[3]));
  }

  public static Texture2D MergeTextures(Texture2D tex1, Texture2D tex2)
  {
    Texture2D texture2D = new Texture2D(tex1.width, tex1.height, TextureFormat.RGBA32, false);
    Color[] pixels1 = tex1.GetPixels();
    Color[] pixels2 = tex2.GetPixels();
    for (int index = 0; index < pixels1.Length; ++index)
    {
      Color color1 = pixels1[index];
      Color color2 = pixels2[index];
      if ((double) color1.a == 0.0)
        pixels1[index] = color2;
      else if ((double) color2.a == 0.0)
      {
        pixels1[index] = color1;
      }
      else
      {
        float a1 = color1.a;
        float a2 = color2.a;
        float a3 = a1 + a2 * (1f - a1);
        float r = (float) ((double) color1.r * (double) a1 * (1.0 - (double) a2) + (double) color2.r * (double) a2) / a3;
        float g = (float) ((double) color1.g * (double) a1 * (1.0 - (double) a2) + (double) color2.g * (double) a2) / a3;
        float b = (float) ((double) color1.b * (double) a1 * (1.0 - (double) a2) + (double) color2.b * (double) a2) / a3;
        pixels1[index] = new Color(r, g, b, a3);
      }
    }
    texture2D.SetPixels(pixels1);
    texture2D.Apply();
    return texture2D;
  }

  public static int SumUpTo(int n) => n * ((n + 1) / 2);

  public static GameObject Spawn(GameObject prefab, Transform parent = null, bool saveable = false)
  {
    GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(prefab, parent);
    gameObject.name = gameObject.name.Replace("(Clone)", string.Empty);
    bool flag = false;
    SaveableBehaviour saveableBehaviour = (SaveableBehaviour) null;
    SaveableBehaviour[] componentsInChildren = gameObject.GetComponentsInChildren<SaveableBehaviour>(true);
    for (int index = 0; index < componentsInChildren.Length; ++index)
    {
      componentsInChildren[index].WorldSaveID = string.Empty;
      if (!flag && componentsInChildren[index].AddToSaveableOnStart)
      {
        flag = true;
        saveableBehaviour = componentsInChildren[index];
      }
    }
    if (saveable)
    {
      if ((UnityEngine.Object) saveableBehaviour == (UnityEngine.Object) null)
        saveableBehaviour = gameObject.GetComponent<SaveableBehaviour>();
      if ((UnityEngine.Object) saveableBehaviour != (UnityEngine.Object) null)
        Main.Instance.SpawnedObjects.Add(saveableBehaviour);
    }
    return gameObject;
  }

  public bool CancelKey()
  {
    return Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.J) || Input.GetKeyUp(KeyCode.I);
  }

  public static float ValOfP(float M, float N, float P) => (M - N) * P + N;

  public static float POfVal(float M, float N, float Val)
  {
    return (float) (((double) Val - (double) N) / ((double) M - (double) N));
  }

  public static string GenerateRandomString(int length)
  {
    char[] chArray = new char[length];
    for (int index = 0; index < length; ++index)
      chArray[index] = (char) (48 /*0x30*/ + UnityEngine.Random.Range(0, 10));
    return new string(chArray);
  }

  public static float ParseFloat(string text)
  {
    return float.Parse(text.Replace(",", "."), (IFormatProvider) CultureInfo.InvariantCulture);
  }

  public static string Float2Str(float value)
  {
    return value.ToString("0.###", (IFormatProvider) CultureInfo.InvariantCulture);
  }

  public static string Vector32Str(Vector3 value)
  {
    return $"({Main.Float2Str(value.x)},{Main.Float2Str(value.y)},{Main.Float2Str(value.z)})";
  }

  public static string Color2Str(Color value)
  {
    return $"({Main.Float2Str(value.r)},{Main.Float2Str(value.g)},{Main.Float2Str(value.b)},{Main.Float2Str(value.a)})";
  }

  public static void AdjustCharacterPosition(
    Transform character2,
    Transform torso1,
    Transform torso2)
  {
    Vector3 vector3 = new Vector3(0.0f, torso1.position.y - torso2.position.y + 0.01f, 0.0f);
    character2.position += vector3;
  }

  public void RandomizeFloatSafes()
  {
    ++this._FSFrameCounter;
    if (this._FSFrameCounter <= 10)
      return;
    this._FSFrameCounter = 0;
    this.SafeFVal = UnityEngine.Random.Range(-500f, 500f);
    this.SafeIVal = UnityEngine.Random.Range(-500, 500);
  }

  public IEnumerator StartCombatWithArmy()
  {
    if (!Main.AlreadyStartedCombat)
    {
      Main.AlreadyStartedCombat = true;
      int i;
      if ((UnityEngine.Object) Main.Instance.Player.CurrentZone != (UnityEngine.Object) null)
      {
        for (i = 0; i < Main.Instance.Player.CurrentZone.PeopleInZone.Count; ++i)
        {
          Person person = Main.Instance.Player.CurrentZone.PeopleInZone[i];
          if ((UnityEngine.Object) person != (UnityEngine.Object) null && person.PersonType.ThisType == Person_Type.Army && !person.TheHealth.dead && !person.TheHealth.Incapacitated)
            person.StartFighting(Main.Instance.Player);
          yield return (object) null;
        }
      }
      for (i = 0; i < Main.Instance.SpawnedPeopleOfType[6].Count; ++i)
      {
        Person person = Main.Instance.SpawnedPeopleOfType[6][i];
        if ((UnityEngine.Object) person != (UnityEngine.Object) null && !person.TheHealth.dead && !person.TheHealth.Incapacitated && (double) Vector3.Distance(person.transform.position, Main.Instance.Player.transform.position) < 30.0)
          person.StartFighting(Main.Instance.Player);
        yield return (object) null;
      }
      Main.AlreadyStartedCombat = false;
    }
  }

  public IEnumerator StartCombatWithEveryone()
  {
    if (!Main.AlreadyStartedCombat)
    {
      Main.AlreadyStartedCombat = true;
      int i;
      if ((UnityEngine.Object) Main.Instance.Player.CurrentZone != (UnityEngine.Object) null)
      {
        for (i = 0; i < Main.Instance.Player.CurrentZone.PeopleInZone.Count; ++i)
        {
          Person person = Main.Instance.Player.CurrentZone.PeopleInZone[i];
          if ((UnityEngine.Object) person != (UnityEngine.Object) null && !person.TheHealth.dead && !person.TheHealth.Incapacitated)
          {
            switch (person.PersonType.ThisType)
            {
              case Person_Type.Worker:
              case Person_Type.Civilian:
              case Person_Type.HigherCivilian:
              case Person_Type.Army:
              case Person_Type.Royal:
                person.StartFighting(Main.Instance.Player);
                break;
            }
          }
          yield return (object) null;
        }
      }
      for (i = 0; i < Main.Instance.SpawnedPeople.Count; ++i)
      {
        Person person = Main.Instance.SpawnedPeople[i];
        if ((UnityEngine.Object) person != (UnityEngine.Object) null && !person.TheHealth.dead && !person.TheHealth.Incapacitated && (double) Vector3.Distance(person.transform.position, Main.Instance.Player.transform.position) < 30.0)
        {
          switch (person.PersonType.ThisType)
          {
            case Person_Type.Worker:
            case Person_Type.Civilian:
            case Person_Type.HigherCivilian:
            case Person_Type.Army:
            case Person_Type.Royal:
              person.StartFighting(Main.Instance.Player);
              break;
          }
        }
        yield return (object) null;
      }
      Main.AlreadyStartedCombat = false;
    }
  }

  public static bool GeneBoolSelect(bool value1, bool value2, float probability = 0.5f)
  {
    return value1 == value2 ? value1 : (double) UnityEngine.Random.Range(0, 1) < (double) probability;
  }

  public static float GeneSelect(float value1, float value2, bool randIsHalfVal = false)
  {
    switch (UnityEngine.Random.Range(0, 2))
    {
      case 1:
        return value1;
      case 2:
        return value2;
      default:
        if (!randIsHalfVal)
          return UnityEngine.Random.Range(value1, value2);
        return (double) value1 > (double) value2 ? (float) (((double) value1 + (double) value2) / 2.0) : (float) (((double) value2 + (double) value1) / 2.0);
    }
  }

  public static Color GeneColorSelect(Color value1, Color value2)
  {
    switch (UnityEngine.Random.Range(0, 2))
    {
      case 1:
        return value1;
      case 2:
        return value2;
      default:
        return new Color((double) value1.r > (double) value2.r ? (float) (((double) value1.r + (double) value2.r) / 2.0) : (float) (((double) value2.r + (double) value1.r) / 2.0), (double) value1.g > (double) value2.g ? (float) (((double) value1.g + (double) value2.g) / 2.0) : (float) (((double) value2.g + (double) value1.g) / 2.0), (double) value1.b > (double) value2.b ? (float) (((double) value1.b + (double) value2.b) / 2.0) : (float) (((double) value2.b + (double) value1.b) / 2.0), 1f);
    }
  }

  public Person CreateOffspring(Person parent1, Person parent2)
  {
    bool flag1 = false;
    bool flag2 = false;
    bool flag3 = false;
    int num1 = Main.Instance.CustomizeMenu.GenderSettings.value;
    if ((UnityEngine.Object) parent1 == (UnityEngine.Object) null)
    {
      flag2 = true;
      parent1 = Main.Instance.CityCharacters.Sarah;
    }
    if ((UnityEngine.Object) parent2 == (UnityEngine.Object) null)
    {
      flag3 = true;
      parent2 = Main.Instance.CityCharacters.Sarah;
    }
    float probability = 0.5f;
    bool flag4;
    switch (num1)
    {
      case 1:
        flag4 = false;
        break;
      case 2:
        flag4 = true;
        break;
      case 3:
        probability = 0.2f;
        goto default;
      case 4:
        probability = 0.8f;
        goto default;
      default:
        flag4 = Main.GeneBoolSelect(parent1 is Guy, parent2 is Guy, probability);
        break;
    }
    if (!flag4)
      flag1 = (double) UI_Customize.FutaChanceValue != 0.0 && ((double) UI_Customize.FutaChanceValue == 1.0 || (!(parent1 is Girl) || !(parent1 as Girl).Futa ? (!(parent2 is Girl) || !(parent2 as Girl).Futa ? (double) UnityEngine.Random.Range(0.0f, 1f) < (double) UI_Customize.FutaChanceValue : Main.GeneBoolSelect(true, parent1.HasPenis, UI_Customize.FutaChanceValue)) : Main.GeneBoolSelect(true, parent2.HasPenis, UI_Customize.FutaChanceValue)));
    Person component = (flag4 ? UnityEngine.Object.Instantiate<GameObject>(Main.Instance.PersonGuyPrefab) : UnityEngine.Object.Instantiate<GameObject>(Main.Instance.PersonPrefab)).GetComponent<Person>();
    if (!flag4)
      component.Anim.runtimeAnimatorController = Main.Instance.NPCController;
    component.NaturalHairColor = Main.GeneColorSelect(parent1.NaturalHairColor, parent2.NaturalHairColor);
    component.NaturalEyeColor = new Color(Main.GeneSelect(parent1.NaturalEyeColor.r, parent2.NaturalEyeColor.r), Main.GeneSelect(parent1.NaturalEyeColor.g, parent2.NaturalEyeColor.g), Main.GeneSelect(parent1.NaturalEyeColor.b, parent2.NaturalEyeColor.b), 1f);
    component.NaturalSkinColor = Main.GeneColorSelect(parent1.NaturalSkinColor, parent2.NaturalSkinColor);
    if ((double) parent1.Height == 0.0)
      parent1.Height = 1f;
    if ((double) parent2.Height == 0.0)
      parent2.Height = 1f;
    component.Height = Main.GeneSelect(parent1.Height, parent2.Height);
    component.VoicePitch = Main.GeneSelect(parent1.VoicePitch, parent2.VoicePitch);
    if (!flag4)
    {
      if (flag1)
      {
        component.HasPenis = true;
        component.HasBalls = Main.GeneBoolSelect(parent1.HasBalls, parent2.HasBalls);
      }
      if (parent1 is Girl && parent2 is Girl)
      {
        Main.RandomFaceRange randomFaceRange = new Main.RandomFaceRange();
        for (int index = 0; index < component.AllFaceBones.Length; ++index)
        {
          randomFaceRange.PosMax = parent1.AllFaceBones[index].localPosition;
          randomFaceRange.PosMin = parent2.AllFaceBones[index].localPosition;
          randomFaceRange.RotMax = parent1.AllFaceBones[index].localEulerAngles;
          randomFaceRange.RotMin = parent2.AllFaceBones[index].localEulerAngles;
          randomFaceRange.SclMax = parent1.AllFaceBones[index].localScale;
          randomFaceRange.SclMin = parent2.AllFaceBones[index].localScale;
          randomFaceRange.ApplyTo(component.AllFaceBones[index], rotationGlitchFix: true);
        }
        randomFaceRange.GetRangesFrom(parent1.Neck, parent2.Neck);
        randomFaceRange.ApplyTo(component.Neck);
        randomFaceRange.GetRangesFrom(parent1.BoobLeft, parent2.BoobLeft);
        randomFaceRange.ApplyTo(component.BoobLeft, component.BoobRight);
        randomFaceRange.GetRangesFrom(parent1.NippleLeft, parent2.NippleLeft);
        randomFaceRange.ApplyTo(component.NippleLeft, component.NippleRight);
        randomFaceRange.GetRangesFrom(parent1.Hips, parent2.Hips);
        randomFaceRange.ApplyTo(component.Hips);
        randomFaceRange.GetRangesFrom(parent1.UpperThighLeft, parent2.UpperThighLeft);
        randomFaceRange.ApplyTo(component.UpperThighLeft, component.UpperThighRight);
        randomFaceRange.GetRangesFrom(parent1.CalveLeft, parent2.CalveLeft);
        randomFaceRange.ApplyTo(component.CalveLeft, component.CalveRight);
        randomFaceRange.PosMax = (parent1 as Girl).PregnancyBones_default[3];
        randomFaceRange.PosMin = (parent2 as Girl).PregnancyBones_default[3];
        randomFaceRange.RotMax = parent1.Waist.localEulerAngles;
        randomFaceRange.RotMin = parent2.Waist.localEulerAngles;
        randomFaceRange.SclMax = (parent1 as Girl).PregnancyBones_default[2];
        randomFaceRange.SclMin = (parent2 as Girl).PregnancyBones_default[2];
        randomFaceRange.ApplyTo(component.Waist);
        randomFaceRange.PosMax = (parent1 as Girl).PregnancyBones_default[1];
        randomFaceRange.PosMin = (parent2 as Girl).PregnancyBones_default[1];
        randomFaceRange.RotMax = parent1.Belly.localEulerAngles;
        randomFaceRange.RotMin = parent2.Belly.localEulerAngles;
        randomFaceRange.SclMax = (parent1 as Girl).PregnancyBones_default[0];
        randomFaceRange.SclMin = (parent2 as Girl).PregnancyBones_default[0];
        randomFaceRange.ApplyTo(component.Belly);
        randomFaceRange.GetRangesFrom(parent1.ShoulderLeft, parent2.ShoulderLeft);
        randomFaceRange.ApplyTo(component.ShoulderLeft, component.ShoulderRight);
        randomFaceRange.GetRangesFrom(parent1.UpperArmLeft, parent2.UpperArmLeft);
        randomFaceRange.ApplyTo(component.UpperArmLeft, component.UpperArmRight);
        randomFaceRange.GetRangesFrom(parent1.ForeArmLeft, parent2.ForeArmLeft);
        randomFaceRange.ApplyTo(component.ForeArmLeft, component.ForeArmRight);
      }
      else
      {
        component.GenerateRandomBody();
        component.GenerateRandomFace();
      }
    }
    if (component.HasPenis)
    {
      float num2 = UnityEngine.Random.Range(2f, 3.5f);
      component.Penis.transform.localScale = new Vector3(num2, num2, num2);
    }
    component.Personality = (Personality_Type) UnityEngine.Random.Range(0, 13);
    component.PersonalityData = Main.Instance.Personalities[(int) component.Personality];
    int num3 = UnityEngine.Random.Range(1, 5);
    bool flag5 = false;
    List<e_Fetish> list = Enum.GetValues(typeof (e_Fetish)).Cast<e_Fetish>().ToList<e_Fetish>();
    list.Remove(e_Fetish.MAX);
    Person.Shuffle<e_Fetish>(list);
    for (int index = 0; index < num3; ++index)
    {
      if (list[index] == e_Fetish.Clean || list[index] == e_Fetish.Dirty)
      {
        if (!flag5)
        {
          flag5 = true;
          ++num3;
          component.Fetishes.Add(list[index]);
        }
      }
      else
        component.Fetishes.Add(list[index]);
    }
    component.Name = Main.Instance.GenerateRandomName();
    component.States = new bool[34];
    component.WorldSaveID = Main.GenerateRandomString(25);
    component.PersonType = Main.Instance.PersonTypes[4];
    component.SPAWN_noUglyHair = true;
    component.PersonType.ApplyTo(component, false, false);
    component.DyedEyeColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    component.DyedHairColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    component.TannedSkinColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    component.RefreshColors();
    component.Parent1 = flag2 ? (Person) null : parent1;
    component.Parent2 = flag3 ? (Person) null : parent2;
    component.PutFeet();
    return component;
  }

  [Serializable]
  public class RandomFaceRange
  {
    public Vector3 PosMin;
    public Vector3 PosMax;
    public Vector3 RotMin;
    public Vector3 RotMax;
    public Vector3 SclMin;
    public Vector3 SclMax;

    public void ApplyTo(Transform part, bool wholeScale = false, bool rotationGlitchFix = false)
    {
      part.localPosition = new Vector3((double) this.PosMin.x == (double) this.PosMax.x ? part.localPosition.x : UnityEngine.Random.Range(this.PosMin.x, this.PosMax.x), (double) this.PosMin.y == (double) this.PosMax.y ? part.localPosition.y : UnityEngine.Random.Range(this.PosMin.y, this.PosMax.y), (double) this.PosMin.z == (double) this.PosMax.z ? part.localPosition.z : UnityEngine.Random.Range(this.PosMin.z, this.PosMax.z));
      if (rotationGlitchFix)
      {
        float[] numArray = new float[6]
        {
          (double) this.RotMin.x < 180.0 ? this.RotMin.x : this.RotMin.x - 360f,
          (double) this.RotMax.x < 180.0 ? this.RotMax.x : this.RotMax.x - 360f,
          (double) this.RotMin.y < 180.0 ? this.RotMin.y : this.RotMin.y - 360f,
          (double) this.RotMax.y < 180.0 ? this.RotMax.y : this.RotMax.y - 360f,
          (double) this.RotMin.z < 180.0 ? this.RotMin.z : this.RotMin.z - 360f,
          (double) this.RotMax.z < 180.0 ? this.RotMax.z : this.RotMax.z - 360f
        };
        part.localEulerAngles = new Vector3((double) this.RotMin.x == (double) this.RotMax.x ? part.localEulerAngles.x : UnityEngine.Random.Range(numArray[0], numArray[1]), (double) this.RotMin.y == (double) this.RotMax.y ? part.localEulerAngles.y : UnityEngine.Random.Range(numArray[2], numArray[3]), (double) this.RotMin.z == (double) this.RotMax.z ? part.localEulerAngles.z : UnityEngine.Random.Range(numArray[4], numArray[5]));
      }
      else
        part.localEulerAngles = new Vector3((double) this.RotMin.x == (double) this.RotMax.x ? part.localEulerAngles.x : UnityEngine.Random.Range(this.RotMin.x, this.RotMax.x), (double) this.RotMin.y == (double) this.RotMax.y ? part.localEulerAngles.y : UnityEngine.Random.Range(this.RotMin.y, this.RotMax.y), (double) this.RotMin.z == (double) this.RotMax.z ? part.localEulerAngles.z : UnityEngine.Random.Range(this.RotMin.z, this.RotMax.z));
      if (wholeScale)
      {
        float num = UnityEngine.Random.Range(this.SclMin.x, this.SclMax.x);
        part.localScale = new Vector3(num, num, num);
      }
      else
        part.localScale = new Vector3((double) this.SclMin.x == (double) this.SclMax.x ? part.localScale.x : UnityEngine.Random.Range(this.SclMin.x, this.SclMax.x), (double) this.SclMin.y == (double) this.SclMax.y ? part.localScale.y : UnityEngine.Random.Range(this.SclMin.y, this.SclMax.y), (double) this.SclMin.z == (double) this.SclMax.z ? part.localScale.z : UnityEngine.Random.Range(this.SclMin.z, this.SclMax.z));
    }

    public void ApplyTo(Transform leftPart, Transform rightPart, bool wholeScale = false)
    {
      leftPart.localPosition = new Vector3((double) this.PosMin.x == (double) this.PosMax.x ? leftPart.localPosition.x : UnityEngine.Random.Range(this.PosMin.x, this.PosMax.x), (double) this.PosMin.y == (double) this.PosMax.y ? leftPart.localPosition.y : UnityEngine.Random.Range(this.PosMin.y, this.PosMax.y), (double) this.PosMin.z == (double) this.PosMax.z ? leftPart.localPosition.z : UnityEngine.Random.Range(this.PosMin.z, this.PosMax.z));
      rightPart.localPosition = new Vector3(-leftPart.localPosition.x, leftPart.localPosition.y, leftPart.localPosition.z);
      leftPart.localEulerAngles = new Vector3((double) this.RotMin.x == (double) this.RotMax.x ? leftPart.localEulerAngles.x : UnityEngine.Random.Range(this.RotMin.x, this.RotMax.x), (double) this.RotMin.y == (double) this.RotMax.y ? leftPart.localEulerAngles.y : UnityEngine.Random.Range(this.RotMin.y, this.RotMax.y), (double) this.RotMin.z == (double) this.RotMax.z ? leftPart.localEulerAngles.z : UnityEngine.Random.Range(this.RotMin.z, this.RotMax.z));
      rightPart.localEulerAngles = new Vector3(leftPart.localEulerAngles.x, -leftPart.localEulerAngles.y, -leftPart.localEulerAngles.z);
      if (wholeScale)
      {
        float num = UnityEngine.Random.Range(this.SclMin.x, this.SclMax.x);
        leftPart.localScale = new Vector3(num, num, num);
        rightPart.localScale = new Vector3(num, num, num);
      }
      else
      {
        leftPart.localScale = new Vector3((double) this.SclMin.x == (double) this.SclMax.x ? leftPart.localScale.x : UnityEngine.Random.Range(this.SclMin.x, this.SclMax.x), (double) this.SclMin.y == (double) this.SclMax.y ? leftPart.localScale.y : UnityEngine.Random.Range(this.SclMin.y, this.SclMax.y), (double) this.SclMin.z == (double) this.SclMax.z ? leftPart.localScale.z : UnityEngine.Random.Range(this.SclMin.z, this.SclMax.z));
        rightPart.localScale = leftPart.localScale;
      }
    }

    public void GetRangesFrom(Transform max, Transform min)
    {
      this.PosMax = max.localPosition;
      this.PosMin = min.localPosition;
      this.RotMax = max.localEulerAngles;
      this.RotMin = min.localEulerAngles;
      this.SclMax = max.localScale;
      this.SclMin = min.localScale;
    }
  }

  public class _runinnextframe : MonoBehaviour
  {
    public Action TheAction;
    public int Counter;

    public void LateUpdate()
    {
      --this.Counter;
      if (this.Counter > 0)
        return;
      this.TheAction();
      UnityEngine.Object.Destroy((UnityEngine.Object) this.gameObject);
    }
  }

  public class _runinseconds : MonoBehaviour
  {
    public Action TheAction;
    public float Counter;

    public void LateUpdate()
    {
      this.Counter -= Time.deltaTime;
      if ((double) this.Counter > 0.0)
        return;
      this.TheAction();
      UnityEngine.Object.Destroy((UnityEngine.Object) this.gameObject);
    }

    public void Stop()
    {
      this.enabled = false;
      this.TheAction = (Action) null;
      this.Counter = 9999f;
      UnityEngine.Object.Destroy((UnityEngine.Object) this.gameObject);
    }
  }

  public enum CustomBundleAssetType
  {
    Body,
    Head,
    Dressable,
    Item,
  }

  [Serializable]
  public class RegisteredCustomBundle
  {
    public string BundleFileName;
    public string AssetName;
    public Main.CustomBundleAssetType AssetType;
    public AssetBundle LoadedBundle;
    public GameObject LoadedAsset;
  }

  [Serializable]
  public class bl_Dictionary<T1, T2>
  {
    public List<T1> Keys = new List<T1>();
    public List<T2> Values = new List<T2>();

    public T2 this[T1 Key]
    {
      get => this.Get(Key);
      set => this.Set(Key, value);
    }

    public T2 this[int Index]
    {
      get => this.Values[Index];
      set => this.Values[Index] = value;
    }

    public void Clear()
    {
      this.Keys.Clear();
      this.Values.Clear();
    }

    public void Add(T1 Key, T2 Value)
    {
      this.Keys.Add(Key);
      this.Values.Add(Value);
    }

    public void Set(T1 Key, T2 Value)
    {
      int keyIndex = this.GetKeyIndex(Key);
      if (keyIndex == -1)
        this.Add(Key, Value);
      else
        this.Values[keyIndex] = Value;
    }

    public T2 Get(T1 Key)
    {
      int keyIndex = this.GetKeyIndex(Key);
      return keyIndex != -1 ? this.Values[keyIndex] : default (T2);
    }

    public void Remove(T1 Key)
    {
      int keyIndex = this.GetKeyIndex(Key);
      if (keyIndex == -1)
        return;
      this.Keys.RemoveAt(keyIndex);
      this.Values.RemoveAt(keyIndex);
    }

    public bool ContainsKey(T1 Key)
    {
      foreach (T1 key in this.Keys)
      {
        if (key.Equals((object) Key))
          return true;
      }
      return false;
    }

    public bool ContainsValue(T2 Value)
    {
      foreach (T2 obj in this.Values)
      {
        if (obj.Equals((object) Value))
          return true;
      }
      return false;
    }

    public int GetKeyIndex(T1 Key)
    {
      int count = this.Keys.Count;
      for (int index = 0; index < count; ++index)
      {
        if (Key.Equals((object) this.Keys[index]))
          return index;
      }
      return -1;
    }

    public int Count => this.Keys.Count;

    public void AddArray(IEnumerable<T1> Key, T2 Value)
    {
      foreach (T1 obj in Key)
      {
        this.Keys.Add(obj);
        this.Values.Add(Value);
      }
    }

    public List<T1> FindAll(Predicate<T2> match)
    {
      List<T1> all = new List<T1>();
      int count = this.Keys.Count;
      for (int index = 0; index < count; ++index)
      {
        if (match(this.Values[index]))
          all.Add(this.Keys[index]);
      }
      return all;
    }

    public bool TryGetValue(T1 key, out T2 value)
    {
      int keyIndex = this.GetKeyIndex(key);
      if (keyIndex == -1)
      {
        value = default (T2);
        return false;
      }
      value = this.Values[keyIndex];
      return true;
    }

    public void TryAdd(T1 key, T2 value)
    {
      if (this.GetKeyIndex(key) != -1)
        return;
      this.Add(key, value);
    }
  }
}
