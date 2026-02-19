// Decompiled with JetBrains decompiler
// Type: Peace.Assets
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

#nullable disable
namespace Peace
{
  public static class Assets
  {
    private const int IM_GREY = 1;
    private const int IM_RGB = 3;
    private const int IM_RGBA = 4;

    public static Mesh GetMesh(IntPtr handle)
    {
      int vertSize = 0;
      int indicesSize = 0;
      Assets.readMeshSizes(handle, ref vertSize, ref indicesSize);
      double[] vertices = new double[vertSize];
      int[] numArray = new int[indicesSize];
      Assets.readMesh(handle, vertices, numArray);
      int length = vertSize / 8;
      Vector3[] vector3Array1 = new Vector3[length];
      Vector3[] vector3Array2 = new Vector3[length];
      Vector2[] vector2Array = new Vector2[length];
      for (int index = 0; index < length; ++index)
      {
        vector3Array1[index] = new Vector3((float) vertices[index * 8], (float) vertices[index * 8 + 2], (float) vertices[index * 8 + 1]);
        vector3Array2[index] = new Vector3((float) vertices[index * 8 + 3], (float) vertices[index * 8 + 5], (float) vertices[index * 8 + 4]);
        vector2Array[index] = new Vector2((float) vertices[index * 8 + 6], 1f - (float) vertices[index * 8 + 7]);
      }
      return new Mesh()
      {
        vertices = vector3Array1,
        normals = vector3Array2,
        uv = vector2Array,
        triangles = ((IEnumerable<int>) numArray).Reverse<int>().ToArray<int>()
      };
    }

    public static Material GetMaterial(IntPtr handle)
    {
      Assets.MaterialDescription materialDescription = Assets.readMaterial(handle);
      Material material = new Material(Shader.Find("Standard"));
      material.color = new Color((float) materialDescription.Kdr, (float) materialDescription.Kdg, (float) materialDescription.Kdb);
      material.SetFloat("_Glossiness", 0.0f);
      material.EnableKeyword("_SPECGLOSSMAP");
      if (materialDescription.transparent)
      {
        material.SetInt("_SrcBlend", 1);
        material.SetInt("_DstBlend", 0);
        material.SetInt("_ZWrite", 1);
        material.EnableKeyword("_ALPHATEST_ON");
        material.DisableKeyword("_ALPHABLEND_ON");
        material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
      }
      return material;
    }

    public static string GetMaterialTexture(IntPtr handle) => Assets.readMaterial(handle).MapKd;

    public static Texture2D GetTexture(IntPtr handle)
    {
      IntPtr zero = IntPtr.Zero;
      int width = 0;
      int height = 0;
      int type = 0;
      Assets.readTexture(handle, ref zero, ref width, ref height, ref type);
      TextureFormat textureFormat;
      switch (type)
      {
        case 1:
          textureFormat = TextureFormat.R8;
          break;
        case 3:
          textureFormat = TextureFormat.RGB24;
          break;
        case 4:
          textureFormat = TextureFormat.RGBA32;
          break;
        default:
          throw new DataException("Image type not supported: " + type.ToString());
      }
      Texture2D texture = new Texture2D(width, height, textureFormat, false);
      int length = width * height * type;
      byte[] rawTextureData = texture.GetRawTextureData();
      Marshal.Copy(zero, rawTextureData, 0, length);
      texture.LoadRawTextureData(rawTextureData);
      texture.Apply();
      return texture;
    }

    [DllImport("peace")]
    private static extern void readMeshSizes(IntPtr meshPtr, ref int vertSize, ref int indicesSize);

    [DllImport("peace")]
    private static extern void readMesh(IntPtr meshPtr, [In, Out] double[] vertices, [In, Out] int[] indices);

    [DllImport("peace")]
    private static extern Assets.MaterialDescription readMaterial(IntPtr materialPtr);

    [DllImport("peace")]
    private static extern string materialGetCustomMap(IntPtr materialPtr, string mapName);

    [DllImport("peace")]
    private static extern void readTexture(
      IntPtr texturePtr,
      ref IntPtr data,
      ref int width,
      ref int height,
      ref int type);

    private struct MaterialDescription
    {
      public string MapKd;
      public double Kdr;
      public double Kdg;
      public double Kdb;
      public double Ksr;
      public double Ksg;
      public double Ksb;
      public bool transparent;
    }
  }
}
