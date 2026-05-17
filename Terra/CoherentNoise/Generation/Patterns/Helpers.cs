// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Patterns.Helpers
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace Terra.CoherentNoise.Generation.Patterns
{
  internal class Helpers
  {
    public static float Saw(float x)
    {
      int num = Mathf.FloorToInt(x);
      return num % 2 == 0 ? (float) (2.0 * ((double) x - (double) num) - 1.0) : (float) (2.0 * (1.0 - ((double) x - (double) num)) - 1.0);
    }
  }
}
