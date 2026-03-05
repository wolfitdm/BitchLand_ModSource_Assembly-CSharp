// Decompiled with JetBrains decompiler
// Type: Peace.Serialization.PerlinInfo
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
