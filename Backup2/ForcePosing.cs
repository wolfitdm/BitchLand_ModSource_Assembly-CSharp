// Decompiled with JetBrains decompiler
// Type: ForcePosing
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
