// Decompiled with JetBrains decompiler
// Type: CamTarget
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class CamTarget : MonoBehaviour
{
  public Transform target;
  private float camSpeed = 50f;
  private Vector3 lerpPos;

  private void Update()
  {
    this.lerpPos = (this.target.position - this.transform.position) * Time.deltaTime * this.camSpeed;
    this.transform.position += this.lerpPos;
  }
}
