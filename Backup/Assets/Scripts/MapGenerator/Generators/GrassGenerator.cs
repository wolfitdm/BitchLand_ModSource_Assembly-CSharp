// Decompiled with JetBrains decompiler
// Type: Assets.Scripts.MapGenerator.Generators.GrassGenerator
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using Assets.Scripts.MapGenerator.Maps;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Assets.Scripts.MapGenerator.Generators;

public class GrassGenerator : MonoBehaviour, IGenerator
{
  public int Octaves = 4;
  public float Scale = 40f;
  public float Lacunarity = 2f;
  [Range(0.0f, 1f)]
  public float Persistance = 0.5f;
  public float Offset = 100f;
  public float MinLevel;
  public float MaxLevel = 100f;
  [Range(0.0f, 90f)]
  public float MaxSteepness = 70f;
  [Range(-1f, 1f)]
  public float IslandsSize;
  [Range(1f, 100f)]
  public int Density = 10;
  public bool Randomize;
  public bool AutoUpdate;
  public List<Texture2D> GrassTextures;

  public void Generate()
  {
    if (this.Randomize)
      this.Offset = Random.Range(0.0f, 9999f);
    List<DetailPrototype> detailPrototypeList = new List<DetailPrototype>();
    foreach (Texture2D grassTexture in this.GrassTextures)
      detailPrototypeList.Add(new DetailPrototype()
      {
        prototypeTexture = grassTexture
      });
    TerrainData terrainData = Terrain.activeTerrain.terrainData;
    terrainData.detailPrototypes = detailPrototypeList.ToArray();
    float[,] numArray = new PerlinMap()
    {
      Size = terrainData.detailWidth,
      Octaves = this.Octaves,
      Scale = this.Scale,
      Offset = this.Offset,
      Persistance = this.Persistance,
      Lacunarity = this.Lacunarity
    }.Generate();
    for (int layer = 0; layer < terrainData.detailPrototypes.Length; ++layer)
    {
      int[,] detailLayer = terrainData.GetDetailLayer(0, 0, terrainData.detailWidth, terrainData.detailHeight, layer);
      for (int x1 = 0; x1 < terrainData.alphamapWidth; ++x1)
      {
        for (int y1 = 0; y1 < terrainData.alphamapHeight; ++y1)
        {
          float height = terrainData.GetHeight(x1, y1);
          float x2 = ((float) x1 + Random.Range(-1f, 1f)) / (float) terrainData.alphamapWidth;
          float y2 = ((float) y1 + Random.Range(-1f, 1f)) / (float) terrainData.alphamapHeight;
          float steepness = terrainData.GetSteepness(x2, y2);
          detailLayer[x1, y1] = (double) numArray[x1, y1] >= (double) this.IslandsSize || (double) steepness >= (double) this.MaxSteepness || (double) height <= (double) this.MinLevel || (double) height >= (double) this.MaxLevel ? 0 : this.Density;
        }
      }
      terrainData.SetDetailLayer(0, 0, layer, detailLayer);
    }
  }

  public void Clear()
  {
    Terrain.activeTerrain.terrainData.detailPrototypes = (DetailPrototype[]) null;
  }
}
