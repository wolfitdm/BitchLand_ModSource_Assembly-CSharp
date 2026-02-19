// Decompiled with JetBrains decompiler
// Type: Terra.Nodes.Generation.AbsVoronoiNoiseNode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
