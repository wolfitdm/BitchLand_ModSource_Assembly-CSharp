// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Combination.Max
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace Terra.CoherentNoise.Generation.Combination
{
  public class Max : Generator
  {
    private readonly Generator m_A;
    private readonly Generator m_B;

    public Max(Generator a, Generator b)
    {
      this.m_A = a;
      this.m_B = b;
    }

    public override float GetValue(float x, float y, float z)
    {
      return Mathf.Max(this.m_A.GetValue(x, y, z), this.m_B.GetValue(x, y, z));
    }
  }
}
