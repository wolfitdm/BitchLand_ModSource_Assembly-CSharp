// Decompiled with JetBrains decompiler
// Type: FirstPersonMovement
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
    this.rigidbody.velocity = this.transform.rotation * new Vector3(vector2.x, this.rigidbody.velocity.y, vector2.y);
  }
}
