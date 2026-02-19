// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Interpolation.CosineSCurve
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
namespace Terra.CoherentNoise.Interpolation;

internal class CosineSCurve : SCurve
{
  public override float Interpolate(float t)
  {
    return (float) ((1.0 - Math.Cos((double) t * 3.1415927)) * 0.5);
  }
}
