// Decompiled with JetBrains decompiler
// Type: ChobiAssets.KTP.Turret_Control_CS
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
namespace ChobiAssets.KTP;

public class Turret_Control_CS : MonoBehaviour
{
  [Header("Turret movement settings")]
  [Tooltip("Maximum Rotation Speed. (Degree per Second)")]
  public float rotationSpeed = 15f;
  [Tooltip("Time to reach the maximum speed. (Sec)")]
  public float acceleration_Time = 0.2f;
  [Tooltip("Angle range for slowing down. (Degree)")]
  public float bufferAngle = 5f;
  [Tooltip("Name of Image for marker.")]
  public string markerName = "Marker";
  [Tooltip("Assign the 'Gun_Camera'.")]
  public GunCamera_Control_CS gunCameraScript;
  [HideInInspector]
  public bool isTracking = true;
  [HideInInspector]
  public Vector3 targetPos;
  [HideInInspector]
  public Vector3 localTargetPos;
  [HideInInspector]
  public Vector3 adjustAng;
  private Transform thisTransform;
  private Transform rootTransform;
  private float currentAng;
  private Transform targetTransform;
  private Vector3 targetOffset;
  private Vector3 previousMousePos;
  private float speedRate;
  private Image markerImage;
  private int layerMask = -1541;
  private float targetAng;
  private bool gunCamFlag;
  private float spherecastRadius = 0.5f;
  private ID_Control_CS idScript;

  private void Awake()
  {
    this.thisTransform = this.transform;
    this.rootTransform = this.thisTransform.root;
    this.currentAng = this.thisTransform.localEulerAngles.y;
    if ((Object) this.gunCameraScript == (Object) null)
      Debug.LogError((object) "'Gun Camera Script' is not assigned.");
    this.Find_Image();
  }

  private void Find_Image()
  {
    if (!string.IsNullOrEmpty(this.markerName))
    {
      GameObject gameObject = GameObject.Find(this.markerName);
      if ((bool) (Object) gameObject)
        this.markerImage = gameObject.GetComponent<Image>();
    }
    if ((bool) (Object) this.markerImage)
      this.markerImage.enabled = false;
    else
      Debug.LogWarning((object) (this.markerName + "Image for Marker cannot be found in the scene."));
  }

  private void LateUpdate()
  {
    if (!(bool) (Object) this.idScript || !this.idScript.isPlayer)
      return;
    this.Desktop_Input();
    this.Marker_Control();
  }

  private void Marker_Control()
  {
    if (!(bool) (Object) this.markerImage)
      return;
    if (this.isTracking)
    {
      this.markerImage.transform.position = Camera.main.WorldToScreenPoint(this.targetPos);
      if ((double) this.markerImage.transform.position.z < 0.0)
      {
        this.markerImage.enabled = false;
      }
      else
      {
        this.markerImage.enabled = true;
        if ((bool) (Object) this.targetTransform)
          this.markerImage.color = Color.red;
        else
          this.markerImage.color = Color.white;
      }
    }
    else
      this.markerImage.enabled = false;
  }

  private void Desktop_Input() => this.Mouse_Input();

  private void Mouse_Input()
  {
    if (this.idScript.aimButtonDown)
    {
      this.isTracking = true;
      this.Cast_Ray_Sphere(Input.mousePosition, true);
      this.previousMousePos = Input.mousePosition;
    }
    else if (this.idScript.aimButton)
    {
      if (this.gunCamFlag)
      {
        this.adjustAng += (Input.mousePosition - this.previousMousePos) * 0.03f;
        this.previousMousePos = Input.mousePosition;
      }
      else
      {
        if ((double) Mathf.Abs(this.targetAng) >= 5.0)
          return;
        this.gunCamFlag = true;
        this.gunCameraScript.GunCam_On();
      }
    }
    else if (this.idScript.aimButtonUp)
    {
      this.gunCamFlag = false;
      this.gunCameraScript.GunCam_Off();
      this.adjustAng = Vector3.zero;
      this.targetTransform = (Transform) null;
    }
    else
      this.Cast_Ray_Sphere(Input.mousePosition, false);
  }

