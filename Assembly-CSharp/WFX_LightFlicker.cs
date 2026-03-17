// Decompiled with JetBrains decompiler
// Type: WFX_LightFlicker
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
[RequireComponent(typeof (Light))]
public class WFX_LightFlicker : MonoBehaviour
{
  public float time = 0.05f;
  private float timer;

  private void Start()
  {
    this.timer = this.time;
    this.StartCoroutine("Flicker");
  }

  private IEnumerator Flicker()
  {
    WFX_LightFlicker wfxLightFlicker = this;
    while (true)
    {
      wfxLightFlicker.GetComponent<Light>().enabled = !wfxLightFlicker.GetComponent<Light>().enabled;
      do
      {
        wfxLightFlicker.timer -= Time.deltaTime;
        yield return (object) null;
      }
      while ((double) wfxLightFlicker.timer > 0.0);
      wfxLightFlicker.timer = wfxLightFlicker.time;
    }
  }
}
