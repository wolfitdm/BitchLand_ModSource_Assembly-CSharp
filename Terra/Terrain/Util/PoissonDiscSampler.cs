// Decompiled with JetBrains decompiler
// Type: Terra.Terrain.Util.PoissonDiscSampler
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Terra.Terrain.Util
{
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
      yield return this.AddSample(new Vector2(Random.value * this.rect.width, Random.value * this.rect.height));
      while (this.activeSamples.Count > 0)
      {
        int i = (int) Random.value * this.activeSamples.Count;
        Vector2 activeSample = this.activeSamples[i];
        bool found = false;
        for (int index = 0; index < 30; ++index)
        {
          float f = 6.28318548f * Random.value;
          float num = Mathf.Sqrt(Random.value * 3f * this.radius2 + this.radius2);
          Vector2 vector2 = activeSample + num * new Vector2(Mathf.Cos(f), Mathf.Sin(f));
          if (this.rect.Contains(vector2) && this.IsFarEnough(vector2))
          {
            found = true;
            yield return this.AddSample(vector2);
            break;
          }
        }
        if (!found)
        {
          this.activeSamples[i] = this.activeSamples[this.activeSamples.Count - 1];
          this.activeSamples.RemoveAt(this.activeSamples.Count - 1);
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
}
