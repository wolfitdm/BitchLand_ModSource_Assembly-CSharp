// Decompiled with JetBrains decompiler
// Type: BiomeConfigSO
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
[CreateAssetMenu(fileName = "Biome Config", menuName = "Procedural Generation/Biome Configuration", order = -1)]
public class BiomeConfigSO : ScriptableObject
{
  public string Name;
  [Range(0.0f, 1f)]
  public float MinIntensity = 0.5f;
  [Range(0.0f, 1f)]
  public float MaxIntensity = 1f;
  [Range(0.0f, 1f)]
  public float MinDecayRate = 0.01f;
  [Range(0.0f, 1f)]
  public float MaxDecayRate = 0.02f;
  public GameObject HeightModifier;
  public GameObject TerrainPainter;
  public GameObject ObjectPlacer;

  public List<TextureConfig> RetrieveTextures()
  {
    if ((Object) this.TerrainPainter == (Object) null)
      return (List<TextureConfig>) null;
    List<TextureConfig> textureConfigList = new List<TextureConfig>();
    foreach (BaseTexturePainter component in this.TerrainPainter.GetComponents<BaseTexturePainter>())
    {
      List<TextureConfig> collection = component.RetrieveTextures();
      if (collection != null && collection.Count != 0)
        textureConfigList.AddRange((IEnumerable<TextureConfig>) collection);
    }
    return textureConfigList;
  }
}
