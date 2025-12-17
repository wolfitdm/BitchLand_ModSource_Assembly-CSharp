// Decompiled with JetBrains decompiler
// Type: int_Piss
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class int_Piss : Interactible
{
  public Transform PissAimSpot;
  public Transform Pos;

  public override void Interact(Person person)
  {
    this.InteractingPerson = person;
    person.AddMoveBlocker("pissing");
    this.AddBlocker("Using");
    person.transform.position = this.Pos.position;
    person.transform.rotation = this.Pos.rotation;
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
    if (person.HasPenis)
    {
      person.Anim.Play("mast2pp");
      person.PutPenis();
      person.PenisErect = true;
      person.PenisBones[5].position = person.PenisBones[2].position;
      person.PenisBones[2].SetParent(person.PenisBones[5]);
      person.PenisBones[2].localPosition = Vector3.zero;
      person.PenisBones[2].localEulerAngles = new Vector3(90f, 0.0f, 0.0f);
      person.PenisBones[5].localEulerAngles = Vector3.zero;
      this.enabled = true;
      person.RightArmIK.enabled = true;
      person.RightArmIK.Target.SetParent(person.PenisBones[2]);
      person.RightArmIK.Target.localPosition = new Vector3(0.0151f, 3f / 500f, -0.0111f);
      person.RightArmIK.Target.localEulerAngles = new Vector3(313.04892f, 215.515991f, 65.49016f);
      person.RightArmIK.Pole.localPosition = new Vector3(0.425f, 1.315f, -0.445f);
    }
    else
      person.Anim.Play("Mast2");
    UnityEngine.Object.Instantiate<GameObject>(Main.Instance.PissPrefab, person.SquirtSpots[person.SquirtSpots.Count - 1]);
    Main.RunInSeconds((Action) (() => this.StopInteracting(person)), 10f);
  }

  public void Update()
  {
    if ((UnityEngine.Object) this.InteractingPerson == (UnityEngine.Object) null)
      this.enabled = false;
    else
      this.InteractingPerson.PenisBones[5].LookAt(this.PissAimSpot);
  }

  public override void StopInteracting(Person person)
  {
    this.enabled = false;
    this.RemoveBlocker("Using");
    if ((UnityEngine.Object) person != (UnityEngine.Object) null)
    {
      person.RemoveMoveBlocker("pissing");
      if ((UnityEngine.Object) person.CurrentPants != (UnityEngine.Object) null)
      {
        foreach (Renderer componentsInChild in person.CurrentPants.GetComponentsInChildren<SkinnedMeshRenderer>())
          componentsInChild.enabled = true;
      }
      if ((UnityEngine.Object) person.CurrentUnderwearLower != (UnityEngine.Object) null)
      {
        foreach (Renderer componentsInChild in person.CurrentUnderwearLower.GetComponentsInChildren<SkinnedMeshRenderer>())
          componentsInChild.enabled = true;
      }
      if (person.HasPenis)
      {
        person.RightArmIK.enabled = false;
        person._StartedMastPP = true;
        person.PenisBones[5].localPosition = Vector3.zero;
        person.Masturbating = false;
      }
    }
    this.InteractingPerson = (Person) null;
  }
}
