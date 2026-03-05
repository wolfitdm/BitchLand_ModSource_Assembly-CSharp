// Decompiled with JetBrains decompiler
// Type: BL_MapArea
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class BL_MapArea : MonoBehaviour
{
  public float MusicPitch = 1f;
  public AudioClip[] LocalMusics;
  public AudioClip[] CombatLocalMusics;
  public GameObject[] EnabledWhileInside;
  public GameObject[] DisabledWhileInside;
  public Light[] LightsEnabledWhileInside;
  public Color AmbientLight;
  public bool DisableSkybox;

  public virtual void OnEnter()
  {
    if ((Object) Main.Instance.CurrentArea != (Object) null)
    {
      if ((Object) Main.Instance.CurrentArea == (Object) this)
        return;
      Main.Instance.CurrentArea.OnLeave();
    }
    RenderSettings.ambientLight = this.AmbientLight;
    Main.Instance.CurrentArea = this;
    Main.Instance.MusicPlayer.Stop();
    Main.Instance.MusicPlayer.clip = (AudioClip) null;
    for (int index = 0; index < this.DisabledWhileInside.Length; ++index)
      this.DisabledWhileInside[index].SetActive(false);
    for (int index = 0; index < this.EnabledWhileInside.Length; ++index)
      this.EnabledWhileInside[index].SetActive(true);
    for (int index = 0; index < this.LightsEnabledWhileInside.Length; ++index)
      this.LightsEnabledWhileInside[index].enabled = true;
    if (this.DisableSkybox)
      Main.Instance.PlayerCam.clearFlags = CameraClearFlags.Color;
    else
      Main.Instance.PlayerCam.clearFlags = CameraClearFlags.Skybox;
  }

  public virtual void OnLeave()
  {
    Main.Instance.MusicPlayer.Stop();
    Main.Instance.MusicPlayer.clip = (AudioClip) null;
    Main.Instance.Lights.SetActive(true);
    for (int index = 0; index < this.EnabledWhileInside.Length; ++index)
      this.EnabledWhileInside[index].SetActive(false);
    for (int index = 0; index < this.DisabledWhileInside.Length; ++index)
      this.DisabledWhileInside[index].SetActive(true);
    for (int index = 0; index < this.LightsEnabledWhileInside.Length; ++index)
      this.LightsEnabledWhileInside[index].enabled = false;
    Main.Instance.CurrentArea = (BL_MapArea) null;
  }
}
