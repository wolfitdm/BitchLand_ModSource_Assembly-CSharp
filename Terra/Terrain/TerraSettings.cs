// Decompiled with JetBrains decompiler
// Type: Terra.Terrain.TerraSettings
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using Terra.Graph.Noise;
using UnityEngine;

#nullable disable
namespace Terra.Terrain
{
  [ExecuteInEditMode]
  [Serializable]
  public class TerraSettings : MonoBehaviour
  {
    private static TerraSettings _instance;
    public TerraSettings.ToolbarOptions ToolbarSelection;
    public GameObject TrackedObject;
    public bool GenerateOnStart = true;
    public int GenerationRadius = 3;
    public float ColliderGenerationExtent = 50f;
    public static int GenerationSeed = 1337;
    public int MeshResolution = 128;
    public int Length = 500;
    public bool UseRandomSeed;
    public bool GenAllColliders;
    public bool DisplayPreview;
    public bool UseMultithreading = true;
    public NoiseGraph Graph;
    public float Spread = 100f;
    public float Amplitude = 50f;
    public List<TerrainPaint.SplatSetting> SplatSettings = new List<TerrainPaint.SplatSetting>();
    public float TessellationAmount = 4f;
    public float TessellationMinDistance = 5f;
    public float TessellationMaxDistance = 30f;
    public bool UseTessellation = true;
    public bool IsAdvancedFoldout;
    public bool IsMaxHeightSelected;
    public bool IsMinHeightSelected;
    public bool UseCustomMaterial;
    public Material CustomMaterial;
    public bool PlaceGrass;
    public float GrassStepLength = 1.5f;
    public float GrassVariation = 0.8f;
    public float GrassHeight = 1.5f;
    public float BillboardDistance = 75f;
    public float ClipCutoff = 0.25f;
    public bool GrassConstrainHeight;
    public float GrassMinHeight;
    public float GrassMaxHeight = 200f;
    public bool GrassConstrainAngle;
    public float GrassAngleMin;
    public float GrassAngleMax = 25f;
    public Texture2D GrassTexture;
    public List<ObjectPlacementType> ObjectPlacementSettings = new List<ObjectPlacementType>();
    public TilePool Pool;
    public TerrainPreview Preview;

    public static TerraSettings Instance
    {
      get
      {
        if ((UnityEngine.Object) TerraSettings._instance != (UnityEngine.Object) null)
          return TerraSettings._instance;
        TerraSettings._instance = UnityEngine.Object.FindObjectOfType<TerraSettings>();
        return TerraSettings._instance;
      }
    }

    private void Awake()
    {
      this.Pool = new TilePool();
      this.Preview = new TerrainPreview();
    }

    private void Start()
    {
      this.CreateMTD();
      if (!this.GenerateOnStart)
        return;
      this.Generate();
    }

    private void Update()
    {
      if (!Application.isPlaying || this.Pool == null || !this.GenerateOnStart)
        return;
      this.Pool.Update();
    }

    private void OnDrawGizmosSelected()
    {
      foreach (Vector2 positionsFromRadiu in TilePool.GetTilePositionsFromRadius(this.GenerationRadius, this.transform.position, this.Length))
      {
        Vector3 center = new Vector3(positionsFromRadiu.x * (float) this.Length, 0.0f, positionsFromRadiu.y * (float) this.Length);
        Gizmos.color = Color.white;
        Vector3 size = new Vector3((float) this.Length, 0.0f, (float) this.Length);
        Gizmos.DrawWireCube(center, size);
      }
      if (!((UnityEngine.Object) this.TrackedObject != (UnityEngine.Object) null))
        return;
      Vector3 position = this.TrackedObject.transform.position;
      Vector3 center1 = new Vector3(position.x, 0.0f, position.z);
      Gizmos.color = Color.blue;
      Vector3 size1 = new Vector3(this.ColliderGenerationExtent, 0.0f, this.ColliderGenerationExtent);
      Gizmos.DrawWireCube(center1, size1);
    }

    private void CreateMTD()
    {
      if (!((UnityEngine.Object) UnityEngine.Object.FindObjectOfType<MTDispatch>() == (UnityEngine.Object) null))
        return;
      GameObject gameObject = new GameObject("Main Thread Dispatch");
      gameObject.AddComponent<MTDispatch>();
      gameObject.transform.parent = this.transform;
    }

    public void Generate()
    {
      this.CreateMTD();
      if (Application.isPlaying)
      {
        this.Preview.Cleanup();
        if ((UnityEngine.Object) this.TrackedObject == (UnityEngine.Object) null)
          this.TrackedObject = Camera.main.gameObject;
        if (!this.UseRandomSeed)
          UnityEngine.Random.InitState(TerraSettings.GenerationSeed);
        else
          TerraSettings.GenerationSeed = new System.Random().Next(0, int.MaxValue);
      }
      this.GenerateOnStart = true;
    }

    [Serializable]
    public enum ToolbarOptions
    {
      General,
      Noise,
      Materials,
      ObjectPlacement,
    }
  }
}
