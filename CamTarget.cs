// Decompiled with JetBrains decompiler
// Type: CamTarget
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
