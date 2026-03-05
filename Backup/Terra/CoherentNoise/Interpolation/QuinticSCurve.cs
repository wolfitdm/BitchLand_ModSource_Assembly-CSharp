// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Interpolation.QuinticSCurve
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
