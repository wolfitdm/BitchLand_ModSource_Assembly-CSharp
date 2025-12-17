// Decompiled with JetBrains decompiler
// Type: Terra.Nodes.Generation.AbsVoronoiNoiseNode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using Terra.Graph.Noise;
using XNode;

#nullable disable
namespace Terra.Nodes.Generation;

public abstract class AbsVoronoiNoiseNode : AbsGeneratorNode
{
  [Node.Input(Node.ShowBackingValue.Unconnected, Node.ConnectionType.Multiple)]
  public float Frequency;
  [Node.Input(Node.ShowBackingValue.Unconnected, Node.ConnectionType.Multiple)]
  public float Period;
  protected const string MENU_PARENT_NAME = "Terrain/Noise/Voronoi/";
}
