// Decompiled with JetBrains decompiler
// Type: bl_PhysicsManager
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class bl_PhysicsManager : MonoBehaviour
{
  public Vector3 OrgPos;
  public Vector3 OrgRot;
  public float MaxDistance;
  public Rigidbody rb;

  public void Awake()
  {
    this.OrgPos = this.transform.localPosition;
    this.OrgRot = this.transform.localEulerAngles;
  }

  private void FixedUpdate()
  {
    if (this.rb.isKinematic || (double) Vector3.Distance(this.transform.position, this.transform.parent.position) <= (double) this.MaxDistance)
      return;
    this.rb.isKinematic = true;
    this.transform.localPosition = this.OrgPos;
    this.transform.localEulerAngles = this.OrgRot;
    Main.RunInNextFrame(new Action(this.RestorePhysics), 2);
  }

  public void RestorePhysics()
  {
    if (!((UnityEngine.Object) this.rb != (UnityEngine.Object) null))
      return;
    this.rb.isKinematic = false;
  }

  public static Vector3 GetPointBetween(
    Vector3 position1,
    Vector3 position2,
    float distanceFromPosition1)
  {
    Vector3 vector3 = position2 - position1;
    vector3.Normalize();
    return position1 + vector3 * distanceFromPosition1;
  }
}
