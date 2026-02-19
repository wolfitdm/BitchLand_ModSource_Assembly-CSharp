// Decompiled with JetBrains decompiler
// Type: TexturePainter_Random
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class TexturePainter_Random : BaseTexturePainter
{
  [SerializeField]
  private TextureConfig BaseTexture;
  [SerializeField]
  private List<RandomPainterConfig> PaintingConfigs;
  [NonSerialized]
  private List<TextureConfig> CachedTextures;

  public override void Execute(
    ProcGenManager manager,
    int mapResolution,
    float[,] heightMap,
    Vector3 heightmapScale,
    float[,] slopeMap,
    float[,,] alphaMaps,
    int alphaMapResolution,
    byte[,] biomeMap = null,
    int biomeIndex = -1,
    BiomeConfigSO biome = null)
  {
    int layerForTexture1 = manager.GetLayerForTexture(this.BaseTexture);
    for (int index1 = 0; index1 < alphaMapResolution; ++index1)
    {
      int index2 = Mathf.FloorToInt((float) index1 * (float) mapResolution / (float) alphaMapResolution);
      for (int index3 = 0; index3 < alphaMapResolution; ++index3)
      {
        int index4 = Mathf.FloorToInt((float) index3 * (float) mapResolution / (float) alphaMapResolution);
        if (biomeIndex < 0 || (int) biomeMap[index4, index2] == biomeIndex)
        {
          foreach (RandomPainterConfig paintingConfig in this.PaintingConfigs)
          {
            float num = Mathf.PerlinNoise((float) index3 * paintingConfig.NoiseScale, (float) index1 * paintingConfig.NoiseScale);
            if ((double) UnityEngine.Random.Range(0.0f, 1f) >= (double) num)
            {
              int layerForTexture2 = manager.GetLayerForTexture(paintingConfig.TextureToPaint);
              alphaMaps[index3, index1, layerForTexture2] = this.Strength * paintingConfig.IntensityModifier;
            }
          }
          alphaMaps[index3, index1, layerForTexture1] = this.Strength;
        }
      }
    }
  }

  public override List<TextureConfig> RetrieveTextures()
  {
    if (this.CachedTextures == null)
    {
      this.CachedTextures = new List<TextureConfig>();
      this.CachedTextures.Add(this.BaseTexture);
      foreach (RandomPainterConfig paintingConfig in this.PaintingConfigs)
        this.CachedTextures.Add(paintingConfig.TextureToPaint);
    }
    return this.CachedTextures;
  }
}
