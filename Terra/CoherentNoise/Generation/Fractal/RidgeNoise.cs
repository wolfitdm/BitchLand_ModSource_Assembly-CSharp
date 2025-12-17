// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Fractal.RidgeNoise
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace Terra.CoherentNoise.Generation.Fractal;

public class RidgeNoise : FractalNoiseBase
{
  private float m_Exponent;
  private float[] m_SpectralWeights;
  private float m_Weight;

  public RidgeNoise(int seed)
    : base(seed)
  {
    this.Offset = 1f;
    this.Gain = 2f;
    this.Exponent = 1f;
  }

  public RidgeNoise(Generator source)
    : base(source)
  {
    this.Offset = 1f;
    this.Gain = 2f;
    this.Exponent = 1f;
  }

  public float Exponent
  {
    get => this.m_Exponent;
    set
    {
      this.m_Exponent = value;
      this.OnParamsChanged();
    }
  }

  public float Offset { get; set; }

  public float Gain { get; set; }

  protected override float CombineOctave(int curOctave, float signal, float value)
  {
    if (curOctave == 0)
      this.m_Weight = 1f;
    signal = this.Offset - Mathf.Abs(signal);
    signal *= signal;
    signal *= this.m_Weight;
    this.m_Weight = signal * this.Gain;
    if ((double) this.m_Weight > 1.0)
      this.m_Weight = 1f;
    if ((double) this.m_Weight < 0.0)
      this.m_Weight = 0.0f;
    return value + signal * this.m_SpectralWeights[curOctave];
  }

  protected override void OnParamsChanged() => this.PrecalculateWeights();

  private void PrecalculateWeights()
  {
    float f = 1f;
    this.m_SpectralWeights = new float[this.OctaveCount];
    for (int index = 0; index < this.OctaveCount; ++index)
    {
      this.m_SpectralWeights[index] = Mathf.Pow(f, -this.Exponent);
      f *= this.Lacunarity;
    }
  }
}
