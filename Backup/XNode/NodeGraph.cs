// Decompiled with JetBrains decompiler
// Type: XNode.NodeGraph
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace XNode;

[Serializable]
public abstract class NodeGraph : ScriptableObject
{
  [SerializeField]
  public List<Node> nodes = new List<Node>();

  public T AddNode<T>() where T : Node => this.AddNode(typeof (T)) as T;

  public virtual Node AddNode(System.Type type)
  {
    Node instance = ScriptableObject.CreateInstance(type) as Node;
    this.nodes.Add(instance);
    instance.graph = this;
    return instance;
  }

  public virtual Node CopyNode(Node original)
  {
    Node node = UnityEngine.Object.Instantiate<Node>(original);
    node.ClearConnections();
    this.nodes.Add(node);
    node.graph = this;
    return node;
  }

  public void RemoveNode(Node node)
  {
    node.ClearConnections();
    this.nodes.Remove(node);
  }

  public void Clear() => this.nodes.Clear();

  public NodeGraph Copy()
  {
    NodeGraph nodeGraph = UnityEngine.Object.Instantiate<NodeGraph>(this);
    for (int index = 0; index < this.nodes.Count; ++index)
    {
      Node node = UnityEngine.Object.Instantiate<Node>(this.nodes[index]);
      node.graph = nodeGraph;
      nodeGraph.nodes[index] = node;
    }
    for (int index = 0; index < nodeGraph.nodes.Count; ++index)
    {
      foreach (NodePort port in nodeGraph.nodes[index].Ports)
        port.Redirect(this.nodes, nodeGraph.nodes);
    }
    return nodeGraph;
  }
}
