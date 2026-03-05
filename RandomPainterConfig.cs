// Decompiled with JetBrains decompiler
// Type: RandomPainterConfig
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
