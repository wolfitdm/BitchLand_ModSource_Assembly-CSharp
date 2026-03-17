// Decompiled with JetBrains decompiler
// Type: Terra.Nodes.Generation.AbsVoronoiNoiseNode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using Terra.Graph.Noise;
using XNode;

#nullable disable
namespace Terra.Nodes.Generation
{
  public abstract class AbsVoronoiNoiseNode : AbsGeneratorNode
  {
    [Node.Input(Node.ShowBackingValue.Unconnected, Node.ConnectionType.Multiple)]
    public float Frequency;
    [Node.Input(Node.ShowBackingValue.Unconnected, Node.ConnectionType.Multiple)]
    public float Period;
    protected const string MENU_PARENT_NAME = "Terrain/Noise/Voronoi/";
  }
}
