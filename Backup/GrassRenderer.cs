// Decompiled with JetBrains decompiler
// Type: GrassRenderer
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using Terra.Terrain;
using UnityEngine;

#nullable disable
public static class GrassRenderer
{
  private static Material _material;
  public static int Resolution = 128 /*0x80*/;
  private static bool CalculatingTile = false;
  private static Dictionary<TerrainTile, List<GameObject>> CachedMeshData = new Dictionary<TerrainTile, List<GameObject>>();
  private static LinkedList<TerrainTile> GenerationQueue = new LinkedList<TerrainTile>();
  private const string GRASS_SHADER_LOC = "Terra/GrassGeometry";
  private const string GRASS_CONTAINER_NAME = "Grass Meshes";

  public static Material Material
  {
    get
    {
      if ((Object) GrassRenderer._material == (Object) null)
        GrassRenderer._material = GrassRenderer.GetGrassMaterial();
      return GrassRenderer._material;
    }
  }

  static GrassRenderer()
  {
    TerraEvent.OnMeshColliderDidForm += (TerraEvent.MeshColliderAction) ((go, mc) =>
    {
      TerrainTile component = go.GetComponent<TerrainTile>();
      if (!TerraSettings.Instance.PlaceGrass || GrassRenderer.CachedMeshData.ContainsKey(component) || GrassRenderer.GenerationQueue.Contains(component))
        return;
      GrassRenderer.GenerationQueue.AddFirst(component);
    });
  }

  public static void Update()
  {
    GrassRenderer.UpdateMaterialData();
    if (GrassRenderer.CalculatingTile || GrassRenderer.GenerationQueue.Count <= 0)
      return;
    TerrainTile tile = GrassRenderer.GenerationQueue.Last.Value;
    GrassRenderer.GenerationQueue.RemoveLast();
    GrassRenderer.CalculateGrassMeshes(tile);
  }

  public static bool HasGrassData(TerrainTile tile)
  {
    return GrassRenderer.CachedMeshData.ContainsKey(tile);
  }

  public static void CalculateGrassMeshes(TerrainTile tile)
  {
    GrassRenderer.GrassTile grassTile = new GrassRenderer.GrassTile(tile, TerraSettings.Instance.GrassStepLength);
    GrassRenderer.CalculatingTile = true;
    tile.StartCoroutine(grassTile.CalculateCells((GrassRenderer.GrassTile.CalcFinished) (data =>
    {
      List<GameObject> gameObjectList = new List<GameObject>(data.Count);
      GameObject gameObject1 = GrassRenderer.SetupGrassParent(tile);
      foreach (GrassRenderer.GrassTile.MeshData meshData in data)
      {
        if (meshData.vertices != null)
        {
          GameObject gameObject2 = new GameObject("Grass");
          gameObject2.transform.parent = gameObject1.transform;
          gameObjectList.Add(gameObject2);
          MeshFilter meshFilter = gameObject2.AddComponent<MeshFilter>();
          gameObject2.AddComponent<MeshRenderer>().material = GrassRenderer.Material;
          Mesh mesh1 = new Mesh();
          mesh1.SetVertices(meshData.vertices);
          mesh1.SetNormals(meshData.normals);
          mesh1.SetIndices(meshData.indicies.ToArray(), MeshTopology.Points, 0);
          Mesh mesh2 = mesh1;
          meshFilter.mesh = mesh2;
        }
      }
      GrassRenderer.CachedMeshData.Add(tile, gameObjectList);
      GrassRenderer.CalculatingTile = false;
    })));
  }

  private static GameObject SetupGrassParent(TerrainTile tile)
  {
    GameObject gameObject = (GameObject) null;
    foreach (Transform transform in tile.transform)
    {
      if (transform.gameObject.name == "Grass Meshes")
      {
        gameObject = transform.gameObject;
        break;
      }
    }
    if ((Object) gameObject == (Object) null)
    {
      gameObject = new GameObject("Grass Meshes");
      gameObject.transform.parent = tile.transform;
    }
    return gameObject;
  }

  private static Material GetGrassMaterial()
  {
    Material grassMaterial = new Material(Shader.Find("Terra/GrassGeometry"));
    TerraSettings instance = TerraSettings.Instance;
    grassMaterial.SetTexture("_MainTex", (Texture) instance.GrassTexture);
    grassMaterial.SetFloat("_BillboardDistance", instance.BillboardDistance);
    grassMaterial.SetFloat("_GrassHeight", instance.GrassHeight);
    grassMaterial.SetFloat("_Cutoff", instance.ClipCutoff);
    return grassMaterial;
  }

