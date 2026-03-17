// Decompiled with JetBrains decompiler
// Type: TerrainTexture
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
[Serializable]
public class TerrainTexture
{
  [Header("Texture Settings:")]
  public Texture2D texture;
  public Vector2 tilesize = new Vector2(1f, 1f);
  [Header("Normal Settings:")]
  public Texture2D normalMap;
  [Range(0.0f, 1f)]
  public float bumpFactor = 0.5f;
  [Header("Kind of Texture:")]
  public TerrainTexture.Type type;
  [Header("Other Settings:")]
  public string textureName = "TextureLayer";
  [Range(0.0f, 1f)]
  public float metallness;
  [Range(0.0f, 1f)]
  public float smoothness;
  [Space(10f)]
  public AnimationCurve heightCurve;
  public AnimationCurve angleCurve;
  public AnimationCurve normalCurve;
  public TerrainTexture.NormalDirection normal;

  public enum Type
  {
    HeightBased,
    SlopeBased,
    HeightAndSlopeMixed,
    BuildingFoundation,
    EdgeCliff,
    NormalBased,
  }

  public enum NormalDirection
  {
    FacingZ,
    FacingNegativeZ,
    FacingX,
    FacingNegativeX,
  }
}
