// Decompiled with JetBrains decompiler
// Type: MouseRotator
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class MouseRotator : MonoBehaviour
{
  public Vector2 rotationRange = (Vector2) new Vector3(70f, 70f);
  public float rotationSpeed = 10f;
  public float dampingTime = 0.2f;
  public bool autoZeroVerticalOnMobile = true;
  public bool autoZeroHorizontalOnMobile;
  public bool relative = true;
  private Vector3 targetAngles;
  private Vector3 followAngles;
  private Vector3 followVelocity;
  private Quaternion originalRotation;
  public Transform AlsoRotate;
  public Transform AlsoRotate_lookat;

  private void Start() => this.originalRotation = this.transform.localRotation;

  private void Update()
  {
    this.transform.localRotation = this.originalRotation;
    if (this.relative)
    {
      float num1 = Input.GetAxis("Mouse X") * UI_Settings.CurrentMouseSensitivity;
      float num2 = Input.GetAxis("Mouse Y") * UI_Settings.CurrentMouseSensitivity;
      if ((double) this.targetAngles.y > 180.0)
      {
        this.targetAngles.y -= 360f;
        this.followAngles.y -= 360f;
      }
      if ((double) this.targetAngles.x > 180.0)
      {
        this.targetAngles.x -= 360f;
        this.followAngles.x -= 360f;
      }
      if ((double) this.targetAngles.y < -180.0)
      {
        this.targetAngles.y += 360f;
        this.followAngles.y += 360f;
      }
      if ((double) this.targetAngles.x < -180.0)
      {
        this.targetAngles.x += 360f;
        this.followAngles.x += 360f;
      }
      this.targetAngles.y += num1 * this.rotationSpeed;
      this.targetAngles.x += num2 * this.rotationSpeed;
      this.targetAngles.y = Mathf.Clamp(this.targetAngles.y, (float) (-(double) this.rotationRange.y * 0.5), this.rotationRange.y * 0.5f);
      this.targetAngles.x = Mathf.Clamp(this.targetAngles.x, (float) (-(double) this.rotationRange.x * 0.5), this.rotationRange.x * 0.5f);
    }
    else
    {
      float x = Input.mousePosition.x;
      float y = Input.mousePosition.y;
      this.targetAngles.y = Mathf.Lerp((float) (-(double) this.rotationRange.y * 0.5), this.rotationRange.y * 0.5f, x / (float) Screen.width);
      this.targetAngles.x = Mathf.Lerp((float) (-(double) this.rotationRange.x * 0.5), this.rotationRange.x * 0.5f, y / (float) Screen.height);
    }
    this.followAngles = Vector3.SmoothDamp(this.followAngles, this.targetAngles, ref this.followVelocity, this.dampingTime);
    this.transform.localRotation = this.originalRotation * Quaternion.Euler(-this.followAngles.x, this.followAngles.y, 0.0f);
  }
}
