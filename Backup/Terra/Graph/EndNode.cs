// Decompiled with JetBrains decompiler
// Type: Terra.Graph.EndNode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using Terra.CoherentNoise;
using Terra.Graph.Noise;
using XNode;

#nullable disable
namespace Terra.Graph;

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
