// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Function
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
namespace Terra.CoherentNoise.Generation
{
  public class Function : Generator
  {
    private readonly Func<float, float, float, float> m_Func;

    public Function(Func<float, float, float, float> func) => this.m_Func = func;

    public override float GetValue(float x, float y, float z) => this.m_Func(x, y, z);
  }
}
