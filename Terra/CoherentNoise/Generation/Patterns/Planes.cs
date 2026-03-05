// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Patterns.Planes
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
namespace Terra.CoherentNoise.Generation.Patterns
{
  public class Planes : Function
  {
    public Planes(float step)
      : base((Func<float, float, float, float>) ((x, y, z) => Helpers.Saw(x / step)))
    {
      if ((double) step <= 0.0)
        throw new ArgumentException("Step must be > 0");
    }
  }
}
