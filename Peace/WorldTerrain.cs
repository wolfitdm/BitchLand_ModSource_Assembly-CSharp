// Decompiled with JetBrains decompiler
// Type: Peace.WorldTerrain
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
