// Decompiled with JetBrains decompiler
// Type: Person
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using DitzelGames.FastIK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

#nullable disable
public class Person : SaveableBehaviour
{
  public bool DEBUG;
  public GameObject Penis;
  public bool PenisEnabled;
  public bool HasPenis;
  public bool HasCondomPut;
  public int _TimesHadSexClean;
  public bool UnparentOnStart;
  public Animator Anim;
  public NavMeshAgent navMesh;
  public Rigidbody _Rigidbody;
  public Vision Eyes;
  public Transform EyesSpot;
  public Health TheHealth;
  public int_Person ThisPersonInt;
  public bl_ragdollmanager RagdollManager;
  public bl_ThirdPersonUserControl UserControl;
  public CharacterLOD LOD;
  public bl_ProxSeen ProxSeen;
  public bool CantBeHit;
  public float VoicePitch;
  public bl_footsteps FootStepsAudio;
  public Transform ViewPoint;
  public Transform TorsoViewPoint;
  public Collider[] ViewCols;
  public List<string> Perks = new List<string>();
  public Main.bl_Dictionary<string, string> SaveableVars = new Main.bl_Dictionary<string, string>();
  public bl_HangZone Home;
  [Obsolete]
  public Transform HomeSpot;
  public bl_WorkJobManager WorkJob;
  public int JobIndex;
  public bl_LocalLOD CurrentLocalLOD;
  public int Money;
  public float Strength = 10f;
  public bool _DontLoadInteraction;
  public bool _DontLoadClothing;
  public List<Person.TempAggroStruct> TempAggroToType = new List<Person.TempAggroStruct>();
  public List<string> MoveBlockers = new List<string>();
  public bool _CanRun = true;
  public List<string> RunBlockers = new List<string>();
  public Collider MainCol;
  public Collider HeadCol;
  public bool Interacting;
  public Interactible InteractingWith;
  public bool IsPlayer;
  public Transform Ground;
  public bool InCombat;
  public Person_State State;
  public Person_PostureState PostureState;
  public Person_PostureHeightState PostureHeightState;
  public Person_CombatState CombatState;
  public WeaponSystem WeaponInv;
  public int_personStorage InventoryStorage;
  public Int_Storage Storage_Hands;
  public Int_Storage Storage_Vag;
  public Int_Storage Storage_Anal;
  public int_startsex StartSleepingSex;
  public FirstPersonCharacter FirstPersonController;
  public SkinnedMeshRenderer MainBodyLowPoly;
  public SkinnedMeshRenderer MainBody;
  public Renderer LodRen;
  public FastIKFabric HeadIK;
  public FastIKFabric HipsIK;
  public FastIKFabric LeftArmIK;
  public FastIKFabric RightArmIK;
  public FastIKFabric LeftLegIK;
  public FastIKFabric RightLegIK;
  public bool SexEnding_bug1;
  public bool HavingSex;
  public bool _Masturbating;
  public bool SexPoseHasNoArousalIncrease;
  public float SexMultiplier = 1f;
  public float SexMAddictionultiplier = 1f;
  public bl_LookAtPlayer LookAtPlayer;
  [Header("          Vision")]
  public List<Collider> InRange = new List<Collider>();
  public List<Collider> Seeing = new List<Collider>();
  public GameObject[] EyesObjects;
  [Header("          Unarmed")]
  public string A_Standing_Org;
  public string A_Standing;
  public string A_Walking;
  public string A_Running;
  public string A_Crouching;
  public string A_Crouching_walk;
  public string A_Crawling_idle;
  public string A_Crawling;
  public string A_Jump;
  [Header("          Pistol")]
  public string AP_Standing;
  public string AP_Combat_Standing;
  public string AP_Walking;
  public string AP_Running;
  public string AP_Crouching;
  public string AP_Crouching_walk;
  public string AP_Crawling_idle;
  public string AP_Crawling;
  [Header("          Rifle")]
  public string AR_Standing;
  public string AR_Combat_Standing;
  public string AR_Walking;
  public string AR_Running;
  public string AR_Crouching;
  public string AR_Crouching_walk;
  public string AR_Crawling_idle;
  public string AR_Crawling;
  [Header("          Melee")]
  public string ME_Standing;
  public string ME_Combat_Standing;
  public string ME_Walking;
  public string ME_Running;
  public string ME_Crouching;
  public string ME_Crouching_walk;
  public string ME_Crawling_idle;
  public string ME_Crawling;
  public string ME_Pickaxe;
  public string ME_Short;
  public string ME_Long;
  [Header("          Free State")]
  [Header("          Work State")]
  [Header("          Combat State")]
  public Health EnemyFighting;
  public Vector3 EnemyLastKnownPosition;
  [Header("          Ragdoll")]
  public Rigidbody[] RagdollParts;
  [Header("          Clothes")]
  public List<GameObject> StartingClothes = new List<GameObject>();
  public List<string> _StartingClothes = new List<string>();
  public List<GameObject> StartingWeapons = new List<GameObject>();
  public List<string> _StartingWeapons = new List<string>();
  public Dressable CurrentShoes;
  public Dressable CurrentPants;
  public Dressable CurrentTop;
  public Dressable CurrentUnderwearTop;
  public Dressable CurrentUnderwearLower;
  public Dressable CurrentGarter;
  public Dressable CurrentSocks;
  public Dressable CurrentHat;
  public Dressable CurrentHair;
  public BackPack CurrentBackpack;
  public Dressable CurrentFeet;
  public Dressable CurrentBeard;
  public SkinnedMeshRenderer CurrentFeetMesh;
  public List<Dressable> CurrentAnys = new List<Dressable>();
  public Dressable CurrentBody;
  public Dressable CurrentHead;
  [Header("          Data")]
  public string _Name;
  public bool PlayerKnowsName;
  public Color NaturalSkinColor;
  public Color NaturalHairColor;
  public Color NaturalEyeColor;
  public Color TannedSkinColor;
  public Color DyedHairColor;
  public Color DyedEyeColor;
  public float Hunger;
  public float Energy = 100f;
  public float Toilet;
  public float HungerMax = 100f;
  public float EnergyMax = 100f;
  public float ToiletMax = 100f;
  public int IntestinalSubstance;
  public float Arousal;
  public List<Transform> SquirtSpots = new List<Transform>();
  public bool[] _CustomSkinStates;
  public bool[] _CustomFaceSkinStates;
  public bool[] _FaceSkinStates;
  public bool[] _SkinStates;
  public bool[] _States;
  public bl_Personality _PersonalityData;
  public Personality_Type Personality;
  public List<e_Fetish> Fetishes = new List<e_Fetish>();
  public int TimesSexedPlayer;
  public Person Parent1;
  public Person Parent2;
  public bool IsPlayerDescendant;
  public int Favor;
  public float StoryModeFertility;
  public float Fertility;
  public intsafe _SexSkills;
  public intsafe _WorkSkills;
  public intsafe _ArmySkills;
  public int SexXpThisLvlMax = 300;
  public int SexXpThisLvl;
  public int WorkXpThisLvlMax = 300;
  public int WorkXpThisLvl;
  public int ArmyXpThisLvlMax = 300;
  public int ArmyXpThisLvl;
  public float BoobSize;
  public float AssSize;
  public float FatSize;
  public float AnalTraining;
  public float VaginalTraining;
  public float NippleTraining;
  public float ClitTraining;
  public float BodyTraining;
  public List<Dressable> EquippedClothes = new List<Dressable>();
  public bool SPAWN_noUglyHair;
  public bool SPAWN_onlyGoodHair;
  [Header("          Perks")]
  public bool SecondWeapon;
  public BaseType PersonType;
  public bool Inited;
  public Vector3 _Destination;
  private GameObject _scatexiting;
  private float _StartShitAtStartShit;
  private float _StartShitAtStartShitActual;
  public bool _IsSleeping;
  public float _y;
  public float _z;
  public float _arg;
  public List<Action> OnFinallyInited = new List<Action>();
  public Transform[] Holes;
  public Transform[] PenisBones;
  public bool _CharacterVisible;
  public List<Action<Person>> OnSeen = new List<Action<Person>>();
  public static float GenderChance = 0.5f;
  public bool _StartedMastPP;
  public bl_HangZone CurrentZone;
  public List<Person.ScheduleTask> FreeScheduleTasks = new List<Person.ScheduleTask>();
  public List<Person.ScheduleTask> WorkScheduleTasks = new List<Person.ScheduleTask>();
  public Person.ScheduleTask CurrentScheduleTask;
  public bool Do_Schedule_GoingToTargetThread;
  public int _PathRedo;
  public float _TimeGoingToTarget;
  public float RandActionTimer;
  public Action WhileDoingAction;
  public List<Action> RuntimeActions = new List<Action>();
  public bool TEMP_HANDLENEEDS_OFF;
  public bool TEMP_HANDLEANIMS_OFF;
  public bool TEMP_SEXUPDATE_OFF;
  public bool TEMP_UPDATE_OFF;
  public bool TEMP_RUNTIME_OFF;
  public float DecideTimer;
  public bool _ShootBlind;
  public float CombatDistance = 50f;
  public bool EndingCombat;
  public SpawnedSexScene HavingSex_Scene;
  public Person HavingSexWith;
  public float Orgasming;
  public bool NoEnergyLoss;
  public bool _HiddenHead;
  public Transform[] _ClothingBatch1Bones;
  public GameObject ObjInHand;
  public Transform HeadStuff;
  public Transform RightHandStuff;
  public Transform LeftHandStuff;
  public Transform RightHandWankCenter;
  [Header("    custom face")]
  public Transform[] AllFaceBones;
  public Transform Head;
  public Transform MouthBase;
  public Transform MouthLeft;
  public Transform MouthRight;
  public Transform MouthTop;
  public Transform MouthBottom;
  public Transform CheekLowLeft;
  public Transform CheekLowRight;
  public Transform CheekUpLeft;
  public Transform CheekUpRight;
  public Transform Jaw;
  public Transform JawLow;
  public Transform Chin;
  public Transform EarLeft;
  public Transform EarLeftLow;
  public Transform EarLeftHigh;
  public Transform EarRight;
  public Transform EarRightLow;
  public Transform EarRightHigh;
  public Transform Nose;
  public Transform NoseBridge;
  public Transform NoseTip;
  public Transform NostrilLeft;
  public Transform NostrilRight;
  public Transform EyeLeft;
  public Transform EyeRight;
  public Transform EyeBallLeft;
  public Transform EyeBallRight;
  public Transform EyeLeftTop;
  public Transform EyeLeftLow;
  public Transform EyeLeftInner;
  public Transform EyeLeftOuter;
  public Transform EyeRightTop;
  public Transform EyeRightLow;
  public Transform EyeRightInner;
  public Transform EyeRightOuter;
  [Header("    custom body")]
  public Transform[] AllBodyBones;
  public Transform BoobLeft;
  public Transform BoobRight;
  public Transform NippleLeft;
  public Transform NippleRight;
  public Transform AssCheekLeft;
  public Transform AssCheekRight;
  public Transform LegLeft;
  public Transform LegRight;
  public Transform UpperThighLeft;
  public Transform UpperThighRight;
  public Transform MidThighLeft;
  public Transform MidThighRight;
  public Transform LowerThighLeft;
  public Transform LowerThighRight;
  public Transform KneeLeft;
  public Transform KneeRight;
  public Transform CalveLeft;
  public Transform CalveRight;
  public Transform FootLeft;
  public Transform FootRight;
  public Transform ActualHips;
  public Transform Hips;
  public Transform Hips2;
  public Transform Belly;
  public Transform Waist;
  public Transform Ribcage;
  public Transform Torso;
  public Transform Neck;
  public Transform ShoulderLeft;
  public Transform UpperArmLeft;
  public Transform ForeArmLeft;
  public Transform HandLeft;
  public Transform ShoulderRight;
  public Transform UpperArmRight;
  public Transform ForeArmRight;
  public Transform HandRight;
  public float Height;
  public int CurrentLOD;
  public bool CinematicCharacter;
  public bool _CantBeForced;
  public List<Action> CallWhenHighCol = new List<Action>();
  public bool _DirtySkin;
  public Texture2D MainBodyTex;
  public Texture2D MainFaceTex;
  public Texture2D CustomMainBodyTex;
  public Texture2D CustomMainFaceTex;
  public string sBodyTexIndex;
  public string sFaceTexIndex;
  public string sCustomBodyTexIndex;
  public string sCustomFaceTexIndex;
  public int MaterialTypeNPC;
  public string PunchingAnim;
  public Person PersonThrowingDown;
  public float _CurrentPunchPower;
  public GameObject MeleeHitBox;
  public bool Doing_Punch;
  public bool Doing_ThrowDown;
  public bool Doing_MeleeHit;
  private bool _Punched;
  private Person _personPunching;
  private Quaternion turning_targetRotation;
  private Transform turning_target;
  public e_ClothingCondition ClothingCondition;

  public AudioSource PersonAudio
  {
    get => this.TheHealth.Audio;
    set => this.TheHealth.Audio = value;
  }

  public string HomeAddress => !((UnityEngine.Object) this.Home != (UnityEngine.Object) null) ? "None" : this.Home.name;

  public void SaveOnThisPlay()
  {
    string filename = $"{Main.Instance.CurrentSavePath}{this.WorldSaveID}.chr";
    if (this.IsPlayer)
      filename = !(this is Girl) ? Main.Instance.CurrentSavePath + "Player_m.chr" : Main.Instance.CurrentSavePath + "Player.chr";
    this.SaveToFile(filename);
  }

  public override void SaveToFile(string filename)
  {
    if (this._DirtySkin)
      this.States[0] = true;
    using (BinaryWriter writer = new BinaryWriter((Stream) File.Open(filename, FileMode.Create)))
    {
      writer.Write("10");
      writer.Write(this.WorldSaveID);
      writer.Write(this.Name);
      this.WriteVector3(writer, this.transform.position);
      this.WriteVector3(writer, this.transform.eulerAngles);
      this.WriteVector3(writer, this.transform.localScale);
      this.WriteColor(writer, this.NaturalEyeColor);
      this.WriteColor(writer, this.NaturalHairColor);
      this.WriteColor(writer, this.NaturalSkinColor);
      this.WriteColor(writer, this.DyedEyeColor);
      this.WriteColor(writer, this.DyedHairColor);
      this.WriteColor(writer, this.TannedSkinColor);
      writer.Write(this.HasPenis);
      writer.Write(this.Penis.transform.localScale.x);
      if (this.EquippedClothes.Count == 0)
      {
        writer.Write("None");
      }
      else
      {
        string str = this.EquippedClothes[0].sv_SaveData();
        for (int index = 1; index < this.EquippedClothes.Count; ++index)
        {
          if (this.EquippedClothes[index].BodyPart != DressableType.BackPack)
            str = $"{str};{this.EquippedClothes[index].sv_SaveData()}";
        }
        writer.Write(str);
      }
      for (int index = 0; index < this.AllFaceBones.Length; ++index)
      {
        Transform allFaceBone = this.AllFaceBones[index];
        if ((UnityEngine.Object) allFaceBone != (UnityEngine.Object) null)
        {
          this.WriteVector3(writer, allFaceBone.localPosition);
          this.WriteVector3(writer, allFaceBone.localEulerAngles);
          this.WriteVector3(writer, allFaceBone.localScale);
        }
      }
      for (int index = 0; index < this.AllBodyBones.Length; ++index)
      {
        Transform allBodyBone = this.AllBodyBones[index];
        if ((UnityEngine.Object) allBodyBone != (UnityEngine.Object) null)
        {
          this.WriteVector3(writer, allBodyBone.localPosition);
          this.WriteVector3(writer, allBodyBone.localEulerAngles);
          this.WriteVector3(writer, allBodyBone.localScale);
        }
      }
      writer.Write(this.PlayerKnowsName);
      if (this is Girl)
        writer.Write((this as Girl)._PregnancyPercent);
      else
        writer.Write(0.0f);
      writer.Write((int) this.Personality);
      writer.Write(this.Fetishes.Count);
      for (int index = 0; index < this.Fetishes.Count; ++index)
        writer.Write((int) this.Fetishes[index]);
      writer.Write(this.HomeAddress);
      if ((UnityEngine.Object) this.PersonType == (UnityEngine.Object) null)
        writer.Write(0);
      else
        writer.Write((int) this.PersonType.ThisType);
      writer.Write(this.States.Length);
      for (int index = 0; index < this.States.Length; ++index)
        writer.Write(this.States[index]);
      writer.Write(this.Arousal);
      writer.Write(this.Money);
      writer.Write(this.TheHealth.currentHealth);
      writer.Write(this.TheHealth.maxHealth);
      writer.Write(this.TheHealth.dead);
      writer.Write(this.TheHealth.Incapacitated);
      writer.Write(this.Hunger);
      writer.Write(this.Energy);
      writer.Write(this.Toilet);
      writer.Write(this.HungerMax);
      writer.Write(this.EnergyMax);
      writer.Write(this.ToiletMax);
      writer.Write(this.IntestinalSubstance);
      writer.Write(this.Favor);
      writer.Write(this._SexSkills.Value);
      writer.Write(this._WorkSkills.Value);
      writer.Write(this._ArmySkills.Value);
      writer.Write(this.SexXpThisLvlMax);
      writer.Write(this.SexXpThisLvl);
      writer.Write(this.WorkXpThisLvlMax);
      writer.Write(this.WorkXpThisLvl);
      writer.Write(this.ArmyXpThisLvlMax);
      writer.Write(this.ArmyXpThisLvl);
      writer.Write(this.SecondWeapon);
      writer.Write(this.Height);
      writer.Write(this.Perks.Count);
      for (int index = 0; index < this.Perks.Count; ++index)
        writer.Write(this.Perks[index]);
      writer.Write((int) this.State);
      writer.Write(this.JobIndex);
      if ((UnityEngine.Object) this.WorkJob == (UnityEngine.Object) null)
        writer.Write("NoJob");
      else
        writer.Write(this.WorkJob.JobName);
      writer.Write(this.WeaponInv.weaponIndex);
      writer.Write(this.WeaponInv.weapons.Count);
      for (int index = 0; index < this.WeaponInv.weapons.Count; ++index)
      {
        GameObject weapon = this.WeaponInv.weapons[index];
        if ((UnityEngine.Object) weapon == (UnityEngine.Object) null)
        {
          writer.Write("null");
        }
        else
        {
          Weapon component = weapon.GetComponent<Weapon>();
          writer.Write(component.PrefabName);
        }
      }
      writer.Write(this._SkinStates.Length);
      for (int index = 0; index < this._SkinStates.Length; ++index)
        writer.Write(this._SkinStates[index]);
      writer.Write(this._DirtySkin);
      if ((UnityEngine.Object) this.CurrentZone != (UnityEngine.Object) null)
        writer.Write(this.CurrentZone.name);
      else
        writer.Write("None");
      writer.Write(this.VoicePitch);
      if (this.Interacting && (UnityEngine.Object) this.InteractingWith != (UnityEngine.Object) null)
        writer.Write(this.InteractingWith.WorldSaveID);
      else
        writer.Write("None");
      if ((UnityEngine.Object) this.Storage_Hands == (UnityEngine.Object) null)
        Main.Log(this.Name + " Storage_Hands == null", true);
      else if (this.Storage_Hands.StorageItems == null)
      {
        Main.Log(this.Name + " Storage_Hands.StorageItems == null", true);
      }
      else
      {
        writer.Write(this.Storage_Hands.StorageItems.Count);
        for (int index = 0; index < this.Storage_Hands.StorageItems.Count; ++index)
        {
          writer.Write(this.Storage_Hands.StorageItems[index].GetComponent<SaveableBehaviour>().sv_SaveData());
          this.Storage_Hands.StorageItems[index].SetActive(false);
          Main.Instance.EnableAfterSave.Add(this.Storage_Hands.StorageItems[index]);
        }
        if ((UnityEngine.Object) this.Storage_Vag == (UnityEngine.Object) null)
        {
          writer.Write(0);
        }
        else
        {
          writer.Write(this.Storage_Vag.StorageItems.Count);
          for (int index = 0; index < this.Storage_Vag.StorageItems.Count; ++index)
          {
            writer.Write(this.Storage_Vag.StorageItems[index].GetComponent<SaveableBehaviour>().sv_SaveData());
            this.Storage_Vag.StorageItems[index].SetActive(false);
            Main.Instance.EnableAfterSave.Add(this.Storage_Vag.StorageItems[index]);
          }
        }
        writer.Write(this.Storage_Anal.StorageItems.Count);
        for (int index = 0; index < this.Storage_Anal.StorageItems.Count; ++index)
        {
          writer.Write(this.Storage_Anal.StorageItems[index].GetComponent<SaveableBehaviour>().sv_SaveData());
          this.Storage_Anal.StorageItems[index].SetActive(false);
          Main.Instance.EnableAfterSave.Add(this.Storage_Anal.StorageItems[index]);
        }
        writer.Write(0);
        writer.Write(0);
        if (this is Girl)
        {
          this.WriteVector3(writer, (this as Girl).PregnancyBones_default[0]);
          this.WriteVector3(writer, (this as Girl).PregnancyBones_default[1]);
          this.WriteVector3(writer, (this as Girl).PregnancyBones_default[2]);
          this.WriteVector3(writer, (this as Girl).PregnancyBones_default[3]);
        }
        writer.Write(this.TimesSexedPlayer);
        writer.Write(this.sCustomBodyTexIndex);
        writer.Write(this.sCustomFaceTexIndex);
        if (this is Girl)
        {
          if ((UnityEngine.Object) (this as Girl).PregnancyParent != (UnityEngine.Object) null)
            writer.Write((this as Girl).PregnancyParent.WorldSaveID);
          else
            writer.Write("None");
        }
        writer.Write(this.Fertility);
        writer.Write(this.SaveableVars.Count);
        for (int index = 0; index < this.SaveableVars.Count; ++index)
        {
          writer.Write(this.SaveableVars.Keys[index]);
          writer.Write(this.SaveableVars.Values[index]);
        }
      }
    }
  }

