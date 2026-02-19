// Decompiled with JetBrains decompiler
// Type: Peace.Collector
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;

#nullable disable
namespace Peace
{
  public class Collector
  {
    private IntPtr _handle;
    private HashSet<string> _newNodes;
    private Dictionary<string, Collector.CollectorNode> _nodes;
    private Dictionary<string, Mesh> _meshes;
    private Dictionary<string, Material> _materials;
    private Dictionary<string, Texture2D> _textures;
    private Dictionary<string, IntPtr> _terrainHandles;
    public CollectorStats LastStats = new CollectorStats();
    private Collector.Preset _preset;
    private const int NODE_CHANNEL = 0;
    private const int MESH_CHANNEL = 1;
    private const int MATERIAL_CHANNEL = 2;
    private const int TEXTURE_CHANNEL = 3;
    private const int TERRAIN_CHANNEL = 4;

    public Collector(Collector.Preset preset = Collector.Preset.SCENE)
    {
      this._preset = preset;
      this._handle = Collector.createCollector((int) preset);
      this._newNodes = new HashSet<string>();
      this._nodes = new Dictionary<string, Collector.CollectorNode>();
      this._meshes = new Dictionary<string, Mesh>();
      this._materials = new Dictionary<string, Material>();
      this._textures = new Dictionary<string, Texture2D>();
      this._terrainHandles = new Dictionary<string, IntPtr>();
    }

    ~Collector() => Collector.freeCollector(this._handle);

    public void Reset()
    {
      this._newNodes.Clear();
      this._nodes.Clear();
      this._meshes.Clear();
      this._materials.Clear();
      this._textures.Clear();
    }

    private void GetChannel(int type, out string[] names, out IntPtr[] items)
    {
      int channelSize = Collector.collectorGetChannelSize(this._handle, type);
      IntPtr[] numArray = new IntPtr[channelSize];
      IntPtr[] items1 = new IntPtr[channelSize];
      Collector.collectorGetChannel(this._handle, type, numArray, items1);
      names = Util.ToStringArray(numArray);
      items = items1;
    }

    public async Task CollectFirstPerson(World world, FirstPersonView view)
    {
      await Task.Run((Action) (() => Collector.collectFirstPerson(this._handle, world._handle, view)));
      await this.Collect(world);
    }

    public async Task CollectZone(World world, ZoneView view)
    {
      await Task.Run((Action) (() => Collector.collectZone(this._handle, world._handle, view)));
      await this.Collect(world);
    }

