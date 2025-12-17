// Decompiled with JetBrains decompiler
// Type: ObjectPlacer_Perlin
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class ObjectPlacer_Perlin : BaseObjectPlacer
{
  [SerializeField]
  private Vector2 NoiseScale = new Vector2(1f / 128f, 1f / 128f);
  [SerializeField]
  private float NoiseThreshold = 0.5f;

  private List<Vector3> GetFilteredLocationsForBiome(
    ProcGenConfigSO globalConfig,
    int mapResolution,
    float[,] heightMap,
    Vector3 heightmapScale,
    byte[,] biomeMap,
    int biomeIndex)
  {
    List<Vector3> locationsForBiome = new List<Vector3>(mapResolution * mapResolution / 10);
    for (int index1 = 0; index1 < mapResolution; ++index1)
    {
      for (int index2 = 0; index2 < mapResolution; ++index2)
      {
        if ((int) biomeMap[index2, index1] == biomeIndex && (double) Mathf.PerlinNoise((float) index2 * this.NoiseScale.x, (float) index1 * this.NoiseScale.y) >= (double) this.NoiseThreshold)
        {
          float y = heightMap[index2, index1] * heightmapScale.y;
          locationsForBiome.Add(new Vector3((float) index1 * heightmapScale.z, y, (float) index2 * heightmapScale.x));
        }
      }
    }
    return locationsForBiome;
  }

  public override void Execute(
    ProcGenConfigSO globalConfig,
    Transform objectRoot,
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
    base.Execute(globalConfig, objectRoot, mapResolution, heightMap, heightmapScale, slopeMap, alphaMaps, alphaMapResolution, biomeMap, biomeIndex, biome);
    List<Vector3> locationsForBiome = this.GetFilteredLocationsForBiome(globalConfig, mapResolution, heightMap, heightmapScale, biomeMap, biomeIndex);
    this.ExecuteSimpleSpawning(globalConfig, objectRoot, locationsForBiome);
  }
}
