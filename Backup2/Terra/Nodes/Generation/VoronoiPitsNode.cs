// Decompiled with JetBrains decompiler
// Type: Terra.Nodes.Generation.VoronoiPitsNode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using Terra.CoherentNoise;
using Terra.CoherentNoise.Generation.Voronoi;
using Terra.Terrain;
using XNode;

#nullable disable
namespace Terra.Nodes.Generation;

[Node.CreateNodeMenu("Terrain/Noise/Voronoi/Pits")]
public class VoronoiPitsNode : AbsVoronoiNoiseNode
{
  public override Generator GetGenerator()
  {
    VoronoiPits2D generator = new VoronoiPits2D(TerraSettings.GenerationSeed);
    generator.Frequency = this.Frequency;
    generator.Period = (int) this.Period;
    return (Generator) generator;
  }

  public override string GetTitle() => "Voronoi Pits";
}
