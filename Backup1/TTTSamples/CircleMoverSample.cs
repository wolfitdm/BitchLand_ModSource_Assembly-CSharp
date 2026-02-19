// Decompiled with JetBrains decompiler
// Type: TTTSamples.CircleMoverSample
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace TTTSamples
{
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
}
