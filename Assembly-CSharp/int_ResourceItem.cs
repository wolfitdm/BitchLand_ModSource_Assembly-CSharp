// Decompiled with JetBrains decompiler
// Type: int_ResourceItem
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
