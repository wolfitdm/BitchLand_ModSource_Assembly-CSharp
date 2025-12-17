// Decompiled with JetBrains decompiler
// Type: bl_WorldChunk
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class bl_WorldChunk : MonoBehaviour
{
  public int XCordinate;
  public int YCordinate;
  public e_WorldChunkType ThisType;
  public ChunkGenerateData ThisData;
  public bool top;
  public bool down;
  public bool left;
  public bool right;
  public bool topRight;
  public bool downRight;
  public bool topLeft;
  public bool downLeft;
  public int Sides;
  public int Corners_Min;
  public int Corners_Max;
  public bool CornerSides;
  [Space]
  public GameObject[] asd;
  public int MinProps;
  public int MaxProps;
  public int PerFrame;
  public int FramesPassed;
  public int CurrentLOD;
  public List<Renderer> HighRens = new List<Renderer>();
  public List<Renderer> LowRens = new List<Renderer>();

  public void SaveChunkData()
  {
  }

  public void LoadChunkData()
  {
  }

  public void OnSpawnChunk()
  {
    if (this.ThisData.Structure != 0)
      return;
    if (true)
    {
      int num1 = Random.Range(this.MinProps, this.MaxProps);
      for (int index = 0; index < num1; ++index)
      {
        Transform transform = Object.Instantiate<GameObject>(this.asd[Random.Range(0, this.asd.Length)]).transform;
        transform.SetParent(this.transform);
        transform.localPosition = new Vector3(Random.Range(-0.125f, 0.125f), Random.Range(-0.125f, 0.125f), 0.0f);
        transform.localEulerAngles = new Vector3((float) Random.Range(0, 360), 90f, 90f);
        float num2 = Random.Range(3f / 1000f, 0.01f);
        transform.localScale = new Vector3(num2, num2, num2);
      }
    }
    Renderer[] componentsInChildren = this.GetComponentsInChildren<Renderer>(false);
    for (int index = 0; index < componentsInChildren.Length; ++index)
    {
      switch (componentsInChildren[index].gameObject.tag)
      {
        case "NoLOD":
          continue;
        case "LOD":
          this.LowRens.Add(componentsInChildren[index]);
          continue;
        default:
          this.HighRens.Add(componentsInChildren[index]);
          continue;
      }
    }
    this.SetLowLod();
  }

  public void OnDespawnChunk()
  {
  }

  public void Start() => this.PerFrame = Random.Range(10, 20);

  private void Update()
  {
    if (++this.FramesPassed < this.PerFrame)
      return;
    this.FramesPassed = 0;
    float num = Vector2.Distance(new Vector2(Main.Instance.Player.transform.position.x, Main.Instance.Player.transform.position.z), new Vector2(this.transform.position.x, this.transform.position.z));
    switch (this.CurrentLOD)
    {
      case 0:
        if ((double) num >= 1000.0)
          break;
        if ((double) num < 100.0)
        {
          this.SetHighLod();
          break;
        }
        this.SetLowLod();
        break;
      case 1:
        if ((double) num > 1000.0)
        {
          this.SetCullLod();
          break;
        }
        if ((double) num >= 100.0)
          break;
        this.SetHighLod();
        break;
      case 2:
        if ((double) num <= 100.0)
          break;
        this.SetLowLod();
        break;
    }
  }

  public void OnBecameInvisible()
  {
  }

  public void OnBecameVisible()
  {
  }

  public void SetHighLod()
  {
    this.CurrentLOD = 2;
    for (int index = 0; index < this.HighRens.Count; ++index)
      this.HighRens[index].enabled = true;
    for (int index = 0; index < this.LowRens.Count; ++index)
      this.LowRens[index].enabled = false;
  }

  public void SetLowLod()
  {
    this.CurrentLOD = 1;
    for (int index = 0; index < this.HighRens.Count; ++index)
      this.HighRens[index].enabled = false;
    for (int index = 0; index < this.LowRens.Count; ++index)
      this.LowRens[index].enabled = true;
  }

  public void SetCullLod()
  {
    this.CurrentLOD = 0;
    for (int index = 0; index < this.HighRens.Count; ++index)
      this.HighRens[index].enabled = false;
    for (int index = 0; index < this.LowRens.Count; ++index)
      this.LowRens[index].enabled = false;
  }
}
