// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Modification.Curve
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
