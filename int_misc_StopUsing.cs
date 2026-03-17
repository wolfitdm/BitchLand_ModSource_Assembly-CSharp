// Decompiled with JetBrains decompiler
// Type: int_misc_StopUsing
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
