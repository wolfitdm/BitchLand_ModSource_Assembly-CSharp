// Decompiled with JetBrains decompiler
// Type: ForcePosing
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
