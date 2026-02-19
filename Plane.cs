// Decompiled with JetBrains decompiler
// Type: Plane
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Plane : MonoBehaviour
{
  public float Speed;
  public float Health;
  public float PlaneLifeTime;
  public float[] RandomTurnRate;
  public float LerpSpeed;
  public GameObject DamageFX;
  public GameObject ExplosionFX;
  private Rigidbody _rb;
  private bool _isDead;

  private void Start()
  {
    this._rb = this.GetComponent<Rigidbody>();
    this.DamageFX.SetActive(false);
    this.ExplosionFX.SetActive(false);
    this.Invoke("Destroy", this.PlaneLifeTime);
  }

  private void FixedUpdate()
  {
    if (this._isDead)
      this.Speed = Mathf.Lerp(this.Speed, 0.0f, this.LerpSpeed * Time.fixedDeltaTime);
    this.transform.Translate(new Vector3(0.0f, 0.0f, 1f) * this.Speed * Time.fixedDeltaTime);
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (LayerMask.LayerToName(collision.gameObject.layer) != "Projectile" || this._isDead)
      return;
    --this.Health;
    if ((double) this.Health > 0.0)
      return;
    this._isDead = true;
    this.DamageFX.SetActive(true);
    this._rb.useGravity = true;
    this.Invoke("Destroy", 10f);
  }

  private void Destroy()
  {
    this.DamageFX.transform.SetParent((Transform) null);
    this.ExplosionFX.SetActive(true);
    this.ExplosionFX.transform.SetParent((Transform) null);
    Object.Destroy((Object) this.gameObject);
    Object.Destroy((Object) this.DamageFX);
  }
}
