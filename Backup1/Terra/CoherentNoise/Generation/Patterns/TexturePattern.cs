// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Generation.Patterns.TexturePattern
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace Terra.CoherentNoise.Generation.Patterns
{
  public class TexturePattern : Generator
  {
    private readonly Color[] m_Colors;
    private readonly int m_Width;
    private readonly int m_Height;
    private readonly TextureWrapMode m_WrapMode;

    public TexturePattern(Texture2D texture, TextureWrapMode wrapMode)
    {
      this.m_Colors = texture.GetPixels();
      this.m_Width = texture.width;
      this.m_Height = texture.height;
      this.m_WrapMode = wrapMode;
    }

    public override float GetValue(float x, float y, float z)
    {
      int i1 = Mathf.FloorToInt(x * (float) this.m_Width);
      int i2 = Mathf.FloorToInt(y * (float) this.m_Height);
      int num = this.Wrap(i1, this.m_Width);
      return (float) ((double) this.m_Colors[this.Wrap(i2, this.m_Height) * this.m_Width + num].r * 2.0 - 1.0);
    }

    private int Wrap(int i, int size)
    {
      switch (this.m_WrapMode)
      {
        case TextureWrapMode.Repeat:
          return i < 0 ? i % size + size : i % size;
        case TextureWrapMode.Clamp:
          if (i < 0)
            return 0;
          return i <= size ? i : size - 1;
        default:
          throw new ArgumentOutOfRangeException();
      }
    }
  }
}
