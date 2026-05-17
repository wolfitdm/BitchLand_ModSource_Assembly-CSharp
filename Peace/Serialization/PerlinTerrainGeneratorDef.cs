// Decompiled with JetBrains decompiler
// Type: Peace.Serialization.PerlinTerrainGeneratorDef
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
