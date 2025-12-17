// Decompiled with JetBrains decompiler
// Type: PlayerController1
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class PlayerController1 : MonoBehaviour
{
  public Rigidbody Rigid;
  public float speedPower;
  public Transform centerOfmass;
  private float torque = 100f;
  private Vector3 vel;
  public float currentSpeed;
  public float maxSpeed = 2.5f;
  public AudioSource engineSound;
  public Transform[] Wheels;
  public Transform[] TurnWheels;

  private void Start()
  {
    this.Rigid.centerOfMass = this.centerOfmass.localPosition;
    this.engineSound.pitch = 0.6f;
    this.Rigid.maxAngularVelocity = 0.6f;
    Cursor.visible = false;
    Cursor.lockState = CursorLockMode.Locked;
  }

  private void FixedUpdate()
  {
    float num = Input.GetAxis("Horizontal") * this.speedPower;
    Vector3 vector3 = new Vector3(0.0f, 0.0f, Input.GetAxis("Vertical"));
    if ((double) this.currentSpeed < (double) this.maxSpeed)
      this.Rigid.AddRelativeForce(vector3 * this.speedPower);
    this.Rigid.AddTorque(this.transform.up * this.torque * num);
  }

  public void OnApplicationFocus(bool focus)
  {
    if (!focus)
      return;
    Cursor.visible = false;
    Cursor.lockState = CursorLockMode.Locked;
  }

  private void Update()
  {
    this.torque = (double) this.currentSpeed <= 1.0 ? 100f : 50f;
    this.vel = this.Rigid.velocity;
    this.currentSpeed = this.vel.magnitude;
    this.engineSound.pitch = (float) (0.30000001192092896 + (double) this.currentSpeed / 10.0);
    for (int index = 0; index < this.Wheels.Length; ++index)
      this.Wheels[index].localEulerAngles += new Vector3(this.currentSpeed, 0.0f, 0.0f);
  }
}
