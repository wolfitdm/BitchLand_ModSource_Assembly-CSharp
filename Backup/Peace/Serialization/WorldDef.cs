// Decompiled with JetBrains decompiler
// Type: Peace.Serialization.WorldDef
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Peace.Serialization;

[Serializable]
public class WorldDef
{
  public HeightmapGroundDef ground = new HeightmapGroundDef();
  public List<string> nodes = new List<string>();
}
