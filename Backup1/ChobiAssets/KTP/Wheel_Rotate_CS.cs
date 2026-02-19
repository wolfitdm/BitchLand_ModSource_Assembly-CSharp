// Decompiled with JetBrains decompiler
// Type: ChobiAssets.KTP.Wheel_Rotate_CS
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace ChobiAssets.KTP
{
  public class Wheel_Rotate_CS : MonoBehaviour
  {
    private bool isLeft;
    private Rigidbody thisRigidbody;
    private float maxAngVelocity;
    private Wheel_Control_CS controlScript;
    private Transform thisTransform;
    private Transform parentTransform;
    private Vector3 angles;

    private void Awake()
    {
      this.gameObject.layer = 9;
      this.thisRigidbody = this.GetComponent<Rigidbody>();
      this.isLeft = (double) this.transform.localPosition.y > 0.0;
      this.thisTransform = this.transform;
      this.parentTransform = this.thisTransform.parent;
      this.angles = this.thisTransform.localEulerAngles;
      this.controlScript = this.parentTransform.parent.GetComponent<Wheel_Control_CS>();
      this.maxAngVelocity = (float) (Math.PI / 180.0 * ((double) this.controlScript.maxSpeed / (6.2831854820251465 * (double) this.GetComponent<SphereCollider>().radius) * 360.0));
    }

    private void FixedUpdate()
    {
      float f = !this.isLeft ? this.controlScript.rightRate : this.controlScript.leftRate;
      this.thisRigidbody.AddRelativeTorque(0.0f, Mathf.Sign(f) * this.controlScript.wheelTorque, 0.0f);
      this.thisRigidbody.maxAngularVelocity = Mathf.Abs(this.maxAngVelocity * f);
      this.angles.y = this.thisTransform.localEulerAngles.y;
      this.thisRigidbody.rotation = this.parentTransform.rotation * Quaternion.Euler(this.angles);
    }

    private void Destroy()
    {
      this.thisRigidbody.angularDrag = float.PositiveInfinity;
      UnityEngine.Object.Destroy((UnityEngine.Object) this);
    }

    private void Pause(bool isPaused) => this.enabled = !isPaused;
  }
}
