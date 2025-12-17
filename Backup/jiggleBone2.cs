// Decompiled with JetBrains decompiler
// Type: jiggleBone2
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class jiggleBone2 : MonoBehaviour
{
  public float bounceFactor = 20f;
  public float wobbleFactor = 10f;
  public float maxTranslation = 0.05f;
  public float maxRotationDegrees = 5f;
  private Vector3 oldBoneWorldPosition;
  private Quaternion oldBoneWorldRotation;
  private Vector3 animatedBoneWorldPosition;
  private Quaternion animatedBoneWorldRotation;
  private Quaternion goalRotation;
  private Vector3 goalPosition;

  private void Awake()
  {
    this.oldBoneWorldPosition = this.transform.position;
    this.oldBoneWorldRotation = this.transform.rotation;
  }

  private void LateUpdate() => this.JiggleBonesUpdate();

  private void JiggleBonesUpdate()
  {
    this.animatedBoneWorldPosition = this.transform.position;
    this.animatedBoneWorldRotation = this.transform.rotation;
    this.goalPosition = Vector3.Slerp(this.oldBoneWorldPosition, this.transform.position, Time.deltaTime * this.bounceFactor);
    this.goalRotation = Quaternion.Slerp(this.oldBoneWorldRotation, this.transform.rotation, Time.deltaTime * this.wobbleFactor);
    this.transform.rotation = Quaternion.RotateTowards(this.animatedBoneWorldRotation, this.goalRotation, this.maxRotationDegrees);
    this.transform.position = Vector3.MoveTowards(this.animatedBoneWorldPosition, this.goalPosition, this.maxTranslation);
    this.oldBoneWorldPosition = this.transform.position;
    this.oldBoneWorldRotation = this.transform.rotation;
  }
}
