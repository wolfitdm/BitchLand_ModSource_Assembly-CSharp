// Decompiled with JetBrains decompiler
// Type: Peace.TerrainSystem
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using Peace.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

#nullable disable
namespace Peace;

[ExecuteInEditMode]
public class TerrainSystem : MonoBehaviour
{
  public Material materialTemplate;
  [Header("Terrain parameters")]
  public int resolution = 2049;
  public int octavesCount = 9;
  public float persistence = 0.45f;
  public float frequency = 4f;
  public float tileWidth = 2000f;
  public float minAltitude;
  public float maxAltitude = 1000f;
  [Header("Biomes Parameters")]
  public bool useBiomes;
  public double biomeDensity = 1.0;
  public double limitBrightness = 4.0;
  [Header("Texture layers parameters")]
  public uint distributionResolution = 257;
  public List<TerrainSystem.Layer> layers = new List<TerrainSystem.Layer>();
  private Dictionary<Vector2Int, GameObject> _terrainGOs = new Dictionary<Vector2Int, GameObject>();
  private Dictionary<Vector2Int, Terrain> _terrains = new Dictionary<Vector2Int, Terrain>();
  private string _cacheLocation = "Assets/_world/";
  private HashSet<Vector2Int> _generatingCoords = new HashSet<Vector2Int>();
  private World _world;

  public bool generating => this._generatingCoords.Count != 0;

  public IEnumerable<Vector2Int> generatingCoords
  {
    get => (IEnumerable<Vector2Int>) this._generatingCoords;
  }

  private void OnEnable()
  {
    if (this._world != null)
      return;
    this.InitWorld();
    this.ReconnectGeneratedTerrains();
  }

  public void SetupDefaultLayers()
  {
    this.layers.Add(new TerrainSystem.Layer()
    {
      name = "rocks",
      distribParams = new DistributionParams()
      {
        ha = -1f,
        hb = 0.0f,
        hc = 1f,
        hd = 2f,
        dha = -1f,
        dhb = 0.0f,
        dhc = 1f,
        dhd = 2f,
        hmin = 0.0f,
        hmax = 1f,
        dhmin = 0.0f,
        dhmax = 1f,
        threshold = 0.05f,
        slopeFactor = 0.0f
      },
      color = new Color()
      {
        r = 0.3f,
        g = 0.3f,
        b = 0.3f,
        a = 1f
      },
      shader = new ShaderDef("texture-rock.frag")
    });
    this.layers.Add(new TerrainSystem.Layer()
    {
      name = "sand",
      distribParams = new DistributionParams()
      {
        ha = -1f,
        hb = 0.0f,
        hc = 0.4f,
        hd = 0.45f,
        dha = -1f,
        dhb = 0.0f,
        dhc = 0.4f,
        dhd = 0.6f,
        hmin = 0.0f,
        hmax = 1f,
        dhmin = 0.0f,
        dhmax = 1f,
        threshold = 0.05f,
        slopeFactor = 0.0f
      },
      color = new Color()
      {
        r = 0.75f,
        g = 0.7f,
        b = 0.6f,
        a = 1f
      },
      shader = new ShaderDef("texture-sand.frag")
    });
    this.layers.Add(new TerrainSystem.Layer()
    {
      name = "soil",
      distribParams = new DistributionParams()
      {
        ha = 0.33f,
        hb = 0.4f,
        hc = 0.6f,
        hd = 0.75f,
        dha = -1f,
        dhb = 0.0f,
        dhc = 0.45f,
        dhd = 0.65f,
        hmin = 0.0f,
        hmax = 0.85f,
        dhmin = 0.25f,
        dhmax = 0.85f,
        threshold = 0.05f,
        slopeFactor = 0.0f
      },
      color = new Color()
      {
        r = 0.13f,
        g = 0.09f,
        b = 0.06f,
        a = 1f
      },
      shader = new ShaderDef("texture-soil.frag")
    });
    this.layers.Add(new TerrainSystem.Layer()
    {
      name = "grass",
      distribParams = new DistributionParams()
      {
        ha = 0.33f,
        hb = 0.4f,
        hc = 0.6f,
        hd = 0.7f,
        dha = -1f,
        dhb = 0.0f,
        dhc = 0.4f,
        dhd = 0.6f,
        hmin = 0.0f,
        hmax = 1f,
        dhmin = 0.25f,
        dhmax = 0.6f,
        threshold = 0.05f,
        slopeFactor = 0.0f
      },
      color = new Color()
      {
        r = 0.2f,
        g = 0.6f,
        b = 0.3f,
        a = 1f
      },
      shader = new ShaderDef("texture-grass.frag")
    });
    this.layers.Add(new TerrainSystem.Layer()
    {
      name = "snow",
      distribParams = new DistributionParams()
      {
        ha = 0.65f,
        hb = 0.8f,
        hc = 1f,
        hd = 2f,
        dha = -1f,
        dhb = 0.0f,
        dhc = 0.5f,
        dhd = 0.7f,
        hmin = 0.0f,
        hmax = 1f,
        dhmin = 0.0f,
        dhmax = 1f,
        threshold = 0.05f,
        slopeFactor = 0.0f
      },
      color = new Color()
      {
        r = 0.95f,
        g = 0.95f,
        b = 0.96f,
        a = 1f
      },
      shader = new ShaderDef("texture-snow.frag")
    });
  }

