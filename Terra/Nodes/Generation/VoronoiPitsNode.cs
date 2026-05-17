// Decompiled with JetBrains decompiler
// Type: Terra.Nodes.Generation.VoronoiPitsNode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
