// Decompiled with JetBrains decompiler
// Type: Terra.Graph.Value.IntNode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using XNode;

#nullable disable
namespace Terra.Graph.Value
{
  [Node.CreateNodeMenu("Value/Int")]
  internal class IntNode : Node
  {
    [Node.Output(Node.ShowBackingValue.Never, Node.ConnectionType.Multiple)]
    public int Output;
    [Node.Input(Node.ShowBackingValue.Unconnected, Node.ConnectionType.Multiple)]
    public int Value;

    public override object GetValue(NodePort port) => base.GetValue(port);
  }
}
