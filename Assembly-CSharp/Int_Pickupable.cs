// Decompiled with JetBrains decompiler
// Type: Int_Pickupable
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Int_Pickupable : Interactible
{
  [Header("-")]
  public Dressable ThisClothing;

  public override void Interact(Person person) => person.DressClothe(this.RootObj, false);
}
