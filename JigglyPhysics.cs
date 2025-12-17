// Decompiled with JetBrains decompiler
// Type: JigglyPhysics
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class JigglyPhysics : MonoBehaviour
{
  public float springForce = 1000f;
  public float damping = 0.5f;
  private Vector3 velocity = Vector3.zero;

  private void FixedUpdate()
  {
    Vector3 force = this.springForce * this.transform.up;
    this.GetComponent<Rigidbody>().AddForce(force, ForceMode.Force);
    Vector3 direction = this.transform.InverseTransformDirection(this.GetComponent<Rigidbody>().velocity);
    direction.x *= (float) (1.0 - (double) this.damping * (double) Time.fixedDeltaTime);
    direction.y *= (float) (1.0 - (double) this.damping * (double) Time.fixedDeltaTime);
    direction.z *= (float) (1.0 - (double) this.damping * (double) Time.fixedDeltaTime);
    this.velocity = this.transform.TransformDirection(direction);
    this.GetComponent<Rigidbody>().velocity = this.velocity;
  }
}
