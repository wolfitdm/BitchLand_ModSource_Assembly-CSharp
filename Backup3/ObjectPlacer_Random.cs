// Decompiled with JetBrains decompiler
// Type: ObjectPlacer_Random
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class ObjectPlacer_Random : BaseObjectPlacer
{
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
    List<Vector3> locationsForBiome = this.GetAllLocationsForBiome(globalConfig, mapResolution, heightMap, heightmapScale, biomeMap, biomeIndex);
    this.ExecuteSimpleSpawning(globalConfig, objectRoot, locationsForBiome);
  }
}
