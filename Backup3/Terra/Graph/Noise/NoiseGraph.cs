// Decompiled with JetBrains decompiler
// Type: Terra.Graph.Noise.NoiseGraph
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using Terra.CoherentNoise;
using UnityEngine;
using XNode;

#nullable disable
namespace Terra.Graph.Noise
{
  [CreateAssetMenu(fileName = "New Noise Graph", menuName = "Terra/Noise Graph")]
  [Serializable]
  public class NoiseGraph : NodeGraph
  {
    public Generator GetEndGenerator()
    {
      foreach (Node node in this.nodes)
      {
        if (node is EndNode)
          return ((EndNode) node).GetFinalGenerator();
      }
      return (Generator) null;
    }
  }
}
