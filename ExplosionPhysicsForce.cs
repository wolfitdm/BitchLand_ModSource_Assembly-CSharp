// Decompiled with JetBrains decompiler
// Type: ExplosionPhysicsForce
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class ExplosionPhysicsForce : MonoBehaviour
{
  public float ExplosionForce = 4f;
  public float Radius = 10f;

  private IEnumerator Start()
  {
    ExplosionPhysicsForce explosionPhysicsForce = this;
    yield return (object) null;
    float num = 10f;
    Collider[] colliderArray = Physics.OverlapSphere(explosionPhysicsForce.transform.position, num);
    List<Rigidbody> rigidbodyList = new List<Rigidbody>();
    foreach (Collider collider in colliderArray)
    {
      if ((Object) collider.attachedRigidbody != (Object) null && !rigidbodyList.Contains(collider.attachedRigidbody))
        rigidbodyList.Add(collider.attachedRigidbody);
    }
    foreach (Rigidbody rigidbody in rigidbodyList)
      rigidbody.AddExplosionForce(explosionPhysicsForce.ExplosionForce, explosionPhysicsForce.transform.position, num, 10f, ForceMode.Impulse);
  }
}