  public bool IsEmpty() => this._terrains.Count == 0;

  public async void Regenerate()
  {
    if (this.generating)
      return;
    List<Vector2Int> other = new List<Vector2Int>((IEnumerable<Vector2Int>) this._terrainGOs.Keys);
    foreach (Vector2Int coords in other)
      this.DeleteTerrain(coords);
    if (this._world != null)
    {
      this._world.Dispose();
      Util.DeleteTree(new DirectoryInfo(this._cacheLocation));
    }
    this.InitWorld();
    if (other.Count == 0)
      other.Add(new Vector2Int(0, 0));
    this._generatingCoords.UnionWith((IEnumerable<Vector2Int>) other);
    foreach (Vector2Int tileCoords in other)
      await this.GenerateTile(tileCoords);
  }

  public async Task GenerateTile(Vector2Int tileCoords)
  {
    this._generatingCoords.Add(tileCoords);
    Collector collector = new Collector(Collector.Preset.ENGINE);
    ZoneView view = new ZoneView();
    float tileWidth = this.tileWidth;
    view.bbox.xmin = ((double) tileCoords.x + 0.05) * (double) tileWidth;
    view.bbox.ymin = ((double) tileCoords.y + 0.05) * (double) tileWidth;
    view.bbox.zmin = (double) this.minAltitude;
    view.bbox.xmax = view.bbox.xmin + (double) tileWidth * 0.9;
    view.bbox.ymax = view.bbox.ymin + (double) tileWidth * 0.9;
    view.bbox.zmax = (double) this.maxAltitude;
    view.resolution = (double) this.resolution / (double) this.tileWidth;
    await collector.CollectZone(this._world, view);
    this.AddTerrains(collector);
    this._generatingCoords.Remove(tileCoords);
    collector = (Collector) null;
  }

  public List<Vector2Int> GetExtensionPossibility()
  {
    List<Vector2Int> extensionPossibility = new List<Vector2Int>();
    Vector2Int[] vector2IntArray = new Vector2Int[4]
    {
      Vector2Int.left,
      Vector2Int.right,
      Vector2Int.down,
      Vector2Int.up
    };
    foreach (Vector2Int key1 in this._terrains.Keys)
    {
      foreach (Vector2Int vector2Int in vector2IntArray)
      {
        Vector2Int key2 = key1 + vector2Int;
        if (!this._terrains.ContainsKey(key2))
          extensionPossibility.Add(key2);
      }
    }
    return extensionPossibility;
  }

  private void InitWorld(bool vulkan = false)
  {
    WorldDef worldDef = new WorldDef();
    worldDef.ground.terrainRes = this.resolution;
    worldDef.ground.textureRes = 3;
    worldDef.ground.minAltitude = (double) this.minAltitude;
    worldDef.ground.maxAltitude = (double) this.maxAltitude;
    worldDef.ground.tileSystem.maxLod = 0;
    worldDef.ground.tileSystem.baseSize.x = this.tileWidth;
    worldDef.ground.tileSystem.baseSize.y = this.tileWidth;
    PerlinTerrainGeneratorDef terrainGeneratorDef = new PerlinTerrainGeneratorDef();
    terrainGeneratorDef.perlinInfo.octaves = terrainGeneratorDef.maxOctaves = this.octavesCount;
    terrainGeneratorDef.perlinInfo.frequency = (double) this.frequency;
    terrainGeneratorDef.perlinInfo.persistence = (double) this.persistence;
    worldDef.ground.workers_list.Add((IGroundWorkerDef) terrainGeneratorDef);
    if (this.useBiomes)
      worldDef.ground.workers_list.Add((IGroundWorkerDef) new CustomWorldRMModifierDef()
      {
        biomeDensity = this.biomeDensity,
        limitBrightness = this.limitBrightness
      });
    MultilayerGroundTextureDef groundTextureDef = new MultilayerGroundTextureDef();
    groundTextureDef.distribResolution = this.distributionResolution;
    foreach (TerrainSystem.Layer layer in this.layers)
      groundTextureDef.layers.Add(layer.distribParams);
    if (vulkan)
    {
      VkwGroundTextureGeneratorDef textureGeneratorDef = new VkwGroundTextureGeneratorDef();
      groundTextureDef.texProvider = (ITextureProviderDef) textureGeneratorDef;
      foreach (TerrainSystem.Layer layer in this.layers)
        textureGeneratorDef.layers.Add(layer.shader);
    }
    else
    {
      GroundTextureGeneratorDef textureGeneratorDef = new GroundTextureGeneratorDef();
      groundTextureDef.texProvider = (ITextureProviderDef) textureGeneratorDef;
      foreach (TerrainSystem.Layer layer in this.layers)
      {
        Color4dDef color4dDef = new Color4dDef()
        {
          r = (double) layer.color.r,
          g = (double) layer.color.g,
          b = (double) layer.color.b,
          a = (double) layer.color.a
        };
        textureGeneratorDef.colors.Add(color4dDef);
      }
    }
    worldDef.ground.workers_list.Add((IGroundWorkerDef) groundTextureDef);
    this._world = new World(worldDef);
    this._world.SetCacheLocation(this._cacheLocation);
  }

