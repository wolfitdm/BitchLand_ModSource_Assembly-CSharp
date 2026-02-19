// Decompiled with JetBrains decompiler
// Type: Peace.WorldTerrain
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
