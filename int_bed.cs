// Decompiled with JetBrains decompiler
// Type: int_bed
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class int_bed : Interactible
{
  public Transform SleepPlace;
  public bool SafeBed;

  public override void Interact(Person person)
  {
    base.Interact(person);
    this.enabled = true;
    person.transform.SetPositionAndRotation(this.SleepPlace.position, this.SleepPlace.rotation);
    person.SleepOnFloor();
  }

  public void Interact_SexyWait(Person person)
  {
    person.transform.SetPositionAndRotation(this.SleepPlace.position, this.SleepPlace.rotation);
    person.Anim.Play("xxx-6");
    person.ThisPersonInt.SetSexInteraction();
  }

  public void Update()
  {
    if (this.InteractingPerson.MoveBlockers.Contains("SleepingFloor"))
      return;
    this.StopInteracting();
  }

  public override void StopInteracting()
  {
    this.enabled = false;
    this.InteractingPerson.transform.SetParent((Transform) null);
    this.InteractingPerson.WakeUp();
    base.StopInteracting();
  }
}
