// Decompiled with JetBrains decompiler
// Type: BLTerrainGenerator
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using Terra.Terrain;
using UnityEngine;

#nullable disable
public class BLTerrainGenerator : MonoBehaviour
{
  public UnityEngine.Terrain DefaultTerrain;
  public TerraSettings _Terra;

  private void Start()
  {
  }

  private void Update()
  {
  }

  public static float GetNoiseAt(
    int x,
    int z,
    float scale,
    float heightMultiplier,
    int octaves,
    float persistance,
    float lacunarity)
  {
    float num1 = 0.0f;
    float num2 = 1f;
    float num3 = 1f;
    for (int index = 0; index < octaves; ++index)
    {
      num1 += Mathf.PerlinNoise((float) x * num3, (float) z * num3) * num2;
      num2 *= persistance;
      num3 *= lacunarity;
    }
    return num1 * heightMultiplier;
  }
}
