// Decompiled with JetBrains decompiler
// Type: Terra.Graph.Noise.Generation.RidgeNoiseNode
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
  [Node.CreateNodeMenu("Terrain/Noise/Ridge")]
  public class RidgeNoiseNode : AbsFractalNoiseNode
  {
    [Node.Input(Node.ShowBackingValue.Unconnected, Node.ConnectionType.Multiple)]
    public float Exponent = 1f;
    [Node.Input(Node.ShowBackingValue.Unconnected, Node.ConnectionType.Multiple)]
    public float Offset = 1f;
    [Node.Input(Node.ShowBackingValue.Unconnected, Node.ConnectionType.Multiple)]
    public float Gain = 2f;

    public override Generator GetGenerator()
    {
      RidgeNoise generator = new RidgeNoise(TerraSettings.GenerationSeed);
      generator.Frequency = this.Frequency;
      generator.Lacunarity = this.Lacunarity;
      generator.OctaveCount = this.OctaveCount;
      generator.Exponent = this.Exponent;
      generator.Offset = this.Offset;
      generator.Gain = this.Gain;
      return (Generator) generator;
    }

    public override string GetTitle() => "Ridge";
  }
}
