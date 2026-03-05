// Decompiled with JetBrains decompiler
// Type: Terra.Graph.Noise.Generation.RidgeNoiseNode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
