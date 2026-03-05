// Decompiled with JetBrains decompiler
// Type: PauseMenu
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class PauseMenu : MonoBehaviour
{
  private Toggle m_MenuToggle;
  private float m_TimeScaleRef = 1f;
  private float m_VolumeRef = 1f;
  private bool m_Paused;

  private void Awake() => this.m_MenuToggle = this.GetComponent<Toggle>();

  private void MenuOn()
  {
    this.m_TimeScaleRef = Time.timeScale;
    Time.timeScale = 0.0f;
    this.m_VolumeRef = AudioListener.volume;
    AudioListener.volume = 0.0f;
    this.m_Paused = true;
  }

  public void MenuOff()
  {
    Time.timeScale = this.m_TimeScaleRef;
    AudioListener.volume = this.m_VolumeRef;
    this.m_Paused = false;
  }

  public void OnMenuStatusChange()
  {
    if (this.m_MenuToggle.isOn && !this.m_Paused)
    {
      this.MenuOn();
    }
    else
    {
      if (this.m_MenuToggle.isOn || !this.m_Paused)
        return;
      this.MenuOff();
    }
  }

  private void Update()
  {
    if (!Input.GetKeyUp(KeyCode.Escape))
      return;
    this.m_MenuToggle.isOn = !this.m_MenuToggle.isOn;
    Cursor.visible = this.m_MenuToggle.isOn;
  }
}
