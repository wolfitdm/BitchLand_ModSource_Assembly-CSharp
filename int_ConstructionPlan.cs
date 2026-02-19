// Decompiled with JetBrains decompiler
// Type: int_ConstructionPlan
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

#nullable disable
public class int_ConstructionPlan : Int_Storage
{
  [Header(" - Plan")]
  public bool BeingMoved;
  public bool CanNOTBuild;
  public GameObject FinalPrefab;
  public bl_CraftRecipes OwnRecipe;
  public bool PlanAnotherAfter;
  public float[] ConstructionSpotsTimers;
  public Transform[] ConstructionSpots;
  public List<Person> PeopleBuilding = new List<Person>();
  public Transform DropSpotAfterBuild;
  public float ExtraBuildHeight;
  public int_ConstructionPlan.e_BuildSnapType BuildSnapType;
  [Space]
  public MeshRenderer BuildFill;
  public float BuiltProgresspointsNeeded;
  public float FillMax;
  public float _BuiltProgress;
  public bool _AllResourcesIn;
  public bool _WasInFirstPerson;

  public bool Foundation => (double) this.ExtraBuildHeight != 0.0;

  public virtual float BuiltProgress
  {
    get => this._BuiltProgress;
    set
    {
      this._BuiltProgress = value;
      this.BuildFill.material.SetFloat("_fill", Main.POfVal(this.BuiltProgresspointsNeeded, 0.0f, value) * this.FillMax);
    }
  }

  public virtual bool AllResourcesIn
  {
    set
    {
      this._AllResourcesIn = value;
      if (value)
        this.InteractText = "Build";
      else
        this.InteractText = "Add Resources";
    }
    get => this._AllResourcesIn;
  }

  public override string[] sd_SaveData(char SlitChar = ':')
  {
    List<string> stringList = new List<string>();
    stringList.AddRange((IEnumerable<string>) base.sd_SaveData(SlitChar));
    stringList.Add(this.AllResourcesIn ? "1" : "0");
    stringList.Add(this.BuiltProgress.ToString("0.###"));
    return stringList.ToArray();
  }

  public override void sd_LoadData(string[] Data, char SlitChar = ':')
  {
    base.sd_LoadData(Data, SlitChar);
    this.AllResourcesIn = Data[this._CurrentLoadingIndex++] == "1";
    this.BuiltProgress = Main.ParseFloat(Data[this._CurrentLoadingIndex++]);
  }

  public virtual bool CanAddPersonToBuild
  {
    get => this.ConstructionSpotsTimers.Length != this.PeopleBuilding.Count;
  }

  public virtual void ResourcesCheck()
  {
    Dictionary<e_ResourceType, int> dictionary = new Dictionary<e_ResourceType, int>();
    foreach (GameObject storageItem in this.StorageItems)
    {
      int_ResourceItem componentInChildren = storageItem.GetComponentInChildren<int_ResourceItem>(true);
      if (dictionary.ContainsKey(componentInChildren.ResourceType))
        dictionary[componentInChildren.ResourceType]++;
      else
        dictionary[componentInChildren.ResourceType] = 1;
    }
    foreach (bl_RecipesNeed ingredient in this.OwnRecipe.Ingredients)
    {
      if (!dictionary.ContainsKey(ingredient.IngredientType) || dictionary[ingredient.IngredientType] < ingredient.Amount)
        return;
    }
    this.AllResourcesIn = true;
  }

