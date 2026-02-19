// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Interpolation.QuinticSCurve
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Terra.CoherentNoise.Interpolation;

internal class QuinticSCurve : SCurve
{
  public override float Interpolate(float t)
  {
    float num1 = t * t * t;
    float num2 = num1 * t;
    return (float) (6.0 * (double) (num2 * t) - 15.0 * (double) num2 + 10.0 * (double) num1);
  }
}
