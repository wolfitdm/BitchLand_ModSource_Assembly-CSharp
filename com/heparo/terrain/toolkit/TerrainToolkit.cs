// Decompiled with JetBrains decompiler
// Type: com.heparo.terrain.toolkit.TerrainToolkit
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

#nullable disable
namespace com.heparo.terrain.toolkit
{
  [ExecuteInEditMode]
  [AddComponentMenu("Terrain/Terrain Toolkit")]
  public class TerrainToolkit : MonoBehaviour
  {
    public const string EMPTY = "";
    public const string TERRAIN_LAYER_EXTENSION = ".terrainlayer";
    public const string TERRAIN_LAYER_PREFIX = "Layer_";
    public const string TOOLKIT_LAYERS_FOLDER = "TerrainToolkitLayers";
    public const string TERRAIN_LAYERS_FOLDER = "_Layers";
    private TerrainToolkit.ErosionMode p_erosionMode;
    private TerrainToolkit.ErosionType p_erosionType;
    private TerrainToolkit.GeneratorType p_generatorType;
    private TerrainToolkit.Neighbourhood p_neighbourhood;
    private TerrainToolkit.HydraulicType p_hydraulicType;
    private TerrainToolkit.VoronoiType p_voronoiType;
    public int toolModeInt;
    public int erosionTypeInt;
    public int generatorTypeInt;
    public bool isBrushOn;
    public bool isBrushHidden;
    public bool isBrushPainting;
    public Vector3 brushPosition;
    public float brushSize = 50f;
    public float brushOpacity = 1f;
    public float brushSoftness = 0.5f;
    public int neighbourhoodInt;
    public bool useDifferenceMaps = true;
    public int thermalIterations = 25;
    public float thermalMinSlope = 1f;
    public float thermalFalloff = 0.5f;
    public int hydraulicTypeInt;
    public int hydraulicIterations = 25;
    public float hydraulicMaxSlope = 60f;
    public float hydraulicFalloff = 0.5f;
    public float hydraulicRainfall = 0.01f;
    public float hydraulicEvaporation = 0.5f;
    public float hydraulicSedimentSolubility = 0.01f;
    public float hydraulicSedimentSaturation = 0.1f;
    public float hydraulicVelocityRainfall = 0.01f;
    public float hydraulicVelocityEvaporation = 0.5f;
    public float hydraulicVelocitySedimentSolubility = 0.01f;
    public float hydraulicVelocitySedimentSaturation = 0.1f;
    public float hydraulicVelocity = 20f;
    public float hydraulicMomentum = 1f;
    public float hydraulicEntropy;
    public float hydraulicDowncutting = 0.1f;
    public int tidalIterations = 25;
    public float tidalSeaLevel = 50f;
    public float tidalRangeAmount = 5f;
    public float tidalCliffLimit = 60f;
    public int windIterations = 25;
    public float windDirection;
    public float windForce = 0.5f;
    public float windLift = 0.01f;
    public float windGravity = 0.5f;
    public float windCapacity = 0.01f;
    public float windEntropy = 0.1f;
    public float windSmoothing = 0.25f;
    public TerrainLayer[] terrainLayers;
    public float slopeBlendMinAngle = 60f;
    public float slopeBlendMaxAngle = 75f;
    public List<float> heightBlendPoints;
    public string[] gradientStyles;
    public int voronoiTypeInt;
    public int voronoiCells = 16;
    public float voronoiFeatures = 1f;
    public float voronoiScale = 1f;
    public float voronoiBlend = 1f;
    public float diamondSquareDelta = 0.5f;
    public float diamondSquareBlend = 1f;
    public int perlinFrequency = 4;
    public float perlinAmplitude = 1f;
    public int perlinOctaves = 8;
    public float perlinBlend = 1f;
    public float smoothBlend = 1f;
    public int smoothIterations;
    public float normaliseMin;
    public float normaliseMax = 1f;
    public float normaliseBlend = 1f;
    public ArrayList voronoiPresets = new ArrayList();
    public ArrayList fractalPresets = new ArrayList();
    public ArrayList perlinPresets = new ArrayList();
    public ArrayList thermalErosionPresets = new ArrayList();
    public ArrayList fastHydraulicErosionPresets = new ArrayList();
    public ArrayList fullHydraulicErosionPresets = new ArrayList();
    public ArrayList velocityHydraulicErosionPresets = new ArrayList();
    public ArrayList tidalErosionPresets = new ArrayList();
    public ArrayList windErosionPresets = new ArrayList();
    [NonSerialized]
    public bool presetsInitialised;
    [NonSerialized]
    public int voronoiPresetId;
    [NonSerialized]
    public int fractalPresetId;
    [NonSerialized]
    public int perlinPresetId;
    [NonSerialized]
    public int thermalErosionPresetId;
    [NonSerialized]
    public int fastHydraulicErosionPresetId;
    [NonSerialized]
    public int fullHydraulicErosionPresetId;
    [NonSerialized]
    public int velocityHydraulicErosionPresetId;
    [NonSerialized]
    public int tidalErosionPresetId;
    [NonSerialized]
    public int windErosionPresetId;
    private string layersPath = "";
    private string assetPath = "";

    public void addPresets()
    {
      this.presetsInitialised = true;
      this.voronoiPresets = new ArrayList();
      this.fractalPresets = new ArrayList();
      this.perlinPresets = new ArrayList();
      this.thermalErosionPresets = new ArrayList();
      this.fastHydraulicErosionPresets = new ArrayList();
      this.fullHydraulicErosionPresets = new ArrayList();
      this.velocityHydraulicErosionPresets = new ArrayList();
      this.tidalErosionPresets = new ArrayList();
      this.windErosionPresets = new ArrayList();
      this.voronoiPresets.Add((object) new TerrainToolkit.voronoiPresetData("Scattered Peaks", TerrainToolkit.VoronoiType.Linear, 16, 8f, 0.5f, 1f));
      this.voronoiPresets.Add((object) new TerrainToolkit.voronoiPresetData("Rolling Hills", TerrainToolkit.VoronoiType.Sine, 8, 8f, 0.0f, 1f));
      this.voronoiPresets.Add((object) new TerrainToolkit.voronoiPresetData("Jagged Mountains", TerrainToolkit.VoronoiType.Linear, 32, 32f, 0.5f, 1f));
      this.fractalPresets.Add((object) new TerrainToolkit.fractalPresetData("Rolling Plains", 0.4f, 1f));
      this.fractalPresets.Add((object) new TerrainToolkit.fractalPresetData("Rough Mountains", 0.5f, 1f));
      this.fractalPresets.Add((object) new TerrainToolkit.fractalPresetData("Add Noise", 0.75f, 0.05f));
      this.perlinPresets.Add((object) new TerrainToolkit.perlinPresetData("Rough Plains", 2, 0.5f, 9, 1f));
      this.perlinPresets.Add((object) new TerrainToolkit.perlinPresetData("Rolling Hills", 5, 0.75f, 3, 1f));
      this.perlinPresets.Add((object) new TerrainToolkit.perlinPresetData("Rocky Mountains", 4, 1f, 8, 1f));
      this.perlinPresets.Add((object) new TerrainToolkit.perlinPresetData("Hellish Landscape", 11, 1f, 7, 1f));
      this.perlinPresets.Add((object) new TerrainToolkit.perlinPresetData("Add Noise", 10, 1f, 8, 0.2f));
      this.thermalErosionPresets.Add((object) new TerrainToolkit.thermalErosionPresetData("Gradual, Weak Erosion", 25, 7.5f, 0.5f));
      this.thermalErosionPresets.Add((object) new TerrainToolkit.thermalErosionPresetData("Fast, Harsh Erosion", 25, 2.5f, 0.1f));
      this.thermalErosionPresets.Add((object) new TerrainToolkit.thermalErosionPresetData("Thermal Erosion Brush", 25, 0.1f, 0.0f));
      this.fastHydraulicErosionPresets.Add((object) new TerrainToolkit.fastHydraulicErosionPresetData("Rainswept Earth", 25, 70f, 1f));
      this.fastHydraulicErosionPresets.Add((object) new TerrainToolkit.fastHydraulicErosionPresetData("Terraced Slopes", 25, 30f, 0.4f));
      this.fastHydraulicErosionPresets.Add((object) new TerrainToolkit.fastHydraulicErosionPresetData("Hydraulic Erosion Brush", 25, 85f, 1f));
      this.fullHydraulicErosionPresets.Add((object) new TerrainToolkit.fullHydraulicErosionPresetData("Low Rainfall, Hard Rock", 25, 0.01f, 0.5f, 0.01f, 0.1f));
      this.fullHydraulicErosionPresets.Add((object) new TerrainToolkit.fullHydraulicErosionPresetData("Low Rainfall, Soft Earth", 25, 0.01f, 0.5f, 0.06f, 0.15f));
      this.fullHydraulicErosionPresets.Add((object) new TerrainToolkit.fullHydraulicErosionPresetData("Heavy Rainfall, Hard Rock", 25, 0.02f, 0.5f, 0.01f, 0.1f));
      this.fullHydraulicErosionPresets.Add((object) new TerrainToolkit.fullHydraulicErosionPresetData("Heavy Rainfall, Soft Earth", 25, 0.02f, 0.5f, 0.06f, 0.15f));
      this.velocityHydraulicErosionPresets.Add((object) new TerrainToolkit.velocityHydraulicErosionPresetData("Low Rainfall, Hard Rock", 25, 0.01f, 0.5f, 0.01f, 0.1f, 1f, 1f, 0.05f, 0.12f));
      this.velocityHydraulicErosionPresets.Add((object) new TerrainToolkit.velocityHydraulicErosionPresetData("Low Rainfall, Soft Earth", 25, 0.01f, 0.5f, 0.06f, 0.15f, 1.2f, 2.8f, 0.05f, 0.12f));
      this.velocityHydraulicErosionPresets.Add((object) new TerrainToolkit.velocityHydraulicErosionPresetData("Heavy Rainfall, Hard Rock", 25, 0.02f, 0.5f, 0.01f, 0.1f, 1.1f, 2.2f, 0.05f, 0.12f));
      this.velocityHydraulicErosionPresets.Add((object) new TerrainToolkit.velocityHydraulicErosionPresetData("Heavy Rainfall, Soft Earth", 25, 0.02f, 0.5f, 0.06f, 0.15f, 1.2f, 2.4f, 0.05f, 0.12f));
      this.velocityHydraulicErosionPresets.Add((object) new TerrainToolkit.velocityHydraulicErosionPresetData("Carved Stone", 25, 0.01f, 0.5f, 0.01f, 0.1f, 2f, 1.25f, 0.05f, 0.35f));
      this.tidalErosionPresets.Add((object) new TerrainToolkit.tidalErosionPresetData("Low Tidal Range, Calm Waves", 25, 5f, 65f));
      this.tidalErosionPresets.Add((object) new TerrainToolkit.tidalErosionPresetData("Low Tidal Range, Strong Waves", 25, 5f, 35f));
      this.tidalErosionPresets.Add((object) new TerrainToolkit.tidalErosionPresetData("High Tidal Range, Calm Water", 25, 15f, 55f));
      this.tidalErosionPresets.Add((object) new TerrainToolkit.tidalErosionPresetData("High Tidal Range, Strong Waves", 25, 15f, 25f));
      this.windErosionPresets.Add((object) new TerrainToolkit.windErosionPresetData("Default (Northerly)", 25, 180f, 0.5f, 0.01f, 0.5f, 0.01f, 0.1f, 0.25f));
      this.windErosionPresets.Add((object) new TerrainToolkit.windErosionPresetData("Default (Southerly)", 25, 0.0f, 0.5f, 0.01f, 0.5f, 0.01f, 0.1f, 0.25f));
      this.windErosionPresets.Add((object) new TerrainToolkit.windErosionPresetData("Default (Easterly)", 25, 270f, 0.5f, 0.01f, 0.5f, 0.01f, 0.1f, 0.25f));
      this.windErosionPresets.Add((object) new TerrainToolkit.windErosionPresetData("Default (Westerly)", 25, 90f, 0.5f, 0.01f, 0.5f, 0.01f, 0.1f, 0.25f));
    }

    public void setVoronoiPreset(TerrainToolkit.voronoiPresetData preset)
    {
      this.generatorTypeInt = 0;
      this.p_generatorType = TerrainToolkit.GeneratorType.Voronoi;
      this.voronoiTypeInt = (int) preset.p_voronoiType;
      this.p_voronoiType = preset.p_voronoiType;
      this.voronoiCells = preset.voronoiCells;
      this.voronoiFeatures = preset.voronoiFeatures;
      this.voronoiScale = preset.voronoiScale;
      this.voronoiBlend = preset.voronoiBlend;
    }

    public void setFractalPreset(TerrainToolkit.fractalPresetData preset)
    {
      this.generatorTypeInt = 1;
      this.p_generatorType = TerrainToolkit.GeneratorType.DiamondSquare;
      this.diamondSquareDelta = preset.diamondSquareDelta;
      this.diamondSquareBlend = preset.diamondSquareBlend;
    }

    public void setPerlinPreset(TerrainToolkit.perlinPresetData preset)
    {
      this.generatorTypeInt = 2;
      this.p_generatorType = TerrainToolkit.GeneratorType.Perlin;
      this.perlinFrequency = preset.perlinFrequency;
      this.perlinAmplitude = preset.perlinAmplitude;
      this.perlinOctaves = preset.perlinOctaves;
      this.perlinBlend = preset.perlinBlend;
    }

    public void setThermalErosionPreset(TerrainToolkit.thermalErosionPresetData preset)
    {
      this.erosionTypeInt = 0;
      this.p_erosionType = TerrainToolkit.ErosionType.Thermal;
      this.thermalIterations = preset.thermalIterations;
      this.thermalMinSlope = preset.thermalMinSlope;
      this.thermalFalloff = preset.thermalFalloff;
    }

    public void setFastHydraulicErosionPreset(
      TerrainToolkit.fastHydraulicErosionPresetData preset)
    {
      this.erosionTypeInt = 1;
      this.p_erosionType = TerrainToolkit.ErosionType.Hydraulic;
      this.hydraulicTypeInt = 0;
      this.p_hydraulicType = TerrainToolkit.HydraulicType.Fast;
      this.hydraulicIterations = preset.hydraulicIterations;
      this.hydraulicMaxSlope = preset.hydraulicMaxSlope;
      this.hydraulicFalloff = preset.hydraulicFalloff;
    }

