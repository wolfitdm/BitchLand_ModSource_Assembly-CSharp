// Decompiled with JetBrains decompiler
// Type: GenerateTerrain
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Text;
using UnityEngine;

#nullable disable
public class GenerateTerrain : MonoBehaviour
{
  [Header("Size of the Sandbox:")]
  public GenerateTerrain.SandboxSize TerrainSize;
  public bool drawInstanced = true;
  private int TerrainCount = 1;
  private Terrain[] Terrains;
  private GameObject TerrainTileObject;
  private TerrainCollider Collider;
  private Terrain LeftTerrain;
  private Terrain RightTerrain;
  private Terrain TopTerrain;
  private Terrain BottomTerrain;
  private int size = 513;
  [Header("Hight Scale:")]
  public int height = 100;
  [Header("Large Details:")]
  [Range(50f, 500f)]
  public float LargeHeight = 15f;
  [Range(0.01f, 0.2f)]
  public float LargeNoiseScale = 0.1f;
  [Header("Big Details:")]
  [Range(5f, 100f)]
  public float BigHeight = 15f;
  [Range(0.1f, 30f)]
  public float BigNoiseScale = 10f;
  [Header("Medium Details:")]
  [Range(1f, 10f)]
  public float MidHeight = 5f;
  [Range(5f, 100f)]
  public float MidNoiseScale = 20f;
  [Header("Small Details:")]
  [Range(0.1f, 5f)]
  public float SmallHeight = 2f;
  [Range(30f, 400f)]
  public float SmallNoiseScale = 40f;
  private int xOffset = 1;
  private int yOffset = 1;
  [Header("Perlin Noise Options:")]
  [Range(0.01f, 0.2f)]
  public float LargeSub = 0.05f;
  [Range(0.01f, 2f)]
  public float BigSub = 0.1f;
  [Range(0.01f, 2f)]
  public float MidSub = 0.5f;
  [Range(0.01f, 2f)]
  public float SmallSub = 0.8f;
  [Range(0.01f, 10f)]
  public float mult = 2f;
  [Range(0.01f, 5f)]
  public float Exponent = 2f;
  [Header("Other stuff:")]
  public int groupID;
  [Header("Terrain Material:")]
  public Material TerrainMaterial;
  [Header("Terrain Textures:")]
  public TerrainTexture[] textures;
  private TerrainLayer[] splatPrototypes;
  private float[,,] splatMaps;
  private float terrainMaxHeight;
  private int counter;
  [Header("Vegetation Textures:")]
  public Texture2D[] Grass;
  [Header("Vegetation Settings:")]
  [Range(0.0f, 100f)]
  public int grassDensity = 5;
  public Color healthyColor;
  public Color dryColor;
  [Header("Building Objects:")]
  public int CoverObjectsPerTerrain = 50;
  public GameObject[] CoverObjects;
  public int BuildingsPerTerrain = 10;
  public GameObject[] BuildingObjects;
  private int[][][] isBuilding;
  private int dis;
  [Header("Wall to close the map:")]
  public GameObject[] WallObject;
  public GameObject CornerTower;
  private GameObject[] WallHolder;
  [Header("Seed for Random Generation:")]
  public int RandomOffsetSeed = 132;
  [Header("Holo Wall Settings:")]
  public Material HoloWallMaterial;
  [Range(5f, 200f)]
  public int HoloWallHeight = 30;
  private Mesh HoloWallMesh;
  private GameObject HoloWallObject;
  private Vector3[] Verts;
  private Vector2[] UVs;
  private int[] Tris;

  public void Generate(string Seed)
  {
    this.RestoreSeed(Seed);
    this.Generate();
  }

