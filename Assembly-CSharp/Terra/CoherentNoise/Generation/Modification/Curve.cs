// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Modification.Curve
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
