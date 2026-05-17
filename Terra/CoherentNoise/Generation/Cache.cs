// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Cache
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Terra.CoherentNoise.Generation
{
  public class Cache : Generator
  {
    private float m_X;
    private float m_Y;
    private float m_Z;
    private float m_Cached;
    private readonly Generator m_Source;

    public Cache(Generator source) => this.m_Source = source;

    public override float GetValue(float x, float y, float z)
    {
      if ((double) x == (double) this.m_X && (double) y == (double) this.m_Y && (double) z == (double) this.m_Z)
        return this.m_Cached;
      this.m_X = x;
      this.m_Y = y;
      this.m_Z = z;
      return this.m_Cached = this.m_Source.GetValue(x, y, z);
    }
  }
}
