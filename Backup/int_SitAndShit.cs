// Decompiled with JetBrains decompiler
// Type: int_SitAndShit
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class int_SitAndShit : Interactible
{
  public Transform ShitSpot;
  public Transform SitSpot;
  public Transform HipsRegulate;
  public GameObject Cols;

  public override void Interact(Person person)
  {
    this.InteractingPerson = person;
    this.Cols.SetActive(false);
    person.AddMoveBlocker("shittingtoilet");
    this.AddBlocker("Using");
    person.transform.position = this.SitSpot.position;
    person.transform.rotation = this.SitSpot.rotation;
    if ((UnityEngine.Object) person.CurrentPants != (UnityEngine.Object) null)
    {
      foreach (Renderer componentsInChild in person.CurrentPants.GetComponentsInChildren<SkinnedMeshRenderer>())
        componentsInChild.enabled = false;
    }
    if ((UnityEngine.Object) person.CurrentUnderwearLower != (UnityEngine.Object) null)
    {
      foreach (Renderer componentsInChild in person.CurrentUnderwearLower.GetComponentsInChildren<SkinnedMeshRenderer>())
        componentsInChild.enabled = false;
    }
    person.enabled = false;
    person.Anim.Play("sit_00");
    Main.RunInNextFrame((Action) (() => Main.AdjustCharacterPosition(this.InteractingPerson.transform, this.InteractingPerson.ActualHips, this.HipsRegulate)), 3);
    if (person.HasPenis)
      person.PutPenis();
    person.PersonAudio.PlayOneShot(Main.Instance.ShitSounds[UnityEngine.Random.Range(0, Main.Instance.ShitSounds.Count)]);
    UnityEngine.Object.Instantiate<GameObject>(Main.Instance.PissPrefab, person.SquirtSpots[person.SquirtSpots.Count - 1]);
    Main.RunInSeconds((Action) (() => this.StopInteracting(person)), 4f);
  }

  public override void StopInteracting(Person person)
  {
    this.Cols.SetActive(true);
    this.RemoveBlocker("Using");
    if ((UnityEngine.Object) person != (UnityEngine.Object) null)
    {
      person.enabled = true;
      person.RemoveMoveBlocker("shittingtoilet");
      bool flag = false;
      if ((UnityEngine.Object) person.CurrentPants != (UnityEngine.Object) null)
      {
        flag = true;
        foreach (Renderer componentsInChild in person.CurrentPants.GetComponentsInChildren<SkinnedMeshRenderer>())
          componentsInChild.enabled = true;
      }
      if ((UnityEngine.Object) person.CurrentUnderwearLower != (UnityEngine.Object) null)
      {
        flag = true;
        foreach (Renderer componentsInChild in person.CurrentUnderwearLower.GetComponentsInChildren<SkinnedMeshRenderer>())
          componentsInChild.enabled = true;
      }
      if (person.HasPenis & flag)
        person.RemovePenis();
      GameObject gameObject = Main.Spawn(Main.Instance.PileOfScats[UnityEngine.Random.Range(0, Main.Instance.PileOfScats.Count)]);
      gameObject.transform.SetPositionAndRotation(this.ShitSpot.position, Quaternion.Euler(0.0f, (float) UnityEngine.Random.Range(0, 359), 0.0f));
      int_Scat componentInChildren = gameObject.GetComponentInChildren<int_Scat>();
      componentInChildren.Nutrition = int_Scat.NutritionOfToilet(person.Toilet);
      componentInChildren.SetSizeOnSpawn();
      person.Toilet = 0.0f;
      person.IntestinalSubstance = 0;
    }
    this.InteractingPerson = (Person) null;
  }
}
