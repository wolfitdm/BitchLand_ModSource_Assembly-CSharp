// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Effects.ExtinguishableParticleSystem
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
