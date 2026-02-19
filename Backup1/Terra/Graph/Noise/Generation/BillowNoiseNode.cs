// Decompiled with JetBrains decompiler
// Type: Terra.Graph.Noise.Generation.BillowNoiseNode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
