// Decompiled with JetBrains decompiler
// Type: TTDemoScripts.SimpleSmoothMouseLook
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace TTDemoScripts;

public class SimpleSmoothMouseLook : MonoBehaviour
{
  private Vector2 _mouseAbsolute;
  private Vector2 _smoothMouse;
  public Vector2 clampInDegrees = new Vector2(360f, 180f);
  public bool lockCursor;
  public Vector2 sensitivity = new Vector2(2f, 2f);
  public Vector2 smoothing = new Vector2(3f, 3f);
  public Vector2 targetDirection;

  private void Start() => this.targetDirection = (Vector2) this.transform.localRotation.eulerAngles;

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
      this.lockCursor = !this.lockCursor;
    Cursor.lockState = this.lockCursor ? CursorLockMode.Locked : CursorLockMode.None;
    Cursor.visible = !this.lockCursor;
    Quaternion quaternion = Quaternion.Euler((Vector3) this.targetDirection);
    Vector2 a = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
    a = Vector2.Scale(a, new Vector2(this.sensitivity.x * this.smoothing.x, this.sensitivity.y * this.smoothing.y));
    this._smoothMouse.x = Mathf.Lerp(this._smoothMouse.x, a.x, 1f / this.smoothing.x);
    this._smoothMouse.y = Mathf.Lerp(this._smoothMouse.y, a.y, 1f / this.smoothing.y);
    this._mouseAbsolute += this._smoothMouse;
    if ((double) this.clampInDegrees.x < 360.0)
      this._mouseAbsolute.x = Mathf.Clamp(this._mouseAbsolute.x, (float) (-(double) this.clampInDegrees.x * 0.5), this.clampInDegrees.x * 0.5f);
    this.transform.localRotation = Quaternion.AngleAxis(-this._mouseAbsolute.y, quaternion * Vector3.right);
    if ((double) this.clampInDegrees.y < 360.0)
      this._mouseAbsolute.y = Mathf.Clamp(this._mouseAbsolute.y, (float) (-(double) this.clampInDegrees.y * 0.5), this.clampInDegrees.y * 0.5f);
    this.transform.localRotation *= quaternion;
    this.transform.localRotation *= Quaternion.AngleAxis(this._mouseAbsolute.x, this.transform.InverseTransformDirection(Vector3.up));
  }
}
