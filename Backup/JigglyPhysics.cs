// Decompiled with JetBrains decompiler
// Type: JigglyPhysics
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
