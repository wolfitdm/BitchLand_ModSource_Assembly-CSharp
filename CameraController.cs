// Decompiled with JetBrains decompiler
// Type: CameraController
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class CameraController : MonoBehaviour
{
  public Transform lookAt;
  public Transform camTransform;
  public Transform firePoint;
  public Transform canon;
  public Transform canonGun;
  public Camera cam;
  public bool RegularTank;
  public float currentX;
  public float currentY;
  public float minY = -40f;
  public float maxY = 35f;
  public float minX = -15f;
  public float maxX = 40f;
  public Quaternion startRotation;
  public bool ThisIsTurret;

  private void Start()
  {
    this.camTransform = this.transform;
    if ((Object) this.firePoint != (Object) null)
      this.firePoint.transform.position = this.cam.ScreenToWorldPoint(new Vector3((float) (Screen.width / 2), (float) (Screen.height / 2), this.cam.nearClipPlane + 12f));
    this.startRotation = new Quaternion(0.0f, 0.0f, 0.0f, 1f);
  }

  public void OnInteract()
  {
    if (!((Object) this.canonGun != (Object) null))
      return;
    this.canonGun.localEulerAngles = Vector3.zero;
  }

  private void Update()
  {
    if ((Object) this.canon != (Object) null)
    {
      this.canon.forward = this.cam.transform.forward;
      this.canon.rotation *= this.startRotation;
    }
    if (this.ThisIsTurret)
    {
      if (UI_Settings.Inverted_X_tur)
        this.currentY -= Input.GetAxis("Mouse X");
      else
        this.currentY += Input.GetAxis("Mouse X");
      if (UI_Settings.Inverted_Y_tur)
        this.currentX -= Input.GetAxis("Mouse Y");
      else
        this.currentX += Input.GetAxis("Mouse Y");
    }
    else
    {
      if (UI_Settings.Inverted_X_car)
        this.currentY -= Input.GetAxis("Mouse X");
      else
        this.currentY += Input.GetAxis("Mouse X");
      if (UI_Settings.Inverted_Y_car)
        this.currentX -= Input.GetAxis("Mouse Y");
      else
        this.currentX += Input.GetAxis("Mouse Y");
    }
    this.currentY = Mathf.Clamp(this.currentY, this.minY, this.maxY);
    this.currentX = Mathf.Clamp(this.currentX, this.minX, this.maxX);
  }

  private void LateUpdate()
  {
    this.lookAt.localRotation = Quaternion.Euler(this.currentX, this.currentY, 0.0f);
    if (!this.RegularTank)
      return;
    this.canonGun.localEulerAngles = new Vector3(this.canon.localEulerAngles.x, 0.0f, 0.0f);
    this.canon.localEulerAngles = new Vector3(0.0f, this.canon.localEulerAngles.y, 0.0f);
  }
}
