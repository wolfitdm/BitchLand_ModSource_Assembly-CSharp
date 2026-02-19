// Decompiled with JetBrains decompiler
// Type: Terra.Terrain.TileCache
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Terra.Terrain
{
  public class TileCache
  {
    private int CacheCapacity;
    private LinkedList<TerrainTile> CachedTiles = new LinkedList<TerrainTile>();

    public List<TerrainTile> ActiveTiles { get; private set; }

    public TileCache(int cacheCapacity = 20)
    {
      this.CacheCapacity = cacheCapacity;
      this.ActiveTiles = new List<TerrainTile>();
    }

    public TerrainTile GetCachedTileAtPosition(Vector2 position)
    {
      for (LinkedListNode<TerrainTile> node = this.CachedTiles.First; node != null; node = node.Next)
      {
        LinkedListNode<TerrainTile> next = node.Next;
        if (node.Value.Position == position)
        {
          this.CachedTiles.Remove(node);
          return node.Value;
        }
      }
      return (TerrainTile) null;
    }

    public bool TileActiveAtPosition(Vector2 position)
    {
      foreach (TerrainTile activeTile in this.ActiveTiles)
      {
        if (activeTile.Position == position)
          return true;
      }
      return false;
    }

    public List<Vector2> GetNewTilePositions(List<Vector2> positions)
    {
      List<Vector2> newTilePositions = new List<Vector2>(this.ActiveTiles.Count);
      foreach (Vector2 position in positions)
      {
        bool flag = false;
        foreach (TerrainTile activeTile in this.ActiveTiles)
        {
          if (activeTile.Position == position)
          {
            flag = true;
            break;
          }
        }
        if (!flag)
          newTilePositions.Add(position);
      }
      return newTilePositions;
    }

    public void CacheTile(TerrainTile tile)
    {
      tile.gameObject.SetActive(false);
      this.CachedTiles.AddFirst(tile);
      this.EnforceCacheSize();
      TerraEvent.TriggerOnTileDeactivated(tile);
    }

    public void AddActiveTile(TerrainTile tile)
    {
      tile.gameObject.SetActive(true);
      this.ActiveTiles.Add(tile);
      TerraEvent.TriggerOnTileActivated(tile);
    }

    private void EnforceCacheSize()
    {
      for (int index = this.CachedTiles.Count - this.CacheCapacity; index > 0; --index)
      {
        Object.Destroy((Object) this.CachedTiles.Last.Value);
        this.CachedTiles.RemoveLast();
      }
    }
  }
}
