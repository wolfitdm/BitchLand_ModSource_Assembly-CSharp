// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Displacement.Scale
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace Terra.CoherentNoise.Generation.Displacement
{
  public class Scale : Generator
  {
    private readonly Generator m_Source;
    private readonly float m_X;
    private readonly float m_Y;
    private readonly float m_Z;

    public Scale(Generator source, Vector3 v)
      : this(source, v.x, v.y, v.z)
    {
    }

    public Scale(Generator source, float x, float y, float z)
    {
      this.m_Source = source;
      this.m_Z = z;
      this.m_Y = y;
      this.m_X = x;
    }

    public override float GetValue(float x, float y, float z)
    {
      return this.m_Source.GetValue(x * this.m_X, y * this.m_Y, z * this.m_Z);
    }
  }
}
