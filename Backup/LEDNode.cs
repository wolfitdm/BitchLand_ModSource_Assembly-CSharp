// Decompiled with JetBrains decompiler
// Type: LEDNode
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class LEDNode : MonoBehaviour
{
  public LEDNode prevNode;
  public bool isFirstNode;
  public bool isPointLightEn;
  public bool slowProgress;
  private Light pointLight;
  private Renderer rend;
  private float intensity;
  private float minIntensity;
  private float maxIntensity = 1f;
  private float onTime;
  private float maxOnTime = 1f;
  private float onTimerSpeed = 2f;
  private float offTime;
  private float maxOffTime = 20f;
  private float offTimerSpeed = 20f;
  private LEDNode.LightState lightState = LEDNode.LightState.IDLE;

  public bool nextStart { get; private set; }

  private void Start()
  {
    this.pointLight = this.GetComponent<Light>();
    this.rend = this.GetComponent<Renderer>();
  }

  private void Update()
  {
    this.ResolveNodeState();
    this.UpdateColor();
  }

  private void ResolveNodeState()
  {
    switch (this.lightState)
    {
      case LEDNode.LightState.INCR:
        this.IntensityIncrease();
        break;
      case LEDNode.LightState.DECR:
        this.IntensityDecrease();
        break;
      case LEDNode.LightState.IDLE:
        this.LightIdle();
        break;
    }
  }

  private void IntensityIncrease()
  {
    if (!this.slowProgress && !this.nextStart)
      this.nextStart = true;
    this.intensity = this.maxIntensity;
    if (this.isPointLightEn)
      this.pointLight.enabled = true;
    if ((double) this.onTime < (double) this.maxOnTime)
    {
      this.onTime += this.onTimerSpeed * Time.deltaTime;
    }
    else
    {
      this.onTime = 0.0f;
      this.lightState = LEDNode.LightState.DECR;
    }
  }

  private void IntensityDecrease()
  {
    this.intensity = this.minIntensity;
    if (this.isPointLightEn)
      this.pointLight.enabled = false;
    if (this.slowProgress)
    {
      if (!this.nextStart)
        this.nextStart = true;
    }
    else if (this.nextStart)
      this.nextStart = false;
    this.lightState = LEDNode.LightState.IDLE;
  }

  private void LightIdle()
  {
    if (this.slowProgress && this.nextStart)
      this.nextStart = false;
    if ((Object) this.prevNode != (Object) null)
    {
      if (!this.prevNode.nextStart)
        return;
      this.lightState = LEDNode.LightState.INCR;
    }
    else
    {
      if (!this.isFirstNode)
        return;
      if ((double) this.offTime < (double) this.maxOffTime)
      {
        this.offTime += this.offTimerSpeed * Time.deltaTime;
      }
      else
      {
        this.offTime = 0.0f;
        this.lightState = LEDNode.LightState.INCR;
        if (this.nextStart)
          return;
        this.nextStart = true;
      }
    }
  }

  private void UpdateColor()
  {
    Material material = this.rend.material;
    material.SetColor("_EmissionColor", material.color * Mathf.LinearToGammaSpace(this.intensity));
  }

  private enum LightState
  {
    INCR,
    DECR,
    IDLE,
  }
}
