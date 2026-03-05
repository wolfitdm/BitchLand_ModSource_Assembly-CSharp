// Decompiled with JetBrains decompiler
// Type: BaseHeightMapModifier
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
