// Decompiled with JetBrains decompiler
// Type: HeightMapModifier_Noise
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class HeightMapModifier_Noise : BaseHeightMapModifier
{
  [SerializeField]
  private List<HeightNoisePass> Passes;

  public override void Execute(
    ProcGenConfigSO globalConfig,
    int mapResolution,
    float[,] heightMap,
    Vector3 heightmapScale,
    byte[,] biomeMap = null,
    int biomeIndex = -1,
    BiomeConfigSO biome = null)
  {
    foreach (HeightNoisePass pass in this.Passes)
    {
      for (int index1 = 0; index1 < mapResolution; ++index1)
      {
        for (int index2 = 0; index2 < mapResolution; ++index2)
        {
          if (biomeIndex < 0 || (int) biomeMap[index2, index1] == biomeIndex)
          {
            float num = (float) ((double) Mathf.PerlinNoise((float) index2 * pass.NoiseScale, (float) index1 * pass.NoiseScale) * 2.0 - 1.0);
            float b = heightMap[index2, index1] + num * pass.HeightDelta / heightmapScale.y;
            heightMap[index2, index1] = Mathf.Lerp(heightMap[index2, index1], b, this.Strength);
          }
        }
      }
    }
  }
}
