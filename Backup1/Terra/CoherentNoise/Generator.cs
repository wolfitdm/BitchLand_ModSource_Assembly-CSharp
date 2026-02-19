// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generator
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using Terra.CoherentNoise.Generation;
using UnityEngine;

#nullable disable
namespace Terra.CoherentNoise
{
  public abstract class Generator
  {
    public abstract float GetValue(float x, float y, float z);

    public float GetValue(Vector3 v) => this.GetValue(v.x, v.y, v.z);

    public static Generator operator +(Generator g1, Generator g2)
    {
      return (Generator) new Function((Func<float, float, float, float>) ((x, y, z) => g1.GetValue(x, y, z) + g2.GetValue(x, y, z)));
    }

    public static Generator operator +(Generator g1, float f)
    {
      return (Generator) new Function((Func<float, float, float, float>) ((x, y, z) => g1.GetValue(x, y, z) + f));
    }

    public static Generator operator -(Generator g1) => (Generator) -1f * g1;

    public static Generator operator -(Generator g1, Generator g2)
    {
      return (Generator) new Function((Func<float, float, float, float>) ((x, y, z) => g1.GetValue(x, y, z) - g2.GetValue(x, y, z)));
    }

    public static Generator operator -(Generator g1, float f)
    {
      return (Generator) new Function((Func<float, float, float, float>) ((x, y, z) => g1.GetValue(x, y, z) - f));
    }

    public static Generator operator -(float f, Generator g1)
    {
      return (Generator) new Function((Func<float, float, float, float>) ((x, y, z) => f - g1.GetValue(x, y, z)));
    }

    public static Generator operator *(Generator g1, Generator g2)
    {
      return (Generator) new Function((Func<float, float, float, float>) ((x, y, z) => g1.GetValue(x, y, z) * g2.GetValue(x, y, z)));
    }

    public static Generator operator *(Generator g1, float f)
    {
      return (Generator) new Function((Func<float, float, float, float>) ((x, y, z) => g1.GetValue(x, y, z) * f));
    }

    public static Generator operator /(Generator g1, Generator g2)
    {
      return (Generator) new Function((Func<float, float, float, float>) ((x, y, z) => g1.GetValue(x, y, z) / g2.GetValue(x, y, z)));
    }

    public static Generator operator /(Generator g1, float f)
    {
      return (Generator) new Function((Func<float, float, float, float>) ((x, y, z) => g1.GetValue(x, y, z) / f));
    }

    public static Generator operator /(float f, Generator g1)
    {
      return (Generator) new Function((Func<float, float, float, float>) ((x, y, z) => f / g1.GetValue(x, y, z)));
    }

    public static implicit operator Generator(float f) => (Generator) new Constant(f);
  }
}
