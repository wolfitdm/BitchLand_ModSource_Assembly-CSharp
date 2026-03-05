// Decompiled with JetBrains decompiler
// Type: CFX_LightIntensityFade
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[RequireComponent(typeof (Light))]
public class CFX_LightIntensityFade : MonoBehaviour
{
  public float duration = 1f;
  public float delay;
  public float finalIntensity;
  private float baseIntensity;
  public bool autodestruct;
  private float p_lifetime;
  private float p_delay;

  private void Start() => this.baseIntensity = this.GetComponent<Light>().intensity;

  private void OnEnable()
  {
    this.p_lifetime = 0.0f;
    this.p_delay = this.delay;
    if ((double) this.delay <= 0.0)
      return;
    this.GetComponent<Light>().enabled = false;
  }

  private void Update()
  {
    if ((double) this.p_delay > 0.0)
    {
      this.p_delay -= Time.deltaTime;
      if ((double) this.p_delay > 0.0)
        return;
      this.GetComponent<Light>().enabled = true;
    }
    else if ((double) this.p_lifetime / (double) this.duration < 1.0)
    {
      this.GetComponent<Light>().intensity = Mathf.Lerp(this.baseIntensity, this.finalIntensity, this.p_lifetime / this.duration);
      this.p_lifetime += Time.deltaTime;
    }
    else
    {
      if (!this.autodestruct)
        return;
      Object.Destroy((Object) this.gameObject);
    }
  }
}
