// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Voronoi.VoronoiValleys2D
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Terra.CoherentNoise.Generation.Voronoi
{
  public class VoronoiValleys2D(int seed) : VoronoiDiagramBase2D(seed)
  {
    protected override float GetResult(float min1, float min2, float min3) => min2 - min1;
  }
}
