// Decompiled with JetBrains decompiler
// Type: Terra.Terrain.TerrainTile
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using Terra.CoherentNoise;
using Terra.Terrain.Detail;
using UnityEngine;

#nullable disable
namespace Terra.Terrain
{
  public class TerrainTile : MonoBehaviour
  {
    [HideInInspector]
    public bool IsColliderDirty;
    private TerraSettings Settings;

    public Mesh Terrain { get; private set; }

    public Vector2 Position { get; private set; }

    public DetailManager Details { get; private set; }

    private void OnEnable()
    {
      this.Details = new DetailManager(this);
      this.Settings = TerraSettings.Instance;
      if (!((UnityEngine.Object) this.Settings == (UnityEngine.Object) null))
        return;
      Debug.LogError((object) "Cannot find a TerraSettings object in the scene");
    }

    private void Update() => this.Details.Update();

    public static TerrainTile CreateTileGameobject(string name)
    {
      TerrainTile tileGameobject = new GameObject(name).AddComponent<TerrainTile>();
      if ((UnityEngine.Object) tileGameobject.Settings == (UnityEngine.Object) null)
        tileGameobject.Settings = UnityEngine.Object.FindObjectOfType<TerraSettings>();
      if ((UnityEngine.Object) tileGameobject.Settings == (UnityEngine.Object) null)
        Debug.LogError((object) "Cannot find a TerraSettings object in the scene");
      return tileGameobject;
    }

    public static Mesh GetPreviewMesh(TerraSettings settings, Generator gen)
    {
      TerrainTile.MeshData rawMesh = TerrainTile.CreateRawMesh(settings, new Vector2(0.0f, 0.0f), gen);
      return new Mesh()
      {
        vertices = rawMesh.vertices,
        normals = rawMesh.normals,
        uv = rawMesh.uvs,
        triangles = rawMesh.triangles
      };
    }

    public static float PollGenerator(
      float xPos,
      float zPos,
      TerraSettings settings,
      Generator gen)
    {
      float num = (float) (1.0 / ((double) settings.Spread * (double) settings.MeshResolution));
      return gen.GetValue(xPos * num, zPos * num, 0.0f) * settings.Amplitude;
    }

    public void UpdatePosition(Vector2 position)
    {
      this.Position = position;
      int length = this.Settings.Length;
      this.transform.position = new Vector3(position.x * (float) length, 0.0f, position.y * (float) length);
    }

    public void CreateMesh(Vector2 position, bool renderOnCreation = true)
    {
      this.CreateMesh(position, this.Settings.Graph.GetEndGenerator(), renderOnCreation);
    }

    public void CreateMesh(Vector2 position, Generator generator, bool renderOnCreation = true)
    {
      TerraEvent.TriggerOnMeshWillForm(this.gameObject);
      MeshRenderer meshRenderer = this.gameObject.AddComponent<MeshRenderer>();
      meshRenderer.material = new Material(Shader.Find("Diffuse"));
      meshRenderer.enabled = renderOnCreation;
      this.Terrain = this.gameObject.AddComponent<MeshFilter>().mesh;
      TerrainTile.MeshData rawMesh = this.CreateRawMesh(position, generator);
      this.Terrain.vertices = rawMesh.vertices;
      this.Terrain.triangles = rawMesh.triangles;
      this.Terrain.uv = rawMesh.uvs;
      this.Terrain.normals = rawMesh.normals;
      this.UpdatePosition(position);
    }

    public void GenerateCollider()
    {
      if (!((UnityEngine.Object) this.gameObject.GetComponent<MeshCollider>() == (UnityEngine.Object) null) && !this.IsColliderDirty)
        return;
      MeshCollider collider = this.gameObject.AddComponent<MeshCollider>();
      collider.sharedMesh = this.Terrain;
      TerraEvent.TriggerOnMeshColliderDidForm(this.gameObject, collider);
    }

    public void ApplyCustomMaterial()
    {
      TerraEvent.TriggerOnCustomMaterialWillApply(this.gameObject);
      this.GetComponent<MeshRenderer>().sharedMaterial = this.Settings.CustomMaterial;
      TerraEvent.TriggerOnCustomMaterialDidApply(this.gameObject);
    }

    public void ApplyMaterial(Material mat)
    {
      this.GetComponent<MeshRenderer>().sharedMaterial = mat;
    }

    public TerrainTile.MeshData CreateRawMesh(Vector2 position, Generator gen)
    {
      return TerrainTile.CreateRawMesh(this.Settings, position, gen);
    }

