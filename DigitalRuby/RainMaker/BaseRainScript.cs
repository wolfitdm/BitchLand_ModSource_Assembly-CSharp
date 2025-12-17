// Decompiled with JetBrains decompiler
// Type: DigitalRuby.RainMaker.BaseRainScript
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.Audio;

#nullable disable
namespace DigitalRuby.RainMaker;

public class BaseRainScript : MonoBehaviour
{
  [Tooltip("Camera the rain should hover over, defaults to main camera")]
  public Camera Camera;
  [Tooltip("Whether rain should follow the camera. If false, rain must be moved manually and will not follow the camera.")]
  public bool FollowCamera = true;
  [Tooltip("Light rain looping clip")]
  public AudioClip RainSoundLight;
  [Tooltip("Medium rain looping clip")]
  public AudioClip RainSoundMedium;
  [Tooltip("Heavy rain looping clip")]
  public AudioClip RainSoundHeavy;
  [Tooltip("AudoMixer used for the rain sound")]
  public AudioMixerGroup RainSoundAudioMixer;
  [Tooltip("Intensity of rain (0-1)")]
  [Range(0.0f, 1f)]
  public float RainIntensity;
  [Tooltip("Rain particle system")]
  public ParticleSystem RainFallParticleSystem;
  [Tooltip("Particles system for when rain hits something")]
  public ParticleSystem RainExplosionParticleSystem;
  [Tooltip("Particle system to use for rain mist")]
  public ParticleSystem RainMistParticleSystem;
  [Tooltip("The threshold for intensity (0 - 1) at which mist starts to appear")]
  [Range(0.0f, 1f)]
  public float RainMistThreshold = 0.5f;
  [Tooltip("Wind looping clip")]
  public AudioClip WindSound;
  [Tooltip("Wind sound volume modifier, use this to lower your sound if it's too loud.")]
  public float WindSoundVolumeModifier = 0.5f;
  [Tooltip("Wind zone that will affect and follow the rain")]
  public WindZone WindZone;
  [Tooltip("X = minimum wind speed. Y = maximum wind speed. Z = sound multiplier. Wind speed is divided by Z to get sound multiplier value. Set Z to lower than Y to increase wind sound volume, or higher to decrease wind sound volume.")]
  public Vector3 WindSpeedRange = new Vector3(50f, 500f, 500f);
  [Tooltip("How often the wind speed and direction changes (minimum and maximum change interval in seconds)")]
  public Vector2 WindChangeInterval = new Vector2(5f, 30f);
  [Tooltip("Whether wind should be enabled.")]
  public bool EnableWind = true;
  protected LoopingAudioSource audioSourceRainLight;
  protected LoopingAudioSource audioSourceRainMedium;
  protected LoopingAudioSource audioSourceRainHeavy;
  protected LoopingAudioSource audioSourceRainCurrent;
  protected LoopingAudioSource audioSourceWind;
  protected Material rainMaterial;
  protected Material rainExplosionMaterial;
  protected Material rainMistMaterial;
  private float lastRainIntensityValue = -1f;
  private float nextWindTime;

  private void UpdateWind()
  {
    if (this.EnableWind && (Object) this.WindZone != (Object) null && (double) this.WindSpeedRange.y > 1.0)
    {
      this.WindZone.gameObject.SetActive(true);
      if (this.FollowCamera)
        this.WindZone.transform.position = this.Camera.transform.position;
      if (!this.Camera.orthographic)
        this.WindZone.transform.Translate(0.0f, this.WindZone.radius, 0.0f);
      if ((double) this.nextWindTime < (double) Time.time)
      {
        this.WindZone.windMain = Random.Range(this.WindSpeedRange.x, this.WindSpeedRange.y);
        this.WindZone.windTurbulence = Random.Range(this.WindSpeedRange.x, this.WindSpeedRange.y);
        if (this.Camera.orthographic)
          this.WindZone.transform.rotation = Quaternion.Euler(0.0f, Random.Range(0, 2) == 0 ? 90f : -90f, 0.0f);
        else
          this.WindZone.transform.rotation = Quaternion.Euler(Random.Range(-30f, 30f), Random.Range(0.0f, 360f), 0.0f);
        this.nextWindTime = Time.time + Random.Range(this.WindChangeInterval.x, this.WindChangeInterval.y);
        this.audioSourceWind.Play(this.WindZone.windMain / this.WindSpeedRange.z * this.WindSoundVolumeModifier);
      }
    }
    else
    {
      if ((Object) this.WindZone != (Object) null)
        this.WindZone.gameObject.SetActive(false);
      this.audioSourceWind.Stop();
    }
    this.audioSourceWind.Update();
  }

