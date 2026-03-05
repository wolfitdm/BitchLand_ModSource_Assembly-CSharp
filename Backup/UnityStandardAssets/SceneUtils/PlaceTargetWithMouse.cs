// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.SceneUtils.PlaceTargetWithMouse
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
