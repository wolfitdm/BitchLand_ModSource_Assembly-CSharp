// Decompiled with JetBrains decompiler
// Type: alphascreenshot
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
