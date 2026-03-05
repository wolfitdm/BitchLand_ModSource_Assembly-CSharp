// Decompiled with JetBrains decompiler
// Type: Terra.Graph.Noise.Modifier.ArithmeticNode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
