// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Constant
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Terra.CoherentNoise.Generation
{
  public class Constant : Generator
  {
    private readonly float m_Value;

    public Constant(float value) => this.m_Value = value;

    public override float GetValue(float x, float y, float z) => this.m_Value;
  }
}
