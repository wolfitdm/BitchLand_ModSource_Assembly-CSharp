// Decompiled with JetBrains decompiler
// Type: alphascreenshot
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class alphascreenshot : MonoBehaviour
{
  public bool UseSimple;
  public string Thefilename;

  private void Start()
  {
    Camera main = Camera.main;
    string screengrabfile_path = Application.streamingAssetsPath + "/" + this.Thefilename + ".png";
    int width = Screen.width;
    int height = Screen.height;
    if (this.UseSimple)
      CaptureScreenshot.SimpleCaptureTransparentScreenshot(main, width, height, screengrabfile_path);
    else
      CaptureScreenshot.CaptureTransparentScreenshot(main, width, height, screengrabfile_path);
  }
}
