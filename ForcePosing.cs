// Decompiled with JetBrains decompiler
// Type: ForcePosing
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class ForcePosing : MonoBehaviour
{
  public bool DoPos;
  public Vector3 Position;
  public bool DoRot;
  public Vector3 Rotation;
  public bool DoScl;
  public Vector3 Scale;

  private void LateUpdate()
  {
    if (this.DoPos)
      this.transform.localPosition = this.Position;
    if (this.DoRot)
      this.transform.localEulerAngles = this.Rotation;
    if (!this.DoScl)
      return;
    this.transform.localScale = this.Scale;
  }
}
