// Decompiled with JetBrains decompiler
// Type: FreeFly
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[RequireComponent(typeof (Camera))]
public class FreeFly : MonoBehaviour
{
  public float initialSpeed = 10f;
  public float increaseSpeed = 1.25f;
  public bool allowMovement = true;
  public bool allowRotation = true;
  public KeyCode forwardButton = KeyCode.W;
  public KeyCode backwardButton = KeyCode.S;
  public KeyCode rightButton = KeyCode.D;
  public KeyCode leftButton = KeyCode.A;
  public float cursorSensitivity = 0.025f;
  public bool cursorToggleAllowed = true;
  public KeyCode cursorToggleButton = KeyCode.Escape;
  private float currentSpeed;
  private bool moving;
  private bool togglePressed;

  private void OnEnable()
  {
    if (!this.cursorToggleAllowed)
      return;
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
  }

  private void Update()
  {
    if (this.allowMovement)
    {
      bool moving = this.moving;
      Vector3 zero = Vector3.zero;
      if (this.moving)
        this.currentSpeed += this.increaseSpeed * Time.deltaTime;
      this.moving = false;
      this.CheckMove(this.forwardButton, ref zero, this.transform.forward);
      this.CheckMove(this.backwardButton, ref zero, -this.transform.forward);
      this.CheckMove(this.rightButton, ref zero, this.transform.right);
      this.CheckMove(this.leftButton, ref zero, -this.transform.right);
      if (this.moving)
      {
        if (this.moving != moving)
          this.currentSpeed = this.initialSpeed;
        this.transform.position += zero * this.currentSpeed * Time.deltaTime;
      }
      else
        this.currentSpeed = 0.0f;
    }
    if (this.allowRotation)
    {
      Vector3 eulerAngles = this.transform.eulerAngles;
      eulerAngles.x += (float) (-(double) Input.GetAxis("Mouse Y") * 359.0) * this.cursorSensitivity;
      eulerAngles.y += Input.GetAxis("Mouse X") * 359f * this.cursorSensitivity;
      this.transform.eulerAngles = eulerAngles;
    }
    if (this.cursorToggleAllowed)
    {
      if (Input.GetKey(this.cursorToggleButton))
      {
        if (this.togglePressed)
          return;
        this.togglePressed = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = !Cursor.visible;
      }
      else
        this.togglePressed = false;
    }
    else
    {
      this.togglePressed = false;
      Cursor.visible = false;
    }
  }

  private void CheckMove(KeyCode keyCode, ref Vector3 deltaPosition, Vector3 directionVector)
  {
    if (!Input.GetKey(keyCode))
      return;
    this.moving = true;
    deltaPosition += directionVector;
  }
}
