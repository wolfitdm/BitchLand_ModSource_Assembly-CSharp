// Decompiled with JetBrains decompiler
// Type: LimbHitbox
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
