// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Effects.ExtinguishableParticleSystem
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
