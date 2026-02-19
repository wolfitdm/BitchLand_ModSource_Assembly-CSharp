// Decompiled with JetBrains decompiler
// Type: Peace.Serialization.CustomWorldRMModifierDef
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace Peace.Serialization;

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
