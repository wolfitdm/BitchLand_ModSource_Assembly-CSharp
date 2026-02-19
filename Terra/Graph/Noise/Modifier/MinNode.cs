// Decompiled with JetBrains decompiler
// Type: Terra.Graph.Noise.Modifier.MinNode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using Terra.CoherentNoise;
using Terra.CoherentNoise.Generation.Combination;
using XNode;

#nullable disable
namespace Terra.Graph.Noise.Modifier
{
  [Node.CreateNodeMenu("Modifier/Min")]
  public class MinNode : AbsTwoModNode
  {
    public override Generator GetGenerator()
    {
      return !this.HasBothGenerators() ? (Generator) null : (Generator) new Min(this.GetGenerator1(), this.GetGenerator2());
    }

    public override string GetTitle() => "Min";
  }
}
