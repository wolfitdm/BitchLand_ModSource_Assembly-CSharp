// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.NoiseEx
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace Terra.CoherentNoise
{
  public static class NoiseEx
  {
    public static Generator Scale(this Generator source, float x, float y, float z)
    {
      return (Generator) new Terra.CoherentNoise.Generation.Displacement.Scale(source, x, y, z);
    }

    public static Generator Translate(this Generator source, float x, float y, float z)
    {
      return (Generator) new Terra.CoherentNoise.Generation.Displacement.Translate(source, x, y, z);
    }

    public static Generator Rotate(this Generator source, float x, float y, float z)
    {
      return (Generator) new Terra.CoherentNoise.Generation.Displacement.Rotate(source, x, y, z);
    }

    public static Generator Turbulence(
      this Generator source,
      float frequency,
      float power,
      int seed)
    {
      return (Generator) new Terra.CoherentNoise.Generation.Displacement.Turbulence(source, seed)
      {
        Frequency = frequency,
        Power = power,
        OctaveCount = 6
      };
    }

    public static Generator Turbulence(this Generator source, float frequency, float power)
    {
      return (Generator) new Terra.CoherentNoise.Generation.Displacement.Turbulence(source, Guid.NewGuid().GetHashCode())
      {
        Frequency = frequency,
        Power = power,
        OctaveCount = 6
      };
    }

    public static Generator Blend(this Generator source, Generator other, Generator weight)
    {
      return (Generator) new Terra.CoherentNoise.Generation.Combination.Blend(source, other, weight);
    }

    public static Generator Modify(this Generator source, Func<float, float> modifier)
    {
      return (Generator) new Terra.CoherentNoise.Generation.Modification.Modify(source, modifier);
    }

    public static Generator Curve(this Generator source, AnimationCurve curve)
    {
      return (Generator) new Terra.CoherentNoise.Generation.Modification.Curve(source, curve);
    }

    public static Generator Binarize(this Generator source, float treshold)
    {
      return (Generator) new Terra.CoherentNoise.Generation.Modification.Binarize(source, treshold);
    }

    public static Generator Bias(this Generator source, float b) => (Generator) new Terra.CoherentNoise.Generation.Modification.Bias(source, b);

    public static Generator Gain(this Generator source, float g) => (Generator) new Terra.CoherentNoise.Generation.Modification.Gain(source, g);

    public static Generator ScaleShift(this Generator source, float a, float b)
    {
      return (Generator) new Terra.CoherentNoise.Generation.Modification.Modify(source, (Func<float, float>) (f => a * f + b));
    }
  }
}
