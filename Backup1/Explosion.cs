// Decompiled with JetBrains decompiler
// Type: Explosion
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Explosion : MonoBehaviour
{
  public bool shooterAISupport;
  public bool bloodyMessSupport;
  public int weaponType;
  public float explosionForce = 5f;
  public float explosionRadius = 10f;
  public bool shakeCamera = true;
  public float cameraShakeViolence = 0.5f;
  public bool causeDamage = true;
  public float damage = 10f;
  public Person ThisPerson;

  private IEnumerator Start()
  {
    Explosion explosion = this;
    yield return (object) null;
    Collider[] colliderArray = Physics.OverlapSphere(explosion.transform.position, explosion.explosionRadius);
    if (explosion.causeDamage)
    {
      foreach (Collider collider in colliderArray)
      {
        float num = explosion.damage * (1f / Vector3.Distance(explosion.transform.position, collider.transform.position));
        LimbHitbox component = collider.GetComponent<LimbHitbox>();
        if ((Object) component != (Object) null)
          component.PersonHealth.ChangeHealth(-num, component.VitalLimb, explosion.ThisPerson);
        if (explosion.shooterAISupport)
          collider.transform.SendMessageUpwards("Damage", (object) num, SendMessageOptions.DontRequireReceiver);
        if (explosion.bloodyMessSupport && collider.gameObject.layer == LayerMask.NameToLayer("Limb"))
        {
          Vector3 vector3 = collider.transform.position - explosion.transform.position;
        }
      }
    }
    List<Rigidbody> rigidbodyList = new List<Rigidbody>();
    foreach (Collider collider in colliderArray)
    {
      if ((Object) collider.attachedRigidbody != (Object) null && !rigidbodyList.Contains(collider.attachedRigidbody))
        rigidbodyList.Add(collider.attachedRigidbody);
    }
    foreach (Rigidbody rigidbody in rigidbodyList)
      rigidbody.AddExplosionForce(explosion.explosionForce, explosion.transform.position, explosion.explosionRadius, 1f, ForceMode.Impulse);
  }
}
