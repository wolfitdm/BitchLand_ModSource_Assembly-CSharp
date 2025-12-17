// Decompiled with JetBrains decompiler
// Type: DigitalRuby.RainMaker.DemoScript
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
namespace DigitalRuby.RainMaker;

public class DemoScript : MonoBehaviour
{
  public RainScript RainScript;
  public Toggle MouseLookToggle;
  public Toggle FlashlightToggle;
  public Slider RainSlider;
  public Light Flashlight;
  public GameObject Sun;
  private DemoScript.RotationAxes axes;
  private float sensitivityX = 15f;
  private float sensitivityY = 15f;
  private float minimumX = -360f;
  private float maximumX = 360f;
  private float minimumY = -60f;
  private float maximumY = 60f;
  private float rotationX;
  private float rotationY;
  private Quaternion originalRotation;

  private void UpdateRain()
  {
    if (!((Object) this.RainScript != (Object) null))
      return;
    if (Input.GetKeyDown(KeyCode.Alpha1))
      this.RainScript.RainIntensity = 0.0f;
    else if (Input.GetKeyDown(KeyCode.Alpha2))
      this.RainScript.RainIntensity = 0.2f;
    else if (Input.GetKeyDown(KeyCode.Alpha3))
    {
      this.RainScript.RainIntensity = 0.5f;
    }
    else
    {
      if (!Input.GetKeyDown(KeyCode.Alpha4))
        return;
      this.RainScript.RainIntensity = 0.8f;
    }
  }

  private void UpdateMovement()
  {
    float num = 5f * Time.deltaTime;
    if (Input.GetKey(KeyCode.W))
      Camera.main.transform.Translate(0.0f, 0.0f, num);
    else if (Input.GetKey(KeyCode.S))
      Camera.main.transform.Translate(0.0f, 0.0f, -num);
    if (Input.GetKey(KeyCode.A))
      Camera.main.transform.Translate(-num, 0.0f, 0.0f);
    else if (Input.GetKey(KeyCode.D))
      Camera.main.transform.Translate(num, 0.0f, 0.0f);
    if (!Input.GetKeyDown(KeyCode.F))
      return;
    this.FlashlightToggle.isOn = !this.FlashlightToggle.isOn;
  }

  private void UpdateMouseLook()
  {
    if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.M))
      this.MouseLookToggle.isOn = !this.MouseLookToggle.isOn;
    if (!this.MouseLookToggle.isOn)
      return;
    if (this.axes == DemoScript.RotationAxes.MouseXAndY)
    {
      this.rotationX += Input.GetAxis("Mouse X") * this.sensitivityX;
      this.rotationY += Input.GetAxis("Mouse Y") * this.sensitivityY;
      this.rotationX = DemoScript.ClampAngle(this.rotationX, this.minimumX, this.maximumX);
      this.rotationY = DemoScript.ClampAngle(this.rotationY, this.minimumY, this.maximumY);
      this.transform.localRotation = this.originalRotation * Quaternion.AngleAxis(this.rotationX, Vector3.up) * Quaternion.AngleAxis(this.rotationY, -Vector3.right);
    }
    else if (this.axes == DemoScript.RotationAxes.MouseX)
    {
      this.rotationX += Input.GetAxis("Mouse X") * this.sensitivityX;
      this.rotationX = DemoScript.ClampAngle(this.rotationX, this.minimumX, this.maximumX);
      this.transform.localRotation = this.originalRotation * Quaternion.AngleAxis(this.rotationX, Vector3.up);
    }
    else
    {
      this.rotationY += Input.GetAxis("Mouse Y") * this.sensitivityY;
      this.rotationY = DemoScript.ClampAngle(this.rotationY, this.minimumY, this.maximumY);
      this.transform.localRotation = this.originalRotation * Quaternion.AngleAxis(-this.rotationY, Vector3.right);
    }
  }

  public void RainSliderChanged(float val) => this.RainScript.RainIntensity = val;

  public void MouseLookChanged(bool val) => this.MouseLookToggle.isOn = val;

  public void FlashlightChanged(bool val)
  {
    this.FlashlightToggle.isOn = val;
    this.Flashlight.enabled = val;
  }

  public void DawnDuskSliderChanged(float val)
  {
    this.Sun.transform.rotation = Quaternion.Euler(val, 0.0f, 0.0f);
  }

  public void FollowCameraChanged(bool val) => this.RainScript.FollowCamera = val;

  private void Start()
  {
    this.originalRotation = this.transform.localRotation;
    this.RainScript.RainIntensity = this.RainSlider.value = 0.5f;
    this.RainScript.EnableWind = true;
  }

  private void Update()
  {
    this.UpdateRain();
    this.UpdateMovement();
    this.UpdateMouseLook();
  }

  public static float ClampAngle(float angle, float min, float max)
  {
    if ((double) angle < -360.0)
      angle += 360f;
    if ((double) angle > 360.0)
      angle -= 360f;
    return Mathf.Clamp(angle, min, max);
  }

  private enum RotationAxes
  {
    MouseXAndY,
    MouseX,
    MouseY,
  }
}
