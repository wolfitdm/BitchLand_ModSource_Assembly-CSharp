// Decompiled with JetBrains decompiler
// Type: BaseHeightMapModifier
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class BaseHeightMapModifier : MonoBehaviour
{
  [SerializeField]
  [Range(0.0f, 1f)]
  protected float Strength = 1f;

  public virtual void Execute(
    ProcGenConfigSO globalConfig,
    int mapResolution,
    float[,] heightMap,
    Vector3 heightmapScale,
    byte[,] biomeMap = null,
    int biomeIndex = -1,
    BiomeConfigSO biome = null)
  {
    Debug.LogError((object) ("No implementation of Execute function for " + this.gameObject.name));
  }
}
