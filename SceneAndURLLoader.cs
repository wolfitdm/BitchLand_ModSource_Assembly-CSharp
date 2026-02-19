// Decompiled with JetBrains decompiler
// Type: SceneAndURLLoader
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

#nullable disable
public class SceneAndURLLoader : MonoBehaviour
{
  private PauseMenu m_PauseMenu;

  private void Awake() => this.m_PauseMenu = this.GetComponentInChildren<PauseMenu>();

  public void SceneLoad(string sceneName)
  {
    this.m_PauseMenu.MenuOff();
    SceneManager.LoadScene(sceneName);
  }

  public void LoadURL(string url) => Application.OpenURL(url);
}
