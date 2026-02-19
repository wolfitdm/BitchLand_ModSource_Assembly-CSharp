// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Effects.Hose
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace UnityStandardAssets.Effects;

public class Hose : MonoBehaviour
{
  public float maxPower = 20f;
  public float minPower = 5f;
  public float changeSpeed = 5f;
  public ParticleSystem[] hoseWaterSystems;
  public Renderer systemRenderer;
  private float m_Power;

  private void Update()
  {
    this.m_Power = Mathf.Lerp(this.m_Power, Input.GetMouseButton(0) ? this.maxPower : this.minPower, Time.deltaTime * this.changeSpeed);
    if (Input.GetKeyDown(KeyCode.Alpha1))
      this.systemRenderer.enabled = !this.systemRenderer.enabled;
    foreach (ParticleSystem hoseWaterSystem in this.hoseWaterSystems)
    {
      hoseWaterSystem.main.startSpeed = (ParticleSystem.MinMaxCurve) this.m_Power;
      hoseWaterSystem.emission.enabled = (double) this.m_Power > (double) this.minPower * 1.1000000238418579;
    }
  }
}
