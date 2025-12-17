// Decompiled with JetBrains decompiler
// Type: bl_sceneticsound
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class bl_sceneticsound : MonoBehaviour
{
  public AudioClip[] Clips;
  public int _CurrentClip;
  public AudioSource Sound;
  public AudioSource ExteriorSound;
  public bool Positive;
  public float Volume = 1f;
  public bool DelayedStart;

  public void Start()
  {
    if ((UnityEngine.Object) this.Sound == (UnityEngine.Object) null || this.Clips == null || this.Clips.Length == 0)
      return;
    if (this.DelayedStart)
    {
      Main.RunInSeconds((Action) (() =>
      {
        this._CurrentClip = -1;
        this.SelectRandomMusic();
        if (!((UnityEngine.Object) this.ExteriorSound != (UnityEngine.Object) null))
          return;
        this.ExteriorSound.Play();
      }), 1f);
    }
    else
    {
      this._CurrentClip = -1;
      this.SelectRandomMusic();
      if (!((UnityEngine.Object) this.ExteriorSound != (UnityEngine.Object) null))
        return;
      this.ExteriorSound.Play();
    }
  }

  public void SelectRandomMusic()
  {
    int index = UnityEngine.Random.Range(0, this.Clips.Length);
    if (this.Clips.Length != 1 && index == this._CurrentClip)
      return;
    this._CurrentClip = index;
    this.Sound.time = 0.0f;
    this.Sound.clip = this.Clips[index];
    if (!((UnityEngine.Object) this.ExteriorSound != (UnityEngine.Object) null))
      return;
    this.ExteriorSound.time = 0.0f;
    this.ExteriorSound.clip = this.Clips[index];
  }

  public void FixedUpdate()
  {
    if ((UnityEngine.Object) this.Sound == (UnityEngine.Object) null || this.Clips == null || this.Clips.Length == 0 || this.Sound.isPlaying || !((UnityEngine.Object) this.ExteriorSound != (UnityEngine.Object) null) || this.ExteriorSound.isPlaying)
      return;
    this.SelectRandomMusic();
    if (this.Sound.enabled)
      this.Sound.Play();
    if (!((UnityEngine.Object) this.ExteriorSound != (UnityEngine.Object) null) || !this.ExteriorSound.enabled)
      return;
    this.ExteriorSound.Play();
  }

  public void OnTriggerEnter(Collider other)
  {
    if (!(other.tag == "Player"))
      return;
    this.Positive = true;
    this.enabled = true;
    this.Sound.enabled = true;
    this.Sound.time = !((UnityEngine.Object) this.ExteriorSound == (UnityEngine.Object) null) ? this.ExteriorSound.time : UnityEngine.Random.Range(0.0f, this.Sound.clip.length);
    this.Sound.Play();
  }

  public void OnTriggerExit(Collider other)
  {
    if (!(other.tag == "Player"))
      return;
    this.Positive = false;
    if (!((UnityEngine.Object) this.ExteriorSound != (UnityEngine.Object) null))
      return;
    this.ExteriorSound.enabled = true;
    this.ExteriorSound.time = this.Sound.time;
    this.ExteriorSound.Play();
  }

  public void Update()
  {
    if (this.Positive)
    {
      this.Sound.volume += Time.deltaTime;
      if ((double) this.Sound.volume >= (double) this.Volume)
        this.Sound.volume = this.Volume;
      if (!((UnityEngine.Object) this.ExteriorSound != (UnityEngine.Object) null))
        return;
      this.ExteriorSound.volume -= Time.deltaTime;
      if ((double) this.ExteriorSound.volume > 0.0)
        return;
      this.ExteriorSound.volume = 0.0f;
      this.ExteriorSound.enabled = false;
    }
    else
    {
      this.Sound.volume -= Time.deltaTime;
      if ((double) this.Sound.volume <= 0.0)
      {
        this.Sound.volume = 0.0f;
        this.Sound.enabled = false;
      }
      if (!((UnityEngine.Object) this.ExteriorSound != (UnityEngine.Object) null))
        return;
      this.ExteriorSound.volume += Time.deltaTime;
      if ((double) this.ExteriorSound.volume < (double) this.Volume)
        return;
      this.ExteriorSound.volume = this.Volume;
    }
  }
}
