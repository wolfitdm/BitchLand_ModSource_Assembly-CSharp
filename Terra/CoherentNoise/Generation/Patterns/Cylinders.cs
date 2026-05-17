// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Patterns.Cylinders
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace Terra.CoherentNoise.Generation.Patterns
{
  public class Cylinders : Function
  {
    public Cylinders(float radius)
      : base((Func<float, float, float, float>) ((x, y, z) => Helpers.Saw(new Vector2(x, y).magnitude / radius)))
    {
      if ((double) radius <= 0.0)
        throw new ArgumentException("Radius must be > 0");
    }
  }
}
