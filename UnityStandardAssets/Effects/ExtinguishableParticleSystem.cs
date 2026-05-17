// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Effects.ExtinguishableParticleSystem
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace UnityStandardAssets.Effects
{
  public class ExtinguishableParticleSystem : MonoBehaviour
  {
    public float multiplier = 1f;
    private ParticleSystem[] m_Systems;

    private void Start() => this.m_Systems = this.GetComponentsInChildren<ParticleSystem>();

    public void Extinguish()
    {
      foreach (ParticleSystem system in this.m_Systems)
        system.emission.enabled = false;
    }
  }
}
