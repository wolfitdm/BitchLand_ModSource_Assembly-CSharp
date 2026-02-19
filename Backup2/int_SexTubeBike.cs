// Decompiled with JetBrains decompiler
// Type: int_SexTubeBike
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class int_SexTubeBike : Int_SexMachine
{
  [Space]
  public string AnimToplay;
  public Transform[] HandsSpots;
  public Transform[] FeetSpots;
  public Transform[] TubeTips;
  public Collider[] Cols;
  public bool DoIK = true;
  public Vector3[] Posssss;

  public override void Interact(Person person)
  {
    if (this.Locked)
      return;
    base.Interact(person);
    person.Anim.Play(this.Anim_Active);
    if (this.Cols.Length != 0)
    {
      this.Cols[0].enabled = false;
      this.Cols[1].enabled = true;
    }
    Main.RunInNextFrame((Action) (() =>
    {
      if (this.DoIK)
      {
        person.LeftArmIK.enabled = true;
        person.LeftArmIK.Target.SetParent(this.HandsSpots[0]);
        person.LeftArmIK.Target.localPosition = Vector3.zero;
        person.LeftArmIK.Target.localEulerAngles = Vector3.zero;
        person.LeftArmIK.Pole.position = this.HandsSpots[2].position;
        person.LeftLegIK.enabled = true;
        person.LeftLegIK.Target.SetParent(this.FeetSpots[0]);
        person.LeftLegIK.Target.localPosition = Vector3.zero;
        person.LeftLegIK.Target.localEulerAngles = Vector3.zero;
        person.LeftLegIK.Pole.position = this.FeetSpots[2].position;
        person.RightArmIK.enabled = true;
        person.RightArmIK.Target.SetParent(this.HandsSpots[1]);
        person.RightArmIK.Target.localPosition = Vector3.zero;
        person.RightArmIK.Target.localEulerAngles = Vector3.zero;
        person.RightArmIK.Pole.position = this.HandsSpots[3].position;
        person.RightLegIK.enabled = true;
        person.RightLegIK.Target.SetParent(this.FeetSpots[1]);
        person.RightLegIK.Target.localPosition = Vector3.zero;
        person.RightLegIK.Target.localEulerAngles = Vector3.zero;
        person.RightLegIK.Pole.position = this.FeetSpots[3].position;
      }
      if (!(person is Girl))
        return;
      (person as Girl).GirlPhysics = true;
      if (this.TubeTips.Length == 0)
        return;
      this.TubeTips[0].transform.SetParent(person.Holes[0]);
      this.TubeTips[0].transform.localPosition = this.Posssss[3];
      this.TubeTips[0].transform.localEulerAngles = this.Posssss[4];
      this.TubeTips[0].transform.localScale = Vector3.one;
      person.Holes[0].localScale = this.Posssss[0];
      person.Holes[0].localEulerAngles = this.Posssss[1];
      this.TubeTips[1].transform.SetParent(person.Holes[1]);
      this.TubeTips[1].transform.localPosition = this.Posssss[5];
      this.TubeTips[1].transform.localEulerAngles = this.Posssss[6];
      this.TubeTips[1].transform.localScale = Vector3.one;
      person.Holes[1].localScale = this.Posssss[0];
      person.Holes[1].localEulerAngles = this.Posssss[2];
    }), 3);
    this.enabled = true;
  }

  public override void StopInteracting()
  {
    if ((UnityEngine.Object) this.InteractingPerson == (UnityEngine.Object) null || this.Locked)
      return;
    if (this.InteractingPerson is Girl)
      (this.InteractingPerson as Girl).GirlPhysics = false;
    if (this.Cols.Length != 0)
    {
      this.Cols[0].enabled = true;
      this.Cols[1].enabled = false;
    }
    this.InteractingPerson.Holes[0].localEulerAngles = Vector3.zero;
    this.InteractingPerson.Holes[1].localEulerAngles = Vector3.zero;
    this.InteractingPerson.Holes[0].localScale = Vector3.one;
    this.InteractingPerson.Holes[1].localScale = Vector3.one;
    if (this.TubeTips.Length != 0)
    {
      this.TubeTips[0].transform.SetParent(this.TubeTips[2]);
      this.TubeTips[1].transform.SetParent(this.TubeTips[3]);
      this.TubeTips[0].transform.localScale = Vector3.one;
      this.TubeTips[1].transform.localScale = Vector3.one;
    }
    if (this.DoIK)
    {
      this.InteractingPerson.LeftArmIK.enabled = false;
      this.InteractingPerson.LeftArmIK.Target.SetParent(this.InteractingPerson.LeftArmIK.Pole.parent);
      this.InteractingPerson.RightArmIK.enabled = false;
      this.InteractingPerson.RightArmIK.Target.SetParent(this.InteractingPerson.LeftArmIK.Pole.parent);
      this.InteractingPerson.LeftLegIK.enabled = false;
      this.InteractingPerson.LeftLegIK.Target.SetParent(this.InteractingPerson.LeftArmIK.Pole.parent);
      this.InteractingPerson.RightLegIK.enabled = false;
      this.InteractingPerson.RightLegIK.Target.SetParent(this.InteractingPerson.LeftArmIK.Pole.parent);
    }
    base.StopInteracting();
    this.enabled = false;
  }
}
