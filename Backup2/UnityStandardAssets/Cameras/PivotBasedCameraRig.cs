// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Cameras.PivotBasedCameraRig
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace UnityStandardAssets.Cameras;

public abstract class PivotBasedCameraRig : AbstractTargetFollower
{
  protected Transform m_Cam;
  protected Transform m_Pivot;
  protected Vector3 m_LastTargetPosition;

  protected virtual void Awake()
  {
    this.m_Cam = this.GetComponentInChildren<Camera>().transform;
    this.m_Pivot = this.m_Cam.parent;
  }
}
