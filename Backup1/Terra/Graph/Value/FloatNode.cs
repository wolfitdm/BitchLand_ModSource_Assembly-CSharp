// Decompiled with JetBrains decompiler
// Type: Terra.Graph.Value.FloatNode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using XNode;

#nullable disable
namespace Terra.Graph.Value
{
  [Node.CreateNodeMenu("Value/Float")]
  internal class FloatNode : Node
  {
    [Node.Output(Node.ShowBackingValue.Never, Node.ConnectionType.Multiple)]
    public float Output;
    [Node.Input(Node.ShowBackingValue.Unconnected, Node.ConnectionType.Multiple)]
    public float Value;

    public override object GetValue(NodePort port) => base.GetValue(port);
  }
}
