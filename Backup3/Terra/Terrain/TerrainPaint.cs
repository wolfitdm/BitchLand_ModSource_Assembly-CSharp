// Decompiled with JetBrains decompiler
// Type: Terra.Terrain.TerrainPaint
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using Terra.Terrain.Util;
using UnityEngine;

#nullable disable
namespace Terra.Terrain
{
  [ExecuteInEditMode]
  public class TerrainPaint
  {
    public int AlphaMapResolution = 128;
    private GameObject TerrainObject;
    private List<TerrainPaint.SplatSetting> SplatSettings;
    private TerraSettings Settings;
    private MeshSampler Sampler;
    private Material TerrainMaterial;
    private Mesh Mesh;

    public TerrainPaint(GameObject gameobject)
    {
      this.TerrainObject = gameobject;
      this.Settings = TerraSettings.Instance;
      this.SplatSettings = this.Settings.SplatSettings;
      this.SetFirstPassShader();
      this.Mesh = this.TerrainObject.GetComponent<MeshFilter>().sharedMesh;
      this.Sampler = new MeshSampler(this.Mesh.normals, this.Mesh.vertices, (int) Math.Sqrt((double) this.Mesh.vertexCount));
    }

    public List<Texture2D> GenerateSplatmaps(bool applySplats = true)
    {
      this.SetFirstPassShader(true);
      List<Texture2D> textures = new List<Texture2D>();
      for (int index = 0; index < Mathf.CeilToInt((float) this.SplatSettings.Count / 4f); ++index)
        textures.Add(new Texture2D(this.AlphaMapResolution, this.AlphaMapResolution));
      for (int y = 0; y < this.AlphaMapResolution; ++y)
      {
        for (int x = 0; x < this.AlphaMapResolution; ++x)
          this.AddWeightsToTextures(this.CalculateWeights(this.Sampler.SampleAt((float) x / (float) this.AlphaMapResolution, (float) y / (float) this.AlphaMapResolution)), ref textures, x, y);
      }
      textures.ForEach((Action<Texture2D>) (t => t.Apply()));
      if (applySplats)
        this.ApplySplatmapsToShaders(textures);
      return textures;
    }

    private float[] CalculateWeights(MeshSampler.MeshSample sample)
    {
      float height = sample.Height;
      float angle = sample.Angle;
      float[] source = new float[this.SplatSettings.Count];
      Dictionary<TerrainPaint.PlacementType, int> orderMap = new Dictionary<TerrainPaint.PlacementType, int>()
      {
        {
          TerrainPaint.PlacementType.ElevationRange,
          0
        },
        {
          TerrainPaint.PlacementType.Angle,
          1
        }
      };
      List<TerrainPaint.SplatSetting> list = this.SplatSettings.OrderBy<TerrainPaint.SplatSetting, int>((Func<TerrainPaint.SplatSetting, int>) (s => orderMap[s.PlacementType])).ToList<TerrainPaint.SplatSetting>();
      for (int index = 0; index < this.SplatSettings.Count; ++index)
      {
        TerrainPaint.SplatSetting splatSetting = list[index];
        float num1 = splatSetting.IsMinHeight ? float.MinValue : splatSetting.MinRange;
        float num2 = splatSetting.IsMaxHeight ? float.MaxValue : splatSetting.MaxRange;
        switch (splatSetting.PlacementType)
        {
          case TerrainPaint.PlacementType.ElevationRange:
            if ((double) height > (double) num1 && (double) height < (double) num2)
            {
              if (index > 0)
              {
                float num3 = Mathf.Clamp01((splatSetting.Blend - (height - num1)) / splatSetting.Blend);
                source[index - 1] = num3;
                source[index] = 1f - num3;
                break;
              }
              source[index] = 1f;
              break;
            }
            break;
          case TerrainPaint.PlacementType.Angle:
            if ((double) angle > (double) splatSetting.AngleMin && (double) angle < (double) splatSetting.AngleMax)
            {
              float num4 = Mathf.Clamp01((angle - splatSetting.AngleMin) / splatSetting.Blend);
              source[index] = num4;
              break;
            }
            break;
        }
      }
      float num = ((IEnumerable<float>) source).Sum();
      for (int index = 0; index < source.Length; ++index)
        source[index] /= num;
      return source;
    }

