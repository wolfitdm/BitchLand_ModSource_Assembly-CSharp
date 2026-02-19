// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Modification.Bias
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
namespace Terra.CoherentNoise.Generation.Modification
{
  public class Bias : Generator
  {
    private readonly float m_Bias;
    private readonly Generator m_Source;

    public Bias(Generator source, float bias)
    {
      if ((double) this.m_Bias <= -1.0 || (double) this.m_Bias >= 1.0)
        throw new ArgumentException("Bias must be between -1 and 1");
      this.m_Source = source;
      this.m_Bias = bias / (1f + bias);
    }

    public override float GetValue(float x, float y, float z)
    {
      float num = this.m_Source.GetValue(x, y, z);
      if ((double) num < -1.0)
        num = -1f;
      if ((double) num > 1.0)
        num = 1f;
      return (float) (((double) num + 1.0) / (1.0 - (double) this.m_Bias * (1.0 - (double) num) * 0.5) - 1.0);
    }
  }
}
