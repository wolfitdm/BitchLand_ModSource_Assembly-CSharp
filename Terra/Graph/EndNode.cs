// Decompiled with JetBrains decompiler
// Type: Terra.Graph.EndNode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using Terra.CoherentNoise;
using Terra.Graph.Noise;
using XNode;

#nullable disable
namespace Terra.Graph
{
  [Node.CreateNodeMenu("End Generator")]
  public class EndNode : Node
  {
    [Node.Input(Node.ShowBackingValue.Never, Node.ConnectionType.Override)]
    public AbsGeneratorNode Noise;

    public Generator GetFinalGenerator()
    {
      return this.GetInputValue<AbsGeneratorNode>("Noise").GetGenerator();
    }
  }
}
