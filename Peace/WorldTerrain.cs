// Decompiled with JetBrains decompiler
// Type: Peace.WorldTerrain
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace Peace
{
  [ExecuteInEditMode]
  public class WorldTerrain : MonoBehaviour
  {
    public TerrainSystem terrainSystem;
    public Vector2Int coords;

    private void OnDestroy()
    {
      if (!(bool) (Object) this.terrainSystem)
        return;
      this.terrainSystem.OnTerrainDeleted(this.coords);
    }
  }
}
