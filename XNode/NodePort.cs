// Decompiled with JetBrains decompiler
// Type: XNode.NodePort
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace XNode
{
  [Serializable]
  public class NodePort
  {
    private System.Type valueType;
    [SerializeField]
    private string _fieldName;
    [SerializeField]
    private Node _node;
    [SerializeField]
    private string _typeQualifiedName;
    [SerializeField]
    private List<NodePort.PortConnection> connections = new List<NodePort.PortConnection>();
    [SerializeField]
    private NodePort.IO _direction;
    [SerializeField]
    private Node.ConnectionType _connectionType;
    [SerializeField]
    private bool _dynamic;

    public int ConnectionCount => this.connections.Count;

    public NodePort Connection
    {
      get
      {
        for (int index = 0; index < this.connections.Count; ++index)
        {
          if (this.connections[index] != null)
            return this.connections[index].Port;
        }
        return (NodePort) null;
      }
    }

    public NodePort.IO direction => this._direction;

    public Node.ConnectionType connectionType => this._connectionType;

    public bool IsConnected => this.connections.Count != 0;

    public bool IsInput => this.direction == NodePort.IO.Input;

    public bool IsOutput => this.direction == NodePort.IO.Output;

    public string fieldName => this._fieldName;

    public Node node => this._node;

    public bool IsDynamic => this._dynamic;

    public bool IsStatic => !this._dynamic;

    public System.Type ValueType
    {
      get
      {
        if (this.valueType == (System.Type) null && !string.IsNullOrEmpty(this._typeQualifiedName))
          this.valueType = System.Type.GetType(this._typeQualifiedName, false);
        return this.valueType;
      }
      set
      {
        this.valueType = value;
        if (!(value != (System.Type) null))
          return;
        this._typeQualifiedName = value.AssemblyQualifiedName;
      }
    }

    public NodePort(FieldInfo fieldInfo)
    {
      this._fieldName = fieldInfo.Name;
      this.ValueType = fieldInfo.FieldType;
      this._dynamic = false;
      object[] customAttributes = fieldInfo.GetCustomAttributes(false);
      for (int index = 0; index < customAttributes.Length; ++index)
      {
        if (customAttributes[index] is Node.InputAttribute)
        {
          this._direction = NodePort.IO.Input;
          this._connectionType = (customAttributes[index] as Node.InputAttribute).connectionType;
        }
        else if (customAttributes[index] is Node.OutputAttribute)
        {
          this._direction = NodePort.IO.Output;
          this._connectionType = (customAttributes[index] as Node.OutputAttribute).connectionType;
        }
      }
    }

    public NodePort(NodePort nodePort, Node node)
    {
      this._fieldName = nodePort._fieldName;
      this.ValueType = nodePort.valueType;
      this._direction = nodePort.direction;
      this._dynamic = nodePort._dynamic;
      this._connectionType = nodePort._connectionType;
      this._node = node;
    }

    public NodePort(
      string fieldName,
      System.Type type,
      NodePort.IO direction,
      Node.ConnectionType connectionType,
      Node node)
    {
      this._fieldName = fieldName;
      this.ValueType = type;
      this._direction = direction;
      this._node = node;
      this._dynamic = true;
      this._connectionType = connectionType;
    }

    public void VerifyConnections()
    {
      for (int index = this.connections.Count - 1; index >= 0; --index)
      {
        if (!((UnityEngine.Object) this.connections[index].node != (UnityEngine.Object) null) || string.IsNullOrEmpty(this.connections[index].fieldName) || this.connections[index].node.GetPort(this.connections[index].fieldName) == null)
          this.connections.RemoveAt(index);
      }
    }

    public object GetOutputValue()
    {
      return this.direction == NodePort.IO.Input ? (object) null : this.node.GetValue(this);
    }

    public object GetInputValue() => this.Connection?.GetOutputValue();

    public object[] GetInputValues()
    {
      object[] inputValues = new object[this.ConnectionCount];
      for (int index = 0; index < this.ConnectionCount; ++index)
      {
        NodePort port = this.connections[index].Port;
        if (port == null)
        {
          this.connections.RemoveAt(index);
          --index;
        }
        else
          inputValues[index] = port.GetOutputValue();
      }
      return inputValues;
    }

    public T GetInputValue<T>()
    {
      return !(this.GetInputValue() is T inputValue) ? default (T) : inputValue;
    }

    public T[] GetInputValues<T>()
    {
      object[] inputValues1 = this.GetInputValues();
      T[] inputValues2 = new T[inputValues1.Length];
      for (int index = 0; index < inputValues1.Length; ++index)
      {
        if (inputValues1[index] is T)
          inputValues2[index] = (T) inputValues1[index];
      }
      return inputValues2;
    }

    public bool TryGetInputValue<T>(out T value)
    {
      if (this.GetInputValue() is T inputValue)
      {
        value = inputValue;
        return true;
      }
      value = default (T);
      return false;
    }

    public float GetInputSum(float fallback)
    {
      object[] inputValues = this.GetInputValues();
      if (inputValues.Length == 0)
        return fallback;
      float inputSum = 0.0f;
      for (int index = 0; index < inputValues.Length; ++index)
      {
        if (inputValues[index] is float)
          inputSum += (float) inputValues[index];
      }
      return inputSum;
    }

    public int GetInputSum(int fallback)
    {
      object[] inputValues = this.GetInputValues();
      if (inputValues.Length == 0)
        return fallback;
      int inputSum = 0;
      for (int index = 0; index < inputValues.Length; ++index)
      {
        if (inputValues[index] is int)
          inputSum += (int) inputValues[index];
      }
      return inputSum;
    }

    public void Connect(NodePort port)
    {
      if (this.connections == null)
        this.connections = new List<NodePort.PortConnection>();
      if (port == null)
        Debug.LogWarning((object) "Cannot connect to null port");
      else if (port == this)
        Debug.LogWarning((object) "Attempting to connect port to self.");
      else if (this.IsConnectedTo(port))
        Debug.LogWarning((object) "Port already connected. ");
      else if (this.direction == port.direction)
      {
        Debug.LogWarning((object) ("Cannot connect two " + (this.direction == NodePort.IO.Input ? "input" : "output") + " connections"));
      }
      else
      {
        if (port.connectionType == Node.ConnectionType.Override && port.ConnectionCount != 0)
          port.ClearConnections();
        if (this.connectionType == Node.ConnectionType.Override && this.ConnectionCount != 0)
          this.ClearConnections();
        this.connections.Add(new NodePort.PortConnection(port));
        if (port.connections == null)
          port.connections = new List<NodePort.PortConnection>();
        if (!port.IsConnectedTo(this))
          port.connections.Add(new NodePort.PortConnection(this));
        this.node.OnCreateConnection(this, port);
        port.node.OnCreateConnection(this, port);
      }
    }

    public NodePort GetConnection(int i)
    {
      if ((UnityEngine.Object) this.connections[i].node == (UnityEngine.Object) null || string.IsNullOrEmpty(this.connections[i].fieldName))
      {
        this.connections.RemoveAt(i);
        return (NodePort) null;
      }
      NodePort port = this.connections[i].node.GetPort(this.connections[i].fieldName);
      if (port != null)
        return port;
      this.connections.RemoveAt(i);
      return (NodePort) null;
    }

    public bool IsConnectedTo(NodePort port)
    {
      for (int index = 0; index < this.connections.Count; ++index)
      {
        if (this.connections[index].Port == port)
          return true;
      }
      return false;
    }

    public void Disconnect(NodePort port)
    {
      for (int index = this.connections.Count - 1; index >= 0; --index)
      {
        if (this.connections[index].Port == port)
          this.connections.RemoveAt(index);
      }
      if (port != null)
      {
        for (int index = 0; index < port.connections.Count; ++index)
        {
          if (port.connections[index].Port == this)
            port.connections.RemoveAt(index);
        }
      }
      this.node.OnRemoveConnection(this);
      port?.node.OnRemoveConnection(port);
    }

    public void ClearConnections()
    {
      while (this.connections.Count > 0)
        this.Disconnect(this.connections[0].Port);
    }

    public void Redirect(List<Node> oldNodes, List<Node> newNodes)
    {
      foreach (NodePort.PortConnection connection in this.connections)
      {
        int index = oldNodes.IndexOf(connection.node);
        if (index >= 0)
          connection.node = newNodes[index];
      }
    }

    public enum IO
    {
      Input,
      Output,
    }

    [Serializable]
    private class PortConnection
    {
      [SerializeField]
      public string fieldName;
      [SerializeField]
      public Node node;
      [NonSerialized]
      private NodePort port;

      public NodePort Port => this.port == null ? (this.port = this.GetPort()) : this.port;

      public PortConnection(NodePort port)
      {
        this.port = port;
        this.node = port.node;
        this.fieldName = port.fieldName;
      }

      private NodePort GetPort()
      {
        return (UnityEngine.Object) this.node == (UnityEngine.Object) null || string.IsNullOrEmpty(this.fieldName) ? (NodePort) null : this.node.GetPort(this.fieldName);
      }
    }
  }
}
