// Decompiled with JetBrains decompiler
// Type: int_DeflateMax
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class int_DeflateMax : Interactible
{
  public GameObject[] VaccumParts;
  public Transform UseSpot;
  public AudioSource ThisAudio;

  public override void Interact(Person person)
  {
    this.VaccumParts[0].SetActive(true);
    this.VaccumParts[1].SetActive(false);
    this.VaccumParts[2].SetActive(false);
    if (person is Girl)
    {
      Girl girl = person as Girl;
      girl.AddMoveBlocker("vaccum");
      girl.GiveBirth();
      base.Interact(person);
      girl.Anim.Play("Mast2");
      girl.transform.position = this.UseSpot.transform.position;
      girl.transform.rotation = this.UseSpot.transform.rotation;
      this.ThisAudio.enabled = true;
      this.ThisAudio.Play();
      this.VaccumParts[0].SetActive(false);
      this.VaccumParts[1].SetActive(true);
      this.VaccumParts[2].SetActive(false);
      Main.AdjustCharacterPosition(girl.transform, this.UseSpot, girl.Hips);
      Main.RunInSeconds((Action) (() => this.StopInteracting()), 3f);
    }
    else
      Main.Instance.Player.PersonAudio.PlayOneShot(Main.Instance.MiscSounds[0]);
  }

  public override void StopInteracting()
  {
    this.ThisAudio.Stop();
    this.ThisAudio.enabled = false;
    this.VaccumParts[0].SetActive(false);
    this.VaccumParts[1].SetActive(false);
    this.VaccumParts[2].SetActive(true);
    this.InteractingPerson.RemoveMoveBlocker("vaccum");
    base.StopInteracting();
    this.InteractingPerson.RemoveMoveBlocker("vaccum");
  }
}
