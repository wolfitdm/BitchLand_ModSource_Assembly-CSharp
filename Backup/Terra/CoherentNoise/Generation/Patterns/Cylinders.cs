// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Patterns.Cylinders
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace Terra.CoherentNoise.Generation.Patterns;

public class Cylinders : Function
{
  public Cylinders(float radius)
    : base((Func<float, float, float, float>) ((x, y, z) => Helpers.Saw(new Vector2(x, y).magnitude / radius)))
  {
    if ((double) radius <= 0.0)
      throw new ArgumentException("Radius must be > 0");
  }
}
