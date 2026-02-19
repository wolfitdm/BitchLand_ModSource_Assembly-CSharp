// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Effects.ParticleSystemMultiplier
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace UnityStandardAssets.Effects
{
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
}
