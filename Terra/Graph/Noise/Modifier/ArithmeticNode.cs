// Decompiled with JetBrains decompiler
// Type: Terra.Graph.Noise.Modifier.ArithmeticNode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
