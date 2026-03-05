// Decompiled with JetBrains decompiler
// Type: Terra.Graph.EndNode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
