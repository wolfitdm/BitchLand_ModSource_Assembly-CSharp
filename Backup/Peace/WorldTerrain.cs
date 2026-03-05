// Decompiled with JetBrains decompiler
// Type: Peace.WorldTerrain
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
