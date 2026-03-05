// Decompiled with JetBrains decompiler
// Type: Terra.Graph.EndNode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
