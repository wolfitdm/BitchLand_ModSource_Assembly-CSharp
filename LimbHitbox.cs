// Decompiled with JetBrains decompiler
// Type: LimbHitbox
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
