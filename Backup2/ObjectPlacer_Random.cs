// Decompiled with JetBrains decompiler
// Type: ObjectPlacer_Random
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
