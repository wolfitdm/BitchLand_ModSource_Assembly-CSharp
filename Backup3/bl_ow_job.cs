// Decompiled with JetBrains decompiler
// Type: bl_ow_job
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class bl_ow_job : int_ConstructionPlan
{
  public Person_Type ForClass;
  public Transform WorkerSpot;
  public Transform[] CustomerSpots;

  public override void GetPlaced()
  {
    this.InteractText = this.RootObj.transform.position.x.ToString("0") + "." + this.RootObj.transform.position.y.ToString("0") + "." + this.RootObj.transform.position.z.ToString("0");
  }

  public override void Interact(Person person)
  {
    if (this.BeingMoved)
      return;
    Object.Destroy((Object) this.RootObj);
  }

  public override string[] sd_SaveData(char SlitChar = ':')
  {
    List<string> stringList = new List<string>();
    stringList.AddRange((IEnumerable<string>) base.sd_SaveData(SlitChar));
    stringList.Add(this.InteractText);
    return stringList.ToArray();
  }

  public override void sd_LoadData(string[] Data, char SlitChar = ':')
  {
    base.sd_LoadData(Data, SlitChar);
    this.InteractText = Data[this._CurrentLoadingIndex++];
  }

  public override void AddBuilder(Person person)
  {
  }

  public override void AddItem(GameObject item)
  {
  }

  public override void AddItem(GameObject item, Vector3 pos, Vector3 rot)
  {
  }

  public override void AddRemainingIngredientsFrom(Int_Storage storage)
  {
  }

  public override bool AllResourcesIn
  {
    get => false;
    set
    {
    }
  }

  public override void Awake()
  {
  }

  public override bool CanAddPersonToBuild => false;

  public override void GetBuilt()
  {
  }

  public override e_ResourceType NextRandomIngredient(
    out bool hasTooManyOfAny,
    out int amountNeeded)
  {
    hasTooManyOfAny = false;
    amountNeeded = 0;
    return e_ResourceType.None;
  }

  public override void Update() => this.enabled = false;
}
