// Decompiled with JetBrains decompiler
// Type: Terra.Graph.Noise.NoiseGraph
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
