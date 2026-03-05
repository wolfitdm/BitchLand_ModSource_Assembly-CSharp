// Decompiled with JetBrains decompiler
// Type: TracksControler
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class TracksControler : MonoBehaviour
{
  private float offsetL;
  private float offsetR;
  public Renderer trackLeft;
  public Renderer trackRight;
  public Rigidbody Rig;
  private Vector3 vel;
  private float speed;
  private bool Front;
  private bool Back;
  private bool turn = true;
  public bool Reverse;

  private void pressFunc()
  {
    if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && (double) this.speed < 0.30000001192092896)
    {
      this.Front = true;
      this.Back = false;
    }
    if (!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.DownArrow) || (double) this.speed >= 0.30000001192092896)
      return;
    this.Back = true;
    this.Front = false;
  }

  private void Update()
  {
    this.pressFunc();
    if ((double) this.Rig.angularVelocity.magnitude > 0.10000000149011612 && (double) this.speed < 1.5)
    {
      if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
      {
        this.offsetL += 1f / 500f;
        this.offsetR -= 1f / 500f;
      }
      if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
      {
        this.offsetL -= 1f / 500f;
        this.offsetR += 1f / 500f;
      }
      this.turn = true;
    }
    else
      this.turn = false;
    if ((double) this.speed > 0.0 && !this.turn)
    {
      if (this.Front)
      {
        this.offsetL -= this.speed / 1000f;
        this.offsetR -= this.speed / 1000f;
      }
      if (this.Back)
      {
        this.offsetL += this.speed / 1000f;
        this.offsetR += this.speed / 1000f;
      }
    }
    this.vel = this.Rig.velocity;
    this.speed = this.vel.magnitude;
    if (this.Reverse)
    {
      this.trackLeft.material.SetTextureOffset("_MainTex", new Vector2(-this.offsetL, 0.0f));
      this.trackRight.material.SetTextureOffset("_MainTex", new Vector2(-this.offsetR, 0.0f));
    }
    else
    {
      this.trackLeft.material.SetTextureOffset("_MainTex", new Vector2(this.offsetL, 0.0f));
      this.trackRight.material.SetTextureOffset("_MainTex", new Vector2(this.offsetR, 0.0f));
    }
  }
}
