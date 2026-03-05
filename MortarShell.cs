// Decompiled with JetBrains decompiler
// Type: MortarShell
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class MortarShell : MonoBehaviour
{
  private Rigidbody mortarRigidbody;
  public GameObject explosionPrefab;
  public GameObject explosionNoCrater;

  private void Start() => this.mortarRigidbody = this.GetComponent<Rigidbody>();

  private void Update()
  {
    this.transform.forward = Vector3.Slerp(this.transform.forward, this.mortarRigidbody.velocity.normalized, Time.deltaTime);
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Terrain"))
      Object.Instantiate<GameObject>(this.explosionPrefab, this.transform.position, Quaternion.identity);
    else
      Object.Instantiate<GameObject>(this.explosionNoCrater, this.transform.position, Quaternion.identity);
    Object.Destroy((Object) this.gameObject);
  }
}
