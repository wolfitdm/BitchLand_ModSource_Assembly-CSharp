// Decompiled with JetBrains decompiler
// Type: ChobiAssets.KTP.Fire_Spawn_CS
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
namespace ChobiAssets.KTP
{
  public class Fire_Spawn_CS : MonoBehaviour
  {
    [Header("Firing settings")]
    [Tooltip("Prefab of muzzle fire.")]
    public GameObject firePrefab;
    [Tooltip("Prefab of bullet.")]
    public GameObject bulletPrefab;
    [Tooltip("Attack force of the bullet.")]
    public float attackForce = 100f;
    [Tooltip("Speed of the bullet. (Meter per Second)")]
    public float bulletVelocity = 250f;
    [Tooltip("Offset distance for spawning the bullet. (Meter)")]
    public float spawnOffset = 1f;
    private Transform thisTransform;

    private void Awake() => this.thisTransform = this.transform;

    public IEnumerator Fire()
    {
      if ((bool) (Object) this.firePrefab)
        Object.Instantiate<GameObject>(this.firePrefab, this.thisTransform.position, this.thisTransform.rotation).transform.parent = this.thisTransform;
      if ((bool) (Object) this.bulletPrefab)
      {
        GameObject bulletObject = Object.Instantiate<GameObject>(this.bulletPrefab, this.thisTransform.position + this.thisTransform.forward * this.spawnOffset, this.thisTransform.rotation);
        bulletObject.GetComponent<Bullet_Nav_CS>().attackForce = this.attackForce;
        Vector3 tempVelocity = this.thisTransform.forward * this.bulletVelocity;
        yield return (object) new WaitForFixedUpdate();
        bulletObject.GetComponent<Rigidbody>().velocity = tempVelocity;
        bulletObject = (GameObject) null;
        tempVelocity = new Vector3();
      }
    }
  }
}
