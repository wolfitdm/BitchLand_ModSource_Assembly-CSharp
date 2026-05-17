// Decompiled with JetBrains decompiler
// Type: TerrainTexture
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
