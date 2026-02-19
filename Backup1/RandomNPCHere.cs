// Decompiled with JetBrains decompiler
// Type: RandomNPCHere
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

#nullable disable
public class RandomNPCHere : MonoBehaviour
{
  public string PersonSaveID;
  public int BuildVersionAdded;
  public bool Add_DontSaveInMain;
  public static List<bl_HangZone> _PossibleHomes;
  public bool DestroyOnCreate = true;
  public Person PersonGenerated;
  public bool WithoutClothing;
  public bool WithoutWeapon;
  public bool NoUglyHair;
  public bool OnlyGoodHair;
  public bool SpawnClean;
  public Person_Type TypeToSet = Person_Type.Max;
  public List<string> AddRunawayBlockers = new List<string>();
  public Person_State StartingState;
  public bool AddHome;
  public bl_HangZone SpecificHome;
  public bl_WorkJobManager AddJob;
  public int JobIndex;
  public bl_HangZone StartingZone;
  public GameObject PersonType;
  public GameObject[] Displays;
  public bool UseCityCharacters;
  [Tooltip("Already sends Person as parameter")]
  public MonoBehaviour RunForThisPerson;
  [Tooltip("Already sends Person as parameter")]
  public string FunctionToRun;
  public bool SpawnAnyGender;
  public bool _SpawnFemale = true;
  public bool AlwaysDefinedGenderIfPossible;
  public bool DefaultSpawnFemale = true;
  public bool CantDie;
  public bool LoadSpecificNPC;
  public string NPCToLoad;
  public bool FullPath;
  public bool LoadClothes;
  public bool DontLoadInteraction;
  public List<GameObject> SpecificClothes;
  public List<GameObject> SpecificWeapons;
  public bool ExtraPerson;
  public bool DEBUG_GenderMix;
  public bool DEBUG_GenderMix2;
  public string DEBUG_LogID;

  public bool SpawnFemale
  {
    set
    {
      if (this.DEBUG_GenderMix2)
        Debug.LogError((object) (this.DEBUG_LogID + " SpawnFemale = " + value.ToString()));
      this._SpawnFemale = value;
    }
    get => this._SpawnFemale;
  }

