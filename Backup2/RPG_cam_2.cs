// Decompiled with JetBrains decompiler
// Type: RPG_cam_2
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class RPG_cam_2 : MonoBehaviour
{
  public Transform PlayerObj;
  public Transform target;
  public float targetHeight = 1.7f;
  public float distance = 1.5f;
  public float offsetFromWall = 0.1f;
  public float maxDistance = 1.5f;
  public float minDistance = 0.8f;
  public float xSpeed = 100f;
  public float ySpeed = 25f;
  public float xMinLimit = -20f;
  public float xMaxLimit = 40f;
  public float zoomRate = 150f;
  public float rotationDampening = 3f;
  public float zoomDampening = 5f;
  public LayerMask collisionLayers;
  public bool lockToRearOfTarget;
  public bool allowMouseInputX = true;
  public bool allowMouseInputY = true;
  public float xDeg;
  public float yDeg;
  public float currentDistance;
  public float desiredDistance;
  public float correctedDistance;
  private bool rotateBehind;
  public GameObject userModel;
  public bool inFirstPerson;
  public Transform CameraObj;
  public Transform CamSide;
  public Person Player;
  public float CamPointSide_Value;
  public bool CamPointSide_Right = true;
  public bool CamPointMoving;
  public FirstPersonCharacter FirstPerson;
  public bool isCorrected;
  public float RotationValue;

  private void Start()
  {
    Vector3 eulerAngles = this.transform.eulerAngles;
    this.xDeg = eulerAngles.x;
    this.yDeg = eulerAngles.y;
    this.currentDistance = this.distance;
    this.desiredDistance = this.distance;
    this.correctedDistance = this.distance;
    if (!this.lockToRearOfTarget)
      return;
    this.rotateBehind = true;
  }

  public void LateUpdate()
  {
    if (!(bool) (Object) this.target)
      return;
    this.xDeg += (float) ((double) Input.GetAxis("Mouse X") * (double) this.xSpeed * 0.019999999552965164) * UI_Settings.CurrentMouseSensitivity;
    this.yDeg -= (float) ((double) Input.GetAxis("Mouse Y") * (double) this.ySpeed * 0.019999999552965164) * UI_Settings.CurrentMouseSensitivity;
    this.ClampAngle(this.yDeg);
    Quaternion quaternion = Quaternion.Euler(this.yDeg, this.xDeg, 0.0f);
    this.desiredDistance -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * this.zoomRate * Mathf.Abs(this.desiredDistance);
    this.desiredDistance = Mathf.Clamp(this.desiredDistance, this.minDistance, this.maxDistance);
    this.correctedDistance = this.desiredDistance;
    Vector3 vector3_1 = this.target.position - quaternion * Vector3.forward * this.desiredDistance;
    this.target.LookAt(this.CameraObj.transform.position);
    if (this.FirstPerson.desiredMove != Vector3.zero)
    {
      this.Player.LookAtPlayer.enabled = false;
      if (Input.GetKey(KeyCode.LeftAlt))
      {
        this.FirstPerson.DesiredMoveTransformReference = this.FirstPerson.transform;
      }
      else
      {
        this.FirstPerson.DesiredMoveTransformReference = this.FirstPerson.CameraTransform;
        this.PlayerObj.eulerAngles = new Vector3(0.0f, this.target.eulerAngles.y + this.RotationValue, 0.0f);
        this.target.LookAt(this.CameraObj.transform.position);
      }
    }
    else
      this.Player.LookAtPlayer.EnableIfNotEnabled();
    bool flag = false;
    RaycastHit hitInfo;
    if (Physics.Raycast(this.target.position, this.target.forward, out hitInfo, 2f, (int) this.collisionLayers, QueryTriggerInteraction.Ignore))
    {
      flag = true;
      if ((double) hitInfo.distance < (double) this.desiredDistance)
      {
        this.isCorrected = true;
        this.currentDistance = hitInfo.distance - 0.1f;
      }
      else
      {
        this.isCorrected = false;
        this.currentDistance = this.correctedDistance;
        this.currentDistance = Mathf.Clamp(this.currentDistance, this.minDistance, this.maxDistance);
      }
    }
    if (!flag)
    {
      this.isCorrected = false;
      this.currentDistance = (double) this.correctedDistance > (double) this.currentDistance ? Mathf.Lerp(this.currentDistance, this.correctedDistance, Time.deltaTime * this.zoomDampening) : this.correctedDistance;
      this.currentDistance = Mathf.Clamp(this.correctedDistance, this.minDistance, this.maxDistance);
    }
    Vector3 vector3_2 = this.target.position - quaternion * Vector3.forward * this.currentDistance;
    this.transform.rotation = quaternion;
    this.transform.position = vector3_2;
  }

  private void ClampAngle(float angle)
  {
    if ((double) angle < -360.0)
      angle += 360f;
    if ((double) angle > 360.0)
      angle -= 360f;
    this.yDeg = Mathf.Clamp(angle, this.xMinLimit, this.xMaxLimit);
  }
}
