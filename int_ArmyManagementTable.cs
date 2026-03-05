// Decompiled with JetBrains decompiler
// Type: int_ArmyManagementTable
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class int_ArmyManagementTable : Interactible
{
  [Header("asdasdasd")]
  public string MenuToOpen;

  public override void Interact(Person person)
  {
    Main.Instance.GameplayMenu.Open_ArmyManagementTable();
  }
}
