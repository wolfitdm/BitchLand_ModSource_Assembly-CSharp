// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Fractal.PinkNoise
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Terra.CoherentNoise.Generation.Fractal;

public class PinkNoise : FractalNoiseBase
{
  private float m_CurPersistence;

  public PinkNoise(int seed)
    : base(seed)
  {
    this.Persistence = 0.5f;
  }

  public PinkNoise(Generator source)
    : base(source)
  {
    this.Persistence = 0.5f;
  }

  protected override float CombineOctave(int curOctave, float signal, float value)
  {
    if (curOctave == 0)
      this.m_CurPersistence = 1f;
    value += signal * this.m_CurPersistence;
    this.m_CurPersistence *= this.Persistence;
    return value;
  }

  public float Persistence { get; set; }
}