    public void setFullHydraulicErosionPreset(
      TerrainToolkit.fullHydraulicErosionPresetData preset)
    {
      this.erosionTypeInt = 1;
      this.p_erosionType = TerrainToolkit.ErosionType.Hydraulic;
      this.hydraulicTypeInt = 1;
      this.p_hydraulicType = TerrainToolkit.HydraulicType.Full;
      this.hydraulicIterations = preset.hydraulicIterations;
      this.hydraulicRainfall = preset.hydraulicRainfall;
      this.hydraulicEvaporation = preset.hydraulicEvaporation;
      this.hydraulicSedimentSolubility = preset.hydraulicSedimentSolubility;
      this.hydraulicSedimentSaturation = preset.hydraulicSedimentSaturation;
    }

    public void setVelocityHydraulicErosionPreset(
      TerrainToolkit.velocityHydraulicErosionPresetData preset)
    {
      this.erosionTypeInt = 1;
      this.p_erosionType = TerrainToolkit.ErosionType.Hydraulic;
      this.hydraulicTypeInt = 2;
      this.p_hydraulicType = TerrainToolkit.HydraulicType.Velocity;
      this.hydraulicIterations = preset.hydraulicIterations;
      this.hydraulicVelocityRainfall = preset.hydraulicVelocityRainfall;
      this.hydraulicVelocityEvaporation = preset.hydraulicVelocityEvaporation;
      this.hydraulicVelocitySedimentSolubility = preset.hydraulicVelocitySedimentSolubility;
      this.hydraulicVelocitySedimentSaturation = preset.hydraulicVelocitySedimentSaturation;
      this.hydraulicVelocity = preset.hydraulicVelocity;
      this.hydraulicMomentum = preset.hydraulicMomentum;
      this.hydraulicEntropy = preset.hydraulicEntropy;
      this.hydraulicDowncutting = preset.hydraulicDowncutting;
    }

    public void setTidalErosionPreset(TerrainToolkit.tidalErosionPresetData preset)
    {
      this.erosionTypeInt = 2;
      this.p_erosionType = TerrainToolkit.ErosionType.Tidal;
      this.tidalIterations = preset.tidalIterations;
      this.tidalRangeAmount = preset.tidalRangeAmount;
      this.tidalCliffLimit = preset.tidalCliffLimit;
    }

    public void setWindErosionPreset(TerrainToolkit.windErosionPresetData preset)
    {
      this.erosionTypeInt = 3;
      this.p_erosionType = TerrainToolkit.ErosionType.Wind;
      this.windIterations = preset.windIterations;
      this.windDirection = preset.windDirection;
      this.windForce = preset.windForce;
      this.windLift = preset.windLift;
      this.windGravity = preset.windGravity;
      this.windCapacity = preset.windCapacity;
      this.windEntropy = preset.windEntropy;
      this.windSmoothing = preset.windSmoothing;
    }

    public void Update()
    {
      if (!this.isBrushOn || this.toolModeInt == 1 && this.erosionTypeInt <= 2 && (this.erosionTypeInt != 1 || this.hydraulicTypeInt <= 0))
        return;
      this.isBrushOn = false;
    }

    public void OnDrawGizmos()
    {
      Terrain component = (Terrain) this.GetComponent(typeof (Terrain));
      if ((UnityEngine.Object) component == (UnityEngine.Object) null)
        return;
      if (this.isBrushOn && !this.isBrushHidden)
      {
        Gizmos.color = !this.isBrushPainting ? Color.white : Color.red;
        float num = this.brushSize / 4f;
        Gizmos.DrawLine(this.brushPosition + new Vector3(-num, 0.0f, 0.0f), this.brushPosition + new Vector3(num, 0.0f, 0.0f));
        Gizmos.DrawLine(this.brushPosition + new Vector3(0.0f, -num, 0.0f), this.brushPosition + new Vector3(0.0f, num, 0.0f));
        Gizmos.DrawLine(this.brushPosition + new Vector3(0.0f, 0.0f, -num), this.brushPosition + new Vector3(0.0f, 0.0f, num));
        Gizmos.DrawWireCube(this.brushPosition, new Vector3(this.brushSize, 0.0f, this.brushSize));
        Gizmos.DrawWireSphere(this.brushPosition, this.brushSize / 2f);
      }
      Vector3 size = component.terrainData.size;
      if (this.toolModeInt == 1 && this.erosionTypeInt == 2)
      {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(new Vector3(this.transform.position.x + size.x / 2f, this.tidalSeaLevel, this.transform.position.z + size.z / 2f), new Vector3(size.x, 0.0f, size.z));
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(new Vector3(this.transform.position.x + size.x / 2f, this.tidalSeaLevel, this.transform.position.z + size.z / 2f), new Vector3(size.x, this.tidalRangeAmount * 2f, size.z));
      }
      if (this.toolModeInt != 1 || this.erosionTypeInt != 3)
        return;
      Gizmos.color = Color.blue;
      Vector3 vector3_1 = Quaternion.Euler(0.0f, this.windDirection, 0.0f) * Vector3.forward;
      Vector3 from = new Vector3(this.transform.position.x + size.x / 2f, this.transform.position.y + size.y, this.transform.position.z + size.z / 2f);
      Vector3 vector3_2 = from + vector3_1 * (size.x / 4f);
      Vector3 vector3_3 = from + vector3_1 * (size.x / 6f);
      Gizmos.DrawLine(from, vector3_2);
      Gizmos.DrawLine(vector3_2, vector3_3 + new Vector3(0.0f, size.x / 16f, 0.0f));
      Gizmos.DrawLine(vector3_2, vector3_3 - new Vector3(0.0f, size.x / 16f, 0.0f));
    }

    public void paint()
    {
      this.convertIntVarsToEnums();
      this.erodeTerrainWithBrush();
    }

    public void erodeTerrainWithBrush()
    {
      this.p_erosionMode = TerrainToolkit.ErosionMode.Brush;
      Terrain component = (Terrain) this.GetComponent(typeof (Terrain));
      if ((UnityEngine.Object) component == (UnityEngine.Object) null)
        return;
      try
      {
        TerrainData terrainData = component.terrainData;
        int heightmapResolution1 = terrainData.heightmapResolution;
        int heightmapResolution2 = terrainData.heightmapResolution;
        Vector3 size = terrainData.size;
        int width = (int) Mathf.Floor((float) heightmapResolution1 / size.x * this.brushSize);
        int height = (int) Mathf.Floor((float) heightmapResolution2 / size.z * this.brushSize);
        Vector3 vector3 = this.transform.InverseTransformPoint(this.brushPosition);
        int xBase = (int) Mathf.Round(vector3.x / size.x * (float) heightmapResolution1 - (float) (width / 2));
        int yBase = (int) Mathf.Round(vector3.z / size.z * (float) heightmapResolution2 - (float) (height / 2));
        if (xBase < 0)
        {
          width += xBase;
          xBase = 0;
        }
        if (yBase < 0)
        {
          height += yBase;
          yBase = 0;
        }
        if (xBase + width > heightmapResolution1)
          width = heightmapResolution1 - xBase;
        if (yBase + height > heightmapResolution2)
          height = heightmapResolution2 - yBase;
        float[,] heights = terrainData.GetHeights(xBase, yBase, width, height);
        int length1 = heights.GetLength(1);
        int length2 = heights.GetLength(0);
        float[,] heightMap = (float[,]) heights.Clone();
        TerrainToolkit.ErosionProgressDelegate erosionProgressDelegate = new TerrainToolkit.ErosionProgressDelegate(this.dummyErosionProgress);
        float[,] numArray = this.fastErosion(heightMap, new Vector2((float) length1, (float) length2), 1, erosionProgressDelegate);
        float num1 = (float) length1 / 2f;
        for (int y = 0; y < length1; ++y)
        {
          for (int x = 0; x < length2; ++x)
          {
            float num2 = heights[x, y];
            double num3 = (double) numArray[x, y];
            float num4 = (float) (1.0 - ((double) Vector2.Distance(new Vector2((float) x, (float) y), new Vector2(num1, num1)) - ((double) num1 - (double) num1 * (double) this.brushSoftness)) / ((double) num1 * (double) this.brushSoftness));
            if ((double) num4 < 0.0)
              num4 = 0.0f;
            else if ((double) num4 > 1.0)
              num4 = 1f;
            float num5 = num4 * this.brushOpacity;
            double num6 = (double) num5;
            float num7 = (float) (num3 * num6 + (double) num2 * (1.0 - (double) num5));
            heights[x, y] = num7;
          }
        }
        terrainData.SetHeights(xBase, yBase, heights);
      }
      catch (Exception ex)
      {
        Debug.LogError((object) ("A brush error occurred : " + ex?.ToString()));
      }
    }

    public void erodeAllTerrain(
      TerrainToolkit.ErosionProgressDelegate erosionProgressDelegate)
    {
      this.p_erosionMode = TerrainToolkit.ErosionMode.Filter;
      this.convertIntVarsToEnums();
      Terrain component = (Terrain) this.GetComponent(typeof (Terrain));
      if ((UnityEngine.Object) component == (UnityEngine.Object) null)
        return;
      try
      {
        TerrainData terrainData = component.terrainData;
        int heightmapResolution1 = terrainData.heightmapResolution;
        int heightmapResolution2 = terrainData.heightmapResolution;
        float[,] numArray = terrainData.GetHeights(0, 0, heightmapResolution1, heightmapResolution2);
        switch (this.p_erosionType)
        {
          case TerrainToolkit.ErosionType.Thermal:
            int thermalIterations = this.thermalIterations;
            numArray = this.fastErosion(numArray, new Vector2((float) heightmapResolution1, (float) heightmapResolution2), thermalIterations, erosionProgressDelegate);
            break;
          case TerrainToolkit.ErosionType.Hydraulic:
            int hydraulicIterations = this.hydraulicIterations;
            switch (this.p_hydraulicType)
            {
              case TerrainToolkit.HydraulicType.Fast:
                numArray = this.fastErosion(numArray, new Vector2((float) heightmapResolution1, (float) heightmapResolution2), hydraulicIterations, erosionProgressDelegate);
                break;
              case TerrainToolkit.HydraulicType.Full:
                numArray = this.fullHydraulicErosion(numArray, new Vector2((float) heightmapResolution1, (float) heightmapResolution2), hydraulicIterations, erosionProgressDelegate);
                break;
              case TerrainToolkit.HydraulicType.Velocity:
                numArray = this.velocityHydraulicErosion(numArray, new Vector2((float) heightmapResolution1, (float) heightmapResolution2), hydraulicIterations, erosionProgressDelegate);
                break;
            }
            break;
          case TerrainToolkit.ErosionType.Tidal:
            Vector3 size = terrainData.size;
            if ((double) this.tidalSeaLevel >= (double) this.transform.position.y && (double) this.tidalSeaLevel <= (double) this.transform.position.y + (double) size.y)
            {
              int tidalIterations = this.tidalIterations;
              numArray = this.fastErosion(numArray, new Vector2((float) heightmapResolution1, (float) heightmapResolution2), tidalIterations, erosionProgressDelegate);
              break;
            }
            Debug.LogError((object) "Sea level does not intersect terrain object. Erosion operation failed.");
            break;
          case TerrainToolkit.ErosionType.Wind:
            int windIterations = this.windIterations;
            numArray = this.windErosion(numArray, new Vector2((float) heightmapResolution1, (float) heightmapResolution2), windIterations, erosionProgressDelegate);
            break;
          default:
            return;
        }
        terrainData.SetHeights(0, 0, numArray);
      }
      catch (Exception ex)
      {
        Debug.LogError((object) ("An error occurred : " + ex?.ToString()));
      }
    }

