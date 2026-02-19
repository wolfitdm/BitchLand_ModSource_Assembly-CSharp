// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.LatticeNoise
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Terra.CoherentNoise
{
  internal class LatticeNoise
  {
    private int m_Seed;

    internal LatticeNoise(int seed) => this.m_Seed = seed;

    internal int Period { get; set; }

    internal float GetValue(int x, int y, int z)
    {
      if (this.Period > 0)
      {
        x %= this.Period;
        if (x < 0)
          x += this.Period;
        y %= this.Period;
        if (y < 0)
          y += this.Period;
        z %= this.Period;
        if (z < 0)
          z += this.Period;
      }
      int num1 = 1619 * x + 31337 * y + 6971 * z + 1013 * this.m_Seed & int.MaxValue;
      int num2 = num1 >> 13 ^ num1;
      return (float) (1.0 - (double) (num2 * (num2 * num2 * 60493 + 19990303) + 1376312589 & int.MaxValue) / 1073741824.0);
    }
  }
}
