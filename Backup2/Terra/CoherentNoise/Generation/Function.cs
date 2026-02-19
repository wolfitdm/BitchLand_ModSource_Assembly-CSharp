// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Function
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
namespace Terra.CoherentNoise.Generation;

public class Function : Generator
{
  private readonly Func<float, float, float, float> m_Func;

  public Function(Func<float, float, float, float> func) => this.m_Func = func;

  public override float GetValue(float x, float y, float z) => this.m_Func(x, y, z);
}
