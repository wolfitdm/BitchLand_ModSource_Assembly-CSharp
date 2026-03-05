// Decompiled with JetBrains decompiler
// Type: int_PickupToBag
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
