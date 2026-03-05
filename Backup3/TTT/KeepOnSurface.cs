// Decompiled with JetBrains decompiler
// Type: TTT.KeepOnSurface
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace TTT
{
  public class KeepOnSurface : MonoBehaviour
  {
    public float PivotOffset;
    public float RayOffset = 100f;
    public LayerMask GroundLayer;
    private RaycastHit hit;

    private void Start()
    {
      if ((1 << this.gameObject.layer & (int) this.GroundLayer) == 0)
        return;
      Debug.LogWarning((object) "GameObject is in the same layer as raycasting layer, raycast might hit gameobject instead of ground");
    }

    private void Update()
    {
      if (!Physics.Raycast(this.transform.position + Vector3.up * this.RayOffset, -Vector3.up, out this.hit, float.PositiveInfinity, (int) this.GroundLayer))
        return;
      this.transform.Translate(-Vector3.up * (this.hit.distance - this.PivotOffset - this.RayOffset), Space.World);
    }
  }
}
