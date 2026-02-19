// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Cache
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
