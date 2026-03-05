// Decompiled with JetBrains decompiler
// Type: Terra.Graph.Noise.AbsGeneratorNode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using Terra.CoherentNoise;
using UnityEngine;
using XNode;

#nullable disable
namespace Terra.Graph.Noise
{
  public abstract class AbsGeneratorNode : XNode.Node
  {
    [XNode.Node.Output(XNode.Node.ShowBackingValue.Never, XNode.Node.ConnectionType.Multiple)]
    public AbsGeneratorNode Output;

    public override object GetValue(NodePort port) => (object) this;

    public void OnValueChange()
    {
      Stack<XNode.Node> nodeStack = new Stack<XNode.Node>();
      Dictionary<XNode.Node, bool> dictionary = new Dictionary<XNode.Node, bool>();
      nodeStack.Push((XNode.Node) this);
      while (nodeStack.Count != 0)
      {
        XNode.Node key = nodeStack.Pop();
        if (!dictionary.ContainsKey(key) || !dictionary[key])
          dictionary[key] = true;
        foreach (NodePort output in key.Outputs)
        {
          if (output != null)
          {
            for (int i = 0; i < output.ConnectionCount; ++i)
            {
              XNode.Node node = output.GetConnection(i).node;
              if ((Object) node != (Object) null && (!dictionary.ContainsKey(node) || !dictionary[node]))
                nodeStack.Push(node);
            }
          }
        }
        NoisePreviewNode noisePreviewNode = key as NoisePreviewNode;
        if ((Object) noisePreviewNode != (Object) null)
          noisePreviewNode.InvalidateTexture();
      }
    }

    internal static bool HasAllGenerators(params AbsGeneratorNode[] gens)
    {
      foreach (AbsGeneratorNode gen in gens)
      {
        if ((Object) gen == (Object) null || gen.GetGenerator() == null)
          return false;
      }
      return true;
    }

    public abstract Generator GetGenerator();

    public abstract string GetTitle();
  }
}