  public override void Interact(Person person)
  {
    if (this.BeingMoved)
      return;
    if (this.AllResourcesIn)
    {
      if (!this.CanAddPersonToBuild)
        return;
      this.AddBuilder(person);
    }
    else if (person.IsPlayer)
    {
      Main.Instance.GameplayMenu.OnCloseContainer.Clear();
      Main.Instance.GameplayMenu.OnCloseContainer.Add((Action) (() => this.ResourcesCheck()));
      Main.Instance.GameplayMenu.OpenContainer((Int_Storage) this);
    }
    else
    {
      Dictionary<e_ResourceType, int> dictionary1 = new Dictionary<e_ResourceType, int>();
      Dictionary<e_ResourceType, int> dictionary2 = new Dictionary<e_ResourceType, int>();
      for (int index = 0; index < this.OwnRecipe.Ingredients.Length; ++index)
        dictionary1[this.OwnRecipe.Ingredients[index].IngredientType] = 0;
label_10:
      foreach (GameObject storageItem in this.StorageItems)
      {
        int_ResourceItem componentInChildren = storageItem.GetComponentInChildren<int_ResourceItem>(true);
        if (dictionary1.ContainsKey(componentInChildren.ResourceType))
          dictionary1[componentInChildren.ResourceType]++;
        else if (this.HasItem(storageItem))
        {
          this.RemoveItem(storageItem);
          goto label_10;
        }
      }
      for (int index = 0; index < this.OwnRecipe.Ingredients.Length; ++index)
        dictionary2[this.OwnRecipe.Ingredients[index].IngredientType] = this.OwnRecipe.Ingredients[index].Amount - dictionary1[this.OwnRecipe.Ingredients[index].IngredientType];
      for (int index1 = 0; index1 < this.OwnRecipe.Ingredients.Length; ++index1)
      {
        if (dictionary2[this.OwnRecipe.Ingredients[index1].IngredientType] != 0)
        {
          if (dictionary2[this.OwnRecipe.Ingredients[index1].IngredientType] < 0)
          {
            int num = -dictionary2[this.OwnRecipe.Ingredients[index1].IngredientType];
            List<GameObject> itemsOfType = this.GetItemsOfType(this.OwnRecipe.Ingredients[index1].IngredientType);
            for (int index2 = 0; index2 < num; ++index2)
              this.RemoveItem(itemsOfType[index2]);
          }
          else
          {
            Int_Storage storageWith = person.GetStorageWith(this.OwnRecipe.Ingredients[index1].IngredientType);
            if ((UnityEngine.Object) storageWith != (UnityEngine.Object) null)
            {
              List<GameObject> itemsOfType = storageWith.GetItemsOfType(this.OwnRecipe.Ingredients[index1].IngredientType);
              int num = dictionary2[this.OwnRecipe.Ingredients[index1].IngredientType] >= itemsOfType.Count ? itemsOfType.Count : dictionary2[this.OwnRecipe.Ingredients[index1].IngredientType];
              for (int index3 = 0; index3 < num; ++index3)
                storageWith.SendTo(itemsOfType[index3], (Int_Storage) this);
            }
          }
        }
      }
      this.ResourcesCheck();
    }
  }

  public virtual e_ResourceType NextRandomIngredient(out bool hasTooManyOfAny, out int amountNeeded)
  {
    Dictionary<e_ResourceType, int> dictionary1 = new Dictionary<e_ResourceType, int>();
    Dictionary<e_ResourceType, int> dictionary2 = new Dictionary<e_ResourceType, int>();
    List<e_ResourceType> list = new List<e_ResourceType>();
    hasTooManyOfAny = false;
    amountNeeded = 0;
    for (int index = 0; index < this.OwnRecipe.Ingredients.Length; ++index)
      dictionary1[this.OwnRecipe.Ingredients[index].IngredientType] = 0;
    foreach (GameObject storageItem in this.StorageItems)
    {
      int_ResourceItem componentInChildren = storageItem.GetComponentInChildren<int_ResourceItem>(true);
      if (dictionary1.ContainsKey(componentInChildren.ResourceType))
        dictionary1[componentInChildren.ResourceType]++;
      else
        hasTooManyOfAny = true;
    }
    for (int index = 0; index < this.OwnRecipe.Ingredients.Length; ++index)
    {
      dictionary2[this.OwnRecipe.Ingredients[index].IngredientType] = this.OwnRecipe.Ingredients[index].Amount - dictionary1[this.OwnRecipe.Ingredients[index].IngredientType];
      if (dictionary2[this.OwnRecipe.Ingredients[index].IngredientType] > 0)
        list.Add(this.OwnRecipe.Ingredients[index].IngredientType);
      else if (dictionary2[this.OwnRecipe.Ingredients[index].IngredientType] < 0)
        hasTooManyOfAny = true;
    }
    if (list.Count == 0)
      return e_ResourceType.None;
    Person.Shuffle<e_ResourceType>(ref list);
    amountNeeded = dictionary2[list[0]];
    return list[0];
  }

