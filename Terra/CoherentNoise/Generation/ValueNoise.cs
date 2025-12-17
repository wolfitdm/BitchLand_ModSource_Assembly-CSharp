// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.ValueNoise
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using Terra.CoherentNoise.Interpolation;
using UnityEngine;

#nullable disable
namespace Terra.CoherentNoise.Generation;

public class ValueNoise : Generator
{
  private readonly LatticeNoise m_Source;
  private readonly SCurve m_SCurve;

  public ValueNoise(int seed)
    : this(seed, (SCurve) null)
  {
  }

  public int Period
  {
    get => this.m_Source.Period;
    set => this.m_Source.Period = value;
  }

  public ValueNoise(int seed, SCurve sCurve)
  {
    this.m_Source = new LatticeNoise(seed);
    this.m_SCurve = sCurve;
  }

  private SCurve SCurve => this.m_SCurve ?? SCurve.Default;

  public override float GetValue(float x, float y, float z)
  {
    int x1 = Mathf.FloorToInt(x);
    int y1 = Mathf.FloorToInt(y);
    int z1 = Mathf.FloorToInt(z);
    float t1 = this.SCurve.Interpolate(x - (float) x1);
    float t2 = this.SCurve.Interpolate(y - (float) y1);
    float t3 = this.SCurve.Interpolate(z - (float) z1);
    return Mathf.Lerp(Mathf.Lerp(Mathf.Lerp(this.m_Source.GetValue(x1, y1, z1), this.m_Source.GetValue(x1 + 1, y1, z1), t1), Mathf.Lerp(this.m_Source.GetValue(x1, y1 + 1, z1), this.m_Source.GetValue(x1 + 1, y1 + 1, z1), t1), t2), Mathf.Lerp(Mathf.Lerp(this.m_Source.GetValue(x1, y1, z1 + 1), this.m_Source.GetValue(x1 + 1, y1, z1 + 1), t1), Mathf.Lerp(this.m_Source.GetValue(x1, y1 + 1, z1 + 1), this.m_Source.GetValue(x1 + 1, y1 + 1, z1 + 1), t1), t2), t3);
  }
}