    private void AddWeightsToTextures(float[] weights, ref List<Texture2D> textures, int x, int y)
    {
      int length = weights.Length;
      for (int index = 0; index < length; index += 4)
      {
        float weight = weights[index];
        float g = index + 1 < length ? weights[index + 1] : 0.0f;
        float b = index + 2 < length ? weights[index + 2] : 0.0f;
        float a = index + 3 < length ? weights[index + 3] : 0.0f;
        textures[index / 4].SetPixel(x, y, new Color(weight, g, b, a));
      }
    }

    public void ApplySplatmapsToShaders(List<Texture2D> splats)
    {
      int count = this.SplatSettings.Count;
      MeshRenderer component = this.TerrainObject.GetComponent<MeshRenderer>();
      Material mat = this.TerrainMaterial;
      if (this.Settings.UseTessellation)
        this.SetTessellation(mat);
      for (int index = 0; index < splats.Count; ++index)
      {
        if (index != 0)
        {
          mat = new Material(Shader.Find("Hidden/TerrainEngine/Splatmap/Standard-AddPass"));
          component.sharedMaterials = ((IEnumerable<Material>) component.sharedMaterials).Concat<Material>((IEnumerable<Material>) new Material[1]
          {
            mat
          }).ToArray<Material>();
        }
        mat.SetTexture("_Control", (Texture) splats[index]);
        mat.SetTexture("_MainTex", (Texture) splats[0]);
        mat.SetColor("_Color", Color.black);
        if (index * 4 < count)
          this.SetMaterialForSplatIndex(0, this.SplatSettings[index * 4], mat);
        if (index * 4 + 1 < count)
          this.SetMaterialForSplatIndex(1, this.SplatSettings[index * 4 + 1], mat);
        if (index * 4 + 2 < count)
          this.SetMaterialForSplatIndex(2, this.SplatSettings[index * 4 + 2], mat);
        if (index * 4 + 3 < count)
          this.SetMaterialForSplatIndex(3, this.SplatSettings[index * 4 + 3], mat);
      }
    }

    private void SetMaterialForSplatIndex(int index, TerrainPaint.SplatSetting splat, Material mat)
    {
      mat.SetTexture("_Splat" + index.ToString(), (Texture) splat.Diffuse);
      mat.SetTextureScale("_Splat" + index.ToString(), splat.Tiling);
      mat.SetTextureOffset("_Splat" + index.ToString(), splat.Offset);
      mat.SetTexture("_Normal" + index.ToString(), (Texture) splat.Normal);
      mat.SetTextureScale("_Normal" + index.ToString(), splat.Tiling);
      mat.SetTextureOffset("_Normal" + index.ToString(), splat.Offset);
      mat.SetFloat("_Smoothness" + index.ToString(), splat.Smoothness);
    }

    private void SetTessellation(Material mat)
    {
      mat.SetFloat("_TessValue", this.Settings.TessellationAmount);
      mat.SetFloat("_TessMin", this.Settings.TessellationMinDistance);
      mat.SetFloat("_TessMax", this.Settings.TessellationMaxDistance);
    }

    private void SetFirstPassShader(bool overwrite = false)
    {
      string name = this.Settings.UseTessellation ? "Terra/TerrainFirstPassTess" : "Terra/TerrainFirstPass";
      if ((UnityEngine.Object) this.TerrainMaterial == (UnityEngine.Object) null)
      {
        this.TerrainMaterial = this.TerrainObject.GetComponent<MeshRenderer>().material = new Material(Shader.Find(name));
      }
      else
      {
        if (!overwrite)
          return;
        this.TerrainMaterial.shader = Shader.Find(name);
      }
    }

    [Serializable]
    public class SplatSetting
    {
      public Texture2D Diffuse;
      public Texture2D Normal;
      public Vector2 Tiling = new Vector2(1f, 1f);
      public Vector2 Offset;
      public float Smoothness;
      public float Metallic;
      public float Blend = 30f;
      public TerrainPaint.PlacementType PlacementType;
      public float AngleMin = 5f;
      public float AngleMax = 25f;
      public float MinRange;
      public float MaxRange;
      public bool IsMaxHeight;
      public bool IsMinHeight;
    }

    public enum PlacementType
    {
      ElevationRange,
      Angle,
    }
  }
}
