// Decompiled with JetBrains decompiler
// Type: ThirdPersonCamRPG
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class ThirdPersonCamRPG : MonoBehaviour
{
  public Camera MainCam;
  public float SideSide;
  public float SideSideMax;
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
  public bool rotateBehind;
  public GameObject userModel;
  public bool inFirstPerson;
  public bool CamPointSide_Right = true;
  public bool CamPointMoving;
  private bool isCorrected;
  public Transform PlayerObj;
  public float ExtraX = 10f;
  public Vector3 HeadRot;
  public float SavedHeadX;
  public float SavedHeadY;
  public float HeadX;
  public float HeadY;

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

  private void Update()
  {
    if (!Main.Instance.Player.FirstPersonController.Basic3rdPerson && Input.GetKeyUp(KeyCode.P))
    {
      this.CamPointSide_Right = !this.CamPointSide_Right;
      this.CamPointMoving = true;
    }
    if (!this.CamPointMoving)
      return;
    if (this.CamPointSide_Right)
    {
      this.SideSide = this.SideSideMax;
      this.MainCam.transform.localPosition = new Vector3(Mathf.Lerp(this.MainCam.transform.localPosition.x, this.SideSide, Time.deltaTime), this.MainCam.transform.localPosition.y, this.MainCam.transform.localPosition.z);
      if ((double) this.SideSide - (double) this.MainCam.transform.localPosition.x >= 0.0099999997764825821)
        return;
      this.CamPointMoving = false;
      this.MainCam.transform.localPosition = new Vector3(this.SideSide, this.MainCam.transform.localPosition.y, this.MainCam.transform.localPosition.z);
    }
    else
    {
      this.SideSide = -this.SideSideMax;
      this.MainCam.transform.localPosition = new Vector3(Mathf.Lerp(this.MainCam.transform.localPosition.x, this.SideSide, Time.deltaTime), this.MainCam.transform.localPosition.y, this.MainCam.transform.localPosition.z);
      if ((double) this.MainCam.transform.localPosition.x - (double) this.SideSide >= 0.0099999997764825821)
        return;
      this.CamPointMoving = false;
      this.MainCam.transform.localPosition = new Vector3(this.SideSide, this.MainCam.transform.localPosition.y, this.MainCam.transform.localPosition.z);
    }
  }

  public void LateUpdate()
  {
    if (!(bool) (Object) this.target)
      return;
    this.xDeg += (float) ((double) Input.GetAxis("Mouse X") * (double) this.xSpeed * 0.019999999552965164);
    this.yDeg -= (float) ((double) Input.GetAxis("Mouse Y") * (double) this.ySpeed * 0.019999999552965164);
    this.ClampAngle(this.yDeg);
    Quaternion quaternion = Quaternion.Euler(this.yDeg, this.xDeg, 0.0f);
    this.desiredDistance -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * this.zoomRate * Mathf.Abs(this.desiredDistance);
    this.desiredDistance = Mathf.Clamp(this.desiredDistance, this.minDistance, this.maxDistance);
    this.correctedDistance = this.desiredDistance;
    Vector3 vector3_1 = this.transform.position - quaternion * Vector3.forward * this.desiredDistance;
    this.transform.LookAt(this.target.position);
    RaycastHit hitInfo;
    if (Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo))
    {
      if ((double) hitInfo.distance < (double) this.desiredDistance)
      {
        this.isCorrected = true;
        this.currentDistance = hitInfo.distance - 0.1f;
      }
      else
      {
        this.isCorrected = false;
        this.currentDistance = !this.isCorrected || (double) this.correctedDistance > (double) this.currentDistance ? Mathf.Lerp(this.currentDistance, this.correctedDistance, Time.deltaTime * this.zoomDampening) : this.correctedDistance;
        this.currentDistance = Mathf.Clamp(this.currentDistance, this.minDistance, this.maxDistance);
      }
    }
    Vector3 vector3_2 = this.transform.position - quaternion * Vector3.forward * this.currentDistance;
    this.target.rotation = quaternion;
    this.target.position = vector3_2;
  }

  private void ClampAngle(float angle)
  {
    if ((double) angle < -360.0)
      angle += 360f;
    if ((double) angle > 360.0)
      angle -= 360f;
    this.yDeg = Mathf.Clamp(angle, this.xMinLimit, this.xMaxLimit);
  }

  private void ClampAngle2(float angle)
  {
    if ((double) angle < 50.0)
      this.HeadY = angle;
    else if ((double) angle > 310.0)
      this.HeadY = angle;
    else
      this.HeadY = 0.0f;
  }
}
