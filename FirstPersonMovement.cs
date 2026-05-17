// Decompiled with JetBrains decompiler
// Type: FirstPersonMovement
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class FirstPersonMovement : MonoBehaviour
{
  public float speed = 5f;
  [Header("Running")]
  public bool canRun = true;
  public float runSpeed = 9f;
  public KeyCode runningKey = KeyCode.LeftShift;
  private Rigidbody rigidbody;
  public List<Func<float>> speedOverrides = new List<Func<float>>();

  public bool IsRunning { get; private set; }

  private void Awake() => this.rigidbody = this.GetComponent<Rigidbody>();

  private void FixedUpdate()
  {
    this.IsRunning = this.canRun && Input.GetKey(this.runningKey);
    float num = this.IsRunning ? this.runSpeed : this.speed;
    if (this.speedOverrides.Count > 0)
      num = this.speedOverrides[this.speedOverrides.Count - 1]();
    Vector2 vector2 = new Vector2(Input.GetAxis("Horizontal") * num, Input.GetAxis("Vertical") * num);
    this.rigidbody.linearVelocity = this.transform.rotation * new Vector3(vector2.x, this.rigidbody.linearVelocity.y, vector2.y);
  }
}
