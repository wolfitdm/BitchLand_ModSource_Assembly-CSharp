// Decompiled with JetBrains decompiler
// Type: Peace.WorldTerrain
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace Peace;

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