  private void Cast_Ray_Sphere(Vector3 screenPos, bool isLockOn)
  {
    foreach (RaycastHit raycastHit in Physics.SphereCastAll(Camera.main.ScreenPointToRay(screenPos), this.spherecastRadius, 1000f, this.layerMask))
    {
      Transform transform = raycastHit.collider.transform;
      if ((Object) transform.root != (Object) this.rootTransform && (bool) (Object) raycastHit.transform.GetComponent<Rigidbody>() && transform.root.tag != "Finish")
      {
        this.targetTransform = raycastHit.transform;
        this.targetOffset.y = 0.5f;
        return;
      }
    }
    this.Cast_Ray(screenPos, isLockOn);
  }

  private void Cast_Ray(Vector3 screenPos, bool isLockOn)
  {
    RaycastHit hitInfo;
    if (Physics.Raycast(Camera.main.ScreenPointToRay(screenPos), out hitInfo, 1000f, this.layerMask))
    {
      if ((Object) hitInfo.collider.transform.root != (Object) this.rootTransform)
      {
        this.targetTransform = (Transform) null;
        this.targetPos = hitInfo.point;
      }
      else if (isLockOn)
      {
        this.isTracking = false;
        this.targetTransform = (Transform) null;
      }
      else
      {
        this.targetTransform = (Transform) null;
        screenPos.z = 500f;
        this.targetPos = Camera.main.ScreenToWorldPoint(screenPos);
      }
    }
    else
    {
      this.targetTransform = (Transform) null;
      screenPos.z = 500f;
      this.targetPos = Camera.main.ScreenToWorldPoint(screenPos);
    }
  }

  private void FixedUpdate()
  {
    if (this.isTracking)
    {
      if ((bool) (Object) this.targetTransform)
        this.targetPos = this.targetTransform.position + this.targetTransform.forward * this.targetOffset.z + this.targetTransform.right * this.targetOffset.x + this.targetTransform.up * this.targetOffset.y;
      this.localTargetPos = this.thisTransform.InverseTransformPoint(this.targetPos);
      this.targetAng = Vector2.Angle(Vector2.up, new Vector2(this.localTargetPos.x, this.localTargetPos.z)) * Mathf.Sign(this.localTargetPos.x);
      this.targetAng += this.adjustAng.x;
    }
    else
      this.targetAng = Mathf.DeltaAngle(this.currentAng, 0.0f);
    if ((double) Mathf.Abs(this.targetAng) <= 0.0099999997764825821)
      return;
    this.speedRate = Mathf.MoveTowardsAngle(this.speedRate, Mathf.Lerp(0.0f, 1f, Mathf.Abs(this.targetAng) / (this.rotationSpeed * Time.fixedDeltaTime + this.bufferAngle)) * Mathf.Sign(this.targetAng), Time.fixedDeltaTime / this.acceleration_Time);
    this.currentAng += this.rotationSpeed * this.speedRate * Time.fixedDeltaTime;
    this.thisTransform.localRotation = Quaternion.Euler(new Vector3(0.0f, this.currentAng, 0.0f));
  }

  private void Destroy()
  {
    this.thisTransform.parent = this.thisTransform.root;
    Rigidbody rigidbody = this.GetComponent<Rigidbody>();
    if ((Object) rigidbody == (Object) null)
    {
      rigidbody = this.gameObject.AddComponent<Rigidbody>();
      rigidbody.mass = 100f;
    }
    Vector3 vector3 = new Vector3(Random.Range(0.0f, 1f), 0.0f, Random.Range(0.0f, 1f));
    rigidbody.AddForceAtPosition(this.thisTransform.up * 500f, this.thisTransform.position + vector3, ForceMode.Impulse);
    if (this.idScript.isPlayer)
    {
      if ((bool) (Object) this.markerImage)
        this.markerImage.enabled = false;
      this.gunCameraScript.GunCam_Off();
    }
    Object.Destroy((Object) this);
  }

  private void Get_ID_Script(ID_Control_CS tempScript)
  {
    this.idScript = tempScript;
    if (!this.idScript.isPlayer)
      this.isTracking = false;
    this.idScript.turretScript = this;
  }

  private void Pause(bool isPaused) => this.enabled = !isPaused;

  public void Switch_Player(bool isPlayer)
  {
    this.isTracking = true;
    if (!(bool) (Object) this.markerImage)
      return;
    this.markerImage.enabled = false;
  }
}
