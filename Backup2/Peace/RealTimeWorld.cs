// Decompiled with JetBrains decompiler
// Type: Peace.RealTimeWorld
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
namespace Peace;

public class RealTimeWorld : MonoBehaviour
{
  public string configLocation = "";
  public GameObject tracking;
  private Collector _collector;
  private World _world;
  private Vector3 _position;
  private FirstPersonView _view;
  private bool _collecting;
  private RealTimeWorldStatistics _stats = new RealTimeWorldStatistics();
  private Queue<GameObject> _objectPool;
  private List<GameObject> _objectsUsed;

  private async void RunCollect()
  {
    this._collecting = true;
    await this._collector.CollectFirstPerson(this._world, this._view);
    this.UpdateFromCollector();
    this._collecting = false;
  }

  private void UpdateFromCollector()
  {
    this._stats.removed = 0;
    this._stats.added = 0;
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    for (int index = this._objectsUsed.Count - 1; index >= 0; --index)
    {
      GameObject gameObject = this._objectsUsed[index];
      if (!this._collector.HasNode(gameObject.name))
      {
        this._objectsUsed.RemoveAt(index);
        gameObject.SetActive(false);
        this._objectPool.Enqueue(gameObject);
      }
    }
    foreach (string newNode in this._collector.GetNewNodes())
    {
      Collector.CollectorNode node = this._collector.GetNode(newNode);
      Mesh mesh = this._collector.GetMesh(node.Mesh);
      if ((Object) mesh != (Object) null)
      {
        GameObject gameObject = this.AllocateObject(newNode);
        gameObject.transform.localPosition = new Vector3((float) node.posX, (float) node.posZ, (float) node.posY);
        gameObject.transform.localScale = new Vector3((float) node.scaleX, (float) node.scaleZ, (float) node.scaleY);
        gameObject.transform.localEulerAngles = new Vector3((float) node.rotX, (float) node.rotZ, (float) node.rotY);
        gameObject.GetComponent<MeshFilter>().sharedMesh = mesh;
        MeshRenderer component = gameObject.GetComponent<MeshRenderer>();
        Material material = this._collector.GetMaterial(node.Material);
        if ((Object) material != (Object) null)
          component.material = material;
        else
          component.material.shader = Shader.Find("Standard");
        this._objectsUsed.Add(gameObject);
      }
      ++this._stats.added;
    }
    stopwatch.Stop();
    this._stats.updateTime = (float) stopwatch.Elapsed.TotalMilliseconds;
    this._stats.collectorStats = this._collector.LastStats;
  }

  private GameObject AllocateObject(string name)
  {
    GameObject gameObject;
    if (this._objectPool.Count != 0)
    {
      gameObject = this._objectPool.Dequeue();
      gameObject.SetActive(true);
      gameObject.name = name;
    }
    else
    {
      gameObject = new GameObject(name);
      gameObject.transform.SetParent(this.transform);
      gameObject.AddComponent<MeshFilter>();
      gameObject.AddComponent<MeshRenderer>();
    }
    return gameObject;
  }

  private void Start()
  {
    this._objectPool = new Queue<GameObject>();
    this._objectsUsed = new List<GameObject>();
    this._world = !(this.configLocation == "") ? new World(this.configLocation) : World.CreateDemo("");
    this._collector = new Collector();
    this._view.eyeResolution = 700.0;
    this._view.maxDistance = 10000.0;
  }

  private void UpdatePosition(Vector3 position)
  {
    this._position = position;
    this._view.X = (double) position.x;
    this._view.Y = (double) position.z;
    this._view.Z = (double) position.y;
  }

  private void Update()
  {
    Vector3 position = this.tracking.transform.position;
    if ((double) Vector3.Distance(position, this._position) <= 10.0 || this._collecting)
      return;
    this.UpdatePosition(position);
    this.RunCollect();
  }
}
