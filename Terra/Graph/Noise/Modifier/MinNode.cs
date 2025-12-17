// Decompiled with JetBrains decompiler
// Type: Terra.Graph.Noise.Modifier.MinNode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using Terra.CoherentNoise;
using Terra.CoherentNoise.Generation.Combination;
using XNode;

#nullable disable
namespace Terra.Graph.Noise.Modifier;

[Node.CreateNodeMenu("Modifier/Min")]
public class MinNode : AbsTwoModNode
{
  public override Generator GetGenerator()
  {
    return !this.HasBothGenerators() ? (Generator) null : (Generator) new Min(this.GetGenerator1(), this.GetGenerator2());
  }

  public override string GetTitle() => "Min";
}
