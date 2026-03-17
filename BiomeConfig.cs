// Decompiled with JetBrains decompiler
// Type: BiomeConfig
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
[Serializable]
public class BiomeConfig
{
  public BiomeConfigSO Biome;
  [Range(0.0f, 1f)]
  public float Weighting = 1f;
}
