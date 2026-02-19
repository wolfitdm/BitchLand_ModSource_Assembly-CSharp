// Decompiled with JetBrains decompiler
// Type: TexturePainter_Smooth
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class TexturePainter_Smooth : BaseTexturePainter
{
  [SerializeField]
  private int SmoothingKernelSize = 5;

  public override void Execute(
    ProcGenManager manager,
    int mapResolution,
    float[,] heightMap,
    Vector3 heightmapScale,
    float[,] slopeMap,
    float[,,] alphaMaps,
    int alphaMapResolution,
    byte[,] biomeMap = null,
    int biomeIndex = -1,
    BiomeConfigSO biome = null)
  {
    if (biomeMap != null)
    {
      Debug.LogError((object) $"TexturePainter_Smooth is not supported as a per biome modifier [{this.gameObject.name}]");
    }
    else
    {
      for (int index1 = 0; index1 < alphaMaps.GetLength(2); ++index1)
      {
        float[,] numArray = new float[alphaMapResolution, alphaMapResolution];
        for (int index2 = 0; index2 < alphaMapResolution; ++index2)
        {
          for (int index3 = 0; index3 < alphaMapResolution; ++index3)
          {
            float num1 = 0.0f;
            int num2 = 0;
            for (int index4 = -this.SmoothingKernelSize; index4 <= this.SmoothingKernelSize; ++index4)
            {
              int index5 = index2 + index4;
              if (index5 >= 0 && index5 < alphaMapResolution)
              {
                for (int index6 = -this.SmoothingKernelSize; index6 <= this.SmoothingKernelSize; ++index6)
                {
                  int index7 = index3 + index6;
                  if (index7 >= 0 && index7 < alphaMapResolution)
                  {
                    num1 += alphaMaps[index7, index5, index1];
                    ++num2;
                  }
                }
              }
            }
            numArray[index3, index2] = num1 / (float) num2;
          }
        }
        for (int index8 = 0; index8 < alphaMapResolution; ++index8)
        {
          for (int index9 = 0; index9 < alphaMapResolution; ++index9)
            alphaMaps[index9, index8, index1] = Mathf.Lerp(alphaMaps[index9, index8, index1], numArray[index9, index8], this.Strength);
        }
      }
    }
  }
}
