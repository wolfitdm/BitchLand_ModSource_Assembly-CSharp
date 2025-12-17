// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Cameras.ProtectCameraFromWallClip
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using UnityEngine;

#nullable disable
namespace UnityStandardAssets.Cameras;

public class ProtectCameraFromWallClip : MonoBehaviour
{
  public float clipMoveTime = 0.05f;
  public float returnTime = 0.4f;
  public float sphereCastRadius = 0.1f;
  public bool visualiseInEditor;
  public float closestDistance = 0.5f;
  public string dontClipTag = "Player";
  public Transform m_Cam;
  public Transform m_Pivot;
  public float m_OriginalDist;
  public float m_MoveVelocity;
  public float m_CurrentDist;
  public Ray m_Ray;
  public RaycastHit[] m_Hits;
  public ProtectCameraFromWallClip.RayHitComparer m_RayHitComparer;
  public LayerMask IGNORE;

  public bool protecting { get; private set; }

  private void Start()
  {
    this.m_Cam = this.GetComponentInChildren<Camera>().transform;
    this.m_Pivot = this.m_Cam.parent;
    this.m_CurrentDist = this.m_OriginalDist;
    this.m_RayHitComparer = new ProtectCameraFromWallClip.RayHitComparer();
  }

  private void LateUpdate()
  {
    this.m_OriginalDist -= (float) ((double) Input.GetAxis("Mouse ScrollWheel") * (double) Time.deltaTime * 50.0);
    if ((double) this.m_OriginalDist < 0.30000001192092896)
      this.m_OriginalDist = 0.3f;
    if ((double) this.m_OriginalDist > 2.0)
      this.m_OriginalDist = 2f;
    float target = this.m_OriginalDist;
    this.m_Ray.origin = this.m_Pivot.position + this.m_Pivot.forward * this.sphereCastRadius;
    this.m_Ray.direction = -this.m_Pivot.forward;
    Collider[] colliderArray = Physics.OverlapSphere(this.m_Ray.origin, this.sphereCastRadius);
    bool flag1 = false;
    bool flag2 = false;
    for (int index = 0; index < colliderArray.Length; ++index)
    {
      if (!colliderArray[index].isTrigger && colliderArray[index].gameObject.layer != 22 && (!((UnityEngine.Object) colliderArray[index].attachedRigidbody != (UnityEngine.Object) null) || !colliderArray[index].attachedRigidbody.CompareTag(this.dontClipTag)))
      {
        flag1 = true;
        break;
      }
    }
    if (flag1)
    {
      this.m_Ray.origin += this.m_Pivot.forward * this.sphereCastRadius;
      this.m_Hits = Physics.RaycastAll(this.m_Ray, this.m_OriginalDist - this.sphereCastRadius, this.IGNORE.value);
    }
    else
      this.m_Hits = Physics.SphereCastAll(this.m_Ray, this.sphereCastRadius, this.m_OriginalDist + this.sphereCastRadius, this.IGNORE.value);
    Array.Sort((Array) this.m_Hits, (IComparer) this.m_RayHitComparer);
    float num = float.PositiveInfinity;
    for (int index = 0; index < this.m_Hits.Length; ++index)
    {
      if ((double) this.m_Hits[index].distance < (double) num && !this.m_Hits[index].collider.isTrigger && (!((UnityEngine.Object) this.m_Hits[index].collider.attachedRigidbody != (UnityEngine.Object) null) || !this.m_Hits[index].collider.attachedRigidbody.CompareTag(this.dontClipTag)) && !this.IsOnIgnoredLayer(this.m_Hits[index].collider.gameObject.layer))
      {
        num = this.m_Hits[index].distance;
        target = -this.m_Pivot.InverseTransformPoint(this.m_Hits[index].point).z;
        flag2 = true;
      }
    }
    if (flag2)
      Debug.DrawRay(this.m_Ray.origin, -this.m_Pivot.forward * (target + this.sphereCastRadius), Color.red);
    this.protecting = flag2;
    this.m_CurrentDist = Mathf.SmoothDamp(this.m_CurrentDist, target, ref this.m_MoveVelocity, (double) this.m_CurrentDist > (double) target ? this.clipMoveTime : this.returnTime);
    this.m_CurrentDist = Mathf.Clamp(this.m_CurrentDist, this.closestDistance, this.m_OriginalDist);
    this.m_Cam.localPosition = -Vector3.forward * this.m_CurrentDist;
  }

  private bool IsOnIgnoredLayer(int layer) => layer == 22;

  public class RayHitComparer : IComparer
  {
    public int Compare(object x, object y)
    {
      return ((RaycastHit) x).distance.CompareTo(((RaycastHit) y).distance);
    }
  }
}
