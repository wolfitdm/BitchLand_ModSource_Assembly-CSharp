// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Effects.ParticleSystemMultiplier
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace UnityStandardAssets.Effects;

public class ParticleSystemMultiplier : MonoBehaviour
{
  public float multiplier = 1f;

  private void Start()
  {
    foreach (ParticleSystem componentsInChild in this.GetComponentsInChildren<ParticleSystem>())
    {
      ParticleSystem.MainModule main = componentsInChild.main;
      main.startSizeMultiplier *= this.multiplier;
      main.startSpeedMultiplier *= this.multiplier;
      main.startLifetimeMultiplier *= Mathf.Lerp(this.multiplier, 1f, 0.5f);
      componentsInChild.Clear();
      componentsInChild.Play();
    }
  }
}
