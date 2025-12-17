// Decompiled with JetBrains decompiler
// Type: int_Bathe
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class int_Bathe : int_basicSit
{
  public List<Transform> BatheSpots = new List<Transform>();
  public string BatheAnim;
  public AudioClip OnWaterSound;

  public override void Interact(Person person)
  {
    base.Interact(person);
    int index = Random.Range(0, this.BatheSpots.Count);
    person.transform.SetPositionAndRotation(this.BatheSpots[index].position, this.BatheSpots[index].rotation);
    if (!((Object) this.OnWaterSound != (Object) null))
      return;
    person.PersonAudio.PlayOneShot(this.OnWaterSound);
  }

  public override void StopInteracting()
  {
    if ((Object) this.OnWaterSound != (Object) null)
      this.InteractingPerson.PersonAudio.PlayOneShot(this.OnWaterSound);
    this.InteractingPerson.States[0] = false;
    this.InteractingPerson.States[2] = false;
    this.InteractingPerson.States[3] = false;
    this.InteractingPerson.States[8] = false;
    this.InteractingPerson.States[12] = false;
    this.InteractingPerson.States[13] = false;
    this.InteractingPerson.States[14] = false;
    this.InteractingPerson.States[15] = false;
    this.InteractingPerson.States[16 /*0x10*/] = false;
    this.InteractingPerson.States[17] = false;
    this.InteractingPerson.States[18] = false;
    this.InteractingPerson.States[19] = false;
    this.InteractingPerson.States[26] = false;
    this.InteractingPerson.States[33] = false;
    this.InteractingPerson.States[23] = false;
    this.InteractingPerson.States[24] = false;
    this.InteractingPerson.States[25] = false;
    this.InteractingPerson.DirtySkin = false;
    base.StopInteracting();
  }
}
