// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Constant
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
