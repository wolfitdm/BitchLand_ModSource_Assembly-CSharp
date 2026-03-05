// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Displacement.Rotate
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace Terra.CoherentNoise.Generation.Displacement
{
  public class Rotate : Generator
  {
    private Generator m_Source;
    private Quaternion m_Rotation;

    public Rotate(Generator source, Quaternion rotation)
    {
      this.m_Source = source;
      this.m_Rotation = rotation;
    }

    public Rotate(Generator source, float angleX, float angleY, float angleZ)
      : this(source, Quaternion.Euler(angleX, angleY, angleZ))
    {
    }

    public override float GetValue(float x, float y, float z)
    {
      return this.m_Source.GetValue(this.m_Rotation * new Vector3(x, y, z));
    }
  }
}
