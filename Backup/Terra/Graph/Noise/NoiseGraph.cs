// Decompiled with JetBrains decompiler
// Type: Terra.Graph.Noise.NoiseGraph
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using Terra.CoherentNoise;
using UnityEngine;
using XNode;

#nullable disable
namespace Terra.Graph.Noise;

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
