// Decompiled with JetBrains decompiler
// Type: Terra.Nodes.Generation.VoronoiPitsNode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using Terra.CoherentNoise;
using Terra.CoherentNoise.Generation.Voronoi;
using Terra.Terrain;
using XNode;

#nullable disable
namespace Terra.Nodes.Generation
{
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
}
