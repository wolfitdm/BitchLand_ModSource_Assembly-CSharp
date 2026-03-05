// Decompiled with JetBrains decompiler
// Type: int_bed
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class int_bed : bl_HangFurniture
{
  public Transform SleepPlace;
  public bool SafeBed;

  public override void MakeOwner(Person person)
  {
    base.MakeOwner(person);
    person.OwnBed = this;
    this.InteractText = person.Name + "'s bed";
  }

  public override void Interact(Person person)
  {
    base.Interact(person);
    this.enabled = true;
    person.transform.SetPositionAndRotation(this.SleepPlace.position, this.SleepPlace.rotation);
    person.SleepOnFloor();
    if (!Main.Instance.OpenWorld)
      return;
    this.MakeOwner(person);
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
