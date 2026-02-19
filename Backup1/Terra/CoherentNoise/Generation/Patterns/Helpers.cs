// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Patterns.Helpers
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
