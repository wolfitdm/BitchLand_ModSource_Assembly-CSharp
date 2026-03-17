// Decompiled with JetBrains decompiler
// Type: Terra.Graph.EndNode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
