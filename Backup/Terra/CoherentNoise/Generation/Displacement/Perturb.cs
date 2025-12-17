// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Displacement.Perturb
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace Terra.CoherentNoise.Generation.Displacement;

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
