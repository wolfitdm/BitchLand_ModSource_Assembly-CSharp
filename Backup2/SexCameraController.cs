// Decompiled with JetBrains decompiler
// Type: SexCameraController
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SexCameraController : MonoBehaviour
{
  public Transform focalPoint;
  public float cameraDistance = 1.5f;
  public float MaxZoom = 5f;
  public float MinZoom = 0.2f;
  public float MoveCameraSpeed = 0.05f;
  public float RotCameraSpeed = 1.5f;
  public float zoomSpeed = 2f;
  public bool _FirstPerson;
  private Vector3 lastMousePosition;
  public bool isPanning;
  private Vector3 panOffset;
  public bool NOTGetMouseInput;

  public bool FirstPerson
  {
    get => this._FirstPerson;
    set
    {
      this._FirstPerson = value;
      if (value)
      {
        this.focalPoint = Main.Instance.Player.EyesSpot;
        this.cameraDistance = 0.0f;
        this.MinZoom = 0.0f;
        this.MaxZoom = 0.0f;
      }
      else
      {
        this.focalPoint = Main.Instance.SexScene.FocalPoint;
        this.cameraDistance = 1.5f;
        this.MinZoom = 0.2f;
        this.MaxZoom = 5f;
      }
    }
  }

  private void Start()
  {
    if (!((Object) this.focalPoint == (Object) null))
      return;
    Debug.LogError((object) "Focal point is not set in CameraController script!");
  }

  public void OnOpen() => this.isPanning = false;

  private void Update()
  {
    if (Input.GetMouseButton(UI_Settings.RightMouseButton))
    {
      float num1 = 0.0f;
      float num2 = 0.0f;
      if (!this.NOTGetMouseInput)
      {
        num1 = Input.GetAxis("Mouse X");
        num2 = Input.GetAxis("Mouse Y");
      }
      this.transform.RotateAround(this.focalPoint.position, Vector3.up, num1 * this.RotCameraSpeed);
      this.transform.RotateAround(this.focalPoint.position, this.transform.right, -num2 * this.RotCameraSpeed);
    }
    if (Input.GetMouseButtonDown(UI_Settings.LeftMouseButton) && !this.NOTGetMouseInput)
    {
      this.isPanning = true;
      this.panOffset = this.focalPoint.position - Camera.main.ScreenToWorldPoint(Input.mousePosition with
      {
        z = this.cameraDistance
      });
    }
    if (Input.GetMouseButtonUp(UI_Settings.LeftMouseButton))
      this.isPanning = false;
    if (this.isPanning)
      this.focalPoint.position = Vector3.Lerp(this.focalPoint.position, Camera.main.ScreenToWorldPoint(Input.mousePosition with
      {
        z = this.cameraDistance
      }) + this.panOffset, Time.deltaTime * this.MoveCameraSpeed);
    this.cameraDistance -= Input.GetAxis("Mouse ScrollWheel") * this.zoomSpeed;
    this.cameraDistance = Mathf.Clamp(this.cameraDistance, this.MinZoom, this.MaxZoom);
    this.transform.position = this.focalPoint.position - this.transform.forward * this.cameraDistance;
    this.lastMousePosition = Input.mousePosition;
  }
}
