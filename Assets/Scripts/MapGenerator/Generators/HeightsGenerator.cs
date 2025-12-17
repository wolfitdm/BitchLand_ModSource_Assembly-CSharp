// Decompiled with JetBrains decompiler
// Type: Assets.Scripts.MapGenerator.Generators.HeightsGenerator
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using Assets.Scripts.MapGenerator.Maps;
using UnityEngine;

#nullable disable
namespace Assets.Scripts.MapGenerator.Generators;

public class HeightsGenerator : MonoBehaviour, IGenerator
{
  public int Width = 256 /*0x0100*/;
  public int Height = 256 /*0x0100*/;
  public int Depth = 10;
  public int Octaves = 4;
  public float Scale = 50f;
  public float Lacunarity = 2f;
  [Range(0.0f, 1f)]
  public float Persistance = 0.5f;
  public AnimationCurve HeightCurve;
  public float Offset = 100f;
  public float OffsetY;
  public float FalloffDirection = 3f;
  public float FalloffRange = 3f;
  public bool UseFalloffMap;
  public bool Randomize;
  public bool AutoUpdate;

  private void OnValidate()
  {
    if (this.Width < 1)
      this.Width = 1;
    if (this.Height < 1)
      this.Height = 1;
    if ((double) this.Lacunarity < 1.0)
      this.Lacunarity = 1f;
    if (this.Octaves < 0)
      this.Octaves = 0;
    if ((double) this.Scale > 0.0)
      return;
    this.Scale = 0.0001f;
  }

  public void Generate()
  {
    if (this.Randomize)
      this.Offset = Random.Range(0.0f, 9999f);
    TerrainData terrainData = Terrain.activeTerrain.terrainData;
    terrainData.heightmapResolution = this.Width + 1;
    terrainData.alphamapResolution = this.Width;
    terrainData.SetDetailResolution(this.Width, 8);
    terrainData.size = new Vector3((float) this.Width, (float) this.Depth, (float) this.Height);
    float[,] falloffMap = (float[,]) null;
    if (this.UseFalloffMap)
      falloffMap = new FalloffMap()
      {
        FalloffDirection = this.FalloffDirection,
        FalloffRange = this.FalloffRange,
        Size = this.Width
      }.Generate();
    terrainData.SetHeights(0, 0, this.GenerateNoise(falloffMap));
  }

  private float[,] GenerateNoise(float[,] falloffMap = null)
  {
    AnimationCurve animationCurve = new AnimationCurve(this.HeightCurve.keys);
    float maxLocalNoiseHeight;
    float minLocalNoiseHeight;
    float[,] noise = new PerlinMap()
    {
      Size = this.Width,
      Octaves = this.Octaves,
      Scale = this.Scale,
      Offset = this.Offset,
      OffsetY = this.OffsetY,
      Persistance = this.Persistance,
      Lacunarity = this.Lacunarity
    }.Generate(out maxLocalNoiseHeight, out minLocalNoiseHeight);
    for (int index1 = 0; index1 < this.Height; ++index1)
    {
      for (int index2 = 0; index2 < this.Width; ++index2)
      {
        float time = Mathf.InverseLerp(minLocalNoiseHeight, maxLocalNoiseHeight, noise[index2, index1]);
        if (falloffMap != null)
          time -= falloffMap[index2, index1];
        noise[index2, index1] = (double) time < 0.0 ? 0.0f : animationCurve.Evaluate(time);
      }
    }
    return noise;
  }

  public void Clear()
  {
    Terrain.activeTerrain.terrainData.SetHeights(0, 0, new float[this.Width, this.Height]);
  }
}
