// Decompiled with JetBrains decompiler
// Type: XNode.Node
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace XNode;

[Serializable]
public abstract class Node : ScriptableObject
{
  [SerializeField]
  public NodeGraph graph;
  [SerializeField]
  public Vector2 position;
  [SerializeField]
  private Node.NodePortDictionary ports = new Node.NodePortDictionary();

  public IEnumerable<NodePort> Ports
  {
    get
    {
      foreach (NodePort port in this.ports.Values)
        yield return port;
    }
  }

  public IEnumerable<NodePort> Outputs
  {
    get
    {
      foreach (NodePort port in this.Ports)
      {
        if (port.IsOutput)
          yield return port;
      }
    }
  }

  public IEnumerable<NodePort> Inputs
  {
    get
    {
      foreach (NodePort port in this.Ports)
      {
        if (port.IsInput)
          yield return port;
      }
    }
  }

  public IEnumerable<NodePort> InstancePorts
  {
    get
    {
      foreach (NodePort port in this.Ports)
      {
        if (port.IsDynamic)
          yield return port;
      }
    }
  }

  public IEnumerable<NodePort> InstanceOutputs
  {
    get
    {
      foreach (NodePort port in this.Ports)
      {
        if (port.IsDynamic && port.IsOutput)
          yield return port;
      }
    }
  }

  public IEnumerable<NodePort> InstanceInputs
  {
    get
    {
      foreach (NodePort port in this.Ports)
      {
        if (port.IsDynamic && port.IsInput)
          yield return port;
      }
    }
  }

  protected void OnEnable()
  {
    this.UpdateStaticPorts();
    this.Init();
  }

  public void UpdateStaticPorts()
  {
    NodeDataCache.UpdatePorts(this, (Dictionary<string, NodePort>) this.ports);
  }

  protected virtual void Init() => this.name = this.GetType().Name;

  public void VerifyConnections()
  {
    foreach (NodePort port in this.Ports)
      port.VerifyConnections();
  }

  public NodePort AddInstanceInput(System.Type type, Node.ConnectionType connectionType = Node.ConnectionType.Multiple, string fieldName = null)
  {
    return this.AddInstancePort(type, NodePort.IO.Input, connectionType, fieldName);
  }

  public NodePort AddInstanceOutput(
    System.Type type,
    Node.ConnectionType connectionType = Node.ConnectionType.Multiple,
    string fieldName = null)
  {
    return this.AddInstancePort(type, NodePort.IO.Output, connectionType, fieldName);
  }

  private NodePort AddInstancePort(
    System.Type type,
    NodePort.IO direction,
    Node.ConnectionType connectionType = Node.ConnectionType.Multiple,
    string fieldName = null)
  {
    if (fieldName == null)
    {
      fieldName = "instanceInput_0";
      int num = 0;
      while (this.HasPort(fieldName))
        fieldName = "instanceInput_" + (++num).ToString();
    }
    else if (this.HasPort(fieldName))
    {
      Debug.LogWarning((object) $"Port '{fieldName}' already exists in {this.name}", (UnityEngine.Object) this);
      return this.ports[fieldName];
    }
    NodePort nodePort = new NodePort(fieldName, type, direction, connectionType, this);
    this.ports.Add(fieldName, nodePort);
    return nodePort;
  }

  public void RemoveInstancePort(string fieldName)
  {
    this.RemoveInstancePort(this.GetPort(fieldName));
  }

  public void RemoveInstancePort(NodePort port)
  {
    if (port == null)
      throw new ArgumentNullException(nameof (port));
    if (port.IsStatic)
      throw new ArgumentException("cannot remove static port");
    port.ClearConnections();
    this.ports.Remove(port.fieldName);
  }

  [ContextMenu("Clear instance ports")]
  public void ClearInstancePorts()
  {
    foreach (NodePort port in new List<NodePort>(this.InstancePorts))
      this.RemoveInstancePort(port);
  }

  public NodePort GetOutputPort(string fieldName)
  {
    NodePort port = this.GetPort(fieldName);
    return port == null || port.direction != NodePort.IO.Output ? (NodePort) null : port;
  }

