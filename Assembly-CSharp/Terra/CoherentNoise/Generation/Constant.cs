// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Constant
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
