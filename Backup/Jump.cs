// Decompiled with JetBrains decompiler
// Type: Jump
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class Jump : MonoBehaviour
{
  private Rigidbody rigidbody;
  public float jumpStrength = 2f;
  [SerializeField]
  [Tooltip("Prevents jumping when the transform is in mid-air.")]
  private GroundCheck groundCheck;

  public event Action Jumped;

  private void Reset() => this.groundCheck = this.GetComponentInChildren<GroundCheck>();

  private void Awake() => this.rigidbody = this.GetComponent<Rigidbody>();

  private void LateUpdate()
  {
    if (!Input.GetButtonDown(nameof (Jump)) || (bool) (UnityEngine.Object) this.groundCheck && !this.groundCheck.isGrounded)
      return;
    this.rigidbody.AddForce(Vector3.up * 100f * this.jumpStrength);
    Action jumped = this.Jumped;
    if (jumped == null)
      return;
    jumped();
  }
}
