// Decompiled with JetBrains decompiler
// Type: Peace.Serialization.CustomWorldRMModifierDef
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
