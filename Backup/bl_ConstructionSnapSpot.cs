// Decompiled with JetBrains decompiler
// Type: bl_ConstructionSnapSpot
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