    public float[,] fastErosion(
      float[,] heightMap,
      Vector2 arraySize,
      int iterations,
      TerrainToolkit.ErosionProgressDelegate erosionProgressDelegate)
    {
      int y = (int) arraySize.y;
      int x = (int) arraySize.x;
      float[,] numArray = new float[y, x];
      Vector3 size = ((Terrain) this.GetComponent(typeof (Terrain))).terrainData.size;
      float num1 = 0.0f;
      float num2 = 0.0f;
      float num3 = 0.0f;
      float num4 = 0.0f;
      float num5 = 0.0f;
      float num6 = 0.0f;
      float num7 = 0.0f;
      float num8 = 0.0f;
      float num9 = 0.0f;
      switch (this.p_erosionType)
      {
        case TerrainToolkit.ErosionType.Thermal:
          num1 = size.x / (float) y * Mathf.Tan(this.thermalMinSlope * ((float) Math.PI / 180f)) / size.y;
          if ((double) num1 > 1.0)
            num1 = 1f;
          if ((double) this.thermalFalloff == 1.0)
            this.thermalFalloff = 0.999f;
          float num10 = this.thermalMinSlope + (90f - this.thermalMinSlope) * this.thermalFalloff;
          num2 = size.x / (float) y * Mathf.Tan(num10 * ((float) Math.PI / 180f)) / size.y;
          if ((double) num2 > 1.0)
          {
            num2 = 1f;
            break;
          }
          break;
        case TerrainToolkit.ErosionType.Hydraulic:
          num4 = size.x / (float) y * Mathf.Tan(this.hydraulicMaxSlope * ((float) Math.PI / 180f)) / size.y;
          if ((double) this.hydraulicFalloff == 0.0)
            this.hydraulicFalloff = 1f / 1000f;
          float num11 = this.hydraulicMaxSlope * (1f - this.hydraulicFalloff);
          num3 = size.x / (float) y * Mathf.Tan(num11 * ((float) Math.PI / 180f)) / size.y;
          break;
        case TerrainToolkit.ErosionType.Tidal:
          num5 = (float) (((double) this.tidalSeaLevel - (double) this.transform.position.y) / ((double) this.transform.position.y + (double) size.y));
          num6 = (float) (((double) this.tidalSeaLevel - (double) this.transform.position.y - (double) this.tidalRangeAmount) / ((double) this.transform.position.y + (double) size.y));
          num7 = (float) (((double) this.tidalSeaLevel - (double) this.transform.position.y + (double) this.tidalRangeAmount) / ((double) this.transform.position.y + (double) size.y));
          num8 = num7 - num5;
          num9 = size.x / (float) y * Mathf.Tan(this.tidalCliffLimit * ((float) Math.PI / 180f)) / size.y;
          break;
        default:
          return heightMap;
      }
      for (int iteration = 0; iteration < iterations; ++iteration)
      {
        for (int index1 = 0; index1 < x; ++index1)
        {
          int num12;
          int num13;
          int num14;
          if (index1 == 0)
          {
            num12 = 2;
            num13 = 0;
            num14 = 0;
          }
          else if (index1 == x - 1)
          {
            num12 = 2;
            num13 = -1;
            num14 = 1;
          }
          else
          {
            num12 = 3;
            num13 = -1;
            num14 = 1;
          }
          for (int index2 = 0; index2 < y; ++index2)
          {
            int num15;
            int num16;
            int num17;
            if (index2 == 0)
            {
              num15 = 2;
              num16 = 0;
              num17 = 0;
            }
            else if (index2 == y - 1)
            {
              num15 = 2;
              num16 = -1;
              num17 = 1;
            }
            else
            {
              num15 = 3;
              num16 = -1;
              num17 = 1;
            }
            float num18 = 1f;
            float num19 = 0.0f;
            float num20 = 0.0f;
            float height1 = heightMap[index2 + num17 + num16, index1 + num14 + num13];
            float num21 = height1;
            int num22 = 0;
            for (int index3 = 0; index3 < num12; ++index3)
            {
              for (int index4 = 0; index4 < num15; ++index4)
              {
                if ((index4 != num17 || index3 != num14) && (this.p_neighbourhood == TerrainToolkit.Neighbourhood.Moore || this.p_neighbourhood == TerrainToolkit.Neighbourhood.VonNeumann && (index4 == num17 || index3 == num14)))
                {
                  float height2 = heightMap[index2 + index4 + num16, index1 + index3 + num13];
                  num21 += height2;
                  float num23 = height1 - height2;
                  if ((double) num23 > 0.0)
                  {
                    num20 += num23;
                    if ((double) num23 < (double) num18)
                      num18 = num23;
                    if ((double) num23 > (double) num19)
                      num19 = num23;
                  }
                  ++num22;
                }
              }
            }
            float num24 = num20 / (float) num22;
            bool flag = false;
            switch (this.p_erosionType)
            {
              case TerrainToolkit.ErosionType.Thermal:
                if ((double) num24 >= (double) num1)
                {
                  flag = true;
                  break;
                }
                break;
              case TerrainToolkit.ErosionType.Hydraulic:
                if ((double) num24 > 0.0 && (double) num24 <= (double) num4)
                {
                  flag = true;
                  break;
                }
                break;
              case TerrainToolkit.ErosionType.Tidal:
                if ((double) num24 > 0.0 && (double) num24 <= (double) num9 && (double) height1 < (double) num7 && (double) height1 > (double) num6)
                {
                  flag = true;
                  break;
                }
                break;
              default:
                return heightMap;
            }
            if (flag)
            {
              if (this.p_erosionType == TerrainToolkit.ErosionType.Tidal)
              {
                float num25 = num21 / (float) (num22 + 1);
                double f = (double) Mathf.Abs(num5 - height1);
                float num26 = (float) f / num8;
                float num27 = (float) ((double) height1 * (double) num26 + (double) num25 * (1.0 - (double) num26));
                float num28 = Mathf.Pow((float) f, 3f);
                heightMap[index2 + num17 + num16, index1 + num14 + num13] = (float) ((double) num5 * (double) num28 + (double) num27 * (1.0 - (double) num28));
              }
              else
              {
                float num29;
                if (this.p_erosionType == TerrainToolkit.ErosionType.Thermal)
                {
                  if ((double) num24 > (double) num2)
                  {
                    num29 = 1f;
                  }
                  else
                  {
                    float num30 = num2 - num1;
                    num29 = (num24 - num1) / num30;
                  }
                }
                else if ((double) num24 < (double) num3)
                {
                  num29 = 1f;
                }
                else
                {
                  float num31 = num4 - num3;
                  num29 = (float) (1.0 - ((double) num24 - (double) num3) / (double) num31);
                }
                float num32 = num24 / 2f * num29;
                float height3 = heightMap[index2 + num17 + num16, index1 + num14 + num13];
                if (this.p_erosionMode == TerrainToolkit.ErosionMode.Filter || this.p_erosionMode == TerrainToolkit.ErosionMode.Brush && this.useDifferenceMaps)
                {
                  float num33 = numArray[index2 + num17 + num16, index1 + num14 + num13] - num32;
                  numArray[index2 + num17 + num16, index1 + num14 + num13] = num33;
                }
                else
                {
                  float num34 = height3 - num32;
                  if ((double) num34 < 0.0)
                    num34 = 0.0f;
                  heightMap[index2 + num17 + num16, index1 + num14 + num13] = num34;
                }
                for (int index5 = 0; index5 < num12; ++index5)
                {
                  for (int index6 = 0; index6 < num15; ++index6)
                  {
                    if ((index6 != num17 || index5 != num14) && (this.p_neighbourhood == TerrainToolkit.Neighbourhood.Moore || this.p_neighbourhood == TerrainToolkit.Neighbourhood.VonNeumann && (index6 == num17 || index5 == num14)))
                    {
                      float height4 = heightMap[index2 + index6 + num16, index1 + index5 + num13];
                      float num35 = height3 - height4;
                      if ((double) num35 > 0.0)
                      {
                        float num36 = num32 * (num35 / num20);
                        if (this.p_erosionMode == TerrainToolkit.ErosionMode.Filter || this.p_erosionMode == TerrainToolkit.ErosionMode.Brush && this.useDifferenceMaps)
                        {
                          float num37 = numArray[index2 + index6 + num16, index1 + index5 + num13] + num36;
                          numArray[index2 + index6 + num16, index1 + index5 + num13] = num37;
                        }
                        else
                        {
                          float num38 = height4 + num36;
                          if ((double) num38 < 0.0)
                            num38 = 0.0f;
                          heightMap[index2 + index6 + num16, index1 + index5 + num13] = num38;
                        }
                      }
                    }
                  }
                }
              }
            }
          }
        }
        if ((this.p_erosionMode == TerrainToolkit.ErosionMode.Filter || this.p_erosionMode == TerrainToolkit.ErosionMode.Brush && this.useDifferenceMaps) && this.p_erosionType != TerrainToolkit.ErosionType.Tidal)
        {
          for (int index7 = 0; index7 < x; ++index7)
          {
            for (int index8 = 0; index8 < y; ++index8)
            {
              float num39 = heightMap[index8, index7] + numArray[index8, index7];
              if ((double) num39 > 1.0)
                num39 = 1f;
              else if ((double) num39 < 0.0)
                num39 = 0.0f;
              heightMap[index8, index7] = num39;
              numArray[index8, index7] = 0.0f;
            }
          }
        }
        if (this.p_erosionMode == TerrainToolkit.ErosionMode.Filter)
        {
          string titleString;
          string displayString;
          switch (this.p_erosionType)
          {
            case TerrainToolkit.ErosionType.Thermal:
              titleString = "Applying Thermal Erosion";
              displayString = "Applying thermal erosion.";
              break;
            case TerrainToolkit.ErosionType.Hydraulic:
              titleString = "Applying Hydraulic Erosion";
              displayString = "Applying hydraulic erosion.";
              break;
            case TerrainToolkit.ErosionType.Tidal:
              titleString = "Applying Tidal Erosion";
              displayString = "Applying tidal erosion.";
              break;
            default:
              return heightMap;
          }
          float percentComplete = (float) iteration / (float) iterations;
          erosionProgressDelegate(titleString, displayString, iteration, iterations, percentComplete);
        }
      }
      return heightMap;
    }

    public float[,] velocityHydraulicErosion(
      float[,] heightMap,
      Vector2 arraySize,
      int iterations,
      TerrainToolkit.ErosionProgressDelegate erosionProgressDelegate)
    {
      int x = (int) arraySize.x;
      int y = (int) arraySize.y;
      float[,] numArray1 = new float[x, y];
      float[,] numArray2 = new float[x, y];
      float[,] numArray3 = new float[x, y];
      float[,] numArray4 = new float[x, y];
      float[,] numArray5 = new float[x, y];
      float[,] numArray6 = new float[x, y];
      float[,] numArray7 = new float[x, y];
      float[,] numArray8 = new float[x, y];
      for (int index1 = 0; index1 < y; ++index1)
      {
        for (int index2 = 0; index2 < x; ++index2)
        {
          numArray3[index2, index1] = 0.0f;
          numArray4[index2, index1] = 0.0f;
          numArray5[index2, index1] = 0.0f;
          numArray6[index2, index1] = 0.0f;
          numArray7[index2, index1] = 0.0f;
          numArray8[index2, index1] = 0.0f;
        }
      }
      for (int index3 = 0; index3 < y; ++index3)
      {
        for (int index4 = 0; index4 < x; ++index4)
        {
          float height = heightMap[index4, index3];
          numArray1[index4, index3] = height;
        }
      }
      for (int index5 = 0; index5 < y; ++index5)
      {
        int num1;
        int num2;
        int num3;
        if (index5 == 0)
        {
          num1 = 2;
          num2 = 0;
          num3 = 0;
        }
        else if (index5 == y - 1)
        {
          num1 = 2;
          num2 = -1;
          num3 = 1;
        }
        else
        {
          num1 = 3;
          num2 = -1;
          num3 = 1;
        }
        for (int index6 = 0; index6 < x; ++index6)
        {
          int num4;
          int num5;
          int num6;
          if (index6 == 0)
          {
            num4 = 2;
            num5 = 0;
            num6 = 0;
          }
          else if (index6 == x - 1)
          {
            num4 = 2;
            num5 = -1;
            num6 = 1;
          }
          else
          {
            num4 = 3;
            num5 = -1;
            num6 = 1;
          }
          float num7 = 0.0f;
          float height1 = heightMap[index6 + num6 + num5, index5 + num3 + num2];
          int num8 = 0;
          for (int index7 = 0; index7 < num1; ++index7)
          {
            for (int index8 = 0; index8 < num4; ++index8)
            {
              if ((index8 != num6 || index7 != num3) && (this.p_neighbourhood == TerrainToolkit.Neighbourhood.Moore || this.p_neighbourhood == TerrainToolkit.Neighbourhood.VonNeumann && (index8 == num6 || index7 == num3)))
              {
                float height2 = heightMap[index6 + index8 + num5, index5 + index7 + num2];
                float num9 = Mathf.Abs(height1 - height2);
                num7 += num9;
                ++num8;
              }
            }
          }
          float num10 = num7 / (float) num8;
          numArray2[index6 + num6 + num5, index5 + num3 + num2] = num10;
        }
      }
      for (int iteration = 0; iteration < iterations; ++iteration)
      {
        for (int index9 = 0; index9 < y; ++index9)
        {
          for (int index10 = 0; index10 < x; ++index10)
          {
            float num = numArray3[index10, index9] + numArray1[index10, index9] * this.hydraulicVelocityRainfall;
            if ((double) num > 1.0)
              num = 1f;
            numArray3[index10, index9] = num;
          }
        }
        for (int index11 = 0; index11 < y; ++index11)
        {
          for (int index12 = 0; index12 < x; ++index12)
          {
            float num11 = numArray7[index12, index11];
            float num12 = numArray3[index12, index11] * this.hydraulicVelocitySedimentSaturation;
            if ((double) num11 < (double) num12)
            {
              float num13 = numArray3[index12, index11] * numArray5[index12, index11] * this.hydraulicVelocitySedimentSolubility;
              if ((double) num11 + (double) num13 > (double) num12)
                num13 = num12 - num11;
              float height = heightMap[index12, index11];
              if ((double) num13 > (double) height)
                num13 = height;
              numArray7[index12, index11] = num11 + num13;
              heightMap[index12, index11] = height - num13;
            }
          }
        }
        for (int index13 = 0; index13 < y; ++index13)
        {
          int num14;
          int num15;
          int num16;
          if (index13 == 0)
          {
            num14 = 2;
            num15 = 0;
            num16 = 0;
          }
          else if (index13 == y - 1)
          {
            num14 = 2;
            num15 = -1;
            num16 = 1;
          }
          else
          {
            num14 = 3;
            num15 = -1;
            num16 = 1;
          }
          for (int index14 = 0; index14 < x; ++index14)
          {
            int num17;
            int num18;
            int num19;
            if (index14 == 0)
            {
              num17 = 2;
              num18 = 0;
              num19 = 0;
            }
            else if (index14 == x - 1)
            {
              num17 = 2;
              num18 = -1;
              num19 = 1;
            }
            else
            {
              num17 = 3;
              num18 = -1;
              num19 = 1;
            }
            float num20 = 0.0f;
            float height3 = heightMap[index14, index13];
            float num21 = height3;
            float a = numArray3[index14, index13];
            int num22 = 0;
            for (int index15 = 0; index15 < num14; ++index15)
            {
              for (int index16 = 0; index16 < num17; ++index16)
              {
                if ((index16 != num19 || index15 != num16) && (this.p_neighbourhood == TerrainToolkit.Neighbourhood.Moore || this.p_neighbourhood == TerrainToolkit.Neighbourhood.VonNeumann && (index16 == num19 || index15 == num16)))
                {
                  float height4 = heightMap[index14 + index16 + num18, index13 + index15 + num15];
                  float num23 = numArray3[index14 + index16 + num18, index13 + index15 + num15];
                  float num24 = (float) ((double) height3 + (double) a - ((double) height4 + (double) num23));
                  if ((double) num24 > 0.0)
                  {
                    num20 += num24;
                    num21 += height3 + a;
                    ++num22;
                  }
                }
              }
            }
            float num25 = numArray5[index14, index13];
            float num26 = numArray2[index14, index13];
            double num27 = (double) numArray7[index14, index13];
            double num28 = (double) num25 + (double) this.hydraulicVelocity * (double) num26;
            float num29 = num21 / (float) (num22 + 1);
            float num30 = height3 + a - num29;
            float num31 = Mathf.Min(a, num30 * (1f + num25));
            float num32 = numArray4[index14, index13] - num31;
            numArray4[index14, index13] = num32;
            double num33 = (double) num31 / (double) a;
            float num34 = (float) (num28 * num33);
            double num35 = (double) num31 / (double) a;
            float num36 = (float) (num27 * num35);
            for (int index17 = 0; index17 < num14; ++index17)
            {
              for (int index18 = 0; index18 < num17; ++index18)
              {
                if ((index18 != num19 || index17 != num16) && (this.p_neighbourhood == TerrainToolkit.Neighbourhood.Moore || this.p_neighbourhood == TerrainToolkit.Neighbourhood.VonNeumann && (index18 == num19 || index17 == num16)))
                {
                  float height5 = heightMap[index14 + index18 + num18, index13 + index17 + num15];
                  float num37 = numArray3[index14 + index18 + num18, index13 + index17 + num15];
                  float num38 = (float) ((double) height3 + (double) a - ((double) height5 + (double) num37));
                  if ((double) num38 > 0.0)
                  {
                    float num39 = numArray4[index14 + index18 + num18, index13 + index17 + num15] + num31 * (num38 / num20);
                    numArray4[index14 + index18 + num18, index13 + index17 + num15] = num39;
                    float num40 = numArray6[index14 + index18 + num18, index13 + index17 + num15] + (float) ((double) num34 * (double) this.hydraulicMomentum * ((double) num38 / (double) num20));
                    numArray6[index14 + index18 + num18, index13 + index17 + num15] = num40;
                    float num41 = numArray8[index14 + index18 + num18, index13 + index17 + num15] + (float) ((double) num36 * (double) this.hydraulicMomentum * ((double) num38 / (double) num20));
                    numArray8[index14 + index18 + num18, index13 + index17 + num15] = num41;
                  }
                }
              }
            }
            float num42 = numArray6[index14, index13];
            numArray6[index14, index13] = num42 - num34;
          }
        }
        for (int index19 = 0; index19 < y; ++index19)
        {
          for (int index20 = 0; index20 < x; ++index20)
          {
            float num = (numArray5[index20, index19] + numArray6[index20, index19]) * (1f - this.hydraulicEntropy);
            if ((double) num > 1.0)
              num = 1f;
            else if ((double) num < 0.0)
              num = 0.0f;
            numArray5[index20, index19] = num;
            numArray6[index20, index19] = 0.0f;
          }
        }
        for (int index21 = 0; index21 < y; ++index21)
        {
          for (int index22 = 0; index22 < x; ++index22)
          {
            float num43 = numArray3[index22, index21] + numArray4[index22, index21];
            float num44 = num43 * this.hydraulicVelocityEvaporation;
            float num45 = num43 - num44;
            if ((double) num45 > 1.0)
              num45 = 1f;
            else if ((double) num45 < 0.0)
              num45 = 0.0f;
            numArray3[index22, index21] = num45;
            numArray4[index22, index21] = 0.0f;
          }
        }
        for (int index23 = 0; index23 < y; ++index23)
        {
          for (int index24 = 0; index24 < x; ++index24)
          {
            float num = numArray7[index24, index23] + numArray8[index24, index23];
            if ((double) num > 1.0)
              num = 1f;
            else if ((double) num < 0.0)
              num = 0.0f;
            numArray7[index24, index23] = num;
            numArray8[index24, index23] = 0.0f;
          }
        }
        for (int index25 = 0; index25 < y; ++index25)
        {
          for (int index26 = 0; index26 < x; ++index26)
          {
            float num46 = numArray3[index26, index25] * this.hydraulicVelocitySedimentSaturation;
            float num47 = numArray7[index26, index25];
            if ((double) num47 > (double) num46)
            {
              float num48 = num47 - num46;
              numArray7[index26, index25] = num46;
              float height = heightMap[index26, index25];
              heightMap[index26, index25] = height + num48;
            }
          }
        }
        for (int index27 = 0; index27 < y; ++index27)
        {
          for (int index28 = 0; index28 < x; ++index28)
          {
            float num49 = numArray3[index28, index27];
            float height = heightMap[index28, index27];
            float num50 = (float) (1.0 - (double) Mathf.Abs(0.5f - height) * 2.0);
            float num51 = this.hydraulicDowncutting * num49 * num50;
            float num52 = height - num51;
            heightMap[index28, index27] = num52;
          }
        }
        float percentComplete = (float) iteration / (float) iterations;
        erosionProgressDelegate("Applying Hydraulic Erosion", "Applying hydraulic erosion.", iteration, iterations, percentComplete);
      }
      return heightMap;
    }

