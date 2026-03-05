// Decompiled with JetBrains decompiler
// Type: int_DildoPole
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class int_DildoPole : Interactible
{
  [Header("Dildo Pole")]
  public Transform UseSpot;
  public Transform[] PenisBones;
  public string[] UseAnims;
  public float CamHeight;
  public bool Mouth;
  public GameObject InvMouthOpen;
  public GameObject InvMouthOpen_using;
  public GameObject[] RandomFluidsAfterUse;
  private bool _PlayedShlick;

  public override void Interact(Person person)
  {
    base.Interact(person);
    this.enabled = true;
    if (this.PlaceNPCOnInteract)
    {
      this.InteractingPerson.transform.position = this.UseSpot.position;
      this.InteractingPerson.transform.rotation = this.UseSpot.rotation;
    }
    this.InteractingPerson.AddMoveBlocker("UsingDildoPole");
    if (this.InteractingPerson.IsPlayer)
    {
      this.InteractingPerson._Rigidbody.isKinematic = true;
      this.InteractingPerson.UserControl.FirstPerson = false;
      Main.Instance.Player.UserControl.ThirdCamPositionType = bl_ThirdPersonUserControl.e_ThirdCamPositionType.Back;
      this.InteractingPerson.UserControl.Pivot.localPosition = new Vector3(this.InteractingPerson.UserControl.Pivot.localPosition.x, this.CamHeight, this.InteractingPerson.UserControl.Pivot.localPosition.z);
      if (this.CanLeave)
      {
        Main.Instance.GameplayMenu.QLeave.SetActive(true);
        Main.Instance.GameplayMenu.QLeave.transform.Find("a/Text").GetComponent<Text>().text = "Leave";
      }
      if (this.InteractingPerson is Girl)
        (this.InteractingPerson as Girl).GirlPhysics = true;
    }
    this.InteractingPerson.Anim.Play(this.UseAnims[UnityEngine.Random.Range(0, this.UseAnims.Length)]);
    if (this.Mouth)
    {
      this.PenisBones[1].SetParent(person.Holes[2]);
      this.PenisBones[1].localPosition = Vector3.zero;
      this.PenisBones[1].localEulerAngles = new Vector3(0.0f, 180f, 0.0f);
      this.PenisBones[1].localScale = new Vector3(2f, 2f, 2f);
      Main.RunInNextFrame((Action) (() =>
      {
        Main.AdjustCharacterPosition(this.PenisBones[2], person.Holes[2], this.PenisBones[2]);
        this.PenisBones[2].localPosition -= new Vector3(0.0f, 0.0f, 0.0103f);
        this.InvMouthOpen_using = person.DressClothe(this.InvMouthOpen);
      }), 2);
      if (person.IsPlayer)
        return;
      person.CallWhenHighCol.Add(new Action(this.OnNonCull));
    }
    else
    {
      this.InteractingPerson.Masturbating = true;
      this.PenisBones[1].SetParent(person.Holes[0]);
      this.PenisBones[1].localPosition = Vector3.zero;
      this.PenisBones[1].localEulerAngles = Vector3.zero;
      this.PenisBones[1].localScale = new Vector3(2f, 2f, 2f);
    }
  }

  public void LateUpdate()
  {
    if ((UnityEngine.Object) this.InteractingPerson == (UnityEngine.Object) null)
    {
      this.enabled = false;
    }
    else
    {
      double num = (double) this.InteractingPerson.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime % 1.0;
      if (num >= 0.10000000149011612 && !this._PlayedShlick)
      {
        this._PlayedShlick = true;
        AudioClip clip = !this.Mouth ? Main.Instance.SexScene.ShlickSounds[UnityEngine.Random.Range(0, Main.Instance.SexScene.ShlickSounds.Length)] : Main.Instance.SuccSounds[UnityEngine.Random.Range(0, Main.Instance.SuccSounds.Length)];
        if ((UnityEngine.Object) clip != (UnityEngine.Object) null)
          this.InteractingPerson.PersonAudio.PlayOneShot(clip, UnityEngine.Random.Range(0.05f, 0.2f));
      }
      if (num < 0.10000000149011612)
        this._PlayedShlick = false;
      if (!this.InteractingPerson.IsPlayer || !this.CanLeave || !Input.GetKeyUp(KeyCode.Q) && !Input.GetMouseButtonUp(UI_Settings.RightMouseButton))
        return;
      this.StopInteracting();
    }
  }

  public override void StopInteracting(Person interactingPerson)
  {
    if (this.Mouth)
    {
      if ((UnityEngine.Object) this.InvMouthOpen_using != (UnityEngine.Object) null)
      {
        UnityEngine.Object.Destroy((UnityEngine.Object) this.InteractingPerson.UndressClothe(this.InvMouthOpen_using.GetComponent<Dressable>()));
        this.InvMouthOpen_using = (GameObject) null;
      }
      if (!this.InteractingPerson.IsPlayer)
        this.InteractingPerson.CallWhenHighCol.Remove(new Action(this.OnNonCull));
      for (int index = 0; index < this.RandomFluidsAfterUse.Length; ++index)
        this.RandomFluidsAfterUse[index].SetActive(false);
      this.RandomFluidsAfterUse[UnityEngine.Random.Range(0, this.RandomFluidsAfterUse.Length)].SetActive(true);
    }
    base.StopInteracting(interactingPerson);
    this.enabled = false;
    this.InteractingPerson.Masturbating = false;
    this.InteractingPerson.RemoveMoveBlocker("UsingDildoPole");
    if (this.InteractingPerson.IsPlayer)
    {
      this.InteractingPerson._Rigidbody.isKinematic = false;
      Main.Instance.Player.UserControl.ThirdCamPositionType = Main.Instance.Player.UserControl.ThirdCamPositionTypeOnSettings;
      Main.Instance.Player.UserControl.m_Character.StandState = bl_ThirdPersonCharacter.bl_StandState.Standing;
      if (this.CanLeave)
        Main.Instance.GameplayMenu.QLeave.SetActive(false);
      if (this.InteractingPerson is Girl)
        (this.InteractingPerson as Girl).GirlPhysics = false;
    }
    this.PenisBones[1].SetParent(this.PenisBones[0]);
    this.PenisBones[1].localPosition = new Vector3(0.0f, 0.02f, 0.0f);
    this.PenisBones[1].localEulerAngles = new Vector3(8f, 0.0f, 0.0f);
    this.PenisBones[1].localScale = Vector3.one;
  }

  public void OnNonCull()
  {
    Main.RunInNextFrame((Action) (() =>
    {
      Main.AdjustCharacterPosition(this.PenisBones[2], this.InteractingPerson.Holes[2], this.PenisBones[2]);
      this.PenisBones[2].localPosition -= new Vector3(0.0f, 0.0f, 0.0103f);
    }), 2);
  }
}
