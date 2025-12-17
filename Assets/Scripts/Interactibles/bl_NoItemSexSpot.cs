// Decompiled with JetBrains decompiler
// Type: Assets.Scripts.Interactibles.bl_NoItemSexSpot
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace Assets.Scripts.Interactibles;

public class bl_NoItemSexSpot : int_basicSit
{
  [Space]
  public InteractRedirect ThisRed;
  public MultiInteractible ThisMulti;
  public bool Free;
  public GameObject PrefabEquipWhenUsing;
  public Dressable SpawnedEquipWhenUsing;

  public override void Interact(Person person)
  {
    this.RemoveBlocker("UserSexing");
    if ((UnityEngine.Object) this.InteractingPerson == (UnityEngine.Object) null)
    {
      base.Interact(person);
      this.GenderOnly = GenderType.Both;
      this.InteractBlockers.Clear();
      this.CanInteract = true;
      this.RunTo = true;
      if (!((UnityEngine.Object) this.PrefabEquipWhenUsing != (UnityEngine.Object) null))
        return;
      if ((UnityEngine.Object) this.SpawnedEquipWhenUsing != (UnityEngine.Object) null)
        UnityEngine.Object.Destroy((UnityEngine.Object) this.SpawnedEquipWhenUsing.PersonEquipped.UndressClothe(this.SpawnedEquipWhenUsing));
      this.SpawnedEquipWhenUsing = this.InteractingPerson.DressClothe(this.PrefabEquipWhenUsing).GetComponentInChildren<Dressable>();
    }
    else
    {
      Person _prost = this.InteractingPerson;
      this.StopInteracting();
      this.AddBlocker("UserSexing");
      if (this.Free)
      {
        SpawnedSexScene spawnedSexScene = !person.HasPenis ? (!_prost.HasPenis ? Main.Instance.SexScene.SpawnSexScene(2, 1, person, _prost, canControl: false) : Main.Instance.SexScene.SpawnSexScene(2, 1, _prost, person, canControl: false)) : Main.Instance.SexScene.SpawnSexScene(2, 3, person, _prost, canControl: false);
        spawnedSexScene.TimerForRandomPoseChange = true;
        spawnedSexScene.TimerMax = UnityEngine.Random.Range(10f, 20f);
        spawnedSexScene.TimerPoseChange = spawnedSexScene.TimerMax;
        spawnedSexScene.TimerForRandomSexEnd = true;
        spawnedSexScene.TimerSexEnd = UnityEngine.Random.Range(60f, 120f);
        spawnedSexScene.OnSexEnd = (Action) (() =>
        {
          this.InteractingPerson = (Person) null;
          this.Interact(_prost);
        });
      }
      else
      {
        SpawnedSexScene spawnedSexScene = !person.HasPenis ? (!_prost.HasPenis ? Main.Instance.SexScene.SpawnSexScene(2, 1, person, _prost, receiveMoney: true, canControl: false) : Main.Instance.SexScene.SpawnSexScene(2, 1, _prost, person, receiveMoney: true, canControl: false)) : Main.Instance.SexScene.SpawnSexScene(2, 3, person, _prost, receiveMoney: true, canControl: false);
        spawnedSexScene.TimerForRandomPoseChange = true;
        spawnedSexScene.TimerMax = UnityEngine.Random.Range(10f, 20f);
        spawnedSexScene.TimerPoseChange = spawnedSexScene.TimerMax;
        spawnedSexScene.TimerForRandomSexEnd = true;
        spawnedSexScene.TimerSexEnd = UnityEngine.Random.Range(60f, 120f);
        spawnedSexScene.OnSexEnd = (Action) (() =>
        {
          this.InteractingPerson = (Person) null;
          this.Interact(_prost);
        });
      }
    }
  }

  public override void StopInteracting()
  {
    if ((UnityEngine.Object) this.PrefabEquipWhenUsing != (UnityEngine.Object) null && (UnityEngine.Object) this.SpawnedEquipWhenUsing != (UnityEngine.Object) null)
    {
      if ((UnityEngine.Object) this.SpawnedEquipWhenUsing.PersonEquipped == (UnityEngine.Object) null)
        UnityEngine.Object.Destroy((UnityEngine.Object) this.SpawnedEquipWhenUsing);
      else
        UnityEngine.Object.Destroy((UnityEngine.Object) this.SpawnedEquipWhenUsing.PersonEquipped.UndressClothe(this.SpawnedEquipWhenUsing));
      this.SpawnedEquipWhenUsing = (Dressable) null;
    }
    base.StopInteracting();
    this.InteractingPerson = (Person) null;
    this.RemoveBlocker("UserSexing");
    this.GenderOnly = GenderType.Female;
    this.RunTo = false;
  }
}
