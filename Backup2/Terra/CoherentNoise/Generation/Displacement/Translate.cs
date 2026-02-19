// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Displacement.Translate
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace Terra.CoherentNoise.Generation.Displacement;

public class Translate : Generator
{
  private readonly Generator m_Source;
  private readonly float m_X;
  private readonly float m_Y;
  private readonly float m_Z;

  public Translate(Generator source, Vector3 v)
    : this(source, v.x, v.y, v.z)
  {
  }

  public Translate(Generator source, float x, float y, float z)
  {
    this.m_Source = source;
    this.m_Z = z;
    this.m_Y = y;
    this.m_X = x;
  }

  public override float GetValue(float x, float y, float z)
  {
    return this.m_Source.GetValue(x + this.m_X, y + this.m_Y, z + this.m_Z);
  }
}
