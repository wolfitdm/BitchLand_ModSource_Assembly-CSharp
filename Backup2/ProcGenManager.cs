// Decompiled with JetBrains decompiler
// Type: ProcGenManager
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#nullable disable
public class ProcGenManager : MonoBehaviour
{
  [SerializeField]
  private ProcGenConfigSO Config;
  [SerializeField]
  private Terrain TargetTerrain;
  [Header("Debugging")]
  [SerializeField]
  private bool DEBUG_TurnOffObjectPlacers;
  private Dictionary<TextureConfig, int> BiomeTextureToTerrainLayerIndex = new Dictionary<TextureConfig, int>();
  private byte[,] BiomeMap_LowResolution;
  private float[,] BiomeStrengths_LowResolution;
  private byte[,] BiomeMap;
  private float[,] BiomeStrengths;
  private float[,] SlopeMap;
  private Vector2Int[] NeighbourOffsets = new Vector2Int[8]
  {
    new Vector2Int(0, 1),
    new Vector2Int(0, -1),
    new Vector2Int(1, 0),
    new Vector2Int(-1, 0),
    new Vector2Int(1, 1),
    new Vector2Int(-1, -1),
    new Vector2Int(1, -1),
    new Vector2Int(-1, 1)
  };

  private void Start()
  {
  }

  private void Update()
  {
  }

  public IEnumerator AsyncRegenerateWorld(Action<int, int, string> reportStatusFn = null)
  {
    ProcGenManager procGenManager = this;
    int mapResolution = procGenManager.TargetTerrain.terrainData.heightmapResolution;
    int alphaMapResolution = procGenManager.TargetTerrain.terrainData.alphamapResolution;
    if (reportStatusFn != null)
      reportStatusFn(1, 7, "Beginning Generation");
    yield return (object) new WaitForSeconds(1f);
    for (int index = procGenManager.transform.childCount - 1; index >= 0; --index)
      UnityEngine.Object.Destroy((UnityEngine.Object) procGenManager.transform.GetChild(index).gameObject);
    if (reportStatusFn != null)
      reportStatusFn(2, 7, "Building texture map");
    yield return (object) new WaitForSeconds(1f);
    procGenManager.Perform_GenerateTextureMapping();
    if (reportStatusFn != null)
      reportStatusFn(3, 7, "Build low res biome map");
    yield return (object) new WaitForSeconds(1f);
    procGenManager.Perform_BiomeGeneration_LowResolution((int) procGenManager.Config.BiomeMapResolution);
    if (reportStatusFn != null)
      reportStatusFn(4, 7, "Build high res biome map");
    yield return (object) new WaitForSeconds(1f);
    procGenManager.Perform_BiomeGeneration_HighResolution((int) procGenManager.Config.BiomeMapResolution, mapResolution);
    if (reportStatusFn != null)
      reportStatusFn(5, 7, "Modifying heights");
    yield return (object) new WaitForSeconds(1f);
    procGenManager.Perform_HeightMapModification(mapResolution, alphaMapResolution);
    if (reportStatusFn != null)
      reportStatusFn(6, 7, "Painting the terrain");
    yield return (object) new WaitForSeconds(1f);
    procGenManager.Perform_TerrainPainting(mapResolution, alphaMapResolution);
    if (reportStatusFn != null)
      reportStatusFn(7, 7, "Placing objects");
    yield return (object) new WaitForSeconds(1f);
    procGenManager.Perform_ObjectPlacement(mapResolution, alphaMapResolution);
    if (reportStatusFn != null)
      reportStatusFn(7, 7, "Generation complete");
  }

