// Decompiled with JetBrains decompiler
// Type: Terra.Graph.Noise.Modifier.AbsTwoModNode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using Terra.CoherentNoise;
using XNode;

#nullable disable
namespace Terra.Graph.Noise.Modifier
{
  public abstract class AbsTwoModNode : AbsGeneratorNode
  {
    [Node.Input(Node.ShowBackingValue.Never, Node.ConnectionType.Override)]
    public AbsGeneratorNode Generator1;
    [Node.Input(Node.ShowBackingValue.Never, Node.ConnectionType.Override)]
    public AbsGeneratorNode Generator2;
    internal const string MENU_PARENT_NAME = "Modifier/";

    protected bool HasBothGenerators()
    {
      return AbsGeneratorNode.HasAllGenerators(this.GetInputValue<AbsGeneratorNode>("Generator1"), this.GetInputValue<AbsGeneratorNode>("Generator2"));
    }

    protected Generator GetGenerator1()
    {
      return this.GetInputValue<AbsGeneratorNode>("Generator1").GetGenerator();
    }

    protected Generator GetGenerator2()
    {
      return this.GetInputValue<AbsGeneratorNode>("Generator2").GetGenerator();
    }
  }
}
