// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Patterns.Helpers
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace Terra.CoherentNoise.Generation.Patterns;

internal class Helpers
{
  public static float Saw(float x)
  {
    int num = Mathf.FloorToInt(x);
    return num % 2 == 0 ? (float) (2.0 * ((double) x - (double) num) - 1.0) : (float) (2.0 * (1.0 - ((double) x - (double) num)) - 1.0);
  }
}
