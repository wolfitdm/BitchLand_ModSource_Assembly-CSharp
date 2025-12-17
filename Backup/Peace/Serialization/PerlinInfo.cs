// Decompiled with JetBrains decompiler
// Type: Peace.Serialization.PerlinInfo
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
namespace Peace.Serialization;

[Serializable]
public class PerlinInfo
{
  public int octaves = 5;
  public double persistence = 0.45;
  public bool repeatable;
  public int reference;
  public double frequency = 4.0;
}
