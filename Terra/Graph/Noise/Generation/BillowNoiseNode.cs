// Decompiled with JetBrains decompiler
// Type: Terra.Graph.Noise.Generation.BillowNoiseNode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using Terra.CoherentNoise;
using Terra.CoherentNoise.Generation.Fractal;
using Terra.Terrain;
using XNode;

#nullable disable
namespace Terra.Graph.Noise.Generation
{
  [Node.CreateNodeMenu("Terrain/Noise/Billow")]
  public class BillowNoiseNode : AbsFractalNoiseNode
  {
    [Node.Input(Node.ShowBackingValue.Unconnected, Node.ConnectionType.Multiple)]
    public float Persistence = 1f;

    public override Generator GetGenerator()
    {
      BillowNoise generator = new BillowNoise(TerraSettings.GenerationSeed);
      generator.Frequency = this.Frequency;
      generator.Lacunarity = this.Lacunarity;
      generator.OctaveCount = this.OctaveCount;
      generator.Persistence = this.Persistence;
      return (Generator) generator;
    }

    public override string GetTitle() => "Billow";
  }
}
