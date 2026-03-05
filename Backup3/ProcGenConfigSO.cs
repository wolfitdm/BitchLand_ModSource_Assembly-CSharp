// Decompiled with JetBrains decompiler
// Type: ProcGenConfigSO
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
[CreateAssetMenu(fileName = "ProcGen Config", menuName = "Procedural Generation/ProcGen Configuration", order = -1)]
public class ProcGenConfigSO : ScriptableObject
{
  public List<BiomeConfig> Biomes;
  [Range(0.0f, 1f)]
  public float BiomeSeedPointDensity = 0.1f;
  public ProcGenConfigSO.EBiomeMapBaseResolution BiomeMapResolution = ProcGenConfigSO.EBiomeMapBaseResolution.Size_64x64;
  public GameObject InitialHeightModifier;
  public GameObject HeightPostProcessingModifier;
  public GameObject PaintingPostProcessingModifier;
  public float WaterHeight = 15f;

  public int NumBiomes => this.Biomes.Count;

  public float TotalWeighting
  {
    get
    {
      float totalWeighting = 0.0f;
      foreach (BiomeConfig biome in this.Biomes)
        totalWeighting += biome.Weighting;
      return totalWeighting;
    }
  }

  public enum EBiomeMapBaseResolution
  {
    Size_64x64 = 64, // 0x00000040
    Size_128x128 = 128, // 0x00000080
    Size_256x256 = 256, // 0x00000100
    Size_512x512 = 512, // 0x00000200
  }
}
