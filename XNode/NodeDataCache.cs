// Decompiled with JetBrains decompiler
// Type: XNode.NodeDataCache
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace XNode
{
  public static class NodeDataCache
  {
    private static NodeDataCache.PortDataCache portDataCache;

    private static bool Initialized => NodeDataCache.portDataCache != null;

    public static void UpdatePorts(Node node, Dictionary<string, NodePort> ports)
    {
      if (!NodeDataCache.Initialized)
        NodeDataCache.BuildCache();
      Dictionary<string, NodePort> dictionary = new Dictionary<string, NodePort>();
      System.Type type = node.GetType();
      if (NodeDataCache.portDataCache.ContainsKey(type))
      {
        for (int index = 0; index < NodeDataCache.portDataCache[type].Count; ++index)
          dictionary.Add(NodeDataCache.portDataCache[type][index].fieldName, NodeDataCache.portDataCache[type][index]);
      }
      foreach (NodePort nodePort1 in ports.Values.ToList<NodePort>())
      {
        if (dictionary.ContainsKey(nodePort1.fieldName))
        {
          NodePort nodePort2 = dictionary[nodePort1.fieldName];
          if (nodePort1.connectionType != nodePort2.connectionType || nodePort1.IsDynamic || nodePort1.direction != nodePort2.direction)
            ports.Remove(nodePort1.fieldName);
          else
            nodePort1.ValueType = nodePort2.ValueType;
        }
        else if (nodePort1.IsStatic)
          ports.Remove(nodePort1.fieldName);
      }
      foreach (NodePort nodePort in dictionary.Values)
      {
        if (!ports.ContainsKey(nodePort.fieldName))
          ports.Add(nodePort.fieldName, new NodePort(nodePort, node));
      }
    }

    private static void BuildCache()
    {
      NodeDataCache.portDataCache = new NodeDataCache.PortDataCache();
      System.Type baseType = typeof (Node);
      foreach (System.Type nodeType in ((IEnumerable<System.Type>) Assembly.GetAssembly(baseType).GetTypes()).Where<System.Type>((Func<System.Type, bool>) (t => !t.IsAbstract && baseType.IsAssignableFrom(t))).ToArray<System.Type>())
        NodeDataCache.CachePorts(nodeType);
    }

    private static void CachePorts(System.Type nodeType)
    {
      FieldInfo[] fields = nodeType.GetFields();
      for (int index = 0; index < fields.Length; ++index)
      {
        object[] customAttributes = fields[index].GetCustomAttributes(false);
        Node.InputAttribute inputAttribute = ((IEnumerable<object>) customAttributes).FirstOrDefault<object>((Func<object, bool>) (x => x is Node.InputAttribute)) as Node.InputAttribute;
        Node.OutputAttribute outputAttribute = ((IEnumerable<object>) customAttributes).FirstOrDefault<object>((Func<object, bool>) (x => x is Node.OutputAttribute)) as Node.OutputAttribute;
        if (inputAttribute != null || outputAttribute != null)
        {
          if (inputAttribute != null && outputAttribute != null)
          {
            Debug.LogError((object) ("Field " + fields[index].Name + " of type " + nodeType.FullName + " cannot be both input and output."));
          }
          else
          {
            if (!NodeDataCache.portDataCache.ContainsKey(nodeType))
              NodeDataCache.portDataCache.Add(nodeType, new List<NodePort>());
            NodeDataCache.portDataCache[nodeType].Add(new NodePort(fields[index]));
          }
        }
      }
    }

    [Serializable]
    private class PortDataCache : Dictionary<System.Type, List<NodePort>>, ISerializationCallbackReceiver
    {
      [SerializeField]
      private List<System.Type> keys = new List<System.Type>();
      [SerializeField]
      private List<List<NodePort>> values = new List<List<NodePort>>();

      public void OnBeforeSerialize()
      {
        this.keys.Clear();
        this.values.Clear();
        foreach (KeyValuePair<System.Type, List<NodePort>> keyValuePair in (Dictionary<System.Type, List<NodePort>>) this)
        {
          this.keys.Add(keyValuePair.Key);
          this.values.Add(keyValuePair.Value);
        }
      }

      public void OnAfterDeserialize()
      {
        this.Clear();
        if (this.keys.Count != this.values.Count)
          throw new Exception(string.Format("there are {0} keys and {1} values after deserialization. Make sure that both key and value types are serializable."));
        for (int index = 0; index < this.keys.Count; ++index)
          this.Add(this.keys[index], this.values[index]);
      }
    }
  }
}
