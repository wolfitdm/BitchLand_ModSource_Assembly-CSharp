// Decompiled with JetBrains decompiler
// Type: BiomeConfigSO
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
