// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Modification.Modify
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
namespace Terra.CoherentNoise.Generation.Modification
{
  public class Modify : Generator
  {
    private Func<float, float> m_Modifier;
    private Generator m_Source;

    public Modify(Generator source, Func<float, float> modifier)
    {
      this.m_Source = source;
      this.m_Modifier = modifier;
    }

    public override float GetValue(float x, float y, float z)
    {
      return this.m_Modifier(this.m_Source.GetValue(x, y, z));
    }
  }
}
