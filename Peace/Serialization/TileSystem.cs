// Decompiled with JetBrains decompiler
// Type: Peace.Serialization.TileSystem
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
