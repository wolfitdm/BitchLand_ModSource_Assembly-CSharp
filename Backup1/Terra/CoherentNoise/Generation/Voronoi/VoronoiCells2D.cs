// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Voronoi.VoronoiCells2D
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace Terra.CoherentNoise.Generation.Voronoi
{
  public class VoronoiCells2D : Generator
  {
    private readonly Func<int, int, float> m_CellValueSource;
    private readonly LatticeNoise[] m_ControlPointSource;

    public VoronoiCells2D(int seed, Func<int, int, float> cellValueSource)
    {
      this.Frequency = 1f;
      this.m_ControlPointSource = new LatticeNoise[2]
      {
        new LatticeNoise(seed),
        new LatticeNoise(seed + 1)
      };
      this.m_CellValueSource = cellValueSource;
    }

    public int Period { get; set; }

    public override float GetValue(float x, float y, float z)
    {
      if (this.Period > 0)
      {
        x %= (float) this.Period;
        if ((double) x < 0.0)
          x += (float) this.Period;
        y %= (float) this.Period;
        if ((double) y < 0.0)
          y += (float) this.Period;
      }
      x *= this.Frequency;
      y *= this.Frequency;
      float num1 = float.MaxValue;
      int num2 = 0;
      int num3 = 0;
      int num4 = Mathf.FloorToInt(x);
      int num5 = Mathf.FloorToInt(y);
      Vector2 vector2_1 = new Vector2(x, y);
      for (int x1 = num4 - 1; x1 < num4 + 2; ++x1)
      {
        for (int y1 = num5 - 1; y1 < num5 + 2; ++y1)
        {
          Vector2 vector2_2 = new Vector2((float) ((double) this.m_ControlPointSource[0].GetValue(x1, y1, 0) * 0.5 + 0.5), (float) ((double) this.m_ControlPointSource[1].GetValue(x1, y1, 0) * 0.5 + 0.5));
          float num6 = Vector2.SqrMagnitude(new Vector2((float) x1, (float) y1) + vector2_2 - vector2_1);
          if ((double) num6 < (double) num1)
          {
            num1 = num6;
            num2 = x1;
            num3 = y1;
          }
        }
      }
      return this.m_CellValueSource(num2, num3);
    }

    public float Frequency { get; set; }
  }
}