  public void Generate()
  {
    this.TerrainCount = (int) (this.TerrainSize + 1);
    this.yOffset = 1;
    this.xOffset = 1;
    this.counter = 0;
    if (this.transform.childCount != 0)
      UnityEngine.Object.DestroyImmediate((UnityEngine.Object) this.transform.GetChild(0).gameObject);
    GameObject gameObject1 = new GameObject("Generated Terrain");
    gameObject1.transform.parent = this.transform;
    gameObject1.isStatic = true;
    this.splatPrototypes = new TerrainLayer[this.textures.Length];
    for (int index = 0; index < this.textures.Length; ++index)
    {
      this.splatPrototypes[index] = new TerrainLayer();
      this.splatPrototypes[index].diffuseTexture = this.textures[index].texture;
      this.splatPrototypes[index].tileSize = this.textures[index].tilesize;
      this.splatPrototypes[index].normalMapTexture = this.textures[index].normalMap;
      this.splatPrototypes[index].metallic = this.textures[index].metallness;
      this.splatPrototypes[index].name = this.textures[index].textureName;
      this.splatPrototypes[index].normalScale = this.textures[index].bumpFactor;
      this.splatPrototypes[index].smoothness = this.textures[index].smoothness;
    }
    this.WallHolder = new GameObject[this.TerrainCount * this.TerrainCount];
    GameObject gameObject2 = new GameObject("Wall Parts");
    gameObject2.transform.parent = gameObject1.transform;
    gameObject2.isStatic = true;
    for (int index = 0; index < this.WallHolder.Length; ++index)
    {
      this.WallHolder[index] = new GameObject("Wall");
      this.WallHolder[index].transform.parent = gameObject2.transform;
      this.WallHolder[index].isStatic = true;
    }
    GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.CornerTower, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.Euler(0.0f, 0.0f, 0.0f));
    gameObject3.transform.parent = gameObject2.transform;
    gameObject3.isStatic = true;
    GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(this.CornerTower, new Vector3((float) ((double) this.transform.position.x + (double) (this.size * this.TerrainCount) - (1.0 + 0.125 * (double) this.TerrainCount)), this.transform.position.y, this.transform.position.z), Quaternion.Euler(0.0f, -90f, 0.0f));
    gameObject4.transform.parent = gameObject2.transform;
    gameObject4.isStatic = true;
    GameObject gameObject5 = UnityEngine.Object.Instantiate<GameObject>(this.CornerTower, new Vector3(this.transform.position.x, this.transform.position.y, (float) ((double) this.transform.position.z + (double) (this.size * this.TerrainCount) - (1.0 + 0.125 * (double) this.TerrainCount))), Quaternion.Euler(0.0f, 90f, 0.0f));
    gameObject5.transform.parent = gameObject2.transform;
    gameObject5.isStatic = true;
    GameObject gameObject6 = UnityEngine.Object.Instantiate<GameObject>(this.CornerTower, new Vector3((float) ((double) this.transform.position.x + (double) (this.size * this.TerrainCount) - (1.0 + 0.125 * (double) this.TerrainCount)), this.transform.position.y, (float) ((double) this.transform.position.z + (double) (this.size * this.TerrainCount) - (1.0 + 0.125 * (double) this.TerrainCount))), Quaternion.Euler(0.0f, 180f, 0.0f));
    gameObject6.transform.parent = gameObject2.transform;
    gameObject6.isStatic = true;
    this.HoloWallMesh = new Mesh();
    this.Verts = new Vector3[8];
    this.UVs = new Vector2[8];
    this.Tris = new int[24];
    this.Verts[0] = new Vector3(1f, 0.0f, 1f);
    this.Verts[1] = new Vector3(1f, (float) this.HoloWallHeight, 1f);
    this.Verts[2] = new Vector3((float) (this.TerrainCount * 513 - 2), 0.0f, 1f);
    this.Verts[3] = new Vector3((float) (this.TerrainCount * 513 - 2), (float) this.HoloWallHeight, 1f);
    this.Verts[4] = new Vector3((float) (this.TerrainCount * 513 - 2), 0.0f, (float) (this.TerrainCount * 513 - 2));
    this.Verts[5] = new Vector3((float) (this.TerrainCount * 513 - 2), (float) this.HoloWallHeight, (float) (this.TerrainCount * 513 - 2));
    this.Verts[6] = new Vector3(1f, 0.0f, (float) (this.TerrainCount * 513 - 2));
    this.Verts[7] = new Vector3(1f, (float) this.HoloWallHeight, (float) (this.TerrainCount * 513 - 2));
    this.UVs[0] = new Vector2(0.0f, 0.0f);
    this.UVs[1] = new Vector2(0.0f, 1f);
    this.UVs[2] = new Vector2(1f, 0.0f);
    this.UVs[3] = new Vector2(1f, 1f);
    this.UVs[4] = new Vector2(0.0f, 0.0f);
    this.UVs[5] = new Vector2(0.0f, 1f);
    this.UVs[6] = new Vector2(1f, 0.0f);
    this.UVs[7] = new Vector2(1f, 1f);
    this.Tris[0] = 0;
    this.Tris[1] = 2;
    this.Tris[2] = 1;
    this.Tris[3] = 2;
    this.Tris[4] = 3;
    this.Tris[5] = 1;
    this.Tris[6] = 2;
    this.Tris[7] = 4;
    this.Tris[8] = 3;
    this.Tris[9] = 3;
    this.Tris[10] = 4;
    this.Tris[11] = 5;
    this.Tris[12] = 5;
    this.Tris[13] = 4;
    this.Tris[14] = 6;
    this.Tris[15] = 6;
    this.Tris[16 /*0x10*/] = 7;
    this.Tris[17] = 5;
    this.Tris[18] = 0;
    this.Tris[19] = 7;
    this.Tris[20] = 6;
    this.Tris[21] = 0;
    this.Tris[22] = 1;
    this.Tris[23] = 7;
    this.HoloWallMesh.vertices = this.Verts;
    this.HoloWallMesh.uv = this.UVs;
    this.HoloWallMesh.triangles = this.Tris;
    this.HoloWallObject = new GameObject("Holowall", new System.Type[2]
    {
      typeof (MeshFilter),
      typeof (MeshRenderer)
    });
    this.HoloWallObject.transform.localScale = new Vector3(1f, 1f, 1f);
    this.HoloWallObject.GetComponent<MeshFilter>().mesh = this.HoloWallMesh;
    this.HoloWallObject.GetComponent<MeshRenderer>().material = this.HoloWallMaterial;
    this.HoloWallObject.GetComponent<MeshRenderer>().sharedMaterial.SetTextureScale("_MainTex", new Vector2((float) (this.TerrainCount * this.size), (float) this.HoloWallHeight));
    this.HoloWallObject.AddComponent<MeshCollider>();
    this.HoloWallObject.layer = 2;
    this.HoloWallObject.transform.parent = gameObject1.transform;
    UnityEngine.Random.InitState(this.RandomOffsetSeed);
    this.Terrains = new Terrain[this.TerrainCount * this.TerrainCount];
    this.isBuilding = new int[this.Terrains.Length][][];
    for (int index1 = 0; index1 < this.TerrainCount * this.TerrainCount; ++index1)
    {
      this.isBuilding[index1] = new int[this.size][];
      for (int index2 = 0; index2 < this.size; ++index2)
      {
        this.isBuilding[index1][index2] = new int[this.size];
        for (int index3 = 0; index3 < this.size; ++index3)
          this.isBuilding[index1][index2][index3] = 0;
      }
    }
    GameObject gameObject7 = new GameObject("Terrain Chunks");
    gameObject7.transform.parent = gameObject1.transform;
    gameObject7.isStatic = true;
    for (int index4 = 0; index4 < this.TerrainCount; ++index4)
    {
      this.yOffset = (this.size - 1) * index4;
      for (int index5 = 0; index5 < this.TerrainCount; ++index5)
      {
        this.xOffset = (this.size - 1) * index5;
        this.TerrainTileObject = new GameObject($"Terrain Tile: {index4.ToString()}/{index5.ToString()}");
        this.TerrainTileObject.transform.parent = gameObject7.transform;
        this.TerrainTileObject.AddComponent<Terrain>();
        this.TerrainTileObject.AddComponent<TerrainCollider>();
        this.TerrainTileObject.transform.position = new Vector3((float) (this.size * index4), 0.0f, (float) (this.size * index5)) + this.transform.position;
        this.TerrainTileObject.isStatic = true;
        this.Terrains[this.counter] = this.TerrainTileObject.GetComponent<Terrain>();
        this.Collider = this.TerrainTileObject.GetComponent<TerrainCollider>();
        this.Terrains[this.counter].terrainData = new TerrainData();
        this.Terrains[this.counter].terrainData = this.GenTerrainData(this.Terrains[this.counter]);
        this.Terrains[this.counter].groupingID = this.groupID;
        this.Terrains[this.counter].drawInstanced = this.drawInstanced;
        this.GenerateBuildings(this.Terrains[this.counter]);
        this.GenerateVegetation(this.Terrains[this.counter]);
        this.GenerateTextures(this.Terrains[this.counter].terrainData);
        this.Collider.terrainData = this.Terrains[this.counter].terrainData;
        this.Terrains[this.counter].materialType = Terrain.MaterialType.Custom;
        this.Terrains[this.counter].materialTemplate = this.TerrainMaterial;
        ++this.counter;
      }
    }
    this.counter = 0;
    for (int index = 0; index < this.WallHolder.Length; ++index)
    {
      if (this.WallHolder[index].transform.childCount < 1)
        UnityEngine.Object.DestroyImmediate((UnityEngine.Object) this.WallHolder[index]);
    }
    for (int index6 = 0; index6 < this.TerrainCount; ++index6)
    {
      for (int index7 = 0; index7 < this.TerrainCount; ++index7)
      {
        this.LeftTerrain = index6 <= 0 ? (Terrain) null : this.Terrains[this.counter - this.TerrainCount];
        this.BottomTerrain = index7 <= 0 ? (Terrain) null : this.Terrains[this.counter - 1];
        this.TopTerrain = this.counter + 1 >= this.TerrainCount * this.TerrainCount || (this.counter + 1) % this.TerrainCount == 0 ? (Terrain) null : this.Terrains[this.counter + 1];
        this.RightTerrain = this.counter + this.TerrainCount >= this.TerrainCount * this.TerrainCount ? (Terrain) null : this.Terrains[this.counter + this.TerrainCount];
        this.Terrains[this.counter].SetNeighbors(this.LeftTerrain, this.TopTerrain, this.RightTerrain, this.BottomTerrain);
        ++this.counter;
      }
    }
    for (int index = 0; index < this.Terrains.Length; ++index)
      this.Terrains[index].Flush();
  }

  private TerrainData GenTerrainData(Terrain myTerrain)
  {
    TerrainData terrainData = myTerrain.terrainData;
    terrainData.heightmapResolution = this.size;
    terrainData.SetDetailResolution(512 /*0x0200*/, 32 /*0x20*/);
    terrainData.thickness = 1f;
    terrainData.size = new Vector3((float) this.size, (float) this.height, (float) this.size);
    terrainData.SetHeights(0, 0, this.GenerateHeights());
    this.GenerateTextures(terrainData);
    return terrainData;
  }

  private float[,] GenerateHeights()
  {
    float[,] heights = new float[this.size, this.size];
    for (int index1 = 0; index1 < this.size; ++index1)
    {
      for (int index2 = 0; index2 < this.size; ++index2)
      {
        heights[index1, index2] = this.PerlinNoise(index1 + this.xOffset, index2 + this.yOffset);
        if (this.xOffset == 0)
        {
          if (index1 == 1 && index2 % 8 == 0 && index2 != 0)
          {
            GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.WallObject[UnityEngine.Random.Range(0, this.WallObject.Length)], new Vector3((float) index1 + this.transform.position.x, this.transform.position.y, (float) (index2 + this.yOffset) + this.transform.position.z), Quaternion.identity);
            gameObject.transform.parent = this.WallHolder[this.counter].transform;
            gameObject.isStatic = true;
          }
          if (index1 < 10)
            this.isBuilding[this.counter][index1][index2] = 2;
          if (index1 < 2)
            heights[index1, index2] = -1f;
          else if (index1 < 100)
            heights[index1, index2] -= 1f - Mathf.Pow((float) index1 / 100f, 0.2f);
        }
        if (this.yOffset == 0)
        {
          if (index2 == 1 && index1 % 8 == 0 && index1 != 512 /*0x0200*/)
          {
            GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.WallObject[UnityEngine.Random.Range(0, this.WallObject.Length)], new Vector3((float) (index1 + this.xOffset) + this.transform.position.x, this.transform.position.y, (float) index2 + this.transform.position.z), Quaternion.Euler(0.0f, -90f, 0.0f));
            gameObject.transform.parent = this.WallHolder[this.counter].transform;
            gameObject.isStatic = true;
          }
          if (index2 < 10)
            this.isBuilding[this.counter][index1][index2] = 2;
          if (index2 < 2)
            heights[index1, index2] = -1f;
          else if (index2 < 100)
            heights[index1, index2] -= 1f - Mathf.Pow((float) index2 / 100f, 0.2f);
        }
        if (this.xOffset == (this.size - 1) * (this.TerrainCount - 1))
        {
          if (this.size - 2 - index1 == 0 && (this.size - 1 - index2) % 8 == 0 && this.size - 1 - index2 != 0)
          {
            GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.WallObject[UnityEngine.Random.Range(0, this.WallObject.Length)], new Vector3((float) index1 + this.transform.position.x + (float) this.xOffset + (float) (this.TerrainCount - 1), this.transform.position.y, (float) index2 + this.transform.position.z + (float) this.yOffset), Quaternion.Euler(0.0f, 180f, 0.0f));
            gameObject.transform.parent = this.WallHolder[this.counter].transform;
            gameObject.isStatic = true;
          }
          if (this.size - 2 - index1 < 10)
            this.isBuilding[this.counter][index1][index2] = 2;
          if (this.size - 2 - index1 < 2)
            heights[index1, index2] = -1f;
          else if (this.size - 2 - index1 < 100)
            heights[index1, index2] -= 1f - Mathf.Pow((float) (this.size - 1 - index1) / 100f, 0.2f);
        }
        if (this.yOffset == (this.size - 1) * (this.TerrainCount - 1))
        {
          if (this.size - 2 - index2 == 0 && (this.size - 1 - index1) % 8 == 0 && this.size - 1 - index1 != 512 /*0x0200*/)
          {
            GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.WallObject[UnityEngine.Random.Range(0, this.WallObject.Length)], new Vector3((float) index1 + this.transform.position.x + (float) this.xOffset, this.transform.position.y, (float) index2 + this.transform.position.z + (float) this.yOffset + (float) (this.TerrainCount - 1)), Quaternion.Euler(0.0f, 90f, 0.0f));
            gameObject.transform.parent = this.WallHolder[this.counter].transform;
            gameObject.isStatic = true;
          }
          if (this.size - 2 - index2 < 10)
            this.isBuilding[this.counter][index1][index2] = 2;
          if (this.size - 2 - index2 < 2)
            heights[index1, index2] = -1f;
          else if (this.size - 2 - index2 < 100)
            heights[index1, index2] -= 1f - Mathf.Pow((float) (this.size - 1 - index2) / 100f, 0.2f);
        }
      }
    }
    return heights;
  }

  private void GenerateTextures(TerrainData terrainData)
  {
    this.terrainMaxHeight = terrainData.size.y;
    terrainData.terrainLayers = this.splatPrototypes;
    float[,,] map = new float[terrainData.alphamapWidth, terrainData.alphamapHeight, terrainData.alphamapLayers];
    for (int x1 = 0; x1 < terrainData.alphamapHeight; ++x1)
    {
      for (int y1 = 0; y1 < terrainData.alphamapWidth; ++y1)
      {
        float time1 = terrainData.GetHeight(x1, y1) / this.terrainMaxHeight;
        float x2 = (float) x1 / (float) terrainData.heightmapResolution;
        float y2 = (float) y1 / (float) terrainData.heightmapResolution;
        float time2 = terrainData.GetSteepness(x2, y2) / 90f;
        Vector3 interpolatedNormal = terrainData.GetInterpolatedNormal(x2, y2);
        for (int index1 = 0; index1 < terrainData.alphamapLayers; ++index1)
        {
          switch (this.textures[index1].type)
          {
            case TerrainTexture.Type.HeightBased:
              if (index1 != 0)
              {
                map[y1, x1, index1] = this.textures[index1].heightCurve.Evaluate(time1);
                for (int index2 = 0; index2 < index1; ++index2)
                  map[y1, x1, index2] *= (float) (((double) map[y1, x1, index1] - 1.0) / -1.0);
                break;
              }
              map[y1, x1, index1] = this.textures[index1].heightCurve.Evaluate(time1);
              break;
            case TerrainTexture.Type.SlopeBased:
              map[y1, x1, index1] = this.textures[index1].angleCurve.Evaluate(time2);
              for (int index3 = 0; index3 < index1; ++index3)
                map[y1, x1, index3] *= (float) (((double) map[y1, x1, index1] - 1.0) / -1.0);
              break;
            case TerrainTexture.Type.HeightAndSlopeMixed:
              map[y1, x1, index1] = this.textures[index1].angleCurve.Evaluate(time2) * this.textures[index1].heightCurve.Evaluate(time1);
              for (int index4 = 0; index4 < index1; ++index4)
                map[y1, x1, index4] *= (float) (((double) map[y1, x1, index1] - 1.0) / -1.0);
              break;
            case TerrainTexture.Type.BuildingFoundation:
              for (int index5 = 0; index5 < index1; ++index5)
              {
                if (this.isBuilding[this.counter][y1][x1] == 1)
                {
                  map[y1, x1, index1] = (float) this.isBuilding[this.counter][y1][x1];
                  map[y1, x1, index5] *= (float) (((double) map[y1, x1, index1] - 1.0) / -1.0);
                }
              }
              break;
            case TerrainTexture.Type.EdgeCliff:
              for (int index6 = 0; index6 < index1; ++index6)
              {
                if (this.isBuilding[this.counter][y1][x1] == 2)
                {
                  map[y1, x1, index1] = (float) this.isBuilding[this.counter][y1][x1];
                  map[y1, x1, index6] *= (float) (((double) map[y1, x1, index1] - 1.0) / -1.0);
                }
              }
              break;
            case TerrainTexture.Type.NormalBased:
              if (this.textures[index1].normal == TerrainTexture.NormalDirection.FacingZ)
                map[y1, x1, index1] = this.textures[index1].normalCurve.Evaluate(interpolatedNormal.z);
              else if (this.textures[index1].normal == TerrainTexture.NormalDirection.FacingZ)
                map[y1, x1, index1] = this.textures[index1].normalCurve.Evaluate(interpolatedNormal.z * -1f);
              else if (this.textures[index1].normal == TerrainTexture.NormalDirection.FacingZ)
                map[y1, x1, index1] = this.textures[index1].normalCurve.Evaluate(interpolatedNormal.x);
              else if (this.textures[index1].normal == TerrainTexture.NormalDirection.FacingZ)
                map[y1, x1, index1] = this.textures[index1].normalCurve.Evaluate(interpolatedNormal.x * -1f);
              for (int index7 = 0; index7 < index1; ++index7)
                map[y1, x1, index7] *= (float) (((double) map[y1, x1, index1] - 1.0) / -1.0);
              break;
          }
          if ((double) map[y1, x1, index1] > 1.0)
            map[y1, x1, index1] = 1f;
        }
      }
    }
    terrainData.SetAlphamaps(0, 0, map);
  }

  private float PerlinNoise(int x, int y)
  {
    return Mathf.Pow((float) (((double) Mathf.PerlinNoise(this.LargeNoiseScale * (float) x / (float) this.size, this.LargeNoiseScale * (float) y / (float) this.size) * (double) this.mult - (double) this.LargeSub) * (double) this.LargeHeight / 100.0 + ((double) Mathf.PerlinNoise(this.BigNoiseScale * (float) x / (float) this.size, this.BigNoiseScale * (float) y / (float) this.size) * (double) this.mult - (double) this.BigSub) * (double) this.BigHeight / 100.0 + ((double) Mathf.PerlinNoise(this.MidNoiseScale * (float) x / (float) this.size, this.MidNoiseScale * (float) y / (float) this.size) * (double) this.mult - 0.5 - (double) this.MidSub) * (double) this.MidHeight / 100.0 + ((double) Mathf.PerlinNoise(this.SmallNoiseScale * (float) x / (float) this.size, this.SmallNoiseScale * (float) y / (float) this.size) * (double) this.mult - (double) this.SmallSub) * (double) this.SmallHeight / 100.0), this.Exponent);
  }

  public void GenerateVegetation(Terrain MyTerrain)
  {
    int[][,] numArray = new int[this.Grass.Length][,];
    DetailPrototype[] detailPrototypeArray = new DetailPrototype[this.Grass.Length];
    for (int index = 0; index < detailPrototypeArray.Length; ++index)
      detailPrototypeArray[index] = new DetailPrototype();
    for (int index = 0; index < this.Grass.Length; ++index)
    {
      numArray[index] = new int[this.Terrains[0].terrainData.detailResolution, this.Terrains[0].terrainData.detailResolution];
      detailPrototypeArray[index].prototypeTexture = this.Grass[index];
      detailPrototypeArray[index].minWidth = 0.2f;
      detailPrototypeArray[index].maxWidth = 0.6f;
      detailPrototypeArray[index].minHeight = 0.2f;
      detailPrototypeArray[index].maxHeight = 0.5f;
      detailPrototypeArray[index].healthyColor = this.healthyColor;
      detailPrototypeArray[index].dryColor = this.dryColor;
    }
    MyTerrain.terrainData.detailPrototypes = detailPrototypeArray;
    MyTerrain.terrainData.wavingGrassAmount = 0.05f;
    MyTerrain.terrainData.wavingGrassSpeed = 0.01f;
    MyTerrain.detailObjectDistance = 180f;
    MyTerrain.detailObjectDensity = 1f;
    for (int index1 = 0; index1 < MyTerrain.terrainData.detailResolution; ++index1)
    {
      for (int index2 = 0; index2 < MyTerrain.terrainData.detailResolution; ++index2)
      {
        if (UnityEngine.Random.Range(0, 100) > this.grassDensity)
        {
          for (int index3 = 0; index3 < this.Grass.Length; ++index3)
            numArray[index3][index1, index2] = 0;
        }
        else if ((this.isBuilding[this.counter][index1][index2] > 2 || this.isBuilding[this.counter][index1][index2] == 0) && (double) MyTerrain.terrainData.GetSteepness((float) index2 / (float) this.size, (float) index1 / (float) this.size) < 20.0)
        {
          numArray[(int) ((double) this.Grass.Length * (double) UnityEngine.Random.value - 0.0099999997764825821)][index1, index2] = 6;
        }
        else
        {
          for (int index4 = 0; index4 < this.Grass.Length; ++index4)
            numArray[index4][index1, index2] = 0;
        }
      }
    }
    for (int layer = 0; layer < this.Grass.Length; ++layer)
      MyTerrain.terrainData.SetDetailLayer(0, 0, layer, numArray[layer]);
  }

  public void GenerateBuildings(Terrain MyTerrain)
  {
    int x1 = (int) this.Terrains[0].terrainData.size.x;
    int z1 = (int) this.Terrains[0].terrainData.size.z;
    int num1 = 0;
    int x2 = (int) MyTerrain.transform.position.x;
    int z2 = (int) MyTerrain.transform.position.z;
    float[,] heights = MyTerrain.terrainData.GetHeights(0, 0, this.size, this.size);
    int[][,] numArray = new int[this.Grass.Length][,];
    for (int layer = 0; layer < this.Grass.Length; ++layer)
      numArray[layer] = MyTerrain.terrainData.GetDetailLayer(0, 0, this.size, this.size, layer);
    MyTerrain.terrainData.SetHeights(0, 0, heights);
    MyTerrain.Flush();
    while (num1 <= this.BuildingsPerTerrain)
    {
      int x3 = UnityEngine.Random.Range(x2, x2 + x1);
      int z3 = UnityEngine.Random.Range(z2, z2 + z1);
      float y1 = MyTerrain.terrainData.GetHeight(x3 - x2, z3 - z2) - MyTerrain.transform.parent.transform.position.y;
      if ((double) MyTerrain.terrainData.GetSteepness((float) (x3 - x2) / (float) this.size, (float) (z3 - z2) / (float) this.size) < 30.0 && this.IsFreeToBuild(x3 - x2, z3 - z2, 20))
      {
        float y2 = (float) UnityEngine.Random.Range(0, 360);
        int index1 = UnityEngine.Random.Range(0, this.BuildingObjects.Length);
        for (int index2 = x3 - x2 - 18; index2 < x3 - x2 + 19; ++index2)
        {
          for (int index3 = z3 - z2 - 18; index3 < z3 - z2 + 19; ++index3)
          {
            if (x3 - x2 - 7 < index2 && index2 < x3 - x2 + 7 && z3 - z2 - 7 < index3 && index3 < z3 - z2 + 7)
            {
              heights[index3, index2] = heights[z3 - z2, x3 - x2];
              this.isBuilding[this.counter][index3][index2] = 1;
            }
            else if (this.isBuilding[this.counter][index3][index2] < 1 || this.isBuilding[this.counter][index3][index2] == 4)
            {
              this.dis = 0;
              while (x3 - x2 - (8 + this.dis) >= index2 || index2 >= x3 - x2 + (8 + this.dis) || z3 - z2 - (8 + this.dis) >= index3 || index3 >= z3 - z2 + (8 + this.dis))
                ++this.dis;
              if (this.dis < 10)
              {
                heights[index3, index2] = (float) (((double) heights[index3, index2] * (double) this.dis + (double) heights[z3 - z2, x3 - x2] * (double) (10 - this.dis)) / 10.0);
                this.isBuilding[this.counter][index3][index2] = 4;
              }
            }
          }
        }
        if (this.isBuilding[this.counter][z3 - z2][x3 - x2] == 1)
        {
          GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BuildingObjects[index1], new Vector3((float) x3, y1, (float) z3), Quaternion.Euler(0.0f, y2, 0.0f));
          gameObject.transform.parent = MyTerrain.gameObject.transform;
          gameObject.isStatic = true;
          ++num1;
        }
      }
    }
    int num2 = 0;
    MyTerrain.terrainData.SetHeights(0, 0, heights);
    while (num2 <= this.CoverObjectsPerTerrain)
    {
      int x4 = UnityEngine.Random.Range(x2, x2 + x1);
      int z4 = UnityEngine.Random.Range(z2, z2 + z1);
      float y3 = MyTerrain.terrainData.GetHeight(x4 - x2, z4 - z2) - MyTerrain.transform.parent.transform.position.y;
      if ((double) MyTerrain.terrainData.GetSteepness((float) (x4 - x2) / (float) this.size, (float) (z4 - z2) / (float) this.size) < 20.0 && this.IsFreeToBuild(x4 - x2, z4 - z2, 2))
      {
        float y4 = (float) UnityEngine.Random.Range(0, 360);
        int index4 = UnityEngine.Random.Range(0, this.CoverObjects.Length);
        for (int index5 = x4 - x2 - 3; index5 < x4 - x2 + 3; ++index5)
        {
          for (int index6 = z4 - z2 - 3; index6 < z4 - z2 + 3; ++index6)
          {
            if (x4 - x2 == index5 && z4 - z2 == index6)
            {
              heights[index6, index5] = heights[z4 - z2, x4 - x2];
              this.isBuilding[this.counter][index6][index5] = 3;
            }
            else if (this.isBuilding[this.counter][index6][index5] < 1 || this.isBuilding[this.counter][index6][index5] == 4)
            {
              this.dis = 0;
              while (x4 - x2 - (1 + this.dis) >= index5 || index5 >= x4 - x2 + (1 + this.dis) || z4 - z2 - (1 + this.dis) >= index6 || index6 >= z4 - z2 + (1 + this.dis))
                ++this.dis;
              if (this.dis < 3)
              {
                heights[index6, index5] = (float) (((double) heights[index6, index5] * (double) this.dis + (double) heights[z4 - z2, x4 - x2] * (double) (10 - this.dis)) / 10.0);
                this.isBuilding[this.counter][index6][index5] = 4;
              }
            }
          }
        }
        if (this.isBuilding[this.counter][z4 - z2][x4 - x2] == 3)
        {
          GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.CoverObjects[index4], new Vector3((float) x4, y3, (float) z4), Quaternion.Euler(0.0f, y4, 0.0f));
          gameObject.transform.parent = MyTerrain.gameObject.transform;
          gameObject.isStatic = true;
          ++num2;
        }
      }
    }
    MyTerrain.terrainData.SetHeights(0, 0, heights);
  }

  public bool IsFreeToBuild(int xCord, int yCord, int size)
  {
    for (int index1 = xCord - size - 1; index1 < xCord + size; ++index1)
    {
      for (int index2 = yCord - size - 1; index2 < yCord + size; ++index2)
      {
        if (index1 < size || index1 + size > 513 || index2 < size || index2 + size > 513 || this.isBuilding[this.counter][yCord][xCord] != 0)
          return false;
      }
    }
    return true;
  }

  public string GetSeed()
  {
    return Convert.ToBase64String(Encoding.UTF8.GetBytes($"{this.TerrainCount.ToString()}i{this.CoverObjectsPerTerrain.ToString()}i{this.RandomOffsetSeed.ToString()}i{this.height.ToString()}i{this.grassDensity.ToString()}i{this.BuildingsPerTerrain.ToString()}i{this.LargeHeight.ToString()}i{this.LargeNoiseScale.ToString()}i{this.BigHeight.ToString()}i{this.BigNoiseScale.ToString()}i{this.MidHeight.ToString()}i{this.MidNoiseScale.ToString()}i{this.SmallHeight.ToString()}i{this.SmallNoiseScale.ToString()}i{this.LargeSub.ToString()}i{this.BigSub.ToString()}i{this.MidSub.ToString()}i{this.SmallSub.ToString()}i{this.mult.ToString()}i{this.Exponent.ToString()}i{this.HoloWallHeight.ToString()}"));
  }

  private void RestoreSeed(string Seed)
  {
    Seed = Seed.Trim();
    if (Seed.Length % 4 == 0)
    {
      Seed = Encoding.UTF8.GetString(Convert.FromBase64String(Seed));
      string[] strArray = Seed.Split('i', StringSplitOptions.None);
      this.TerrainCount = int.Parse(strArray[0]);
      this.CoverObjectsPerTerrain = int.Parse(strArray[1]);
      this.RandomOffsetSeed = int.Parse(strArray[2]);
      this.height = int.Parse(strArray[3]);
      this.grassDensity = int.Parse(strArray[4]);
      this.BuildingsPerTerrain = int.Parse(strArray[5]);
      this.LargeHeight = float.Parse(strArray[6]);
      this.LargeNoiseScale = float.Parse(strArray[7]);
      this.BigHeight = float.Parse(strArray[8]);
      this.BigNoiseScale = float.Parse(strArray[9]);
      this.MidHeight = float.Parse(strArray[10]);
      this.MidNoiseScale = float.Parse(strArray[11]);
      this.SmallHeight = float.Parse(strArray[12]);
      this.SmallNoiseScale = float.Parse(strArray[13]);
      this.LargeSub = float.Parse(strArray[14]);
      this.BigSub = float.Parse(strArray[15]);
      this.MidSub = float.Parse(strArray[16 /*0x10*/]);
      this.SmallSub = float.Parse(strArray[17]);
      this.mult = float.Parse(strArray[18]);
      this.Exponent = float.Parse(strArray[19]);
      this.HoloWallHeight = int.Parse(strArray[20]);
    }
    else
      Debug.LogError((object) "<color=cyan>XenoSandbox:</color> Seed has incorrect Length!");
  }

  public enum SandboxSize
  {
    _500x500m,
    _1x1km,
    _2sqkm,
    _4sqkm,
  }
}
