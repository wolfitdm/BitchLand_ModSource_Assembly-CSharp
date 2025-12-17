// Decompiled with JetBrains decompiler
// Type: Assets.Scripts.MapGenerator.Maps.PerlinMap
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using Assets.Scripts.MapGenerator.Abstract;
using UnityEngine;

#nullable disable
namespace Assets.Scripts.MapGenerator.Maps;

public class PerlinMap : IMap
{
  public int Size { get; set; }

  public int Octaves { get; set; }

  public float Scale { get; set; }

  public float Offset { get; set; }

  public float OffsetY { get; set; }

  public float Persistance { get; set; }

  public float Lacunarity { get; set; }

  public float[,] Generate() => this.GenerateNoise(out float _, out float _);

  public float[,] Generate(out float maxLocalNoiseHeight, out float minLocalNoiseHeight)
  {
    return this.GenerateNoise(out maxLocalNoiseHeight, out minLocalNoiseHeight);
  }

  private float[,] GenerateNoise(out float maxLocalNoiseHeight, out float minLocalNoiseHeight)
  {
    float[,] noise = new float[this.Size, this.Size];
    Vector2[] vector2Array = new Vector2[this.Octaves];
    float num1 = 0.0f;
    float num2 = 1f;
    for (int index = 0; index < this.Octaves; ++index)
    {
      vector2Array[index] = new Vector2(this.Offset, this.OffsetY);
      num1 += num2;
      num2 *= this.Persistance;
    }
    if ((double) this.Scale <= 0.0)
      this.Scale = 0.0001f;
    maxLocalNoiseHeight = float.MinValue;
    minLocalNoiseHeight = float.MaxValue;
    float num3 = (float) this.Size / 2f;
    for (int index1 = 0; index1 < this.Size; ++index1)
    {
      for (int index2 = 0; index2 < this.Size; ++index2)
      {
        float num4 = 1f;
        float num5 = 1f;
        float num6 = 0.0f;
        for (int index3 = 0; index3 < this.Octaves; ++index3)
        {
          float num7 = (float) ((double) Mathf.PerlinNoise(((float) index2 - num3 + vector2Array[index3].x) / this.Scale * num5, ((float) index1 - num3 + vector2Array[index3].y) / this.Scale * num5) * 2.0 - 1.0);
          num6 += num7 * num4;
          num4 *= this.Persistance;
          num5 *= this.Lacunarity;
        }
        if ((double) num6 > (double) maxLocalNoiseHeight)
          maxLocalNoiseHeight = num6;
        else if ((double) num6 < (double) minLocalNoiseHeight)
          minLocalNoiseHeight = num6;
        noise[index2, index1] = num6;
      }
    }
    return noise;
  }
}
