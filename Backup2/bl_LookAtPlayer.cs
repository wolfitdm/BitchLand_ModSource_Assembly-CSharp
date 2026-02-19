// Decompiled with JetBrains decompiler
// Type: bl_LookAtPlayer
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[DefaultExecutionOrder(99999999)]
public class bl_LookAtPlayer : MonoBehaviour
{
  public Person ThisPerson;
  public Transform headFrontTransform;
  public Transform headTransform;
  public Transform[] eyeTransforms;
  public Transform playerTransform;
  public Transform NonplayerTarget;
  public float visibleAngle = 90f;
  public float maxDistance = 3.5f;
  public float rotationSpeed = 1f;
  public float EyerotationSpeed = 5f;
  public float minClampAngle = -40f;
  public float maxClampAngle = 40f;
  public bool canSeePlayer;
  private Quaternion currentHeadRotation;
  private Quaternion[] currentEyeRotations;
  public bool Disable;
  public bool OnlyEyes;
  public Vector3 AddHeadRotation;
  public Vector3 AddEyeRotation;
  public bool ExtraRot;
  public bool DontBlockSides;
  public bool Restored;

  private void Start()
  {
    this.currentHeadRotation = this.headTransform.rotation;
    this.currentEyeRotations = new Quaternion[this.eyeTransforms.Length];
    for (int index = 0; index < this.eyeTransforms.Length; ++index)
      this.currentEyeRotations[index] = this.eyeTransforms[index].rotation;
  }

  public void LateUpdate()
  {
    Transform transform = this.NonplayerTarget;
    if ((Object) transform == (Object) null)
      transform = this.playerTransform;
    if ((Object) transform == (Object) null)
    {
      this.enabled = false;
    }
    else
    {
      if (this.Disable)
        return;
      Vector3 from = transform.position - this.headFrontTransform.position;
      this.canSeePlayer = (double) Vector3.Angle(from, this.headFrontTransform.forward) <= (double) this.visibleAngle && (double) from.magnitude <= (double) this.maxDistance;
      if (this.canSeePlayer)
      {
        this.Restored = false;
        if (!this.OnlyEyes)
        {
          Quaternion b = Quaternion.LookRotation(from * 0.6f + this.headFrontTransform.forward * 0.4f);
          if (this.ExtraRot)
            b = Quaternion.Euler(new Vector3(b.eulerAngles.x + this.AddHeadRotation.x, b.eulerAngles.y + this.AddHeadRotation.y, b.eulerAngles.z + this.AddHeadRotation.z));
          this.currentHeadRotation = Quaternion.Slerp(this.currentHeadRotation, b, this.rotationSpeed * Time.deltaTime);
          this.headTransform.rotation = this.currentHeadRotation;
        }
        for (int index = 0; index < this.eyeTransforms.Length; ++index)
        {
          Quaternion b = Quaternion.LookRotation(transform.position - this.eyeTransforms[index].position);
          if (this.ExtraRot)
            b = Quaternion.Euler(new Vector3(b.eulerAngles.x + this.AddEyeRotation.x, b.eulerAngles.y + this.AddEyeRotation.y, b.eulerAngles.z + this.AddEyeRotation.z));
          this.currentEyeRotations[index] = Quaternion.Slerp(this.currentEyeRotations[index], b, this.EyerotationSpeed * Time.deltaTime);
          this.eyeTransforms[index].rotation = this.currentEyeRotations[index];
          if (this.ThisPerson is Girl)
          {
            if ((double) this.eyeTransforms[index].localEulerAngles.y < 180.0)
            {
              if ((double) this.eyeTransforms[index].localEulerAngles.y > 29.0)
                this.eyeTransforms[index].localEulerAngles = new Vector3(this.eyeTransforms[index].localEulerAngles.x, 29f, this.eyeTransforms[index].localEulerAngles.z);
            }
            else if ((double) this.eyeTransforms[index].localEulerAngles.y < 327.0)
              this.eyeTransforms[index].localEulerAngles = new Vector3(this.eyeTransforms[index].localEulerAngles.x, 327f, this.eyeTransforms[index].localEulerAngles.z);
            this.currentEyeRotations[index] = this.eyeTransforms[index].rotation;
          }
        }
      }
      else if (!this.Restored && (double) Quaternion.Angle(this.currentHeadRotation, this.headTransform.rotation) >= 1.0)
      {
        if (!this.OnlyEyes)
        {
          this.currentHeadRotation = Quaternion.Slerp(this.currentHeadRotation, this.headTransform.rotation, this.rotationSpeed * Time.deltaTime);
          this.headTransform.rotation = this.currentHeadRotation;
          if ((double) this.headTransform.localEulerAngles.y < 1.0 || (double) this.headTransform.localEulerAngles.y > 359.0)
            this.Restored = true;
        }
        for (int index = 0; index < this.eyeTransforms.Length; ++index)
        {
          this.currentEyeRotations[index] = Quaternion.Slerp(this.currentEyeRotations[index], this.eyeTransforms[index].rotation, this.EyerotationSpeed * Time.deltaTime);
          this.eyeTransforms[index].rotation = this.currentEyeRotations[index];
        }
      }
      if (this.DontBlockSides || (double) this.headTransform.localEulerAngles.y > 0.0 && (double) this.headTransform.localEulerAngles.y < 55.0 || (double) this.headTransform.localEulerAngles.y > 305.0 && (double) this.headTransform.localEulerAngles.y < 360.0)
        return;
      if ((double) this.headTransform.localEulerAngles.y > 180.0)
        this.headTransform.localEulerAngles = new Vector3(this.headTransform.localEulerAngles.x, 305f, this.headTransform.localEulerAngles.z);
      else
        this.headTransform.localEulerAngles = new Vector3(this.headTransform.localEulerAngles.x, 55f, this.headTransform.localEulerAngles.z);
    }
  }

  private Quaternion ClampRotation(Quaternion rotation, float minAngle, float maxAngle)
  {
    Vector3 eulerAngles = rotation.eulerAngles;
    eulerAngles.y = Mathf.Clamp(eulerAngles.y, minAngle, maxAngle);
    return Quaternion.Euler(eulerAngles);
  }

  public void EnableIfNotEnabled()
  {
    if (this.enabled)
      return;
    this.enabled = true;
    this.headTransform.localRotation = Quaternion.identity;
    this.currentHeadRotation = this.headTransform.rotation;
  }
}
