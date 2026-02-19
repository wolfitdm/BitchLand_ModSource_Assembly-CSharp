// Decompiled with JetBrains decompiler
// Type: Assets.Scripts.MapGenerator.Generators.TreeGenerator
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using Assets.Scripts.MapGenerator.Maps;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Assets.Scripts.MapGenerator.Generators
{
  public class TreeGenerator : MonoBehaviour, IGenerator
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
    [Range(0.0f, 1f)]
    public float Density = 0.5f;
    public bool Randomize;
    public bool AutoUpdate;
    public List<GameObject> TreePrototypes;

    public void Generate()
    {
      if (this.Randomize)
        this.Offset = Random.Range(0.0f, 9999f);
      List<TreePrototype> treePrototypeList = new List<TreePrototype>();
      foreach (GameObject treePrototype in this.TreePrototypes)
        treePrototypeList.Add(new TreePrototype()
        {
          prefab = treePrototype
        });
      TerrainData terrainData = Terrain.activeTerrain.terrainData;
      terrainData.treePrototypes = treePrototypeList.ToArray();
      terrainData.treeInstances = new TreeInstance[0];
      List<Vector3> vector3List = new List<Vector3>();
      float[,] numArray = new PerlinMap()
      {
        Size = terrainData.alphamapWidth,
        Octaves = this.Octaves,
        Scale = this.Scale,
        Offset = this.Offset,
        Persistance = this.Persistance,
        Lacunarity = this.Lacunarity
      }.Generate(out float _, out float _);
      for (int x1 = 0; x1 < terrainData.alphamapWidth; ++x1)
      {
        for (int y1 = 0; y1 < terrainData.alphamapHeight; ++y1)
        {
          float height = terrainData.GetHeight(x1, y1);
          float y2 = height / terrainData.size.y;
          float x2 = ((float) x1 + Random.Range(-1f, 1f)) / (float) terrainData.alphamapWidth;
          float num1 = ((float) y1 + Random.Range(-1f, 1f)) / (float) terrainData.alphamapHeight;
          float steepness = terrainData.GetSteepness(x2, num1);
          double num2 = (double) Random.Range(0.0f, 1f);
          float num3 = numArray[x1, y1];
          double density = (double) this.Density;
          if (num2 < density && (double) num3 < (double) this.IslandsSize && (double) steepness < (double) this.MaxSteepness && (double) height > (double) this.MinLevel && (double) height < (double) this.MaxLevel)
            vector3List.Add(new Vector3(x2, y2, num1));
        }
      }
      TreeInstance[] treeInstanceArray = new TreeInstance[vector3List.Count];
      for (int index = 0; index < treeInstanceArray.Length; ++index)
      {
        treeInstanceArray[index].position = vector3List[index];
        treeInstanceArray[index].prototypeIndex = Random.Range(0, treePrototypeList.Count);
        treeInstanceArray[index].color = (Color32) new Color((float) Random.Range(100, (int) byte.MaxValue), (float) Random.Range(100, (int) byte.MaxValue), (float) Random.Range(100, (int) byte.MaxValue));
        treeInstanceArray[index].lightmapColor = (Color32) Color.white;
        treeInstanceArray[index].heightScale = 1f + Random.Range(-0.25f, 0.5f);
        treeInstanceArray[index].widthScale = 1f + Random.Range(-0.5f, 0.25f);
      }
      terrainData.treeInstances = treeInstanceArray;
      Debug.Log((object) (treeInstanceArray.Length.ToString() + " trees were created"));
    }

    public void Clear()
    {
      Terrain.activeTerrain.terrainData.treePrototypes = (TreePrototype[]) null;
    }
  }
}
