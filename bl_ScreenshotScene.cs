// Decompiled with JetBrains decompiler
// Type: bl_ScreenshotScene
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.IO;
using UnityEngine;

#nullable disable
public class bl_ScreenshotScene : MonoBehaviour
{
  public int screenshotFilename;
  public Camera captureCamera;

  private void Update()
  {
    if (!Input.GetKeyDown(KeyCode.S))
      return;
    this.CaptureScreenshot();
  }

  private void CaptureScreenshot()
  {
    if (!Directory.Exists(Application.streamingAssetsPath))
      Directory.CreateDirectory(Application.streamingAssetsPath);
    int width = Screen.width;
    int height = Screen.height;
    RenderTexture renderTexture = new RenderTexture(width, height, 32 /*0x20*/);
    this.captureCamera.targetTexture = renderTexture;
    Texture2D tex = new Texture2D(width, height, TextureFormat.ARGB32, false);
    this.captureCamera.Render();
    RenderTexture.active = renderTexture;
    tex.ReadPixels(new Rect(0.0f, 0.0f, (float) width, (float) height), 0, 0);
    tex.Apply();
    RenderTexture.active = (RenderTexture) null;
    byte[] png = tex.EncodeToPNG();
    string path = Path.Combine(Application.streamingAssetsPath, this.screenshotFilename++.ToString() + ".png");
    File.WriteAllBytes(path, png);
    this.captureCamera.targetTexture = (RenderTexture) null;
    Object.Destroy((Object) renderTexture);
    Debug.Log((object) ("Screenshot captured and saved as: " + path));
  }
}
