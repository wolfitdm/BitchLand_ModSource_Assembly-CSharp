// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Patterns.Helpers
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