  private static void UpdateMaterialData()
  {
    if (!((Object) GrassRenderer.Material != (Object) null))
      return;
    TerraSettings instance = TerraSettings.Instance;
    GrassRenderer.Material.SetTexture("_MainTex", (Texture) instance.GrassTexture);
    GrassRenderer.Material.SetFloat("_BillboardDistance", instance.BillboardDistance);
    GrassRenderer.Material.SetFloat("_GrassHeight", instance.GrassHeight);
    GrassRenderer.Material.SetFloat("_Cutoff", instance.ClipCutoff);
  }

  private class GrassTile
  {
    private MeshCollider _mc;
    private const int MAX_ITERATIONS_PER_FRAME = 10000;
    private const int MAX_VERTS_PER_MESH = 60000;
    private TerrainTile Tile;
    private float StepLength;

    private MeshCollider MeshCollider
    {
      get
      {
        if ((Object) this._mc == (Object) null)
        {
          this._mc = this.Tile.GetComponent<MeshCollider>();
          if ((Object) this._mc == (Object) null)
            Debug.Log((object) "GrassRenderer requires the passed TerrainTile have a MeshCollider");
        }
        return this._mc;
      }
    }

    public GrassTile(TerrainTile tile, float stepLength)
    {
      this.Tile = tile;
      this.StepLength = stepLength;
    }

    public IEnumerator CalculateCells(GrassRenderer.GrassTile.CalcFinished onCalculated)
    {
      Random.InitState(TerraSettings.GenerationSeed);
      float variation = TerraSettings.Instance.GrassVariation;
      List<GrassRenderer.GrassTile.MeshData> data = new List<GrassRenderer.GrassTile.MeshData>();
      Bounds bounds = this.Tile.Terrain.bounds;
      Bounds worldBounds = this.Tile.GetComponent<MeshRenderer>().bounds;
      int meshResolution = TerraSettings.Instance.MeshResolution;
      float rayHeight = worldBounds.max.y + 5f;
      float rayMaxLength = rayHeight - (worldBounds.min.y - 5f);
      List<Vector3> verts = new List<Vector3>(60000);
      List<Vector3> norms = new List<Vector3>(60000);
      List<int> indicies = new List<int>(60000);
      int idx = 0;
      int iterationCount = 0;
      for (float x = worldBounds.min.x; (double) x < (double) worldBounds.max.x; x += this.StepLength)
      {
        for (float z = worldBounds.min.z; (double) z < (double) worldBounds.max.z; z += this.StepLength)
        {
          float x1 = x + Random.Range(-variation, variation);
          float z1 = z + Random.Range(-variation, variation);
          RaycastHit hitInfo;
          if (this.MeshCollider.Raycast(new Ray(new Vector3(x1, rayHeight, z1), Vector3.down), out hitInfo, rayMaxLength) && this.CanPlaceAt(hitInfo))
          {
            verts.Add(new Vector3(x1, hitInfo.point.y, z1));
            norms.Add(hitInfo.normal);
            indicies.Add(idx);
            ++idx;
          }
          if (verts.Count >= 60000)
          {
            data.Add(new GrassRenderer.GrassTile.MeshData()
            {
              vertices = verts,
              normals = norms,
              indicies = indicies
            });
            verts = new List<Vector3>();
            norms = new List<Vector3>();
            indicies = new List<int>();
            idx = 0;
          }
          ++iterationCount;
          if (iterationCount > 10000)
          {
            iterationCount = 0;
            yield return (object) null;
          }
        }
      }
      yield return (object) null;
      data.Add(new GrassRenderer.GrassTile.MeshData()
      {
        vertices = verts,
        normals = norms,
        indicies = indicies
      });
      onCalculated(data);
    }

    private bool CanPlaceAt(RaycastHit hit)
    {
      float y = hit.point.y;
      float num = Vector3.Angle(Vector3.up, hit.normal);
      TerraSettings instance = TerraSettings.Instance;
      bool flag1 = (double) y >= (double) instance.GrassMinHeight && (double) y <= (double) instance.GrassMaxHeight;
      bool flag2 = (double) num >= (double) instance.GrassAngleMin && (double) num <= (double) instance.GrassAngleMax;
      if (instance.GrassConstrainHeight && instance.GrassConstrainAngle)
        return flag1 & flag2;
      if (instance.GrassConstrainHeight)
        return flag1;
      return !instance.GrassConstrainAngle || flag2;
    }

    public delegate void CalcFinished(List<GrassRenderer.GrassTile.MeshData> data);

    public struct MeshData
    {
      public List<Vector3> vertices;
      public List<Vector3> normals;
      public List<int> indicies;
    }
  }
}
