// Decompiled with JetBrains decompiler
// Type: Peace.Serialization.CustomWorldRMModifierDef
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace Peace.Serialization
{
  [Serializable]
  public class CustomWorldRMModifierDef : IGroundWorkerDef
  {
    public string type = "CustomWorldRMModifier";
    public double biomeDensity = 1.0;
    public double limitBrightness = 4.0;
    public TileSystem tileSystem = new TileSystem()
    {
      maxLod = 0,
      factor = 2,
      baseSize = new Vector3(400000f, 400000f, 0.0f),
      bufferRes = new Vector3Int(400, 400, 0)
    };
  }
}
