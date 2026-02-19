// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Patterns.Cylinders
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
