// Decompiled with JetBrains decompiler
// Type: int_bed
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
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

  public override string[] sd_SaveData(char SlitChar = ':')
  {
    List<string> stringList = new List<string>();
    stringList.AddRange((IEnumerable<string>) base.sd_SaveData(SlitChar));
    stringList.Add((Object) this.Owner == (Object) null ? "NULL" : this.Owner.WorldSaveID);
    return stringList.ToArray();
  }

  public override void sd_LoadData(string[] Data, char SlitChar = ':')
  {
    base.sd_LoadData(Data, SlitChar);
    if (Data.Length - 1 < this._CurrentLoadingIndex)
      return;
    string str = Data[this._CurrentLoadingIndex++];
    if (!(str != "NULL"))
      return;
    if (Main.Instance.OpenWorld)
    {
      for (int index = 0; index < Main.Instance.SpawnedPeople_World.Count; ++index)
      {
        if ((Object) Main.Instance.SpawnedPeople_World[index] != (Object) null && Main.Instance.SpawnedPeople_World[index].WorldSaveID == str)
        {
          this.MakeOwner(Main.Instance.SpawnedPeople_World[index]);
          break;
        }
      }
    }
    else
    {
      for (int index = 0; index < Main.Instance.SpawnedPeople.Count; ++index)
      {
        if ((Object) Main.Instance.SpawnedPeople[index] != (Object) null && Main.Instance.SpawnedPeople[index].WorldSaveID == str)
        {
          this.MakeOwner(Main.Instance.SpawnedPeople[index]);
          break;
        }
      }
    }
  }
}
