// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Interpolation.SCurve
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Terra.CoherentNoise.Interpolation;

public abstract class SCurve
{
  public static readonly SCurve Linear = (SCurve) new LinearSCurve();
  public static readonly SCurve Cubic = (SCurve) new CubicSCurve();
  public static readonly SCurve Quintic = (SCurve) new QuinticSCurve();
  public static readonly SCurve Cosine = (SCurve) new CosineSCurve();
  public static SCurve Default = SCurve.Cubic;

  public abstract float Interpolate(float t);
}
