// Decompiled with JetBrains decompiler
// Type: Terra.Graph.Value.Vector3Node
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using XNode;

#nullable disable
namespace Terra.Graph.Value
{
  [Node.CreateNodeMenu("Value/Vector 3")]
  internal class Vector3Node : Node
  {
    [Node.Output(Node.ShowBackingValue.Never, Node.ConnectionType.Multiple)]
    public Vector3 Output;
    [Node.Input(Node.ShowBackingValue.Unconnected, Node.ConnectionType.Multiple)]
    public Vector3 Value;

    public override object GetValue(NodePort port) => base.GetValue(port);
  }
}