    public float[,] fullHydraulicErosion(
      float[,] heightMap,
      Vector2 arraySize,
      int iterations,
      TerrainToolkit.ErosionProgressDelegate erosionProgressDelegate)
    {
      int x = (int) arraySize.x;
      int y = (int) arraySize.y;
      float[,] numArray1 = new float[x, y];
      float[,] numArray2 = new float[x, y];
      float[,] numArray3 = new float[x, y];
      float[,] numArray4 = new float[x, y];
      for (int index1 = 0; index1 < y; ++index1)
      {
        for (int index2 = 0; index2 < x; ++index2)
        {
          numArray1[index2, index1] = 0.0f;
          numArray2[index2, index1] = 0.0f;
          numArray3[index2, index1] = 0.0f;
          numArray4[index2, index1] = 0.0f;
        }
      }
      for (int iteration = 0; iteration < iterations; ++iteration)
      {
        for (int index3 = 0; index3 < y; ++index3)
        {
          for (int index4 = 0; index4 < x; ++index4)
          {
            float num = numArray1[index4, index3] + this.hydraulicRainfall;
            if ((double) num > 1.0)
              num = 1f;
            numArray1[index4, index3] = num;
          }
        }
        for (int index5 = 0; index5 < y; ++index5)
        {
          for (int index6 = 0; index6 < x; ++index6)
          {
            float num1 = numArray3[index6, index5];
            float num2 = numArray1[index6, index5] * this.hydraulicSedimentSaturation;
            if ((double) num1 < (double) num2)
            {
              float num3 = numArray1[index6, index5] * this.hydraulicSedimentSolubility;
              if ((double) num1 + (double) num3 > (double) num2)
                num3 = num2 - num1;
              float height = heightMap[index6, index5];
              if ((double) num3 > (double) height)
                num3 = height;
              numArray3[index6, index5] = num1 + num3;
              heightMap[index6, index5] = height - num3;
            }
          }
        }
        for (int index7 = 0; index7 < y; ++index7)
        {
          int num4;
          int num5;
          int num6;
          if (index7 == 0)
          {
            num4 = 2;
            num5 = 0;
            num6 = 0;
          }
          else if (index7 == y - 1)
          {
            num4 = 2;
            num5 = -1;
            num6 = 1;
          }
          else
          {
            num4 = 3;
            num5 = -1;
            num6 = 1;
          }
          for (int index8 = 0; index8 < x; ++index8)
          {
            int num7;
            int num8;
            int num9;
            if (index8 == 0)
            {
              num7 = 2;
              num8 = 0;
              num9 = 0;
            }
            else if (index8 == x - 1)
            {
              num7 = 2;
              num8 = -1;
              num9 = 1;
            }
            else
            {
              num7 = 3;
              num8 = -1;
              num9 = 1;
            }
            float num10 = 0.0f;
            float num11 = 0.0f;
            float height1 = heightMap[index8 + num9 + num8, index7 + num6 + num5];
            float a = numArray1[index8 + num9 + num8, index7 + num6 + num5];
            float num12 = height1;
            int num13 = 0;
            for (int index9 = 0; index9 < num4; ++index9)
            {
              for (int index10 = 0; index10 < num7; ++index10)
              {
                if ((index10 != num9 || index9 != num6) && (this.p_neighbourhood == TerrainToolkit.Neighbourhood.Moore || this.p_neighbourhood == TerrainToolkit.Neighbourhood.VonNeumann && (index10 == num9 || index9 == num6)))
                {
                  float height2 = heightMap[index8 + index10 + num8, index7 + index9 + num5];
                  float num14 = numArray1[index8 + index10 + num8, index7 + index9 + num5];
                  float num15 = (float) ((double) height1 + (double) a - ((double) height2 + (double) num14));
                  if ((double) num15 > 0.0)
                  {
                    num10 += num15;
                    num12 += height2 + num14;
                    ++num13;
                    if ((double) num15 > (double) num11)
                      ;
                  }
                }
              }
            }
            float num16 = num12 / (float) (num13 + 1);
            float b = height1 + a - num16;
            float num17 = Mathf.Min(a, b);
            float num18 = numArray2[index8 + num9 + num8, index7 + num6 + num5] - num17;
            numArray2[index8 + num9 + num8, index7 + num6 + num5] = num18;
            float num19 = numArray3[index8 + num9 + num8, index7 + num6 + num5] * (num17 / a);
            float num20 = numArray4[index8 + num9 + num8, index7 + num6 + num5] - num19;
            numArray4[index8 + num9 + num8, index7 + num6 + num5] = num20;
            for (int index11 = 0; index11 < num4; ++index11)
            {
              for (int index12 = 0; index12 < num7; ++index12)
              {
                if ((index12 != num9 || index11 != num6) && (this.p_neighbourhood == TerrainToolkit.Neighbourhood.Moore || this.p_neighbourhood == TerrainToolkit.Neighbourhood.VonNeumann && (index12 == num9 || index11 == num6)))
                {
                  float height3 = heightMap[index8 + index12 + num8, index7 + index11 + num5];
                  float num21 = numArray1[index8 + index12 + num8, index7 + index11 + num5];
                  float num22 = (float) ((double) height1 + (double) a - ((double) height3 + (double) num21));
                  if ((double) num22 > 0.0)
                  {
                    float num23 = numArray2[index8 + index12 + num8, index7 + index11 + num5] + num17 * (num22 / num10);
                    numArray2[index8 + index12 + num8, index7 + index11 + num5] = num23;
                    float num24 = numArray4[index8 + index12 + num8, index7 + index11 + num5] + num19 * (num22 / num10);
                    numArray4[index8 + index12 + num8, index7 + index11 + num5] = num24;
                  }
                }
              }
            }
          }
        }
        for (int index13 = 0; index13 < y; ++index13)
        {
          for (int index14 = 0; index14 < x; ++index14)
          {
            float num25 = numArray1[index14, index13] + numArray2[index14, index13];
            float num26 = num25 * this.hydraulicEvaporation;
            float num27 = num25 - num26;
            if ((double) num27 < 0.0)
              num27 = 0.0f;
            numArray1[index14, index13] = num27;
            numArray2[index14, index13] = 0.0f;
          }
        }
        for (int index15 = 0; index15 < y; ++index15)
        {
          for (int index16 = 0; index16 < x; ++index16)
          {
            float num = numArray3[index16, index15] + numArray4[index16, index15];
            if ((double) num > 1.0)
              num = 1f;
            else if ((double) num < 0.0)
              num = 0.0f;
            numArray3[index16, index15] = num;
            numArray4[index16, index15] = 0.0f;
          }
        }
        for (int index17 = 0; index17 < y; ++index17)
        {
          for (int index18 = 0; index18 < x; ++index18)
          {
            float num28 = numArray1[index18, index17] * this.hydraulicSedimentSaturation;
            float num29 = numArray3[index18, index17];
            if ((double) num29 > (double) num28)
            {
              float num30 = num29 - num28;
              numArray3[index18, index17] = num28;
              float height = heightMap[index18, index17];
              heightMap[index18, index17] = height + num30;
            }
          }
        }
        float percentComplete = (float) iteration / (float) iterations;
        erosionProgressDelegate("Applying Hydraulic Erosion", "Applying hydraulic erosion.", iteration, iterations, percentComplete);
      }
      return heightMap;
    }

