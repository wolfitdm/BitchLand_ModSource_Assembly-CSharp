// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Displacement.Perturb
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace Terra.CoherentNoise.Generation.Displacement
{
  public class Perturb : Generator
  {
    private readonly Generator m_Source;
    private readonly Func<Vector3, Vector3> m_DisplacementSource;

    public Perturb(Generator source, Func<Vector3, Vector3> displacementSource)
    {
      this.m_Source = source;
      this.m_DisplacementSource = displacementSource;
    }

    public override float GetValue(float x, float y, float z)
    {
      Vector3 vector3 = this.m_DisplacementSource(new Vector3(x, y, z));
      return this.m_Source.GetValue(x + vector3.x, y + vector3.y, z + vector3.z);
    }
  }
}
