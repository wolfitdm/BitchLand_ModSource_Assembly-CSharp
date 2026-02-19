// Decompiled with JetBrains decompiler
// Type: alphascreenshot
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class alphascreenshot : MonoBehaviour
{
  public bool UseSimple;
  public string Thefilename;

  private void Start()
  {
    Camera main = Camera.main;
    string screengrabfile_path = $"{Application.streamingAssetsPath}/{this.Thefilename}.png";
    int width = Screen.width;
    int height = Screen.height;
    if (this.UseSimple)
      CaptureScreenshot.SimpleCaptureTransparentScreenshot(main, width, height, screengrabfile_path);
    else
      CaptureScreenshot.CaptureTransparentScreenshot(main, width, height, screengrabfile_path);
  }
}