    public float[,] windErosion(
      float[,] heightMap,
      Vector2 arraySize,
      int iterations,
      TerrainToolkit.ErosionProgressDelegate erosionProgressDelegate)
    {
      TerrainData terrainData = ((Terrain) this.GetComponent(typeof (Terrain))).terrainData;
      Vector3 to = Quaternion.Euler(0.0f, this.windDirection + 180f, 0.0f) * Vector3.forward;
      int x = (int) arraySize.x;
      int y = (int) arraySize.y;
      float[,] numArray1 = new float[x, y];
      float[,] numArray2 = new float[x, y];
      float[,] numArray3 = new float[x, y];
      float[,] numArray4 = new float[x, y];
      float[,] numArray5 = new float[x, y];
      float[,] numArray6 = new float[x, y];
      float[,] numArray7 = new float[x, y];
      for (int index1 = 0; index1 < y; ++index1)
      {
        for (int index2 = 0; index2 < x; ++index2)
        {
          numArray1[index2, index1] = 0.0f;
          numArray2[index2, index1] = 0.0f;
          numArray3[index2, index1] = 0.0f;
          numArray4[index2, index1] = 0.0f;
          numArray5[index2, index1] = 0.0f;
          numArray6[index2, index1] = 0.0f;
          numArray7[index2, index1] = 0.0f;
        }
      }
      for (int iteration = 0; iteration < iterations; ++iteration)
      {
        for (int index3 = 0; index3 < y; ++index3)
        {
          for (int index4 = 0; index4 < x; ++index4)
          {
            float num1 = numArray3[index4, index3];
            float height = heightMap[index4, index3];
            float num2 = numArray5[index4, index3];
            float num3 = num2 * this.windGravity;
            numArray5[index4, index3] = num2 - num3;
            heightMap[index4, index3] = height + num3;
          }
        }
        for (int index5 = 0; index5 < y; ++index5)
        {
          for (int index6 = 0; index6 < x; ++index6)
          {
            float height = heightMap[index6, index5];
            Vector3 interpolatedNormal = terrainData.GetInterpolatedNormal((float) index6 / (float) x, (float) index5 / (float) y);
            float num4 = (float) (((double) Vector3.Angle(interpolatedNormal, to) - 90.0) / 90.0);
            if ((double) num4 < 0.0)
              num4 = 0.0f;
            numArray1[index6, index5] = num4 * height;
            float num5 = (float) (1.0 - (double) Mathf.Abs(Vector3.Angle(interpolatedNormal, to) - 90f) / 90.0);
            numArray2[index6, index5] = num5 * height;
            float num6 = num5 * height * this.windForce;
            float num7 = numArray3[index6, index5] + num6;
            numArray3[index6, index5] = num7;
            float num8 = numArray5[index6, index5];
            float num9 = this.windLift * num7;
            if ((double) num8 + (double) num9 > (double) this.windCapacity)
              num9 = this.windCapacity - num8;
            numArray5[index6, index5] = num8 + num9;
            heightMap[index6, index5] = height - num9;
          }
        }
        for (int index7 = 0; index7 < y; ++index7)
        {
          int num10;
          int num11;
          int num12;
          if (index7 == 0)
          {
            num10 = 2;
            num11 = 0;
            num12 = 0;
          }
          else if (index7 == y - 1)
          {
            num10 = 2;
            num11 = -1;
            num12 = 1;
          }
          else
          {
            num10 = 3;
            num11 = -1;
            num12 = 1;
          }
          for (int index8 = 0; index8 < x; ++index8)
          {
            int num13;
            int num14;
            int num15;
            if (index8 == 0)
            {
              num13 = 2;
              num14 = 0;
              num15 = 0;
            }
            else if (index8 == x - 1)
            {
              num13 = 2;
              num14 = -1;
              num15 = 1;
            }
            else
            {
              num13 = 3;
              num14 = -1;
              num15 = 1;
            }
            float num16 = numArray2[index8, index7];
            float num17 = numArray1[index8, index7];
            float num18 = numArray5[index8, index7];
            for (int index9 = 0; index9 < num10; ++index9)
            {
              for (int index10 = 0; index10 < num13; ++index10)
              {
                if ((index10 != num15 || index9 != num12) && (this.p_neighbourhood == TerrainToolkit.Neighbourhood.Moore || this.p_neighbourhood == TerrainToolkit.Neighbourhood.VonNeumann && (index10 == num15 || index9 == num12)))
                {
                  float num19 = (float) ((90.0 - (double) Vector3.Angle(new Vector3((float) (index10 + num14), 0.0f, (float) (-1 * (index9 + num11))), to)) / 90.0);
                  if ((double) num19 < 0.0)
                    num19 = 0.0f;
                  double num20 = (double) numArray4[index8 + index10 + num14, index7 + index9 + num11];
                  float num21 = (float) ((double) num19 * ((double) num16 - (double) num17) * 0.10000000149011612);
                  if ((double) num21 < 0.0)
                    num21 = 0.0f;
                  double num22 = (double) num21;
                  float num23 = (float) (num20 + num22);
                  numArray4[index8 + index10 + num14, index7 + index9 + num11] = num23;
                  float num24 = numArray4[index8, index7] - num21;
                  numArray4[index8, index7] = num24;
                  double num25 = (double) numArray6[index8 + index10 + num14, index7 + index9 + num11];
                  float num26 = num18 * num21;
                  double num27 = (double) num26;
                  float num28 = (float) (num25 + num27);
                  numArray6[index8 + index10 + num14, index7 + index9 + num11] = num28;
                  float num29 = numArray6[index8, index7] - num26;
                  numArray6[index8, index7] = num29;
                }
              }
            }
          }
        }
        for (int index11 = 0; index11 < y; ++index11)
        {
          for (int index12 = 0; index12 < x; ++index12)
          {
            float num = numArray5[index12, index11] + numArray6[index12, index11];
            if ((double) num > 1.0)
              num = 1f;
            else if ((double) num < 0.0)
              num = 0.0f;
            numArray5[index12, index11] = num;
            numArray6[index12, index11] = 0.0f;
          }
        }
        for (int index13 = 0; index13 < y; ++index13)
        {
          for (int index14 = 0; index14 < x; ++index14)
          {
            float num = (numArray3[index14, index13] + numArray4[index14, index13]) * (1f - this.windEntropy);
            if ((double) num > 1.0)
              num = 1f;
            else if ((double) num < 0.0)
              num = 0.0f;
            numArray3[index14, index13] = num;
            numArray4[index14, index13] = 0.0f;
          }
        }
        this.smoothIterations = 1;
        this.smoothBlend = 0.25f;
        float[,] heightMap1 = (float[,]) heightMap.Clone();
        TerrainToolkit.GeneratorProgressDelegate generatorProgressDelegate = new TerrainToolkit.GeneratorProgressDelegate(this.dummyGeneratorProgress);
        float[,] numArray8 = this.smooth(heightMap1, arraySize, generatorProgressDelegate);
        for (int index15 = 0; index15 < y; ++index15)
        {
          for (int index16 = 0; index16 < x; ++index16)
          {
            float height = heightMap[index16, index15];
            double num30 = (double) numArray8[index16, index15];
            float num31 = numArray1[index16, index15] * this.windSmoothing;
            double num32 = (double) num31;
            float num33 = (float) (num30 * num32 + (double) height * (1.0 - (double) num31));
            heightMap[index16, index15] = num33;
          }
        }
        float percentComplete = (float) iteration / (float) iterations;
        erosionProgressDelegate("Applying Wind Erosion", "Applying wind erosion.", iteration, iterations, percentComplete);
      }
      return heightMap;
    }

    public void textureTerrain(
      TerrainToolkit.TextureProgressDelegate textureProgressDelegate)
    {
      Terrain component = (Terrain) this.GetComponent(typeof (Terrain));
      if ((UnityEngine.Object) component == (UnityEngine.Object) null)
        return;
      TerrainData terrainData = component.terrainData;
      this.terrainLayers = terrainData.terrainLayers;
      int length1 = this.terrainLayers.Length;
      if (length1 < 2)
      {
        Debug.LogError((object) "Error: You must assign at least 2 textures.");
      }
      else
      {
        textureProgressDelegate("Procedural Terrain Texture", "Generating height and slope maps. Please wait.", 0.1f);
        int length2 = terrainData.heightmapResolution - 1;
        int height = terrainData.heightmapResolution - 1;
        float[,] numArray1 = new float[length2, height];
        float[,] numArray2 = new float[length2, height];
        float[,,] alphamaps = terrainData.GetAlphamaps(0, 0, length2, length2);
        terrainData.alphamapResolution = length2;
        Vector3 size = terrainData.size;
        double num1 = (double) size.x / ((double) length2 * (double) size.y);
        float num2 = (float) num1 * Mathf.Tan(this.slopeBlendMinAngle * ((float) Math.PI / 180f));
        float num3 = (float) num1 * Mathf.Tan(this.slopeBlendMaxAngle * ((float) Math.PI / 180f));
        float num4 = num3 - num2;
        float[,] numArray3;
        float[,] numArray4;
        float[,,] numArray5;
        try
        {
          textureProgressDelegate("Procedural Terrain Texture", "Generating height and slope maps. Please wait.", 0.25f);
          float[,] heights = terrainData.GetHeights(0, 0, length2, height);
          for (int index1 = 0; index1 < height; ++index1)
          {
            int num5;
            int num6;
            int num7;
            if (index1 == 0)
            {
              num5 = 2;
              num6 = 0;
              num7 = 0;
            }
            else if (index1 == height - 1)
            {
              num5 = 2;
              num6 = -1;
              num7 = 1;
            }
            else
            {
              num5 = 3;
              num6 = -1;
              num7 = 1;
            }
            for (int index2 = 0; index2 < length2; ++index2)
            {
              int num8;
              int num9;
              int num10;
              if (index2 == 0)
              {
                num8 = 2;
                num9 = 0;
                num10 = 0;
              }
              else if (index2 == length2 - 1)
              {
                num8 = 2;
                num9 = -1;
                num10 = 1;
              }
              else
              {
                num8 = 3;
                num9 = -1;
                num10 = 1;
              }
              float num11 = heights[index2 + num10 + num9, index1 + num7 + num6];
              numArray1[index2, index1] = num11;
              float num12 = 0.0f;
              float num13 = (float) (num8 * num5 - 1);
              for (int index3 = 0; index3 < num5; ++index3)
              {
                for (int index4 = 0; index4 < num8; ++index4)
                {
                  if (index4 != num10 || index3 != num7)
                    num12 += Mathf.Abs(num11 - heights[index2 + index4 + num9, index1 + index3 + num6]);
                }
              }
              numArray2[index2, index1] = num12 / num13;
            }
          }
          textureProgressDelegate("Procedural Terrain Texture", "Generating height and slope maps. Please wait.", 0.6f);
          for (int index5 = 0; index5 < height; ++index5)
          {
            for (int index6 = 0; index6 < length2; ++index6)
            {
              float num14 = numArray2[index6, index5];
              if ((double) num14 < (double) num2)
                num14 = 0.0f;
              else if ((double) num14 <= (double) num3)
                num14 = Mathf.Clamp01((num14 - num2) / num4);
              else if ((double) num14 > (double) num3)
                num14 = 1f;
              numArray2[index6, index5] = num14;
              alphamaps[index6, index5, 0] = num14;
              float num15 = num14;
              for (int index7 = 1; index7 < length1; ++index7)
              {
                float num16 = 0.0f;
                float num17 = 0.0f;
                float num18 = 1f;
                float num19 = 1f;
                if (index7 > 1)
                {
                  num16 = this.heightBlendPoints[index7 * 2 - 4];
                  num17 = this.heightBlendPoints[index7 * 2 - 3];
                }
                if (index7 < length1 - 1)
                {
                  num18 = this.heightBlendPoints[index7 * 2 - 2];
                  num19 = this.heightBlendPoints[index7 * 2 - 1];
                }
                float num20 = numArray1[index6, index5];
                float num21 = 0.0f;
                if ((double) num20 >= (double) num17 && (double) num20 <= (double) num18)
                  num21 = 1f;
                else if ((double) num20 >= (double) num16 && (double) num20 < (double) num17)
                  num21 = Mathf.Clamp01((float) (((double) num20 - (double) num16) / ((double) num17 - (double) num16)));
                else if ((double) num20 > (double) num18 && (double) num20 <= (double) num19)
                  num21 = Mathf.Clamp01((float) (1.0 - ((double) num20 - (double) num18) / ((double) num19 - (double) num18)));
                alphamaps[index6, index5, index7] = Mathf.Clamp01(num21 - numArray2[index6, index5]);
                num15 += alphamaps[index6, index5, index7];
              }
              if ((double) num15 < 1.0)
                alphamaps[index6, index5, 0] = Mathf.Clamp01(alphamaps[index6, index5, 0] + 1f - num15);
            }
          }
          textureProgressDelegate("Procedural Terrain Texture", "Generating splat map. Please wait.", 0.9f);
          terrainData.SetAlphamaps(0, 0, alphamaps);
          numArray3 = (float[,]) null;
          numArray4 = (float[,]) null;
          numArray5 = (float[,,]) null;
        }
        catch (Exception ex)
        {
          numArray3 = (float[,]) null;
          numArray4 = (float[,]) null;
          numArray5 = (float[,,]) null;
          Debug.LogError((object) ("An error occurred : " + ex?.ToString()));
        }
      }
    }

    public void BuildPaths()
    {
      this.layersPath = Application.dataPath + Path.DirectorySeparatorChar.ToString() + "TerrainToolkitLayers" + Path.DirectorySeparatorChar.ToString() + this.gameObject.name + "_Layers";
      this.assetPath = "Assets" + Path.DirectorySeparatorChar.ToString() + "TerrainToolkitLayers" + Path.DirectorySeparatorChar.ToString() + this.gameObject.name + "_Layers" + Path.DirectorySeparatorChar.ToString();
      Directory.CreateDirectory(this.layersPath);
    }

    public void addTerrainLayer(Texture2D tex, int index)
    {
    }

    public void deleteTerrainLayer(Texture2D tex, int index)
    {
    }

    public void deleteAllTerrainLayers()
    {
    }

    public void addBlendPoints()
    {
      float num = 0.0f;
      if (this.heightBlendPoints.Count > 0)
        num = this.heightBlendPoints[this.heightBlendPoints.Count - 1];
      this.heightBlendPoints.Add(num + (float) ((1.0 - (double) num) * 0.33000001311302185));
      this.heightBlendPoints.Add(num + (float) ((1.0 - (double) num) * 0.6600000262260437));
    }

    public void deleteBlendPoints()
    {
      if (this.heightBlendPoints.Count > 0)
        this.heightBlendPoints.RemoveAt(this.heightBlendPoints.Count - 1);
      if (this.heightBlendPoints.Count <= 0)
        return;
      this.heightBlendPoints.RemoveAt(this.heightBlendPoints.Count - 1);
    }

    public void deleteAllBlendPoints()
    {
      this.heightBlendPoints.Clear();
      this.heightBlendPoints = new List<float>();
    }

