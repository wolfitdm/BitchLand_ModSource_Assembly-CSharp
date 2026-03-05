// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Effects.ParticleSystemMultiplier
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
