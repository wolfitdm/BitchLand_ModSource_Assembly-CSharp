// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.SceneUtils.PlaceTargetWithMouse
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace UnityStandardAssets.SceneUtils;

public class PlaceTargetWithMouse : MonoBehaviour
{
  public float surfaceOffset = 1.5f;
  public GameObject setTargetOn;

  private void Update()
  {
    RaycastHit hitInfo;
    if (!Input.GetMouseButtonDown(0) || !Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
      return;
    this.transform.position = hitInfo.point + hitInfo.normal * this.surfaceOffset;
    if (!((Object) this.setTargetOn != (Object) null))
      return;
    this.setTargetOn.SendMessage("SetTarget", (object) this.transform);
  }
}