  public override void StopInteracting(Person interactingPerson)
  {
    if (this.AllResourcesIn)
      this.RemoveBuilder(interactingPerson);
    else
      Main.Instance.GameplayMenu.CloseStorage();
    base.StopInteracting(interactingPerson);
  }

  public virtual void AddBuilder(Person person)
  {
    this.PeopleBuilding.Add(person);
    Transform constructionSpot = this.ConstructionSpots[this.PeopleBuilding.Count - 1];
    person.PlaceAt(constructionSpot);
    person.transform.eulerAngles = new Vector3(0.0f, person.transform.eulerAngles.y, 0.0f);
    person.AddMoveBlocker("Building");
    person.enabled = false;
    string[] strArray = new string[14]
    {
      "Villager@Hammer-Working01_A",
      "Villager@Hammer-Working01_A",
      "Villager@Hammer-Working01_A",
      "Villager@Hammer-Working01_A",
      "Villager@Hammer-Working01_A",
      "Villager@Hammer-Working01_A",
      "1HAttack",
      "Buff",
      "NewJump",
      "SpearSwipe",
      "SpellCast",
      "Villager@Farm-Working01",
      "Villager@Gathering01",
      "Villager@Pickaxe-Mining01"
    };
    person.Anim.Play(strArray[UnityEngine.Random.Range(0, strArray.Length)]);
    this.enabled = true;
    this.BuildFill.enabled = true;
    if (person.IsPlayer)
    {
      Main.Instance.MainThreads.Add(new Action(this.StopBuildingThread));
      Main.Instance.GameplayMenu.QLeave.SetActive(true);
      Main.Instance.GameplayMenu.QLeave.transform.Find("a/Text").GetComponent<Text>().text = "Stand up";
      this._WasInFirstPerson = Main.Instance.Player.UserControl.FirstPerson;
      if (this._WasInFirstPerson)
        Main.Instance.Player.UserControl.FirstPerson = false;
    }
    if (!((UnityEngine.Object) person.WeaponInv.CurrentWeapon == (UnityEngine.Object) null))
      return;
    for (int index = 0; index < person.WeaponInv.weapons.Count; ++index)
    {
      if ((UnityEngine.Object) person.WeaponInv.weapons[index] != (UnityEngine.Object) null)
      {
        person.WeaponInv.SetActiveWeapon(index);
        break;
      }
    }
  }

  public void StopBuildingThread()
  {
    if (!Main.Instance.CancelKey())
      return;
    this.RemoveBuilder(Main.Instance.Player);
  }

  public virtual void RemoveBuilder(Person person)
  {
    this.PeopleBuilding.Remove(person);
    if (this.PeopleBuilding.Count == 0)
    {
      this.enabled = false;
      this.BuildFill.enabled = false;
    }
    person.RemoveMoveBlocker("Building");
    person.enabled = true;
    if (person.IsPlayer)
    {
      Main.Instance.GameplayMenu.QLeave.SetActive(false);
      Main.Instance.MainThreads.Remove(new Action(this.StopBuildingThread));
      if (this._WasInFirstPerson)
        Main.Instance.Player.UserControl.FirstPerson = true;
    }
    if (!((UnityEngine.Object) person.WeaponInv.CurrentWeapon != (UnityEngine.Object) null))
      return;
    person.WeaponInv.CurrentWeapon.Holdster();
  }

