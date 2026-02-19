// Decompiled with JetBrains decompiler
// Type: Terra.Terrain.Util.PoissonDiscSampler
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Terra.Terrain.Util;

public class PoissonDiscSampler
{
  private const int k = 30;
  private readonly Rect rect;
  private readonly float radius2;
  private readonly float cellSize;
  private Vector2[,] grid;
  private List<Vector2> activeSamples = new List<Vector2>();

  public PoissonDiscSampler(float width, float height, float radius)
  {
    this.rect = new Rect(0.0f, 0.0f, width, height);
    this.radius2 = radius * radius;
    this.cellSize = radius / Mathf.Sqrt(2f);
    this.grid = new Vector2[Mathf.CeilToInt(width / this.cellSize), Mathf.CeilToInt(height / this.cellSize)];
  }

  public IEnumerable<Vector2> Samples()
  {
    PoissonDiscSampler poissonDiscSampler1 = this;
    PoissonDiscSampler poissonDiscSampler2 = poissonDiscSampler1;
    double num1 = (double) Random.value;
    Rect rect = poissonDiscSampler1.rect;
    double width = (double) rect.width;
    double x = num1 * width;
    double num2 = (double) Random.value;
    rect = poissonDiscSampler1.rect;
    double height = (double) rect.height;
    double y = num2 * height;
    Vector2 sample = new Vector2((float) x, (float) y);
    yield return poissonDiscSampler2.AddSample(sample);
    while (poissonDiscSampler1.activeSamples.Count > 0)
    {
      int i = (int) Random.value * poissonDiscSampler1.activeSamples.Count;
      Vector2 activeSample = poissonDiscSampler1.activeSamples[i];
      bool found = false;
      for (int index = 0; index < 30; ++index)
      {
        float f = 6.28318548f * Random.value;
        float num3 = Mathf.Sqrt(Random.value * 3f * poissonDiscSampler1.radius2 + poissonDiscSampler1.radius2);
        Vector2 vector2 = activeSample + num3 * new Vector2(Mathf.Cos(f), Mathf.Sin(f));
        if (poissonDiscSampler1.rect.Contains(vector2) && poissonDiscSampler1.IsFarEnough(vector2))
        {
          found = true;
          yield return poissonDiscSampler1.AddSample(vector2);
          break;
        }
      }
      if (!found)
      {
        poissonDiscSampler1.activeSamples[i] = poissonDiscSampler1.activeSamples[poissonDiscSampler1.activeSamples.Count - 1];
        poissonDiscSampler1.activeSamples.RemoveAt(poissonDiscSampler1.activeSamples.Count - 1);
      }
    }
  }

  private bool IsFarEnough(Vector2 sample)
  {
    PoissonDiscSampler.GridPos gridPos = new PoissonDiscSampler.GridPos(sample, this.cellSize);
    int num1 = Mathf.Max(gridPos.x - 2, 0);
    int num2 = Mathf.Max(gridPos.y - 2, 0);
    int num3 = Mathf.Min(gridPos.x + 2, this.grid.GetLength(0) - 1);
    int num4 = Mathf.Min(gridPos.y + 2, this.grid.GetLength(1) - 1);
    for (int index1 = num2; index1 <= num4; ++index1)
    {
      for (int index2 = num1; index2 <= num3; ++index2)
      {
        Vector2 vector2_1 = this.grid[index2, index1];
        if (vector2_1 != Vector2.zero)
        {
          Vector2 vector2_2 = vector2_1 - sample;
          if ((double) vector2_2.x * (double) vector2_2.x + (double) vector2_2.y * (double) vector2_2.y < (double) this.radius2)
            return false;
        }
      }
    }
    return true;
  }

  private Vector2 AddSample(Vector2 sample)
  {
    this.activeSamples.Add(sample);
    PoissonDiscSampler.GridPos gridPos = new PoissonDiscSampler.GridPos(sample, this.cellSize);
    this.grid[gridPos.x, gridPos.y] = sample;
    return sample;
  }

  private struct GridPos
  {
    public int x;
    public int y;

    public GridPos(Vector2 sample, float cellSize)
    {
      this.x = (int) ((double) sample.x / (double) cellSize);
      this.y = (int) ((double) sample.y / (double) cellSize);
    }
  }
}
