// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Modification.Curve
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