  private void CheckForRainChange()
  {
    if ((double) this.lastRainIntensityValue == (double) this.RainIntensity)
      return;
    this.lastRainIntensityValue = this.RainIntensity;
    if ((double) this.RainIntensity <= 0.0099999997764825821)
    {
      if (this.audioSourceRainCurrent != null)
      {
        this.audioSourceRainCurrent.Stop();
        this.audioSourceRainCurrent = (LoopingAudioSource) null;
      }
      if ((Object) this.RainFallParticleSystem != (Object) null)
      {
        this.RainFallParticleSystem.emission.enabled = false;
        this.RainFallParticleSystem.Stop();
      }
      if (!((Object) this.RainMistParticleSystem != (Object) null))
        return;
      this.RainMistParticleSystem.emission.enabled = false;
      this.RainMistParticleSystem.Stop();
    }
    else
    {
      LoopingAudioSource loopingAudioSource = (double) this.RainIntensity < 0.67000001668930054 ? ((double) this.RainIntensity < 0.33000001311302185 ? this.audioSourceRainLight : this.audioSourceRainMedium) : this.audioSourceRainHeavy;
      if (this.audioSourceRainCurrent != loopingAudioSource)
      {
        if (this.audioSourceRainCurrent != null)
          this.audioSourceRainCurrent.Stop();
        this.audioSourceRainCurrent = loopingAudioSource;
        this.audioSourceRainCurrent.Play(1f);
      }
      if ((Object) this.RainFallParticleSystem != (Object) null)
      {
        ParticleSystem.EmissionModule emission = this.RainFallParticleSystem.emission with
        {
          enabled = this.RainFallParticleSystem.GetComponent<Renderer>().enabled = true
        };
        if (!this.RainFallParticleSystem.isPlaying)
          this.RainFallParticleSystem.Play();
        ParticleSystem.MinMaxCurve rateOverTime = emission.rateOverTime with
        {
          mode = ParticleSystemCurveMode.Constant
        };
        rateOverTime.constantMin = rateOverTime.constantMax = this.RainFallEmissionRate();
        emission.rateOverTime = rateOverTime;
      }
      if (!((Object) this.RainMistParticleSystem != (Object) null))
        return;
      ParticleSystem.EmissionModule emission1 = this.RainMistParticleSystem.emission with
      {
        enabled = this.RainMistParticleSystem.GetComponent<Renderer>().enabled = true
      };
      if (!this.RainMistParticleSystem.isPlaying)
        this.RainMistParticleSystem.Play();
      float num = (double) this.RainIntensity >= (double) this.RainMistThreshold ? this.MistEmissionRate() : 0.0f;
      ParticleSystem.MinMaxCurve rateOverTime1 = emission1.rateOverTime with
      {
        mode = ParticleSystemCurveMode.Constant
      };
      rateOverTime1.constantMin = rateOverTime1.constantMax = num;
      emission1.rateOverTime = rateOverTime1;
    }
  }

  protected virtual void Start()
  {
    if ((Object) this.Camera == (Object) null)
      this.Camera = Camera.main;
    this.audioSourceRainLight = new LoopingAudioSource((MonoBehaviour) this, this.RainSoundLight, this.RainSoundAudioMixer);
    this.audioSourceRainMedium = new LoopingAudioSource((MonoBehaviour) this, this.RainSoundMedium, this.RainSoundAudioMixer);
    this.audioSourceRainHeavy = new LoopingAudioSource((MonoBehaviour) this, this.RainSoundHeavy, this.RainSoundAudioMixer);
    this.audioSourceWind = new LoopingAudioSource((MonoBehaviour) this, this.WindSound, this.RainSoundAudioMixer);
    if ((Object) this.RainFallParticleSystem != (Object) null)
    {
      this.RainFallParticleSystem.emission.enabled = false;
      Renderer component = this.RainFallParticleSystem.GetComponent<Renderer>();
      component.enabled = false;
      this.rainMaterial = new Material(component.material);
      this.rainMaterial.EnableKeyword("SOFTPARTICLES_OFF");
      component.material = this.rainMaterial;
    }
    if ((Object) this.RainExplosionParticleSystem != (Object) null)
    {
      this.RainExplosionParticleSystem.emission.enabled = false;
      Renderer component = this.RainExplosionParticleSystem.GetComponent<Renderer>();
      this.rainExplosionMaterial = new Material(component.material);
      this.rainExplosionMaterial.EnableKeyword("SOFTPARTICLES_OFF");
      component.material = this.rainExplosionMaterial;
    }
    if (!((Object) this.RainMistParticleSystem != (Object) null))
      return;
    this.RainMistParticleSystem.emission.enabled = false;
    Renderer component1 = this.RainMistParticleSystem.GetComponent<Renderer>();
    component1.enabled = false;
    this.rainMistMaterial = new Material(component1.material);
    if (this.UseRainMistSoftParticles)
      this.rainMistMaterial.EnableKeyword("SOFTPARTICLES_ON");
    else
      this.rainMistMaterial.EnableKeyword("SOFTPARTICLES_OFF");
    component1.material = this.rainMistMaterial;
  }

  protected virtual void Update()
  {
    this.CheckForRainChange();
    this.UpdateWind();
    this.audioSourceRainLight.Update();
    this.audioSourceRainMedium.Update();
    this.audioSourceRainHeavy.Update();
  }

  protected virtual float RainFallEmissionRate()
  {
    ParticleSystem.MainModule main = this.RainFallParticleSystem.main;
    double maxParticles = (double) main.maxParticles;
    main = this.RainFallParticleSystem.main;
    double constant = (double) main.startLifetime.constant;
    return (float) (maxParticles / constant) * this.RainIntensity;
  }

  protected virtual float MistEmissionRate()
  {
    ParticleSystem.MainModule main = this.RainMistParticleSystem.main;
    double maxParticles = (double) main.maxParticles;
    main = this.RainMistParticleSystem.main;
    double constant = (double) main.startLifetime.constant;
    return (float) (maxParticles / constant) * this.RainIntensity * this.RainIntensity;
  }

  protected virtual bool UseRainMistSoftParticles => true;
}
