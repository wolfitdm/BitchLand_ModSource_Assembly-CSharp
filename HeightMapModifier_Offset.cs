// Decompiled with JetBrains decompiler
// Type: HeightMapModifier_Offset
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class HeightMapModifier_Offset : BaseHeightMapModifier
{
  [SerializeField]
  private float OffsetAmount;

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
          float b = heightMap[index2, index1] + this.OffsetAmount / heightmapScale.y;
          heightMap[index2, index1] = Mathf.Lerp(heightMap[index2, index1], b, this.Strength);
        }
      }
    }
  }
}
