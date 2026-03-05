// Decompiled with JetBrains decompiler
// Type: ForcePosing
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
