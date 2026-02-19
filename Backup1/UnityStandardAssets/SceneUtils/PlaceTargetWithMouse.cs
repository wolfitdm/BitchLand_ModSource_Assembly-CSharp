// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.SceneUtils.PlaceTargetWithMouse
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
