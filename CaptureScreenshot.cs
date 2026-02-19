// Decompiled with JetBrains decompiler
// Type: CaptureScreenshot
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.IO;
using UnityEngine;

#nullable disable
public static class CaptureScreenshot
{
  public static void CaptureTransparentScreenshot(
    Camera cam,
    int width,
    int height,
    string screengrabfile_path)
  {
    RenderTexture targetTexture = cam.targetTexture;
    CameraClearFlags clearFlags = cam.clearFlags;
    RenderTexture active = RenderTexture.active;
    Texture2D texture2D1 = new Texture2D(width, height, TextureFormat.ARGB32, false);
    Texture2D texture2D2 = new Texture2D(width, height, TextureFormat.ARGB32, false);
    Texture2D tex = new Texture2D(width, height, TextureFormat.ARGB32, false);
    RenderTexture temporary = RenderTexture.GetTemporary(width, height, 24, RenderTextureFormat.ARGB32);
    Rect source = new Rect(0.0f, 0.0f, (float) width, (float) height);
    RenderTexture.active = temporary;
    cam.targetTexture = temporary;
    cam.clearFlags = CameraClearFlags.Color;
    cam.backgroundColor = Color.black;
    cam.Render();
    texture2D2.ReadPixels(source, 0, 0);
    texture2D2.Apply();
    cam.backgroundColor = Color.white;
    cam.Render();
    texture2D1.ReadPixels(source, 0, 0);
    texture2D1.Apply();
    for (int y = 0; y < tex.height; ++y)
    {
      for (int x = 0; x < tex.width; ++x)
      {
        float num = 1f - (texture2D1.GetPixel(x, y).r - texture2D2.GetPixel(x, y).r);
        Color color = ((double) num != 0.0 ? texture2D2.GetPixel(x, y) / num : Color.clear) with
        {
          a = num
        };
        tex.SetPixel(x, y, color);
      }
    }
    byte[] png = tex.EncodeToPNG();
    File.WriteAllBytes(screengrabfile_path, png);
    cam.clearFlags = clearFlags;
    cam.targetTexture = targetTexture;
    RenderTexture.active = active;
    RenderTexture.ReleaseTemporary(temporary);
    Object.Destroy((Object) texture2D2);
    Object.Destroy((Object) texture2D1);
    Object.Destroy((Object) tex);
  }

  public static void SimpleCaptureTransparentScreenshot(
    Camera cam,
    int width,
    int height,
    string screengrabfile_path)
  {
    RenderTexture targetTexture = cam.targetTexture;
    CameraClearFlags clearFlags = cam.clearFlags;
    RenderTexture active = RenderTexture.active;
    Texture2D tex = new Texture2D(width, height, TextureFormat.ARGB32, false);
    RenderTexture temporary = RenderTexture.GetTemporary(width, height, 24, RenderTextureFormat.ARGB32);
    Rect source = new Rect(0.0f, 0.0f, (float) width, (float) height);
    RenderTexture.active = temporary;
    cam.targetTexture = temporary;
    cam.clearFlags = CameraClearFlags.Color;
    cam.backgroundColor = Color.clear;
    cam.Render();
    tex.ReadPixels(source, 0, 0);
    tex.Apply();
    byte[] png = tex.EncodeToPNG();
    File.WriteAllBytes(screengrabfile_path, png);
    cam.clearFlags = clearFlags;
    cam.targetTexture = targetTexture;
    RenderTexture.active = active;
    RenderTexture.ReleaseTemporary(temporary);
    Object.Destroy((Object) tex);
  }
}
