// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Interpolation.SCurve
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
