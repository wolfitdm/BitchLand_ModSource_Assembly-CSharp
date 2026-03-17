// Decompiled with JetBrains decompiler
// Type: TerrainQualitySettings
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class TerrainQualitySettings : MonoBehaviour
{
  private void Start() => this.UpdateQuality();

  private void UpdateQuality()
  {
    Debug.Log((object) "updating terrain quality");
    switch (QualitySettings.GetQualityLevel())
    {
      case 0:
        Terrain.activeTerrain.treeDistance = 250f;
        Terrain.activeTerrain.treeBillboardDistance = 30f;
        Terrain.activeTerrain.treeCrossFadeLength = 5f;
        Terrain.activeTerrain.treeMaximumFullLODCount = 5;
        Terrain.activeTerrain.detailObjectDistance = 30f;
        Terrain.activeTerrain.heightmapPixelError = 20f;
        Terrain.activeTerrain.heightmapMaximumLOD = 1;
        Terrain.activeTerrain.basemapDistance = 100f;
        break;
      case 1:
        Terrain.activeTerrain.treeDistance = 500f;
        Terrain.activeTerrain.treeBillboardDistance = 50f;
        Terrain.activeTerrain.treeCrossFadeLength = 10f;
        Terrain.activeTerrain.treeMaximumFullLODCount = 10;
        Terrain.activeTerrain.detailObjectDistance = 40f;
        Terrain.activeTerrain.heightmapPixelError = 10f;
        Terrain.activeTerrain.heightmapMaximumLOD = 1;
        Terrain.activeTerrain.basemapDistance = 250f;
        break;
      case 2:
        Terrain.activeTerrain.treeDistance = 650f;
        Terrain.activeTerrain.treeBillboardDistance = 75f;
        Terrain.activeTerrain.treeCrossFadeLength = 25f;
        Terrain.activeTerrain.treeMaximumFullLODCount = 20;
        Terrain.activeTerrain.detailObjectDistance = 60f;
        Terrain.activeTerrain.heightmapPixelError = 8f;
        Terrain.activeTerrain.heightmapMaximumLOD = 0;
        Terrain.activeTerrain.basemapDistance = 500f;
        break;
      case 3:
        Terrain.activeTerrain.treeDistance = 800f;
        Terrain.activeTerrain.treeBillboardDistance = 100f;
        Terrain.activeTerrain.treeCrossFadeLength = 40f;
        Terrain.activeTerrain.treeMaximumFullLODCount = 30;
        Terrain.activeTerrain.detailObjectDistance = 75f;
        Terrain.activeTerrain.heightmapPixelError = 5f;
        Terrain.activeTerrain.heightmapMaximumLOD = 0;
        Terrain.activeTerrain.basemapDistance = 800f;
        break;
      case 4:
        Terrain.activeTerrain.treeDistance = 1000f;
        Terrain.activeTerrain.treeBillboardDistance = 150f;
        Terrain.activeTerrain.treeCrossFadeLength = 50f;
        Terrain.activeTerrain.treeMaximumFullLODCount = 50;
        Terrain.activeTerrain.detailObjectDistance = 100f;
        Terrain.activeTerrain.heightmapPixelError = 5f;
        Terrain.activeTerrain.heightmapMaximumLOD = 0;
        Terrain.activeTerrain.basemapDistance = 1000f;
        break;
      case 5:
        Terrain.activeTerrain.treeDistance = 2000f;
        Terrain.activeTerrain.treeBillboardDistance = 250f;
        Terrain.activeTerrain.treeCrossFadeLength = 50f;
        Terrain.activeTerrain.treeMaximumFullLODCount = 100;
        Terrain.activeTerrain.detailObjectDistance = 200f;
        Terrain.activeTerrain.heightmapPixelError = 5f;
        Terrain.activeTerrain.heightmapMaximumLOD = 0;
        Terrain.activeTerrain.basemapDistance = 1000f;
        break;
    }
  }
}
