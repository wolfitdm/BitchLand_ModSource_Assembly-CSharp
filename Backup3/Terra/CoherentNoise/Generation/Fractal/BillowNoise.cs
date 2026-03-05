// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Fractal.BillowNoise
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace Terra.CoherentNoise.Generation.Fractal
{
  public class BillowNoise : FractalNoiseBase
  {
    private float m_CurPersistence;

    public BillowNoise(int seed)
      : base(seed)
    {
      this.Persistence = 0.5f;
    }

    public BillowNoise(Generator source)
      : base(source)
    {
      this.Persistence = 0.5f;
    }

    protected override float CombineOctave(int curOctave, float signal, float value)
    {
      if (curOctave == 0)
        this.m_CurPersistence = 1f;
      value += (float) (2.0 * (double) Mathf.Abs(signal) - 1.0) * this.m_CurPersistence;
      this.m_CurPersistence *= this.Persistence;
      return value;
    }

    public float Persistence { get; set; }
  }
}
