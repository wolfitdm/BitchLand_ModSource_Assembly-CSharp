// Decompiled with JetBrains decompiler
// Type: Terra.Nodes.Generation.VoronoiPitsNode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
