// Decompiled with JetBrains decompiler
// Type: bl_int_LockUnlockPrompt
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class bl_int_LockUnlockPrompt : Interactible
{
  [Header("++++++++++++++++++++")]
  public int_Lockable Lockable;

  public override bool CheckCanInteract(Person person)
  {
    if (!this.Lockable.PlayerOwned)
      return false;
    if (this.Lockable.Locked)
      this.InteractText = "Unlock";
    else
      this.InteractText = "Lock";
    return base.CheckCanInteract(person);
  }

  public override void Interact(Person person) => this.Lockable.Locked = !this.Lockable.Locked;
}
