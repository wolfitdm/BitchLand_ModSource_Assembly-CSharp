// Decompiled with JetBrains decompiler
// Type: UnitySampleAssetsModified.Camera2DFollow
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace UnitySampleAssetsModified;

public class Camera2DFollow : MonoBehaviour
{
  public Transform target;
  public float damping = 1f;
  public float lookAheadFactor = 3f;
  public float lookAheadReturnSpeed = 0.5f;
  public float lookAheadMoveThreshold = 0.1f;
  private Vector3 offsetY;
  private float offsetZ;
  private Vector3 lastTargetPosition;
  private Vector3 currentVelocity;
  private Vector3 lookAheadPos;

  private void Awake()
  {
    this.lastTargetPosition = this.target.position;
    this.offsetY = this.transform.position - this.target.position;
    this.offsetY.x = 0.0f;
    this.offsetY.z = 0.0f;
    this.offsetZ = (this.transform.position - this.target.position).z;
    this.transform.parent = (Transform) null;
  }

  private void Update()
  {
    float x = (this.target.position - this.lastTargetPosition).x;
    this.lookAheadPos = (double) Mathf.Abs(x) <= (double) this.lookAheadMoveThreshold ? Vector3.MoveTowards(this.lookAheadPos, Vector3.zero, Time.deltaTime * this.lookAheadReturnSpeed) : this.lookAheadFactor * Vector3.right * Mathf.Sign(x);
    this.transform.position = Vector3.SmoothDamp(this.transform.position, this.target.position + this.lookAheadPos + Vector3.forward * this.offsetZ + this.offsetY, ref this.currentVelocity, this.damping);
    this.lastTargetPosition = this.target.position;
  }
}
