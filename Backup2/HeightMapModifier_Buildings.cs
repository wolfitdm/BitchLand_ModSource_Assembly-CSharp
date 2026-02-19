// Decompiled with JetBrains decompiler
// Type: HeightMapModifier_Buildings
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class HeightMapModifier_Buildings : BaseHeightMapModifier
{
  [SerializeField]
  private List<BuildingConfig> Buildings;

  protected void SpawnBuilding(
    ProcGenConfigSO globalConfig,
    BuildingConfig building,
    int spawnX,
    int spawnY,
    int mapResolution,
    float[,] heightMap,
    Vector3 heightmapScale,
    Transform buildingRoot)
  {
    float num1 = 0.0f;
    int num2 = 0;
    for (int index1 = -building.Radius; index1 <= building.Radius; ++index1)
    {
      for (int index2 = -building.Radius; index2 <= building.Radius; ++index2)
      {
        num1 += heightMap[index2 + spawnX, index1 + spawnY];
        ++num2;
      }
    }
    float num3 = num1 / (float) num2;
    if (!building.CanGoInWater)
      num3 = Mathf.Max(num3, globalConfig.WaterHeight / heightmapScale.y);
    if (building.HasHeightLimits)
      num3 = Mathf.Clamp(num3, building.MinHeightToSpawn / heightmapScale.y, building.MaxHeightToSpawn / heightmapScale.y);
    for (int index3 = -building.Radius; index3 <= building.Radius; ++index3)
    {
      int index4 = index3 + spawnY;
      float v = Mathf.Clamp01((float) (index3 + building.Radius) / ((float) building.Radius * 2f));
      for (int index5 = -building.Radius; index5 <= building.Radius; ++index5)
      {
        int index6 = index5 + spawnX;
        float u = Mathf.Clamp01((float) (index5 + building.Radius) / ((float) building.Radius * 2f));
        float r = building.HeightMap.GetPixelBilinear(u, v).r;
        heightMap[index6, index4] = Mathf.Lerp(heightMap[index6, index4], num3, r);
      }
    }
    Vector3 position = new Vector3((float) spawnY * heightmapScale.z, heightMap[spawnX, spawnY] * heightmapScale.y, (float) spawnX * heightmapScale.x);
    Object.Instantiate<GameObject>(building.Prefab, position, Quaternion.identity, buildingRoot);
  }

  protected List<Vector2Int> GetSpawnLocationsForBuilding(
    ProcGenConfigSO globalConfig,
    int mapResolution,
    float[,] heightMap,
    Vector3 heightmapScale,
    BuildingConfig buildingConfig)
  {
    List<Vector2Int> locationsForBuilding = new List<Vector2Int>(mapResolution * mapResolution / 10);
    for (int radius1 = buildingConfig.Radius; radius1 < mapResolution - buildingConfig.Radius; radius1 += buildingConfig.Radius * 2)
    {
      for (int radius2 = buildingConfig.Radius; radius2 < mapResolution - buildingConfig.Radius; radius2 += buildingConfig.Radius * 2)
      {
        float num = heightMap[radius2, radius1] * heightmapScale.y;
        if (((double) num >= (double) globalConfig.WaterHeight || buildingConfig.CanGoInWater) && ((double) num < (double) globalConfig.WaterHeight || buildingConfig.CanGoAboveWater) && (!buildingConfig.HasHeightLimits || (double) num >= (double) buildingConfig.MinHeightToSpawn && (double) num < (double) buildingConfig.MaxHeightToSpawn))
          locationsForBuilding.Add(new Vector2Int(radius2, radius1));
      }
    }
    return locationsForBuilding;
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
    Transform transform = Object.FindObjectOfType<ProcGenManager>().transform;
    using (List<BuildingConfig>.Enumerator enumerator = this.Buildings.GetEnumerator())
    {
label_5:
      while (enumerator.MoveNext())
      {
        BuildingConfig current = enumerator.Current;
        List<Vector2Int> locationsForBuilding = this.GetSpawnLocationsForBuilding(globalConfig, mapResolution, heightMap, heightmapScale, current);
        int num = 0;
        while (true)
        {
          if (num < current.NumToSpawn && locationsForBuilding.Count > 0)
          {
            int index = Random.Range(0, locationsForBuilding.Count);
            Vector2Int vector2Int = locationsForBuilding[index];
            locationsForBuilding.RemoveAt(index);
            this.SpawnBuilding(globalConfig, current, vector2Int.x, vector2Int.y, mapResolution, heightMap, heightmapScale, transform);
            ++num;
          }
          else
            goto label_5;
        }
      }
    }
  }
}
