// Decompiled with JetBrains decompiler
// Type: ChobiAssets.KTP.Track_Deform_CS
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace ChobiAssets.KTP;

public class Track_Deform_CS : MonoBehaviour
{
  public int anchorNum;
  public Transform[] anchorArray;
  public float[] widthArray;
  public float[] heightArray;
  public float[] offsetArray;
  private Mesh thisMesh;
  public float[] initialPosArray;
  public Vector3[] initialVertices;
  public IntArray[] movableVerticesList;
  private Vector3[] currentVertices;

  private void Awake()
  {
    this.thisMesh = this.GetComponent<MeshFilter>().mesh;
    this.thisMesh.MarkDynamic();
    for (int index = 0; index < this.anchorArray.Length; ++index)
    {
      if ((UnityEngine.Object) this.anchorArray[index] == (UnityEngine.Object) null)
      {
        Debug.LogError((object) ("Anchor Wheel is not assigned in " + this.name));
        UnityEngine.Object.Destroy((UnityEngine.Object) this);
      }
    }
    if (this.initialPosArray == null || this.initialPosArray.Length == 0 || this.initialVertices == null || this.initialVertices.Length == 0 || this.movableVerticesList == null || this.movableVerticesList.Length == 0)
      this.Set_Vertices();
    this.currentVertices = new Vector3[this.initialVertices.Length];
  }

  private void Set_Vertices()
  {
    Debug.Log((object) "Vertices Lists are not prepared in the prefab.");
    this.initialPosArray = new float[this.anchorArray.Length];
    this.initialVertices = this.thisMesh.vertices;
    this.movableVerticesList = new IntArray[this.anchorArray.Length];
    for (int index1 = 0; index1 < this.anchorArray.Length; ++index1)
    {
      if ((UnityEngine.Object) this.anchorArray[index1] != (UnityEngine.Object) null)
      {
        Transform anchor = this.anchorArray[index1];
        this.initialPosArray[index1] = anchor.localPosition.x;
        Vector3 vector3 = this.transform.InverseTransformPoint(anchor.position);
        List<int> intList = new List<int>();
        for (int index2 = 0; index2 < this.thisMesh.vertices.Length; ++index2)
        {
          float num1 = Mathf.Abs(vector3.z - this.thisMesh.vertices[index2].z);
          float num2 = Mathf.Abs(vector3.y - this.thisMesh.vertices[index2].y);
          if ((double) num1 <= (double) this.widthArray[index1] * 0.5 && (double) num2 <= (double) this.heightArray[index1] * 0.5)
            intList.Add(index2);
        }
        IntArray intArray = new IntArray(intList.ToArray());
        this.movableVerticesList[index1] = intArray;
      }
    }
  }

  private void Update()
  {
    this.initialVertices.CopyTo((Array) this.currentVertices, 0);
    for (int index1 = 0; index1 < this.anchorArray.Length; ++index1)
    {
      float num = this.anchorArray[index1].localPosition.x - this.initialPosArray[index1];
      for (int index2 = 0; index2 < this.movableVerticesList[index1].intArray.Length; ++index2)
        this.currentVertices[this.movableVerticesList[index1].intArray[index2]].y += num;
    }
    this.thisMesh.vertices = this.currentVertices;
  }

  private void OnDrawGizmos()
  {
    if (this.anchorArray == null || this.anchorArray.Length == 0 || this.offsetArray == null || this.offsetArray.Length == 0)
      return;
    Gizmos.color = Color.green;
    for (int index = 0; index < this.anchorArray.Length; ++index)
    {
      if ((UnityEngine.Object) this.anchorArray[index] != (UnityEngine.Object) null)
      {
        Vector3 size = new Vector3(0.0f, this.heightArray[index], this.widthArray[index]);
        Vector3 position = this.anchorArray[index].position;
        position.y += this.offsetArray[index];
        Gizmos.DrawWireCube(position, size);
      }
    }
  }

  private void Pause(bool isPaused) => this.enabled = !isPaused;
}
