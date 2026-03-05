// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Cameras.PivotBasedCameraRig
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace UnityStandardAssets.Cameras
{
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
}
