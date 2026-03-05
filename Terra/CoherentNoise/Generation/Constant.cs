// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Constant
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
