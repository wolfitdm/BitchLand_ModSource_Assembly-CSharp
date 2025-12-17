// Decompiled with JetBrains decompiler
// Type: TTT.PlaceOnSurfaceAtStart
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace TTT;

public class PlaceOnSurfaceAtStart : MonoBehaviour
{
  public float PivotOffset;
  public float RayOffset = 100f;
  public LayerMask GroundLayer;

  private void Start()
  {
    if ((1 << this.gameObject.layer & (int) this.GroundLayer) != 0)
      Debug.LogWarning((object) "GameObject is in the same layer as raycasting layer, raycast might hit gameobject instead of ground");
    RaycastHit hitInfo;
    if (!Physics.Raycast(this.transform.position + Vector3.up * this.RayOffset, -Vector3.up, out hitInfo, float.PositiveInfinity, (int) this.GroundLayer))
      return;
    this.transform.Translate(-Vector3.up * (hitInfo.distance - this.PivotOffset - this.RayOffset), Space.World);
  }
}