  public override void LoadFromFile(string filename)
  {
    if (!File.Exists(filename))
    {
      Debug.LogError((object) ("Person.LoadFromFile: File doesnt exist " + filename));
    }
    else
    {
      File.ReadAllBytes(filename);
      int offset = 0;
      try
      {
        if (filename.ToUpperInvariant().EndsWith(".PNG"))
          offset = (int) UI_Customize.FindDataStart(filename, UI_Customize.StringToBytes("DataStart"));
        using (BinaryReader reader = new BinaryReader((Stream) File.Open(filename, FileMode.Open)))
        {
          this.VoicePitch = 1f;
          this.Fertility = 1f;
          this.Personality = Personality_Type.Casual;
          this.Fetishes.Clear();
          reader.BaseStream.Seek((long) offset, SeekOrigin.Begin);
          long num1 = reader.BaseStream.Length - 16L /*0x10*/;
          string str1 = reader.ReadString();
          this.WorldSaveID = reader.ReadString();
          this.Name = reader.ReadString().Replace("NPC_", "");
          this.transform.position = this.ReadVector3(reader);
          this.transform.eulerAngles = this.ReadVector3(reader);
          this.transform.localScale = this.ReadVector3(reader);
          this.Height = this.transform.localScale.y;
          this.NaturalEyeColor = this.ReadColor(reader);
          this.NaturalHairColor = this.ReadColor(reader);
          this.NaturalSkinColor = this.ReadColor(reader);
          this.DyedEyeColor = this.ReadColor(reader);
          this.DyedHairColor = this.ReadColor(reader);
          this.TannedSkinColor = this.ReadColor(reader);
          this.HasPenis = reader.ReadBoolean();
          float num2 = reader.ReadSingle();
          this.Penis.transform.localScale = new Vector3(num2, num2, num2);
          this.StartingClothes.Clear();
          this._StartingClothes.Clear();
          string str2 = reader.ReadString();
          if (str2 != "None")
          {
            foreach (string str3 in str2.Split(";", StringSplitOptions.None))
              this._StartingClothes.Add(str3);
          }
          if (this._DontLoadClothing)
          {
            string str4 = string.Empty;
            for (int index1 = 0; index1 < this._StartingClothes.Count; ++index1)
            {
              if (this._StartingClothes[index1] != null && this._StartingClothes[index1].Length != 0)
              {
                string[] strArray = this._StartingClothes[index1].Split(":", StringSplitOptions.None);
                for (int index2 = 0; index2 < Main.Instance.Prefabs_Hair.Count; ++index2)
                {
                  if (!((UnityEngine.Object) Main.Instance.Prefabs_Hair[index2] == (UnityEngine.Object) null) && strArray[0] == Main.Instance.Prefabs_Hair[index2].name)
                  {
                    str4 = this._StartingClothes[index1];
                    goto label_20;
                  }
                }
              }
            }
label_20:
            this.StartingClothes.Clear();
            this._StartingClothes.Clear();
            this._StartingClothes.Add(str4);
          }
          for (int index = 0; index < this.AllFaceBones.Length; ++index)
          {
            Transform allFaceBone = this.AllFaceBones[index];
            if ((UnityEngine.Object) allFaceBone != (UnityEngine.Object) null)
            {
              allFaceBone.localPosition = this.ReadVector3(reader);
              allFaceBone.localEulerAngles = this.ReadVector3(reader);
              allFaceBone.localScale = this.ReadVector3(reader);
            }
          }
          for (int index = 0; index < this.AllBodyBones.Length; ++index)
          {
            Transform allBodyBone = this.AllBodyBones[index];
            if ((UnityEngine.Object) allBodyBone != (UnityEngine.Object) null)
            {
              allBodyBone.localPosition = this.ReadVector3(reader);
              allBodyBone.localEulerAngles = this.ReadVector3(reader);
              allBodyBone.localScale = this.ReadVector3(reader);
            }
          }
          if (!(str1 == "2"))
          {
            if (!(str1 == "2 beta"))
            {
              if (!(str1 == "2 alpha (Highest Patron level)"))
              {
                if (!(str1 == "3"))
                {
                  if (!(str1 == "3.1"))
                  {
                    if (!(str1 == "2"))
                    {
                      if (!(str1 == "2.1"))
                      {
                        if (!(str1 == "2.2"))
                        {
                          this.PlayerKnowsName = reader.ReadBoolean();
                          if ((UnityEngine.Object) this.ThisPersonInt != (UnityEngine.Object) null)
                            this.ThisPersonInt.SetDefaultInteraction();
                          if (!(str1 == "4"))
                          {
                            if (!(str1 == "4.5 (Technical update)"))
                            {
                              float num3 = reader.ReadSingle();
                              this.Personality = (Personality_Type) reader.ReadInt32();
                              int num4 = reader.ReadInt32();
                              for (int index = 0; index < num4; ++index)
                                this.Fetishes.Add((e_Fetish) reader.ReadInt32());
                              if (!(str1 == "5"))
                              {
                                if (reader.BaseStream.Position != num1)
                                {
                                  string str5 = reader.ReadString();
                                  if (str5 != "None")
                                  {
                                    for (int index = 0; index < Main.Instance.AllHomes.Count; ++index)
                                    {
                                      if (Main.Instance.AllHomes[index].name == str5)
                                      {
                                        this.Home = Main.Instance.AllHomes[index];
                                        break;
                                      }
                                    }
                                  }
                                  this.PersonType = Main.Instance.PersonTypes[reader.ReadInt32()];
                                  int num5 = reader.ReadInt32();
                                  for (int index = 0; index < num5; ++index)
                                    this.States[index] = reader.ReadBoolean();
                                  this.Arousal = reader.ReadSingle();
                                  this.Money = reader.ReadInt32();
                                  this.TheHealth.currentHealth = reader.ReadSingle();
                                  this.TheHealth.startingHealth = this.TheHealth.currentHealth;
                                  this.TheHealth.maxHealth = reader.ReadSingle();
                                  int num6 = reader.ReadBoolean() ? 1 : 0;
                                  bool flag = reader.ReadBoolean();
                                  if (num6 != 0)
                                    this.TheHealth.Die(false);
                                  else if (flag)
                                    this.TheHealth.Incapacitate();
                                  this.Hunger = reader.ReadSingle();
                                  this.Energy = reader.ReadSingle();
                                  this.Toilet = reader.ReadSingle();
                                  this.HungerMax = reader.ReadSingle();
                                  this.EnergyMax = reader.ReadSingle();
                                  this.ToiletMax = reader.ReadSingle();
                                  this.IntestinalSubstance = reader.ReadInt32();
                                  this.Favor = reader.ReadInt32();
                                  this._SexSkills.Value = reader.ReadInt32();
                                  this._WorkSkills.Value = reader.ReadInt32();
                                  this._ArmySkills.Value = reader.ReadInt32();
                                  this.SexXpThisLvlMax = reader.ReadInt32();
                                  this.SexXpThisLvl = reader.ReadInt32();
                                  this.WorkXpThisLvlMax = reader.ReadInt32();
                                  this.WorkXpThisLvl = reader.ReadInt32();
                                  this.ArmyXpThisLvlMax = reader.ReadInt32();
                                  this.ArmyXpThisLvl = reader.ReadInt32();
                                  this.SecondWeapon = reader.ReadBoolean();
                                  this.Height = reader.ReadSingle();
                                  if ((double) this.Height == 0.0)
                                    this.Height = this.transform.localScale.y;
                                  else
                                    this.transform.localScale = new Vector3(this.Height, this.Height, this.Height);
                                  int num7 = reader.ReadInt32();
                                  for (int index = 0; index < num7; ++index)
                                    this.Perks.Add(reader.ReadString());
                                  this.State = (Person_State) reader.ReadInt32();
                                  this.JobIndex = reader.ReadInt32();
                                  string str6 = reader.ReadString();
                                  if (str6 != "NoJob")
                                  {
                                    for (int index = 0; index < Main.Instance.AllJobs.Count; ++index)
                                    {
                                      if (Main.Instance.AllJobs[index].JobName == str6)
                                      {
                                        this.WorkJob = Main.Instance.AllJobs[index];
                                        this.WorkJob.AddWorker(this);
                                        break;
                                      }
                                    }
                                  }
                                  this.WeaponInv.startingWeaponIndex = reader.ReadInt32();
                                  int num8 = reader.ReadInt32();
                                  this._StartingWeapons.Clear();
                                  for (int index = 0; index < num8; ++index)
                                    this._StartingWeapons.Add(reader.ReadString());
                                  int length = reader.ReadInt32();
                                  this._SkinStates = new bool[length];
                                  for (int index = 0; index < length; ++index)
                                    this._SkinStates[index] = reader.ReadBoolean();
                                  this._DirtySkin = reader.ReadBoolean();
                                  string str7 = reader.ReadString();
                                  if (str7 != "None")
                                  {
                                    for (int index = 0; index < Main.Instance.AllHomes.Count; ++index)
                                    {
                                      if (Main.Instance.AllHomes[index].name == str7)
                                      {
                                        this.CurrentZone = Main.Instance.AllHomes[index];
                                        break;
                                      }
                                    }
                                  }
                                  float num9 = reader.ReadSingle();
                                  if ((double) num9 > 0.30000001192092896 && (double) num9 < 1.2000000476837158)
                                    this.VoicePitch = num9;
                                  string str8 = reader.ReadString();
                                  if (!this._DontLoadInteraction && str8 != "None" && str8.Length > 0)
                                  {
                                    Interactible[] objectsOfType = UnityEngine.Object.FindObjectsOfType<Interactible>(true);
                                    for (int index = 0; index < objectsOfType.Length; ++index)
                                    {
                                      if (objectsOfType[index].WorldSaveID == str8)
                                      {
                                        if (!objectsOfType[index].DontSaveInMain)
                                        {
                                          string interactText = objectsOfType[index].InteractText;
                                          if (!(interactText == "Use") && !(interactText == "Sit"))
                                          {
                                            objectsOfType[index].Interact(this);
                                            break;
                                          }
                                          break;
                                        }
                                        break;
                                      }
                                    }
                                  }
                                  if (reader.BaseStream.Position == num1)
                                  {
                                    if (this is Girl)
                                      this.States[22] = true;
                                  }
                                  else
                                  {
                                    int num10 = reader.ReadInt32();
                                    for (int index3 = 0; index3 < num10; ++index3)
                                    {
                                      string str9 = reader.ReadString();
                                      if (str9 != null && str9.Length != 0)
                                      {
                                        if (str9.Contains(":"))
                                        {
                                          string[] Data = str9.Split(":", StringSplitOptions.None);
                                          for (int index4 = 0; index4 < Main.Instance.AllPrefabs.Count; ++index4)
                                          {
                                            if (Main.Instance.AllPrefabs[index4].name == Data[1])
                                            {
                                              GameObject gameObject = Main.Spawn(Main.Instance.AllPrefabs[index4], saveable: true);
                                              Interactible component = gameObject.GetComponent<Interactible>();
                                              if ((UnityEngine.Object) component != (UnityEngine.Object) null)
                                                component.sd_LoadData(Data, ':');
                                              gameObject.GetComponentInChildren<int_PickupToHand>(true).EquipToHand(this);
                                              break;
                                            }
                                          }
                                        }
                                        else
                                        {
                                          for (int index5 = 0; index5 < Main.Instance.AllPrefabs.Count; ++index5)
                                          {
                                            if (Main.Instance.AllPrefabs[index5].name == str9)
                                            {
                                              Main.Spawn(Main.Instance.AllPrefabs[index5], saveable: true).GetComponentInChildren<int_PickupToHand>(true).EquipToHand(this);
                                              break;
                                            }
                                          }
                                        }
                                      }
                                    }
                                    int num11 = reader.ReadInt32();
                                    for (int index6 = 0; index6 < num11; ++index6)
                                    {
                                      string str10 = reader.ReadString();
                                      if (str10 != null && str10.Length != 0)
                                      {
                                        if (str10.Contains(":"))
                                        {
                                          string[] Data = str10.Split(":", StringSplitOptions.None);
                                          for (int index7 = 0; index7 < Main.Instance.AllPrefabs.Count; ++index7)
                                          {
                                            if (Main.Instance.AllPrefabs[index7].name == Data[1])
                                            {
                                              GameObject gameObject = Main.Spawn(Main.Instance.AllPrefabs[index7], saveable: true);
                                              Interactible component = gameObject.GetComponent<Interactible>();
                                              if ((UnityEngine.Object) component != (UnityEngine.Object) null)
                                                component.sd_LoadData(Data, ':');
                                              gameObject.GetComponentInChildren<int_PickupToHand>(true).EquipToVag(this);
                                              break;
                                            }
                                          }
                                        }
                                        else
                                        {
                                          for (int index8 = 0; index8 < Main.Instance.AllPrefabs.Count; ++index8)
                                          {
                                            if (Main.Instance.AllPrefabs[index8].name == str10)
                                            {
                                              Main.Spawn(Main.Instance.AllPrefabs[index8], saveable: true).GetComponentInChildren<int_PickupToHand>(true).EquipToVag(this);
                                              break;
                                            }
                                          }
                                        }
                                      }
                                    }
                                    int num12 = reader.ReadInt32();
                                    for (int index9 = 0; index9 < num12; ++index9)
                                    {
                                      string str11 = reader.ReadString();
                                      if (str11 != null && str11.Length != 0)
                                      {
                                        if (str11.Contains(":"))
                                        {
                                          string[] Data = str11.Split(":", StringSplitOptions.None);
                                          for (int index10 = 0; index10 < Main.Instance.AllPrefabs.Count; ++index10)
                                          {
                                            if (Main.Instance.AllPrefabs[index10].name == Data[1])
                                            {
                                              GameObject gameObject = Main.Spawn(Main.Instance.AllPrefabs[index10], saveable: true);
                                              Interactible component = gameObject.GetComponent<Interactible>();
                                              if ((UnityEngine.Object) component != (UnityEngine.Object) null)
                                                component.sd_LoadData(Data, ':');
                                              gameObject.GetComponentInChildren<int_PickupToHand>(true).EquipToAss(this);
                                              break;
                                            }
                                          }
                                        }
                                        else
                                        {
                                          for (int index11 = 0; index11 < Main.Instance.AllPrefabs.Count; ++index11)
                                          {
                                            if (Main.Instance.AllPrefabs[index11].name == str11)
                                            {
                                              Main.Spawn(Main.Instance.AllPrefabs[index11], saveable: true).GetComponentInChildren<int_PickupToHand>(true).EquipToAss(this);
                                              break;
                                            }
                                          }
                                        }
                                      }
                                    }
                                    if (reader.BaseStream.Position != num1)
                                    {
                                      int num13 = reader.ReadInt32();
                                      this._CustomSkinStates = new bool[Main.Instance._CustomBodySkinsName.Count];
                                      for (int index = 0; index < num13; ++index)
                                        this._CustomSkinStates[index] = reader.ReadBoolean();
                                      int num14 = reader.ReadInt32();
                                      this._CustomFaceSkinStates = new bool[Main.Instance._CustomFaceSkinsName.Count];
                                      for (int index = 0; index < num14; ++index)
                                        this._CustomFaceSkinStates[index] = reader.ReadBoolean();
                                      if (this is Girl)
                                      {
                                        (this as Girl)._PregBonesSet = true;
                                        (this as Girl).PregnancyBones_default[0] = this.ReadVector3(reader);
                                        (this as Girl).PregnancyBones_default[1] = this.ReadVector3(reader);
                                        (this as Girl).PregnancyBones_default[2] = this.ReadVector3(reader);
                                        (this as Girl).PregnancyBones_default[3] = this.ReadVector3(reader);
                                        if ((double) num3 != 0.0)
                                          (this as Girl).PregnancyPercent = num3;
                                      }
                                      this.TimesSexedPlayer = reader.ReadInt32();
                                      if (reader.BaseStream.Position != num1)
                                      {
                                        this.sCustomBodyTexIndex = reader.ReadString();
                                        this.sCustomFaceTexIndex = reader.ReadString();
                                        this._CustomSkinStates = new bool[Main.Instance._CustomBodySkinsName.Count];
                                        foreach (string str12 in this.sCustomBodyTexIndex.Split(":", StringSplitOptions.None))
                                        {
                                          for (int index = 0; index < Main.Instance._CustomBodySkinsName.Count; ++index)
                                          {
                                            if (Main.Instance._CustomBodySkinsName[index] == str12)
                                              this._CustomSkinStates[index] = true;
                                          }
                                        }
                                        this._CustomFaceSkinStates = new bool[Main.Instance._CustomFaceSkinsName.Count];
                                        foreach (string str13 in this.sCustomFaceTexIndex.Split(":", StringSplitOptions.None))
                                        {
                                          for (int index = 0; index < Main.Instance._CustomFaceSkinsName.Count; ++index)
                                          {
                                            if (Main.Instance._CustomFaceSkinsName[index] == str13)
                                              this._CustomFaceSkinStates[index] = true;
                                          }
                                        }
                                        if (reader.BaseStream.Position != num1)
                                        {
                                          if (this is Girl)
                                          {
                                            string str14 = reader.ReadString();
                                            if (str14 != "None")
                                              (this as Girl).s_PregnancyParent = str14;
                                          }
                                          if (reader.BaseStream.Position != num1)
                                          {
                                            this.Fertility = reader.ReadSingle();
                                            if (reader.BaseStream.Position != num1)
                                            {
                                              int num15 = reader.ReadInt32();
                                              for (int index = 0; index < num15; ++index)
                                                this.SaveableVars.Add(reader.ReadString(), reader.ReadString());
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
                      }
                    }
                  }
                }
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        Debug.LogError((object) ("Error loading character " + filename));
        Debug.LogError((object) ex.Message);
        Debug.LogError((object) ex.StackTrace);
      }
      if (this.Inited)
        return;
      this.Init();
    }
  }

  public override string[] sd_SaveData(char SlitChar = ':')
  {
    List<string> stringList1 = new List<string>();
    stringList1.Add("10");
    stringList1.Add(this.WorldSaveID);
    stringList1.Add(this.Name);
    stringList1.Add(this.transform.position.ToString());
    stringList1.Add(this.transform.eulerAngles.ToString());
    stringList1.Add(this.transform.localScale.ToString());
    stringList1.Add(this.NaturalEyeColor.ToString());
    stringList1.Add(this.NaturalHairColor.ToString());
    stringList1.Add(this.NaturalSkinColor.ToString());
    stringList1.Add(this.DyedEyeColor.ToString());
    stringList1.Add(this.DyedHairColor.ToString());
    stringList1.Add(this.TannedSkinColor.ToString());
    stringList1.Add(this.HasPenis ? "1" : "0");
    stringList1.Add(this.Penis.transform.localScale.x.ToString());
    stringList1.Add((UnityEngine.Object) this.CurrentHair == (UnityEngine.Object) null ? "None" : this.CurrentHair.name);
    Vector3 vector3;
    for (int index = 0; index < this.AllFaceBones.Length; ++index)
    {
      Transform allFaceBone = this.AllFaceBones[index];
      if ((UnityEngine.Object) allFaceBone != (UnityEngine.Object) null)
      {
        List<string> stringList2 = stringList1;
        vector3 = allFaceBone.localPosition;
        string str1 = vector3.ToString();
        stringList2.Add(str1);
        List<string> stringList3 = stringList1;
        vector3 = allFaceBone.localEulerAngles;
        string str2 = vector3.ToString();
        stringList3.Add(str2);
        List<string> stringList4 = stringList1;
        vector3 = allFaceBone.localScale;
        string str3 = vector3.ToString();
        stringList4.Add(str3);
      }
    }
    for (int index = 0; index < this.AllBodyBones.Length; ++index)
    {
      Transform allBodyBone = this.AllBodyBones[index];
      if ((UnityEngine.Object) allBodyBone != (UnityEngine.Object) null)
      {
        List<string> stringList5 = stringList1;
        vector3 = allBodyBone.localPosition;
        string str4 = vector3.ToString();
        stringList5.Add(str4);
        List<string> stringList6 = stringList1;
        vector3 = allBodyBone.localEulerAngles;
        string str5 = vector3.ToString();
        stringList6.Add(str5);
        List<string> stringList7 = stringList1;
        vector3 = allBodyBone.localScale;
        string str6 = vector3.ToString();
        stringList7.Add(str6);
      }
    }
    return stringList1.ToArray();
  }

  public override void sd_LoadData(string[] Data, char SlitChar = ':')
  {
    base.sd_LoadData(Data, SlitChar);
    if (Data[0] != "10")
      Debug.LogError((object) "DiferentVersion");
    this.WorldSaveID = Data[1];
    this.Name = Data[2];
  }

  public bool CanMove
  {
    get => this.MoveBlockers.Count == 0;
    set
    {
      if (this.IsPlayer)
      {
        Main.Instance.Player.UserControl.StopMoving();
        Main.Instance.Player.UserControl.enabled = value;
        if (!value)
          return;
        Main.Instance.Player.Anim.Play("GainControl");
      }
      else if (value)
      {
        this.navMesh.enabled = true;
        if (this.navMesh.isOnNavMesh)
          this.navMesh.isStopped = false;
        this.SetDestination(this._Destination);
      }
      else
      {
        if (this.navMesh.isOnNavMesh)
          this.navMesh.isStopped = true;
        this.navMesh.enabled = false;
      }
    }
  }

  public bool TempAggroContainsID(Person_Type ID)
  {
    for (int index = 0; index < this.TempAggroToType.Count; ++index)
    {
      if (this.TempAggroToType[index].TheType == ID)
        return true;
    }
    return false;
  }

  public bool TempAggroMelee(Person_Type ID)
  {
    bool flag = false;
    for (int index = 0; index < this.TempAggroToType.Count; ++index)
    {
      if (this.TempAggroToType[index].TheType == ID && this.TempAggroToType[index].Melee)
        return true;
    }
    return flag;
  }

  public int TempAggroContains(Person_Type ID, string flagger)
  {
    for (int index = 0; index < this.TempAggroToType.Count; ++index)
    {
      if (this.TempAggroToType[index].TheType == ID && this.TempAggroToType[index].Flagger == flagger)
        return index;
    }
    return -1;
  }

  public void AddTempAggroToType(Person_Type ID, string flagger, bool melee = false)
  {
    if (this.TempAggroContains(ID, flagger) != -1)
      return;
    this.TempAggroToType.Add(new Person.TempAggroStruct()
    {
      TheType = ID,
      Flagger = flagger,
      Melee = melee
    });
  }

  public void RemoveTempAggroToType(Person_Type ID, string flagger)
  {
    int index = this.TempAggroContains(ID, flagger);
    if (index == -1)
      return;
    this.TempAggroToType.RemoveAt(index);
  }

  public void RemoveAllTempAggro() => this.TempAggroToType.Clear();

  public void RemoveAllTempAggroToFlagger(string flagger)
  {
    int index = 0;
    while (index < this.TempAggroToType.Count)
    {
      if (this.TempAggroToType[index].Flagger == flagger)
        this.TempAggroToType.RemoveAt(index);
      else
        ++index;
    }
  }

  public void AddMoveBlocker(string blockerID)
  {
    if (this.MoveBlockers.Contains(blockerID))
      return;
    this.MoveBlockers.Add(blockerID);
    this.CanMove = false;
  }

  public void RemoveMoveBlocker(string blockerID)
  {
    if (this.MoveBlockers.Contains(blockerID))
      this.MoveBlockers.Remove(blockerID);
    if (this.MoveBlockers.Count != 0)
      return;
    this.CanMove = true;
  }

  public bool HasMoveBlocker(string blockerID) => this.MoveBlockers.Contains(blockerID);

  public bool CanRun
  {
    get => this._CanRun;
    set => this._CanRun = value;
  }

  public void AddRunBlocker(string blockerID)
  {
    if (this.RunBlockers.Contains(blockerID))
      return;
    this.RunBlockers.Add(blockerID);
    this.CanRun = false;
  }

  public void RemoveRunBlocker(string blockerID)
  {
    if (this.RunBlockers.Contains(blockerID))
      this.RunBlockers.Remove(blockerID);
    if (this.RunBlockers.Count != 0)
      return;
    this.CanRun = true;
  }

  public bool Masturbating
  {
    get => this._Masturbating;
    set
    {
      this._Masturbating = value;
      if (value)
      {
        this.ApplyFaceBlendShapeData(Main.Instance.BlendShapesDatas[2]);
      }
      else
      {
        this.ResetAllShapes();
        if (!this._StartedMastPP)
          return;
        this._StartedMastPP = false;
        this.ResetPenisBones();
        if (!((UnityEngine.Object) this.CurrentPants != (UnityEngine.Object) null) && !((UnityEngine.Object) this.CurrentUnderwearLower != (UnityEngine.Object) null))
          return;
        this.RemovePenis();
      }
    }
  }

  public bool Aiming
  {
    get => this.InCombat;
    set => this.InCombat = value;
  }

  public string Name
  {
    get => this._Name;
    set
    {
      this._Name = value;
      this.gameObject.name = value;
    }
  }

  public bool DyedHair => this.DyedHairColor != new Color(0.0f, 0.0f, 0.0f, 0.0f);

  public bool DyedEyes => this.DyedEyeColor != new Color(0.0f, 0.0f, 0.0f, 0.0f);

  public bool IsHungry => (double) this.Hunger > 50.0;

  public bool NeedsEnergy => (double) this.Energy < 25.0;

  public bool NeedsToilet => (double) this.Toilet > 50.0;

  public bool[] States
  {
    set
    {
      if (this._States == null || this._States.Length != 34)
        this._States = new bool[34];
      this._States = value;
      if (this._SkinStates == null || this._SkinStates.Length != 15)
        this._SkinStates = new bool[15];
      if (this._FaceSkinStates == null || this._FaceSkinStates.Length != 16 /*0x10*/)
        this._FaceSkinStates = new bool[16 /*0x10*/];
      this._SkinStates[1] = this._States[0];
      this._SkinStates[2] = this._States[2];
      this._SkinStates[3] = this._States[3];
      this._SkinStates[7] = this._States[12];
      this._SkinStates[8] = this._States[13];
      this._SkinStates[9] = this._States[14];
      this._SkinStates[10] = this._States[15];
      this._SkinStates[11] = this._States[16 /*0x10*/];
      this._SkinStates[4] = this._States[17];
      this._SkinStates[5] = this._States[18];
      this._SkinStates[6] = this._States[19];
      this._SkinStates[12] = this._States[20];
      this._SkinStates[13] = this._States[21];
      this._FaceSkinStates[9] = this._States[0];
      this._FaceSkinStates[1] = this._States[22];
      this._FaceSkinStates[2] = this._States[27];
      this._FaceSkinStates[15] = this._States[8];
      this._FaceSkinStates[11] = this._States[26];
      this._FaceSkinStates[3] = this._States[32 /*0x20*/];
      this._FaceSkinStates[5] = this._States[28];
      this._FaceSkinStates[7] = this._States[29];
      this._FaceSkinStates[6] = this._States[30];
      this._FaceSkinStates[4] = this._States[31 /*0x1F*/];
      this._FaceSkinStates[12] = this._States[23];
      this._FaceSkinStates[13] = this._States[24];
      this._FaceSkinStates[14] = this._States[25];
      this._FaceSkinStates[10] = this._States[33];
      this._FaceSkinStates[8] = this._States[19];
    }
    get
    {
      if (this._States == null || this._States.Length != 34)
        this._States = new bool[34];
      if (this._SkinStates == null || this._SkinStates.Length != 15)
        this._SkinStates = new bool[15];
      if (this._FaceSkinStates == null || this._FaceSkinStates.Length != 16 /*0x10*/)
        this._FaceSkinStates = new bool[16 /*0x10*/];
      return this._States;
    }
  }

  public bl_Personality PersonalityData
  {
    get
    {
      if ((UnityEngine.Object) this._PersonalityData == (UnityEngine.Object) null)
        this._PersonalityData = Main.Instance.Personalities[0];
      return this._PersonalityData;
    }
    set => this._PersonalityData = value;
  }

  public int RelatioshipLevel => this.Favor >= 100 ? 1 : 0;

  public int SexSkills
  {
    set
    {
      if (this._SexSkills == null)
        this._SexSkills = new intsafe();
      this._SexSkills.Value = value;
      this.SexXpThisLvlMax = this._SexSkills.Value * 500;
    }
    get => this._SexSkills.Value;
  }

  public int WorkSkills
  {
    set
    {
      if (this._WorkSkills == null)
        this._WorkSkills = new intsafe();
      this._WorkSkills.Value = value;
      this.WorkXpThisLvlMax = this._WorkSkills.Value * 500;
    }
    get => this._WorkSkills.Value;
  }

  public int ArmySkills
  {
    set
    {
      if (this._ArmySkills == null)
        this._ArmySkills = new intsafe();
      this._ArmySkills.Value = value;
      this.ArmyXpThisLvlMax = this._ArmySkills.Value * 500;
    }
    get => this._ArmySkills.Value;
  }

  public override void Start()
  {
    this.Init();
    if (!this.IsPlayer)
      return;
    this.UserControl.FirstPerson = false;
  }

  public virtual void Init()
  {
    if (this.Inited)
      return;
    this.Inited = true;
    if (this._CustomSkinStates == null || this._CustomSkinStates.Length == 0)
      this._CustomSkinStates = new bool[Main.Instance._CustomBodySkinsName.Count];
    if (this._CustomFaceSkinStates == null || this._CustomFaceSkinStates.Length == 0)
      this._CustomFaceSkinStates = new bool[Main.Instance._CustomFaceSkinsName.Count];
    if (this.UnparentOnStart)
      this.transform.SetParent((Transform) null, true);
    if (!Main.Instance.SpawnedPeople.Contains(this))
      Main.Instance.SpawnedPeople.Add(this);
    if (this._States.Length != 34)
    {
      this.States = new bool[34];
      if (this is Girl)
        this.States[22] = true;
    }
    if (this is Guy || this is Girl && ((Girl) this).Futa)
    {
      if (!this.SquirtSpots.Contains(this.PenisBones[6]))
        this.SquirtSpots.Add(this.PenisBones[6]);
      this.HasPenis = true;
      this.PutPenis();
    }
    for (int index = 0; index < this.StartingWeapons.Count; ++index)
    {
      GameObject weapon = Main.Spawn(this.StartingWeapons[index]);
      weapon.GetComponent<Weapon>();
      this.WeaponInv.PickupWeapon(weapon);
    }
    for (int index = 0; index < this.StartingClothes.Count; ++index)
      this.DressClothe(this.StartingClothes[index]);
    for (int index1 = 0; index1 < this._StartingClothes.Count; ++index1)
    {
      string assetName = this._StartingClothes[index1].Split(":", StringSplitOptions.None)[0];
      GameObject prefab;
      for (int index2 = 0; index2 < Main.Instance.Prefabs_Any.Count; ++index2)
      {
        if ((UnityEngine.Object) Main.Instance.Prefabs_Any[index2] != (UnityEngine.Object) null && Main.Instance.Prefabs_Any[index2].name == assetName)
        {
          prefab = Main.Instance.Prefabs_Any[index2];
          goto label_94;
        }
      }
      for (int index3 = 0; index3 < Main.Instance.Prefabs_Bodies.Count; ++index3)
      {
        if ((UnityEngine.Object) Main.Instance.Prefabs_Bodies[index3] != (UnityEngine.Object) null && Main.Instance.Prefabs_Bodies[index3].name == assetName)
        {
          prefab = Main.Instance.Prefabs_Bodies[index3];
          goto label_94;
        }
      }
      for (int index4 = 0; index4 < Main.Instance.Prefabs_Garter.Count; ++index4)
      {
        if ((UnityEngine.Object) Main.Instance.Prefabs_Garter[index4] != (UnityEngine.Object) null && Main.Instance.Prefabs_Garter[index4].name == assetName)
        {
          prefab = Main.Instance.Prefabs_Garter[index4];
          goto label_94;
        }
      }
      for (int index5 = 0; index5 < Main.Instance.Prefabs_Hair.Count; ++index5)
      {
        if ((UnityEngine.Object) Main.Instance.Prefabs_Hair[index5] != (UnityEngine.Object) null && Main.Instance.Prefabs_Hair[index5].name == assetName)
        {
          prefab = Main.Instance.Prefabs_Hair[index5];
          goto label_94;
        }
      }
      for (int index6 = 0; index6 < Main.Instance.Prefabs_Hat.Count; ++index6)
      {
        if ((UnityEngine.Object) Main.Instance.Prefabs_Hat[index6] != (UnityEngine.Object) null && Main.Instance.Prefabs_Hat[index6].name == assetName)
        {
          prefab = Main.Instance.Prefabs_Hat[index6];
          goto label_94;
        }
      }
      for (int index7 = 0; index7 < Main.Instance.Prefabs_Heads.Count; ++index7)
      {
        if ((UnityEngine.Object) Main.Instance.Prefabs_Heads[index7] != (UnityEngine.Object) null && Main.Instance.Prefabs_Heads[index7].name == assetName)
        {
          prefab = Main.Instance.Prefabs_Heads[index7];
          goto label_94;
        }
      }
      for (int index8 = 0; index8 < Main.Instance.Prefabs_Pants.Count; ++index8)
      {
        if ((UnityEngine.Object) Main.Instance.Prefabs_Pants[index8] != (UnityEngine.Object) null && Main.Instance.Prefabs_Pants[index8].name == assetName)
        {
          prefab = Main.Instance.Prefabs_Pants[index8];
          goto label_94;
        }
      }
      for (int index9 = 0; index9 < Main.Instance.Prefabs_Shoes.Count; ++index9)
      {
        if ((UnityEngine.Object) Main.Instance.Prefabs_Shoes[index9] != (UnityEngine.Object) null && Main.Instance.Prefabs_Shoes[index9].name == assetName)
        {
          prefab = Main.Instance.Prefabs_Shoes[index9];
          goto label_94;
        }
      }
      for (int index10 = 0; index10 < Main.Instance.Prefabs_Socks.Count; ++index10)
      {
        if ((UnityEngine.Object) Main.Instance.Prefabs_Socks[index10] != (UnityEngine.Object) null && Main.Instance.Prefabs_Socks[index10].name == assetName)
        {
          prefab = Main.Instance.Prefabs_Socks[index10];
          goto label_94;
        }
      }
      for (int index11 = 0; index11 < Main.Instance.Prefabs_Top.Count; ++index11)
      {
        if ((UnityEngine.Object) Main.Instance.Prefabs_Top[index11] != (UnityEngine.Object) null && Main.Instance.Prefabs_Top[index11].name == assetName)
        {
          prefab = Main.Instance.Prefabs_Top[index11];
          goto label_94;
        }
      }
      for (int index12 = 0; index12 < Main.Instance.Prefabs_UnderwearLower.Count; ++index12)
      {
        if ((UnityEngine.Object) Main.Instance.Prefabs_UnderwearLower[index12] != (UnityEngine.Object) null && Main.Instance.Prefabs_UnderwearLower[index12].name == assetName)
        {
          prefab = Main.Instance.Prefabs_UnderwearLower[index12];
          goto label_94;
        }
      }
      for (int index13 = 0; index13 < Main.Instance.Prefabs_UnderwearTop.Count; ++index13)
      {
        if ((UnityEngine.Object) Main.Instance.Prefabs_UnderwearTop[index13] != (UnityEngine.Object) null && Main.Instance.Prefabs_UnderwearTop[index13].name == assetName)
        {
          prefab = Main.Instance.Prefabs_UnderwearTop[index13];
          goto label_94;
        }
      }
      for (int index14 = 0; index14 < Main.Instance.Prefabs_Beards.Count; ++index14)
      {
        if ((UnityEngine.Object) Main.Instance.Prefabs_Beards[index14] != (UnityEngine.Object) null && Main.Instance.Prefabs_Beards[index14].name == assetName)
        {
          prefab = Main.Instance.Prefabs_Beards[index14];
          goto label_94;
        }
      }
      for (int index15 = 0; index15 < Main.Instance.AllPrefabs.Count; ++index15)
      {
        if ((UnityEngine.Object) Main.Instance.AllPrefabs[index15] != (UnityEngine.Object) null && Main.Instance.AllPrefabs[index15].name == assetName)
        {
          prefab = Main.Instance.AllPrefabs[index15];
          goto label_94;
        }
      }
      prefab = Main.Instance.SpawnFromCustomBundle(assetName);
      int num = (UnityEngine.Object) prefab != (UnityEngine.Object) null ? 1 : 0;
label_94:
      if ((UnityEngine.Object) prefab == (UnityEngine.Object) null)
      {
        if (assetName != "invmouthopen2")
        {
          Debug.LogError((object) $"Missing Asset> {this.Name} > {assetName}");
          Main.Instance.GameplayMenu.MissingModsNotif.SetActive(true);
        }
      }
      else
        this.DressClothe(prefab, clothingData: this._StartingClothes[index1]);
    }
    this._StartingClothes.Clear();
    for (int index16 = 0; index16 < this._StartingWeapons.Count; ++index16)
    {
      for (int index17 = 0; index17 < Main.Instance.Prefabs_Weapons.Count; ++index17)
      {
        if ((UnityEngine.Object) Main.Instance.Prefabs_Weapons[index17] != (UnityEngine.Object) null && Main.Instance.Prefabs_Weapons[index17].name == this._StartingWeapons[index16])
          this.WeaponInv.PickupWeapon(Main.Spawn(Main.Instance.Prefabs_Weapons[index17].gameObject));
      }
    }
    this._StartingWeapons.Clear();
    this.PersonalityData = Main.Instance.Personalities[(int) this.Personality];
    this.PersonalityData.OnSpawn(this);
    this.RefreshColors();
    for (int index = 0; index < this.OnFinallyInited.Count; ++index)
      this.OnFinallyInited[index]();
    this.OnFinallyInited.Clear();
  }

  public void SetDestination(Transform destination) => this.SetDestination(destination.position);

  public void SetDestination(Vector3 destination)
  {
    if (this.navMesh.isOnNavMesh)
      this.navMesh.isStopped = false;
    this._Destination = destination;
    if (!(this._Destination != Vector3.zero) || !this.navMesh.isOnNavMesh)
      return;
    this.navMesh.SetDestination(this._Destination);
  }

  public void ShitOnFloor()
  {
    this.enabled = false;
    this.AddMoveBlocker("ShitingFloor");
    this.Anim.Play("scatAnim1");
    Transform transform = this.Holes[1].Find("shitter");
    if ((UnityEngine.Object) transform == (UnityEngine.Object) null)
    {
      transform = new GameObject("shitter").transform;
      transform.SetParent(this.Holes[1]);
      transform.transform.localPosition = Vector3.zero;
      transform.transform.localEulerAngles = new Vector3(45f, 0.0f, 90f);
    }
    if (this.IntestinalSubstance == 1)
    {
      this._scatexiting = UnityEngine.Object.Instantiate<GameObject>(Main.Instance.PileOfScatsGoos[2], transform);
      this._scatexiting.GetComponent<Rigidbody>().isKinematic = true;
      this._scatexiting.GetComponent<Collider>().enabled = false;
      this._scatexiting.GetComponent<MultiInteractible>().enabled = false;
      this._scatexiting.GetComponent<int_Dragable>().enabled = false;
    }
    else
      this._scatexiting = UnityEngine.Object.Instantiate<GameObject>(Main.Instance.PileOfScat, transform);
    this._scatexiting.transform.localEulerAngles = Vector3.zero;
    this._StartShitAtStartShitActual = this.Toilet;
    this._StartShitAtStartShit = (float) (1.0 - (double) this.Toilet / (double) this.ToiletMax);
    Main.Instance.MainThreads.Add(new Action(this.Shiting));
    if ((UnityEngine.Object) this.CurrentPants != (UnityEngine.Object) null)
    {
      foreach (Renderer componentsInChild in this.CurrentPants.GetComponentsInChildren<SkinnedMeshRenderer>())
        componentsInChild.enabled = false;
    }
    if ((UnityEngine.Object) this.CurrentUnderwearLower != (UnityEngine.Object) null)
    {
      foreach (Renderer componentsInChild in this.CurrentUnderwearLower.GetComponentsInChildren<SkinnedMeshRenderer>())
        componentsInChild.enabled = false;
    }
    if (this.IsPlayer)
    {
      this.UserControl.FirstPerson = false;
      Main.Instance.GameplayMenu.WeaponReloadUI.SetActive(true);
      this.UserControl.Pivot.localPosition = new Vector3(0.0f, 0.5f, 0.0f);
    }
    if (this.IntestinalSubstance == 1)
    {
      Main.Instance.GlobalAudio.PlayOneShot(Main.Instance.ShitSounds[4]);
      GameObject gameObject = Main.Spawn(Main.Instance.PileOfScatsGoos[0]);
      gameObject.transform.SetPositionAndRotation(this.transform.position - new Vector3(0.0f, 0.04f, 0.0f), Quaternion.Euler(0.0f, (float) UnityEngine.Random.Range(0, 359), 0.0f));
      int_Scat componentInChildren = gameObject.GetComponentInChildren<int_Scat>();
      componentInChildren.Nutrition = int_Scat.NutritionOfToilet(this._StartShitAtStartShitActual);
      componentInChildren.SetSizeOnSpawn();
    }
    else
      Main.Instance.GlobalAudio.PlayOneShot(Main.Instance.ShitSounds[UnityEngine.Random.Range(0, Main.Instance.ShitSounds.Count)]);
  }

  public void SleepOnFloor()
  {
    if (this.InCombat)
      this.StopFighting(false);
    if (this.Interacting)
    {
      if (!this.InteractingWith.CanLeave)
        return;
      this.InteractingWith.StopInteracting();
    }
    this.enabled = false;
    this.AddMoveBlocker("SleepingFloor");
    if (this.IsPlayer)
      this.Anim.Play("FloorSleep1");
    else
      this.Anim.Play("Sleeping Idle");
    this.BlendShape("e01_close", 100f);
    this.Interacting = true;
    this.LookAtPlayer.enabled = false;
    this.LookAtPlayer.Disable = true;
    if ((UnityEngine.Object) this.ThisPersonInt != (UnityEngine.Object) null)
      this.ThisPersonInt.AddBlocker("Sleeping");
    if ((double) this.EnergyMax - 10.0 < (double) this.Energy)
      this.Energy = this.EnergyMax - 10f;
    Main.Instance.MainThreads.Add(new Action(this.Sleeping));
    if (this.IsPlayer)
    {
      this.UserControl.FirstPerson = false;
      this.UserControl.m_Character.StandState = bl_ThirdPersonCharacter.bl_StandState.Crawling;
      Main.Instance.GameplayMenu.WeaponReloadUI.SetActive(true);
      if (Main.Instance.NewGameMenu.DificultySelected != 3)
        Main.Instance.GameplayMenu.SleepMenu.SetActive(true);
      Main.Instance.GameplayMenu.AllowCursor();
      if ((UnityEngine.Object) this.CurrentZone != (UnityEngine.Object) null && this.CurrentZone.UnSafe && (!((UnityEngine.Object) this.InteractingWith != (UnityEngine.Object) null) || !(this.InteractingWith is int_bed) || !((int_bed) this.InteractingWith).SafeBed))
      {
        this.TheHealth.PlayerRespawnNoRagdoll();
        Main.Instance.GameplayMenu.SleepMenu.SetActive(false);
      }
      Main.Instance.DayCycle.cycleDuration = 65f;
    }
    this.LookAtPlayer.enabled = false;
    this.LookAtPlayer.Disable = true;
    Main.RunInNextFrame((Action) (() =>
    {
      this.LookAtPlayer.enabled = false;
      this.LookAtPlayer.Disable = true;
    }));
  }

  public void WakeUp(float energy = 0.0f)
  {
    if ((double) energy == 0.0)
      this.Energy = this.EnergyMax;
    this._IsSleeping = false;
    if ((UnityEngine.Object) this.ThisPersonInt != (UnityEngine.Object) null)
      this.ThisPersonInt.RemoveBlocker("Sleeping");
    this.RemoveMoveBlocker("SleepingFloor");
    this.BlendShape("e01_close", 0.0f);
    this.enabled = true;
    if (Main.Instance.MainThreads.Contains(new Action(this.Sleeping)))
      Main.Instance.MainThreads.Remove(new Action(this.Sleeping));
    this.Interacting = false;
    this.LookAtPlayer.Disable = false;
    this.LookAtPlayer.EnableIfNotEnabled();
    if (this.IsPlayer)
    {
      Main.Instance.GameplayMenu.WeaponReloadUI.SetActive(false);
      Main.Instance.GameplayMenu.SleepMenu.SetActive(false);
      Main.Instance.GameplayMenu.DisallowCursor();
      this.UserControl.FirstPerson = false;
      this.UserControl.m_Character.StandState = bl_ThirdPersonCharacter.bl_StandState.Standing;
      Main.Instance.DayCycle.cycleDuration = 1200f;
    }
    if (!this.TheHealth._BugFix_GetUp)
      this.Anim.Play("getup_20_p");
    this.TheHealth._BugFix_GetUp = false;
  }

  public void Sleeping()
  {
    this._IsSleeping = true;
    this.Energy += Time.deltaTime * 2f;
    if ((double) this.Energy < 0.0)
      this.Energy = 1f;
    if (this.IsPlayer)
      Main.Instance.GameplayMenu.WeaponReloadSlider.fillAmount = this.Energy / this.EnergyMax;
    if ((double) this.Energy < (double) this.EnergyMax)
      return;
    this.Energy = this.EnergyMax;
    this.WakeUp();
  }

  public void Shiting()
  {
    this.Toilet -= Time.deltaTime * 20f;
    if (this.IsPlayer)
      Main.Instance.GameplayMenu.WeaponReloadSlider.fillAmount = this.Toilet / this.ToiletMax;
    this._z = 1f - Main.POfVal(this._StartShitAtStartShitActual, 0.0f, this.Toilet);
    this._arg = Main.ValOfP(0.1703f, -0.022f, this._z);
    this._scatexiting.transform.localPosition = new Vector3(0.0f, 0.0f, this._arg);
    if ((double) this.Toilet > 0.0)
      return;
    this.Toilet = 0.0f;
    UnityEngine.Object.Destroy((UnityEngine.Object) this._scatexiting);
    if (this.IntestinalSubstance != 1)
    {
      Main.Instance.GlobalAudio.PlayOneShot(Main.Instance.ShitSounds[UnityEngine.Random.Range(0, Main.Instance.ShitSounds.Count)]);
      this.States[3] = true;
      this.SetBodyTexture();
    }
    Main.Instance.MainThreads.Remove(new Action(this.Shiting));
    this.RemoveMoveBlocker("ShitingFloor");
    this.enabled = true;
    if (this.IsPlayer)
    {
      Main.Instance.GameplayMenu.WeaponReloadUI.SetActive(false);
      this.UserControl.FirstPerson = false;
    }
    if ((UnityEngine.Object) this.CurrentPants != (UnityEngine.Object) null)
    {
      foreach (Renderer componentsInChild in this.CurrentPants.GetComponentsInChildren<SkinnedMeshRenderer>())
        componentsInChild.enabled = true;
    }
    if ((UnityEngine.Object) this.CurrentUnderwearLower != (UnityEngine.Object) null)
    {
      foreach (Renderer componentsInChild in this.CurrentUnderwearLower.GetComponentsInChildren<SkinnedMeshRenderer>())
        componentsInChild.enabled = true;
    }
    GameObject gameObject = this.IntestinalSubstance != 1 ? Main.Spawn(Main.Instance.PileOfScats[UnityEngine.Random.Range(0, Main.Instance.PileOfScats.Count)]) : Main.Spawn(Main.Instance.PileOfScatsGoos[0]);
    gameObject.transform.SetPositionAndRotation(this.transform.position - new Vector3(0.0f, 0.04f, 0.0f), Quaternion.Euler(0.0f, (float) UnityEngine.Random.Range(0, 359), 0.0f));
    int_Scat componentInChildren = gameObject.GetComponentInChildren<int_Scat>();
    componentInChildren.Nutrition = int_Scat.NutritionOfToilet(this._StartShitAtStartShitActual);
    componentInChildren.SetSizeOnSpawn();
    this.IntestinalSubstance = 0;
  }

  public void BlendShape(string shapeName, float value)
  {
    List<SkinnedMeshRenderer> skinnedMeshRendererList = new List<SkinnedMeshRenderer>();
    if ((UnityEngine.Object) this.CurrentBody != (UnityEngine.Object) null)
      skinnedMeshRendererList.Add(this.CurrentBody.GetComponent<SkinnedMeshRenderer>());
    if ((UnityEngine.Object) this.CurrentHead != (UnityEngine.Object) null)
      skinnedMeshRendererList.Add(this.CurrentHead.GetComponent<SkinnedMeshRenderer>());
    for (int index1 = 0; index1 < skinnedMeshRendererList.Count; ++index1)
    {
      for (int index2 = 0; index2 < skinnedMeshRendererList[index1].sharedMesh.blendShapeCount; ++index2)
      {
        if (skinnedMeshRendererList[index1].sharedMesh.GetBlendShapeName(index2) == shapeName)
        {
          skinnedMeshRendererList[index1].SetBlendShapeWeight(index2, value);
          break;
        }
      }
    }
  }

  public void ResetAllShapes()
  {
    List<SkinnedMeshRenderer> skinnedMeshRendererList = new List<SkinnedMeshRenderer>();
    if ((UnityEngine.Object) this.CurrentBody != (UnityEngine.Object) null)
      skinnedMeshRendererList.Add(this.CurrentBody.GetComponent<SkinnedMeshRenderer>());
    if ((UnityEngine.Object) this.CurrentHead != (UnityEngine.Object) null)
      skinnedMeshRendererList.Add(this.CurrentHead.GetComponent<SkinnedMeshRenderer>());
    for (int index1 = 0; index1 < skinnedMeshRendererList.Count; ++index1)
    {
      for (int index2 = 0; index2 < skinnedMeshRendererList[index1].sharedMesh.blendShapeCount; ++index2)
        skinnedMeshRendererList[index1].SetBlendShapeWeight(index2, 0.0f);
    }
    if (this.Masturbating)
      this.Masturbating = true;
    for (int index = 0; index < this.EquippedClothes.Count; ++index)
    {
      if ((UnityEngine.Object) this.EquippedClothes[index] != (UnityEngine.Object) null)
        this.EquippedClothes[index].RefreshShapeWhileEquipped();
    }
  }

  public virtual void RefreshColors()
  {
    if ((UnityEngine.Object) this.MainBody == (UnityEngine.Object) null)
      return;
    this.MainBody.materials[0].color = this.TannedSkinColor != new Color(0.0f, 0.0f, 0.0f, 0.0f) ? this.TannedSkinColor : this.NaturalSkinColor;
    if (this.MainBody.materials.Length > 1)
      this.MainBody.materials[1].color = this.TannedSkinColor != new Color(0.0f, 0.0f, 0.0f, 0.0f) ? this.TannedSkinColor : this.NaturalSkinColor;
    if (this.MainBody.materials.Length > 2)
      this.MainBody.materials[2].color = this.DyedEyeColor != new Color(0.0f, 0.0f, 0.0f, 0.0f) ? this.DyedEyeColor : this.NaturalEyeColor;
    if ((UnityEngine.Object) this.MainBodyLowPoly != (UnityEngine.Object) null)
    {
      this.MainBodyLowPoly.materials[0] = this.MainBody.materials[0];
      this.MainBodyLowPoly.materials[0].color = this.MainBody.materials[0].color;
      if (this.MainBody.materials.Length > 1 && this.MaterialTypeNPC == 0)
      {
        this.MainBodyLowPoly.materials[1] = this.MainBody.materials[1];
        this.MainBodyLowPoly.materials[1].color = this.MainBody.materials[1].color;
      }
      else if (this.MaterialTypeNPC == 1)
        this.transform.Find("SkinnedMeshContainer/o_head").GetComponent<SkinnedMeshRenderer>().material.color = this.MainBody.materials[0].color;
    }
    if ((UnityEngine.Object) this.CurrentHair != (UnityEngine.Object) null)
    {
      Color color = Color.white;
      if (this.DyedHairColor != new Color(0.0f, 0.0f, 0.0f, 0.0f))
        color = this.DyedHairColor;
      else if (this.NaturalHairColor != new Color(0.0f, 0.0f, 0.0f, 0.0f))
        color = this.NaturalHairColor;
      Renderer[] componentsInChildren = this.CurrentHair.GetComponentsInChildren<Renderer>();
      for (int index1 = 0; index1 < componentsInChildren.Length; ++index1)
      {
        bl_materialproccessing component = componentsInChildren[index1].GetComponent<bl_materialproccessing>();
        if ((UnityEngine.Object) component != (UnityEngine.Object) null)
        {
          for (int index2 = 0; index2 < component.MaterialsThatCanGetColored.Length; ++index2)
            componentsInChildren[index1].materials[component.MaterialsThatCanGetColored[index2]].color = color;
        }
        else
        {
          for (int index3 = 0; index3 < componentsInChildren[index1].materials.Length; ++index3)
            componentsInChildren[index1].materials[index3].color = color;
        }
      }
    }
    if (!((UnityEngine.Object) this.Penis != (UnityEngine.Object) null))
      return;
    this.Penis.GetComponentInChildren<Renderer>().material.color = this.MainBody.materials[0].color;
  }

  public bool PenisErect
  {
    get => (double) this.PenisBones[1].localEulerAngles.x == 90.0;
    set
    {
      if (value)
      {
        this.PenisBones[1].GetComponent<Rigidbody>().isKinematic = true;
        this.PenisBones[2].GetComponent<Rigidbody>().isKinematic = true;
        this.PenisBones[3].GetComponent<Rigidbody>().isKinematic = true;
        this.PenisBones[4].GetComponent<Rigidbody>().isKinematic = true;
        if ((UnityEngine.Object) this.PenisBones[1].GetComponent<CharacterJoint>() != (UnityEngine.Object) null)
        {
          UnityEngine.Object.Destroy((UnityEngine.Object) this.PenisBones[1].GetComponent<CharacterJoint>());
          UnityEngine.Object.Destroy((UnityEngine.Object) this.PenisBones[2].GetComponent<HingeJoint>());
          UnityEngine.Object.Destroy((UnityEngine.Object) this.PenisBones[3].GetComponent<HingeJoint>());
          UnityEngine.Object.Destroy((UnityEngine.Object) this.PenisBones[4].GetComponent<HingeJoint>());
        }
        this.PenisBones[3].SetParent(this.PenisBones[2]);
        this.PenisBones[1].localEulerAngles = new Vector3(90f, 0.0f, 0.0f);
        this.PenisBones[2].localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        this.PenisBones[3].localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        this.PenisBones[4].localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        this.PenisBones[1].localScale = Vector3.one;
        this.PenisBones[2].localScale = Vector3.one;
        this.PenisBones[3].localScale = Vector3.one;
        this.PenisBones[4].localScale = Vector3.one;
        this.PenisBones[1].localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        this.PenisBones[2].localPosition = new Vector3(0.0f, 0.02009349f, 0.0f);
        this.PenisBones[3].localPosition = new Vector3(0.0f, 0.02328722f, 0.0f);
        this.PenisBones[4].localPosition = new Vector3(0.0f, 0.02642323f, 0.0f);
      }
      else
      {
        if (!this.PenisErect)
          return;
        if (!((UnityEngine.Object) this.PenisBones[1].gameObject.GetComponent<CharacterJoint>() != (UnityEngine.Object) null))
        {
          CharacterJoint characterJoint = this.PenisBones[1].gameObject.AddComponent<CharacterJoint>();
          characterJoint.connectedBody = this.RagdollParts[0];
          characterJoint.lowTwistLimit = new SoftJointLimit()
          {
            limit = -28.79303f
          };
          SoftJointLimit softJointLimit = new SoftJointLimit();
          softJointLimit.limit = 86.46519f;
          characterJoint.highTwistLimit = softJointLimit;
          softJointLimit = new SoftJointLimit();
          softJointLimit.limit = 3f;
          characterJoint.swing1Limit = softJointLimit;
          softJointLimit = new SoftJointLimit();
          softJointLimit.limit = 40f;
          characterJoint.swing2Limit = softJointLimit;
          HingeJoint hingeJoint1 = this.PenisBones[2].gameObject.AddComponent<HingeJoint>();
          hingeJoint1.connectedBody = this.PenisBones[1].GetComponent<Rigidbody>();
          hingeJoint1.useLimits = true;
          JointLimits jointLimits = new JointLimits();
          jointLimits.min = -45f;
          jointLimits.max = 45f;
          hingeJoint1.limits = jointLimits;
          HingeJoint hingeJoint2 = this.PenisBones[3].gameObject.AddComponent<HingeJoint>();
          hingeJoint2.connectedBody = this.PenisBones[2].GetComponent<Rigidbody>();
          hingeJoint2.useLimits = true;
          hingeJoint2.limits = jointLimits;
          HingeJoint hingeJoint3 = this.PenisBones[4].gameObject.AddComponent<HingeJoint>();
          hingeJoint3.connectedBody = this.PenisBones[3].GetComponent<Rigidbody>();
          hingeJoint3.useLimits = true;
          hingeJoint3.limits = jointLimits;
        }
        this.PenisBones[1].GetComponent<Rigidbody>().isKinematic = false;
        this.PenisBones[2].GetComponent<Rigidbody>().isKinematic = false;
        this.PenisBones[3].GetComponent<Rigidbody>().isKinematic = false;
        this.PenisBones[4].GetComponent<Rigidbody>().isKinematic = false;
      }
    }
  }

  public void ResetPenisBones()
  {
    this.PenisBones[2].SetParent(this.PenisBones[1]);
    this.PenisBones[3].SetParent(this.PenisBones[2]);
    this.PenisBones[4].SetParent(this.PenisBones[3]);
    this.PenisBones[1].localEulerAngles = new Vector3(90f, 0.0f, 0.0f);
    this.PenisBones[2].localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    this.PenisBones[3].localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    this.PenisBones[4].localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    this.PenisBones[1].localScale = Vector3.one;
    this.PenisBones[2].localScale = Vector3.one;
    this.PenisBones[3].localScale = Vector3.one;
    this.PenisBones[4].localScale = Vector3.one;
    this.PenisBones[1].localPosition = new Vector3(0.0f, 0.0f, 0.0f);
    this.PenisBones[2].localPosition = new Vector3(0.0f, 0.02009349f, 0.0f);
    this.PenisBones[3].localPosition = new Vector3(0.0f, 0.02328722f, 0.0f);
    this.PenisBones[4].localPosition = new Vector3(0.0f, 0.02642323f, 0.0f);
  }

  public void TakeFaceScreenshot(string filepath)
  {
    GameObject gameObject = new GameObject();
    gameObject.transform.SetParent(this.TorsoViewPoint);
    gameObject.transform.localPosition = Vector3.zero;
    gameObject.transform.LookAt(this.Neck);
    this.SetHighLod();
    Camera camera = gameObject.AddComponent<Camera>();
    camera.nearClipPlane = 0.1f;
    camera.targetTexture = new RenderTexture(256 /*0x0100*/, 256 /*0x0100*/, 24);
    camera.Render();
    Texture2D tex = new Texture2D(256 /*0x0100*/, 256 /*0x0100*/, TextureFormat.RGB24, false);
    RenderTexture.active = camera.targetTexture;
    tex.ReadPixels(new Rect(0.0f, 0.0f, (float) camera.targetTexture.width, (float) camera.targetTexture.height), 0, 0);
    tex.Apply();
    byte[] png = tex.EncodeToPNG();
    File.WriteAllBytes(filepath, png);
    UnityEngine.Object.Destroy((UnityEngine.Object) gameObject);
  }

  public void CreatePersonRelationship()
  {
    string str = $"{Main.AssetsFolder}/Saves/{this.WorldSaveID}.png";
    if (!File.Exists(str))
      this.TakeFaceScreenshot(str);
    if (Main.Instance.GameplayMenu.Relationships.Contains(this))
      return;
    Main.Instance.GameplayMenu.Relationships.Add(this);
  }

  public bool CharacterVisible
  {
    get => this._CharacterVisible;
    set
    {
      if (this._CharacterVisible == value)
        return;
      this._CharacterVisible = value;
      if (this.Inited)
        this.__FinallyRefreshCharacterVisible(value);
      else
        this.OnFinallyInited.Add(new Action(this.__RefreshCharacterVisible));
    }
  }

  public void __RefreshCharacterVisible()
  {
    this.OnFinallyInited.Remove(new Action(this.__RefreshCharacterVisible));
    this.__FinallyRefreshCharacterVisible(this._CharacterVisible);
  }

  public void __FinallyRefreshCharacterVisible(bool value)
  {
    Renderer[] componentsInChildren = this.transform.GetComponentsInChildren<Renderer>(true);
    for (int index = 0; index < componentsInChildren.Length; ++index)
    {
      if ((UnityEngine.Object) this.LodRen != (UnityEngine.Object) componentsInChildren[index] && componentsInChildren[index].gameObject.layer != 512 /*0x0200*/)
        componentsInChildren[index].enabled = value;
    }
  }

  public void Seen(GameObject seen)
  {
    bl_PersonRedirect component1 = seen.GetComponent<bl_PersonRedirect>();
    Person component2 = (!((UnityEngine.Object) component1 != (UnityEngine.Object) null) ? (Component) seen.transform.root : (Component) component1.RedirectTarget.transform).GetComponent<Person>();
    if ((UnityEngine.Object) component2 != (UnityEngine.Object) null)
    {
      this.PersonType.OnSeePerson(this, component2);
      component2.PersonalityData.OnSeeOtherPerson(this, component2);
      for (int index = 0; index < this.OnSeen.Count; ++index)
        this.OnSeen[index](component2);
    }
    if (this.ClothingCondition == e_ClothingCondition.Nude)
      ;
  }

  public static Person GenerateRandom(
    GameObject spawnedPerson = null,
    bool female = true,
    bool randomgender = false,
    bool randompartsizes = true,
    bool _DEBUG = false)
  {
    bool flag1 = randomgender ? (double) UnityEngine.Random.Range(0.0f, 1f) > (double) Person.GenderChance : female;
    if (_DEBUG)
    {
      Debug.LogError((object) ("randomgender " + randomgender.ToString()));
      Debug.LogError((object) ("_female " + flag1.ToString()));
      Debug.LogError((object) ("female " + female.ToString()));
    }
    GameObject gameObject = !((UnityEngine.Object) spawnedPerson == (UnityEngine.Object) null) ? spawnedPerson : (flag1 ? UnityEngine.Object.Instantiate<GameObject>(Main.Instance.PersonPrefab) : UnityEngine.Object.Instantiate<GameObject>(Main.Instance.PersonGuyPrefab));
    Person component = gameObject.GetComponent<Person>();
    component.States = new bool[34];
    component.Name = Main.Instance.GenerateRandomName();
    if (flag1)
    {
      Girl girl = (Girl) component;
      girl.Futa = (double) UnityEngine.Random.Range(0.0f, 1f) < (double) UI_Customize.FutaChanceValue;
      component.HasBalls = (double) UnityEngine.Random.Range(0.0f, 1f) < 0.25;
      girl.HadPregnancies = (double) UnityEngine.Random.Range(0.0f, 1f) > 0.25 ? UnityEngine.Random.Range(1, 5) : 0;
      if ((double) UnityEngine.Random.Range(0.0f, 1f) < 0.20000000298023224)
      {
        girl.BecomePreg();
        girl.PregnancyTimer = UnityEngine.Random.Range(0.0f, girl.PregnancyTimeMax);
      }
      component.States[22] = (double) UnityEngine.Random.Range(0.0f, 5f) < 4.9000000953674316;
    }
    float num1 = UnityEngine.Random.Range(2f, 3.5f);
    component.Penis.transform.localScale = new Vector3(num1, num1, num1);
    component.Fertility = UnityEngine.Random.Range(-0.1f, 1.2f);
    if ((double) component.Fertility < 0.0)
      component.Fertility = 0.0f;
    component.Personality = (Personality_Type) UnityEngine.Random.Range(0, 13);
    component.PersonalityData = Main.Instance.Personalities[(int) component.Personality];
    int num2 = UnityEngine.Random.Range(1, 5);
    bool flag2 = false;
    List<e_Fetish> list = Enum.GetValues(typeof (e_Fetish)).Cast<e_Fetish>().ToList<e_Fetish>();
    list.Remove(e_Fetish.MAX);
    Person.Shuffle<e_Fetish>(list);
    for (int index = 0; index < num2; ++index)
    {
      if (list[index] == e_Fetish.Clean || list[index] == e_Fetish.Dirty)
      {
        if (!flag2)
        {
          flag2 = true;
          ++num2;
          component.Fetishes.Add(list[index]);
        }
      }
      else
        component.Fetishes.Add(list[index]);
    }
    component.Favor = UnityEngine.Random.Range(-60, 60);
    component.VoicePitch = UnityEngine.Random.Range(0.8f, 1.1f);
    component.ArmySkills = UnityEngine.Random.Range(-100, 60);
    component.SexSkills = UnityEngine.Random.Range(-100, 60);
    component.WorkSkills = UnityEngine.Random.Range(-100, 60);
    component.Hunger = (float) UnityEngine.Random.Range(25, 75);
    component.Energy = (float) UnityEngine.Random.Range(25, 75);
    component.Toilet = (float) UnityEngine.Random.Range(25, 75);
    component.AssSize = (float) UnityEngine.Random.Range(0, 100);
    component.BoobSize = (float) UnityEngine.Random.Range(0, 100);
    component.FatSize = (float) UnityEngine.Random.Range(0, 100);
    component.NaturalEyeColor = Main.Instance.NaturalEyeColors[UnityEngine.Random.Range(0, Main.Instance.NaturalEyeColors.Length)];
    component.NaturalHairColor = Main.Instance.NaturalHairColors[UnityEngine.Random.Range(0, Main.Instance.NaturalHairColors.Length)];
    component.NaturalSkinColor = Main.Instance.NaturalSkinColors[UnityEngine.Random.Range(0, Main.Instance.NaturalSkinColors.Length)];
    if (randompartsizes)
    {
      component.GenerateRandomFace();
      component.GenerateRandomBody();
    }
    if (component.Fetishes.Contains(e_Fetish.Dirty))
      component.DirtySkin = true;
    gameObject.SetActive(true);
    return component;
  }

  public static void Shuffle<T>(List<T> list)
  {
    int count = list.Count;
    System.Random random = new System.Random();
    while (count > 1)
    {
      --count;
      int index = random.Next(count + 1);
      T obj = list[index];
      list[index] = list[count];
      list[count] = obj;
    }
  }

  public void UnRagdoll()
  {
    this.enabled = true;
    if ((UnityEngine.Object) this.ThisPersonInt != (UnityEngine.Object) null)
    {
      this.ThisPersonInt.RemoveBlocker("Ragdoll");
      this.ThisPersonInt.ThisPerson.RagdollManager.OnBecomeNOTRagdoll();
      this.ThisPersonInt.ThisPerson.RagdollManager.enabled = false;
    }
    this.RemoveMoveBlocker("Ragdoll");
    if ((UnityEngine.Object) this.Anim != (UnityEngine.Object) null)
      this.Anim.enabled = true;
    if (!this.IsPlayer && (UnityEngine.Object) this.navMesh != (UnityEngine.Object) null)
      this.navMesh.enabled = true;
    if ((UnityEngine.Object) this.MainCol != (UnityEngine.Object) null)
      this.MainCol.enabled = true;
    for (int index = 0; index < this.RagdollParts.Length; ++index)
    {
      this.RagdollParts[index].isKinematic = true;
      if (this.IsPlayer)
      {
        Collider component = this.RagdollParts[index].GetComponent<Collider>();
        if ((bool) (UnityEngine.Object) component)
          component.enabled = false;
      }
      int_Dragable component1 = this.RagdollParts[index].GetComponent<int_Dragable>();
      if ((bool) (UnityEngine.Object) component1)
        component1.CanInteract = false;
      MultiInteractible component2 = this.RagdollParts[index].GetComponent<MultiInteractible>();
      if ((UnityEngine.Object) component2 != (UnityEngine.Object) null)
        component2.AddBlocker("Awake");
    }
    if ((UnityEngine.Object) this.InventoryStorage != (UnityEngine.Object) null)
    {
      this.InventoryStorage.AddBlocker("Awake");
      this.StartSleepingSex.AddBlocker("Awake");
    }
    Girl component3 = this.GetComponent<Girl>();
    if ((UnityEngine.Object) component3 != (UnityEngine.Object) null)
      component3.GirlPhysics = false;
    if (this.IsPlayer)
      this.GetComponent<Rigidbody>().isKinematic = false;
    else
      this.HeadCol.enabled = true;
    this.LookAtPlayer.Disable = false;
    this.LookAtPlayer.EnableIfNotEnabled();
  }

  public void StartRagdoll() => this.StartRagdoll(false);

  public void StartRagdoll(bool incapacitatedText)
  {
    Debug.Log((object) "StartRagdoll Called");
    if (this.HavingSex && !this.SexEnding_bug1)
    {
      if ((UnityEngine.Object) this.HavingSex_Scene == (UnityEngine.Object) Main.Instance.SexScene.PlayerSex)
        Main.Instance.SexScene.EndSexScene();
      else
        this.HavingSex_Scene.EndSex();
    }
    if (this.IsPlayer)
      Main.Instance.Player.UserControl.FirstPerson = false;
    this.enabled = false;
    if ((UnityEngine.Object) this.ThisPersonInt != (UnityEngine.Object) null)
      this.ThisPersonInt.AddBlocker("Ragdoll");
    this.AddMoveBlocker("Ragdoll");
    if ((UnityEngine.Object) this.Anim != (UnityEngine.Object) null)
      this.Anim.enabled = false;
    if ((UnityEngine.Object) this.navMesh != (UnityEngine.Object) null)
      this.navMesh.enabled = false;
    if ((UnityEngine.Object) this.MainCol != (UnityEngine.Object) null)
      this.MainCol.enabled = false;
    for (int index = 0; index < this.RagdollParts.Length; ++index)
    {
      if (!((UnityEngine.Object) this.RagdollParts[index] == (UnityEngine.Object) null))
      {
        this.RagdollParts[index].isKinematic = false;
        Collider component1 = this.RagdollParts[index].GetComponent<Collider>();
        if ((UnityEngine.Object) component1 != (UnityEngine.Object) null)
          component1.enabled = true;
        int_Dragable component2 = this.RagdollParts[index].GetComponent<int_Dragable>();
        if ((UnityEngine.Object) component2 != (UnityEngine.Object) null)
          component2.CanInteract = true;
        MultiInteractible component3 = this.RagdollParts[index].GetComponent<MultiInteractible>();
        if ((UnityEngine.Object) component3 != (UnityEngine.Object) null)
        {
          component3.RemoveBlocker("Awake");
          if (this.PlayerKnowsName && (UnityEngine.Object) this.PersonType != (UnityEngine.Object) null)
          {
            if (incapacitatedText)
              component3.InteractText = $"(Incapacitated){this.Name} ({this.PersonType.ThisType.ToString()})";
            else
              component3.InteractText = $"(Dead){this.Name} ({this.PersonType.ThisType.ToString()})";
          }
          else if (incapacitatedText)
            component3.InteractText = $"(Incapacitated) ({this.PersonType.ThisType.ToString()})";
          else
            component3.InteractText = $"(Dead) ({this.PersonType.ThisType.ToString()})";
        }
      }
    }
    if ((UnityEngine.Object) this.InventoryStorage != (UnityEngine.Object) null)
    {
      this.InventoryStorage.RemoveBlocker("Awake");
      this.StartSleepingSex.RemoveBlocker("Awake");
    }
    this.Eyes.gameObject.SetActive(false);
    if (!this.CinematicCharacter)
    {
      Girl component = this.GetComponent<Girl>();
      if ((UnityEngine.Object) component != (UnityEngine.Object) null)
        component.ExSetGirlPhysics(true, true);
    }
    if (this.IsPlayer)
      this.GetComponent<Rigidbody>().isKinematic = true;
    this.LookAtPlayer.Disable = true;
    this.LookAtPlayer.enabled = false;
    if (!((UnityEngine.Object) this.ThisPersonInt != (UnityEngine.Object) null))
      return;
    this.ThisPersonInt.ThisPerson.RagdollManager.OnBecomeRagdoll();
    this.ThisPersonInt.ThisPerson.RagdollManager.enabled = true;
  }

  public void UpdateAnim()
  {
    if (this.Masturbating)
    {
      if (this.IsPlayer)
      {
        if (this.UserControl.m_Character.StandState == bl_ThirdPersonCharacter.bl_StandState.Standing)
        {
          if (this.HasPenis)
          {
            if (!this._StartedMastPP)
            {
              this._StartedMastPP = true;
              this.PutPenis();
              this.PenisErect = true;
              this.PenisBones[5].localPosition = Vector3.zero;
              this.PenisBones[2].SetParent(this.PenisBones[5]);
              this.PenisBones[2].localPosition = Vector3.zero;
              this.PenisBones[2].localEulerAngles = new Vector3(90f, 0.0f, 0.0f);
            }
            this.Anim.Play("mast2pp");
            this.PenisBones[5].LookAt(this.RightHandWankCenter);
          }
          else
            this.Anim.Play("Mast2");
        }
        else
          this.Anim.Play("Mast1SitHand");
      }
      else if (this.PostureState == Person_PostureState.Standing)
        this.Anim.Play("Mast2");
      else
        this.Anim.Play("Mast1SitHand");
    }
    else
    {
      if (this.IsPlayer)
        return;
      Vector2 vector2;
      int num1;
      if (!this.navMesh.enabled)
      {
        vector2 = new Vector2(this._Rigidbody.velocity.x, this._Rigidbody.velocity.z);
        num1 = (double) vector2.magnitude < 0.10000000149011612 ? 1 : 0;
      }
      else
        num1 = (double) this.navMesh.velocity.magnitude < 0.10000000149011612 ? 1 : 0;
      if (num1 != 0)
      {
        this.PostureState = Person_PostureState.Standing;
      }
      else
      {
        int num2;
        if (!this.navMesh.enabled)
        {
          vector2 = new Vector2(this._Rigidbody.velocity.x, this._Rigidbody.velocity.z);
          num2 = (double) vector2.magnitude < 1.6000000238418579 ? 1 : 0;
        }
        else
          num2 = (double) this.navMesh.velocity.magnitude < 1.1000000238418579 ? 1 : 0;
        this.PostureState = num2 == 0 ? Person_PostureState.Running : Person_PostureState.Walking;
      }
      switch (this.PostureState)
      {
        case Person_PostureState.Standing:
          if ((UnityEngine.Object) this.WeaponInv == (UnityEngine.Object) null || (UnityEngine.Object) this.WeaponInv.CurrentWeapon == (UnityEngine.Object) null)
          {
            switch (this.PostureHeightState)
            {
              case Person_PostureHeightState.Standing:
                this.Anim.Play(this.A_Standing);
                return;
              case Person_PostureHeightState.Crouching:
                this.Anim.Play(this.A_Crouching);
                return;
              case Person_PostureHeightState.Crawling:
                this.Anim.Play(this.A_Crawling_idle);
                return;
              default:
                return;
            }
          }
          else if (this.InCombat)
          {
            this.WeaponInv.CurrentWeapon.SetInAiming();
            switch (this.PostureHeightState)
            {
              case Person_PostureHeightState.Standing:
                switch (this.WeaponInv.CurrentWeapon.HoldingType)
                {
                  case WeaponHoldingType.Pistol:
                    this.Anim.Play(this.AP_Combat_Standing);
                    return;
                  case WeaponHoldingType.Rifle:
                    this.Anim.Play(this.AR_Combat_Standing);
                    return;
                  case WeaponHoldingType.Blunt:
                    this.Anim.Play(this.ME_Combat_Standing);
                    return;
                  case WeaponHoldingType.PickAxe:
                    this.Anim.Play(this.ME_Combat_Standing);
                    return;
                  default:
                    return;
                }
              case Person_PostureHeightState.Crouching:
                switch (this.WeaponInv.CurrentWeapon.HoldingType)
                {
                  case WeaponHoldingType.Pistol:
                    this.Anim.Play(this.AP_Crouching);
                    return;
                  case WeaponHoldingType.Rifle:
                    this.Anim.Play(this.AR_Crouching);
                    return;
                  case WeaponHoldingType.Blunt:
                    this.Anim.Play(this.ME_Crouching);
                    return;
                  case WeaponHoldingType.PickAxe:
                    this.Anim.Play(this.ME_Crouching);
                    return;
                  default:
                    return;
                }
              case Person_PostureHeightState.Crawling:
                switch (this.WeaponInv.CurrentWeapon.HoldingType)
                {
                  case WeaponHoldingType.Pistol:
                    this.Anim.Play(this.AP_Crawling_idle);
                    return;
                  case WeaponHoldingType.Rifle:
                    this.Anim.Play(this.AR_Crawling_idle);
                    return;
                  case WeaponHoldingType.Blunt:
                    this.Anim.Play(this.ME_Crawling_idle);
                    return;
                  case WeaponHoldingType.PickAxe:
                    this.Anim.Play(this.ME_Crawling_idle);
                    return;
                  default:
                    return;
                }
              default:
                return;
            }
          }
          else
          {
            this.WeaponInv.CurrentWeapon.SetInRelax();
            switch (this.PostureHeightState)
            {
              case Person_PostureHeightState.Standing:
                switch (this.WeaponInv.CurrentWeapon.HoldingType)
                {
                  case WeaponHoldingType.Pistol:
                    this.Anim.Play(this.AP_Standing);
                    return;
                  case WeaponHoldingType.Rifle:
                    this.Anim.Play(this.AR_Standing);
                    return;
                  case WeaponHoldingType.Blunt:
                    this.Anim.Play(this.ME_Standing);
                    return;
                  case WeaponHoldingType.PickAxe:
                    this.Anim.Play(this.ME_Standing);
                    return;
                  default:
                    return;
                }
              case Person_PostureHeightState.Crouching:
                switch (this.WeaponInv.CurrentWeapon.HoldingType)
                {
                  case WeaponHoldingType.Pistol:
                    this.Anim.Play(this.AP_Crouching);
                    return;
                  case WeaponHoldingType.Rifle:
                    this.Anim.Play(this.AR_Crouching);
                    return;
                  case WeaponHoldingType.Blunt:
                    this.Anim.Play(this.ME_Crouching);
                    return;
                  case WeaponHoldingType.PickAxe:
                    this.Anim.Play(this.ME_Standing);
                    return;
                  default:
                    return;
                }
              case Person_PostureHeightState.Crawling:
                switch (this.WeaponInv.CurrentWeapon.HoldingType)
                {
                  case WeaponHoldingType.Pistol:
                    this.Anim.Play(this.AP_Crawling_idle);
                    return;
                  case WeaponHoldingType.Rifle:
                    this.Anim.Play(this.AR_Crawling_idle);
                    return;
                  case WeaponHoldingType.Blunt:
                    this.Anim.Play(this.ME_Crawling_idle);
                    return;
                  case WeaponHoldingType.PickAxe:
                    this.Anim.Play(this.ME_Standing);
                    return;
                  default:
                    return;
                }
              default:
                return;
            }
          }
        case Person_PostureState.Walking:
          if ((UnityEngine.Object) this.WeaponInv == (UnityEngine.Object) null || (UnityEngine.Object) this.WeaponInv.CurrentWeapon == (UnityEngine.Object) null)
          {
            switch (this.PostureHeightState)
            {
              case Person_PostureHeightState.Standing:
                this.Anim.Play(this.A_Walking);
                return;
              case Person_PostureHeightState.Crouching:
                this.Anim.Play(this.A_Crouching_walk);
                return;
              case Person_PostureHeightState.Crawling:
                this.Anim.Play(this.A_Crawling);
                return;
              default:
                return;
            }
          }
          else
          {
            switch (this.PostureHeightState)
            {
              case Person_PostureHeightState.Standing:
                switch (this.WeaponInv.CurrentWeapon.HoldingType)
                {
                  case WeaponHoldingType.Pistol:
                    this.Anim.Play(this.AP_Walking);
                    return;
                  case WeaponHoldingType.Rifle:
                    this.Anim.Play(this.AR_Walking);
                    return;
                  case WeaponHoldingType.Blunt:
                    this.Anim.Play(this.ME_Walking);
                    return;
                  case WeaponHoldingType.PickAxe:
                    this.Anim.Play(this.ME_Walking);
                    return;
                  default:
                    return;
                }
              case Person_PostureHeightState.Crouching:
                switch (this.WeaponInv.CurrentWeapon.HoldingType)
                {
                  case WeaponHoldingType.Pistol:
                    this.Anim.Play(this.AP_Crouching_walk);
                    return;
                  case WeaponHoldingType.Rifle:
                    this.Anim.Play(this.AR_Crouching_walk);
                    return;
                  case WeaponHoldingType.Blunt:
                    this.Anim.Play(this.ME_Crouching_walk);
                    return;
                  case WeaponHoldingType.PickAxe:
                    this.Anim.Play(this.ME_Crouching_walk);
                    return;
                  default:
                    return;
                }
              case Person_PostureHeightState.Crawling:
                switch (this.WeaponInv.CurrentWeapon.HoldingType)
                {
                  case WeaponHoldingType.Pistol:
                    this.Anim.Play(this.AP_Crawling);
                    return;
                  case WeaponHoldingType.Rifle:
                    this.Anim.Play(this.AR_Crawling);
                    return;
                  case WeaponHoldingType.Blunt:
                    this.Anim.Play(this.ME_Crawling);
                    return;
                  case WeaponHoldingType.PickAxe:
                    this.Anim.Play(this.ME_Crawling);
                    return;
                  default:
                    return;
                }
              default:
                return;
            }
          }
        case Person_PostureState.Running:
          if ((UnityEngine.Object) this.WeaponInv == (UnityEngine.Object) null || (UnityEngine.Object) this.WeaponInv.CurrentWeapon == (UnityEngine.Object) null)
          {
            this.Anim.Play(this.A_Running);
            break;
          }
          switch (this.WeaponInv.CurrentWeapon.HoldingType)
          {
            case WeaponHoldingType.Pistol:
              this.Anim.Play(this.AP_Running);
              return;
            case WeaponHoldingType.Rifle:
              this.Anim.Play(this.AR_Running);
              return;
            case WeaponHoldingType.Blunt:
              this.Anim.Play(this.ME_Running);
              return;
            case WeaponHoldingType.PickAxe:
              this.Anim.Play(this.ME_Running);
              return;
            default:
              return;
          }
      }
    }
  }

  public void StartFighting(Person person, bool melee = false)
  {
    if (this.TheHealth.dead || this.TheHealth.Incapacitated || this.HavingSex)
      return;
    this.InCombat = true;
    if (this.CurrentScheduleTask != null)
      this.InterruptTask();
    this.CurrentScheduleTask = (Person.ScheduleTask) null;
    if ((UnityEngine.Object) this.InteractingWith != (UnityEngine.Object) null)
      this.InteractingWith.StopInteracting();
    if (this.HavingSex)
    {
      if ((UnityEngine.Object) this.HavingSex_Scene == (UnityEngine.Object) Main.Instance.SexScene.PlayerSex)
        Main.Instance.SexScene.EndSexScene();
      else
        this.HavingSex_Scene.EndSex();
    }
    if (this.IsPlayer)
      return;
    if ((UnityEngine.Object) person == (UnityEngine.Object) null)
    {
      this.EnemyFighting = (Health) null;
      this.CombatState = Person_CombatState.Searching;
    }
    else
    {
      this.EnemyFighting = person.GetComponent<Health>();
      this.CombatState = Person_CombatState.Firing;
      if (this.EnemyFighting.isPlayer)
      {
        this.Favor -= 50;
        Main.RunInNextFrame((Action) (() =>
        {
          switch (this.PersonType.ThisType)
          {
            case Person_Type.Worker:
            case Person_Type.Civilian:
              this.StartCoroutine(Main.Instance.StartCombatWithArmy());
              break;
            case Person_Type.HigherCivilian:
            case Person_Type.Army:
            case Person_Type.Royal:
              this.StartCoroutine(Main.Instance.StartCombatWithEveryone());
              break;
          }
        }));
      }
    }
    this.LookAtPlayer.Disable = true;
    this.RandActionTimer = 3f;
    if (!melee)
    {
      if ((UnityEngine.Object) this.WeaponInv.CurrentWeapon == (UnityEngine.Object) null)
      {
        for (int index = 0; index < this.WeaponInv.weapons.Count; ++index)
        {
          if ((UnityEngine.Object) this.WeaponInv.weapons[index] != (UnityEngine.Object) null)
          {
            this.WeaponInv.SetActiveWeapon(index);
            goto label_25;
          }
        }
        this.SpawnSphereTrigger();
      }
    }
    else if ((UnityEngine.Object) this.WeaponInv.CurrentWeapon != (UnityEngine.Object) null)
      this.WeaponInv.CurrentWeapon.Holdster();
label_25:
    if (!((UnityEngine.Object) this.WeaponInv.CurrentWeapon != (UnityEngine.Object) null))
      return;
    this.WeaponInv.CurrentWeapon.fireTimer = UnityEngine.Random.Range(-1.5f, -0.5f);
  }

  public void StopFighting(bool EndEnemy = true)
  {
    if (EndEnemy && (UnityEngine.Object) this.EnemyFighting != (UnityEngine.Object) null)
      this.EnemyFighting.PersonComponent.StopFighting(false);
    this.EnemyFighting = (Health) null;
    this.InCombat = false;
    this.CombatState = Person_CombatState.Firing;
    if ((UnityEngine.Object) this.LookAtPlayer != (UnityEngine.Object) null)
      this.LookAtPlayer.Disable = false;
    this.EndingCombat = false;
  }

  public void SpawnSphereTrigger()
  {
    SphereCollider sphereCollider = new GameObject()
    {
      transform = {
        position = this.transform.position
      }
    }.AddComponent<SphereCollider>();
    sphereCollider.isTrigger = true;
    sphereCollider.radius = 20f;
    Person.SphereTrigger sphereTrigger = sphereCollider.gameObject.AddComponent<Person.SphereTrigger>();
    sphereTrigger.ThisPerson = this;
    Main.RunInNextFrame(new Action(sphereTrigger.GetClosestWeapon), 2);
  }

  public void FoundClosestWeapon(Weapon weapon)
  {
    if ((UnityEngine.Object) weapon == (UnityEngine.Object) null)
    {
      this.GoUnarmed();
    }
    else
    {
      NavMeshPath path = new NavMeshPath();
      if (this.navMesh.CalculatePath(weapon.transform.position, path))
        this.StartScheduleTask(new Person.ScheduleTask()
        {
          IDName = "GoGetWeapon",
          ActionPlace = weapon.transform,
          RunTo = true,
          OnArrive = (Action) (() =>
          {
            this.WeaponInv.PickupWeapon(weapon.gameObject);
            this.CompleteScheduleTask(false);
          })
        });
      else
        this.GoUnarmed();
    }
  }

  public void GoUnarmed()
  {
  }

  public bool CurrentTaskIsNull()
  {
    return this.CurrentScheduleTask == null || this.CurrentScheduleTask.IDName == null || this.CurrentScheduleTask.IDName.Length == 0 || (UnityEngine.Object) this.CurrentScheduleTask.ActionPlace == (UnityEngine.Object) null;
  }

  public void InterruptTask()
  {
    switch (this.CurrentScheduleTask.State)
    {
      case 0:
        if (this.CurrentScheduleTask.OnInterrupt_BeforeStart != null)
        {
          this.CurrentScheduleTask.OnInterrupt_BeforeStart();
          break;
        }
        break;
      case 1:
        if (this.CurrentScheduleTask.OnInterrupt_WhileGoing != null)
        {
          this.CurrentScheduleTask.OnInterrupt_WhileGoing();
          break;
        }
        break;
      case 2:
        if (this.CurrentScheduleTask.OnInterrupt_WhileDoing != null)
        {
          this.CurrentScheduleTask.OnInterrupt_WhileDoing();
          break;
        }
        break;
    }
    this.CurrentScheduleTask.OnFinish = (Action) null;
    this.CompleteScheduleTask(false);
  }

  public void ScheduleDecide()
  {
    if (this.DEBUG)
      Debug.LogError((object) "ScheduleDecide()");
    this.DecideTimer = UnityEngine.Random.Range(5f, 10f);
    if (!this.CurrentTaskIsNull() || this.TheHealth.dead || this.TheHealth.Incapacitated || !this.CanMove)
      return;
    if (this.State == Person_State.Free)
    {
      for (int index = 0; index < this.FreeScheduleTasks.Count; ++index)
      {
        if (this.FreeScheduleTasks[index].CanStart())
        {
          this.StartScheduleTask(this.FreeScheduleTasks[index]);
          break;
        }
      }
    }
    else
    {
      for (int index = 0; index < this.WorkScheduleTasks.Count; ++index)
      {
        if (this.WorkScheduleTasks[index].CanStart())
        {
          this.StartScheduleTask(this.WorkScheduleTasks[index]);
          break;
        }
      }
    }
  }

  public bool HasScheduleTask(string nameID)
  {
    for (int index = 0; index < this.FreeScheduleTasks.Count; ++index)
    {
      if (this.FreeScheduleTasks[index].IDName == nameID)
        return true;
    }
    for (int index = 0; index < this.WorkScheduleTasks.Count; ++index)
    {
      if (this.WorkScheduleTasks[index].IDName == nameID)
        return true;
    }
    return false;
  }

  public void AddFreeScheduleTask(Person.ScheduleTask task, bool notIfContains = false)
  {
    if (notIfContains && this.HasScheduleTask(task.IDName))
      return;
    this.FreeScheduleTasks.Add(task);
    this.ScheduleDecide();
  }

  public void AddWorkScheduleTask(Person.ScheduleTask task, bool notIfContains = false)
  {
    if (notIfContains && this.HasScheduleTask(task.IDName))
      return;
    this.WorkScheduleTasks.Add(task);
    this.ScheduleDecide();
  }

  public void StartScheduleTask(Person.ScheduleTask task)
  {
    if (this.DEBUG)
      Debug.LogError((object) "ScheduleDecide()");
    if (this.IsPlayer)
      return;
    if (!this.CurrentTaskIsNull())
      this.InterruptTask();
    if (this.TheHealth.dead || this.TheHealth.Incapacitated)
      return;
    this.CurrentScheduleTask = task;
    if (this.Interacting)
      this.InteractingWith.StopInteracting();
    this.navMesh.enabled = true;
    this.navMesh.isStopped = false;
    if (this.CurrentScheduleTask == null)
    {
      Debug.LogError((object) (this.Name + " null task"));
      this.Do_Schedule_GoingToTargetThread = false;
    }
    else
    {
      this.SetDestination(this.CurrentScheduleTask.ActionPlace.position);
      this.navMesh.speed = task.RunTo ? 4f : 1f;
      this.CurrentScheduleTask.State = 1;
      this.Do_Schedule_GoingToTargetThread = true;
      if (this.CurrentScheduleTask.OnStartGoing == null)
        return;
      this.CurrentScheduleTask.OnStartGoing();
    }
  }

  public void Schedule_GoingToTargetThread()
  {
    if (this.CurrentTaskIsNull())
    {
      Debug.LogError((object) "bruh");
      this.CompleteScheduleTask();
    }
    else
    {
      if (this.CurrentScheduleTask.WhileGoing != null)
        this.CurrentScheduleTask.WhileGoing();
      if ((double) Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.z), new Vector2(this.CurrentScheduleTask.ActionPlace.position.x, this.CurrentScheduleTask.ActionPlace.position.z)) <= (double) this.navMesh.stoppingDistance)
      {
        if (this.navMesh.enabled)
          this.navMesh.isStopped = true;
        this.Do_Schedule_GoingToTargetThread = false;
        this.CurrentScheduleTask.State = 2;
        this.WhileDoingAction = this.CurrentScheduleTask.WhileDoing;
        if (this.CurrentScheduleTask.OnArrive != null)
          this.CurrentScheduleTask.OnArrive();
        else
          this.CompleteScheduleTask();
      }
      else
      {
        if (!this.CurrentScheduleTask.CanBeInterrupted || !this.navMesh.enabled || this.PostureState != Person_PostureState.Standing)
          return;
        this._TimeGoingToTarget += Time.deltaTime;
        if ((double) this._TimeGoingToTarget < 3.0)
          return;
        this.CompleteScheduleTask();
      }
    }
  }

  public void CompleteScheduleTask() => this.CompleteScheduleTask(true);

  public void CompleteScheduleTask(bool decideAfter)
  {
    this._TimeGoingToTarget = 0.0f;
    this.WhileDoingAction = (Action) null;
    this.Do_Schedule_GoingToTargetThread = false;
    if (this.CurrentTaskIsNull())
      return;
    if (this.CurrentScheduleTask.OnFinish != null)
      this.CurrentScheduleTask.OnFinish();
    this.FreeScheduleTasks.Remove(this.CurrentScheduleTask);
    this.WorkScheduleTasks.Remove(this.CurrentScheduleTask);
    this.CurrentScheduleTask = (Person.ScheduleTask) null;
    if (!decideAfter)
      return;
    this.ScheduleDecide();
  }

  public void SexUpdate()
  {
    if (this.HavingSex || this.Masturbating)
    {
      if ((double) this.Orgasming > 0.0)
      {
        this.Orgasming -= Time.deltaTime;
        if ((double) this.Orgasming <= 0.0)
        {
          this.ResetAllShapes();
          if ((UnityEngine.Object) this.HavingSex_Scene != (UnityEngine.Object) null)
            this.HavingSex_Scene.FaceExpressionOverwrite();
        }
      }
      if ((double) this.Arousal < 1.0)
      {
        if (!this.SexPoseHasNoArousalIncrease)
        {
          if (this.Perks.Contains("Sensetivity"))
            this.SexMultiplier = 1.5f;
          this.Arousal += (float) ((double) Time.deltaTime * (double) this.SexMultiplier * (double) this.SexMAddictionultiplier / 20.0);
        }
        if (!this.IsPlayer)
          return;
        Main.Instance.GameplayMenu.UpdateArousal();
      }
      else
      {
        this.Orgasm();
        if (!this.IsPlayer)
          return;
        Main.Instance.GameplayMenu.UpdateArousal();
      }
    }
    else if ((double) this.Arousal < 0.0)
    {
      this.Arousal = 0.0f;
      if (!this.IsPlayer)
        return;
      Main.Instance.GameplayMenu.UpdateArousal();
    }
    else
    {
      if ((double) this.Arousal <= 0.0)
        return;
      this.Arousal -= Time.deltaTime / 100f;
      if (!this.IsPlayer)
        return;
      Main.Instance.GameplayMenu.UpdateArousal();
    }
  }

  private void Update()
  {
    if (this.TEMP_UPDATE_OFF)
      return;
    if (!this.InCombat || this.IsPlayer)
    {
      if (this.DEBUG)
        Debug.Log((object) "!InCombat");
      if (!this.TEMP_SEXUPDATE_OFF)
        this.SexUpdate();
      if (!this.TEMP_RUNTIME_OFF)
      {
        for (int index = 0; index < this.RuntimeActions.Count; ++index)
          this.RuntimeActions[index]();
      }
      if (!this.TEMP_HANDLENEEDS_OFF)
        this.HandleNeeds();
    }
    if (!this.InCombat)
    {
      if (!this.IsPlayer)
      {
        if (this.DEBUG)
          Debug.Log((object) ("WhileDoingAction == null" + (this.WhileDoingAction == null).ToString()));
        if (this.WhileDoingAction != null)
          this.WhileDoingAction();
        switch (this.State)
        {
          case Person_State.Free:
            if (this.DEBUG)
              Debug.Log((object) "Person_State.Free:");
            if (this.CurrentTaskIsNull())
            {
              if (this.DEBUG)
                Debug.Log((object) "(CurrentTaskIsNull())");
              if ((UnityEngine.Object) this.CurrentZone != (UnityEngine.Object) null)
              {
                if (this.DEBUG)
                  Debug.Log((object) "(CurrentZone != null)");
                Interactible _int = this.CurrentZone.PickThingToDo(this);
                if ((UnityEngine.Object) _int != (UnityEngine.Object) null)
                {
                  if (this.DEBUG)
                    Debug.Log((object) "(_int != null)");
                  this.RandActionTimer = UnityEngine.Random.Range(5f, 50f);
                  this.AddFreeScheduleTask(new Person.ScheduleTask()
                  {
                    IDName = "DoSomethingInZone",
                    ActionPlace = _int.NavMeshInteractSpot,
                    RunTo = _int.RunTo,
                    CanBeInterrupted = true,
                    WhileDoing = _int.AutomatedStopInteraction ? (Action) null : (Action) (() =>
                    {
                      this.RandActionTimer -= Time.deltaTime;
                      if ((double) this.RandActionTimer > 0.0)
                        return;
                      this.RandActionTimer = UnityEngine.Random.Range(5f, 50f);
                      if ((UnityEngine.Object) this.InteractingWith != (UnityEngine.Object) null)
                      {
                        if (this.InteractingWith.NPCOnFinishInteract == null)
                        {
                          this.InteractingWith.StopInteracting();
                          this.CompleteScheduleTask();
                        }
                        else
                          this.InteractingWith.StopInteracting();
                      }
                      else
                        this.CompleteScheduleTask();
                    }),
                    OnArrive = (Action) (() =>
                    {
                      if (_int.CanInteract)
                      {
                        _int.NPCOnFinishInteract = new Action(this.CompleteScheduleTask);
                        _int.Interact(this);
                      }
                      else
                        this.CompleteScheduleTask();
                    })
                  }, true);
                  break;
                }
                break;
              }
              break;
            }
            break;
        }
        if (this.Do_Schedule_GoingToTargetThread)
          this.Schedule_GoingToTargetThread();
      }
    }
    else
      this.HandleCombat();
    if (!this.Interacting && !this.TEMP_HANDLEANIMS_OFF)
      this.UpdateAnim();
    if (this.InCombat || !this.CurrentTaskIsNull())
      return;
    this.DecideTimer -= Time.deltaTime;
    if ((double) this.DecideTimer > 0.0)
      return;
    this.ScheduleDecide();
  }

  public void AddGoHome()
  {
    if ((UnityEngine.Object) this.Home.Door == (UnityEngine.Object) null)
      this.AddFreeScheduleTask(new Person.ScheduleTask()
      {
        IDName = "GoHome",
        ActionPlace = this.Home.Location,
        KeepPathEnabled = true,
        OnArrive = (Action) (() =>
        {
          this.CurrentZone = this.Home;
          this.CompleteScheduleTask();
        })
      }, true);
    else
      this.AddFreeScheduleTask(new Person.ScheduleTask()
      {
        IDName = "GoHome",
        ActionPlace = this.Home.Door.NavMeshInteractSpot,
        KeepPathEnabled = true,
        OnArrive = (Action) (() =>
        {
          this.CurrentZone = this.Home;
          if (!this.Home.Door.Open)
          {
            this.Home.Door.Locked = false;
            this.Home.Door.Interact(this);
          }
          this.StartScheduleTask(new Person.ScheduleTask()
          {
            IDName = "GoInHome",
            ActionPlace = this.Home.Location,
            KeepPathEnabled = true,
            OnArrive = (Action) (() =>
            {
              if (this.Home.Door.Open)
                this.Home.Door.Interact(this);
              this.CurrentZone = this.Home;
              this.CompleteScheduleTask();
            })
          });
        })
      }, true);
  }

  public void HandleWork()
  {
  }

  public void HandleNeeds()
  {
    if ((double) this.Energy > 0.0)
      this.Energy -= Time.deltaTime / 1200f;
    this.States[4] = this.NeedsEnergy;
    if (this.States[4])
    {
      if ((double) this.Energy <= 0.0)
        this.SleepOnFloor();
      if (this.IsPlayer && !Main.Instance.GameplayMenu.ShownSleep)
      {
        Main.Instance.GameplayMenu.ShownSleep = true;
        Main.Instance.GameplayMenu.ShowNotification("You're feeling tired!");
      }
    }
    else if (this.IsPlayer)
      Main.Instance.GameplayMenu.ShownSleep = false;
    if ((double) this.Hunger < (double) this.HungerMax)
      this.Hunger += Time.deltaTime / 600f;
    this.States[6] = this.IsHungry;
    if (this.States[6])
    {
      if (this.IsPlayer && !Main.Instance.GameplayMenu.ShownHunger)
      {
        Main.Instance.GameplayMenu.ShownHunger = true;
        Main.Instance.GameplayMenu.ShowNotification("You are hungry!");
      }
    }
    else if (this.IsPlayer)
      Main.Instance.GameplayMenu.ShownHunger = false;
    if (!Main.Instance.ScatContent)
      return;
    if ((double) this.Toilet < (double) this.ToiletMax)
      this.Toilet += Time.deltaTime / 1200f;
    this.States[5] = this.NeedsToilet;
    if (this.States[5])
    {
      if ((double) this.Toilet >= 100.0)
        this.ShitOnFloor();
      if (!this.IsPlayer || Main.Instance.GameplayMenu.ShownToilet)
        return;
      Main.Instance.GameplayMenu.ShownToilet = true;
      Main.Instance.GameplayMenu.ShowNotification("You need to evacuate!");
    }
    else
    {
      if (!this.IsPlayer)
        return;
      Main.Instance.GameplayMenu.ShownToilet = false;
    }
  }

  public void EndingCombatFunc()
  {
    this.RandActionTimer -= Time.deltaTime;
    if ((double) this.RandActionTimer > 0.0)
      return;
    Main.Instance.MainThreads.Remove(new Action(this.EndingCombatFunc));
    this.StopFighting();
  }

  public bool NoMoveInCombat => this.MoveBlockers.Count != 0;

  public void HandleCombat()
  {
    if (this.IsPlayer)
      return;
    if (!this.EndingCombat && ((UnityEngine.Object) this.EnemyFighting == (UnityEngine.Object) null || this.EnemyFighting.dead || this.EnemyFighting.Incapacitated || this.TheHealth.dead || this.TheHealth.Incapacitated || (double) Vector3.Distance(this.EnemyFighting.transform.position, this.transform.position) > (double) this.CombatDistance))
    {
      Main.Instance.MainThreads.Add(new Action(this.EndingCombatFunc));
      this.EndingCombat = true;
      this.RandActionTimer = 1f;
    }
    else
    {
      if (this.TheHealth.dead || this.TheHealth.Incapacitated || !((UnityEngine.Object) this.EnemyFighting != (UnityEngine.Object) null))
        return;
      if ((UnityEngine.Object) this.WeaponInv.CurrentWeapon != (UnityEngine.Object) null && this.WeaponInv.CurrentWeapon.type != WeaponType.Melee)
      {
        float num = Vector3.Distance(this.EnemyFighting.transform.position, this.transform.position);
        if ((double) num > 20.0)
        {
          this.CombatState = Person_CombatState.ChasingAndFiring;
          if (!this.NoMoveInCombat && this.navMesh.gameObject.activeSelf)
          {
            this.navMesh.enabled = true;
            this.navMesh.speed = 4f;
            this.navMesh.isStopped = false;
            this.navMesh.destination = this.EnemyFighting.transform.position;
          }
        }
        else
        {
          if ((double) num < 1.1000000238418579)
          {
            if (this.EndingCombat)
              return;
            this.Kick(this.EnemyFighting.PersonComponent);
            return;
          }
          this.CombatState = Person_CombatState.Firing;
          if (this.navMesh.enabled)
            this.navMesh.isStopped = true;
        }
        if ((this._ShootBlind ? 1 : (this.Eyes.CanSee(this.EnemyFighting.PersonComponent.MainCol, Color.green) ? 1 : 0)) != 0)
        {
          this.CombatState = Person_CombatState.Firing;
          this.transform.LookAt(this.EnemyFighting.transform);
          this.EnemyLastKnownPosition = this.EnemyFighting.transform.position;
          if ((double) Vector3.Distance(this.EnemyFighting.transform.position, this.transform.position) >= 50.0)
            return;
          this.WeaponInv.CurrentWeapon.AIFiring();
        }
        else
        {
          if (!(this.EnemyLastKnownPosition != Vector3.zero))
            return;
          if ((double) Vector3.Distance(this.EnemyLastKnownPosition, this.transform.position) > 0.10000000149011612)
          {
            this.CombatState = Person_CombatState.GoingTolastKnownPosition;
            if (this.NoMoveInCombat || !this.navMesh.gameObject.activeSelf)
              return;
            this.navMesh.enabled = true;
            this.navMesh.speed = 4f;
            this.navMesh.isStopped = false;
            this.navMesh.destination = this.EnemyLastKnownPosition;
          }
          else
          {
            this.CombatState = Person_CombatState.Waiting;
            if (!this.navMesh.enabled)
              return;
            this.navMesh.isStopped = true;
          }
        }
      }
      else if ((UnityEngine.Object) this.WeaponInv.CurrentWeapon != (UnityEngine.Object) null && this.WeaponInv.CurrentWeapon.type == WeaponType.Melee)
      {
        if (this.MoveBlockers.Contains("Punching"))
          return;
        if ((double) Vector3.Distance(this.EnemyFighting.transform.position, this.transform.position) > 1.0)
        {
          this.CombatState = Person_CombatState.ChasingAndFiring;
          if (this.NoMoveInCombat || !this.navMesh.gameObject.activeSelf)
            return;
          this.navMesh.enabled = true;
          this.navMesh.speed = 4f;
          this.navMesh.isStopped = false;
          this.navMesh.destination = this.EnemyFighting.transform.position;
        }
        else
        {
          this.CombatState = Person_CombatState.Firing;
          if (this.navMesh.enabled)
            this.navMesh.isStopped = true;
          if (this.EndingCombat)
            return;
          this.MeleeHit(this.EnemyFighting.PersonComponent);
        }
      }
      else
      {
        if (this.MoveBlockers.Contains("Punching"))
          return;
        if ((double) Vector3.Distance(this.EnemyFighting.transform.position, this.transform.position) > 1.0)
        {
          this.CombatState = Person_CombatState.ChasingAndFiring;
          if (this.NoMoveInCombat || !this.navMesh.gameObject.activeSelf)
            return;
          this.navMesh.enabled = true;
          this.navMesh.speed = 4f;
          this.navMesh.isStopped = false;
          this.navMesh.destination = this.EnemyFighting.transform.position;
        }
        else
        {
          this.CombatState = Person_CombatState.Firing;
          if (this.navMesh.enabled)
            this.navMesh.isStopped = true;
          if (this.EndingCombat)
            return;
          this.Punch(this.EnemyFighting.PersonComponent);
        }
      }
    }
  }

  public virtual void Orgasm()
  {
    this.Arousal = 0.1f;
    this.Orgasming = 3f;
    if (!this.NoEnergyLoss)
      this.Energy -= 4f;
    this.ResetAllShapes();
    int aheFace = (int) Main.Instance.SexScene.AheFaces[UnityEngine.Random.Range(0, Main.Instance.SexScene.AheFaces.Length)];
    this.ApplyFaceBlendShapeData(Main.Instance.BlendShapesDatas[aheFace]);
    if (this.SquirtSpots != null)
    {
      for (int index = 0; index < this.SquirtSpots.Count; ++index)
        UnityEngine.Object.Instantiate<GameObject>(Main.Instance.SquirtPrefab, this.SquirtSpots[index]);
    }
    this.GainSexXP(this.Perks.Contains("Longer Orgasm") ? 250 : 100);
    if ((double) this.SexMAddictionultiplier < 2.0)
      this.SexMAddictionultiplier += 0.01f;
    if ((UnityEngine.Object) this.HavingSexWith != (UnityEngine.Object) null)
    {
      this.Favor += 5;
      if ((UnityEngine.Object) this.HavingSex_Scene.Leading == (UnityEngine.Object) this)
      {
        if (this.HasPenis && !this.HasCondomPut && this.HavingSexWith is Girl)
        {
          if ((UnityEngine.Object) this.HavingSex_Scene == (UnityEngine.Object) Main.Instance.SexScene.PlayerSex)
          {
            if (!Main.Instance.SexScene._CondomIsOn && Main.Instance.SexScene.TextVaginalAnal.text != "Anal")
              ((Girl) this.HavingSexWith).BecomePreg(false, this.HavingSexWith.Fertility);
          }
          else
            ((Girl) this.HavingSexWith).BecomePreg(false, this.HavingSexWith.Fertility);
        }
        if (this.HasPenis && !this.HasCondomPut && this.HavingSex_Scene.CurrentPose.HoleGoingInto == 2)
        {
          this.HavingSexWith.States[26] = true;
          this.HavingSexWith.SetBodyTexture();
        }
      }
    }
    AudioClip clip = Main.Instance.FemaleForcedStart[UnityEngine.Random.Range(0, Main.Instance.FemaleForcedStart.Length)];
    this.PersonAudio.pitch = this.VoicePitch;
    if (!((UnityEngine.Object) clip != (UnityEngine.Object) null))
      return;
    this.PersonAudio.PlayOneShot(clip);
  }

  public void GainSexXP(int amount, int totalamountpass = 0, bool levelup = false)
  {
    if (totalamountpass == 0)
      totalamountpass = amount;
    this.SexXpThisLvl += amount;
    if (this.SexXpThisLvl >= this.SexXpThisLvlMax)
    {
      int amount1 = this.SexXpThisLvl - this.SexXpThisLvlMax;
      this.SexXpThisLvl = 0;
      ++this.SexSkills;
      this.GainSexXP(amount1, totalamountpass, true);
    }
    else
    {
      if (!this.IsPlayer)
        return;
      Main.Instance.GameplayMenu.AddSexXp(totalamountpass, levelup);
    }
  }

  public void GainWorkXP(int amount, int totalamountpass = 0, bool levelup = false)
  {
    if (totalamountpass == 0)
      totalamountpass = amount;
    this.WorkXpThisLvl += amount;
    if (this.WorkXpThisLvl >= this.WorkXpThisLvlMax)
    {
      int amount1 = this.WorkXpThisLvl - this.WorkXpThisLvlMax;
      this.WorkXpThisLvl = 0;
      ++this.WorkSkills;
      this.GainWorkXP(amount1, totalamountpass, true);
    }
    else
    {
      if (!this.IsPlayer)
        return;
      Main.Instance.GameplayMenu.AddWorkerXp(totalamountpass, levelup);
    }
  }

  public void GainArmyXP(int amount, int totalamountpass = 0, bool levelup = false)
  {
    if (totalamountpass == 0)
      totalamountpass = amount;
    this.ArmyXpThisLvl += amount;
    if (this.ArmyXpThisLvl >= this.ArmyXpThisLvlMax)
    {
      int amount1 = this.ArmyXpThisLvl - this.ArmyXpThisLvlMax;
      this.ArmyXpThisLvl = 0;
      ++this.ArmySkills;
      this.GainArmyXP(amount1, totalamountpass, true);
    }
    else
    {
      if (!this.IsPlayer)
        return;
      Main.Instance.GameplayMenu.AddArmyXp(totalamountpass, levelup);
    }
  }

  public virtual bool HiddenHead
  {
    get => this._HiddenHead;
    set
    {
      this._HiddenHead = value;
      if (this.MaterialTypeNPC == 1)
        return;
      if (value)
      {
        this.MainBody.materials = new Material[1]
        {
          this.MainBody.material
        };
      }
      else
      {
        this.MainBody.materials = new Material[7]
        {
          this.MainBody.material,
          Main.Instance.MatHead,
          Main.Instance.MatEyePupil,
          Main.Instance.MatEyeBack,
          Main.Instance.MatLash,
          Main.Instance.MatThong,
          Main.Instance.MatTeeth
        };
        this.MainBody.materials[1].color = this.MainBody.material.color;
        this.DirtySkin = this.DirtySkin;
      }
    }
  }

  public void ChangeUniform(GameObject[] clothes, bool removecurrent = true)
  {
    if (removecurrent)
    {
      List<Dressable> dressableList = new List<Dressable>();
      dressableList.AddRange((IEnumerable<Dressable>) this.EquippedClothes);
      for (int index = 0; index < dressableList.Count; ++index)
      {
        switch (dressableList[index].BodyPart)
        {
          case DressableType.Hair:
          case DressableType.Head:
          case DressableType.Body:
          case DressableType.Feet:
          case DressableType.Beard:
            continue;
          default:
            UnityEngine.Object.Destroy((UnityEngine.Object) this.UndressClothe(dressableList[index]));
            continue;
        }
      }
    }
    for (int index = 0; index < clothes.Length; ++index)
      this.DressClothe(clothes[index]);
  }

  public GameObject DressClothe(GameObject prefab, bool spawnNew = true, string clothingData = "")
  {
    if ((UnityEngine.Object) prefab == (UnityEngine.Object) null)
      return (GameObject) null;
    Dressable componentInChildren1 = prefab.GetComponentInChildren<Dressable>();
    if ((UnityEngine.Object) componentInChildren1 != (UnityEngine.Object) null)
    {
      switch (componentInChildren1.GenderFor)
      {
        case GenderType.Female:
          if (!(this is Girl))
            return (GameObject) null;
          break;
        case GenderType.Male:
          if (!(this is Guy))
            return (GameObject) null;
          break;
      }
    }
    MultiInteractible component1 = prefab.GetComponent<MultiInteractible>();
    if ((UnityEngine.Object) component1 != (UnityEngine.Object) null)
    {
      int_PickableClothingPackage component2 = component1.Parts[0].gameObject.GetComponent<int_PickableClothingPackage>();
      if ((UnityEngine.Object) component2 != (UnityEngine.Object) null)
      {
        component2.Dress(this, spawnNew);
        return component2.gameObject;
      }
    }
    GameObject gameObject = !spawnNew ? prefab : Main.Spawn(prefab);
    SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(true);
    Dressable componentInChildren2 = gameObject.GetComponentInChildren<Dressable>();
    switch (componentInChildren2.GenderFor)
    {
      case GenderType.Female:
        if (!(this is Girl))
        {
          if (spawnNew)
            UnityEngine.Object.Destroy((UnityEngine.Object) gameObject);
          return (GameObject) null;
        }
        break;
      case GenderType.Male:
        if (!(this is Guy))
        {
          if (spawnNew)
            UnityEngine.Object.Destroy((UnityEngine.Object) gameObject);
          return (GameObject) null;
        }
        break;
    }
    if ((UnityEngine.Object) componentInChildren2.OriginalPrefab == (UnityEngine.Object) null)
      componentInChildren2.OriginalPrefab = prefab;
    componentInChildren2.PersonEquipped = this;
    componentInChildren2.Equipped = true;
    for (int index = 0; index < componentInChildren2.OnDrop_Col.Length; ++index)
      componentInChildren2.OnDrop_Col[index].enabled = false;
    for (int index = 0; index < componentInChildren2.OnDrop_Rig.Length; ++index)
      componentInChildren2.OnDrop_Rig[index].isKinematic = true;
    this.EquippedClothes.Add(componentInChildren2);
    switch (componentInChildren2.BodyPart)
    {
      case DressableType.Any:
        this.CurrentAnys.Add(componentInChildren2);
        break;
      case DressableType.Shoes:
        if ((UnityEngine.Object) this.CurrentShoes != (UnityEngine.Object) null)
          this.UndressClothe(this.CurrentShoes);
        this.CurrentShoes = componentInChildren2;
        break;
      case DressableType.Pants:
        if ((UnityEngine.Object) this.CurrentPants != (UnityEngine.Object) null)
          this.UndressClothe(this.CurrentPants);
        this.CurrentPants = componentInChildren2;
        this.RemovePenis();
        break;
      case DressableType.Top:
        if ((UnityEngine.Object) this.CurrentTop != (UnityEngine.Object) null)
          this.UndressClothe(this.CurrentTop);
        this.CurrentTop = componentInChildren2;
        break;
      case DressableType.UnderwearTop:
        if ((UnityEngine.Object) this.CurrentUnderwearTop != (UnityEngine.Object) null)
          this.UndressClothe(this.CurrentUnderwearTop);
        this.CurrentUnderwearTop = componentInChildren2;
        break;
      case DressableType.UnderwearLower:
        if ((UnityEngine.Object) this.CurrentUnderwearLower != (UnityEngine.Object) null)
          this.UndressClothe(this.CurrentUnderwearLower);
        this.CurrentUnderwearLower = componentInChildren2;
        break;
      case DressableType.Garter:
        if ((UnityEngine.Object) this.CurrentGarter != (UnityEngine.Object) null)
          this.UndressClothe(this.CurrentGarter);
        this.CurrentGarter = componentInChildren2;
        break;
      case DressableType.Socks:
        if ((UnityEngine.Object) this.CurrentSocks != (UnityEngine.Object) null)
          this.UndressClothe(this.CurrentSocks);
        this.CurrentSocks = componentInChildren2;
        break;
      case DressableType.Hat:
        if ((UnityEngine.Object) this.CurrentHat != (UnityEngine.Object) null)
          this.UndressClothe(this.CurrentHat);
        this.CurrentHat = componentInChildren2;
        break;
      case DressableType.Hair:
        if ((UnityEngine.Object) this.CurrentHair != (UnityEngine.Object) null)
          this.UndressClothe(this.CurrentHair);
        this.CurrentHair = componentInChildren2;
        break;
      case DressableType.Head:
        this.HiddenHead = true;
        this.CurrentHead = componentInChildren2;
        break;
      case DressableType.Body:
        this.MainBody.gameObject.SetActive(false);
        this.CurrentBody = componentInChildren2;
        break;
      case DressableType.BackPack:
        if ((UnityEngine.Object) this.CurrentBackpack != (UnityEngine.Object) null)
          this.UndressClothe((Dressable) this.CurrentBackpack);
        this.CurrentBackpack = (BackPack) componentInChildren2;
        break;
      case DressableType.Feet:
        this.CurrentFeet = componentInChildren2;
        this.CurrentFeetMesh = this.CurrentFeet.GetComponentInChildren<SkinnedMeshRenderer>();
        this.CurrentFeetMesh.material = this.MainBody.material;
        break;
      case DressableType.Beard:
        if ((UnityEngine.Object) this.CurrentBeard != (UnityEngine.Object) null)
          this.UndressClothe(this.CurrentBeard);
        this.CurrentBeard = componentInChildren2;
        break;
    }
    if (componentInChildren2.HidesFeet && (UnityEngine.Object) this.CurrentFeet != (UnityEngine.Object) null)
      this.RemoveFeet();
    if (componentInChildren2.Skinned)
    {
      gameObject.transform.SetParent(this.transform);
      gameObject.transform.localPosition = Vector3.zero;
      gameObject.transform.localEulerAngles = Vector3.zero;
      for (int index1 = 0; index1 < componentsInChildren.Length; ++index1)
      {
        componentsInChildren[index1].rootBone = this.MainBody.rootBone;
        if (componentInChildren2.DefaultBones)
          componentsInChildren[index1].bones = this.MainBody.bones;
        else if (componentInChildren2.AttachBones)
        {
          componentInChildren2.BoneStorage = componentsInChildren[index1].bones;
          if (componentInChildren2.PlacedBones != null && componentInChildren2.PlacedBones.Length != 0)
          {
            for (int index2 = 0; index2 < componentInChildren2.PlacedBones.Length; ++index2)
            {
              if (componentInChildren2.PlacedBones[index2] != 0)
              {
                componentsInChildren[index1].bones[index2].SetParent(this.MainBody.bones[componentInChildren2.PlacedBones[index2]]);
                if (componentInChildren2.PlacedBonesPos != null && componentInChildren2.PlacedBonesPos.Length != 0 && componentInChildren2.PlacedBonesPos.Length > index2)
                {
                  componentsInChildren[index1].bones[index2].localPosition = componentInChildren2.PlacedBonesPos[index2];
                  componentsInChildren[index1].bones[index2].localEulerAngles = componentInChildren2.PlacedBonesRot == null || componentInChildren2.PlacedBonesRot.Length == 0 || componentInChildren2.PlacedBonesRot.Length <= index2 ? Vector3.zero : componentInChildren2.PlacedBonesRot[index2];
                  componentsInChildren[index1].bones[index2].localScale = componentInChildren2.PlacedBonesScl == null || componentInChildren2.PlacedBonesScl.Length == 0 || componentInChildren2.PlacedBonesScl.Length <= index2 ? Vector3.one : componentInChildren2.PlacedBonesScl[index2];
                }
                else
                {
                  componentsInChildren[index1].bones[index2].SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
                  componentsInChildren[index1].bones[index2].localScale = Vector3.one;
                }
              }
            }
          }
          else
          {
            bool[] flagArray = new bool[this.MainBody.bones.Length];
            componentInChildren2.PlacedBones = new int[componentsInChildren[index1].bones.Length];
            for (int index3 = 0; index3 < componentsInChildren[index1].bones.Length; ++index3)
            {
              for (int index4 = 0; index4 < this.MainBody.bones.Length; ++index4)
              {
                if ((UnityEngine.Object) this.MainBody.bones[index4] != (UnityEngine.Object) null && (UnityEngine.Object) componentsInChildren[index1].bones[index3] != (UnityEngine.Object) null && !flagArray[index4] && this.MainBody.bones[index4].name == componentsInChildren[index1].bones[index3].name)
                {
                  flagArray[index4] = true;
                  componentInChildren2.PlacedBones[index3] = index4;
                  componentsInChildren[index1].bones[index3].SetParent(this.MainBody.bones[index4]);
                  if (componentInChildren2.PlacedBonesPos != null && componentInChildren2.PlacedBonesPos.Length != 0)
                  {
                    componentsInChildren[index1].bones[index3].localPosition = componentInChildren2.PlacedBonesPos[index3];
                    componentsInChildren[index1].bones[index3].localEulerAngles = componentInChildren2.PlacedBonesRot[index3];
                    componentsInChildren[index1].bones[index3].localScale = componentInChildren2.PlacedBonesScl[index3];
                  }
                  else
                  {
                    componentsInChildren[index1].bones[index3].SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
                    componentsInChildren[index1].bones[index3].localScale = Vector3.one;
                  }
                }
              }
            }
          }
        }
        else if (this._ClothingBatch1Bones != null)
        {
          componentsInChildren[index1].bones = this._ClothingBatch1Bones;
        }
        else
        {
          Transform[] transformArray = new Transform[componentsInChildren[index1].bones.Length];
          bool[] flagArray = new bool[transformArray.Length];
          string[] strArray = new string[transformArray.Length];
          for (int index5 = 0; index5 < transformArray.Length; ++index5)
            strArray[index5] = componentsInChildren[index1].bones[index5].name;
          for (int index6 = 0; index6 < componentsInChildren[index1].bones.Length; ++index6)
          {
            for (int index7 = 0; index7 < this.MainBody.bones.Length; ++index7)
            {
              if (!flagArray[index6] && this.MainBody.bones[index7].name == strArray[index6])
              {
                transformArray[index6] = this.MainBody.bones[index7];
                flagArray[index6] = true;
                componentInChildren2.PlacedBones[index6] = index7;
                break;
              }
            }
          }
          componentsInChildren[index1].bones = transformArray;
          this._ClothingBatch1Bones = transformArray;
        }
      }
      Transform transform1 = gameObject.transform.Find("Armature");
      if ((UnityEngine.Object) transform1 != (UnityEngine.Object) null)
        UnityEngine.Object.Destroy((UnityEngine.Object) transform1.gameObject);
      Transform transform2 = gameObject.transform.Find("BodyTop");
      if ((UnityEngine.Object) transform2 != (UnityEngine.Object) null)
        UnityEngine.Object.Destroy((UnityEngine.Object) transform2.gameObject);
    }
    else
    {
      switch (componentInChildren2.BodyPart)
      {
        case DressableType.Hat:
        case DressableType.Hair:
        case DressableType.Head:
        case DressableType.Beard:
          gameObject.transform.SetParent(this.HeadStuff);
          gameObject.transform.localPosition = componentInChildren2.AttatchPos;
          gameObject.transform.localEulerAngles = componentInChildren2.AttatchRot;
          gameObject.transform.localScale = componentInChildren2.AttatchScl;
          break;
        default:
          Transform headStuff;
          if (componentInChildren2.AttatchBone == "headstuff")
          {
            headStuff = this.HeadStuff;
          }
          else
          {
            headStuff = this.Anim.transform.Find(componentInChildren2.AttatchBone);
            if ((UnityEngine.Object) headStuff == (UnityEngine.Object) null)
              headStuff = this.Anim.transform.Find(componentInChildren2.MaleAttatchBone);
          }
          if ((UnityEngine.Object) headStuff == (UnityEngine.Object) null)
          {
            Debug.LogError((object) $"Could not find AttatchBone \"{componentInChildren2.AttatchBone}\"");
            break;
          }
          gameObject.transform.SetParent(headStuff);
          gameObject.transform.localPosition = componentInChildren2.AttatchPos;
          gameObject.transform.localEulerAngles = componentInChildren2.AttatchRot;
          gameObject.transform.localScale = componentInChildren2.AttatchScl;
          break;
      }
    }
    if (clothingData.Length > 0)
      componentInChildren2.sv_LoadData(clothingData, removeFirst: false);
    if (this is Guy)
      this.RefreshColors();
    componentInChildren2.OnDressed();
    this.GetClothingCondition();
    return componentInChildren2.gameObject;
  }

  public void PutOnHand(GameObject obj, Vector3 pos, Vector3 rot)
  {
    if ((UnityEngine.Object) this.ObjInHand != (UnityEngine.Object) null)
      this.DropFromHand();
    this.ObjInHand = obj;
    obj.transform.SetParent(this.RightHandStuff);
    obj.transform.SetLocalPositionAndRotation(pos, Quaternion.Euler(rot));
  }

  public void DropFromHand()
  {
    this.ObjInHand.transform.SetParent((Transform) null);
    this.ObjInHand = (GameObject) null;
  }

  public void PutFeet()
  {
    if (!((UnityEngine.Object) this.CurrentFeet == (UnityEngine.Object) null))
      return;
    this.DressClothe(Main.Instance.Feet);
  }

  public void RemoveFeet() => UnityEngine.Object.Destroy((UnityEngine.Object) this.UndressClothe(this.CurrentFeet));

  public void PutPenis()
  {
    this.PenisEnabled = true;
    if (this.CurrentLOD == 2)
      this.Penis.SetActive(true);
    this.PenisErect = false;
  }

  public void RemovePenis()
  {
    this.PenisEnabled = false;
    if (!((UnityEngine.Object) this.Penis != (UnityEngine.Object) null))
      return;
    this.Penis.SetActive(false);
  }

  public bool HasBalls
  {
    get => (double) this.PenisBones[0].localScale.y > 0.5;
    set
    {
      if (value)
      {
        this.PenisBones[0].localPosition = new Vector3(0.0f, -11f / 1000f, 0.0036f);
        this.PenisBones[0].localScale = new Vector3(1f, 1f, 1f);
      }
      else
      {
        this.PenisBones[0].localPosition = new Vector3(0.0f, -1f / 1000f, -0.0191f);
        this.PenisBones[0].localScale = new Vector3(0.5f, 0.0f, 0.0f);
      }
    }
  }

  public GameObject UndressClothe(Dressable clothe)
  {
    if ((UnityEngine.Object) clothe == (UnityEngine.Object) null)
      return (GameObject) null;
    clothe.transform.SetParent((Transform) null);
    clothe.Equipped = false;
    for (int index = 0; index < clothe.OnDrop_Col.Length; ++index)
      clothe.OnDrop_Col[index].enabled = true;
    for (int index = 0; index < clothe.OnDrop_Rig.Length; ++index)
      clothe.OnDrop_Rig[index].isKinematic = false;
    foreach (Renderer componentsInChild in clothe.GetComponentsInChildren<Renderer>())
      componentsInChild.shadowCastingMode = ShadowCastingMode.On;
    clothe.OnUndressed();
    this.ResetAllShapes();
    if (clothe.HidesFeet && (UnityEngine.Object) this.CurrentFeet == (UnityEngine.Object) null)
      this.PutFeet();
    if (clothe.BoneStorage != null)
    {
      for (int index = 0; index < clothe.BoneStorage.Length; ++index)
      {
        if ((UnityEngine.Object) clothe.BoneStorage[index] != (UnityEngine.Object) null)
          UnityEngine.Object.Destroy((UnityEngine.Object) clothe.BoneStorage[index].gameObject);
      }
    }
    switch (clothe.BodyPart)
    {
      case DressableType.Any:
        this.CurrentAnys.Remove(clothe);
        break;
      case DressableType.Shoes:
        this.CurrentShoes = (Dressable) null;
        break;
      case DressableType.Pants:
        this.CurrentPants = (Dressable) null;
        if (this is Girl)
        {
          if (((Girl) this).Futa)
          {
            this.PutPenis();
            break;
          }
          break;
        }
        this.PutPenis();
        break;
      case DressableType.Top:
        this.CurrentTop = (Dressable) null;
        break;
      case DressableType.UnderwearTop:
        this.CurrentUnderwearTop = (Dressable) null;
        break;
      case DressableType.UnderwearLower:
        this.CurrentUnderwearLower = (Dressable) null;
        break;
      case DressableType.Garter:
        this.CurrentGarter = (Dressable) null;
        break;
      case DressableType.Socks:
        this.CurrentSocks = (Dressable) null;
        break;
      case DressableType.Hat:
        this.CurrentHat = (Dressable) null;
        break;
      case DressableType.Hair:
        this.CurrentHair = (Dressable) null;
        break;
      case DressableType.Head:
        this.CurrentHead = (Dressable) null;
        break;
      case DressableType.Body:
        this.CurrentBody = (Dressable) null;
        break;
      case DressableType.BackPack:
        this.CurrentBackpack = (BackPack) null;
        break;
      case DressableType.Feet:
        this.CurrentFeet = (Dressable) null;
        break;
      case DressableType.Beard:
        this.CurrentBeard = (Dressable) null;
        break;
    }
    clothe.PersonEquipped = (Person) null;
    this.EquippedClothes.Remove(clothe);
    GameObject gameObject = clothe.gameObject;
    if ((UnityEngine.Object) clothe.DropablePrefab != (UnityEngine.Object) null)
    {
      gameObject = Main.Spawn(clothe.DropablePrefab);
      gameObject.transform.position = this.transform.position + new Vector3(0.0f, 0.5f, 0.0f);
      int_PickableClothingPackage componentInChildren = gameObject.GetComponentInChildren<int_PickableClothingPackage>(true);
      if ((UnityEngine.Object) componentInChildren != (UnityEngine.Object) null)
        componentInChildren.ClothingData = clothe.sv_SaveData();
      UnityEngine.Object.Destroy((UnityEngine.Object) clothe.gameObject);
    }
    this.GetClothingCondition();
    return gameObject;
  }

  public virtual void GenerateRandomFace()
  {
    Main.Instance.RangeHead.ApplyTo(this.Head);
    Main.Instance.RangeMouthBase.ApplyTo(this.MouthBase);
    Main.Instance.RangeMouthSides.ApplyTo(this.MouthLeft, this.MouthRight);
    Main.Instance.RangeMouthTop.ApplyTo(this.MouthTop);
    Main.Instance.RangeMouthBottom.ApplyTo(this.MouthBottom);
    Main.Instance.RangeCheeksLow.ApplyTo(this.CheekLowLeft, this.CheekLowRight);
    Main.Instance.RangeEyes.ApplyTo(this.EyeLeft, this.EyeRight);
    Main.Instance.RangeEyesInner.ApplyTo(this.EyeLeftInner, this.EyeRightInner);
    Main.Instance.RangeEyesOuter.ApplyTo(this.EyeLeftOuter, this.EyeRightOuter);
    Main.Instance.RangeNose.ApplyTo(this.Nose);
    Main.Instance.RangeNoseBridge.ApplyTo(this.NoseBridge);
    Main.Instance.RangeNoseTip.ApplyTo(this.NoseTip);
    Main.Instance.RangeNostrils.ApplyTo(this.NostrilLeft, this.NostrilRight);
  }

  public virtual void GenerateRandomBody()
  {
    this.Height = UnityEngine.Random.Range(0.87f, 1.05f);
    this.transform.localScale = new Vector3(this.Height, this.Height, this.Height);
    Main.Instance.RangeNeck.ApplyTo(this.Neck);
    Main.Instance.RangeBoobs.ApplyTo(this.BoobLeft, this.BoobRight);
    Main.Instance.RangeNips.ApplyTo(this.NippleLeft, this.NippleRight);
    Main.Instance.RangeHips.ApplyTo(this.Hips);
    Main.Instance.RangeUpperThighs.ApplyTo(this.UpperThighLeft, this.UpperThighRight);
    Main.Instance.RangeCalves.ApplyTo(this.CalveLeft, this.CalveRight);
    Main.Instance.RangeWaist.ApplyTo(this.Waist);
    Main.Instance.RangeBelly.ApplyTo(this.Belly);
    Main.Instance.RangeShoulders.ApplyTo(this.ShoulderLeft, this.ShoulderRight);
    Main.Instance.RangeUpperArms.ApplyTo(this.UpperArmLeft, this.UpperArmRight);
    Main.Instance.RangeForeArms.ApplyTo(this.ForeArmLeft, this.ForeArmRight);
  }

  public void FixAverageScaleFor(Transform part)
  {
    float num1 = (double) part.localScale.x > (double) part.localScale.y ? part.localScale.y - part.localScale.x : part.localScale.x - part.localScale.y;
    float num2 = (double) part.localScale.y > (double) part.localScale.z ? part.localScale.z - part.localScale.y : part.localScale.y - part.localScale.z;
    float num3 = (double) part.localScale.z > (double) part.localScale.x ? part.localScale.x - part.localScale.z : part.localScale.z - part.localScale.x;
    if ((double) num1 > (double) num2 && (double) num1 > (double) num3)
    {
      float z = (double) num2 <= (double) num3 ? (float) (((double) part.localScale.z + (double) part.localScale.y) / 2.0) : (float) (((double) part.localScale.y + (double) part.localScale.z) / 2.0);
      part.localScale = new Vector3(part.localScale.x, part.localScale.y, z);
    }
    else if ((double) num2 > (double) num1 && (double) num2 > (double) num3)
    {
      float y = (double) num2 <= (double) num1 ? (float) (((double) part.localScale.x + (double) part.localScale.y) / 2.0) : (float) (((double) part.localScale.y + (double) part.localScale.x) / 2.0);
      part.localScale = new Vector3(part.localScale.x, y, part.localScale.z);
    }
    else
    {
      if ((double) num3 <= (double) num1 || (double) num3 <= (double) num2)
        return;
      float x = (double) num3 <= (double) num1 ? (float) (((double) part.localScale.x + (double) part.localScale.z) / 2.0) : (float) (((double) part.localScale.z + (double) part.localScale.x) / 2.0);
      part.localScale = new Vector3(x, part.localScale.y, part.localScale.z);
    }
  }

  public bool CantBeForced
  {
    get => !Main.Instance.FreeWorldPatch && this.IsPlayerDescendant || this._CantBeForced;
    set => this._CantBeForced = value;
  }

  public virtual void SetHighLod()
  {
    if (this.DEBUG)
      Debug.LogError((object) nameof (SetHighLod));
    this.RemoveMoveBlocker("InCullLOD");
    this.CurrentLOD = 2;
    if (!this.TheHealth.dead && !this.TheHealth.Incapacitated)
    {
      this.Anim.enabled = true;
      this.navMesh.obstacleAvoidanceType = ObstacleAvoidanceType.LowQualityObstacleAvoidance;
      if ((UnityEngine.Object) this.Eyes != (UnityEngine.Object) null)
        this.Eyes.Quality = Vision.VisionQuality.High;
      this.LookAtPlayer.EnableIfNotEnabled();
      if ((UnityEngine.Object) this.PersonalityData != (UnityEngine.Object) null)
        this.ApplyFaceBlendShapeData(Main.Instance.BlendShapesDatas[(int) this.PersonalityData.FaceBlendshape]);
    }
    if (!this.TheHealth.dead && !this.TheHealth.Incapacitated && !this.CinematicCharacter && this is Girl)
      ((Girl) this).BoobPhysics = true;
    if (this is Girl && (this as Girl).PhisicsOnlyOnInSex)
      (this as Girl).BoobPhysics = false;
    this.CharacterVisible = true;
    this.Penis.SetActive(this.PenisEnabled);
    this.Penis.GetComponentInChildren<Renderer>().enabled = true;
    SkinnedMeshRenderer[] componentsInChildren = this.transform.GetComponentsInChildren<SkinnedMeshRenderer>();
    for (int index = 0; index < componentsInChildren.Length; ++index)
    {
      if (!((UnityEngine.Object) componentsInChildren[index] == (UnityEngine.Object) this.MainBodyLowPoly))
      {
        componentsInChildren[index].quality = SkinQuality.Bone4;
        componentsInChildren[index].shadowCastingMode = ShadowCastingMode.On;
        componentsInChildren[index].skinnedMotionVectors = true;
      }
    }
    for (int index = 0; index < this.EquippedClothes.Count; ++index)
      this.EquippedClothes[index].SetHighLod();
    this.MainBodyLowPoly.enabled = false;
    this.MainBody.enabled = true;
    this.HiddenHead = false;
    this.RefreshColors();
    if ((UnityEngine.Object) this.CurrentFeet != (UnityEngine.Object) null)
      this.CurrentFeetMesh.enabled = true;
    for (int index = 0; index < this.CallWhenHighCol.Count; ++index)
      this.CallWhenHighCol[index]();
  }

  public virtual void SetLowLod()
  {
    if (this.DEBUG)
      Debug.LogError((object) nameof (SetLowLod));
    this.RemoveMoveBlocker("InCullLOD");
    this.CurrentLOD = 1;
    if (!this.TheHealth.dead && !this.TheHealth.Incapacitated)
      this.Anim.enabled = true;
    this.CharacterVisible = true;
    this.navMesh.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
    if ((UnityEngine.Object) this.Eyes != (UnityEngine.Object) null)
      this.Eyes.Quality = Vision.VisionQuality.Low;
    this.LookAtPlayer.enabled = false;
    this.Penis.SetActive(false);
    this.MainBody.enabled = false;
    this.MainBodyLowPoly.enabled = true;
    if (this is Girl)
    {
      if (!this.TheHealth.dead && !this.TheHealth.Incapacitated)
        ((Girl) this).GirlPhysics = false;
      else
        ((Girl) this).ResetPhysicsPos();
    }
    SkinnedMeshRenderer[] componentsInChildren = this.transform.GetComponentsInChildren<SkinnedMeshRenderer>();
    for (int index = 0; index < componentsInChildren.Length; ++index)
    {
      if (!((UnityEngine.Object) componentsInChildren[index] == (UnityEngine.Object) this.MainBodyLowPoly))
      {
        componentsInChildren[index].quality = SkinQuality.Bone1;
        componentsInChildren[index].shadowCastingMode = ShadowCastingMode.Off;
        componentsInChildren[index].skinnedMotionVectors = false;
      }
    }
    for (int index = 0; index < this.EquippedClothes.Count; ++index)
      this.EquippedClothes[index].SetLowLod();
    this.MainBodyLowPoly.shadowCastingMode = ShadowCastingMode.On;
    if (!((UnityEngine.Object) this.CurrentFeet != (UnityEngine.Object) null))
      return;
    this.CurrentFeetMesh.enabled = false;
  }

  public virtual void SetCullLod(bool fullCull = false)
  {
    if (this.DEBUG)
      Debug.LogError((object) nameof (SetCullLod));
    if (this.Name.Length == 0)
    {
      Debug.LogError((object) "SetCullLod on nameless");
    }
    else
    {
      this.CurrentLOD = 0;
      this.Anim.enabled = false;
      this.CharacterVisible = false;
      this.LookAtPlayer.enabled = false;
      this.Penis.SetActive(false);
      if (this is Girl)
      {
        if (!this.TheHealth.dead && !this.TheHealth.Incapacitated)
          ((Girl) this).GirlPhysics = false;
        else
          ((Girl) this).ResetPhysicsPos();
      }
      this.MainBody.enabled = false;
      if (fullCull)
      {
        this.MainBodyLowPoly.enabled = false;
      }
      else
      {
        this.MainBodyLowPoly.enabled = true;
        this.MainBodyLowPoly.shadowCastingMode = ShadowCastingMode.ShadowsOnly;
      }
      this.navMesh.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
      if ((double) Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.z), new Vector2(Main.Instance.Player.transform.position.x, Main.Instance.Player.transform.position.z)) > 25.0 && this.State == Person_State.Free && this.CurrentScheduleTask != null && !this.CurrentScheduleTask.KeepPathEnabled)
        this.AddMoveBlocker("InCullLOD");
      if ((UnityEngine.Object) this.Eyes != (UnityEngine.Object) null)
        this.Eyes.Quality = Vision.VisionQuality.None;
      if (!((UnityEngine.Object) this.CurrentFeet != (UnityEngine.Object) null))
        return;
      this.CurrentFeetMesh.enabled = false;
    }
  }

  public bool DirtySkin
  {
    get => this._DirtySkin;
    set
    {
      this._DirtySkin = value;
      this.States[0] = this._DirtySkin;
      this.SetBodyTexture();
      if (!value)
        return;
      this._TimesHadSexClean = 0;
    }
  }

  public virtual void SetBodyTexture()
  {
    this.MainBodyTex = Main.Instance.Tex_BodySkin[0];
    this.States = this.States;
    this.sBodyTexIndex = string.Join(string.Empty, ((IEnumerable<bool>) this._SkinStates).Select<bool, string>((Func<bool, string>) (b => !b ? "0" : "1")));
    Texture2D texture2D1;
    Main.Instance.TexBody_Container2.TryGetValue(this.sBodyTexIndex, out texture2D1);
    if ((UnityEngine.Object) texture2D1 != (UnityEngine.Object) null)
    {
      this.MainBodyTex = texture2D1;
    }
    else
    {
      if (this.States[20])
        this.MainBodyTex = Main.MergeTextures(this.MainBodyTex, Main.Instance.Tex_BodySkin[12]);
      if (this.States[21])
        this.MainBodyTex = Main.MergeTextures(this.MainBodyTex, Main.Instance.Tex_BodySkin[13]);
      if (this.States[17])
        this.MainBodyTex = Main.MergeTextures(this.MainBodyTex, Main.Instance.Tex_BodySkin[4]);
      if (this.States[18])
        this.MainBodyTex = Main.MergeTextures(this.MainBodyTex, Main.Instance.Tex_BodySkin[5]);
      if (this.States[19])
        this.MainBodyTex = Main.MergeTextures(this.MainBodyTex, Main.Instance.Tex_BodySkin[6]);
      if (this.States[2])
        this.MainBodyTex = Main.MergeTextures(this.MainBodyTex, Main.Instance.Tex_BodySkin[2]);
      else if (this.States[0])
        this.MainBodyTex = Main.MergeTextures(this.MainBodyTex, Main.Instance.Tex_BodySkin[1]);
      if (this.States[3])
        this.MainBodyTex = Main.MergeTextures(this.MainBodyTex, Main.Instance.Tex_BodySkin[3]);
      if (this.States[12])
        this.MainBodyTex = Main.MergeTextures(this.MainBodyTex, Main.Instance.Tex_BodySkin[7]);
      if (this.States[13])
        this.MainBodyTex = Main.MergeTextures(this.MainBodyTex, Main.Instance.Tex_BodySkin[8]);
      if (this.States[14])
        this.MainBodyTex = Main.MergeTextures(this.MainBodyTex, Main.Instance.Tex_BodySkin[9]);
      if (this.States[15])
        this.MainBodyTex = Main.MergeTextures(this.MainBodyTex, Main.Instance.Tex_BodySkin[10]);
      if (this.States[16 /*0x10*/])
        this.MainBodyTex = Main.MergeTextures(this.MainBodyTex, Main.Instance.Tex_BodySkin[11]);
      Main.Instance.TexBody_Container2.TryAdd(this.sBodyTexIndex, this.MainBodyTex);
    }
    this.MainBody.materials[0].SetTexture("_Layer2", (Texture) this.MainBodyTex);
    if ((UnityEngine.Object) this.MainBodyLowPoly != (UnityEngine.Object) null)
      this.MainBodyLowPoly.materials[0] = this.MainBody.materials[0];
    Texture2D texture2D2;
    if (this.MainBody.materials.Length > 1 || this.MaterialTypeNPC == 1)
    {
      this.MainFaceTex = Main.Instance.Inv1k;
      this.sFaceTexIndex = string.Join(string.Empty, ((IEnumerable<bool>) this._FaceSkinStates).Select<bool, string>((Func<bool, string>) (b => !b ? "0" : "1")));
      texture2D2 = (Texture2D) null;
      Main.Instance.TexFace_Container2.TryGetValue(this.sFaceTexIndex, out texture2D2);
      if ((UnityEngine.Object) texture2D2 != (UnityEngine.Object) null)
      {
        this.MainFaceTex = texture2D2;
      }
      else
      {
        for (int index = 2; index < this._FaceSkinStates.Length; ++index)
        {
          if (this._FaceSkinStates[index])
            this.MainFaceTex = Main.MergeTextures(this.MainFaceTex, Main.Instance.Tex_FaceSkin[index]);
        }
        Main.Instance.TexFace_Container2.TryAdd(this.sFaceTexIndex, this.MainFaceTex);
      }
      if (this.MaterialTypeNPC == 1)
      {
        this.transform.Find("SkinnedMeshContainer/o_head").GetComponent<SkinnedMeshRenderer>().material.SetTexture("_Layer2", (Texture) this.MainFaceTex);
      }
      else
      {
        this.MainBody.materials[1].SetTexture("_Layer2", (Texture) this.MainFaceTex);
        if ((UnityEngine.Object) this.MainBodyLowPoly != (UnityEngine.Object) null)
          this.MainBodyLowPoly.materials[1] = this.MainBody.materials[1];
      }
    }
    if ((UnityEngine.Object) this.CurrentFeet != (UnityEngine.Object) null)
      this.CurrentFeetMesh.material = this.MainBody.material;
    this.sCustomBodyTexIndex = string.Empty;
    for (int index = 0; index < this._CustomSkinStates.Length; ++index)
    {
      if (this._CustomSkinStates[index])
      {
        if (!string.IsNullOrEmpty(this.sCustomBodyTexIndex))
          this.sCustomBodyTexIndex += ":";
        this.sCustomBodyTexIndex += Main.Instance._CustomBodySkinsName[index];
      }
    }
    texture2D2 = (Texture2D) null;
    Main.Instance.TexBody_ContainerCustom.TryGetValue(this.sCustomBodyTexIndex, out texture2D2);
    if ((UnityEngine.Object) texture2D2 != (UnityEngine.Object) null)
    {
      this.CustomMainBodyTex = texture2D2;
    }
    else
    {
      this.CustomMainBodyTex = Main.Instance.Tex_BodySkin[16 /*0x10*/];
      for (int index = 0; index < this._CustomSkinStates.Length; ++index)
      {
        if (this._CustomSkinStates[index])
          this.CustomMainBodyTex = Main.MergeTextures(this.CustomMainBodyTex, Main.Instance._CustomBodySkins[index]);
      }
      Main.Instance.TexBody_ContainerCustom.TryAdd(this.sCustomBodyTexIndex, this.CustomMainBodyTex);
    }
    if ((UnityEngine.Object) this.CustomMainBodyTex != (UnityEngine.Object) null)
      this.MainBody.materials[0].SetTexture("_Layer1", (Texture) this.CustomMainBodyTex);
    else
      this.MainBody.materials[0].SetTexture("_Layer1", (Texture) Main.Instance.Tex_BodySkin[16 /*0x10*/]);
    this.sCustomFaceTexIndex = string.Empty;
    for (int index = 0; index < this._CustomFaceSkinStates.Length; ++index)
    {
      if (this._CustomFaceSkinStates[index])
      {
        if (!string.IsNullOrEmpty(this.sCustomFaceTexIndex))
          this.sCustomFaceTexIndex += ":";
        this.sCustomFaceTexIndex += Main.Instance._CustomFaceSkinsName[index];
      }
    }
    texture2D2 = (Texture2D) null;
    Main.Instance.TexFace_ContainerCustom.TryGetValue(this.sCustomFaceTexIndex, out texture2D2);
    if ((UnityEngine.Object) texture2D2 != (UnityEngine.Object) null)
    {
      this.CustomMainFaceTex = texture2D2;
    }
    else
    {
      this.CustomMainFaceTex = Main.Instance.Inv1k;
      for (int index = 0; index < this._CustomFaceSkinStates.Length; ++index)
      {
        if (this._CustomFaceSkinStates[index])
          this.CustomMainFaceTex = Main.MergeTextures(this.CustomMainFaceTex, Main.Instance._CustomFaceSkins[index]);
      }
      Main.Instance.TexFace_ContainerCustom.TryAdd(this.sCustomFaceTexIndex, this.CustomMainFaceTex);
    }
    if (this.MainBody.materials.Length > 1 || this.MaterialTypeNPC == 1)
    {
      if (this.MaterialTypeNPC == 1)
      {
        if ((UnityEngine.Object) this.CustomMainFaceTex != (UnityEngine.Object) null)
          this.transform.Find("SkinnedMeshContainer/o_head").GetComponent<SkinnedMeshRenderer>().material.SetTexture("_Layer1", (Texture) this.CustomMainFaceTex);
        else
          this.transform.Find("SkinnedMeshContainer/o_head").GetComponent<SkinnedMeshRenderer>().material.SetTexture("_Layer1", (Texture) Main.Instance.Inv1k);
        if (this.States[22])
          this.transform.Find("SkinnedMeshContainer/o_head").GetComponent<SkinnedMeshRenderer>().material.mainTexture = (Texture) Main.Instance.Tex_FaceSkin[1];
        else
          this.transform.Find("SkinnedMeshContainer/o_head").GetComponent<SkinnedMeshRenderer>().material.mainTexture = (Texture) Main.Instance.Tex_FaceSkin[0];
      }
      else
      {
        if ((UnityEngine.Object) this.CustomMainFaceTex != (UnityEngine.Object) null)
          this.MainBody.materials[1].SetTexture("_Layer1", (Texture) this.CustomMainFaceTex);
        else
          this.MainBody.materials[1].SetTexture("_Layer1", (Texture) Main.Instance.Inv1k);
        if (this.States[22])
          this.MainBody.materials[1].mainTexture = (Texture) Main.Instance.Tex_FaceSkin[1];
        else
          this.MainBody.materials[1].mainTexture = (Texture) Main.Instance.Tex_FaceSkin[0];
      }
    }
    Main.Instance.Player.RefreshColors();
  }

  public void Punch(Person person)
  {
    this.Doing_Punch = true;
    this.enabled = false;
    this.AddMoveBlocker("Punching");
    this.PunchingAnim = (double) UnityEngine.Random.Range(0.0f, 1f) > 0.5 ? "punch_20" : "punch_21";
    this.Anim.Play(this.PunchingAnim);
    if ((UnityEngine.Object) this.ThisPersonInt != (UnityEngine.Object) null)
      this.ThisPersonInt.AddBlocker("Punching");
    Main.Instance.MainThreads.Add(new Action(this.Punching));
    this.PersonAudio.PlayOneShot(Main.Instance.PunchMissSounds[UnityEngine.Random.Range(0, Main.Instance.PunchMissSounds.Length)]);
    if ((UnityEngine.Object) person != (UnityEngine.Object) null)
    {
      this._CurrentPunchPower = 10f;
      this._personPunching = person;
      int thisType = (int) person.PersonType.ThisType;
    }
    else
    {
      this._personPunching = (Person) null;
      if (!this.IsPlayer)
        return;
      this.MeleeHitBox.SetActive(true);
    }
  }

  public void MeleeHit(Person person)
  {
    this.Doing_MeleeHit = true;
    this.enabled = false;
    this.AddMoveBlocker("Punching");
    this.PunchingAnim = (double) UnityEngine.Random.Range(0.0f, 1f) > 0.5 ? "MeleeAttackSwing" : "MeleeAttackSwing";
    this.Anim.Play(this.PunchingAnim);
    if ((UnityEngine.Object) this.ThisPersonInt != (UnityEngine.Object) null)
      this.ThisPersonInt.AddBlocker("Punching");
    Main.Instance.MainThreads.Add(new Action(this.Punching));
    this.PersonAudio.PlayOneShot(Main.Instance.PunchMissSounds[UnityEngine.Random.Range(0, Main.Instance.PunchMissSounds.Length)]);
    if ((UnityEngine.Object) person != (UnityEngine.Object) null)
    {
      this._CurrentPunchPower = this.WeaponInv.CurrentWeapon.power;
      this._personPunching = person;
      int thisType = (int) person.PersonType.ThisType;
    }
    else
    {
      this._personPunching = (Person) null;
      if (!this.IsPlayer)
        return;
      this.MeleeHitBox.SetActive(true);
    }
  }

  public void ThrowDown(Person person)
  {
    int num = this.IsPlayer ? 1 : 0;
    this.enabled = false;
    this.AddMoveBlocker("ThrowDowning");
    this.Anim.Play("jump_13_b");
    if ((UnityEngine.Object) this.ThisPersonInt != (UnityEngine.Object) null)
      this.ThisPersonInt.AddBlocker("ThrowDowning");
    if (!this.Doing_ThrowDown)
      Main.Instance.MainThreads.Add(new Action(this.ThrowDowning));
    this.Doing_ThrowDown = true;
    this.PersonThrowingDown = person;
    if ((UnityEngine.Object) person != (UnityEngine.Object) null)
    {
      this.PersonAudio.PlayOneShot(Main.Instance.PunchSounds[UnityEngine.Random.Range(0, Main.Instance.PunchSounds.Length)]);
    }
    else
    {
      this._personPunching = (Person) null;
      this.PersonAudio.PlayOneShot(Main.Instance.PunchMissSounds[UnityEngine.Random.Range(0, Main.Instance.PunchMissSounds.Length)]);
      if (!this.IsPlayer)
        return;
      this.MeleeHitBox.SetActive(true);
    }
  }

  public void Punching()
  {
    if (this.IsPlayer)
    {
      float normalizedTime = this.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
      Main.Instance.GameplayMenu.MeleeOptionSlider.fillAmount = normalizedTime;
    }
    if ((UnityEngine.Object) this._personPunching != (UnityEngine.Object) null && !this._Punched && (!this.Anim.GetCurrentAnimatorStateInfo(0).IsName(this.PunchingAnim) || (double) this.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.20000000298023224))
    {
      this._Punched = true;
      if ((UnityEngine.Object) this.WeaponInv.CurrentWeapon != (UnityEngine.Object) null)
      {
        if ((UnityEngine.Object) this.UserControl == (UnityEngine.Object) null)
          this._personPunching.TheHealth.ChangeHealth(-this._CurrentPunchPower, false, this);
        else
          this._personPunching.TheHealth.ChangeHealth(-this._CurrentPunchPower, this.UserControl.MeleeWeaponOption == bl_ThirdPersonUserControl.MeleeWeaponOptions.Kill, this);
      }
      else
        this._personPunching.TheHealth.ChangeHealth(-this._CurrentPunchPower, false, this);
      this.PersonAudio.PlayOneShot(Main.Instance.PunchSounds[UnityEngine.Random.Range(0, Main.Instance.PunchSounds.Length)]);
    }
    if (this.Anim.GetCurrentAnimatorStateInfo(0).IsName(this.PunchingAnim) && (double) this.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0)
      return;
    this.enabled = true;
    this.RemoveMoveBlocker(nameof (Punching));
    if ((UnityEngine.Object) this.ThisPersonInt != (UnityEngine.Object) null)
      this.ThisPersonInt.RemoveBlocker(nameof (Punching));
    Main.Instance.MainThreads.Remove(new Action(this.Punching));
    this._personPunching = (Person) null;
    this._Punched = false;
    this.Doing_Punch = false;
    this.Doing_MeleeHit = false;
    this.Doing_ThrowDown = false;
    Main.RunInSeconds((Action) (() =>
    {
      this.RemoveAllTempAggroToFlagger("OnSeeAttack");
      for (int index1 = 0; index1 < 10; ++index1)
      {
        for (int index2 = 0; index2 < Main.Instance.SpawnedPeopleOfType[index1].Count; ++index2)
          Main.Instance.SpawnedPeopleOfType[index1][index2].Eyes.RemoveFlagger("OnSeeAttack");
      }
    }), 5f);
  }

  public void ThrowDowning()
  {
    if (this.IsPlayer)
    {
      float normalizedTime = this.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
      Main.Instance.GameplayMenu.MeleeOptionSlider.fillAmount = normalizedTime;
    }
    if (this.Anim.GetCurrentAnimatorStateInfo(0).IsName("jump_13_b") && (double) this.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0)
      return;
    this.enabled = true;
    this.RemoveMoveBlocker(nameof (ThrowDowning));
    if ((UnityEngine.Object) this.ThisPersonInt != (UnityEngine.Object) null)
      this.ThisPersonInt.RemoveBlocker(nameof (ThrowDowning));
    Main.Instance.MainThreads.Remove(new Action(this.ThrowDowning));
    this.Doing_Punch = false;
    this.Doing_MeleeHit = false;
    this.Doing_ThrowDown = false;
    if (!((UnityEngine.Object) this.PersonThrowingDown != (UnityEngine.Object) null) || this.PersonThrowingDown._IsSleeping)
      return;
    if (this.PersonThrowingDown.Personality == Personality_Type.Nympho || this.PersonThrowingDown.Personality == Personality_Type.Crazy || this.PersonThrowingDown.Personality == Personality_Type.Broken || this.PersonThrowingDown.Personality == Personality_Type.Aggressive || this.PersonThrowingDown.Fetishes.Contains(e_Fetish.Masochist))
      this.PersonThrowingDown.Favor += 10;
    else
      this.PersonThrowingDown.Favor -= 50;
    if (this.PersonThrowingDown.CantBeForced)
      this.PersonThrowingDown.StartFighting(this);
    else
      (!this.HasPenis ? (!this.PersonThrowingDown.HasPenis ? Main.Instance.SexScene.SpawnSexScene(4, 0, this, this.PersonThrowingDown, playerForcing: true) : Main.Instance.SexScene.SpawnSexScene(4, 4, this.PersonThrowingDown, this, playerForcing: true)) : Main.Instance.SexScene.SpawnSexScene(4, 0, this, this.PersonThrowingDown, playerForcing: true)).OnSexEnd = (Action) (() =>
      {
        switch (UnityEngine.Random.Range(0, 6))
        {
          case 1:
            this.PersonThrowingDown.States[12] = true;
            break;
          case 2:
            this.PersonThrowingDown.States[13] = true;
            break;
          case 3:
            this.PersonThrowingDown.States[14] = true;
            break;
          case 4:
            this.PersonThrowingDown.States[15] = true;
            break;
          case 5:
            this.PersonThrowingDown.States[16 /*0x10*/] = true;
            break;
        }
        if ((double) this.Energy < 5.0)
        {
          this.SleepOnFloor();
        }
        else
        {
          if (this.PersonThrowingDown.Favor >= 0)
            return;
          switch (this.PersonThrowingDown.Personality)
          {
            case Personality_Type.Casual:
            case Personality_Type.Motherly:
            case Personality_Type.Aggressive:
            case Personality_Type.Tsundere:
            case Personality_Type.Yandere:
              this.PersonThrowingDown.StartFighting(this);
              break;
            default:
              Transform transform = this.transform;
              if ((UnityEngine.Object) this.Home != (UnityEngine.Object) null && this.Home.SexSpots != null && this.Home.SexSpots.Count > 0)
                transform = this.Home.SexSpots[UnityEngine.Random.Range(0, this.Home.SexSpots.Count)];
              else if ((UnityEngine.Object) this.CurrentZone != (UnityEngine.Object) null && this.CurrentZone.SexSpots != null && this.CurrentZone.SexSpots.Count > 0)
                transform = this.CurrentZone.SexSpots[UnityEngine.Random.Range(0, this.CurrentZone.SexSpots.Count)];
              else if ((UnityEngine.Object) this.Home != (UnityEngine.Object) null && (UnityEngine.Object) this.Home.Location != (UnityEngine.Object) null)
                transform = this.Home.Location;
              else if ((UnityEngine.Object) this.CurrentZone != (UnityEngine.Object) null && (UnityEngine.Object) this.CurrentZone.Location != (UnityEngine.Object) null)
                transform = this.CurrentZone.Location;
              this.PersonThrowingDown.StartScheduleTask(new Person.ScheduleTask()
              {
                IDName = "escape",
                ActionPlace = transform,
                RunTo = true
              });
              break;
          }
        }
      });
  }

  public void Kick(Person person)
  {
    this.enabled = false;
    this.AddMoveBlocker("Kicking");
    this.Anim.Play("kick_20");
    if ((UnityEngine.Object) this.ThisPersonInt != (UnityEngine.Object) null)
      this.ThisPersonInt.AddBlocker("Kicking");
    Main.Instance.MainThreads.Add(new Action(this.Kicking));
    this.PersonAudio.PlayOneShot(Main.Instance.PunchMissSounds[UnityEngine.Random.Range(0, Main.Instance.PunchMissSounds.Length)]);
    if (!((UnityEngine.Object) person != (UnityEngine.Object) null))
      return;
    this.transform.LookAt(person.transform);
    person.TheHealth.ChangeHealth(-10f, false, this);
  }

  public void Kicking()
  {
    if (this.IsPlayer)
    {
      float normalizedTime = this.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
      Main.Instance.GameplayMenu.MeleeOptionSlider.fillAmount = normalizedTime;
    }
    if (this.Anim.GetCurrentAnimatorStateInfo(0).IsName("kick_20") && (double) this.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0)
      return;
    this.enabled = true;
    this.RemoveMoveBlocker(nameof (Kicking));
    if ((UnityEngine.Object) this.ThisPersonInt != (UnityEngine.Object) null)
      this.ThisPersonInt.RemoveBlocker(nameof (Kicking));
    Main.Instance.MainThreads.Remove(new Action(this.Kicking));
  }

  public void OnWeaponFire(Person hitTarget)
  {
  }

  public void ApplyFaceBlendShapeData(PersonBlendShapeData shapes, bool isOverwriteCall = false)
  {
    for (int index1 = 0; index1 < shapes.Shapes.Count; ++index1)
    {
      this.BlendShape(shapes.Shapes[index1].Name, shapes.Shapes[index1].Value);
      for (int index2 = 0; index2 < shapes.Shapes[index1].NameInOtherBodies.Count; ++index2)
        this.BlendShape(shapes.Shapes[index1].NameInOtherBodies[index2], shapes.Shapes[index1].Value);
    }
    if (isOverwriteCall)
      return;
    for (int index = 0; index < this.EquippedClothes.Count; ++index)
    {
      if ((UnityEngine.Object) this.EquippedClothes[index] != (UnityEngine.Object) null)
        this.EquippedClothes[index].RefreshShapeWhileEquipped();
    }
  }

  public void RemoveBlendShapeData(PersonBlendShapeData shapes)
  {
    for (int index1 = 0; index1 < shapes.Shapes.Count; ++index1)
    {
      this.BlendShape(shapes.Shapes[index1].Name, 0.0f);
      for (int index2 = 0; index2 < shapes.Shapes[index1].NameInOtherBodies.Count; ++index2)
        this.BlendShape(shapes.Shapes[index1].NameInOtherBodies[index2], 0.0f);
    }
  }

  public void TurnTowards(Transform target)
  {
    this.turning_target = target;
    Vector3 vector3 = target.position - this.transform.position;
    double num = (double) Vector3.Angle(vector3, this.transform.forward);
    if ((double) Vector3.Cross(this.transform.forward, vector3).y < 0.0)
      this.Anim.Play("StandQuarterTurnRight");
    else
      this.Anim.Play("StandQuarterTurnLeft");
    this.turning_targetRotation = Quaternion.LookRotation(vector3);
    this.AddMoveBlocker("Turning");
    this.enabled = false;
    Main.Instance.MainThreads.Add(new Action(this.TurningTowardsTarget));
  }

  public void TurningTowardsTarget()
  {
    this.transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(this.transform.forward, this.turning_target.position - this.transform.position, 1f * Time.deltaTime, 0.0f));
    if ((double) Quaternion.Angle(this.transform.rotation, this.turning_targetRotation) >= 0.0099999997764825821)
      return;
    Main.Instance.MainThreads.Remove(new Action(this.TurningTowardsTarget));
    this.RemoveMoveBlocker("Turning");
    this.enabled = true;
  }

  public void GetClothingCondition()
  {
    if (!this.IsPlayer)
      return;
    int num1 = 0;
    int num2 = 0;
    for (int index = 0; index < this.EquippedClothes.Count; ++index)
    {
      num1 += this.EquippedClothes[index].CasualPoints;
      num2 += this.EquippedClothes[index].SexyPoints;
    }
    e_ClothingCondition clothingCondition1 = num1 + num2 >= 2 ? (num1 <= num2 ? e_ClothingCondition.Sexy : e_ClothingCondition.Casual) : e_ClothingCondition.Nude;
    e_ClothingCondition clothingCondition2 = this.ClothingCondition;
    this.ClothingCondition = clothingCondition1;
    this.States[9] = false;
    this.States[10] = false;
    this.States[11] = false;
    switch (this.ClothingCondition)
    {
      case e_ClothingCondition.Nude:
        this.States[9] = true;
        if (clothingCondition2 == this.ClothingCondition)
          break;
        Main.Instance.Player.ProxSeen.AddEnabler("Nude");
        if (!this.IsPlayer)
          break;
        Main.Instance.GameplayMenu.ShowNotification("You are now dressed: Nude (danger)");
        break;
      case e_ClothingCondition.Casual:
        this.States[10] = true;
        if (clothingCondition2 == this.ClothingCondition)
          break;
        Main.Instance.Player.ProxSeen.RemoveEnabler("Nude");
        if (!this.IsPlayer)
          break;
        Main.Instance.GameplayMenu.ShowNotification("You are now dressed: Casual");
        break;
      case e_ClothingCondition.Sexy:
        this.States[11] = true;
        if (clothingCondition2 == this.ClothingCondition)
          break;
        Main.Instance.Player.ProxSeen.RemoveEnabler("Nude");
        if (!this.IsPlayer)
          break;
        Main.Instance.GameplayMenu.ShowNotification("You are now dressed: Sexy");
        break;
    }
  }

  [Serializable]
  public class TempAggroStruct
  {
    public Person_Type TheType;
    public string Flagger;
    public bool Melee;
  }

  public enum BodyMaterials
  {
    Body,
    Head,
    EyePupil,
    EyeBack,
    Lash,
    Thong,
    Teeth,
  }

  public enum BodyMaleMaterials
  {
    Thong,
    Head,
    Feet,
    Hands,
    Torso,
    Legs,
    EyeBack,
    EyePupil,
  }

  public enum BodyMale2Materials
  {
    Body,
    Teeth,
    Head,
    Lash,
    Thong,
    Teeth2,
  }

  public enum EyesMale2Materials
  {
    Back,
    Pupil,
  }

  [Serializable]
  public class BL_State
  {
    public string Name;
    public string Effect;
  }

  public enum StatesEnum
  {
    Dirty,
    Horny,
    VeryDirty,
    Shitten,
    Sleepy,
    NeedsToilet,
    Hungry,
    Pregnant,
    Bloody,
    ClothingVibe_Nude,
    ClothingVibe_Casual,
    ClothingVibe_Sexy,
    cum1,
    cum2,
    cum3,
    cum4,
    cum5,
    BodyWritten1,
    BodyWritten2,
    BodyWritten3,
    Bruises1,
    Bruises2,
    FemaleMakeup,
    RunnyMakeup1,
    RunnyMakeup2,
    RunnyMakeup3,
    CumMouth,
    Beard,
    Lipstick1,
    Lipstick2,
    Lipstick3,
    Lipstick4,
    Freckels,
    ScatMouth,
    Max,
  }

  public class SphereTrigger : MonoBehaviour
  {
    public List<Weapon> weaponsInRange = new List<Weapon>();
    public Weapon ClosestWeapon;
    public Person ThisPerson;

    public void OnTriggerEnter(Collider other)
    {
      Weapon component = other.transform.root.GetComponent<Weapon>();
      if (!((UnityEngine.Object) component != (UnityEngine.Object) null))
        return;
      this.weaponsInRange.Add(component);
    }

    public void GetClosestWeapon()
    {
      float num1 = float.PositiveInfinity;
      this.ClosestWeapon = (Weapon) null;
      foreach (Weapon weapon in this.weaponsInRange)
      {
        if (!weapon.PickedUp)
        {
          float num2 = Vector3.Distance(this.transform.position, weapon.transform.position);
          if ((double) num2 < (double) num1)
          {
            num1 = num2;
            this.ClosestWeapon = weapon;
          }
        }
      }
      this.ThisPerson.FoundClosestWeapon(this.ClosestWeapon);
      UnityEngine.Object.Destroy((UnityEngine.Object) this.gameObject);
    }
  }

  [Serializable]
  public class ScheduleTask
  {
    public string IDName;
    public float FixedTimeStart;
    public float FixedTimeEnd;
    public bool CanBeInterrupted;
    public bool KeepPathEnabled;
    public float AutoStop;
    public int State;
    public bool RunTo;
    public Transform ActionPlace;
    public Action OnInterrupt_BeforeStart;
    public Action OnStartGoing;
    public Action WhileGoing;
    public Action OnInterrupt_WhileGoing;
    public Action OnArrive;
    public Action WhileDoing;
    public Action OnInterrupt_WhileDoing;
    public Action OnFinish;
    public Func<bool> _CanStart;

    public bool CanStart()
    {
      if (this.IDName == null || this.IDName.Length == 0)
      {
        Debug.LogError((object) "Null Task Somehow Added");
        return false;
      }
      if ((double) this.FixedTimeStart != 0.0)
      {
        if ((double) Main.Instance.DayCycle.timeOfDay < (double) this.FixedTimeStart)
          return false;
        return this._CanStart == null || this._CanStart();
      }
      return this._CanStart == null || this._CanStart();
    }
  }

  public enum e_FaceTextures
  {
    MainEmpty,
    Makeup,
    Beard,
    Freckels,
    Lipstick4,
    Lipstick1,
    Lipstick3,
    Lipstick2,
    WhoreTat,
    Dirty,
    Scat,
    Cum,
    RunnyMakeup1,
    RunnyMakeup2,
    RunnyMakeup3,
    Bloody,
    Max,
  }

  public enum e_BodyTextures
  {
    Main,
    Dirty,
    VeryDirty,
    Splatter1,
    Writting1,
    Writting2,
    Writting3,
    Cum1,
    Cum2,
    Cum3,
    Cum4,
    Cum5,
    Bruises1,
    Bruises2,
    GooSplatter,
    Max,
  }
}
