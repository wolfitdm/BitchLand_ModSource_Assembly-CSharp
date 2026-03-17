// Decompiled with JetBrains decompiler
// Type: Peace.Serialization.PerlinInfo
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
namespace Peace.Serialization
{
  [Serializable]
  public class PerlinInfo
  {
    public int octaves = 5;
    public double persistence = 0.45;
    public bool repeatable;
    public int reference;
    public double frequency = 4.0;
  }
}
