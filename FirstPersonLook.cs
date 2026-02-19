// Decompiled with JetBrains decompiler
// Type: FirstPersonLook
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class FirstPersonLook : MonoBehaviour
{
  [SerializeField]
  private Transform character;
  public float sensitivity = 2f;
  public float smoothing = 1.5f;
  private Vector2 velocity;
  private Vector2 frameVelocity;

  private void Reset()
  {
    this.character = this.GetComponentInParent<FirstPersonMovement>().transform;
  }

  private void Start() => Cursor.lockState = CursorLockMode.Locked;

  private void Update()
  {
    this.frameVelocity = Vector2.Lerp(this.frameVelocity, Vector2.Scale(new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")), Vector2.one * this.sensitivity), 1f / this.smoothing);
    this.velocity += this.frameVelocity;
    this.velocity.y = Mathf.Clamp(this.velocity.y, -90f, 90f);
    this.transform.localRotation = Quaternion.AngleAxis(-this.velocity.y, Vector3.right);
    this.character.localRotation = Quaternion.AngleAxis(this.velocity.x, Vector3.up);
  }
}
