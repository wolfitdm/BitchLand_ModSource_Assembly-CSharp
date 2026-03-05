// Decompiled with JetBrains decompiler
// Type: bl_ConstructionSnapSpot
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
