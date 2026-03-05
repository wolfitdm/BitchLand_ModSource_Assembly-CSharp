// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Modification.Curve
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace Terra.CoherentNoise.Generation.Modification
{
  public class Curve : Generator
  {
    private Generator m_Source;
    private AnimationCurve m_Curve;

    public Curve(Generator source, AnimationCurve curve)
    {
      this.m_Source = source;
      this.m_Curve = curve;
    }

    public override float GetValue(float x, float y, float z)
    {
      return this.m_Curve.Evaluate(this.m_Source.GetValue(x, y, z));
    }
  }
}
