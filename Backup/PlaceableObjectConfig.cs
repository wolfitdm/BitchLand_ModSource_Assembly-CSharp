// Decompiled with JetBrains decompiler
// Type: PlaceableObjectConfig
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
[Serializable]
public class PlaceableObjectConfig
{
  public bool HasHeightLimits;
  public float MinHeightToSpawn;
  public float MaxHeightToSpawn;
  public bool CanGoInWater;
  public bool CanGoAboveWater = true;
  [Range(0.0f, 1f)]
  public float Weighting = 1f;
  public List<GameObject> Prefabs;

  public float NormalisedWeighting { get; set; }
}