  public NodePort GetInputPort(string fieldName)
  {
    NodePort port = this.GetPort(fieldName);
    return port == null || port.direction != NodePort.IO.Input ? (NodePort) null : port;
  }

  public NodePort GetPort(string fieldName)
  {
    return this.ports.ContainsKey(fieldName) ? this.ports[fieldName] : (NodePort) null;
  }

  public bool HasPort(string fieldName) => this.ports.ContainsKey(fieldName);

  public T GetInputValue<T>(string fieldName, T fallback = null)
  {
    NodePort port = this.GetPort(fieldName);
    return port != null && port.IsConnected ? port.GetInputValue<T>() : fallback;
  }

  public T[] GetInputValues<T>(string fieldName, params T[] fallback)
  {
    NodePort port = this.GetPort(fieldName);
    return port != null && port.IsConnected ? port.GetInputValues<T>() : fallback;
  }

  public virtual object GetValue(NodePort port)
  {
    Debug.LogWarning((object) ("No GetValue(NodePort port) override defined for " + this.GetType()?.ToString()));
    return (object) null;
  }

  public virtual void OnCreateConnection(NodePort from, NodePort to)
  {
  }

  public virtual void OnRemoveConnection(NodePort port)
  {
  }

  public void ClearConnections()
  {
    foreach (NodePort port in this.Ports)
      port.ClearConnections();
  }

  public override int GetHashCode() => JsonUtility.ToJson((object) this).GetHashCode();

  public enum ShowBackingValue
  {
    Never,
    Unconnected,
    Always,
  }

  public enum ConnectionType
  {
    Multiple,
    Override,
  }

  [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
  public class InputAttribute : Attribute
  {
    public Node.ShowBackingValue backingValue;
    public Node.ConnectionType connectionType;

    public InputAttribute(Node.ShowBackingValue backingValue = Node.ShowBackingValue.Unconnected, Node.ConnectionType connectionType = Node.ConnectionType.Multiple)
    {
      this.backingValue = backingValue;
      this.connectionType = connectionType;
    }
  }

  [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
  public class OutputAttribute : Attribute
  {
    public Node.ShowBackingValue backingValue;
    public Node.ConnectionType connectionType;

    public OutputAttribute(Node.ShowBackingValue backingValue = Node.ShowBackingValue.Never, Node.ConnectionType connectionType = Node.ConnectionType.Multiple)
    {
      this.backingValue = backingValue;
      this.connectionType = connectionType;
    }
  }

  [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
  public class CreateNodeMenuAttribute : Attribute
  {
    public string menuName;

    public CreateNodeMenuAttribute(string menuName) => this.menuName = menuName;
  }

  [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
  public class NodeTint : Attribute
  {
    public Color color;

    public NodeTint(float r, float g, float b) => this.color = new Color(r, g, b);

    public NodeTint(string hex) => ColorUtility.TryParseHtmlString(hex, out this.color);

    public NodeTint(byte r, byte g, byte b)
    {
      this.color = (Color) new Color32(r, g, b, byte.MaxValue);
    }
  }

  [Serializable]
  private class NodePortDictionary : Dictionary<string, NodePort>, ISerializationCallbackReceiver
  {
    [SerializeField]
    private List<string> keys = new List<string>();
    [SerializeField]
    private List<NodePort> values = new List<NodePort>();

    public void OnBeforeSerialize()
    {
      this.keys.Clear();
      this.values.Clear();
      foreach (KeyValuePair<string, NodePort> keyValuePair in (Dictionary<string, NodePort>) this)
      {
        this.keys.Add(keyValuePair.Key);
        this.values.Add(keyValuePair.Value);
      }
    }

    public void OnAfterDeserialize()
    {
      this.Clear();
      if (this.keys.Count != this.values.Count)
        throw new Exception($"there are {this.keys.Count.ToString()} keys and {this.values.Count.ToString()} values after deserialization. Make sure that both key and value types are serializable.");
      for (int index = 0; index < this.keys.Count; ++index)
        this.Add(this.keys[index], this.values[index]);
    }
  }
}
