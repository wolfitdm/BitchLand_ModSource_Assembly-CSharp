// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Combination.Blend
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace Terra.CoherentNoise.Generation.Combination;

public class Blend : Generator
{
  private readonly Generator m_A;
  private readonly Generator m_B;
  private readonly Generator m_Weight;

  public Blend(Generator a, Generator b, Generator weight)
  {
    this.m_A = a;
    this.m_Weight = weight;
    this.m_B = b;
  }

  public override float GetValue(float x, float y, float z)
  {
    float num = Mathf.Clamp01(this.m_Weight.GetValue(x, y, z));
    return (float) ((double) this.m_A.GetValue(x, y, z) * (1.0 - (double) num) + (double) this.m_B.GetValue(x, y, z) * (double) num);
  }
}
