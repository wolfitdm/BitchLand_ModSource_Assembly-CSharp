// Decompiled with JetBrains decompiler
// Type: CamTarget
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class CamTarget : MonoBehaviour
{
  public Transform target;
  private float camSpeed = 50f;
  private Vector3 lerpPos;

  private void Update()
  {
    this.lerpPos = (this.target.position - this.transform.position) * Time.deltaTime * this.camSpeed;
    this.transform.position += this.lerpPos;
  }
}
