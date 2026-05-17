// Decompiled with JetBrains decompiler
// Type: RandomPainterConfig
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
[Serializable]
public class RandomPainterConfig
{
  public TextureConfig TextureToPaint;
  [Range(0.0f, 1f)]
  public float IntensityModifier = 1f;
  public float NoiseScale;
  [Range(0.0f, 1f)]
  public float NoiseThreshold;
}
