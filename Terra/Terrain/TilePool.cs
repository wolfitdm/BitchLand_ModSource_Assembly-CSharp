// Decompiled with JetBrains decompiler
// Type: Terra.Terrain.TilePool
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Terra.CoherentNoise;
using UnityEngine;

#nullable disable
namespace Terra.Terrain
{
  public class TilePool
  {
    public TerraSettings Settings;
    private TileCache Cache = new TileCache(30);
    private int queuedTiles;
    private UnityEngine.Object pollLock = new UnityEngine.Object();
    private const int CACHE_SIZE = 30;
    private const float ADD_TILE_DELAY = 0.5f;

    public int ActiveTileCount => this.Cache == null ? 0 : this.Cache.ActiveTiles.Count;

    public List<TerrainTile> ActiveTiles => this.Cache.ActiveTiles;

    public TilePool() => this.Settings = TerraSettings.Instance;

    public void Update()
    {
      if (this.queuedTiles < 1)
        this.Settings.StartCoroutine(this.UpdateTiles());
      this.Settings.StartCoroutine(this.UpdateColliders(0.5f));
    }

    public static List<Vector2> GetTilePositionsFromRadius(
      int radius,
      Vector3 position,
      int length)
    {
      int num1 = Mathf.RoundToInt(position.x / (float) length);
      int num2 = Mathf.RoundToInt(position.z / (float) length);
      List<Vector2> positionsFromRadius = new List<Vector2>(25);
      for (int index1 = -radius; index1 <= radius; ++index1)
      {
        for (int index2 = -radius; index2 <= radius; ++index2)
        {
          if (index2 * index2 + index1 * index1 < radius * radius)
            positionsFromRadius.Add(new Vector2((float) (num1 + index2), (float) (num2 + index1)));
        }
      }
      return positionsFromRadius;
    }

    public List<TerrainTile> GetTilesInExtent(Vector3 trackedPos, float extent)
    {
      List<TerrainTile> tilesInExtent = new List<TerrainTile>(this.Cache.ActiveTiles.Count);
      foreach (TerrainTile activeTile in this.Cache.ActiveTiles)
      {
        MeshRenderer component = activeTile.GetComponent<MeshRenderer>();
        if ((UnityEngine.Object) component != (UnityEngine.Object) null)
        {
          Vector3 vector3;
          ref Vector3 local1 = ref vector3;
          double x1 = (double) trackedPos.x;
          Bounds bounds1 = component.bounds;
          double y1 = (double) bounds1.center.y;
          double z1 = (double) trackedPos.z;
          local1 = new Vector3((float) x1, (float) y1, (float) z1);
          Bounds bounds2;
          ref Bounds local2 = ref bounds2;
          Vector3 center = vector3;
          double x2 = (double) extent;
          bounds1 = component.bounds;
          double y2 = (double) bounds1.max.y;
          double z2 = (double) extent;
          Vector3 size = new Vector3((float) x2, (float) y2, (float) z2);
          local2 = new Bounds(center, size);
          bounds1 = component.bounds;
          if (bounds1.Intersects(bounds2))
            tilesInExtent.Add(activeTile);
        }
      }
      return tilesInExtent;
    }

    public IEnumerator UpdateTiles()
    {
      List<Vector2> positionsFromRadius = this.GetTilePositionsFromRadius();
      List<Vector2> newTilePositions = this.Cache.GetNewTilePositions(positionsFromRadius);
      for (int index = 0; index < this.Cache.ActiveTiles.Count; ++index)
      {
        bool flag = false;
        foreach (Vector2 vector2 in positionsFromRadius)
        {
          if (this.Cache.ActiveTiles[index].Position == vector2)
          {
            flag = true;
            break;
          }
        }
        if (!flag)
        {
          this.Cache.CacheTile(this.Cache.ActiveTiles[index]);
          this.Cache.ActiveTiles.RemoveAt(index);
          --index;
        }
      }
      foreach (Vector2 vector2 in newTilePositions)
      {
        TerrainTile cachedTileAtPosition = this.Cache.GetCachedTileAtPosition(vector2);
        if ((UnityEngine.Object) cachedTileAtPosition != (UnityEngine.Object) null)
          this.Cache.AddActiveTile(cachedTileAtPosition);
        else
          yield return (object) this.AddTileAsync(vector2);
      }
    }

    private IEnumerator UpdateColliders(float delay)
    {
      foreach (TerrainTile terrainTile in this.GetTilesInExtent(this.Settings.TrackedObject.transform.position, this.Settings.GenAllColliders ? float.MaxValue : this.Settings.ColliderGenerationExtent))
      {
        terrainTile.GenerateCollider();
        yield return (object) null;
      }
      yield return (object) new WaitForSeconds(delay);
    }

    private List<Vector2> GetTilePositionsFromRadius()
    {
      return TilePool.GetTilePositionsFromRadius(this.Settings.GenerationRadius, this.Settings.TrackedObject.transform.position, this.Settings.Length);
    }

    public IEnumerator AddTileAsync(Vector2 pos)
    {
      TerrainTile tile = new GameObject("Tile: " + pos.ToString()).AddComponent<TerrainTile>();
      ++this.queuedTiles;
      if (this.Settings.UseMultithreading)
      {
        ThreadPool.QueueUserWorkItem((WaitCallback) (d =>
        {
          lock (this.pollLock)
          {
            if (!(d is TilePool.ThreadData threadData2))
              return;
            TilePool.ThreadData tData = threadData2;
            TerrainTile.MeshData md = tData.tile.CreateRawMesh(pos, tData.gen);
            MTDispatch.Instance().Enqueue((System.Action) (() =>
            {
              tData.tile.RenderRawMeshData(md);
              if (this.Settings.UseCustomMaterial)
                tile.ApplyCustomMaterial();
              else
                tile.Details.ApplySplatmap();
              tile.UpdatePosition(pos);
              this.Cache.AddActiveTile(tile);
              --this.queuedTiles;
            }));
          }
        }), (object) new TilePool.ThreadData()
        {
          tile = tile,
          gen = this.Settings.Graph.GetEndGenerator()
        });
      }
      else
      {
        yield return (object) new WaitForSecondsRealtime(0.5f);
        tile.CreateMesh(pos, false);
        yield return (object) null;
        if (this.Settings.UseCustomMaterial)
          tile.ApplyCustomMaterial();
        else
          tile.Details.ApplySplatmap();
        tile.gameObject.GetComponent<MeshRenderer>().enabled = true;
        this.Cache.AddActiveTile(tile);
        --this.queuedTiles;
      }
    }

    private struct ThreadData
    {
      public TerrainTile tile;
      public Generator gen;
    }
  }
}
