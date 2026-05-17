// Decompiled with JetBrains decompiler
// Type: int_LoadCustomCharacter
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
