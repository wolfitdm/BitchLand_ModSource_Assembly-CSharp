// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Modification.Gain
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
namespace Terra.CoherentNoise.Generation.Modification
{
  public class Gain : Generator
  {
    private readonly float m_Gain;
    private readonly Generator m_Source;

    public Gain(Generator source, float gain)
    {
      if ((double) this.m_Gain <= -1.0 || (double) this.m_Gain >= 1.0)
        throw new ArgumentException("Gain must be between -1 and 1");
      this.m_Source = source;
      this.m_Gain = gain;
    }

    public override float GetValue(float x, float y, float z)
    {
      float f = this.m_Source.GetValue(x, y, z);
      return (double) f >= 0.0 ? this.BiasFunc(f) : -this.BiasFunc(-f);
    }

    private float BiasFunc(float f)
    {
      if ((double) f < 0.0)
        f = 0.0f;
      if ((double) f > 1.0)
        f = 1f;
      return (float) ((double) f * (1.0 + (double) this.m_Gain) / (1.0 + (double) this.m_Gain - (1.0 - (double) f) * 2.0 * (double) this.m_Gain));
    }
  }
}