    public void generateTerrain(
      TerrainToolkit.GeneratorProgressDelegate generatorProgressDelegate)
    {
      this.convertIntVarsToEnums();
      Terrain component = this.gameObject.GetComponent<Terrain>();
      if ((UnityEngine.Object) component == (UnityEngine.Object) null)
        return;
      TerrainData terrainData = component.terrainData;
      int heightmapResolution1 = terrainData.heightmapResolution;
      int heightmapResolution2 = terrainData.heightmapResolution;
      float[,] heights = terrainData.GetHeights(0, 0, heightmapResolution1, heightmapResolution2);
      float[,] heightMap = (float[,]) heights.Clone();
      float[,] numArray;
      switch (this.p_generatorType)
      {
        case TerrainToolkit.GeneratorType.Voronoi:
          numArray = this.generateVoronoi(heightMap, new Vector2((float) heightmapResolution1, (float) heightmapResolution2), generatorProgressDelegate);
          break;
        case TerrainToolkit.GeneratorType.DiamondSquare:
          numArray = this.generateDiamondSquare(heightMap, new Vector2((float) heightmapResolution1, (float) heightmapResolution2), generatorProgressDelegate);
          break;
        case TerrainToolkit.GeneratorType.Perlin:
          numArray = this.generatePerlin(heightMap, new Vector2((float) heightmapResolution1, (float) heightmapResolution2), generatorProgressDelegate);
          break;
        case TerrainToolkit.GeneratorType.Smooth:
          numArray = this.smooth(heightMap, new Vector2((float) heightmapResolution1, (float) heightmapResolution2), generatorProgressDelegate);
          break;
        case TerrainToolkit.GeneratorType.Normalise:
          numArray = this.normalise(heightMap, new Vector2((float) heightmapResolution1, (float) heightmapResolution2), generatorProgressDelegate);
          break;
        default:
          return;
      }
      for (int index1 = 0; index1 < heightmapResolution2; ++index1)
      {
        for (int index2 = 0; index2 < heightmapResolution1; ++index2)
        {
          float num1 = heights[index2, index1];
          float num2 = numArray[index2, index1];
          float num3 = 0.0f;
          switch (this.p_generatorType)
          {
            case TerrainToolkit.GeneratorType.Voronoi:
              num3 = (float) ((double) num2 * (double) this.voronoiBlend + (double) num1 * (1.0 - (double) this.voronoiBlend));
              break;
            case TerrainToolkit.GeneratorType.DiamondSquare:
              num3 = (float) ((double) num2 * (double) this.diamondSquareBlend + (double) num1 * (1.0 - (double) this.diamondSquareBlend));
              break;
            case TerrainToolkit.GeneratorType.Perlin:
              num3 = (float) ((double) num2 * (double) this.perlinBlend + (double) num1 * (1.0 - (double) this.perlinBlend));
              break;
            case TerrainToolkit.GeneratorType.Smooth:
              num3 = (float) ((double) num2 * (double) this.smoothBlend + (double) num1 * (1.0 - (double) this.smoothBlend));
              break;
            case TerrainToolkit.GeneratorType.Normalise:
              num3 = (float) ((double) num2 * (double) this.normaliseBlend + (double) num1 * (1.0 - (double) this.normaliseBlend));
              break;
          }
          heights[index2, index1] = num3;
        }
      }
      terrainData.SetHeights(0, 0, heights);
    }

    public float[,] generateVoronoi(
      float[,] heightMap,
      Vector2 arraySize,
      TerrainToolkit.GeneratorProgressDelegate generatorProgressDelegate)
    {
      int x1 = (int) arraySize.x;
      int y1 = (int) arraySize.y;
      ArrayList arrayList1 = new ArrayList();
      for (int index = 0; index < this.voronoiCells; ++index)
      {
        TerrainToolkit.Peak peak = new TerrainToolkit.Peak();
        int x2 = (int) Mathf.Floor(UnityEngine.Random.value * (float) x1);
        int y2 = (int) Mathf.Floor(UnityEngine.Random.value * (float) y1);
        float num = UnityEngine.Random.value;
        if ((double) UnityEngine.Random.value > (double) this.voronoiFeatures)
          num = 0.0f;
        peak.peakPoint = new Vector2((float) x2, (float) y2);
        peak.peakHeight = num;
        arrayList1.Add((object) peak);
      }
      float num1 = 0.0f;
      for (int y3 = 0; y3 < y1; ++y3)
      {
        for (int x3 = 0; x3 < x1; ++x3)
        {
          ArrayList arrayList2 = new ArrayList();
          for (int index = 0; index < this.voronoiCells; ++index)
          {
            float num2 = Vector2.Distance(((TerrainToolkit.Peak) arrayList1[index]).peakPoint, new Vector2((float) x3, (float) y3));
            arrayList2.Add((object) new TerrainToolkit.PeakDistance()
            {
              id = index,
              dist = num2
            });
          }
          arrayList2.Sort();
          TerrainToolkit.PeakDistance peakDistance1 = (TerrainToolkit.PeakDistance) arrayList2[0];
          TerrainToolkit.PeakDistance peakDistance2 = (TerrainToolkit.PeakDistance) arrayList2[1];
          int id = peakDistance1.id;
          float dist1 = peakDistance1.dist;
          float dist2 = peakDistance2.dist;
          float num3 = Mathf.Abs(dist1 - dist2) / ((float) (x1 + y1) / Mathf.Sqrt((float) this.voronoiCells));
          float peakHeight = ((TerrainToolkit.Peak) arrayList1[id]).peakHeight;
          float num4 = peakHeight - Mathf.Abs(dist1 / dist2) * peakHeight;
          switch (this.p_voronoiType)
          {
            case TerrainToolkit.VoronoiType.Sine:
              num4 = (float) (0.5 + (double) Mathf.Sin((float) ((double) num4 * 3.1415927410125732 - 1.5707963705062866)) / 2.0);
              break;
            case TerrainToolkit.VoronoiType.Tangent:
              num4 = (float) (0.5 + (double) Mathf.Tan((float) ((double) num4 * 3.1415927410125732 / 2.0)) / 2.0);
              break;
          }
          float num5 = (float) ((double) num4 * (double) num3 * (double) this.voronoiScale + (double) num4 * (1.0 - (double) this.voronoiScale));
          if ((double) num5 < 0.0)
            num5 = 0.0f;
          else if ((double) num5 > 1.0)
            num5 = 1f;
          heightMap[x3, y3] = num5;
          if ((double) num5 > (double) num1)
            num1 = num5;
        }
        float percentComplete = (float) (y3 * y1) / (float) (x1 * y1);
        generatorProgressDelegate("Voronoi Generator", "Generating height map. Please wait.", percentComplete);
      }
      for (int index1 = 0; index1 < y1; ++index1)
      {
        for (int index2 = 0; index2 < x1; ++index2)
        {
          float num6 = heightMap[index2, index1] * (1f / num1);
          heightMap[index2, index1] = num6;
        }
      }
      return heightMap;
    }

    public float[,] generateDiamondSquare(
      float[,] heightMap,
      Vector2 arraySize,
      TerrainToolkit.GeneratorProgressDelegate generatorProgressDelegate)
    {
      int x1 = (int) arraySize.x;
      int y1 = (int) arraySize.y;
      float heightRange = 1f;
      int num1 = x1 - 1;
      heightMap[0, 0] = 0.5f;
      heightMap[x1 - 1, 0] = 0.5f;
      heightMap[0, y1 - 1] = 0.5f;
      heightMap[x1 - 1, y1 - 1] = 0.5f;
      generatorProgressDelegate("Fractal Generator", "Generating height map. Please wait.", 0.0f);
      for (; num1 > 1; num1 >>= 1)
      {
        for (int x2 = 0; x2 < x1 - 1; x2 += num1)
        {
          for (int y2 = 0; y2 < y1 - 1; y2 += num1)
          {
            int Tx = x2 + (num1 >> 1);
            int Ty = y2 + (num1 >> 1);
            Vector2[] points = new Vector2[4]
            {
              new Vector2((float) x2, (float) y2),
              new Vector2((float) (x2 + num1), (float) y2),
              new Vector2((float) x2, (float) (y2 + num1)),
              new Vector2((float) (x2 + num1), (float) (y2 + num1))
            };
            this.dsCalculateHeight(heightMap, arraySize, Tx, Ty, points, heightRange);
          }
        }
        for (int index1 = 0; index1 < x1 - 1; index1 += num1)
        {
          for (int index2 = 0; index2 < y1 - 1; index2 += num1)
          {
            int num2 = num1 >> 1;
            int num3 = index1 + num2;
            int num4 = index2;
            int num5 = index1;
            int num6 = index2 + num2;
            Vector2[] points1 = new Vector2[4]
            {
              new Vector2((float) (num3 - num2), (float) num4),
              new Vector2((float) num3, (float) (num4 - num2)),
              new Vector2((float) (num3 + num2), (float) num4),
              new Vector2((float) num3, (float) (num4 + num2))
            };
            Vector2[] points2 = new Vector2[4]
            {
              new Vector2((float) (num5 - num2), (float) num6),
              new Vector2((float) num5, (float) (num6 - num2)),
              new Vector2((float) (num5 + num2), (float) num6),
              new Vector2((float) num5, (float) (num6 + num2))
            };
            this.dsCalculateHeight(heightMap, arraySize, num3, num4, points1, heightRange);
            this.dsCalculateHeight(heightMap, arraySize, num5, num6, points2, heightRange);
          }
        }
        heightRange *= this.diamondSquareDelta;
      }
      generatorProgressDelegate("Fractal Generator", "Generating height map. Please wait.", 1f);
      return heightMap;
    }

    public void dsCalculateHeight(
      float[,] heightMap,
      Vector2 arraySize,
      int Tx,
      int Ty,
      Vector2[] points,
      float heightRange)
    {
      int x = (int) arraySize.x;
      int y = (int) arraySize.y;
      float num1 = 0.0f;
      for (int index = 0; index < 4; ++index)
      {
        if ((double) points[index].x < 0.0)
          points[index].x += (float) (x - 1);
        else if ((double) points[index].x > (double) x)
          points[index].x -= (float) (x - 1);
        else if ((double) points[index].y < 0.0)
          points[index].y += (float) (y - 1);
        else if ((double) points[index].y > (double) y)
          points[index].y -= (float) (y - 1);
        num1 += heightMap[(int) points[index].x, (int) points[index].y] / 4f;
      }
      float num2 = num1 + (float) ((double) UnityEngine.Random.value * (double) heightRange - (double) heightRange / 2.0);
      if ((double) num2 < 0.0)
        num2 = 0.0f;
      else if ((double) num2 > 1.0)
        num2 = 1f;
      heightMap[Tx, Ty] = num2;
      if (Tx == 0)
        heightMap[x - 1, Ty] = num2;
      else if (Tx == x - 1)
        heightMap[0, Ty] = num2;
      else if (Ty == 0)
      {
        heightMap[Tx, y - 1] = num2;
      }
      else
      {
        if (Ty != y - 1)
          return;
        heightMap[Tx, 0] = num2;
      }
    }

    public float[,] generatePerlin(
      float[,] heightMap,
      Vector2 arraySize,
      TerrainToolkit.GeneratorProgressDelegate generatorProgressDelegate)
    {
      int x = (int) arraySize.x;
      int y = (int) arraySize.y;
      for (int index1 = 0; index1 < y; ++index1)
      {
        for (int index2 = 0; index2 < x; ++index2)
          heightMap[index2, index1] = 0.0f;
      }
      TerrainToolkit.PerlinNoise2D[] perlinNoise2DArray = new TerrainToolkit.PerlinNoise2D[this.perlinOctaves];
      int perlinFrequency = this.perlinFrequency;
      float _amp = 1f;
      for (int index = 0; index < this.perlinOctaves; ++index)
      {
        perlinNoise2DArray[index] = new TerrainToolkit.PerlinNoise2D(perlinFrequency, _amp);
        perlinFrequency *= 2;
        _amp /= 2f;
      }
      for (int index3 = 0; index3 < this.perlinOctaves; ++index3)
      {
        double num1 = (double) x / (double) perlinNoise2DArray[index3].Frequency;
        double num2 = (double) y / (double) perlinNoise2DArray[index3].Frequency;
        for (int index4 = 0; index4 < x; ++index4)
        {
          for (int index5 = 0; index5 < y; ++index5)
          {
            int _xa = (int) ((double) index4 / num1);
            int _xb = _xa + 1;
            int _ya = (int) ((double) index5 / num2);
            int _yb = _ya + 1;
            double interpolatedPoint = perlinNoise2DArray[index3].getInterpolatedPoint(_xa, _xb, _ya, _yb, (double) index4 / num1 - (double) _xa, (double) index5 / num2 - (double) _ya);
            heightMap[index4, index5] += (float) interpolatedPoint * perlinNoise2DArray[index3].Amplitude;
          }
        }
        float percentComplete = (float) ((index3 + 1) / this.perlinOctaves);
        generatorProgressDelegate("Perlin Generator", "Generating height map. Please wait.", percentComplete);
      }
      TerrainToolkit.GeneratorProgressDelegate generatorProgressDelegate1 = new TerrainToolkit.GeneratorProgressDelegate(this.dummyGeneratorProgress);
      float normaliseMin = this.normaliseMin;
      float normaliseMax = this.normaliseMax;
      float normaliseBlend = this.normaliseBlend;
      this.normaliseMin = 0.0f;
      this.normaliseMax = 1f;
      this.normaliseBlend = 1f;
      heightMap = this.normalise(heightMap, arraySize, generatorProgressDelegate1);
      this.normaliseMin = normaliseMin;
      this.normaliseMax = normaliseMax;
      this.normaliseBlend = normaliseBlend;
      for (int index6 = 0; index6 < x; ++index6)
      {
        for (int index7 = 0; index7 < y; ++index7)
          heightMap[index6, index7] = heightMap[index6, index7] * this.perlinAmplitude;
      }
      for (int index = 0; index < this.perlinOctaves; ++index)
        perlinNoise2DArray[index] = (TerrainToolkit.PerlinNoise2D) null;
      return heightMap;
    }

    public float[,] smooth(
      float[,] heightMap,
      Vector2 arraySize,
      TerrainToolkit.GeneratorProgressDelegate generatorProgressDelegate)
    {
      int x = (int) arraySize.x;
      int y = (int) arraySize.y;
      for (int index1 = 0; index1 < this.smoothIterations; ++index1)
      {
        for (int index2 = 0; index2 < y; ++index2)
        {
          int num1;
          int num2;
          int num3;
          if (index2 == 0)
          {
            num1 = 2;
            num2 = 0;
            num3 = 0;
          }
          else if (index2 == y - 1)
          {
            num1 = 2;
            num2 = -1;
            num3 = 1;
          }
          else
          {
            num1 = 3;
            num2 = -1;
            num3 = 1;
          }
          for (int index3 = 0; index3 < x; ++index3)
          {
            int num4;
            int num5;
            int num6;
            if (index3 == 0)
            {
              num4 = 2;
              num5 = 0;
              num6 = 0;
            }
            else if (index3 == x - 1)
            {
              num4 = 2;
              num5 = -1;
              num6 = 1;
            }
            else
            {
              num4 = 3;
              num5 = -1;
              num6 = 1;
            }
            float num7 = 0.0f;
            int num8 = 0;
            for (int index4 = 0; index4 < num1; ++index4)
            {
              for (int index5 = 0; index5 < num4; ++index5)
              {
                if (this.p_neighbourhood == TerrainToolkit.Neighbourhood.Moore || this.p_neighbourhood == TerrainToolkit.Neighbourhood.VonNeumann && (index5 == num6 || index4 == num3))
                {
                  float height = heightMap[index3 + index5 + num5, index2 + index4 + num2];
                  num7 += height;
                  ++num8;
                }
              }
            }
            float num9 = num7 / (float) num8;
            heightMap[index3 + num6 + num5, index2 + num3 + num2] = num9;
          }
        }
        float percentComplete = (float) ((index1 + 1) / this.smoothIterations);
        generatorProgressDelegate("Smoothing Filter", "Smoothing height map. Please wait.", percentComplete);
      }
      return heightMap;
    }

