// Decompiled with JetBrains decompiler
// Type: int_misc_StopUsing
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
