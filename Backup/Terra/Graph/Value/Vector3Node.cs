// Decompiled with JetBrains decompiler
// Type: Terra.Graph.Value.Vector3Node
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