    public float[,] normalise(
      float[,] heightMap,
      Vector2 arraySize,
      TerrainToolkit.GeneratorProgressDelegate generatorProgressDelegate)
    {
      int x = (int) arraySize.x;
      int y = (int) arraySize.y;
      float num1 = 0.0f;
      float num2 = 1f;
      generatorProgressDelegate("Normalise Filter", "Normalising height map. Please wait.", 0.0f);
      for (int index1 = 0; index1 < y; ++index1)
      {
        for (int index2 = 0; index2 < x; ++index2)
        {
          float height = heightMap[index2, index1];
          if ((double) height < (double) num2)
            num2 = height;
          else if ((double) height > (double) num1)
            num1 = height;
        }
      }
      generatorProgressDelegate("Normalise Filter", "Normalising height map. Please wait.", 0.5f);
      float num3 = num1 - num2;
      float num4 = this.normaliseMax - this.normaliseMin;
      for (int index3 = 0; index3 < y; ++index3)
      {
        for (int index4 = 0; index4 < x; ++index4)
        {
          float num5 = (heightMap[index4, index3] - num2) / num3 * num4;
          heightMap[index4, index3] = this.normaliseMin + num5;
        }
      }
      generatorProgressDelegate("Normalise Filter", "Normalising height map. Please wait.", 1f);
      return heightMap;
    }

    public void FastThermalErosion(int iterations, float minSlope, float blendAmount)
    {
      this.erosionTypeInt = 0;
      this.p_erosionType = TerrainToolkit.ErosionType.Thermal;
      this.thermalIterations = iterations;
      this.thermalMinSlope = minSlope;
      this.thermalFalloff = blendAmount;
      this.p_neighbourhood = TerrainToolkit.Neighbourhood.Moore;
      this.erodeAllTerrain(new TerrainToolkit.ErosionProgressDelegate(this.dummyErosionProgress));
    }

    public void FastHydraulicErosion(int iterations, float maxSlope, float blendAmount)
    {
      this.erosionTypeInt = 1;
      this.p_erosionType = TerrainToolkit.ErosionType.Hydraulic;
      this.hydraulicTypeInt = 0;
      this.p_hydraulicType = TerrainToolkit.HydraulicType.Fast;
      this.hydraulicIterations = iterations;
      this.hydraulicMaxSlope = maxSlope;
      this.hydraulicFalloff = blendAmount;
      this.p_neighbourhood = TerrainToolkit.Neighbourhood.Moore;
      this.erodeAllTerrain(new TerrainToolkit.ErosionProgressDelegate(this.dummyErosionProgress));
    }

    public void FullHydraulicErosion(
      int iterations,
      float rainfall,
      float evaporation,
      float solubility,
      float saturation)
    {
      this.erosionTypeInt = 1;
      this.p_erosionType = TerrainToolkit.ErosionType.Hydraulic;
      this.hydraulicTypeInt = 1;
      this.p_hydraulicType = TerrainToolkit.HydraulicType.Full;
      this.hydraulicIterations = iterations;
      this.hydraulicRainfall = rainfall;
      this.hydraulicEvaporation = evaporation;
      this.hydraulicSedimentSolubility = solubility;
      this.hydraulicSedimentSaturation = saturation;
      this.p_neighbourhood = TerrainToolkit.Neighbourhood.Moore;
      this.erodeAllTerrain(new TerrainToolkit.ErosionProgressDelegate(this.dummyErosionProgress));
    }

    public void VelocityHydraulicErosion(
      int iterations,
      float rainfall,
      float evaporation,
      float solubility,
      float saturation,
      float velocity,
      float momentum,
      float entropy,
      float downcutting)
    {
      this.erosionTypeInt = 1;
      this.p_erosionType = TerrainToolkit.ErosionType.Hydraulic;
      this.hydraulicTypeInt = 2;
      this.p_hydraulicType = TerrainToolkit.HydraulicType.Velocity;
      this.hydraulicIterations = iterations;
      this.hydraulicVelocityRainfall = rainfall;
      this.hydraulicVelocityEvaporation = evaporation;
      this.hydraulicVelocitySedimentSolubility = solubility;
      this.hydraulicVelocitySedimentSaturation = saturation;
      this.hydraulicVelocity = velocity;
      this.hydraulicMomentum = momentum;
      this.hydraulicEntropy = entropy;
      this.hydraulicDowncutting = downcutting;
      this.p_neighbourhood = TerrainToolkit.Neighbourhood.Moore;
      this.erodeAllTerrain(new TerrainToolkit.ErosionProgressDelegate(this.dummyErosionProgress));
    }

    public void TidalErosion(int iterations, float seaLevel, float tidalRange, float cliffLimit)
    {
      this.erosionTypeInt = 2;
      this.p_erosionType = TerrainToolkit.ErosionType.Tidal;
      this.tidalIterations = iterations;
      this.tidalSeaLevel = seaLevel;
      this.tidalRangeAmount = tidalRange;
      this.tidalCliffLimit = cliffLimit;
      this.p_neighbourhood = TerrainToolkit.Neighbourhood.Moore;
      this.erodeAllTerrain(new TerrainToolkit.ErosionProgressDelegate(this.dummyErosionProgress));
    }

    public void WindErosion(
      int iterations,
      float direction,
      float force,
      float lift,
      float gravity,
      float capacity,
      float entropy,
      float smoothing)
    {
      this.erosionTypeInt = 3;
      this.p_erosionType = TerrainToolkit.ErosionType.Wind;
      this.windIterations = iterations;
      this.windDirection = direction;
      this.windForce = force;
      this.windLift = lift;
      this.windGravity = gravity;
      this.windCapacity = capacity;
      this.windEntropy = entropy;
      this.windSmoothing = smoothing;
      this.p_neighbourhood = TerrainToolkit.Neighbourhood.Moore;
      this.erodeAllTerrain(new TerrainToolkit.ErosionProgressDelegate(this.dummyErosionProgress));
    }

    public void TextureTerrain(float[] slopeStops, float[] heightStops, Texture2D[] textures)
    {
      if (slopeStops.Length != 2)
        Debug.LogError((object) "Error: slopeStops must have 2 values");
      else if (heightStops.Length > 8)
        Debug.LogError((object) "Error: heightStops must have no more than 8 values");
      else if (heightStops.Length % 2 != 0)
        Debug.LogError((object) "Error: heightStops must have an even number of values");
      else if (textures.Length != heightStops.Length / 2 + 2)
      {
        Debug.LogError((object) "Error: heightStops contains an incorrect number of values");
      }
      else
      {
        foreach (float slopeStop in slopeStops)
        {
          if ((double) slopeStop < 0.0 || (double) slopeStop > 90.0)
          {
            Debug.LogError((object) "Error: The value of all slopeStops must be in the range 0.0 to 90.0");
            return;
          }
        }
        foreach (float heightStop in heightStops)
        {
          if ((double) heightStop < 0.0 || (double) heightStop > 1.0)
          {
            Debug.LogError((object) "Error: The value of all heightStops must be in the range 0.0 to 1.0");
            return;
          }
        }
        TerrainData terrainData = ((Terrain) this.GetComponent(typeof (Terrain))).terrainData;
        this.terrainLayers = terrainData.terrainLayers;
        this.deleteAllTerrainLayers();
        int index1 = 0;
        foreach (Texture2D texture in textures)
        {
          this.addTerrainLayer(texture, index1);
          ++index1;
        }
        this.slopeBlendMinAngle = slopeStops[0];
        this.slopeBlendMaxAngle = slopeStops[1];
        int index2 = 0;
        foreach (float heightStop in heightStops)
        {
          this.heightBlendPoints[index2] = heightStop;
          ++index2;
        }
        terrainData.terrainLayers = this.terrainLayers;
        this.textureTerrain(new TerrainToolkit.TextureProgressDelegate(this.dummyTextureProgress));
      }
    }

    public void VoronoiGenerator(
      TerrainToolkit.FeatureType featureType,
      int cells,
      float features,
      float scale,
      float blend)
    {
      this.generatorTypeInt = 0;
      this.p_generatorType = TerrainToolkit.GeneratorType.Voronoi;
      switch (featureType)
      {
        case TerrainToolkit.FeatureType.Mountains:
          this.voronoiTypeInt = 0;
          this.p_voronoiType = TerrainToolkit.VoronoiType.Linear;
          break;
        case TerrainToolkit.FeatureType.Hills:
          this.voronoiTypeInt = 1;
          this.p_voronoiType = TerrainToolkit.VoronoiType.Sine;
          break;
        case TerrainToolkit.FeatureType.Plateaus:
          this.voronoiTypeInt = 2;
          this.p_voronoiType = TerrainToolkit.VoronoiType.Tangent;
          break;
      }
      this.voronoiCells = cells;
      this.voronoiFeatures = features;
      this.voronoiScale = scale;
      this.voronoiBlend = blend;
      this.generateTerrain(new TerrainToolkit.GeneratorProgressDelegate(this.dummyGeneratorProgress));
    }

    public void FractalGenerator(float fractalDelta, float blend)
    {
      this.generatorTypeInt = 1;
      this.p_generatorType = TerrainToolkit.GeneratorType.DiamondSquare;
      this.diamondSquareDelta = fractalDelta;
      this.diamondSquareBlend = blend;
      this.generateTerrain(new TerrainToolkit.GeneratorProgressDelegate(this.dummyGeneratorProgress));
    }

    public void PerlinGenerator(int frequency, float amplitude, int octaves, float blend)
    {
      this.generatorTypeInt = 2;
      this.p_generatorType = TerrainToolkit.GeneratorType.Perlin;
      this.perlinFrequency = frequency;
      this.perlinAmplitude = amplitude;
      this.perlinOctaves = octaves;
      this.perlinBlend = blend;
      this.generateTerrain(new TerrainToolkit.GeneratorProgressDelegate(this.dummyGeneratorProgress));
    }

    public void SmoothTerrain(int iterations, float blend)
    {
      this.generatorTypeInt = 3;
      this.p_generatorType = TerrainToolkit.GeneratorType.Smooth;
      this.smoothIterations = iterations;
      this.smoothBlend = blend;
      this.generateTerrain(new TerrainToolkit.GeneratorProgressDelegate(this.dummyGeneratorProgress));
    }

    public void NormaliseTerrain(float minHeight, float maxHeight, float blend)
    {
      this.generatorTypeInt = 4;
      this.p_generatorType = TerrainToolkit.GeneratorType.Normalise;
      this.normaliseMin = minHeight;
      this.normaliseMax = maxHeight;
      this.normaliseBlend = blend;
      this.generateTerrain(new TerrainToolkit.GeneratorProgressDelegate(this.dummyGeneratorProgress));
    }

    public void NormalizeTerrain(float minHeight, float maxHeight, float blend)
    {
      this.NormaliseTerrain(minHeight, maxHeight, blend);
    }

    public void convertIntVarsToEnums()
    {
      switch (this.erosionTypeInt)
      {
        case 0:
          this.p_erosionType = TerrainToolkit.ErosionType.Thermal;
          break;
        case 1:
          this.p_erosionType = TerrainToolkit.ErosionType.Hydraulic;
          break;
        case 2:
          this.p_erosionType = TerrainToolkit.ErosionType.Tidal;
          break;
        case 3:
          this.p_erosionType = TerrainToolkit.ErosionType.Wind;
          break;
        case 4:
          this.p_erosionType = TerrainToolkit.ErosionType.Glacial;
          break;
      }
      switch (this.hydraulicTypeInt)
      {
        case 0:
          this.p_hydraulicType = TerrainToolkit.HydraulicType.Fast;
          break;
        case 1:
          this.p_hydraulicType = TerrainToolkit.HydraulicType.Full;
          break;
        case 2:
          this.p_hydraulicType = TerrainToolkit.HydraulicType.Velocity;
          break;
      }
      switch (this.generatorTypeInt)
      {
        case 0:
          this.p_generatorType = TerrainToolkit.GeneratorType.Voronoi;
          break;
        case 1:
          this.p_generatorType = TerrainToolkit.GeneratorType.DiamondSquare;
          break;
        case 2:
          this.p_generatorType = TerrainToolkit.GeneratorType.Perlin;
          break;
        case 3:
          this.p_generatorType = TerrainToolkit.GeneratorType.Smooth;
          break;
        case 4:
          this.p_generatorType = TerrainToolkit.GeneratorType.Normalise;
          break;
      }
      switch (this.voronoiTypeInt)
      {
        case 0:
          this.p_voronoiType = TerrainToolkit.VoronoiType.Linear;
          break;
        case 1:
          this.p_voronoiType = TerrainToolkit.VoronoiType.Sine;
          break;
        case 2:
          this.p_voronoiType = TerrainToolkit.VoronoiType.Tangent;
          break;
      }
      switch (this.neighbourhoodInt)
      {
        case 0:
          this.p_neighbourhood = TerrainToolkit.Neighbourhood.Moore;
          break;
        case 1:
          this.p_neighbourhood = TerrainToolkit.Neighbourhood.VonNeumann;
          break;
      }
    }

    public void dummyErosionProgress(
      string titleString,
      string displayString,
      int iteration,
      int nIterations,
      float percentComplete)
    {
    }

    public void dummyTextureProgress(
      string titleString,
      string displayString,
      float percentComplete)
    {
    }

    public void dummyGeneratorProgress(
      string titleString,
      string displayString,
      float percentComplete)
    {
    }

