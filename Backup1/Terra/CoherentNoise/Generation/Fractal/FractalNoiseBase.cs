// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Fractal.FractalNoiseBase
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace Terra.CoherentNoise.Generation.Fractal
{
  public abstract class FractalNoiseBase : Generator
  {
    private static readonly Quaternion s_Rotation = Quaternion.Euler(30f, 30f, 30f);
    private readonly Generator m_Noise;
    private float m_Frequency;
    private float m_Lacunarity;
    private int m_OctaveCount;

    protected FractalNoiseBase(int seed)
    {
      this.m_Noise = (Generator) new GradientNoise(seed);
      this.Lacunarity = 2.17f;
      this.OctaveCount = 6;
      this.Frequency = 1f;
    }

    protected FractalNoiseBase(Generator source)
    {
      this.m_Noise = source;
      this.Lacunarity = 2.17f;
      this.OctaveCount = 6;
      this.Frequency = 1f;
    }

    public float Lacunarity
    {
      get => this.m_Lacunarity;
      set
      {
        this.m_Lacunarity = value;
        this.OnParamsChanged();
      }
    }

    public int OctaveCount
    {
      get => this.m_OctaveCount;
      set
      {
        this.m_OctaveCount = value;
        this.OnParamsChanged();
      }
    }

    public float Frequency
    {
      get => this.m_Frequency;
      set
      {
        this.m_Frequency = value;
        this.OnParamsChanged();
      }
    }

    public override float GetValue(float x, float y, float z)
    {
      float num = 0.0f;
      x *= this.Frequency;
      y *= this.Frequency;
      z *= this.Frequency;
      for (int curOctave = 0; curOctave < this.OctaveCount; ++curOctave)
      {
        float signal = this.m_Noise.GetValue(x, y, z);
        num = this.CombineOctave(curOctave, signal, num);
        Vector3 vector3 = FractalNoiseBase.s_Rotation * (new Vector3(x, y, z) * this.Lacunarity);
        x = vector3.x;
        y = vector3.y;
        z = vector3.z;
      }
      return num;
    }

    protected abstract float CombineOctave(int curOctave, float signal, float value);

    protected virtual void OnParamsChanged()
    {
    }
  }
}
