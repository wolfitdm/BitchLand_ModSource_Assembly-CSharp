// Decompiled with JetBrains decompiler
// Type: BaseTexturePainter
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