  public virtual void Update()
  {
    this.BuiltProgress += Time.deltaTime * (float) this.PeopleBuilding.Count;
    if ((double) this.BuiltProgress >= (double) this.BuiltProgresspointsNeeded)
    {
      this.GetBuilt();
    }
    else
    {
      for (int index = 0; index < this.ConstructionSpotsTimers.Length; ++index)
      {
        this.ConstructionSpotsTimers[index] -= Time.deltaTime;
        if ((double) this.ConstructionSpotsTimers[index] < 0.0)
        {
          this.ConstructionSpotsTimers[index] = 5f;
          if (this.PeopleBuilding.Count > index && (UnityEngine.Object) this.PeopleBuilding[index] != (UnityEngine.Object) null)
          {
            string[] strArray = new string[14]
            {
              "Villager@Hammer-Working01_A",
              "Villager@Hammer-Working01_A",
              "Villager@Hammer-Working01_A",
              "Villager@Hammer-Working01_A",
              "Villager@Hammer-Working01_A",
              "Villager@Hammer-Working01_A",
              "1HAttack",
              "Buff",
              "NewJump",
              "SpearSwipe",
              "SpellCast",
              "Villager@Farm-Working01",
              "Villager@Gathering01",
              "Villager@Pickaxe-Mining01"
            };
            this.PeopleBuilding[index].Anim.Play(strArray[UnityEngine.Random.Range(0, strArray.Length)]);
          }
        }
      }
    }
  }

  public virtual void GetBuilt()
  {
    this.enabled = false;
    List<Person> builders = new List<Person>();
    builders.AddRange((IEnumerable<Person>) this.PeopleBuilding);
    foreach (Person person in builders)
      this.RemoveBuilder(person);
    GameObject gameObject = Main.Spawn(this.FinalPrefab);
    gameObject.transform.position = this.transform.position;
    gameObject.transform.rotation = this.transform.rotation;
    gameObject.transform.localScale = this.transform.localScale;
    bl_MinableObject component = gameObject.GetComponent<bl_MinableObject>();
    if ((UnityEngine.Object) component != (UnityEngine.Object) null)
      component.OnBuilt(builders);
    UnityEngine.Object.Destroy((UnityEngine.Object) this.gameObject);
  }

  public virtual void GetPlaced()
  {
  }

