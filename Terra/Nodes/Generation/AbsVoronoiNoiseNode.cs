// Decompiled with JetBrains decompiler
// Type: Terra.Nodes.Generation.AbsVoronoiNoiseNode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
