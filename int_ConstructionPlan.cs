// Decompiled with JetBrains decompiler
// Type: int_ConstructionPlan
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class int_ConstructionPlan : Int_Storage
{
  [Header(" - Plan")]
  public GameObject FinalPrefab;
  public bl_CraftRecipes OwnRecipe;
  public float[] ConstructionSpotsTimers;
  public Transform[] ConstructionSpots;
  public List<Person> PeopleBuilding = new List<Person>();
  public Transform DropSpotAfterBuild;
  [Space]
  public MeshRenderer BuildFill;
  public float BuiltProgresspointsNeeded;
  public float FillMax;
  public float _BuiltProgress;
  public bool _AllResourcesIn;

  public float BuiltProgress
  {
    get => this._BuiltProgress;
    set
    {
      this._BuiltProgress = value;
      this.BuildFill.material.SetFloat("_fill", Main.POfVal(this.BuiltProgresspointsNeeded, 0.0f, value) * this.FillMax);
    }
  }

  public bool AllResourcesIn
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

  public bool CanAddPersonToBuild => this.ConstructionSpots.Length != this.PeopleBuilding.Count;

  public void ResourcesCheck()
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
    if (this.AllResourcesIn)
    {
      if (this.PeopleBuilding.Count == this.ConstructionSpots.Length)
        return;
      this.AddBuilder(person);
    }
    else
    {
      Main.Instance.GameplayMenu.OnCloseContainer.Clear();
      Main.Instance.GameplayMenu.OnCloseContainer.Add((Action) (() => this.ResourcesCheck()));
      Main.Instance.GameplayMenu.OpenContainer((Int_Storage) this);
    }
  }

  public override void StopInteracting(Person interactingPerson)
  {
    if (this.AllResourcesIn)
      this.RemoveBuilder(interactingPerson);
    else
      Main.Instance.GameplayMenu.CloseStorage();
    base.StopInteracting(interactingPerson);
  }

  public void AddBuilder(Person person)
  {
    this.PeopleBuilding.Add(person);
    Transform constructionSpot = this.ConstructionSpots[this.PeopleBuilding.Count - 1];
    person.PlaceAt(constructionSpot);
    person.AddMoveBlocker("Building");
    person.enabled = false;
    person.Anim.Play("Villager@Hammer-Working01_A");
    this.enabled = true;
    if (!person.IsPlayer)
      return;
    Main.Instance.MainThreads.Add(new Action(this.StopBuildingThread));
    Main.Instance.GameplayMenu.QLeave.SetActive(true);
    Main.Instance.GameplayMenu.QLeave.transform.Find("a/Text").GetComponent<Text>().text = "Stand up";
  }

  public void StopBuildingThread()
  {
    if (!Main.Instance.CancelKey())
      return;
    this.RemoveBuilder(Main.Instance.Player);
  }

  public void RemoveBuilder(Person person)
  {
    this.PeopleBuilding.Remove(person);
    if (this.PeopleBuilding.Count == 0)
      this.enabled = false;
    person.RemoveMoveBlocker("Building");
    person.enabled = true;
    if (!person.IsPlayer)
      return;
    Main.Instance.GameplayMenu.QLeave.SetActive(false);
    Main.Instance.MainThreads.Remove(new Action(this.StopBuildingThread));
  }

  public void Update()
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
            this.PeopleBuilding[index].Anim.Play("Villager@Hammer-Working01_A");
        }
      }
    }
  }

  public void GetBuilt()
  {
    this.enabled = false;
    List<Person> personList = new List<Person>();
    personList.AddRange((IEnumerable<Person>) this.PeopleBuilding);
    foreach (Person person in personList)
      this.RemoveBuilder(person);
    GameObject gameObject = Main.Spawn(this.FinalPrefab);
    gameObject.transform.position = this.transform.position;
    gameObject.transform.rotation = this.transform.rotation;
    gameObject.transform.localScale = this.transform.localScale;
    UnityEngine.Object.Destroy((UnityEngine.Object) this.gameObject);
  }
}