  public void Start()
  {
    if (this.LoadSpecificNPC)
    {
      if (this.NPCToLoad.StartsWith("F_"))
        this.SpawnFemale = true;
      else if (this.NPCToLoad.StartsWith("M_"))
        this.SpawnFemale = false;
      this.PersonGenerated = this.SpawnFemale ? UnityEngine.Object.Instantiate<GameObject>(Main.Instance.PersonPrefab).GetComponent<Person>() : UnityEngine.Object.Instantiate<GameObject>(Main.Instance.PersonGuyPrefab).GetComponent<Person>();
      string filename = this.FullPath ? this.NPCToLoad : Main.AssetsFolder + "/PreSaved/" + this.NPCToLoad;
      this.PersonGenerated._DontLoadClothing = !this.LoadClothes;
      this.PersonGenerated._DontLoadInteraction = this.DontLoadInteraction;
      this.PersonGenerated.LoadFromFile(filename);
      this.PersonGenerated.transform.position = this.transform.position;
      this.PersonGenerated.transform.rotation = this.transform.rotation;
    }
    else if ((UnityEngine.Object) this.PersonGenerated == (UnityEngine.Object) null)
    {
      if (this.DEBUG_GenderMix)
        Debug.LogError((object) (this.DEBUG_LogID + " (SpawnAnyGender && AlwaysDefinedGenderIfPossible) " + (this.SpawnAnyGender && this.AlwaysDefinedGenderIfPossible).ToString()));
      if (this.SpawnAnyGender && this.AlwaysDefinedGenderIfPossible)
      {
        int num = Main.Instance.CustomizeMenu.GenderSettings.value;
        if (this.DEBUG_GenderMix)
        {
          Debug.LogError((object) (this.DEBUG_LogID + " _value " + num.ToString()));
          Debug.LogError((object) (this.DEBUG_LogID + " (_value != 2 && _value != 1) " + (num != 2 && num != 1).ToString()));
        }
        if (num != 2 && num != 1)
        {
          this.SpawnAnyGender = false;
          this.SpawnFemale = this.DefaultSpawnFemale;
        }
      }
      if (this.DEBUG_GenderMix)
      {
        Debug.LogError((object) (this.DEBUG_LogID + " SpawnFemale " + this.SpawnFemale.ToString()));
        Debug.LogError((object) (this.DEBUG_LogID + " SpawnAnyGender " + this.SpawnAnyGender.ToString()));
        Debug.LogError((object) (this.DEBUG_LogID + " Person.GenderChance " + Person.GenderChance.ToString()));
      }
      this.PersonGenerated = Person.GenerateRandom(female: this.SpawnFemale, randomgender: this.SpawnAnyGender, _DEBUG: this.DEBUG_GenderMix);
      this.PersonGenerated.transform.position = this.transform.position;
      this.PersonGenerated.transform.rotation = this.transform.rotation;
    }
    else
      this.PersonGenerated = Person.GenerateRandom(this.PersonGenerated.gameObject, this.PersonGenerated is Girl, randompartsizes: false);
    this.PersonGenerated.WorldSaveID = this.PersonSaveID;
    if (this.PersonGenerated.WorldSaveID.Length == 0)
      this.PersonGenerated.WorldSaveID = Main.GenerateRandomString(25);
    this.PersonGenerated.DontSaveInMain = this.Add_DontSaveInMain;
    this.PersonGenerated.JobIndex = this.JobIndex;
    this.PersonGenerated.SPAWN_noUglyHair = this.NoUglyHair;
    this.PersonGenerated.SPAWN_onlyGoodHair = this.OnlyGoodHair;
    this.PersonGenerated.State = this.StartingState;
    this.PersonGenerated.EscapeBlockers.AddRange((IEnumerable<string>) this.AddRunawayBlockers);
    if (this.AddHome)
    {
      if ((bool) (UnityEngine.Object) this.SpecificHome)
      {
        this.PersonGenerated.Home = this.SpecificHome;
      }
      else
      {
        if (RandomNPCHere._PossibleHomes == null || RandomNPCHere._PossibleHomes.Count == 0)
        {
          RandomNPCHere._PossibleHomes = new List<bl_HangZone>();
          RandomNPCHere._PossibleHomes.AddRange((IEnumerable<bl_HangZone>) Main.Instance.PossibleHomes);
        }
        int index = UnityEngine.Random.Range(0, RandomNPCHere._PossibleHomes.Count);
        this.PersonGenerated.Home = RandomNPCHere._PossibleHomes[index];
        RandomNPCHere._PossibleHomes.RemoveAt(index);
      }
    }
    else
      this.PersonGenerated.Home = Main.Instance.PossibleStreetHomes[UnityEngine.Random.Range(0, Main.Instance.PossibleStreetHomes.Count)];
    if ((UnityEngine.Object) this.StartingZone != (UnityEngine.Object) null)
      this.PersonGenerated.CurrentZone = this.StartingZone;
    if (this.SpecificClothes != null)
      this.PersonGenerated.StartingClothes = this.SpecificClothes;
    if (this.SpecificWeapons != null)
      this.PersonGenerated.StartingWeapons = this.SpecificWeapons;
    this.PersonGenerated.Inited = false;
    if ((UnityEngine.Object) this.PersonType == (UnityEngine.Object) null)
      this.PersonType = this.TypeToSet == Person_Type.Max ? Main.Instance.PersonTypes[0].gameObject : Main.Instance.PersonTypes[(int) this.TypeToSet].gameObject;
    this.PersonType.GetComponent<BaseType>().ApplyTo(this.PersonGenerated, !this.WithoutClothing, !this.WithoutWeapon, !this.LoadSpecificNPC, this);
    this.PersonGenerated.TheHealth.canDie = !this.CantDie;
    Main.Instance.ActionWhenNav(new Action(this.GeneratedRandom));
    this.enabled = false;
    if ((UnityEngine.Object) this.AddJob != (UnityEngine.Object) null)
      Main.Instance.ActionWhenNav((Action) (() => this.AddJob.AddWorker(this.PersonGenerated)));
    if (!this.LoadSpecificNPC)
    {
      for (int index = 0; index < Main.Instance.OnNpcGenerate.Count; ++index)
      {
        try
        {
          int num = Main.Instance.OnNpcGenerate[index](this.PersonGenerated);
        }
        catch (Exception ex)
        {
          Debug.LogError((object) (ex?.ToString() + "\n" + ex.StackTrace));
        }
      }
    }
    this.PersonGenerated.SetLowLod();
    if (this.UseCityCharacters)
      this.RunForThisPerson = (MonoBehaviour) Main.Instance.CityCharacters;
    if (!((UnityEngine.Object) this.RunForThisPerson != (UnityEngine.Object) null))
      return;
    this.RunMethod(this.RunForThisPerson, this.FunctionToRun, new object[1]
    {
      (object) this.PersonGenerated
    });
  }

  public void GeneratedRandom()
  {
    this.PersonGenerated.AddMoveBlocker("GENERATING");
    Main.Instance.MainThreads.Add(new Action(this.ResetNav));
  }

  public void ResetNav()
  {
    Main.Instance.MainThreads.Remove(new Action(this.ResetNav));
    if (!this.PersonGenerated.TheHealth.dead && !this.PersonGenerated.TheHealth.Incapacitated)
      this.PersonGenerated.RemoveMoveBlocker("GENERATING");
    if (this.DestroyOnCreate)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) this.gameObject);
    }
    else
    {
      for (int index = 0; index < this.Displays.Length; ++index)
        UnityEngine.Object.Destroy((UnityEngine.Object) this.Displays[index]);
    }
  }

  public void RunMethod(
    MonoBehaviour theScript,
    string methodName,
    object[] parameters,
    BindingFlags _flags = BindingFlags.Default)
  {
    MethodInfo methodInfo = _flags != BindingFlags.Default ? theScript.GetType().GetMethod(methodName, _flags) : theScript.GetType().GetMethod(methodName);
    if (methodInfo != (MethodInfo) null)
      methodInfo.Invoke((object) theScript, parameters);
    else
      Debug.LogError((object) ("Method \"" + methodName + "\" not found"));
  }
}
