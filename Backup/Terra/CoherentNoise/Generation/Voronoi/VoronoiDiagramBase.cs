// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Voronoi.VoronoiDiagramBase
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace Terra.CoherentNoise.Generation.Voronoi;

public abstract class VoronoiDiagramBase : Generator
{
  private readonly LatticeNoise[] m_ControlPointSource;

  protected VoronoiDiagramBase(int seed)
  {
    this.Frequency = 1f;
    this.m_ControlPointSource = new LatticeNoise[3]
    {
      new LatticeNoise(seed),
      new LatticeNoise(seed + 1),
      new LatticeNoise(seed + 2)
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
      z %= (float) this.Period;
      if ((double) z < 0.0)
        z += (float) this.Period;
    }
    x *= this.Frequency;
    y *= this.Frequency;
    z *= this.Frequency;
    float f1 = float.MaxValue;
    float f2 = float.MaxValue;
    float f3 = float.MaxValue;
    int num1 = Mathf.FloorToInt(x);
    int num2 = Mathf.FloorToInt(y);
    int num3 = Mathf.FloorToInt(z);
    Vector3 vector3_1 = new Vector3(x, y, z);
    for (int x1 = num1 - 1; x1 < num1 + 2; ++x1)
    {
      for (int y1 = num2 - 1; y1 < num2 + 2; ++y1)
      {
        for (int z1 = num3 - 1; z1 < num3 + 2; ++z1)
        {
          Vector3 vector3_2 = new Vector3((float) ((double) this.m_ControlPointSource[0].GetValue(x1, y1, z1) * 0.5 + 0.5), (float) ((double) this.m_ControlPointSource[1].GetValue(x1, y1, z1) * 0.5 + 0.5), (float) ((double) this.m_ControlPointSource[2].GetValue(x1, y1, z1) * 0.5 + 0.5));
          float num4 = Vector3.SqrMagnitude(new Vector3((float) x1, (float) y1, (float) z1) + vector3_2 - vector3_1);
          if ((double) num4 < (double) f1)
          {
            f3 = f2;
            f2 = f1;
            f1 = num4;
          }
          else if ((double) num4 < (double) f2)
          {
            f3 = f2;
            f2 = num4;
          }
          else if ((double) num4 < (double) f3)
            f3 = num4;
        }
      }
    }
    return this.GetResult(Mathf.Sqrt(f1), Mathf.Sqrt(f2), Mathf.Sqrt(f3));
  }

  protected abstract float GetResult(float min1, float min2, float min3);

  public float Frequency { get; set; }
}
