// Decompiled with JetBrains decompiler
// Type: int_LoadCustomCharacter
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class int_LoadCustomCharacter : Interactible
{
  public Transform SpawnSpot;
  public RandomNPCHere TheSpawner;

  public override void Interact(Person person)
  {
    if (Main.Instance.NewGameMenu.DificultySelected == 3)
      return;
    this.TheSpawner.LoadSpecificNPC = true;
    this.TheSpawner.PersonGenerated = (Person) null;
    person.InteractingWith = (Interactible) this;
    Main.Instance.OpenMenu("LoadCustomNPC");
  }
}
