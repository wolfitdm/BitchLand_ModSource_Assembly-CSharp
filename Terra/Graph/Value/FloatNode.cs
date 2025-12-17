// Decompiled with JetBrains decompiler
// Type: Terra.Graph.Value.FloatNode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using XNode;

#nullable disable
namespace Terra.Graph.Value;

[Node.CreateNodeMenu("Value/Float")]
internal class FloatNode : Node
{
  [Node.Output(Node.ShowBackingValue.Never, Node.ConnectionType.Multiple)]
  public float Output;
  [Node.Input(Node.ShowBackingValue.Unconnected, Node.ConnectionType.Multiple)]
  public float Value;

  public override object GetValue(NodePort port) => base.GetValue(port);
}
