// Decompiled with JetBrains decompiler
// Type: LimbHitbox
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class LimbHitbox : MonoBehaviour
{
  public bool VitalLimb;
  public Health PersonHealth;
  public Vector3 OrgPos;
  public Vector3 OrgRot;

  public void Awake()
  {
    this.OrgPos = this.transform.localPosition;
    this.OrgRot = this.transform.localEulerAngles;
  }
}
