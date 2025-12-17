// Decompiled with JetBrains decompiler
// Type: Assets.Scripts.MapGenerator.Generators.TexturesGenerator
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Assets.Scripts.MapGenerator.Generators;

public class TexturesGenerator : MonoBehaviour, IGenerator
{
  public List<_Texture> textures = new List<_Texture>();

  public void Generate()
  {
    if (this.textures == null)
      throw new NullReferenceException("Textures list not setted");
    TerrainData terrainData = Terrain.activeTerrain.terrainData;
    SplatPrototype[] splatPrototypeArray = new SplatPrototype[this.textures.Count];
    for (int index = 0; index < this.textures.Count; ++index)
      splatPrototypeArray[index] = new SplatPrototype()
      {
        texture = this.textures[index].Texture,
        tileSize = this.textures[index].Tilesize
      };
    terrainData.splatPrototypes = splatPrototypeArray;
    if ((double) terrainData.alphamapResolution != (double) terrainData.size.x)
      Debug.LogError((object) "terrainData.alphamapResolution must fit terrain size");
    float[,,] map = new float[terrainData.alphamapWidth, terrainData.alphamapHeight, terrainData.alphamapLayers];
    float y1 = terrainData.size.y;
    for (float x1 = 0.0f; (double) x1 < (double) terrainData.alphamapHeight; ++x1)
    {
      for (float y2 = 0.0f; (double) y2 < (double) terrainData.alphamapWidth; ++y2)
      {
        float time1 = terrainData.GetHeight((int) x1, (int) y2) / y1;
        float x2 = x1 / (float) terrainData.heightmapResolution;
        float y3 = y2 / (float) terrainData.heightmapResolution;
        float time2 = terrainData.GetSteepness(x2, y3) / 90f;
        for (int index1 = 0; index1 < terrainData.alphamapLayers; ++index1)
        {
          switch (this.textures[index1].Type)
          {
            case 0:
              if (index1 != 0)
              {
                map[(int) y2, (int) x1, index1] = this.textures[index1].HeightCurve.Evaluate(time1);
                for (int index2 = 0; index2 < index1; ++index2)
                  map[(int) y2, (int) x1, index2] *= (float) (((double) map[(int) y2, (int) x1, index1] - 1.0) / -1.0);
                break;
              }
              map[(int) y2, (int) x1, index1] = this.textures[index1].HeightCurve.Evaluate(time1);
              break;
            case 1:
              map[(int) y2, (int) x1, index1] = this.textures[index1].AngleCurve.Evaluate(time2);
              for (int index3 = 0; index3 < index1; ++index3)
                map[(int) y2, (int) x1, index3] *= (float) (((double) map[(int) y2, (int) x1, index1] - 1.0) / -1.0);
              break;
          }
          if ((double) map[(int) y2, (int) x1, index1] > 1.0)
            map[(int) y2, (int) x1, index1] = 1f;
        }
      }
    }
    terrainData.SetAlphamaps(0, 0, map);
  }

  public void Clear()
  {
    this.textures = new List<_Texture>();
    this.Generate();
  }
}
