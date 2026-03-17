// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Interpolation.QuinticSCurve
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
