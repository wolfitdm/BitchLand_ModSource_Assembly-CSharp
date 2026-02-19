// Decompiled with JetBrains decompiler
// Type: ChobiAssets.KTP.Cannon_Control_CS
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace ChobiAssets.KTP
{
  public class Cannon_Control_CS : MonoBehaviour
  {
    [Header("Cannon movement settings")]
    [Tooltip("Rotation Speed. (Degree per Second)")]
    public float rotationSpeed = 10f;
    [Tooltip("Angle range for slowing down. (Degree)")]
    public float bufferAngle = 1f;
    [Tooltip("Maximum elevation angle. (Degree)")]
    public float maxElev = 15f;
    [Tooltip("Maximum depression angle. (Degree)")]
    public float maxDep = 10f;
    private Transform thisTransform;
    private Turret_Control_CS turretScript;
    private float currentAng;

    private void Awake()
    {
      this.thisTransform = this.transform;
      this.turretScript = this.thisTransform.GetComponentInParent<Turret_Control_CS>();
      if ((Object) this.turretScript == (Object) null)
      {
        Debug.LogError((object) "Cannon_Base cannot find Turret_Control_CS.");
        Object.Destroy((Object) this);
      }
      this.currentAng = this.thisTransform.localEulerAngles.x;
    }

    private void FixedUpdate()
    {
      float f = !this.turretScript.isTracking ? -Mathf.DeltaAngle(this.currentAng, 0.0f) : this.Manual_Angle() + (Mathf.DeltaAngle(0.0f, this.thisTransform.localEulerAngles.x) + this.turretScript.adjustAng.y);
      if ((double) Mathf.Abs(f) <= 0.0099999997764825821)
        return;
      this.currentAng += this.rotationSpeed * (-Mathf.Lerp(0.0f, 1f, Mathf.Abs(f) / (this.rotationSpeed * Time.fixedDeltaTime + this.bufferAngle)) * Mathf.Sign(f)) * Time.fixedDeltaTime;
      this.currentAng = Mathf.Clamp(this.currentAng, -this.maxElev, this.maxDep);
      this.thisTransform.localRotation = Quaternion.Euler(new Vector3(this.currentAng, 0.0f, 0.0f));
    }

    private float Manual_Angle()
    {
      return 57.29578f * Mathf.Asin((this.turretScript.localTargetPos.y - this.thisTransform.localPosition.y) / Vector3.Distance(this.thisTransform.localPosition, this.turretScript.localTargetPos));
    }

    private void Destroy()
    {
      this.thisTransform.localRotation = Quaternion.Euler(new Vector3(this.maxDep, 0.0f, 0.0f));
      Object.Destroy((Object) this);
    }
  }
}
