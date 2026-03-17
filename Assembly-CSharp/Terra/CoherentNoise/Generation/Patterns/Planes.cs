// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Patterns.Planes
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
