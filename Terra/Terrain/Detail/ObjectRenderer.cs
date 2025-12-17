// Decompiled with JetBrains decompiler
// Type: Terra.Terrain.Detail.ObjectRenderer
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using Terra.Terrain.Util;
using UnityEngine;

#nullable disable
namespace Terra.Terrain.Detail;

[Serializable]
public class ObjectRenderer
{
  private TerraSettings Settings;
  private ObjectPool Pool;
  private bool ObserveTiles;
  private const int GRID_SIZE = 20;

  public List<ObjectPlacementType> ObjectsToPlace { get; private set; }

  public ObjectRenderer(bool observeTiles = true)
  {
    this.Settings = TerraSettings.Instance;
    this.ObserveTiles = observeTiles;
    this.ObjectsToPlace = this.Settings.ObjectPlacementSettings;
    this.Pool = new ObjectPool(this);
    if (!this.ObserveTiles)
      return;
    TerraEvent.OnTileActivated += new TerraEvent.TileEvent(this.OnTerrainTileActivate);
    TerraEvent.OnTileDeactivated += new TerraEvent.TileEvent(this.OnTerrainTileDeactivate);
  }

  public List<Vector2> GetPoissonGrid(float density)
  {
    PoissonDiscSampler poissonDiscSampler = new PoissonDiscSampler(20f, 20f, density);
    List<Vector2> poissonGrid = new List<Vector2>();
    foreach (Vector2 sample in poissonDiscSampler.Samples())
      poissonGrid.Add(sample / 20f);
    return poissonGrid;
  }

  public List<Vector3> GetFilteredGrid(Mesh m, ObjectPlacementType type)
  {
    MeshSampler meshSampler = new MeshSampler(m, this.Settings.MeshResolution);
    List<Vector2> poissonGrid = this.GetPoissonGrid(type.Spread / 10f);
    List<Vector3> filteredGrid = new List<Vector3>();
    foreach (Vector2 vector2 in poissonGrid)
    {
      MeshSampler.MeshSample meshSample = meshSampler.SampleAt(vector2.x, vector2.y);
      if (type.ShouldPlaceAt(meshSample.Height, meshSample.Angle))
      {
        Vector3 vector3 = new Vector3(vector2.x, meshSample.Height, vector2.y);
        filteredGrid.Add(vector3);
      }
    }
    return filteredGrid;
  }

  public List<Vector3> GetFilteredGrid(TerrainTile tile, ObjectPlacementType type, float density)
  {
    MeshFilter component = tile.GetComponent<MeshFilter>();
    if ((UnityEngine.Object) component == (UnityEngine.Object) null)
      throw new ArgumentException("The passed TerrainTile does not have an attached MeshFilter. Has a mesh been created?");
    return this.GetFilteredGrid(component.sharedMesh, type);
  }

  private void OnTerrainTileActivate(TerrainTile tile) => this.Pool.ActivateTile(tile);

  private void OnTerrainTileDeactivate(TerrainTile tile) => this.Pool.DeactivateTile(tile);
}
