// Decompiled with JetBrains decompiler
// Type: LoadingScene
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#nullable disable
public class LoadingScene : MonoBehaviour
{
  public Image BackgroundImage;
  public bool FramePassed;
  public GameObject Loading;
  public GameObject Asking;
  public GameObject ZipError;
  public GameObject ModsMsg;
  public string UpdateCheckLink;
  public static int SceneToLoad;
  public static bool SkipQuestion;
  public static bool FirstOpen;
  public static bool HasShownModMsg;
  public GameObject UpdateMsg;

  private void Start()
  {
    if (!LoadingScene.FirstOpen)
    {
      Debug.Log((object) "! FirstOpen");
      LoadingScene.FirstOpen = true;
      if (Screen.fullScreen)
        Screen.fullScreen = false;
      int num = Screen.currentResolution.width + Screen.currentResolution.height;
      if (num < 2000)
      {
        if (num < 1600)
          Screen.SetResolution(720, 480, false);
        else
          Screen.SetResolution(1024, 576, false);
      }
    }
    else
      Debug.Log((object) "FirstOpen");
    if (Application.dataPath.Replace('\\', '/').ToLower().Contains("/temp/"))
    {
      Debug.Log((object) "its inside the temp folder , likely ran from a zip");
      this.ZipError.SetActive(true);
    }
    string[] files = Directory.GetFiles(Main.AssetsFolder + "/LoadingBackgrounds/", "*.png");
    Texture2D texture2D = new Texture2D(0, 0);
    texture2D.LoadImage(File.ReadAllBytes(files[Random.Range(0, files.Length - 1)]));
    this.BackgroundImage.sprite = Sprite.Create(texture2D, new Rect(0.0f, 0.0f, (float) texture2D.width, (float) texture2D.height), new Vector2(0.0f, 0.0f));
    List<string> stringList = new List<string>();
    string path = Application.dataPath + "/../";
    string[] strArray = new string[6]
    {
      "MANAGER",
      "BEPINEX",
      "CONFIG",
      "WINHTTP",
      "VERSION",
      "LOAD"
    };
    stringList.AddRange((IEnumerable<string>) Directory.GetFiles(path));
    stringList.AddRange((IEnumerable<string>) Directory.GetDirectories(path));
    for (int index1 = 0; index1 < stringList.Count; ++index1)
    {
      for (int index2 = 0; index2 < strArray.Length; ++index2)
      {
        if (stringList[index1].ToUpperInvariant().Contains(strArray[index2]))
        {
          if (!LoadingScene.HasShownModMsg)
          {
            this.ModsMsg.SetActive(true);
            LoadingScene.HasShownModMsg = true;
            LoadingScene.SkipQuestion = false;
            goto label_19;
          }
          else
            goto label_19;
        }
      }
    }
label_19:
    if (LoadingScene.SkipQuestion)
    {
      this.StartGame();
    }
    else
    {
      LoadingScene.SkipQuestion = true;
      this.enabled = false;
      this.Asking.SetActive(true);
      this.Loading.SetActive(false);
      LoadingScene.SceneToLoad = 1;
    }
  }

  public void ExitGame() => Application.Quit();

  public void StartGame()
  {
    this.enabled = true;
    this.Asking.SetActive(false);
    this.Loading.SetActive(true);
  }

  public static void LoadScene(int scene)
  {
    Time.timeScale = 1f;
    LoadingScene.SceneToLoad = scene;
    SceneManager.LoadScene(0);
  }

  public void Update()
  {
    if (this.FramePassed)
    {
      this.FramePassed = false;
      SceneManager.LoadScene(LoadingScene.SceneToLoad);
    }
    else
      this.FramePassed = true;
  }

  public void UpdateCheck()
  {
  }

  public void ClicK_CloseUpdateMsg() => this.UpdateMsg.SetActive(false);

  public void Click_PatreonLink()
  {
    try
    {
      Application.OpenURL("https://patreon.com/Breakfast5");
    }
    catch
    {
    }
  }

  public void Click_SubscribestarLink()
  {
    try
    {
      Application.OpenURL("https://subscribestar.adult/breakfast5");
    }
    catch
    {
    }
  }

  public void Click_DiscordLink()
  {
    try
    {
      Application.OpenURL("https://discord.gg/QjjXAyfwEU");
    }
    catch
    {
    }
  }

  public void Click_KofiLink()
  {
    try
    {
      Application.OpenURL("https://ko-fi.com/breakfast5");
    }
    catch
    {
    }
  }
}
