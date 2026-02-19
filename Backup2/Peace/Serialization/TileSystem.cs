// Decompiled with JetBrains decompiler
// Type: Peace.Serialization.TileSystem
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace Peace.Serialization;

[Serializable]
public struct TileSystem
{
  public int maxLod;
  public int factor;
  public Vector3 baseSize;
  public Vector3Int bufferRes;
}
