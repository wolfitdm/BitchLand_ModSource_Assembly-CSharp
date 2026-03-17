// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Effects.ParticleSystemMultiplier
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
