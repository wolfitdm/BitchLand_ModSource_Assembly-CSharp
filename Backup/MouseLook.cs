// Decompiled with JetBrains decompiler
// Type: MouseLook
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour
{
  public MouseLook.RotationAxes axes;
  public float sensitivityX = 15f;
  public float sensitivityY = 15f;
  public float minimumX = -360f;
  public float maximumX = 360f;
  public float minimumY = -60f;
  public float maximumY = 60f;
  private float rotationY;

  private void Update()
  {
    if (this.axes == MouseLook.RotationAxes.MouseXAndY)
    {
      float y = this.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * this.sensitivityX;
      this.rotationY += Input.GetAxis("Mouse Y") * this.sensitivityY;
      this.rotationY = Mathf.Clamp(this.rotationY, this.minimumY, this.maximumY);
      this.transform.localEulerAngles = new Vector3(-this.rotationY, y, 0.0f);
    }
    else if (this.axes == MouseLook.RotationAxes.MouseX)
    {
      this.transform.Rotate(0.0f, Input.GetAxis("Mouse X") * this.sensitivityX, 0.0f);
    }
    else
    {
      this.rotationY += Input.GetAxis("Mouse Y") * this.sensitivityY;
      this.rotationY = Mathf.Clamp(this.rotationY, this.minimumY, this.maximumY);
      this.transform.localEulerAngles = new Vector3(-this.rotationY, this.transform.localEulerAngles.y, 0.0f);
    }
  }

  private void Start()
  {
    if (!(bool) (Object) this.GetComponent<Rigidbody>())
      return;
    this.GetComponent<Rigidbody>().freezeRotation = true;
  }

  public enum RotationAxes
  {
    MouseXAndY,
    MouseX,
    MouseY,
  }
}
