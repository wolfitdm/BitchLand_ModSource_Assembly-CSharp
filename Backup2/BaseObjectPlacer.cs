// Decompiled with JetBrains decompiler
// Type: BaseObjectPlacer
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class BaseObjectPlacer : MonoBehaviour
{
  [SerializeField]
  protected List<PlaceableObjectConfig> Objects;
  [SerializeField]
  protected float TargetDensity = 0.1f;
  [SerializeField]
  protected int MaxSpawnCount = 1000;
  [SerializeField]
  protected int MaxInvalidLocationSkips = 10;
  [SerializeField]
  protected float MaxPositionJitter = 0.15f;

  protected List<Vector3> GetAllLocationsForBiome(
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
        if ((int) biomeMap[index2, index1] == biomeIndex)
        {
          float y = heightMap[index2, index1] * heightmapScale.y;
          locationsForBiome.Add(new Vector3((float) index1 * heightmapScale.z, y, (float) index2 * heightmapScale.x));
        }
      }
    }
    return locationsForBiome;
  }

  public virtual void Execute(
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
    foreach (PlaceableObjectConfig placeableObjectConfig in this.Objects)
    {
      if (!placeableObjectConfig.CanGoInWater && !placeableObjectConfig.CanGoAboveWater)
        throw new InvalidOperationException("Object placer forbids both in and out of water. Cannot run!");
    }
    float num = 0.0f;
    foreach (PlaceableObjectConfig placeableObjectConfig in this.Objects)
      num += placeableObjectConfig.Weighting;
    foreach (PlaceableObjectConfig placeableObjectConfig in this.Objects)
      placeableObjectConfig.NormalisedWeighting = placeableObjectConfig.Weighting / num;
  }

  protected virtual void ExecuteSimpleSpawning(
    ProcGenConfigSO globalConfig,
    Transform objectRoot,
    List<Vector3> candidateLocations)
  {
    foreach (PlaceableObjectConfig placeableObjectConfig in this.Objects)
    {
      GameObject prefab = placeableObjectConfig.Prefabs[UnityEngine.Random.Range(0, placeableObjectConfig.Prefabs.Count)];
      float num1 = Mathf.Min((float) this.MaxSpawnCount, (float) candidateLocations.Count * this.TargetDensity);
      int num2 = Mathf.FloorToInt(placeableObjectConfig.NormalisedWeighting * num1);
      int num3 = 0;
      int num4 = 0;
      for (int index1 = 0; index1 < num2; ++index1)
      {
        int index2 = UnityEngine.Random.Range(0, candidateLocations.Count);
        Vector3 candidateLocation = candidateLocations[index2];
        bool flag = true;
        if ((double) candidateLocation.y < (double) globalConfig.WaterHeight && !placeableObjectConfig.CanGoInWater)
          flag = false;
        if ((double) candidateLocation.y >= (double) globalConfig.WaterHeight && !placeableObjectConfig.CanGoAboveWater)
          flag = false;
        if (placeableObjectConfig.HasHeightLimits && ((double) candidateLocation.y < (double) placeableObjectConfig.MinHeightToSpawn || (double) candidateLocation.y >= (double) placeableObjectConfig.MaxHeightToSpawn))
          flag = false;
        if (!flag)
        {
          ++num3;
          --index1;
          if (num3 >= this.MaxInvalidLocationSkips)
            break;
        }
        else
        {
          num3 = 0;
          ++num4;
          candidateLocations.RemoveAt(index2);
          this.SpawnObject(prefab, candidateLocation, objectRoot);
        }
      }
      Debug.Log((object) $"Placed {num4} objects out of {num2}");
    }
  }

  protected virtual void SpawnObject(
    GameObject prefab,
    Vector3 spawnLocation,
    Transform objectRoot)
  {
    Quaternion rotation = Quaternion.Euler(0.0f, UnityEngine.Random.Range(0.0f, 360f), 0.0f);
    Vector3 vector3 = new Vector3(UnityEngine.Random.Range(-this.MaxPositionJitter, this.MaxPositionJitter), 0.0f, UnityEngine.Random.Range(-this.MaxPositionJitter, this.MaxPositionJitter));
    UnityEngine.Object.Instantiate<GameObject>(prefab, spawnLocation + vector3, rotation, objectRoot);
  }
}