  private void Perform_GenerateTextureMapping()
  {
    this.BiomeTextureToTerrainLayerIndex.Clear();
    List<TextureConfig> source = new List<TextureConfig>();
    foreach (BiomeConfig biome in this.Config.Biomes)
    {
      List<TextureConfig> collection = biome.Biome.RetrieveTextures();
      if (collection != null && collection.Count != 0)
        source.AddRange((IEnumerable<TextureConfig>) collection);
    }
    if ((UnityEngine.Object) this.Config.PaintingPostProcessingModifier != (UnityEngine.Object) null)
    {
      foreach (BaseTexturePainter component in this.Config.PaintingPostProcessingModifier.GetComponents<BaseTexturePainter>())
      {
        List<TextureConfig> collection = component.RetrieveTextures();
        if (collection != null && collection.Count != 0)
          source.AddRange((IEnumerable<TextureConfig>) collection);
      }
    }
    List<TextureConfig> list = source.Distinct<TextureConfig>().ToList<TextureConfig>();
    int num = 0;
    foreach (TextureConfig key in list)
    {
      this.BiomeTextureToTerrainLayerIndex[key] = num;
      ++num;
    }
  }

  private void Perform_BiomeGeneration_LowResolution(int mapResolution)
  {
    this.BiomeMap_LowResolution = new byte[mapResolution, mapResolution];
    this.BiomeStrengths_LowResolution = new float[mapResolution, mapResolution];
    int capacity = Mathf.FloorToInt((float) (mapResolution * mapResolution) * this.Config.BiomeSeedPointDensity);
    List<byte> byteList = new List<byte>(capacity);
    float totalWeighting = this.Config.TotalWeighting;
    for (int index1 = 0; index1 < this.Config.NumBiomes; ++index1)
    {
      int num = Mathf.RoundToInt((float) capacity * this.Config.Biomes[index1].Weighting / totalWeighting);
      for (int index2 = 0; index2 < num; ++index2)
        byteList.Add((byte) index1);
    }
    while (byteList.Count > 0)
    {
      int index = UnityEngine.Random.Range(0, byteList.Count);
      byte biomeIndex = byteList[index];
      byteList.RemoveAt(index);
      this.Perform_SpawnIndividualBiome(biomeIndex, mapResolution);
    }
  }

  private void Perform_SpawnIndividualBiome(byte biomeIndex, int mapResolution)
  {
    BiomeConfigSO biome = this.Config.Biomes[(int) biomeIndex].Biome;
    Vector2Int vector2Int1 = new Vector2Int(UnityEngine.Random.Range(0, mapResolution), UnityEngine.Random.Range(0, mapResolution));
    float num1 = UnityEngine.Random.Range(biome.MinIntensity, biome.MaxIntensity);
    Queue<Vector2Int> vector2IntQueue = new Queue<Vector2Int>();
    vector2IntQueue.Enqueue(vector2Int1);
    bool[,] flagArray = new bool[mapResolution, mapResolution];
    float[,] numArray = new float[mapResolution, mapResolution];
    numArray[vector2Int1.x, vector2Int1.y] = num1;
    while (vector2IntQueue.Count > 0)
    {
      Vector2Int vector2Int2 = vector2IntQueue.Dequeue();
      this.BiomeMap_LowResolution[vector2Int2.x, vector2Int2.y] = biomeIndex;
      flagArray[vector2Int2.x, vector2Int2.y] = true;
      this.BiomeStrengths_LowResolution[vector2Int2.x, vector2Int2.y] = numArray[vector2Int2.x, vector2Int2.y];
      for (int index = 0; index < this.NeighbourOffsets.Length; ++index)
      {
        Vector2Int vector2Int3 = vector2Int2 + this.NeighbourOffsets[index];
        if (vector2Int3.x >= 0 && vector2Int3.y >= 0 && vector2Int3.x < mapResolution && vector2Int3.y < mapResolution && !flagArray[vector2Int3.x, vector2Int3.y])
        {
          flagArray[vector2Int3.x, vector2Int3.y] = true;
          float num2 = UnityEngine.Random.Range(biome.MinDecayRate, biome.MaxDecayRate) * this.NeighbourOffsets[index].magnitude;
          float num3 = numArray[vector2Int2.x, vector2Int2.y] - num2;
          numArray[vector2Int3.x, vector2Int3.y] = num3;
          if ((double) num3 > 0.0)
            vector2IntQueue.Enqueue(vector2Int3);
        }
      }
    }
  }