    public static TerrainTile.MeshData CreateRawMesh(
      TerraSettings settings,
      Vector2 position,
      Generator gen)
    {
      int meshResolution = settings.MeshResolution;
      float length = (float) settings.Length;
      float num1 = (float) (1.0 / ((double) settings.Spread * (double) settings.MeshResolution));
      Vector3[] verts = new Vector3[meshResolution * meshResolution];
      for (int index1 = 0; index1 < meshResolution; ++index1)
      {
        float z = (float) ((double) index1 / (double) (meshResolution - 1) - 0.5) * length;
        for (int index2 = 0; index2 < meshResolution; ++index2)
        {
          float x = (float) ((double) index2 / (double) (meshResolution - 1) - 0.5) * length;
          float y = gen.GetValue((position.x * length + x) * num1, (position.y * length + z) * num1, 0.0f) * settings.Amplitude;
          verts[index2 + index1 * meshResolution] = new Vector3(x, y, z);
        }
      }
      Vector2[] vector2Array = new Vector2[verts.Length];
      for (int index3 = 0; index3 < meshResolution; ++index3)
      {
        for (int index4 = 0; index4 < meshResolution; ++index4)
          vector2Array[index4 + index3 * meshResolution] = new Vector2((float) index4 / (float) (meshResolution - 1), (float) index3 / (float) (meshResolution - 1));
      }
      int num2 = (meshResolution - 1) * (meshResolution - 1);
      int[] tris = new int[num2 * 6];
      int num3 = 0;
      for (int index5 = 0; index5 < num2; ++index5)
      {
        int num4 = index5 % (meshResolution - 1) + index5 / (meshResolution - 1) * meshResolution;
        int[] numArray1 = tris;
        int index6 = num3;
        int num5 = index6 + 1;
        int num6 = num4 + meshResolution;
        numArray1[index6] = num6;
        int[] numArray2 = tris;
        int index7 = num5;
        int num7 = index7 + 1;
        int num8 = num4 + 1;
        numArray2[index7] = num8;
        int[] numArray3 = tris;
        int index8 = num7;
        int num9 = index8 + 1;
        int num10 = num4;
        numArray3[index8] = num10;
        int[] numArray4 = tris;
        int index9 = num9;
        int num11 = index9 + 1;
        int num12 = num4 + meshResolution;
        numArray4[index9] = num12;
        int[] numArray5 = tris;
        int index10 = num11;
        int num13 = index10 + 1;
        int num14 = num4 + meshResolution + 1;
        numArray5[index10] = num14;
        int[] numArray6 = tris;
        int index11 = num13;
        num3 = index11 + 1;
        int num15 = num4 + 1;
        numArray6[index11] = num15;
      }
      Vector3[] normals = new Vector3[verts.Length];
      TerrainTile.CalculateNormalsManaged(verts, normals, tris);
      return new TerrainTile.MeshData()
      {
        triangles = tris,
        vertices = verts,
        normals = normals,
        uvs = vector2Array
      };
    }

    public void RenderRawMeshData(TerrainTile.MeshData data)
    {
      this.gameObject.AddComponent<MeshRenderer>().material = new Material(Shader.Find("Diffuse"));
      this.Terrain = this.gameObject.AddComponent<MeshFilter>().mesh;
      this.Terrain.vertices = data.vertices;
      this.Terrain.triangles = data.triangles;
      this.Terrain.uv = data.uvs;
      this.Terrain.normals = data.normals;
    }

    private static void CalculateNormalsManaged(Vector3[] verts, Vector3[] normals, int[] tris)
    {
      for (int index = 0; index < tris.Length; index += 3)
      {
        int tri1 = tris[index];
        int tri2 = tris[index + 1];
        int tri3 = tris[index + 2];
        Vector3 vert1 = verts[tri1];
        Vector3 vert2 = verts[tri2];
        Vector3 vert3 = verts[tri3];
        Vector3 vector3 = new Vector3()
        {
          x = (float) ((double) vert1.y * (double) vert2.z - (double) vert1.y * (double) vert3.z - (double) vert2.y * (double) vert1.z + (double) vert2.y * (double) vert3.z + (double) vert3.y * (double) vert1.z - (double) vert3.y * (double) vert2.z),
          y = (float) (-(double) vert1.x * (double) vert2.z + (double) vert1.x * (double) vert3.z + (double) vert2.x * (double) vert1.z - (double) vert2.x * (double) vert3.z - (double) vert3.x * (double) vert1.z + (double) vert3.x * (double) vert2.z),
          z = (float) ((double) vert1.x * (double) vert2.y - (double) vert1.x * (double) vert3.y - (double) vert2.x * (double) vert1.y + (double) vert2.x * (double) vert3.y + (double) vert3.x * (double) vert1.y - (double) vert3.x * (double) vert2.y)
        };
        normals[tri1] += vector3;
        normals[tri2] += vector3;
        normals[tri3] += vector3;
      }
      for (int index = 0; index < normals.Length; ++index)
      {
        Vector3 normal = normals[index];
        float num = 1f / (float) Math.Sqrt((double) normal.x * (double) normal.x + (double) normal.y * (double) normal.y + (double) normal.z * (double) normal.z);
        normals[index].x = normal.x * num;
        normals[index].y = normal.y * num;
        normals[index].z = normal.z * num;
      }
    }

    public struct MeshData
    {
      public Vector3[] vertices;
      public Vector3[] normals;
      public Vector2[] uvs;
      public int[] triangles;
    }
  }
}
