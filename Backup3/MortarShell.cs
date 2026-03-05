// Decompiled with JetBrains decompiler
// Type: MortarShell
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
