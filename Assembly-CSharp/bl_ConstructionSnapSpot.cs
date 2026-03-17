// Decompiled with JetBrains decompiler
// Type: bl_ConstructionSnapSpot
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
