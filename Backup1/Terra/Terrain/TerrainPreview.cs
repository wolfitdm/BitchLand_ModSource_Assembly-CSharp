// Decompiled with JetBrains decompiler
// Type: Terra.Terrain.TerrainPreview
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Terra.Terrain
{
  public class TerrainPreview
  {
    private TerraSettings Settings;
    private TerrainPaint Paint;
    private List<Texture2D> Splats;

    public TerrainPreview() => this.Settings = TerraSettings.Instance;

    public bool CanPreview()
    {
      return this.Settings.DisplayPreview && (Object) this.Settings.Graph != (Object) null && this.Settings.Graph.GetEndGenerator() != null && this.Settings.Preview != null;
    }

    public void TriggerPreviewUpdate()
    {
      if (!this.Settings.DisplayPreview)
        return;
      this.RemoveComponents();
      this.AddComponents();
    }

    public void TriggerMaterialsUpdate()
    {
      if (!this.Settings.DisplayPreview)
        return;
      this.Splats = (List<Texture2D>) null;
      this.Paint = (TerrainPaint) null;
      if ((Object) this.Settings.GetComponent<MeshRenderer>() != (Object) null)
        Object.DestroyImmediate((Object) this.Settings.GetComponent<MeshRenderer>());
      this.AddMaterialComponent();
    }

    public void TriggerObjectPlacementUpdate()
    {
      if (!this.Settings.DisplayPreview || !this.HasMesh())
        return;
      new ObjectPlacerPreview(this.Settings, this.Settings.GetComponent<MeshFilter>().sharedMesh).PreviewAllObjects();
    }

    public bool HasMesh()
    {
      return (Object) this.Settings.GetComponent<MeshFilter>() != (Object) null && (Object) this.Settings.GetComponent<MeshFilter>().sharedMesh != (Object) null;
    }

    public bool HasEndGenerator() => this.Settings.Graph.GetEndGenerator() != null;

    public void RemoveComponents()
    {
      if ((Object) this.Settings.GetComponent<MeshRenderer>() != (Object) null)
        Object.DestroyImmediate((Object) this.Settings.GetComponent<MeshRenderer>());
      if (!((Object) this.Settings.GetComponent<MeshFilter>() != (Object) null))
        return;
      Object.DestroyImmediate((Object) this.Settings.GetComponent<MeshFilter>());
    }

    public void Cleanup()
    {
      if ((Object) this.Settings.GetComponent<MeshRenderer>() != (Object) null)
        Object.Destroy((Object) this.Settings.GetComponent<MeshRenderer>());
      if ((Object) this.Settings.GetComponent<MeshFilter>() != (Object) null)
        Object.Destroy((Object) this.Settings.GetComponent<MeshFilter>());
      foreach (Transform transform in this.Settings.transform)
      {
        if (transform.name == ObjectPlacerPreview.OBJ_PREVIEW_NAME)
        {
          Object.Destroy((Object) transform.gameObject);
          break;
        }
      }
    }

    private Mesh CreateMesh()
    {
      return (Object) this.Settings.Graph != (Object) null && this.Settings.Graph.GetEndGenerator() != null ? TerrainTile.GetPreviewMesh(this.Settings, this.Settings.Graph.GetEndGenerator()) : (Mesh) null;
    }

    private List<Texture2D> CreateSplats()
    {
      if (this.Settings.SplatSettings == null)
        return (List<Texture2D>) null;
      if (this.Paint == null)
        this.Paint = new TerrainPaint(this.Settings.gameObject);
      List<Texture2D> splatmaps = this.Paint.GenerateSplatmaps(false);
      return splatmaps.Count <= 0 ? (List<Texture2D>) null : splatmaps;
    }

    private void AddComponents()
    {
      this.TriggerMeshUpdate();
      this.TriggerMaterialsUpdate();
      this.TriggerObjectPlacementUpdate();
      this.TriggerHideInInspectorUpdate();
    }

    private void AddMaterialComponent()
    {
      if (!((Object) this.Settings.GetComponent<MeshRenderer>() == (Object) null))
        return;
      MeshRenderer meshRenderer = this.Settings.gameObject.AddComponent<MeshRenderer>();
      if (this.Settings.UseCustomMaterial && (Object) this.Settings.CustomMaterial != (Object) null)
      {
        meshRenderer.sharedMaterial = this.Settings.CustomMaterial;
      }
      else
      {
        if (this.Splats != null && this.Splats.Count > 0)
          this.Paint.ApplySplatmapsToShaders(this.Splats);
        else if (this.Settings.SplatSettings != null)
        {
          this.Splats = this.CreateSplats();
          if (this.Splats != null)
            this.Paint.ApplySplatmapsToShaders(this.Splats);
        }
        if (this.Splats != null && this.Splats.Count != 0)
          return;
        meshRenderer.material = new Material(Shader.Find("Nature/Terrain/Standard"));
      }
    }

    private void TriggerMeshUpdate()
    {
      if (!((Object) this.Settings.GetComponent<MeshFilter>() == (Object) null) || !this.HasEndGenerator())
        return;
      MeshFilter meshFilter = this.Settings.gameObject.AddComponent<MeshFilter>();
      if (!((Object) this.CreateMesh() != (Object) null))
        return;
      meshFilter.sharedMesh = this.CreateMesh();
    }

    private void TriggerHideInInspectorUpdate()
    {
      MeshFilter component1 = this.Settings.GetComponent<MeshFilter>();
      MeshRenderer component2 = this.Settings.GetComponent<MeshRenderer>();
      HideFlags hideFlags = HideFlags.HideInInspector;
      if (hideFlags == HideFlags.HideInInspector)
      {
        if ((Object) component1 != (Object) null)
          component1.hideFlags = hideFlags;
        if (!((Object) component2 != (Object) null))
          return;
        component2.hideFlags = hideFlags;
        if (!((Object) component2.sharedMaterial != (Object) null))
          return;
        component2.sharedMaterial.hideFlags = hideFlags;
      }
      else
      {
        foreach (Object component3 in this.Settings.GetComponents<Component>())
          component3.hideFlags = HideFlags.None;
      }
    }
  }
}
