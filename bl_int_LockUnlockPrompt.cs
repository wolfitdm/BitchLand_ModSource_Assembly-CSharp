// Decompiled with JetBrains decompiler
// Type: bl_int_LockUnlockPrompt
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
