// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Interpolation.CubicSCurve
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Terra.CoherentNoise.Interpolation
{
  internal class CubicSCurve : SCurve
  {
    public override float Interpolate(float t)
    {
      return (float) ((double) t * (double) t * (3.0 - 2.0 * (double) t));
    }
  }
}
