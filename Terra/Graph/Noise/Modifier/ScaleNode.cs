// Decompiled with JetBrains decompiler
// Type: Terra.Graph.Noise.Modifier.ScaleNode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using Terra.CoherentNoise.Generation.Displacement;
using UnityEngine;
using XNode;

#nullable disable
namespace Terra.Graph.Noise.Modifier;

[Node.CreateNodeMenu("Modifier/Scale")]
public class ScaleNode : AbsGeneratorNode
{
  [Node.Input(Node.ShowBackingValue.Unconnected, Node.ConnectionType.Multiple)]
  public AbsGeneratorNode Generator;
  [Node.Input(Node.ShowBackingValue.Unconnected, Node.ConnectionType.Multiple)]
  public Vector3 Factor = Vector3.one;
  [Node.Input(Node.ShowBackingValue.Unconnected, Node.ConnectionType.Multiple)]
  public float Amount = 1f;
  [Node.Input(Node.ShowBackingValue.Unconnected, Node.ConnectionType.Multiple)]
  public bool Uniform;

  public override Terra.CoherentNoise.Generator GetGenerator()
  {
    if (!AbsGeneratorNode.HasAllGenerators(this.GetInputValue<AbsGeneratorNode>("Generator")))
      return (Terra.CoherentNoise.Generator) null;
    Terra.CoherentNoise.Generator generator = this.GetInputValue<AbsGeneratorNode>("Generator").GetGenerator();
    if (!this.Uniform)
      return (Terra.CoherentNoise.Generator) new Scale(generator, this.Factor);
    Vector3 v = new Vector3(this.Amount, this.Amount, this.Amount);
    return (Terra.CoherentNoise.Generator) new Scale(generator, v);
  }

  public override string GetTitle() => "Scale";
}
