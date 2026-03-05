// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Displacement.Rotate
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
