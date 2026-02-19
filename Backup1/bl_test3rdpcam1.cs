// Decompiled with JetBrains decompiler
// Type: bl_test3rdpcam1
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class bl_test3rdpcam1 : MonoBehaviour
{
  public float moveSpeed;
  public float shiftAdditionalSpeed;
  public float mouseSensitivity;
  public bool invertMouse;
  public bool autoLockCursor;
  private Camera cam;

  private void Awake()
  {
    this.cam = this.gameObject.GetComponent<Camera>();
    this.gameObject.name = "SpectatorCamera";
    Cursor.lockState = this.autoLockCursor ? CursorLockMode.Locked : CursorLockMode.None;
  }

  private void Update()
  {
    float num = this.moveSpeed + Input.GetAxis("Fire3") * this.shiftAdditionalSpeed;
    this.gameObject.transform.Translate(Vector3.forward * num * Input.GetAxis("Vertical"));
    this.gameObject.transform.Translate(Vector3.right * num * Input.GetAxis("Horizontal"));
    this.gameObject.transform.Translate(Vector3.up * num * (Input.GetAxis("Jump") + Input.GetAxis("Fire1") * -1f));
    this.gameObject.transform.Rotate((float) ((double) Input.GetAxis("Mouse Y") * (double) this.mouseSensitivity * (this.invertMouse ? 1.0 : -1.0)), (float) ((double) Input.GetAxis("Mouse X") * (double) this.mouseSensitivity * (this.invertMouse ? -1.0 : 1.0)), 0.0f);
    this.gameObject.transform.localEulerAngles = new Vector3(this.gameObject.transform.localEulerAngles.x, this.gameObject.transform.localEulerAngles.y, 0.0f);
  }
}
