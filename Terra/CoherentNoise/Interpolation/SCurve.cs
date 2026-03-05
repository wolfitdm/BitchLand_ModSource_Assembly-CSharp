// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Interpolation.SCurve
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
