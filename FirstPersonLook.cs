// Decompiled with JetBrains decompiler
// Type: FirstPersonLook
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
