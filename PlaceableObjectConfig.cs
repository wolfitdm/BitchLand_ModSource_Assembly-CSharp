// Decompiled with JetBrains decompiler
// Type: PlaceableObjectConfig
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
