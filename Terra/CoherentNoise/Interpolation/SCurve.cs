// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Interpolation.SCurve
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Terra.CoherentNoise.Interpolation
{
  public abstract class SCurve
  {
    public static readonly SCurve Linear = (SCurve) new LinearSCurve();
    public static readonly SCurve Cubic = (SCurve) new CubicSCurve();
    public static readonly SCurve Quintic = (SCurve) new QuinticSCurve();
    public static readonly SCurve Cosine = (SCurve) new CosineSCurve();
    public static SCurve Default = SCurve.Cubic;

    public abstract float Interpolate(float t);
  }
}
