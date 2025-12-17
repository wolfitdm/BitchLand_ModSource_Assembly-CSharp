// Decompiled with JetBrains decompiler
// Type: MouseOrbit
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class MouseOrbit : MonoBehaviour
{
  public Transform target;
  private float distance = 15f;
  private float xSpeed = 4f;
  private float ySpeed = 1f;
  private float x;
  private float y = 2f;

  private void Start()
  {
    Vector3 eulerAngles = this.transform.eulerAngles;
    this.x = eulerAngles.y;
    this.y = eulerAngles.x;
    if (!(bool) (Object) this.GetComponent<Rigidbody>())
      return;
    this.GetComponent<Rigidbody>().freezeRotation = true;
  }

  private void LateUpdate()
  {
    this.distance += Input.GetAxis("Mouse ScrollWheel") * 5f;
    if (Input.GetKey(KeyCode.LeftAlt))
    {
      if (Input.GetMouseButton(1))
        this.distance += Input.GetAxis("Mouse Y") * 0.5f;
      if (Input.GetMouseButton(0))
      {
        this.x += (float) ((double) Input.GetAxis("Mouse X") * (double) this.xSpeed * 3.0);
        this.y -= (float) ((double) Input.GetAxis("Mouse Y") * (double) this.ySpeed * 8.0);
        this.y = this.ClampAngle(this.y);
        this.x = this.ClampAngle(this.x);
        this.transform.rotation = Quaternion.Euler(this.y, this.x, 0.0f);
      }
      if (Input.GetMouseButton(2))
      {
        float axis1 = Input.GetAxis("Mouse X");
        float axis2 = Input.GetAxis("Mouse Y");
        this.target.transform.position += this.transform.right * (float) (-(double) axis1 * 0.20000000298023224);
        this.target.transform.position += this.transform.up * (float) (-(double) axis2 * 0.20000000298023224);
      }
    }
    this.transform.position = this.target.transform.position - this.transform.forward * this.distance;
  }

  private float ClampAngle(float angle)
  {
    if ((double) angle < -360.0)
      angle += 360f;
    if ((double) angle > 360.0)
      angle -= 360f;
    return angle;
  }

  private void OnGUI()
  {
    GUI.Label(new Rect(10f, 25f, 1000f, 20f), "ALT+LMB to orbit,   ALT+RMB to zoom,   ALT+MMB to pan");
  }
}
