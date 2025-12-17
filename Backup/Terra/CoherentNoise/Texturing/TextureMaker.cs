// Decompiled with JetBrains decompiler
// Type: Terra.CoherentNoise.Texturing.TextureMaker
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace Terra.CoherentNoise.Texturing;

public static class TextureMaker
{
  public static Texture Make(
    int width,
    int height,
    Func<float, float, Color> colorFunc,
    TextureFormat format = TextureFormat.RGB24)
  {
    Color[] colors = new Color[width * height];
    for (int index1 = 0; index1 < width; ++index1)
    {
      for (int index2 = 0; index2 < height; ++index2)
        colors[index1 + index2 * width] = colorFunc((float) index1 / (float) width, (float) index2 / (float) height);
    }
    Texture2D texture2D = new Texture2D(width, height, format, false);
    texture2D.SetPixels(colors, 0);
    texture2D.Apply();
    return (Texture) texture2D;
  }

  public static Texture AlphaTexture(int width, int height, Generator noise)
  {
    return TextureMaker.Make(width, height, (Func<float, float, Color>) ((x, y) => new Color(0.0f, 0.0f, 0.0f, (float) ((double) noise.GetValue(x, y, 0.0f) * 0.5 + 0.5))), TextureFormat.Alpha8);
  }

  public static Texture MonochromeTexture(int width, int height, Generator noise)
  {
    return TextureMaker.Make(width, height, (Func<float, float, Color>) ((x, y) =>
    {
      double num = (double) noise.GetValue(x, y, 0.0f) * 0.5 + 0.5;
      return new Color((float) num, (float) num, (float) num, 1f);
    }));
  }

  public static Texture RampTexture(int width, int height, Generator noise, Texture2D ramp)
  {
    Color[] rampCols = ramp.GetPixels(0, 0, ramp.width, 1);
    return TextureMaker.Make(width, height, (Func<float, float, Color>) ((x, y) => rampCols[(int) ((double) Mathf.Clamp01((float) ((double) noise.GetValue(x, y, 0.0f) * 0.5 + 0.5)) * (double) (ramp.width - 1))]));
  }

  public static Texture BumpMap(int width, int height, Generator noise)
  {
    Texture2D texture2D = new Texture2D(width, height, TextureFormat.RGB24, false);
    for (int miplevel = 0; miplevel < texture2D.mipmapCount; ++miplevel)
    {
      Color[] colors = new Color[width * height];
      for (int index1 = 0; index1 < width; ++index1)
      {
        for (int index2 = 0; index2 < height; ++index2)
        {
          float num1 = noise.GetValue(((float) index1 - 0.5f) / (float) width, (float) index2 / (float) height, 0.0f);
          double num2 = (double) noise.GetValue(((float) index1 + 0.5f) / (float) width, (float) index2 / (float) height, 0.0f);
          float num3 = noise.GetValue((float) index1 / (float) width, ((float) index2 - 0.5f) / (float) height, 0.0f);
          float num4 = noise.GetValue((float) index1 / (float) width, ((float) index2 + 0.5f) / (float) height, 0.0f);
          double num5 = (double) num1;
          Vector3 normalized = new Vector3((float) (num2 - num5), num4 - num3, 1f).normalized;
          colors[index1 + index2 * width] = new Color(normalized.x, normalized.y, normalized.z);
        }
      }
      texture2D.SetPixels(colors, miplevel);
      width >>= 1;
      height >>= 1;
    }
    texture2D.Apply(false);
    return (Texture) texture2D;
  }
}
