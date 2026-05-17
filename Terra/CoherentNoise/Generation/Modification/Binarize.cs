// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Modification.Binarize
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Terra.CoherentNoise.Generation.Modification
{
  public class Binarize : Generator
  {
    private readonly Generator m_Source;
    private readonly float m_Treshold;

    public Binarize(Generator source, float treshold)
    {
      this.m_Source = source;
      this.m_Treshold = treshold;
    }

    public override float GetValue(float x, float y, float z)
    {
      return (double) this.m_Source.GetValue(x, y, z) > (double) this.m_Treshold ? 1f : 0.0f;
    }
  }
}
