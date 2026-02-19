// Decompiled with JetBrains decompiler
// Type: CharController_Motor
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class CharController_Motor : MonoBehaviour
{
  public float speed = 10f;
  public float sensitivity = 30f;
  public float WaterHeight = 15.5f;
  private CharacterController character;
  public GameObject cam;
  private float moveFB;
  private float moveLR;
  private float rotX;
  private float rotY;
  public bool webGLRightClickRotation = true;
  private float gravity = -9.8f;

  private void Start()
  {
    this.character = this.GetComponent<CharacterController>();
    if (!Application.isEditor)
      return;
    this.webGLRightClickRotation = false;
    this.sensitivity *= 1.5f;
  }

  private void CheckForWaterHeight()
  {
    if ((double) this.transform.position.y < (double) this.WaterHeight)
      this.gravity = 0.0f;
    else
      this.gravity = -9.8f;
  }

  private void Update()
  {
    this.moveFB = Input.GetAxis("Horizontal") * this.speed;
    this.moveLR = Input.GetAxis("Vertical") * this.speed;
    this.rotX = Input.GetAxis("Mouse X") * this.sensitivity;
    this.rotY = Input.GetAxis("Mouse Y") * this.sensitivity;
    this.CheckForWaterHeight();
    Vector3 vector3 = new Vector3(this.moveFB, this.gravity, this.moveLR);
    if (this.webGLRightClickRotation)
    {
      if (Input.GetKey(KeyCode.Mouse0))
        this.CameraRotation(this.cam, this.rotX, this.rotY);
    }
    else if (!this.webGLRightClickRotation)
      this.CameraRotation(this.cam, this.rotX, this.rotY);
    int num = (int) this.character.Move(this.transform.rotation * vector3 * Time.deltaTime);
  }

  private void CameraRotation(GameObject cam, float rotX, float rotY)
  {
    this.transform.Rotate(0.0f, rotX * Time.deltaTime, 0.0f);
    cam.transform.Rotate(-rotY * Time.deltaTime, 0.0f, 0.0f);
  }
}
