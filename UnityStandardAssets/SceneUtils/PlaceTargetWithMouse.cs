// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.SceneUtils.PlaceTargetWithMouse
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace UnityStandardAssets.SceneUtils
{
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
}
