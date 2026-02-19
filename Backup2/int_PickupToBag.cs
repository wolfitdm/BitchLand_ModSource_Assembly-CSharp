// Decompiled with JetBrains decompiler
// Type: int_PickupToBag
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class int_PickupToBag : Interactible
{
  public override bool CheckCanInteract(Person person)
  {
    if ((Object) person.CurrentBackpack == (Object) null)
    {
      Main.Instance.GameplayMenu.ShowNotification("No Backpack equipped");
      return false;
    }
    if (!person.CurrentBackpack.ThisStorage.Full)
      return true;
    Main.Instance.GameplayMenu.ShowNotification("Backpack is full");
    return false;
  }

  public override void Interact(Person person)
  {
    if (!this.CheckCanInteract(person))
      return;
    person.CurrentBackpack.ThisStorage.AddItem(this.RootObj);
  }
}
