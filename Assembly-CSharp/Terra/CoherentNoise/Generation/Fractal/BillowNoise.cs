// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Fractal.BillowNoise
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
