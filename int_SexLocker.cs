// Decompiled with JetBrains decompiler
// Type: int_SexLocker
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class int_SexLocker : Int_SexMachine
{
  public Int_Door Door;
  public Transform HandsPos;
  public string PoseANim;
  public GameObject DildoPanties;
  public GameObject DildoPanties_spawned;
  public Transform FeetPos;
  public bool LowerNeck_temp;

  public override void Interact(Person person)
  {
    if (person.IsPlayer && this.PlayerOwned && (UnityEngine.Object) this.InteractingPerson != (UnityEngine.Object) null)
    {
      this.Locked = !this.Locked;
    }
    else
    {
      if (this.Locked)
        return;
      base.Interact(person);
      person.Anim.Play(this.Anim_Active);
      Main.RunInNextFrame((Action) (() =>
      {
        Main.AdjustCharacterPosition(person.transform, this.HandsPos, person.HandLeft.transform);
        Main.AdjustCharacterPosition(this.FeetPos, person.FootLeft.transform, this.FeetPos);
        if (person is Girl)
          (person as Girl).GirlPhysics = true;
        if (!person.IsPlayer)
          return;
        Main.Instance.Player.UserControl.ThirdCamPositionType = bl_ThirdPersonUserControl.e_ThirdCamPositionType.Back;
        Main.Instance.Player.UserControl.Pivot.position = new Vector3(Main.Instance.Player.UserControl.Pivot.position.x, Main.Instance.Player.ActualHips.position.y, Main.Instance.Player.UserControl.Pivot.position.z);
      }), 2);
      Main.RunInNextFrame((Action) (() =>
      {
        Main.AdjustCharacterPosition(person.transform, this.HandsPos, person.HandLeft.transform);
        Main.AdjustCharacterPosition(this.FeetPos, person.FootLeft.transform, this.FeetPos);
      }), 20);
      this.DildoPanties_spawned = person.DressClothe(this.DildoPanties);
      this.enabled = true;
      if (!this.LowerNeck_temp)
        return;
      this.LowerNeck();
    }
  }

  public override void StopInteracting()
  {
    if ((UnityEngine.Object) this.InteractingPerson == (UnityEngine.Object) null || this.Locked || !this.BeingUsed)
      return;
    if (this.InteractingPerson is Girl)
      (this.InteractingPerson as Girl).GirlPhysics = false;
    if (this.InteractingPerson.IsPlayer)
    {
      Main.Instance.Player.UserControl.ThirdCamPositionType = Main.Instance.Player.UserControl.ThirdCamPositionTypeOnSettings;
      Main.Instance.Player.UserControl.m_Character.StandState = bl_ThirdPersonCharacter.bl_StandState.Standing;
    }
    if ((UnityEngine.Object) this.DildoPanties_spawned != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.InteractingPerson.UndressClothe(this.DildoPanties_spawned.GetComponentInChildren<Dressable>()));
    base.StopInteracting();
    this.enabled = false;
  }

  public override void RefreshPoseAnim()
  {
    base.RefreshPoseAnim();
    Main.RunInNextFrame((Action) (() =>
    {
      Main.AdjustCharacterPosition(this.InteractingPerson.transform, this.HandsPos, this.InteractingPerson.HandLeft.transform);
      Main.AdjustCharacterPosition(this.FeetPos, this.InteractingPerson.FootLeft.transform, this.FeetPos);
    }), 2);
  }

  public void LowerNeck()
  {
    GameObject gameObject = new GameObject();
    gameObject.transform.SetParent(this.InteractingPerson.Torso.parent);
    gameObject.transform.localPosition = new Vector3(0.0f, 0.058f, -0.104f);
    gameObject.transform.localEulerAngles = new Vector3(56.251f, -0.00135f, 0.0009f);
    gameObject.transform.localScale = Vector3.one;
    this.InteractingPerson.Neck.parent.SetParent(gameObject.transform);
  }
}
