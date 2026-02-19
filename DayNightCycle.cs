// Decompiled with JetBrains decompiler
// Type: DayNightCycle
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

#nullable disable
public class DayNightCycle : MonoBehaviour
{
  public Light sunLight;
  public Light sunLight2;
  public Light sunLight3;
  public float cycleDuration = 1200f;
  public float timeOfDay;
  public Color dayColor = new Color(1f, 0.980392158f, 0.921568632f);
  public Color nightColor = new Color(0.0f, 0.0f, 0.0f);
  public Color dayColor2;
  public Color nightColor2;
  public Color dayColor3;
  public Color nightColor3;
  public Color DayAmbientLight;
  public Color NightAmbientLight;
  public Material NormalSky;
  public Material RainySky;
  public bool DayTimeObjectsEnabled;
  public List<GameObject> DayTimeObjects = new List<GameObject>();
  public bool NightTimeObjectsEnabled;
  public List<GameObject> NightTimeObjects = new List<GameObject>();
  public Material NeonMat;
  public PostProcessVolume postProcessVolume;
  public bool ShownSleepNotif;

  public bool isNight => (double) this.timeOfDay > 0.25 && (double) this.timeOfDay < 0.75;

  public bool isDay => !this.isNight;

  public void Start()
  {
    this.ResetMidday();
    this.enabled = false;
  }

  public void Update()
  {
    this.timeOfDay += Time.deltaTime / this.cycleDuration;
    this.timeOfDay %= 1f;
    this.transform.eulerAngles = new Vector3(360f * this.timeOfDay, 0.0f, 0.0f);
    float lightIntensity = this.GetLightIntensity();
    this.sunLight.color = Color.Lerp(this.nightColor, this.dayColor, lightIntensity);
    this.sunLight2.color = Color.Lerp(this.nightColor2, this.dayColor2, lightIntensity);
    this.sunLight3.color = Color.Lerp(this.nightColor3, this.dayColor3, lightIntensity);
    RenderSettings.ambientLight = Color.Lerp(this.NightAmbientLight, this.DayAmbientLight, lightIntensity);
    this.NormalSky.SetFloat("_Blend", 1f - lightIntensity);
    if ((double) this.timeOfDay > 0.75 && !this.DayTimeObjectsEnabled)
    {
      this.NightTimeObjectsEnabled = false;
      this.DayTimeObjectsEnabled = true;
      for (int index = 0; index < this.NightTimeObjects.Count; ++index)
        this.NightTimeObjects[index].SetActive(false);
      for (int index = 0; index < this.DayTimeObjects.Count; ++index)
        this.DayTimeObjects[index].SetActive(true);
      this.postProcessVolume.weight = 0.0f;
      this.NeonMat.DisableKeyword("_EMISSION");
      this.ShownSleepNotif = false;
    }
    else
    {
      if ((double) this.timeOfDay <= 0.20999999344348907 || (double) this.timeOfDay >= 0.75 || this.NightTimeObjectsEnabled)
        return;
      this.NightTimeObjectsEnabled = true;
      this.DayTimeObjectsEnabled = false;
      for (int index = 0; index < this.DayTimeObjects.Count; ++index)
        this.DayTimeObjects[index].SetActive(false);
      for (int index = 0; index < this.NightTimeObjects.Count; ++index)
        this.NightTimeObjects[index].SetActive(true);
      this.postProcessVolume.weight = 0.25f;
      this.NeonMat.EnableKeyword("_EMISSION");
      if (this.ShownSleepNotif)
        return;
      this.ShownSleepNotif = true;
      Main.Instance.GameplayMenu.ShowNotification("It's getting dark. Better find a place to sleep");
    }
  }

  private float Transition(float f)
  {
    if ((double) f <= 0.25 || (double) f >= 0.75)
      return 0.0f;
    if ((double) f >= 0.25999999046325684 && (double) f <= 0.74000000953674316)
      return 1f;
    return (double) f < 0.5 ? Mathf.SmoothStep(0.0f, 1f, Mathf.InverseLerp(0.25f, 0.26f, f)) : Mathf.SmoothStep(0.0f, 1f, Mathf.InverseLerp(0.74f, 0.75f, f));
  }

  public float GetLightIntensity()
  {
    return Mathf.Pow(Mathf.Abs((float) (2.0 * (double) this.timeOfDay - 1.0)), 2f);
  }

  public void ResetMidday()
  {
    this.timeOfDay = 0.0f;
    this.Update();
  }

  public void ResetMidnight()
  {
    this.timeOfDay = 0.6f;
    this.Update();
  }
}
