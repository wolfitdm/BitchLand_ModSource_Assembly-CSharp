// Decompiled with JetBrains decompiler
// Type: HeightMapModifier_Random
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class HeightMapModifier_Random : BaseHeightMapModifier
{
  [SerializeField]
  private float HeightDelta;

  public override void Execute(
    ProcGenConfigSO globalConfig,
    int mapResolution,
    float[,] heightMap,
    Vector3 heightmapScale,
    byte[,] biomeMap = null,
    int biomeIndex = -1,
    BiomeConfigSO biome = null)
  {
    for (int index1 = 0; index1 < mapResolution; ++index1)
    {
      for (int index2 = 0; index2 < mapResolution; ++index2)
      {
        if (biomeIndex < 0 || (int) biomeMap[index2, index1] == biomeIndex)
        {
          float b = heightMap[index2, index1] + Random.Range(-this.HeightDelta, this.HeightDelta) / heightmapScale.y;
          heightMap[index2, index1] = Mathf.Lerp(heightMap[index2, index1], b, this.Strength);
        }
      }
    }
  }
}
