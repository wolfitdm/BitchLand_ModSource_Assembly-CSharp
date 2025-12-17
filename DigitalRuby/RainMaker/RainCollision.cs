// Decompiled with JetBrains decompiler
// Type: DigitalRuby.RainMaker.RainCollision
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace DigitalRuby.RainMaker;

public class RainCollision : MonoBehaviour
{
  private static readonly Color32 color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
  private readonly List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();
  public ParticleSystem RainExplosion;
  public ParticleSystem RainParticleSystem;

  private void Start()
  {
  }

  private void Update()
  {
  }

  private void Emit(ParticleSystem p, ref Vector3 pos)
  {
    for (int index = Random.Range(2, 5); index != 0; --index)
    {
      float y = Random.Range(1f, 3f);
      float z = Random.Range(-2f, 2f);
      float x = Random.Range(-2f, 2f);
      float num = Random.Range(0.05f, 0.1f);
      p.Emit(new ParticleSystem.EmitParams()
      {
        position = pos,
        velocity = new Vector3(x, y, z),
        startLifetime = 0.75f,
        startSize = num,
        startColor = RainCollision.color
      }, 1);
    }
  }

  private void OnParticleCollision(GameObject obj)
  {
    if (!((Object) this.RainExplosion != (Object) null) || !((Object) this.RainParticleSystem != (Object) null))
      return;
    int collisionEvents = this.RainParticleSystem.GetCollisionEvents(obj, this.collisionEvents);
    for (int index = 0; index < collisionEvents; ++index)
    {
      Vector3 intersection = this.collisionEvents[index].intersection;
      this.Emit(this.RainExplosion, ref intersection);
    }
  }
}
