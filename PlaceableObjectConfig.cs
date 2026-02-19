// Decompiled with JetBrains decompiler
// Type: PlaceableObjectConfig
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
