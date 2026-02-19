// Decompiled with JetBrains decompiler
// Type: CameraFollow
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class CameraFollow : MonoBehaviour
{
  public List<Transform> targetCharacters;
  public Vector3 targetCorrection = new Vector3(0.0f, 0.9f, 0.0f);
  public Camera usedCamera;
  public float stepFieldOfView = 0.5f;
  public float rotationSpeed = 10f;
  public float maxRotationSpeed = 120f;
  private float maxRotationHeight;
  public float maxTargetCorrection = 2f;
  private bool circulateGroup;
  private float cameraAngle;
  private float cameraDistance;

  private void Start()
  {
    this.cameraAngle = Mathf.Atan2(this.usedCamera.transform.localPosition.x, this.usedCamera.transform.localPosition.y);
    this.cameraDistance = Vector3.Distance(this.usedCamera.transform.position, this.transform.position);
    this.maxRotationHeight = (float) ((double) this.maxRotationSpeed / 180.0 * 3.1415927410125732);
  }

  private void Update()
  {
    Vector3 vector3 = new Vector3();
    foreach (Transform targetCharacter in this.targetCharacters)
      vector3 += targetCharacter.position;
    Vector3 worldPosition = vector3 / (float) this.targetCharacters.Count + this.targetCorrection;
    this.transform.position = worldPosition;
    if ((double) Input.GetAxis("Mouse ScrollWheel") > 0.0)
      this.usedCamera.fieldOfView += this.stepFieldOfView;
    else if ((double) Input.GetAxis("Mouse ScrollWheel") < 0.0)
      this.usedCamera.fieldOfView -= this.stepFieldOfView;
    if (Input.GetMouseButton(0))
    {
      this.circulateGroup = false;
      float num = (float) (((double) Input.mousePosition.x - (double) (Screen.width / 2)) / (double) Screen.width / 2.0);
      if (Input.GetKey(KeyCode.LeftShift))
        this.targetCorrection.x += this.maxTargetCorrection * num * Time.deltaTime;
      else
        this.transform.Rotate(0.0f, num * this.maxRotationSpeed * Time.deltaTime, 0.0f);
    }
    else if (Input.GetKeyDown(KeyCode.R))
      this.circulateGroup = !this.circulateGroup;
    if (Input.GetMouseButton(1))
    {
      float num = (float) (((double) (Screen.height / 2) - (double) Input.mousePosition.y) / (double) Screen.height / -2.0);
      if (Input.GetKey(KeyCode.LeftShift))
      {
        this.targetCorrection.y += this.maxTargetCorrection * num * Time.deltaTime;
      }
      else
      {
        this.cameraAngle += num * this.maxRotationHeight * Time.deltaTime;
        this.usedCamera.transform.localPosition = new Vector3(Mathf.Sin(this.cameraAngle) * this.cameraDistance, Mathf.Cos(this.cameraAngle) * this.cameraDistance, 0.0f);
      }
    }
    if (this.circulateGroup)
      this.transform.Rotate(0.0f, this.rotationSpeed * Time.deltaTime, 0.0f);
    this.usedCamera.transform.LookAt(worldPosition);
  }
}
