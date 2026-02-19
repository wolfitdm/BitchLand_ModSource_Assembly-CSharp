// Decompiled with JetBrains decompiler
// Type: CFX_AutoStopLoopedEffect
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[RequireComponent(typeof (ParticleSystem))]
public class CFX_AutoStopLoopedEffect : MonoBehaviour
{
  public float effectDuration = 2.5f;
  private float d;

  private void OnEnable() => this.d = this.effectDuration;

  private void Update()
  {
    if ((double) this.d <= 0.0)
      return;
    this.d -= Time.deltaTime;
    if ((double) this.d > 0.0)
      return;
    this.GetComponent<ParticleSystem>().Stop(true);
    CFX_Demo_Translate component = this.gameObject.GetComponent<CFX_Demo_Translate>();
    if (!((Object) component != (Object) null))
      return;
    component.enabled = false;
  }
}
