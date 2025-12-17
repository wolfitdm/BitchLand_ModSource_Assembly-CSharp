// Decompiled with JetBrains decompiler
// Type: Int_SexMachine
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class Int_SexMachine : int_Lockable
{
  public Transform Pos;
  public string Anim_idle;
  public string Anim_Active;
  public Animation ActiveAnim;
  public string Machine_StartingAnim;
  public string Machine_EndingAnim;
  public string Machine_RunningAnim;
  public float SexIntensity = 1.001f;
  public bool CenterCam;
  public Transform HipsSpot;
  public bool AutoActivateOnUse;
  public bool DoShlick;
  private bool _PlayedShlick;

  public void LateUpdate()
  {
    if ((UnityEngine.Object) this.InteractingPerson == (UnityEngine.Object) null)
    {
      this.enabled = false;
    }
    else
    {
      if (!this.DoShlick)
        return;
      double num = (double) this.InteractingPerson.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime % 1.0;
      if (num >= 0.10000000149011612 && !this._PlayedShlick)
      {
        this._PlayedShlick = true;
        AudioClip shlickSound = Main.Instance.SexScene.ShlickSounds[UnityEngine.Random.Range(0, Main.Instance.SexScene.ShlickSounds.Length)];
        if ((UnityEngine.Object) shlickSound != (UnityEngine.Object) null)
          this.InteractingPerson.PersonAudio.PlayOneShot(shlickSound, UnityEngine.Random.Range(0.05f, 0.2f));
      }
      if (num >= 0.10000000149011612)
        return;
      this._PlayedShlick = false;
    }
  }

  public override void Interact(Person person)
  {
    if (this.Locked)
      return;
    this.DoForSeconds = person._PersonalityData.HowLongWantsSex;
    base.Interact(person);
    this.InteractingPerson.enabled = false;
    this.InteractingPerson._Rigidbody.isKinematic = true;
    if (this.InteractingPerson.IsPlayer)
    {
      this.InteractingPerson.UserControl.FirstPerson = false;
      Main.Instance.GameplayMenu.QLeave.SetActive(true);
      Main.Instance.GameplayMenu.QLeave.transform.Find("a/Text").GetComponent<Text>().text = "Leave";
    }
    this.InteractingPerson.AddMoveBlocker("SexMachine");
    this.InteractingPerson.transform.SetParent(this.Pos);
    this.InteractingPerson.transform.position = this.Pos.position;
    this.InteractingPerson.transform.rotation = this.Pos.rotation;
    this.InteractingPerson.Anim.Play(this.Anim_idle);
    this.InteractingPerson.Masturbating = true;
    this.InteractingPerson.HavingSex = true;
    this.InteractingPerson.SexMultiplier = this.SexIntensity;
    if (this.InteractingPerson.IsPlayer && this.CenterCam)
      Main.RunInNextFrame((Action) (() =>
      {
        Main.Instance.Player.UserControl.ThirdCamPositionType = bl_ThirdPersonUserControl.e_ThirdCamPositionType.Back;
        Main.Instance.Player.UserControl.Pivot.position = new Vector3(Main.Instance.Player.UserControl.Pivot.position.x, Main.Instance.Player.ActualHips.position.y, Main.Instance.Player.UserControl.Pivot.position.z);
      }), 5);
    this.InteractingPerson.CallWhenHighCol.Add(new Action(this.RefreshPoseAnim));
    Main.RunInNextFrame((Action) (() =>
    {
      if (!((UnityEngine.Object) this.HipsSpot != (UnityEngine.Object) null))
        return;
      Main.AdjustCharacterPosition(person.transform, this.HipsSpot, person.ActualHips);
    }), 2);
    if (!this.AutoActivateOnUse)
      return;
    this.Activate();
  }

  public virtual void Activate()
  {
    Debug.Log((object) "Sex machine activated");
    this.InteractingPerson.Anim.Play(this.Anim_Active);
    this.enabled = true;
    if (!((UnityEngine.Object) this.ActiveAnim != (UnityEngine.Object) null))
      return;
    this.ActiveAnim.enabled = true;
  }

  public override void StopInteracting()
  {
    if (this.Locked)
      return;
    base.StopInteracting();
    if ((UnityEngine.Object) this.InteractingPerson == (UnityEngine.Object) null)
      return;
    this.enabled = false;
    if ((UnityEngine.Object) this.ActiveAnim != (UnityEngine.Object) null)
      this.ActiveAnim.enabled = false;
    this.InteractingPerson.enabled = true;
    this.InteractingPerson.transform.SetParent((Transform) null);
    if (this.InteractingPerson.IsPlayer)
    {
      this.InteractingPerson._Rigidbody.isKinematic = false;
      Main.Instance.GameplayMenu.QLeave.SetActive(false);
      if (this.CenterCam)
      {
        Main.Instance.Player.UserControl.ThirdCamPositionType = Main.Instance.Player.UserControl.ThirdCamPositionTypeOnSettings;
        Main.Instance.Player.UserControl.m_Character.StandState = bl_ThirdPersonCharacter.bl_StandState.Standing;
      }
    }
    this.InteractingPerson.Masturbating = false;
    this.InteractingPerson.HavingSex = false;
    this.InteractingPerson.SexMultiplier = 1f;
    this.InteractingPerson.RemoveMoveBlocker("SexMachine");
    this.InteractingPerson.CallWhenHighCol.Remove(new Action(this.RefreshPoseAnim));
  }

  public void Update()
  {
    if (!((UnityEngine.Object) this.InteractingPerson != (UnityEngine.Object) null))
      return;
    this.InteractingPerson.SexUpdate();
    if (!this.InteractingPerson.IsPlayer || !Input.GetKeyUp(KeyCode.Q))
      return;
    this.StopInteracting();
  }

  public virtual void RefreshPoseAnim()
  {
    this.InteractingPerson.Anim.Play(this.Anim_Active);
    Main.RunInNextFrame((Action) (() =>
    {
      if (!((UnityEngine.Object) this.HipsSpot != (UnityEngine.Object) null))
        return;
      Main.AdjustCharacterPosition(this.InteractingPerson.transform, this.HipsSpot, this.InteractingPerson.ActualHips);
    }), 2);
  }
}
