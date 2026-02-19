// Decompiled with JetBrains decompiler
// Type: RandomPainterConfig
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