  [ContextMenu("Make Buildable")]
  public void MakeBuildable()
  {
    MeshRenderer[] componentsInChildren1 = this.transform.GetComponentsInChildren<MeshRenderer>();
    for (int index = 0; index < componentsInChildren1.Length; ++index)
    {
      componentsInChildren1[index].lightProbeUsage = LightProbeUsage.Off;
      componentsInChildren1[index].reflectionProbeUsage = ReflectionProbeUsage.Off;
      componentsInChildren1[index].shadowCastingMode = ShadowCastingMode.Off;
      componentsInChildren1[index].receiveShadows = false;
    }
    Transform[] componentsInChildren2 = this.transform.GetComponentsInChildren<Transform>();
    for (int index = 0; index < componentsInChildren2.Length; ++index)
    {
      componentsInChildren2[index].gameObject.isStatic = false;
      componentsInChildren2[index].gameObject.layer = 22;
    }
    this.PrefabName = this.name;
    this.RootObj = this.gameObject.gameObject;
    Transform transform1 = new GameObject("nav").transform;
    transform1.SetParent(this.transform);
    transform1.localScale = Vector3.one;
    transform1.localPosition = Vector3.zero;
    transform1.localEulerAngles = Vector3.zero;
    this.NavMeshInteractSpot = transform1;
    this.DoDistanceCheck = false;
    Transform transform2 = new GameObject("storage").transform;
    transform2.SetParent(this.transform);
    transform2.localScale = Vector3.one;
    transform2.localPosition = Vector3.zero;
    transform2.localEulerAngles = Vector3.zero;
    this.StorageObj = transform2;
    transform2.gameObject.SetActive(false);
    this.Sound = (AudioSource) null;
    Transform transform3 = new GameObject("dropSpot").transform;
    transform3.SetParent(this.transform);
    transform3.localScale = Vector3.one;
    transform3.localPosition = Vector3.zero;
    transform3.localEulerAngles = Vector3.zero;
    this.DropSpot = transform3;
    this.DropSpotAfterBuild = transform3;
    if ((UnityEngine.Object) this.FinalPrefab != (UnityEngine.Object) null)
    {
      this.OwnRecipe.OutCome = new string[1]
      {
        this.FinalPrefab.name
      };
      this.gameObject.name = "PLAN_" + this.FinalPrefab.name;
      this.PrefabName = this.gameObject.name;
    }
    this.PlanAnotherAfter = false;
    Transform transform4 = new GameObject("cons1").transform;
    transform4.SetParent(this.transform);
    transform4.localScale = Vector3.one;
    transform4.localPosition = new Vector3(0.0f, 0.0f, 0.005f);
    transform4.localEulerAngles = new Vector3(0.0f, 180f, 0.0f);
    Transform transform5 = new GameObject("cons2").transform;
    transform5.SetParent(this.transform);
    transform5.localScale = Vector3.one;
    transform5.localPosition = new Vector3(0.005f, 0.0f, 0.0f);
    transform5.localEulerAngles = new Vector3(0.0f, 270f, 0.0f);
    Transform transform6 = new GameObject("cons3").transform;
    transform6.SetParent(this.transform);
    transform6.localScale = Vector3.one;
    transform6.localPosition = new Vector3(-0.005f, 0.0f, 0.0f);
    transform6.localEulerAngles = new Vector3(0.0f, 90f, 0.0f);
    Transform transform7 = new GameObject("cons4").transform;
    transform7.SetParent(this.transform);
    transform7.localScale = Vector3.one;
    transform7.localPosition = new Vector3(0.0f, 0.0f, -0.005f);
    transform7.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    this.ConstructionSpotsTimers = new float[4]
    {
      0.0f,
      1f,
      2f,
      3f
    };
    this.ConstructionSpots = new Transform[4]
    {
      transform4,
      transform5,
      transform6,
      transform7
    };
    this.BuildSnapType = int_ConstructionPlan.e_BuildSnapType.Disabled;
    Transform transform8 = new GameObject("fill").transform;
    transform8.SetParent(this.transform);
    transform8.localScale = Vector3.one;
    transform8.localPosition = Vector3.zero;
    transform8.localEulerAngles = Vector3.zero;
    transform8.gameObject.layer = 22;
    MeshFilter componentInChildren = this.GetComponentInChildren<MeshFilter>();
    this.GetComponentInChildren<MeshRenderer>();
    transform8.gameObject.AddComponent<MeshFilter>().sharedMesh = componentInChildren.sharedMesh;
    MeshRenderer meshRenderer = transform8.gameObject.AddComponent<MeshRenderer>();
    meshRenderer.materials = new Material[1];
    meshRenderer.shadowCastingMode = ShadowCastingMode.Off;
    meshRenderer.receiveShadows = false;
    meshRenderer.lightProbeUsage = LightProbeUsage.Off;
    meshRenderer.reflectionProbeUsage = ReflectionProbeUsage.Off;
    this.BuildFill = meshRenderer;
    this.BuildFill.enabled = false;
    this.FillMax = 1.8f;
    this.BuiltProgresspointsNeeded = 20f;
    this.enabled = false;
  }

  public enum e_BuildSnapType
  {
    Disabled,
    Floor,
    Wall,
    Window,
    Door,
    Pillar,
    MAX,
  }
}
