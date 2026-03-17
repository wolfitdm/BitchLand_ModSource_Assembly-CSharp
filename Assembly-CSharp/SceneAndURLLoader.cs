// Decompiled with JetBrains decompiler
// Type: SceneAndURLLoader
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
