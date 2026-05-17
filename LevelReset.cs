// Decompiled with JetBrains decompiler
// Type: LevelReset
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

#nullable disable
public class LevelReset : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
  public void OnPointerClick(PointerEventData data)
  {
    SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
  }
}
