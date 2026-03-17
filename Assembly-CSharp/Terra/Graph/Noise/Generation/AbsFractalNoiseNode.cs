// Decompiled with JetBrains decompiler
// Type: Terra.Graph.Noise.Generation.AbsFractalNoiseNode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using XNode;

#nullable disable
namespace Terra.Graph.Noise.Generation
{
  public abstract class AbsFractalNoiseNode : AbsGeneratorNode
  {
    [Node.Input(Node.ShowBackingValue.Unconnected, Node.ConnectionType.Multiple)]
    public float Frequency = 1f;
    [Node.Input(Node.ShowBackingValue.Unconnected, Node.ConnectionType.Multiple)]
    public float Lacunarity = 2.17f;
    [Node.Input(Node.ShowBackingValue.Unconnected, Node.ConnectionType.Multiple)]
    public int OctaveCount = 6;
    protected const string MENU_PARENT_NAME = "Terrain/Noise/";
  }
}
