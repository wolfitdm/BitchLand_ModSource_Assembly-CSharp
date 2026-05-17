// Decompiled with JetBrains decompiler
// Type: HeightMapModifier_SetValue
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class HeightMapModifier_SetValue : BaseHeightMapModifier
{
  [SerializeField]
  private float TargetHeight;

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
          float b = this.TargetHeight / heightmapScale.y;
          heightMap[index2, index1] = Mathf.Lerp(heightMap[index2, index1], b, this.Strength);
        }
      }
    }
  }
}
