// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Patterns.Planes
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
