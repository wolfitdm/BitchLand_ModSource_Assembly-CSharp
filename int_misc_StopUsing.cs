// Decompiled with JetBrains decompiler
// Type: int_misc_StopUsing
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class int_misc_StopUsing : Interactible
{
  [Header("++++++++++++++++++++++")]
  public Interactible TheInteractible;
  public string TextPrefix;
  public string TextSufix;

  public override bool CheckCanInteract(Person person)
  {
    if ((Object) this.TheInteractible.InteractingPerson == (Object) null)
      return false;
    this.InteractText = this.TextPrefix + this.TheInteractible.InteractingPerson.Name + this.TextSufix;
    return true;
  }

  public override void Interact(Person person)
  {
    if (!((Object) this.TheInteractible.InteractingPerson != (Object) null))
      return;
    this.TheInteractible.StopInteracting();
  }
}
