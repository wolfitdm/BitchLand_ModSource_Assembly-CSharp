// Decompiled with JetBrains decompiler
// Type: CameraManager
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class CameraManager : MonoBehaviour
{
  [Tooltip("")]
  public Camera Camera;
  [Tooltip("")]
  public Vector3 offset = new Vector3(-4f, 4f, 2f);
  [Tooltip("")]
  [HideInInspector]
  public static List<Transform> CameraTargets = new List<Transform>();
  private int currentTarget;

  private void Start() => this.currentTarget = 0;

  private void Update()
  {
    if (CameraManager.CameraTargets.Count == 0)
      return;
    if (Input.GetKeyDown("x"))
    {
      ++this.currentTarget;
      if (this.currentTarget > CameraManager.CameraTargets.Count - 1)
        this.currentTarget = 0;
    }
    if (Input.GetKeyDown("z"))
    {
      --this.currentTarget;
      if (this.currentTarget < 0)
        this.currentTarget = CameraManager.CameraTargets.Count - 1;
    }
    if (!((Object) CameraManager.CameraTargets[this.currentTarget] == (Object) null) || CameraManager.CameraTargets.Count == 0)
      return;
    CameraManager.CameraTargets.Remove(CameraManager.CameraTargets[this.currentTarget]);
    ++this.currentTarget;
    if (this.currentTarget <= CameraManager.CameraTargets.Count - 1)
      return;
    this.currentTarget = 0;
  }

  private void LateUpdate()
  {
    if (CameraManager.CameraTargets.Count == 0)
      return;
    Transform cameraTarget = CameraManager.CameraTargets[this.currentTarget];
    if ((Object) CameraManager.CameraTargets[this.currentTarget] == (Object) null)
      return;
    this.Camera.transform.position = cameraTarget.position;
    this.Camera.transform.rotation = cameraTarget.rotation;
    this.Camera.transform.position += this.offset;
  }
}
