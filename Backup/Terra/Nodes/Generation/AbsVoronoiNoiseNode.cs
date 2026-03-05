// Decompiled with JetBrains decompiler
// Type: Terra.Nodes.Generation.AbsVoronoiNoiseNode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
