// Decompiled with JetBrains decompiler
// Type: TTT.ForceGrassDistanceInEditor
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace TTT
{
  [ExecuteInEditMode]
  public class ForceGrassDistanceInEditor : MonoBehaviour
  {
    public float distance = 250f;
    private Terrain terrain;

    private void Start()
    {
      this.terrain = this.GetComponent<Terrain>();
      if (!((Object) this.terrain == (Object) null))
        return;
      Debug.LogError((object) "This gameobject is not terrain, disabling forced details distance", (Object) this.gameObject);
      this.enabled = false;
    }

    private void Update() => this.terrain.detailObjectDistance = this.distance;
  }
}
