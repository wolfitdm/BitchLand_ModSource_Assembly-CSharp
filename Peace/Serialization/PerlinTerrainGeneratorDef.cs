// Decompiled with JetBrains decompiler
// Type: Peace.Serialization.PerlinTerrainGeneratorDef
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
namespace Peace.Serialization
{
  [Serializable]
  public class PerlinTerrainGeneratorDef : IGroundWorkerDef
  {
    public string type = "PerlinTerrainGenerator";
    public int maxOctaves = 11;
    public PerlinInfo perlinInfo = new PerlinInfo();
  }
}