  private byte CalculateHighResBiomeIndex(
    int lowResMapSize,
    int lowResX,
    int lowResY,
    float fractionX,
    float fractionY)
  {
    float num1 = (float) this.BiomeMap_LowResolution[lowResX, lowResY];
    float num2 = lowResX + 1 < lowResMapSize ? (float) this.BiomeMap_LowResolution[lowResX + 1, lowResY] : num1;
    float num3 = lowResY + 1 < lowResMapSize ? (float) this.BiomeMap_LowResolution[lowResX, lowResY + 1] : num1;
    float num4 = lowResX + 1 < lowResMapSize ? (lowResY + 1 < lowResMapSize ? (float) this.BiomeMap_LowResolution[lowResX + 1, lowResY + 1] : num2) : num3;
    float num5 = (float) ((double) num1 * (1.0 - (double) fractionX) * (1.0 - (double) fractionY) + (double) num2 * (double) fractionX * (1.0 - (double) fractionY) * (double) num3 * (double) fractionY * (1.0 - (double) fractionX) + (double) num4 * (double) fractionX * (double) fractionY);
    float[] numArray = new float[4]
    {
      num1,
      num2,
      num3,
      num4
    };
    float f = -1f;
    float num6 = float.MaxValue;
    for (int index = 0; index < numArray.Length; ++index)
    {
      float num7 = Mathf.Abs(num5 - numArray[index]);
      if ((double) num7 < (double) num6)
      {
        num6 = num7;
        f = numArray[index];
      }
    }
    return (byte) Mathf.RoundToInt(f);
  }

  private void Perform_BiomeGeneration_HighResolution(int lowResMapSize, int highResMapSize)
  {
    this.BiomeMap = new byte[highResMapSize, highResMapSize];
    this.BiomeStrengths = new float[highResMapSize, highResMapSize];
    float num = (float) lowResMapSize / (float) highResMapSize;
    for (int index1 = 0; index1 < highResMapSize; ++index1)
    {
      int lowResY = Mathf.FloorToInt((float) index1 * num);
      float fractionY = (float) index1 * num - (float) lowResY;
      for (int index2 = 0; index2 < highResMapSize; ++index2)
      {
        int lowResX = Mathf.FloorToInt((float) index2 * num);
        float fractionX = (float) index2 * num - (float) lowResX;
        this.BiomeMap[index2, index1] = this.CalculateHighResBiomeIndex(lowResMapSize, lowResX, lowResY, fractionX, fractionY);
      }
    }
  }

  private void Perform_HeightMapModification(int mapResolution, int alphaMapResolution)
  {
    float[,] heights = this.TargetTerrain.terrainData.GetHeights(0, 0, mapResolution, mapResolution);
    if ((UnityEngine.Object) this.Config.InitialHeightModifier != (UnityEngine.Object) null)
    {
      foreach (BaseHeightMapModifier component in this.Config.InitialHeightModifier.GetComponents<BaseHeightMapModifier>())
        component.Execute(this.Config, mapResolution, heights, this.TargetTerrain.terrainData.heightmapScale);
    }
    for (int index = 0; index < this.Config.NumBiomes; ++index)
    {
      BiomeConfigSO biome = this.Config.Biomes[index].Biome;
      if (!((UnityEngine.Object) biome.HeightModifier == (UnityEngine.Object) null))
      {
        foreach (BaseHeightMapModifier component in biome.HeightModifier.GetComponents<BaseHeightMapModifier>())
          component.Execute(this.Config, mapResolution, heights, this.TargetTerrain.terrainData.heightmapScale, this.BiomeMap, index, biome);
      }
    }
    if ((UnityEngine.Object) this.Config.HeightPostProcessingModifier != (UnityEngine.Object) null)
    {
      foreach (BaseHeightMapModifier component in this.Config.HeightPostProcessingModifier.GetComponents<BaseHeightMapModifier>())
        component.Execute(this.Config, mapResolution, heights, this.TargetTerrain.terrainData.heightmapScale);
    }
    this.TargetTerrain.terrainData.SetHeights(0, 0, heights);
    this.SlopeMap = new float[alphaMapResolution, alphaMapResolution];
    for (int index1 = 0; index1 < alphaMapResolution; ++index1)
    {
      for (int index2 = 0; index2 < alphaMapResolution; ++index2)
        this.SlopeMap[index2, index1] = this.TargetTerrain.terrainData.GetInterpolatedNormal((float) index2 / (float) alphaMapResolution, (float) index1 / (float) alphaMapResolution).y;
    }
  }

