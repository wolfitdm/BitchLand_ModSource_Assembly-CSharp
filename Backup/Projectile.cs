// Decompiled with JetBrains decompiler
// Type: Projectile
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Projectile : MonoBehaviour
{
  public ProjectileType projectileType;
  public DamageType damageType;
  public float damage = 100f;
  public float speed = 10f;
  public float initialForce = 1000f;
  public float lifetime = 30f;
  public float seekRate = 1f;
  public string seekTag = "Enemy";
  public GameObject explosion;
  public float targetListUpdateRate = 1f;
  public GameObject clusterBomb;
  public int clusterBombNum = 6;
  public int weaponType;
  private float lifeTimer;
  private float targetListUpdateTimer;
  private GameObject[] enemyList;
  public bool Collided;
  public Person ThisPerson;
  public float DestroyTimer;

  private void Start()
  {
    this.UpdateEnemyList();
    this.GetComponent<Rigidbody>().AddRelativeForce(0.0f, 0.0f, this.initialForce);
  }

  private void Update()
  {
    this.lifeTimer += Time.deltaTime;
    if ((double) this.lifeTimer >= (double) this.lifetime)
      this.Explode(this.transform.position);
    if ((double) this.initialForce == 0.0)
      this.GetComponent<Rigidbody>().velocity = this.transform.forward * this.speed;
    if (this.projectileType != ProjectileType.Seeker)
      return;
    this.targetListUpdateTimer += Time.deltaTime;
    if ((double) this.targetListUpdateTimer >= (double) this.targetListUpdateRate)
      this.UpdateEnemyList();
    if (this.enemyList == null)
      return;
    float num1 = -1f;
    Vector3 vector3 = this.transform.forward * 1000f;
    foreach (GameObject enemy in this.enemyList)
    {
      if ((Object) enemy != (Object) null)
      {
        float num2 = Vector3.Dot((enemy.transform.position - this.transform.position).normalized, this.transform.forward);
        if ((double) num2 > (double) num1)
        {
          vector3 = enemy.transform.position;
          num1 = num2;
        }
      }
    }
    this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(vector3 - this.transform.position), Time.deltaTime * this.seekRate);
  }

  private void UpdateEnemyList()
  {
    this.enemyList = GameObject.FindGameObjectsWithTag(this.seekTag);
    this.targetListUpdateTimer = 0.0f;
  }

  private void OnCollisionEnter(Collision col)
  {
    if (!this.Collided)
      this.Hit(col);
    this.Collided = true;
  }

  private void Hit(Collision col)
  {
    this.Explode(col.contacts[0].point);
    if (this.damageType != DamageType.Direct)
      return;
    col.collider.gameObject.SendMessageUpwards("ChangeHealth", (object) new object[3]
    {
      (object) (float) -(double) this.damage,
      (object) true,
      (object) this.ThisPerson
    }, SendMessageOptions.DontRequireReceiver);
    if (col.collider.gameObject.layer != LayerMask.NameToLayer("Limb"))
      return;
    Vector3 vector3 = col.collider.transform.position - this.transform.position;
  }

  private void Explode(Vector3 position)
  {
    if ((Object) this.explosion != (Object) null)
    {
      Explosion component = Object.Instantiate<GameObject>(this.explosion, position, Quaternion.identity).GetComponent<Explosion>();
      if ((Object) component != (Object) null)
        component.ThisPerson = this.ThisPerson;
    }
    if (this.projectileType == ProjectileType.ClusterBomb && (Object) this.clusterBomb != (Object) null)
    {
      for (int index = 0; index <= this.clusterBombNum; ++index)
        Object.Instantiate<GameObject>(this.clusterBomb, this.transform.position, Quaternion.identity);
    }
    AudioSource component1 = this.GetComponent<AudioSource>();
    if ((Object) component1 != (Object) null)
      component1.enabled = false;
    Object.Destroy((Object) this.gameObject, this.DestroyTimer);
  }

  public void MultiplyDamage(float amount) => this.damage *= amount;

  public void MultiplyInitialForce(float amount) => this.initialForce *= amount;
}
