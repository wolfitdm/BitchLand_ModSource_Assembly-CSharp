// Decompiled with JetBrains decompiler
// Type: bl_ElyArea
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class bl_ElyArea : MonoBehaviour
{
  public AudioClip OnEnter;
  public AudioClip OnStay;
  public float Timer;

  public void OnTriggerEnter(Collider other)
  {
    if (!((Object) this.OnEnter != (Object) null) || other.gameObject.layer != 20)
      return;
    Main.Instance.MusicPlayer.PlayOneShot(this.OnEnter);
    this.OnEnter = (AudioClip) null;
    this.enabled = true;
  }

  public void Update()
  {
    this.Timer -= Time.deltaTime;
    if ((double) this.Timer >= 0.0)
      return;
    this.enabled = false;
    Main.Instance.MusicPlayer.PlayOneShot(this.OnStay);
    this.OnStay = (AudioClip) null;
  }
}
