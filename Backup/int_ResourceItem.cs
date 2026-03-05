// Decompiled with JetBrains decompiler
// Type: int_ResourceItem
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class int_ResourceItem : Interactible
{
  [Header("Resource")]
  public e_ResourceType ResourceType;
  public int BuyPrice;

  public int SellPrice => this.BuyPrice / 10;

  public bool Sellable => this.BuyPrice != 0;
}
