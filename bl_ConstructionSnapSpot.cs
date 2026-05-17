// Decompiled with JetBrains decompiler
// Type: bl_ConstructionSnapSpot
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class bl_ConstructionSnapSpot : MonoBehaviour
{
  public bl_ConstructionSnapSpot.e_snapSpotUse Wall;
  public bl_ConstructionSnapSpot.e_snapSpotUse Floor;
  public Transform Spot_Floor;
  public Transform Spot_Wall;
  public bl_ConstructionSnapSpot Connection_Floor;
  public bl_ConstructionSnapSpot Connection_Wall;

  public enum e_snapSpotUse
  {
    Disabled,
    Free,
    Used,
    MAX,
  }
}
