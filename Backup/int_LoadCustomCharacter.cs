// Decompiled with JetBrains decompiler
// Type: int_LoadCustomCharacter
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
