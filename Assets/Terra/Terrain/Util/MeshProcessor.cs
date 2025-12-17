// Decompiled with JetBrains decompiler
// Type: Assets.Terra.Terrain.Util.MeshProcessor
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Assets.Terra.Terrain.Util;

internal class MeshProcessor
{
  public static Mesh Process(Mesh mesh)
  {
    List<Vector3> vector3List1 = new List<Vector3>((IEnumerable<Vector3>) mesh.vertices);
    List<Vector2> uvs1 = new List<Vector2>(vector3List1.Count);
    List<Vector4> uvs2 = new List<Vector4>(vector3List1.Count);
    List<Vector4> uvs3 = new List<Vector4>(vector3List1.Count);
    List<Vector4> uvs4 = new List<Vector4>(vector3List1.Count);
    mesh.GetUVs(0, uvs1);
    mesh.GetUVs(1, uvs2);
    mesh.GetUVs(2, uvs3);
    mesh.GetUVs(3, uvs4);
    List<Vector3> vector3List2 = new List<Vector3>((IEnumerable<Vector3>) mesh.normals);
    List<Vector4> vector4List = new List<Vector4>((IEnumerable<Vector4>) mesh.tangents);
    List<int> intList = new List<int>((IEnumerable<int>) mesh.triangles);
    List<Color> colorList = new List<Color>(vector3List1.Count);
    for (int index = 0; index < vector3List1.Count; ++index)
      colorList.Add(Color.black);
    Color[] colorArray = new Color[3]
    {
      Color.red,
      Color.green,
      Color.blue
    };
    bool[] flagArray = new bool[3];
    int count1 = intList.Count;
    for (int index1 = 0; index1 < count1; index1 += 3)
    {
      flagArray[0] = false;
      flagArray[1] = false;
      flagArray[2] = false;
      int[] numArray = new int[3]
      {
        intList[index1],
        intList[index1 + 1],
        intList[index1 + 2]
      };
      for (int index2 = 0; index2 < 3; ++index2)
      {
        int index3 = numArray[index2];
        Color color = colorList[index3];
        if (color == Color.red)
          flagArray[0] = true;
        else if (color == Color.green)
          flagArray[1] = true;
        else if (color == Color.blue)
          flagArray[2] = true;
      }
      for (int index4 = 0; index4 < 3; ++index4)
      {
        int index5 = numArray[index4];
        if (colorList[index5] == Color.black)
        {
          for (int index6 = 0; index6 < 3; ++index6)
          {
            if (!flagArray[index6])
            {
              flagArray[index6] = true;
              colorList[index5] = colorArray[index6];
              break;
            }
          }
        }
      }
      for (int index7 = 0; index7 < 3; ++index7)
      {
        int index8 = numArray[index7];
        Color color1 = colorList[index8];
        Color color2 = colorList[numArray[0]];
        Color color3 = colorList[numArray[1]];
        Color color4 = colorList[numArray[2]];
        if (color1 == Color.black || index7 == 0 && (color1 == color3 || color1 == color4) || index7 == 1 && (color1 == color2 || color1 == color4) || index7 == 2 && (color1 == color2 || color1 == color3))
        {
          int count2 = vector3List1.Count;
          int count3 = vector3List1.Count;
          vector3List1.Add(vector3List1[index8]);
          intList[index1 + index7] = count3;
          if (vector3List2 != null && vector3List2.Count == count2)
            vector3List2.Add(vector3List2[index8]);
          if (vector4List != null && vector4List.Count == count2)
            vector4List.Add(vector4List[index8]);
          if (uvs1 != null && uvs1.Count == count2)
            uvs1.Add(uvs1[index8]);
          if (uvs2 != null && uvs2.Count == count2)
            uvs2.Add(uvs2[index8]);
          if (uvs3 != null && uvs3.Count == count2)
            uvs3.Add(uvs3[index8]);
          if (uvs4 != null && uvs4.Count == count2)
            uvs4.Add(uvs4[index8]);
          Color color5 = Color.red;
          if (color2 == color5 || color3 == color5 || color4 == color5)
          {
            color5 = Color.green;
            if (color2 == color5 || color3 == color5 || color4 == color5)
              color5 = Color.blue;
          }
          numArray[index7] = count3;
          colorList.Add(color5);
        }
      }
    }
    if (vector3List1.Count == 65533)
    {
      Debug.LogError((object) $"Resulting Mesh {mesh.name} is over vertex limit, please use a mesh with less vertices\n{mesh.vertexCount.ToString()}->{vector3List1.Count.ToString()}");
      return (Mesh) null;
    }
    Mesh mesh1 = new Mesh();
    mesh1.Clear();
    mesh1.vertices = vector3List1.ToArray();
    mesh1.SetUVs(0, uvs1);
    if (uvs2 != null && uvs2.Count > 0)
      mesh1.SetUVs(1, uvs2);
    if (uvs3 != null && uvs3.Count > 0)
      mesh1.SetUVs(2, uvs2);
    if (uvs4 != null && uvs4.Count > 0)
      mesh1.SetUVs(3, uvs2);
    mesh1.triangles = intList.ToArray();
    mesh1.colors = colorList.ToArray();
    mesh1.normals = vector3List2.ToArray();
    mesh1.tangents = vector4List.ToArray();
    mesh1.name = mesh.name;
    mesh1.RecalculateBounds();
    mesh1.UploadMeshData(false);
    return mesh1;
  }
}
