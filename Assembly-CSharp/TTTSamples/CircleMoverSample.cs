// Decompiled with JetBrains decompiler
// Type: TTTSamples.CircleMoverSample
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
