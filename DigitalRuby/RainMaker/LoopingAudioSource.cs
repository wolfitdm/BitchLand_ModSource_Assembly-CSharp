// Decompiled with JetBrains decompiler
// Type: DigitalRuby.RainMaker.LoopingAudioSource
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.Audio;

#nullable disable
namespace DigitalRuby.RainMaker
{
  public class LoopingAudioSource
  {
    public AudioSource AudioSource { get; private set; }

    public float TargetVolume { get; private set; }

    public LoopingAudioSource(MonoBehaviour script, AudioClip clip, AudioMixerGroup mixer)
    {
      this.AudioSource = script.gameObject.AddComponent<AudioSource>();
      if ((Object) mixer != (Object) null)
        this.AudioSource.outputAudioMixerGroup = mixer;
      this.AudioSource.loop = true;
      this.AudioSource.clip = clip;
      this.AudioSource.playOnAwake = false;
      this.AudioSource.volume = 0.0f;
      this.AudioSource.Stop();
      this.TargetVolume = 1f;
    }

    public void Play(float targetVolume)
    {
      if (!this.AudioSource.isPlaying)
      {
        this.AudioSource.volume = 0.0f;
        this.AudioSource.Play();
      }
      this.TargetVolume = targetVolume;
    }

    public void Stop() => this.TargetVolume = 0.0f;

    public void Update()
    {
      if (!this.AudioSource.isPlaying || (double) (this.AudioSource.volume = Mathf.Lerp(this.AudioSource.volume, this.TargetVolume, Time.deltaTime)) != 0.0)
        return;
      this.AudioSource.Stop();
    }
  }
}
