// Decompiled with JetBrains decompiler
// Type: ThirdPerson
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class ThirdPerson : MonoBehaviour
{
  public Transform player;
  public Vector3 pivotOffset = new Vector3(0.0f, 1.7f, 0.0f);
  public Vector3 camOffset = new Vector3(0.0f, 0.0f, -3f);
  public float smooth = 10f;
  public float horizontalAimingSpeed = 6f;
  public float verticalAimingSpeed = 6f;
  public float maxVerticalAngle = 30f;
  public float minVerticalAngle = -60f;
  public string XAxis = "Analog X";
  public string YAxis = "Analog Y";
  private float angleH;
  private float angleV;
  private Transform cam;
  private Vector3 smoothPivotOffset;
  private Vector3 smoothCamOffset;
  private Vector3 targetPivotOffset;
  private Vector3 targetCamOffset;
  private float defaultFOV;
  private float targetFOV;
  private float targetMaxVerticalAngle;
  private bool isCustomOffset;

  public float GetH => this.angleH;

  private void Awake()
  {
    this.cam = this.transform;
    this.cam.position = this.player.position + Quaternion.identity * this.pivotOffset + Quaternion.identity * this.camOffset;
    this.cam.rotation = Quaternion.identity;
    this.smoothPivotOffset = this.pivotOffset;
    this.smoothCamOffset = this.camOffset;
    this.defaultFOV = this.cam.GetComponent<Camera>().fieldOfView;
    this.angleH = this.player.eulerAngles.y;
    this.ResetTargetOffsets();
    this.ResetFOV();
    this.ResetMaxVerticalAngle();
    if ((double) this.camOffset.y <= 0.0)
      return;
    Debug.LogWarning((object) "Vertical Cam Offset (Y) will be ignored during collisions!\nIt is recommended to set all vertical offset in Pivot Offset.");
  }

  private void Update()
  {
    this.angleH += Mathf.Clamp(Input.GetAxis("Mouse X"), -1f, 1f) * this.horizontalAimingSpeed;
    this.angleV += Mathf.Clamp(Input.GetAxis("Mouse Y"), -1f, 1f) * this.verticalAimingSpeed;
    this.angleV = Mathf.Clamp(this.angleV, this.minVerticalAngle, this.targetMaxVerticalAngle);
    Quaternion quaternion1 = Quaternion.Euler(0.0f, this.angleH, 0.0f);
    Quaternion quaternion2 = Quaternion.Euler(-this.angleV, this.angleH, 0.0f);
    this.cam.rotation = quaternion2;
    this.cam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(this.cam.GetComponent<Camera>().fieldOfView, this.targetFOV, Time.deltaTime);
    Vector3 vector3_1 = this.player.position + quaternion1 * this.targetPivotOffset;
    Vector3 vector3_2 = this.targetCamOffset;
    while ((double) vector3_2.magnitude >= 0.20000000298023224 && !this.DoubleViewingPosCheck(vector3_1 + quaternion2 * vector3_2))
      vector3_2 -= vector3_2.normalized * 0.2f;
    if ((double) vector3_2.magnitude < 0.20000000298023224)
      vector3_2 = Vector3.zero;
    bool flag = this.isCustomOffset && (double) vector3_2.sqrMagnitude < (double) this.targetCamOffset.sqrMagnitude;
    this.smoothPivotOffset = Vector3.Lerp(this.smoothPivotOffset, flag ? this.pivotOffset : this.targetPivotOffset, this.smooth * Time.deltaTime);
    this.smoothCamOffset = Vector3.Lerp(this.smoothCamOffset, flag ? Vector3.zero : vector3_2, this.smooth * Time.deltaTime);
    this.cam.position = this.player.position + quaternion1 * this.smoothPivotOffset + quaternion2 * this.smoothCamOffset;
  }

  public void SetTargetOffsets(Vector3 newPivotOffset, Vector3 newCamOffset)
  {
    this.targetPivotOffset = newPivotOffset;
    this.targetCamOffset = newCamOffset;
    this.isCustomOffset = true;
  }

  public void ResetTargetOffsets()
  {
    this.targetPivotOffset = this.pivotOffset;
    this.targetCamOffset = this.camOffset;
    this.isCustomOffset = false;
  }

  public void ResetYCamOffset() => this.targetCamOffset.y = this.camOffset.y;

  public void SetYCamOffset(float y) => this.targetCamOffset.y = y;

  public void SetXCamOffset(float x) => this.targetCamOffset.x = x;

  public void SetFOV(float customFOV) => this.targetFOV = customFOV;

  public void ResetFOV() => this.targetFOV = this.defaultFOV;

  public void SetMaxVerticalAngle(float angle) => this.targetMaxVerticalAngle = angle;

  public void ResetMaxVerticalAngle() => this.targetMaxVerticalAngle = this.maxVerticalAngle;

  private bool DoubleViewingPosCheck(Vector3 checkPos)
  {
    return this.ViewingPosCheck(checkPos) && this.ReverseViewingPosCheck(checkPos);
  }

  private bool ViewingPosCheck(Vector3 checkPos)
  {
    Vector3 direction = this.player.position + this.pivotOffset - checkPos;
    RaycastHit hitInfo;
    return !Physics.SphereCast(checkPos, 0.2f, direction, out hitInfo, direction.magnitude) || !((Object) hitInfo.transform != (Object) this.player) || hitInfo.transform.GetComponent<Collider>().isTrigger;
  }

  private bool ReverseViewingPosCheck(Vector3 checkPos)
  {
    Vector3 origin = this.player.position + this.pivotOffset;
    Vector3 direction = checkPos - origin;
    RaycastHit hitInfo;
    return !Physics.SphereCast(origin, 0.2f, direction, out hitInfo, direction.magnitude) || !((Object) hitInfo.transform != (Object) this.player) || !((Object) hitInfo.transform != (Object) this.transform) || hitInfo.transform.GetComponent<Collider>().isTrigger;
  }

  public float GetCurrentPivotMagnitude(Vector3 finalPivotOffset)
  {
    return Mathf.Abs((finalPivotOffset - this.smoothPivotOffset).magnitude);
  }
}
