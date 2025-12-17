// Decompiled with JetBrains decompiler
// Type: BaseTexturePainter
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class BaseTexturePainter : MonoBehaviour
{
  [SerializeField]
  [Range(0.0f, 1f)]
  protected float Strength = 1f;

  public virtual void Execute(
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
    Debug.LogError((object) ("No implementation of Execute function for " + this.gameObject.name));
  }

  public virtual List<TextureConfig> RetrieveTextures() => (List<TextureConfig>) null;
}
