// Decompiled with JetBrains decompiler
// Type: Terra.Nodes.Generation.VoronoiValleysNode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using Terra.CoherentNoise;
using Terra.CoherentNoise.Generation.Voronoi;
using Terra.Terrain;
using XNode;

#nullable disable
namespace Terra.Nodes.Generation
{
  [Node.CreateNodeMenu("Terrain/Noise/Voronoi/Valleys")]
  public class VoronoiValleysNode : AbsVoronoiNoiseNode
  {
    public override Generator GetGenerator()
    {
      VoronoiValleys2D generator = new VoronoiValleys2D(TerraSettings.GenerationSeed);
      generator.Frequency = this.Frequency;
      generator.Period = (int) this.Period;
      return (Generator) generator;
    }

    public override string GetTitle() => "Voronoi Valleys";
  }
}
