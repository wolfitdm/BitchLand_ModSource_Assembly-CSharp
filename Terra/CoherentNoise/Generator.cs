// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generator
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
