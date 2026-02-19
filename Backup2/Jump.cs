// Decompiled with JetBrains decompiler
// Type: Jump
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