    private async Task Collect(World world)
    {
      Stopwatch sw = new Stopwatch();
      sw.Start();
      IntPtr[] nodes = new IntPtr[0];
      IntPtr[] meshes = new IntPtr[0];
      IntPtr[] materials = new IntPtr[0];
      IntPtr[] textures = new IntPtr[0];
      IntPtr[] terrains = new IntPtr[0];
      string[] nodeNames = new string[0];
      string[] meshNames = new string[0];
      string[] materialNames = new string[0];
      string[] textureNames = new string[0];
      string[] terrainNames = new string[0];
      await Task.Run((Action) (() =>
      {
        this.GetChannel(0, out nodeNames, out nodes);
        this.GetChannel(1, out meshNames, out meshes);
        this.GetChannel(2, out materialNames, out materials);
        this.GetChannel(3, out textureNames, out textures);
        if (this._preset != Collector.Preset.ENGINE)
          return;
        this.GetChannel(4, out terrainNames, out terrains);
      }));
      CollectorStats lastStats = this.LastStats;
      TimeSpan elapsed = sw.Elapsed;
      double totalMilliseconds1;
      double num1 = totalMilliseconds1 = elapsed.TotalMilliseconds;
      lastStats.interopTime = totalMilliseconds1;
      double num2 = num1;
      this._newNodes.Clear();
      HashSet<string> stringSet1 = new HashSet<string>((IEnumerable<string>) this._nodes.Keys);
      for (int index = 0; index < nodes.Length; ++index)
      {
        if (!this._nodes.ContainsKey(nodeNames[index]))
        {
          this._nodes.Add(nodeNames[index], Collector.readNode(nodes[index]));
          this._newNodes.Add(nodeNames[index]);
        }
        else
          stringSet1.Remove(nodeNames[index]);
      }
      foreach (string key in stringSet1)
        this._nodes.Remove(key);
      this.LastStats.nodesTime = sw.Elapsed.TotalMilliseconds - num2;
      double totalMilliseconds2 = sw.Elapsed.TotalMilliseconds;
      HashSet<string> stringSet2 = new HashSet<string>((IEnumerable<string>) this._meshes.Keys);
      for (int index = 0; index < meshes.Length; ++index)
      {
        if (!this._meshes.ContainsKey(meshNames[index]))
          this._meshes.Add(meshNames[index], Assets.GetMesh(meshes[index]));
        else
          stringSet2.Remove(meshNames[index]);
      }
      foreach (string key in stringSet2)
      {
        UnityEngine.Object.Destroy((UnityEngine.Object) this._meshes[key]);
        this._meshes.Remove(key);
      }
      this.LastStats.meshesTime = sw.Elapsed.TotalMilliseconds - totalMilliseconds2;
      double totalMilliseconds3 = sw.Elapsed.TotalMilliseconds;
      HashSet<string> stringSet3 = new HashSet<string>((IEnumerable<string>) this._textures.Keys);
      for (int index = 0; index < textures.Length; ++index)
      {
        if (!this._textures.ContainsKey(textureNames[index]))
          this._textures.Add(textureNames[index], Assets.GetTexture(textures[index]));
        else
          stringSet3.Remove(textureNames[index]);
      }
      foreach (string key in stringSet3)
      {
        UnityEngine.Object.Destroy((UnityEngine.Object) this._textures[key]);
        this._textures.Remove(key);
      }
      this.LastStats.texturesTime = sw.Elapsed.TotalMilliseconds - totalMilliseconds3;
      double totalMilliseconds4 = sw.Elapsed.TotalMilliseconds;
      HashSet<string> stringSet4 = new HashSet<string>((IEnumerable<string>) this._materials.Keys);
      for (int index = 0; index < materials.Length; ++index)
      {
        if (!this._materials.ContainsKey(materialNames[index]))
        {
          Material material = Assets.GetMaterial(materials[index]);
          Texture2D texture2D;
          if (this._textures.TryGetValue(Assets.GetMaterialTexture(materials[index]), out texture2D))
            material.mainTexture = (Texture) texture2D;
          this._materials[materialNames[index]] = material;
        }
        else
          stringSet4.Remove(materialNames[index]);
      }
      foreach (string key in stringSet4)
      {
        UnityEngine.Object.Destroy((UnityEngine.Object) this._materials[key]);
        this._materials.Remove(key);
      }
      sw.Stop();
      this.LastStats.materialsTime = sw.Elapsed.TotalMilliseconds - totalMilliseconds4;
      this.LastStats.totalTime = sw.Elapsed.TotalMilliseconds;
      if (this._preset != Collector.Preset.ENGINE)
      {
        sw = (Stopwatch) null;
      }
      else
      {
        HashSet<string> stringSet5 = new HashSet<string>((IEnumerable<string>) this._terrainHandles.Keys);
        for (int index = 0; index < terrains.Length; ++index)
        {
          if (!this._terrainHandles.ContainsKey(terrainNames[index]))
            this._terrainHandles[terrainNames[index]] = terrains[index];
          else
            stringSet5.Remove(terrainNames[index]);
        }
        using (HashSet<string>.Enumerator enumerator = stringSet5.GetEnumerator())
        {
          while (enumerator.MoveNext())
            this._terrainHandles.Remove(enumerator.Current);
          sw = (Stopwatch) null;
        }
      }
    }

    public IEnumerable<string> GetNewNodes() => (IEnumerable<string>) this._newNodes;

    public bool HasNode(string key) => this._nodes.ContainsKey(key);

    public Collector.CollectorNode GetNode(string key) => this._nodes[key];

    public Mesh GetMesh(string key)
    {
      Mesh mesh;
      return !this._meshes.TryGetValue(key, out mesh) ? (Mesh) null : mesh;
    }

    public Material GetMaterial(string key)
    {
      Material material;
      return !this._materials.TryGetValue(key, out material) ? (Material) null : material;
    }

    public Texture2D GetTexture(string key)
    {
      Texture2D texture2D;
      return !this._textures.TryGetValue(key, out texture2D) ? (Texture2D) null : texture2D;
    }

    internal IntPtr GetTerrainHandle(string key)
    {
      IntPtr num;
      return !this._terrainHandles.TryGetValue(key, out num) ? IntPtr.Zero : num;
    }

    [DllImport("peace")]
    private static extern IntPtr createCollector(int preset);

    [DllImport("peace")]
    private static extern void freeCollector(IntPtr handle);

    [DllImport("peace")]
    private static extern void collectFirstPerson(
      IntPtr collector,
      IntPtr world,
      FirstPersonView view);

    [DllImport("peace")]
    private static extern void collectZone(IntPtr collector, IntPtr world, ZoneView view);

    [DllImport("peace")]
    private static extern int collectorGetChannelSize(IntPtr collectorPtr, int type);

    [DllImport("peace")]
    private static extern void collectorGetChannel(
      IntPtr collectorPtr,
      int type,
      [In, Out] IntPtr[] names,
      [In, Out] IntPtr[] items);

    [DllImport("peace")]
    private static extern Collector.CollectorNode readNode(IntPtr nodePtr);

    public enum Preset
    {
      SCENE = 1,
      ENGINE = 2,
    }

    public struct CollectorNode
    {
      public string Mesh;
      public string Material;
      public double posX;
      public double posY;
      public double posZ;
      public double scaleX;
      public double scaleY;
      public double scaleZ;
      public double rotX;
      public double rotY;
      public double rotZ;
    }
  }
}
