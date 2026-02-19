// Decompiled with JetBrains decompiler
// Type: FreeCamRotation
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class FreeCamRotation : MonoBehaviour
{
  public static bool NoDeltaTime;
  public Transform Rotationer;
  private float mX;
  private float mY;
  public float _moveDelta;

  public void Start()
  {
    if ((bool) (Object) this.Rotationer)
      return;
    this.Rotationer = this.transform;
  }

  public void LateUpdate()
  {
    if (!Main.Instance.Player.gameObject.activeSelf)
    {
      bl_PhotoMode.Active = false;
    }
    else
    {
      float num1 = Input.GetAxis("Vertical");
      float axis1 = Input.GetAxis("Horizontal");
      float axis2 = Input.GetAxis("Mouse ScrollWheel");
      float num2 = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ? 0.5f : 0.1f;
      if (Input.GetMouseButton(1))
      {
        this.mX += Input.GetAxis("Mouse X") * 5f;
        this.mY += Input.GetAxis("Mouse Y") * 5f;
        this.Rotationer.localRotation = Quaternion.AngleAxis(this.mX, Vector3.up);
        this.Rotationer.localRotation *= Quaternion.AngleAxis(this.mY, Vector3.left);
      }
      if (FreeCamRotation.NoDeltaTime)
      {
        this._moveDelta = 0.01f;
        num1 = Input.GetKey(KeyCode.W) ? 1f : (Input.GetKey(KeyCode.S) ? -1f : 0.0f);
      }
      else
      {
        this._moveDelta = Time.deltaTime;
        if ((double) this._moveDelta == 0.0)
          this._moveDelta = 0.01f;
      }
      this.Rotationer.position += (double) num1 == 0.0 ? this.Rotationer.forward * axis2 * this._moveDelta * 600f : this.Rotationer.forward * num2 * num1;
      this.Rotationer.position += this.Rotationer.right * num2 * axis1;
      if ((double) Vector3.Distance(Main.Instance.Player.Head.position, this.Rotationer.position) <= 5.0)
        return;
      Vector3 normalized = (this.Rotationer.position - Main.Instance.Player.Head.position).normalized;
      this.Rotationer.position = Main.Instance.Player.Head.position + normalized * 5f;
    }
  }
}
