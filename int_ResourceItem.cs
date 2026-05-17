// Decompiled with JetBrains decompiler
// Type: int_ResourceItem
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
