// Decompiled with JetBrains decompiler
// Type: GunView
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class GunView : MonoBehaviour
{
  private Vector3 baseScale = new Vector3(0.7f, 0.7f, 0.7f);
  private bool isPhone;
  private bool isFirst = true;
  private float zRot;
  private float yRot;
  private Vector3 startPos;

  private void OnEnable()
  {
    this.transform.localScale = this.baseScale;
    if (SystemInfo.deviceType == DeviceType.Handheld)
      this.isPhone = true;
    this.isFirst = true;
  }

  private void Update()
  {
    if (this.isPhone)
    {
      if (Input.touchCount > 0)
      {
        if (this.isFirst)
        {
          this.isFirst = false;
          this.startPos = (Vector3) Input.GetTouch(0).position;
          return;
        }
        this.zRot += (float) (((double) Input.GetTouch(0).position.y - (double) this.startPos.y) * 0.090000003576278687);
        this.zRot = Mathf.Clamp(this.zRot, -55f, 55f);
        this.yRot += (float) (((double) Input.GetTouch(0).position.x - (double) this.startPos.x) * 0.25);
        this.startPos = (Vector3) Input.GetTouch(0).position;
        this.ScaleUp();
      }
      else
      {
        this.isFirst = true;
        this.zRot = Mathf.Lerp(this.zRot, 0.0f, 0.08f);
        this.yRot = Mathf.Lerp(this.yRot, 0.0f, 0.08f);
        this.ScaleDown();
      }
      this.transform.eulerAngles = new Vector3(0.0f, 90f + this.yRot, this.zRot);
    }
    else
    {
      if (Input.GetMouseButton(0))
      {
        if (this.isFirst)
        {
          this.isFirst = false;
          this.startPos = Input.mousePosition;
          return;
        }
        this.zRot += (float) (((double) Input.mousePosition.y - (double) this.startPos.y) * 0.10000000149011612);
        this.zRot = Mathf.Clamp(this.zRot, -55f, 55f);
        this.yRot += (float) (((double) Input.mousePosition.x - (double) this.startPos.x) * 0.30000001192092896);
        this.startPos = Input.mousePosition;
        this.ScaleUp();
      }
      else
      {
        this.isFirst = true;
        this.zRot = Mathf.Lerp(this.zRot, 0.0f, 0.2f);
        this.yRot = Mathf.Lerp(this.yRot, 0.0f, 0.2f);
        this.ScaleDown();
      }
      this.transform.eulerAngles = new Vector3(0.0f, 90f + this.yRot, this.zRot);
    }
  }

  private void ScaleUp()
  {
    this.transform.localScale = Vector3.Lerp(this.transform.localScale, Vector3.one, 0.075f);
  }

  private void ScaleDown()
  {
    this.transform.localScale = Vector3.Lerp(this.transform.localScale, this.baseScale, 0.075f);
  }
}
