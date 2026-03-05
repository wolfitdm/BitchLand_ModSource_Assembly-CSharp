// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Voronoi.VoronoiCells
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace Terra.CoherentNoise.Generation.Voronoi
{
  public class VoronoiCells : Generator
  {
    private readonly Func<int, int, int, float> m_CellValueSource;
    private readonly LatticeNoise[] m_ControlPointSource;

    public VoronoiCells(int seed, Func<int, int, int, float> cellValueSource)
    {
      this.Frequency = 1f;
      this.m_ControlPointSource = new LatticeNoise[3]
      {
        new LatticeNoise(seed),
        new LatticeNoise(seed + 1),
        new LatticeNoise(seed + 2)
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
        z %= (float) this.Period;
        if ((double) z < 0.0)
          z += (float) this.Period;
      }
      x *= this.Frequency;
      y *= this.Frequency;
      z *= this.Frequency;
      float num1 = float.MaxValue;
      int num2 = 0;
      int num3 = 0;
      int num4 = 0;
      int num5 = Mathf.FloorToInt(x);
      int num6 = Mathf.FloorToInt(y);
      int num7 = Mathf.FloorToInt(z);
      Vector3 vector3_1 = new Vector3(x, y, z);
      for (int x1 = num5 - 1; x1 < num5 + 2; ++x1)
      {
        for (int y1 = num6 - 1; y1 < num6 + 2; ++y1)
        {
          for (int z1 = num7 - 1; z1 < num7 + 2; ++z1)
          {
            Vector3 vector3_2 = new Vector3((float) ((double) this.m_ControlPointSource[0].GetValue(x1, y1, z1) * 0.5 + 0.5), (float) ((double) this.m_ControlPointSource[1].GetValue(x1, y1, z1) * 0.5 + 0.5), (float) ((double) this.m_ControlPointSource[2].GetValue(x1, y1, z1) * 0.5 + 0.5));
            float num8 = Vector3.SqrMagnitude(new Vector3((float) x1, (float) y1, (float) z1) + vector3_2 - vector3_1);
            if ((double) num8 < (double) num1)
            {
              num1 = num8;
              num2 = x1;
              num3 = y1;
              num4 = z1;
            }
          }
        }
      }
      return this.m_CellValueSource(num2, num3, num4);
    }

    public float Frequency { get; set; }
  }
}
