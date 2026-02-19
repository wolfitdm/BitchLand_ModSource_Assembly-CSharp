// Decompiled with JetBrains decompiler
// Type: int_PickupToBag
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
