// Decompiled with JetBrains decompiler
// Type: TexturePainter_Slope
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class TexturePainter_Slope : BaseTexturePainter
{
  [SerializeField]
  private TextureConfig Texture;
  [SerializeField]
  private AnimationCurve IntensityVsSlope;

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
    for (int index1 = 0; index1 < alphaMapResolution; ++index1)
    {
      int index2 = Mathf.FloorToInt((float) index1 * (float) mapResolution / (float) alphaMapResolution);
      for (int index3 = 0; index3 < alphaMapResolution; ++index3)
      {
        int index4 = Mathf.FloorToInt((float) index3 * (float) mapResolution / (float) alphaMapResolution);
        if (biomeIndex < 0 || (int) biomeMap[index4, index2] == biomeIndex)
          alphaMaps[index3, index1, layerForTexture] = this.Strength * this.IntensityVsSlope.Evaluate(1f - slopeMap[index3, index1]);
      }
    }
  }

  public override List<TextureConfig> RetrieveTextures()
  {
    return new List<TextureConfig>(1) { this.Texture };
  }
}
