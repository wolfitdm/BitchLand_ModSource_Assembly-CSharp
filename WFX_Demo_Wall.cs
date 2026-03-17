// Decompiled with JetBrains decompiler
// Type: WFX_Demo_Wall
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class WFX_Demo_Wall : MonoBehaviour
{
  public WFX_Demo_New demo;

  private void OnMouseDown()
  {
    RaycastHit hitInfo = new RaycastHit();
    if (!this.GetComponent<Collider>().Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, 9999f))
      return;
    GameObject gameObject = this.demo.spawnParticle();
    gameObject.transform.position = hitInfo.point;
    gameObject.transform.rotation = Quaternion.FromToRotation(Vector3.forward, hitInfo.normal);
  }
}
