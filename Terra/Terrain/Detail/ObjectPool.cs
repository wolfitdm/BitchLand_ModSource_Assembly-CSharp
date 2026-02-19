// Decompiled with JetBrains decompiler
// Type: Terra.Terrain.Detail.ObjectPool
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Terra.Terrain.Detail
{
  public class ObjectPool
  {
    private ObjectRenderer Placer;
    private ObjectPool.ObjectContainer[] Containers;
    private List<ObjectPool.TileContainer> Tiles;

    public ObjectPool(ObjectRenderer placer)
    {
      this.Placer = placer;
      ObjectPlacementType[] array = placer.ObjectsToPlace.ToArray();
      this.Containers = new ObjectPool.ObjectContainer[array.Length];
      this.Tiles = new List<ObjectPool.TileContainer>();
      for (int index = 0; index < array.Length; ++index)
        this.Containers[index] = new ObjectPool.ObjectContainer(array[index]);
    }

    public void ActivateTile(TerrainTile tile)
    {
      ObjectPool.TileContainer tileContainer = (ObjectPool.TileContainer) null;
      foreach (ObjectPool.TileContainer tile1 in this.Tiles)
      {
        if ((Object) tile1.Tile == (Object) tile)
          tileContainer = tile1;
      }
      if (tileContainer == null)
      {
        tileContainer = new ObjectPool.TileContainer(tile, this);
        this.Tiles.Add(tileContainer);
      }
      if (!tileContainer.HasComputedPositions())
        tileContainer.ComputePositions();
      tileContainer.PlaceObjects();
    }

    public void DeactivateTile(TerrainTile tile)
    {
      ObjectPool.TileContainer tileContainer = (ObjectPool.TileContainer) null;
      foreach (ObjectPool.TileContainer tile1 in this.Tiles)
      {
        if ((Object) tile1.Tile == (Object) tile)
          tileContainer = tile1;
      }
      tileContainer?.RemoveObjects();
    }

    protected class ObjectContainer
    {
      private Dictionary<int, GameObject> Active = new Dictionary<int, GameObject>();
      private LinkedList<GameObject> Inactive = new LinkedList<GameObject>();

      public ObjectPlacementType Type { get; private set; }

      public ObjectContainer(ObjectPlacementType type) => this.Type = type;

      public void Warmup(int count, Transform parent, bool active = true)
      {
        for (int index = 0; index < count; ++index)
        {
          GameObject gameObject = Object.Instantiate<GameObject>(this.Type.Prefab, parent);
          gameObject.SetActive(active);
          if (active)
            this.Active.Add(gameObject.GetInstanceID(), gameObject);
          else
            this.Inactive.AddLast(gameObject);
        }
      }

      public GameObject GetObject(Transform parent)
      {
        if (this.Inactive.Count > 0)
        {
          GameObject gameObject = this.Inactive.Last.Value;
          this.Inactive.RemoveLast();
          gameObject.SetActive(true);
          gameObject.transform.parent = parent;
          this.Active.Add(gameObject.GetInstanceID(), gameObject);
          return gameObject;
        }
        GameObject gameObject1 = Object.Instantiate<GameObject>(this.Type.Prefab, parent);
        this.Active.Add(gameObject1.GetInstanceID(), gameObject1);
        return gameObject1;
      }

      public void RemoveObject(GameObject go)
      {
        go.SetActive(false);
        if (this.Active.ContainsKey(go.GetInstanceID()))
        {
          this.Active.Remove(go.GetInstanceID());
          this.Inactive.AddFirst(go);
        }
        else
          Debug.LogWarning((object) "The passed gameobject does not exist in the list of active tiles");
      }

      public override bool Equals(object obj)
      {
        return obj is ObjectPool.ObjectContainer && this.Type.Prefab.name == ((ObjectPool.ObjectContainer) obj).Type.Prefab.name;
      }

      public override int GetHashCode()
      {
        return ((-572560676 * -1521134295 + EqualityComparer<ObjectPlacementType>.Default.GetHashCode(this.Type)) * -1521134295 + EqualityComparer<Dictionary<int, GameObject>>.Default.GetHashCode(this.Active)) * -1521134295 + EqualityComparer<LinkedList<GameObject>>.Default.GetHashCode(this.Inactive);
      }
    }

    protected class TileContainer
    {
      private readonly ObjectPool Pool;
      private ObjectPool.TileContainer.PositionsContainer[] Positions;
      private List<GameObject> PlacedObjects = new List<GameObject>();
      private const string OBJS_CONTAINER_NAME = "OBJECTS";

      public TerrainTile Tile { get; private set; }

      public TileContainer(TerrainTile tile, ObjectPool pool)
      {
        this.Tile = tile;
        this.Pool = pool;
      }

      public void PlaceObjects()
      {
        TerraSettings objectOfType = Object.FindObjectOfType<TerraSettings>();
        if (this.Positions == null || !((Object) objectOfType != (Object) null))
          return;
        foreach (ObjectPool.TileContainer.PositionsContainer position1 in this.Positions)
        {
          ObjectPool.ObjectContainer containerForType = this.GetContainerForType(position1.Type);
          Transform parent = this.GetParent();
          if (containerForType != null)
          {
            foreach (Vector3 position2 in position1.Positions)
            {
              GameObject go = containerForType.GetObject(parent);
              position1.Type.TransformGameObject(go, position2, objectOfType.Length, this.Tile.transform.position);
              this.PlacedObjects.Add(go);
            }
          }
        }
      }

      public void RemoveObjects()
      {
        foreach (ObjectPool.TileContainer.PositionsContainer position in this.Positions)
        {
          ObjectPool.ObjectContainer containerForType = this.GetContainerForType(position.Type);
          foreach (GameObject placedObject in this.PlacedObjects)
            containerForType.RemoveObject(placedObject);
          this.PlacedObjects = new List<GameObject>();
        }
      }

      public void ComputePositions()
      {
        this.Positions = new ObjectPool.TileContainer.PositionsContainer[this.Pool.Placer.ObjectsToPlace.Count];
        for (int index = 0; index < this.Positions.Length; ++index)
        {
          ObjectPlacementType type = this.Pool.Placer.ObjectsToPlace[index];
          Vector3[] array = this.Pool.Placer.GetFilteredGrid(this.Tile, type, 1f).ToArray();
          this.Positions[index] = new ObjectPool.TileContainer.PositionsContainer(array, type);
        }
      }

      public bool HasComputedPositions() => this.Positions != null;

      private Transform GetParent()
      {
        foreach (Transform transform in this.Tile.transform)
        {
          if (transform.name == "OBJECTS")
            return transform.gameObject.transform;
        }
        return new GameObject("OBJECTS")
        {
          transform = {
            parent = this.Tile.transform
          }
        }.transform;
      }

      private ObjectPool.ObjectContainer GetContainerForType(ObjectPlacementType type)
      {
        foreach (ObjectPool.ObjectContainer container in this.Pool.Containers)
        {
          if (container.Type.Equals((object) type))
            return container;
        }
        return (ObjectPool.ObjectContainer) null;
      }

      private class PositionsContainer
      {
        public Vector3[] Positions;
        public ObjectPlacementType Type;

        public PositionsContainer(Vector3[] positions, ObjectPlacementType type)
        {
          this.Positions = positions;
          this.Type = type;
        }
      }
    }
  }
}
