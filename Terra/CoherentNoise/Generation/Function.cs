// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Function
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
