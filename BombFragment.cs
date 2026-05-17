// Decompiled with JetBrains decompiler
// Type: BombFragment
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class BombFragment : MonoBehaviour
{
  public float speed = 5f;
  public GameObject explosion;

  private void Start()
  {
    this.transform.Rotate((float) Random.Range(-180, 180), (float) Random.Range(-180, 180), (float) Random.Range(-180, 180));
  }

  private void Update() => this.transform.Translate(0.0f, 0.0f, this.speed * Time.deltaTime);

  private void OnCollisionEnter(Collision col)
  {
    if (!((Object) col.collider.gameObject.GetComponent<BombFragment>() == (Object) null))
      return;
    this.Explode(col.contacts[0].point);
  }

  private void Explode(Vector3 position)
  {
    if ((Object) this.explosion != (Object) null)
      Object.Instantiate<GameObject>(this.explosion, position, Quaternion.identity);
    Object.Destroy((Object) this.gameObject);
  }
}
