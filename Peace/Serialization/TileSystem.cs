// Decompiled with JetBrains decompiler
// Type: Peace.Serialization.TileSystem
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace Peace.Serialization
{
  [Serializable]
  public struct TileSystem
  {
    public int maxLod;
    public int factor;
    public Vector3 baseSize;
    public Vector3Int bufferRes;
  }
}
