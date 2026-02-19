// Decompiled with JetBrains decompiler
// Type: Jump
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
