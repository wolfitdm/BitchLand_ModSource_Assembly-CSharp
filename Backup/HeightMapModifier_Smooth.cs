// Decompiled with JetBrains decompiler
// Type: HeightMapModifier_Smooth
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class HeightMapModifier_Smooth : BaseHeightMapModifier
{
  [SerializeField]
  private int SmoothingKernelSize = 5;
  [SerializeField]
  private bool UseAdaptiveKernel;
  [SerializeField]
  [Range(0.0f, 1f)]
  private float MaxHeightThreshold = 0.5f;
  [SerializeField]
  private int MinKernelSize = 2;
  [SerializeField]
  private int MaxKernelSize = 7;

  public override void Execute(
    ProcGenConfigSO globalConfig,
    int mapResolution,
    float[,] heightMap,
    Vector3 heightmapScale,
    byte[,] biomeMap = null,
    int biomeIndex = -1,
    BiomeConfigSO biome = null)
  {
    if (biomeMap != null)
    {
      Debug.LogError((object) $"HeightMapModifier_Smooth is not supported as a per biome modifier [{this.gameObject.name}]");
    }
    else
    {
      float[,] numArray = new float[mapResolution, mapResolution];
      for (int index1 = 0; index1 < mapResolution; ++index1)
      {
        for (int index2 = 0; index2 < mapResolution; ++index2)
        {
          float num1 = 0.0f;
          int num2 = 0;
          int smoothingKernelSize = this.SmoothingKernelSize;
          if (this.UseAdaptiveKernel)
            smoothingKernelSize = Mathf.RoundToInt(Mathf.Lerp((float) this.MaxKernelSize, (float) this.MinKernelSize, heightMap[index2, index1] / this.MaxHeightThreshold));
          for (int index3 = -smoothingKernelSize; index3 <= smoothingKernelSize; ++index3)
          {
            int index4 = index1 + index3;
            if (index4 >= 0 && index4 < mapResolution)
            {
              for (int index5 = -smoothingKernelSize; index5 <= smoothingKernelSize; ++index5)
              {
                int index6 = index2 + index5;
                if (index6 >= 0 && index6 < mapResolution)
                {
                  num1 += heightMap[index6, index4];
                  ++num2;
                }
              }
            }
          }
          numArray[index2, index1] = num1 / (float) num2;
        }
      }
      for (int index7 = 0; index7 < mapResolution; ++index7)
      {
        for (int index8 = 0; index8 < mapResolution; ++index8)
          heightMap[index8, index7] = Mathf.Lerp(heightMap[index8, index7], numArray[index8, index7], this.Strength);
      }
    }
  }
}
