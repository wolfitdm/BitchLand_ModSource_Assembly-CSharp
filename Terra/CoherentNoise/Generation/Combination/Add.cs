// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Combination.Add
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Terra.CoherentNoise.Generation.Combination;

public class Add : Generator
{
  private readonly Generator m_A;
  private readonly Generator m_B;

  public Add(Generator a, Generator b)
  {
    this.m_A = a;
    this.m_B = b;
  }

  public override float GetValue(float x, float y, float z)
  {
    return this.m_A.GetValue(x, y, z) + this.m_B.GetValue(x, y, z);
  }
}
