// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Cameras.FreeLookCam
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

#nullable disable
namespace UnityStandardAssets.Cameras;

public class FreeLookCam : PivotBasedCameraRig
{
  [SerializeField]
  private float m_MoveSpeed = 1f;
  [Range(0.0f, 10f)]
  [SerializeField]
  private float m_TurnSpeed = 1.5f;
  [SerializeField]
  private float m_TurnSmoothing;
  [SerializeField]
  private float m_TiltMax = 75f;
  [SerializeField]
  private float m_TiltMin = 45f;
  [SerializeField]
  private bool m_LockCursor;
  [SerializeField]
  private bool m_VerticalAutoReturn;
  private float m_LookAngle;
  private float m_TiltAngle;
  private Vector3 m_PivotEulers;
  private Quaternion m_PivotTargetRot;
  private Quaternion m_TransformTargetRot;

  protected override void Awake()
  {
    base.Awake();
    Cursor.lockState = this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None;
    Cursor.visible = !this.m_LockCursor;
    this.m_PivotEulers = this.m_Pivot.rotation.eulerAngles;
    this.m_PivotTargetRot = this.m_Pivot.transform.localRotation;
    this.m_TransformTargetRot = this.transform.localRotation;
  }

  protected void Update()
  {
    this.HandleRotationMovement();
    if (!this.m_LockCursor || !Input.GetMouseButtonUp(UI_Settings.LeftMouseButton))
      return;
    Cursor.lockState = this.m_LockCursor ? CursorLockMode.Locked : CursorLockMode.None;
    Cursor.visible = !this.m_LockCursor;
  }

  private void OnDisable()
  {
  }

  protected override void FollowTarget(float deltaTime)
  {
    if ((Object) this.m_Target == (Object) null)
      return;
    this.transform.position = Vector3.Lerp(this.transform.position, this.m_Target.position, deltaTime * this.m_MoveSpeed);
  }

  private void HandleRotationMovement()
  {
    if ((double) Time.timeScale < 1.4012984643248171E-45)
      return;
    float num = CrossPlatformInputManager.GetAxis("Mouse X");
    float t = CrossPlatformInputManager.GetAxis("Mouse Y");
    if (Main.Instance.Player.UserControl.FirstPerson)
    {
      if (UI_Settings.Inverted_X_1st)
        num = -num;
      if (UI_Settings.Inverted_Y_1st)
        t = -t;
    }
    else
    {
      if (UI_Settings.Inverted_X_3rd)
        num = -num;
      if (UI_Settings.Inverted_Y_3rd)
        t = -t;
    }
    this.m_LookAngle += num * this.m_TurnSpeed;
    this.m_TransformTargetRot = Quaternion.Euler(0.0f, this.m_LookAngle, 0.0f);
    if (this.m_VerticalAutoReturn)
    {
      this.m_TiltAngle = (double) t > 0.0 ? Mathf.Lerp(0.0f, -this.m_TiltMin, t) : Mathf.Lerp(0.0f, this.m_TiltMax, -t);
    }
    else
    {
      this.m_TiltAngle -= t * this.m_TurnSpeed;
      this.m_TiltAngle = Mathf.Clamp(this.m_TiltAngle, -this.m_TiltMin, this.m_TiltMax);
    }
    this.m_PivotTargetRot = Quaternion.Euler(this.m_TiltAngle, this.m_PivotEulers.y, this.m_PivotEulers.z);
    if ((double) this.m_TurnSmoothing > 0.0)
    {
      this.m_Pivot.localRotation = Quaternion.Slerp(this.m_Pivot.localRotation, this.m_PivotTargetRot, this.m_TurnSmoothing * Time.deltaTime);
      this.transform.localRotation = Quaternion.Slerp(this.transform.localRotation, this.m_TransformTargetRot, this.m_TurnSmoothing * Time.deltaTime);
    }
    else
    {
      this.m_Pivot.localRotation = this.m_PivotTargetRot;
      this.transform.localRotation = this.m_TransformTargetRot;
    }
  }
}
