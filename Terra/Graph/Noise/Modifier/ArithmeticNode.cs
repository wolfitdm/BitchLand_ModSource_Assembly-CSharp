// Decompiled with JetBrains decompiler
// Type: Terra.Graph.Noise.Modifier.ArithmeticNode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using Terra.CoherentNoise;
using XNode;

#nullable disable
namespace Terra.Graph.Noise.Modifier
{
  [Node.CreateNodeMenu("Modifier/Arithmetic")]
  public class ArithmeticNode : AbsTwoModNode
  {
    public ArithmeticNode.Operation operation;

    public override Generator GetGenerator()
    {
      if (!this.HasBothGenerators())
        return (Generator) null;
      Generator generator1 = this.GetGenerator1();
      Generator generator2 = this.GetGenerator2();
      switch (this.operation)
      {
        case ArithmeticNode.Operation.Add:
          return generator1 + generator2;
        case ArithmeticNode.Operation.Subtract:
          return generator1 - generator2;
        case ArithmeticNode.Operation.Multiply:
          return generator1 * generator2;
        case ArithmeticNode.Operation.Divide:
          return generator1 / generator2;
        default:
          return (Generator) null;
      }
    }

    public override string GetTitle() => "Arithmetic";

    public enum Operation
    {
      Add,
      Subtract,
      Multiply,
      Divide,
    }
  }
}
