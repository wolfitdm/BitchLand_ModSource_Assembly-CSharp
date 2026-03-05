// Decompiled with JetBrains decompiler
// Type: Terra.Graph.Noise.NoiseGraph
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