  public int GetLayerForTexture(TextureConfig textureConfig)
  {
    return this.BiomeTextureToTerrainLayerIndex[textureConfig];
  }

  private void Perform_TerrainPainting(int mapResolution, int alphaMapResolution)
  {
    float[,] heights = this.TargetTerrain.terrainData.GetHeights(0, 0, mapResolution, mapResolution);
    float[,,] alphamaps = this.TargetTerrain.terrainData.GetAlphamaps(0, 0, alphaMapResolution, alphaMapResolution);
    for (int index1 = 0; index1 < alphaMapResolution; ++index1)
    {
      for (int index2 = 0; index2 < alphaMapResolution; ++index2)
      {
        for (int index3 = 0; index3 < this.TargetTerrain.terrainData.alphamapLayers; ++index3)
          alphamaps[index2, index1, index3] = 0.0f;
      }
    }
    for (int index = 0; index < this.Config.NumBiomes; ++index)
    {
      BiomeConfigSO biome = this.Config.Biomes[index].Biome;
      if (!((UnityEngine.Object) biome.TerrainPainter == (UnityEngine.Object) null))
      {
        foreach (BaseTexturePainter component in biome.TerrainPainter.GetComponents<BaseTexturePainter>())
          component.Execute(this, mapResolution, heights, this.TargetTerrain.terrainData.heightmapScale, this.SlopeMap, alphamaps, alphaMapResolution, this.BiomeMap, index, biome);
      }
    }
    if ((UnityEngine.Object) this.Config.PaintingPostProcessingModifier != (UnityEngine.Object) null)
    {
      foreach (BaseTexturePainter component in this.Config.PaintingPostProcessingModifier.GetComponents<BaseTexturePainter>())
        component.Execute(this, mapResolution, heights, this.TargetTerrain.terrainData.heightmapScale, this.SlopeMap, alphamaps, alphaMapResolution);
    }
    this.TargetTerrain.terrainData.SetAlphamaps(0, 0, alphamaps);
  }

  private void Perform_ObjectPlacement(int mapResolution, int alphaMapResolution)
  {
    if (this.DEBUG_TurnOffObjectPlacers)
      return;
    float[,] heights = this.TargetTerrain.terrainData.GetHeights(0, 0, mapResolution, mapResolution);
    float[,,] alphamaps = this.TargetTerrain.terrainData.GetAlphamaps(0, 0, alphaMapResolution, alphaMapResolution);
    for (int index = 0; index < this.Config.NumBiomes; ++index)
    {
      BiomeConfigSO biome = this.Config.Biomes[index].Biome;
      if (!((UnityEngine.Object) biome.ObjectPlacer == (UnityEngine.Object) null))
      {
        foreach (BaseObjectPlacer component in biome.ObjectPlacer.GetComponents<BaseObjectPlacer>())
          component.Execute(this.Config, this.transform, mapResolution, heights, this.TargetTerrain.terrainData.heightmapScale, this.SlopeMap, alphamaps, alphaMapResolution, this.BiomeMap, index, biome);
      }
    }
  }
}
