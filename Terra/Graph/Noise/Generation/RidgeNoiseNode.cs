// Decompiled with JetBrains decompiler
// Type: Terra.Graph.Noise.Generation.RidgeNoiseNode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using Terra.CoherentNoise;
using Terra.CoherentNoise.Generation.Fractal;
using Terra.Terrain;
using XNode;

#nullable disable
namespace Terra.Graph.Noise.Generation;

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
