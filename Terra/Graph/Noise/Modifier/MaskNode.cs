// Decompiled with JetBrains decompiler
// Type: Terra.Graph.Noise.Modifier.MaskNode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using Terra.CoherentNoise;
using Terra.CoherentNoise.Generation.Combination;
using XNode;

#nullable disable
namespace Terra.Graph.Noise.Modifier
{
  [Node.CreateNodeMenu("Modifier/Mask")]
  public class MaskNode : AbsGeneratorNode
  {
    [Node.Input(Node.ShowBackingValue.Never, Node.ConnectionType.Override)]
    public AbsGeneratorNode Generator1;
    [Node.Input(Node.ShowBackingValue.Never, Node.ConnectionType.Override)]
    public AbsGeneratorNode Generator2;
    [Node.Input(Node.ShowBackingValue.Never, Node.ConnectionType.Override)]
    public AbsGeneratorNode Mask;

    public override Generator GetGenerator()
    {
      AbsGeneratorNode inputValue1 = this.GetInputValue<AbsGeneratorNode>("Generator1");
      AbsGeneratorNode inputValue2 = this.GetInputValue<AbsGeneratorNode>("Generator2");
      AbsGeneratorNode inputValue3 = this.GetInputValue<AbsGeneratorNode>("Mask");
      if (!AbsGeneratorNode.HasAllGenerators(inputValue1, inputValue2, inputValue3))
        return (Generator) null;
      Generator generator1 = inputValue1.GetGenerator();
      Generator generator2 = inputValue2.GetGenerator();
      Generator generator3 = inputValue3.GetGenerator();
      Generator b = generator2;
      Generator weight = generator3;
      return (Generator) new Blend(generator1, b, weight);
    }

    public override string GetTitle() => "Mask";
  }
}
