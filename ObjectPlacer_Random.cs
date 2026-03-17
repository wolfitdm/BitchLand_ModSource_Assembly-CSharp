// Decompiled with JetBrains decompiler
// Type: ObjectPlacer_Random
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
