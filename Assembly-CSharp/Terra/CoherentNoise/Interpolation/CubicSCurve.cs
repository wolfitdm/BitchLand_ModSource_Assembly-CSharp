// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Interpolation.CubicSCurve
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