  private void AddTerrains(Collector collector, bool removeOld = false)
  {
    HashSet<Vector2Int> vector2IntSet = new HashSet<Vector2Int>((IEnumerable<Vector2Int>) this._terrains.Keys);
    foreach (string newNode in collector.GetNewNodes())
    {
      string mesh = collector.GetNode(newNode).Mesh;
      IntPtr terrainHandle = collector.GetTerrainHandle(mesh);
      if (terrainHandle != IntPtr.Zero)
      {
        BBox bbox = Terrains.terrainGetBBox(terrainHandle);
        double num = bbox.xmax - bbox.xmin;
        Vector2Int key = new Vector2Int((int) (bbox.xmin / num), (int) (bbox.ymin / num));
        if (!this._terrains.ContainsKey(key))
        {
          GameObject gameObject = new GameObject("Terrain " + key.ToString());
          gameObject.transform.SetParent(this.transform);
          WorldTerrain worldTerrain = gameObject.AddComponent<WorldTerrain>();
          worldTerrain.terrainSystem = this;
          worldTerrain.coords = key;
          Terrain terrain = gameObject.AddComponent<Terrain>();
          terrain.materialTemplate = this.materialTemplate;
          terrain.terrainData = new TerrainData();
          gameObject.AddComponent<TerrainCollider>().terrainData = terrain.terrainData;
          Terrains.ReadTerrainData(terrain.terrainData, terrainHandle);
          Terrains.ReadTerrainTextures(terrain, terrainHandle, collector, this._cacheLocation);
          Terrains.UpdateTerrainBBox(terrain, bbox);
          this._terrainGOs.Add(key, gameObject);
          this._terrains.Add(key, terrain);
        }
        else
          vector2IntSet.Remove(key);
      }
    }
    if (removeOld)
    {
      foreach (Vector2Int coords in vector2IntSet)
        this.DeleteTerrain(coords);
    }
    this.UpdateNeighbours();
  }

  private void ReconnectGeneratedTerrains()
  {
    int childCount = this.transform.childCount;
    for (int index = 0; index < childCount; ++index)
    {
      GameObject gameObject = this.transform.GetChild(index).gameObject;
      Terrain component1 = gameObject.GetComponent<Terrain>();
      WorldTerrain component2 = gameObject.GetComponent<WorldTerrain>();
      if ((UnityEngine.Object) component1 != (UnityEngine.Object) null && (UnityEngine.Object) component2 != (UnityEngine.Object) null)
      {
        Vector2Int coords = component2.coords;
        this._terrainGOs.Add(coords, gameObject);
        this._terrains.Add(coords, component1);
      }
    }
  }

  private void DeleteTerrain(Vector2Int coords)
  {
    this._terrainGOs[coords].GetComponent<WorldTerrain>().terrainSystem = (TerrainSystem) null;
    UnityEngine.Object.DestroyImmediate((UnityEngine.Object) this._terrainGOs[coords]);
    this.OnTerrainDeleted(coords);
  }

  internal void OnTerrainDeleted(Vector2Int coords)
  {
    this._terrainGOs.Remove(coords);
    this._terrains.Remove(coords);
  }

  private void UpdateNeighbours()
  {
    foreach (Vector2Int key in this._terrains.Keys)
    {
      Terrain terrain1 = this._terrains[key];
      Terrain terrain2;
      this._terrains.TryGetValue(key + Vector2Int.left, out terrain2);
      Terrain terrain3;
      this._terrains.TryGetValue(key + Vector2Int.up, out terrain3);
      Terrain terrain4;
      this._terrains.TryGetValue(key + Vector2Int.right, out terrain4);
      Terrain terrain5;
      this._terrains.TryGetValue(key + Vector2Int.down, out terrain5);
      Terrain left = terrain2;
      Terrain top = terrain3;
      Terrain right = terrain4;
      Terrain bottom = terrain5;
      terrain1.SetNeighbors(left, top, right, bottom);
    }
  }

  [Serializable]
  public struct Layer
  {
    public string name;
    public DistributionParams distribParams;
    public Color color;
    public ShaderDef shader;
    public bool toRemove;
    public bool addAfter;
    public int posChange;
  }
}
