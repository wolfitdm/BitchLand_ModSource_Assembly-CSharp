// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Voronoi.VoronoiPits2D
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Terra.CoherentNoise.Generation.Voronoi
{
  public class VoronoiPits2D(int seed) : VoronoiDiagramBase2D(seed)
  {
    protected override float GetResult(float min1, float min2, float min3) => min1;
  }
}
