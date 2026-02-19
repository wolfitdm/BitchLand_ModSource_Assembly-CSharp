// Decompiled with JetBrains decompiler
// Type: ChobiAssets.KTP.Bullet_Nav_CS
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace ChobiAssets.KTP
{
  public class Bullet_Nav_CS : MonoBehaviour
  {
    [Header("Bullet settings")]
    [Tooltip("Life time of the bullet. (Sec)")]
    public float lifeTime = 5f;
    [Tooltip("Prefab of the broken effect.")]
    public GameObject brokenObject;
    [HideInInspector]
    public float attackForce;
    private Transform thisTransform;
    private Rigidbody thisRigidbody;
    private bool isLive = true;
    private bool isRayHit;
    private int layerMask = -1029;
    private Vector3 nextPos;
    private Transform hitTransform;
    private Vector3 hitNormal;
    private Ray ray;

    private void Awake()
    {
      this.thisTransform = this.transform;
      this.thisRigidbody = this.GetComponent<Rigidbody>();
      this.ray = new Ray();
      Object.Destroy((Object) this.gameObject, this.lifeTime);
    }

    private void FixedUpdate()
    {
      if (!this.isLive)
        return;
      this.thisTransform.LookAt(this.thisTransform.position + this.thisRigidbody.velocity);
      if (!this.isRayHit)
      {
        this.ray.origin = this.thisTransform.position;
        this.ray.direction = this.thisRigidbody.velocity;
        RaycastHit hitInfo;
        Physics.Raycast(this.ray, out hitInfo, this.thisRigidbody.velocity.magnitude * Time.fixedDeltaTime, this.layerMask);
        if (!(bool) (Object) hitInfo.collider)
          return;
        this.nextPos = hitInfo.point;
        this.hitTransform = hitInfo.collider.transform;
        this.hitNormal = hitInfo.normal;
        this.isRayHit = true;
      }
      else
      {
        this.thisTransform.position = this.nextPos;
        this.thisRigidbody.position = this.nextPos;
        this.isLive = false;
        this.Hit();
      }
    }

    private void OnCollisionEnter(Collision collision)
    {
      if (!this.isLive)
        return;
      this.isLive = false;
      this.hitTransform = collision.collider.transform;
      this.hitNormal = collision.contacts[0].normal;
      this.Hit();
    }

    private void Hit()
    {
      if ((bool) (Object) this.brokenObject)
        Object.Instantiate<GameObject>(this.brokenObject, this.thisTransform.position, Quaternion.identity);
      float damageValue = this.attackForce * Mathf.Lerp(0.0f, 1f, Mathf.Sqrt(Mathf.Abs(90f - Vector3.Angle(this.thisRigidbody.velocity, this.hitNormal)) / 90f));
      if ((bool) (Object) this.hitTransform)
      {
        Armor_Collider_CS component1 = this.hitTransform.GetComponent<Armor_Collider_CS>();
        if ((bool) (Object) component1)
          damageValue *= component1.damageMultiplier;
        Damage_Control_CS component2 = this.hitTransform.root.GetComponent<Damage_Control_CS>();
        if ((bool) (Object) component2)
          component2.Get_Damage(damageValue);
      }
      Object.Destroy((Object) this.gameObject);
    }
  }
}
