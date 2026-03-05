// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Interpolation.QuinticSCurve
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Terra.CoherentNoise.Interpolation
{
  internal class QuinticSCurve : SCurve
  {
    public override float Interpolate(float t)
    {
      float num1 = t * t * t;
      float num2 = num1 * t;
      return (float) (6.0 * (double) (num2 * t) - 15.0 * (double) num2 + 10.0 * (double) num1);
    }
  }
}
