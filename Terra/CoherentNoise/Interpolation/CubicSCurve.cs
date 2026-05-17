// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Interpolation.CubicSCurve
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
