// Decompiled with JetBrains decompiler
// Type: TTTSamples.CircleMoverSample
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace TTTSamples;

public class CircleMoverSample : MonoBehaviour
{
  private float moveSpeed = 150f;
  private float torque;
  private Rigidbody2D rb;

  private void Start() => this.rb = this.GetComponent<Rigidbody2D>();

  private void Update()
  {
    this.torque = Input.GetAxis("Horizontal") * this.moveSpeed * Time.deltaTime;
  }

  private void FixedUpdate() => this.rb.AddTorque(-this.torque);
}
