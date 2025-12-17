// Decompiled with JetBrains decompiler
// Type: HeightMapModifier_Features
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class HeightMapModifier_Features : BaseHeightMapModifier
{
  [SerializeField]
  private List<FeatureConfig> Features;

  protected void SpawnFeature(
    FeatureConfig feature,
    int spawnX,
    int spawnY,
    int mapResolution,
    float[,] heightMap,
    Vector3 heightmapScale)
  {
    float num1 = 0.0f;
    int num2 = 0;
    for (int index1 = -feature.Radius; index1 <= feature.Radius; ++index1)
    {
      for (int index2 = -feature.Radius; index2 <= feature.Radius; ++index2)
      {
        num1 += heightMap[index2 + spawnX, index1 + spawnY];
        ++num2;
      }
    }
    float b = num1 / (float) num2 + feature.Height / heightmapScale.y;
    for (int index3 = -feature.Radius; index3 <= feature.Radius; ++index3)
    {
      int index4 = index3 + spawnY;
      float v = Mathf.Clamp01((float) (index3 + feature.Radius) / ((float) feature.Radius * 2f));
      for (int index5 = -feature.Radius; index5 <= feature.Radius; ++index5)
      {
        int index6 = index5 + spawnX;
        float u = Mathf.Clamp01((float) (index5 + feature.Radius) / ((float) feature.Radius * 2f));
        float r = feature.HeightMap.GetPixelBilinear(u, v).r;
        heightMap[index6, index4] = Mathf.Lerp(heightMap[index6, index4], b, r);
      }
    }
  }

  public override void Execute(
    ProcGenConfigSO globalConfig,
    int mapResolution,
    float[,] heightMap,
    Vector3 heightmapScale,
    byte[,] biomeMap = null,
    int biomeIndex = -1,
    BiomeConfigSO biome = null)
  {
    foreach (FeatureConfig feature in this.Features)
    {
      for (int index = 0; index < feature.NumToSpawn; ++index)
      {
        int spawnX = Random.Range(feature.Radius, mapResolution - feature.Radius);
        int spawnY = Random.Range(feature.Radius, mapResolution - feature.Radius);
        this.SpawnFeature(feature, spawnX, spawnY, mapResolution, heightMap, heightmapScale);
      }
    }
  }
}
