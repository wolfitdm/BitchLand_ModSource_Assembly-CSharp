// Decompiled with JetBrains decompiler
// Type: Terra.Graph.Noise.Modifier.MinNode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
