// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Voronoi.VoronoiDiagramBase2D
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace Terra.CoherentNoise.Generation.Voronoi
{
  public abstract class VoronoiDiagramBase2D : Generator
  {
    private readonly LatticeNoise[] m_ControlPointSource;

    protected VoronoiDiagramBase2D(int seed)
    {
      this.Frequency = 1f;
      this.m_ControlPointSource = new LatticeNoise[2]
      {
        new LatticeNoise(seed),
        new LatticeNoise(seed + 1)
      };
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
      float f1 = float.MaxValue;
      float f2 = float.MaxValue;
      float f3 = float.MaxValue;
      int num1 = Mathf.FloorToInt(x);
      int num2 = Mathf.FloorToInt(y);
      Vector2 vector2_1 = new Vector2(x, y);
      for (int x1 = num1 - 1; x1 < num1 + 2; ++x1)
      {
        for (int y1 = num2 - 1; y1 < num2 + 2; ++y1)
        {
          Vector2 vector2_2 = new Vector2((float) ((double) this.m_ControlPointSource[0].GetValue(x1, y1, 0) * 0.5 + 0.5), (float) ((double) this.m_ControlPointSource[1].GetValue(x1, y1, 0) * 0.5 + 0.5));
          float num3 = Vector2.SqrMagnitude(new Vector2((float) x1, (float) y1) + vector2_2 - vector2_1);
          if ((double) num3 < (double) f1)
          {
            f3 = f2;
            f2 = f1;
            f1 = num3;
          }
          else if ((double) num3 < (double) f2)
          {
            f3 = f2;
            f2 = num3;
          }
          else if ((double) num3 < (double) f3)
            f3 = num3;
        }
      }
      return this.GetResult(Mathf.Sqrt(f1), Mathf.Sqrt(f2), Mathf.Sqrt(f3));
    }

    protected abstract float GetResult(float min1, float min2, float min3);

    public float Frequency { get; set; }
  }
}
