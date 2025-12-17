// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Patterns.Planes
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
namespace Terra.CoherentNoise.Generation.Patterns;

public class Planes : Function
{
  public Planes(float step)
    : base((Func<float, float, float, float>) ((x, y, z) => Helpers.Saw(x / step)))
  {
    if ((double) step <= 0.0)
      throw new ArgumentException("Step must be > 0");
  }
}
