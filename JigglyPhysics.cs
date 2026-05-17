// Decompiled with JetBrains decompiler
// Type: JigglyPhysics
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
    Vector3 direction = this.transform.InverseTransformDirection(this.GetComponent<Rigidbody>().linearVelocity);
    direction.x *= (float) (1.0 - (double) this.damping * (double) Time.fixedDeltaTime);
    direction.y *= (float) (1.0 - (double) this.damping * (double) Time.fixedDeltaTime);
    direction.z *= (float) (1.0 - (double) this.damping * (double) Time.fixedDeltaTime);
    this.velocity = this.transform.TransformDirection(direction);
    this.GetComponent<Rigidbody>().linearVelocity = this.velocity;
  }
}
