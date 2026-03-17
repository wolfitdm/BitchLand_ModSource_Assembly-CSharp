// Decompiled with JetBrains decompiler
// Type: int_LoadCustomCharacter
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
