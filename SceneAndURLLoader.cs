// Decompiled with JetBrains decompiler
// Type: SceneAndURLLoader
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
