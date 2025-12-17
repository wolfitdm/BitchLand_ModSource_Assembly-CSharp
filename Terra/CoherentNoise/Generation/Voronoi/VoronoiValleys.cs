// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Voronoi.VoronoiValleys
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Terra.CoherentNoise.Generation.Voronoi;

public class VoronoiValleys(int seed) : VoronoiDiagramBase(seed)
{
  protected override float GetResult(float min1, float min2, float min3) => min2 - min1;
}
