// Decompiled with JetBrains decompiler
// Type: TexturePainter_Height
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class TexturePainter_Height : BaseTexturePainter
{
  [SerializeField]
  private TextureConfig Texture;
  [SerializeField]
  private float StartHeight;
  [SerializeField]
  private float EndHeight;
  [SerializeField]
  private AnimationCurve Intensity;
  [SerializeField]
  private bool SuppressOtherTextures;
  [SerializeField]
  private AnimationCurve SuppressionIntensity;

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
    int layerForTexture = manager.GetLayerForTexture(this.Texture);
    float num1 = this.StartHeight / heightmapScale.y;
    float num2 = this.EndHeight / heightmapScale.y;
    float num3 = (float) (1.0 / ((double) num2 - (double) num1));
    int length = alphaMaps.GetLength(2);
    for (int index1 = 0; index1 < alphaMapResolution; ++index1)
    {
      int index2 = Mathf.FloorToInt((float) index1 * (float) mapResolution / (float) alphaMapResolution);
      for (int index3 = 0; index3 < alphaMapResolution; ++index3)
      {
        int index4 = Mathf.FloorToInt((float) index3 * (float) mapResolution / (float) alphaMapResolution);
        if (biomeIndex < 0 || (int) biomeMap[index4, index2] == biomeIndex)
        {
          float height = heightMap[index4, index2];
          if ((double) height >= (double) num1 && (double) height <= (double) num2)
          {
            float time = (height - num1) * num3;
            alphaMaps[index3, index1, layerForTexture] = this.Strength * this.Intensity.Evaluate(time);
            if (this.SuppressOtherTextures)
            {
              float num4 = this.SuppressionIntensity.Evaluate(time);
              for (int index5 = 0; index5 < length; ++index5)
              {
                if (index5 != layerForTexture)
                  alphaMaps[index3, index1, index5] *= num4;
              }
            }
          }
        }
      }
    }
  }

  public override List<TextureConfig> RetrieveTextures()
  {
    return new List<TextureConfig>(1) { this.Texture };
  }
}
