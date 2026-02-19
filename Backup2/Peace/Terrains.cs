// Decompiled with JetBrains decompiler
// Type: Peace.Terrains
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;
using UnityEngine;

#nullable disable
namespace Peace;

public static class Terrains
{
  private static float[,] InvertAxis(float[,] heights)
  {
    int length1 = heights.GetLength(0);
    int length2 = heights.GetLength(1);
    float[,] numArray = new float[length2, length1];
    for (int index1 = 0; index1 < length2; ++index1)
    {
      for (int index2 = 0; index2 < length1; ++index2)
        numArray[index1, index2] = heights[index2, index1];
    }
    return numArray;
  }

  public static void ReadTerrainData(TerrainData tData, IntPtr handle)
  {
    int resolution = Terrains.terrainGetResolution(handle);
    tData.heightmapResolution = resolution;
    float[,] heights = new float[resolution, resolution];
    Terrains.readTerrain(handle, heights, false);
    tData.SetHeights(0, 0, Terrains.InvertAxis(heights));
  }

  public static void ReadTerrainTextures(
    Terrain terrain,
    IntPtr terrainHandle,
    Collector collector,
    string cacheLocation = null)
  {
    TerrainData terrainData = terrain.terrainData;
    IntPtr material = Terrains.terrainGetMaterial(terrainHandle);
    int layerCount = Terrains.terrainGetLayerCount(terrainHandle);
    TerrainLayer[] terrainLayerArray = new TerrainLayer[layerCount];
    float[,,] map = (float[,,]) null;
    for (int index1 = 0; index1 < layerCount; ++index1)
    {
      string customMap1 = Terrains.materialGetCustomMap(material, "distribution" + index1.ToString());
      IntPtr terrainHandle1 = collector.GetTerrainHandle(customMap1);
      if (terrainHandle1 != IntPtr.Zero)
      {
        int resolution = Terrains.terrainGetResolution(terrainHandle1);
        if (map == null)
        {
          map = new float[resolution, resolution, layerCount];
          terrainData.alphamapResolution = resolution;
        }
        float[,] numArray = new float[resolution, resolution];
        Terrains.readTerrain(terrainHandle1, numArray, false);
        for (int index2 = 0; index2 < resolution; ++index2)
        {
          for (int index3 = 0; index3 < resolution; ++index3)
          {
            map[index2, index3, index1] = numArray[index3, index2];
            for (int index4 = 0; index4 < index1; ++index4)
              map[index2, index3, index4] *= 1f - numArray[index3, index2];
          }
        }
      }
      string customMap2 = Terrains.materialGetCustomMap(material, "texture" + index1.ToString());
      terrainLayerArray[index1] = new TerrainLayer()
      {
        diffuseTexture = collector.GetTexture(customMap2)
      };
    }
    if (layerCount == 0)
      return;
    terrainData.terrainLayers = terrainLayerArray;
    terrainData.SetAlphamaps(0, 0, map);
  }

  internal static void UpdateTerrainBBox(Terrain terrain, BBox bbox)
  {
    terrain.terrainData.size = new Vector3((float) (bbox.xmax - bbox.xmin), (float) (bbox.zmax - bbox.zmin), (float) (bbox.ymax - bbox.ymin));
    terrain.transform.position = new Vector3((float) bbox.xmin, (float) bbox.zmin, (float) bbox.ymin);
  }

  [DllImport("peace")]
  private static extern void readTerrain(IntPtr terrainPtr, [Out] float[,] value, bool applyBbox);

  [DllImport("peace")]
  private static extern int terrainGetResolution(IntPtr terrainPtr);

  [DllImport("peace")]
  private static extern IntPtr terrainGetMaterial(IntPtr terrainPtr);

  [DllImport("peace")]
  private static extern int terrainGetLayerCount(IntPtr terrainPtr);

  [DllImport("peace")]
  internal static extern BBox terrainGetBBox(IntPtr terrainPtr);

  [DllImport("peace")]
  private static extern string materialGetCustomMap(IntPtr materialPtr, string mapName);
}
