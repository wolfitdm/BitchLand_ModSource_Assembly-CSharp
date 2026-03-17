// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Effects.WaterHoseParticles
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace UnityStandardAssets.Effects
{
  public class WaterHoseParticles : MonoBehaviour
  {
    public static float lastSoundTime;
    public float force = 1f;
    private List<ParticleCollisionEvent> m_CollisionEvents = new List<ParticleCollisionEvent>();
    private ParticleSystem m_ParticleSystem;

    private void Start() => this.m_ParticleSystem = this.GetComponent<ParticleSystem>();

    private void OnParticleCollision(GameObject other)
    {
      int collisionEvents = this.m_ParticleSystem.GetCollisionEvents(other, this.m_CollisionEvents);
      for (int index = 0; index < collisionEvents; ++index)
      {
        if ((double) Time.time > (double) WaterHoseParticles.lastSoundTime + 0.20000000298023224)
          WaterHoseParticles.lastSoundTime = Time.time;
        Rigidbody component = this.m_CollisionEvents[index].colliderComponent.GetComponent<Rigidbody>();
        if ((Object) component != (Object) null)
        {
          Vector3 velocity = this.m_CollisionEvents[index].velocity;
          component.AddForce(velocity * this.force, ForceMode.Impulse);
        }
        other.BroadcastMessage("Extinguish", SendMessageOptions.DontRequireReceiver);
      }
    }
  }
}