    public void resetTerrain()
    {
      Terrain component = (Terrain) this.GetComponent(typeof (Terrain));
      if ((UnityEngine.Object) component == (UnityEngine.Object) null)
        return;
      try
      {
        TerrainData terrainData = component.terrainData;
        this.deleteAllTerrainLayers();
        this.deleteAllBlendPoints();
        terrainData.terrainLayers = this.terrainLayers;
        int heightmapResolution1 = terrainData.heightmapResolution;
        int heightmapResolution2 = terrainData.heightmapResolution;
        float[,] heights = terrainData.GetHeights(0, 0, heightmapResolution1, heightmapResolution2);
        for (int index1 = 0; index1 < heightmapResolution1; ++index1)
        {
          for (int index2 = 0; index2 < heightmapResolution2; ++index2)
            heights[index1, index2] = 0.0f;
        }
        terrainData.SetHeights(0, 0, heights);
      }
      catch (Exception ex)
      {
        Debug.LogError((object) ("An error occurred : " + ex?.ToString()));
      }
    }

    public void invertTerrain()
    {
      Terrain component = (Terrain) this.GetComponent(typeof (Terrain));
      if ((UnityEngine.Object) component == (UnityEngine.Object) null)
        return;
      try
      {
        TerrainData terrainData = component.terrainData;
        int heightmapResolution1 = terrainData.heightmapResolution;
        int heightmapResolution2 = terrainData.heightmapResolution;
        float[,] heights = terrainData.GetHeights(0, 0, heightmapResolution1, heightmapResolution2);
        for (int index1 = 0; index1 < heightmapResolution1; ++index1)
        {
          for (int index2 = 0; index2 < heightmapResolution2; ++index2)
            heights[index1, index2] = 1f - heights[index1, index2];
        }
        terrainData.SetHeights(0, 0, heights);
      }
      catch (Exception ex)
      {
        Debug.LogError((object) ("An error occurred : " + ex?.ToString()));
      }
    }

    public void applyArtifacts(Texture2D artifacts, float pivot, float neutral, float strength)
    {
      Terrain component = (Terrain) this.GetComponent(typeof (Terrain));
      if ((UnityEngine.Object) component == (UnityEngine.Object) null)
        return;
      try
      {
        TerrainData terrainData = component.terrainData;
        int heightmapResolution1 = terrainData.heightmapResolution;
        int heightmapResolution2 = terrainData.heightmapResolution;
        float[,] heights = terrainData.GetHeights(0, 0, heightmapResolution1, heightmapResolution2);
        int width = artifacts.width;
        int height = artifacts.height;
        Color[] pixels = artifacts.GetPixels(0, 0, width, height);
        float num1 = neutral * 0.5f;
        float num2 = 1f - num1;
        float num3 = 1f + num1;
        for (int index1 = 0; index1 < heightmapResolution1; ++index1)
        {
          float t1 = Mathf.InverseLerp(0.0f, (float) heightmapResolution1, (float) index1);
          for (int index2 = 0; index2 < heightmapResolution2; ++index2)
          {
            float t2 = Mathf.InverseLerp(0.0f, (float) heightmapResolution2, (float) index2);
            float num4 = heights[index1, index2];
            float grayscale = pixels[Mathf.FloorToInt(Mathf.Lerp(0.0f, (float) height, t2)) * width + Mathf.FloorToInt(Mathf.Lerp(0.0f, (float) width, t1))].grayscale;
            if ((double) num4 > (double) pivot * (double) num3)
              heights[index1, index2] += (float) ((double) num4 * (double) strength * (1.0 + (double) grayscale));
            else if ((double) num4 < (double) pivot * (double) num2)
              heights[index1, index2] -= num4 * strength * grayscale;
            heights[index1, index2] = Mathf.Clamp01(heights[index1, index2]);
          }
        }
        terrainData.SetHeights(0, 0, heights);
      }
      catch (Exception ex)
      {
        Debug.LogError((object) ("An error occurred : " + ex?.ToString()));
      }
    }

    public void seamlessTerrain(float amount)
    {
      Terrain component = (Terrain) this.GetComponent(typeof (Terrain));
      if ((UnityEngine.Object) component == (UnityEngine.Object) null)
        return;
      try
      {
        TerrainData terrainData = component.terrainData;
        int heightmapResolution1 = terrainData.heightmapResolution;
        int heightmapResolution2 = terrainData.heightmapResolution;
        int b1 = (int) ((double) heightmapResolution1 * (double) amount);
        int b2 = (int) ((double) heightmapResolution2 * (double) amount);
        float[,] heights = terrainData.GetHeights(0, 0, heightmapResolution1, heightmapResolution2);
        for (int index1 = 0; index1 < heightmapResolution1; ++index1)
        {
          for (int index2 = 0; index2 < heightmapResolution2; ++index2)
          {
            if (index1 < b1 || index2 < b2)
            {
              float t = (float) (((double) Mathf.InverseLerp(0.0f, (float) b1, (float) index1) + (double) Mathf.InverseLerp(0.0f, (float) b2, (float) index2)) * 0.5);
              float a = (float) (((double) heights[index1, index2] + (double) heights[heightmapResolution1 - index1 - 1, index2] + (double) heights[index1, heightmapResolution2 - index2 - 1] + (double) heights[heightmapResolution1 - index1 - 1, heightmapResolution2 - index2 - 1]) / 4.0);
              heights[index1, index2] = Mathf.Lerp(a, heights[index1, index2], t);
              heights[heightmapResolution1 - index1 - 1, index2] = Mathf.Lerp(a, heights[heightmapResolution1 - index1 - 1, index2], t);
              heights[index1, heightmapResolution2 - index2 - 1] = Mathf.Lerp(a, heights[index1, heightmapResolution2 - index2 - 1], t);
              heights[heightmapResolution1 - index1 - 1, heightmapResolution2 - index2 - 1] = Mathf.Lerp(a, heights[heightmapResolution1 - index1 - 1, heightmapResolution2 - index2 - 1], t);
            }
          }
        }
        terrainData.SetHeights(0, 0, heights);
      }
      catch (Exception ex)
      {
        Debug.LogError((object) ("An error occurred : " + ex?.ToString()));
      }
    }

    public enum ToolMode
    {
      Create,
      Erode,
      Texture,
    }

    public enum ErosionMode
    {
      Filter,
      Brush,
    }

    public enum ErosionType
    {
      Thermal,
      Hydraulic,
      Tidal,
      Wind,
      Glacial,
    }

    public enum HydraulicType
    {
      Fast,
      Full,
      Velocity,
    }

    public enum Neighbourhood
    {
      Moore,
      VonNeumann,
    }

    public enum GeneratorType
    {
      Voronoi,
      DiamondSquare,
      Perlin,
      Smooth,
      Normalise,
    }

    public enum VoronoiType
    {
      Linear,
      Sine,
      Tangent,
    }

    public enum FeatureType
    {
      Mountains,
      Hills,
      Plateaus,
    }

    public struct Peak
    {
      public Vector2 peakPoint;
      public float peakHeight;
    }

    public delegate void ErosionProgressDelegate(
      string titleString,
      string displayString,
      int iteration,
      int nIterations,
      float percentComplete);

    public delegate void TextureProgressDelegate(
      string titleString,
      string displayString,
      float percentComplete);

    public delegate void GeneratorProgressDelegate(
      string titleString,
      string displayString,
      float percentComplete);

    public class PeakDistance : IComparable
    {
      public int id;
      public float dist;

      public int CompareTo(object obj)
      {
        TerrainToolkit.PeakDistance peakDistance = (TerrainToolkit.PeakDistance) obj;
        int num = this.dist.CompareTo(peakDistance.dist);
        if (num == 0)
          num = this.dist.CompareTo(peakDistance.dist);
        return num;
      }
    }

    public class voronoiPresetData
    {
      public string presetName;
      public TerrainToolkit.VoronoiType p_voronoiType;
      public int voronoiCells;
      public float voronoiFeatures;
      public float voronoiScale;
      public float voronoiBlend;

      public voronoiPresetData(
        string pn,
        TerrainToolkit.VoronoiType vt,
        int c,
        float vf,
        float vs,
        float vb)
      {
        this.presetName = pn;
        this.p_voronoiType = vt;
        this.voronoiCells = c;
        this.voronoiFeatures = vf;
        this.voronoiScale = vs;
        this.voronoiBlend = vb;
      }
    }

    public class fractalPresetData
    {
      public string presetName;
      public float diamondSquareDelta;
      public float diamondSquareBlend;

      public fractalPresetData(string pn, float dsd, float dsb)
      {
        this.presetName = pn;
        this.diamondSquareDelta = dsd;
        this.diamondSquareBlend = dsb;
      }
    }

    public class perlinPresetData
    {
      public string presetName;
      public int perlinFrequency;
      public float perlinAmplitude;
      public int perlinOctaves;
      public float perlinBlend;

      public perlinPresetData(string pn, int pf, float pa, int po, float pb)
      {
        this.presetName = pn;
        this.perlinFrequency = pf;
        this.perlinAmplitude = pa;
        this.perlinOctaves = po;
        this.perlinBlend = pb;
      }
    }

    public class thermalErosionPresetData
    {
      public string presetName;
      public int thermalIterations;
      public float thermalMinSlope;
      public float thermalFalloff;

      public thermalErosionPresetData(string pn, int ti, float tms, float tba)
      {
        this.presetName = pn;
        this.thermalIterations = ti;
        this.thermalMinSlope = tms;
        this.thermalFalloff = tba;
      }
    }

    public class fastHydraulicErosionPresetData
    {
      public string presetName;
      public int hydraulicIterations;
      public float hydraulicMaxSlope;
      public float hydraulicFalloff;

      public fastHydraulicErosionPresetData(string pn, int hi, float hms, float hba)
      {
        this.presetName = pn;
        this.hydraulicIterations = hi;
        this.hydraulicMaxSlope = hms;
        this.hydraulicFalloff = hba;
      }
    }

    public class fullHydraulicErosionPresetData
    {
      public string presetName;
      public int hydraulicIterations;
      public float hydraulicRainfall;
      public float hydraulicEvaporation;
      public float hydraulicSedimentSolubility;
      public float hydraulicSedimentSaturation;

      public fullHydraulicErosionPresetData(
        string pn,
        int hi,
        float hr,
        float he,
        float hso,
        float hsa)
      {
        this.presetName = pn;
        this.hydraulicIterations = hi;
        this.hydraulicRainfall = hr;
        this.hydraulicEvaporation = he;
        this.hydraulicSedimentSolubility = hso;
        this.hydraulicSedimentSaturation = hsa;
      }
    }

    public class velocityHydraulicErosionPresetData
    {
      public string presetName;
      public int hydraulicIterations;
      public float hydraulicVelocityRainfall;
      public float hydraulicVelocityEvaporation;
      public float hydraulicVelocitySedimentSolubility;
      public float hydraulicVelocitySedimentSaturation;
      public float hydraulicVelocity;
      public float hydraulicMomentum;
      public float hydraulicEntropy;
      public float hydraulicDowncutting;

      public velocityHydraulicErosionPresetData(
        string pn,
        int hi,
        float hvr,
        float hve,
        float hso,
        float hsa,
        float hv,
        float hm,
        float he,
        float hd)
      {
        this.presetName = pn;
        this.hydraulicIterations = hi;
        this.hydraulicVelocityRainfall = hvr;
        this.hydraulicVelocityEvaporation = hve;
        this.hydraulicVelocitySedimentSolubility = hso;
        this.hydraulicVelocitySedimentSaturation = hsa;
        this.hydraulicVelocity = hv;
        this.hydraulicMomentum = hm;
        this.hydraulicEntropy = he;
        this.hydraulicDowncutting = hd;
      }
    }

    public class tidalErosionPresetData
    {
      public string presetName;
      public int tidalIterations;
      public float tidalRangeAmount;
      public float tidalCliffLimit;

      public tidalErosionPresetData(string pn, int ti, float tra, float tcl)
      {
        this.presetName = pn;
        this.tidalIterations = ti;
        this.tidalRangeAmount = tra;
        this.tidalCliffLimit = tcl;
      }
    }

    public class windErosionPresetData
    {
      public string presetName;
      public int windIterations;
      public float windDirection;
      public float windForce;
      public float windLift;
      public float windGravity;
      public float windCapacity;
      public float windEntropy;
      public float windSmoothing;

      public windErosionPresetData(
        string pn,
        int wi,
        float wd,
        float wf,
        float wl,
        float wg,
        float wc,
        float we,
        float ws)
      {
        this.presetName = pn;
        this.windIterations = wi;
        this.windDirection = wd;
        this.windForce = wf;
        this.windLift = wl;
        this.windGravity = wg;
        this.windCapacity = wc;
        this.windEntropy = we;
        this.windSmoothing = ws;
      }
    }

    public class PerlinNoise2D
    {
      private double[,] p_noiseValues;
      private float p_amplitude = 1f;
      private int p_frequency = 1;

      public PerlinNoise2D(int freq, float _amp)
      {
        System.Random random = new System.Random(Environment.TickCount);
        this.p_noiseValues = new double[freq, freq];
        this.p_amplitude = _amp;
        this.p_frequency = freq;
        for (int index1 = 0; index1 < freq; ++index1)
        {
          for (int index2 = 0; index2 < freq; ++index2)
            this.p_noiseValues[index1, index2] = random.NextDouble();
        }
      }

      public double getInterpolatedPoint(
        int _xa,
        int _xb,
        int _ya,
        int _yb,
        double Px,
        double Py)
      {
        return this.interpolate(this.interpolate(this.p_noiseValues[_xa % this.Frequency, _ya % this.p_frequency], this.p_noiseValues[_xb % this.Frequency, _ya % this.p_frequency], Px), this.interpolate(this.p_noiseValues[_xa % this.Frequency, _yb % this.p_frequency], this.p_noiseValues[_xb % this.Frequency, _yb % this.p_frequency], Px), Py);
      }

      public double interpolate(double Pa, double Pb, double Px)
      {
        double num = (1.0 - (double) Mathf.Cos((float) (Px * 3.1415927410125732))) * 0.5;
        return Pa * (1.0 - num) + Pb * num;
      }

      public float Amplitude => this.p_amplitude;

      public int Frequency => this.p_frequency;
    }
  }
}
