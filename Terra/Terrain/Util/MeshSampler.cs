// Decompiled with JetBrains decompiler
// Type: Terra.Terrain.Util.MeshSampler
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace Terra.Terrain.Util;

internal class MeshSampler
{
  private Vector3[] Normals;
  private Vector3[] Vertices;
  private int MeshResolution;

  public MeshSampler(Vector3[] normals, Vector3[] vertices, int resolution)
  {
    this.Normals = normals;
    this.Vertices = vertices;
    this.MeshResolution = resolution;
  }

  public MeshSampler(Mesh m, int resolution)
  {
    this.Normals = m.normals;
    this.Vertices = m.vertices;
    this.MeshResolution = resolution;
  }

  public MeshSampler.MeshSample SampleAt(float x, float z)
  {
    float meshResolution = (float) this.MeshResolution;
    int index = Mathf.RoundToInt(Mathf.Clamp(x * meshResolution, 0.0f, meshResolution - 1f)) + Mathf.RoundToInt(Mathf.Clamp(z * meshResolution, 0.0f, meshResolution - 1f)) * this.MeshResolution;
    return new MeshSampler.MeshSample(this.Vertices[index].y, Vector3.Angle(this.Normals[index], Vector3.up));
  }

  public class MeshSample
  {
    public readonly float Height;
    public readonly float Angle;

    public MeshSample(float height = 0.0f, float angle = 0.0f)
    {
      this.Height = height;
      this.Angle = angle;
    }
  }
}
