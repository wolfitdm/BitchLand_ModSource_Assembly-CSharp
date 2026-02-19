// Decompiled with JetBrains decompiler
// Type: bl_ScreenshotScene
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
    RenderTexture renderTexture = new RenderTexture(width, height, 32);
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
