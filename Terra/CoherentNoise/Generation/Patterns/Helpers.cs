// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Patterns.Helpers
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
