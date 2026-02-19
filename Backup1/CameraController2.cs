// Decompiled with JetBrains decompiler
// Type: CameraController2
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class CameraController2 : MonoBehaviour
{
  [SerializeField]
  private float speed;
  [SerializeField]
  private float xSensitivity;
  [SerializeField]
  private float ySensitivity;

  private void Update()
  {
    float x = Input.GetAxis("Horizontal") * this.speed * Time.deltaTime;
    float z = Input.GetAxis("Vertical") * this.speed * Time.deltaTime;
    float y1 = 0.0f;
    if (Input.GetKey(KeyCode.Space))
      y1 += 1f * this.speed * Time.deltaTime;
    if (Input.GetKey(KeyCode.LeftShift))
      y1 -= 1f * this.speed * Time.deltaTime;
    this.transform.Translate(new Vector3(x, y1, z));
    float y2 = Input.GetAxis("Mouse X") * this.xSensitivity;
    this.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * this.ySensitivity, y2, 0.0f));
    Quaternion rotation = this.transform.rotation;
    this.transform.rotation = Quaternion.Euler(new Vector3(rotation.eulerAngles.x, rotation.eulerAngles.y, 0.0f));
  }
}
