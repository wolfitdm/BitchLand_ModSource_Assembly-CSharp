// Decompiled with JetBrains decompiler
// Type: bl_WorldStructure
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class bl_WorldStructure : MonoBehaviour
{
  public static List<bl_WorldStructure> WorldStructures = new List<bl_WorldStructure>();
  public GameObject[] NPCs;

  public void Start() => bl_WorldStructure.WorldStructures.Add(this);

  public void SpawnNPCs()
  {
    for (int index = 0; index < this.NPCs.Length; ++index)
    {
      this.NPCs[index].GetComponent<RandomNPCHere>().DestroyOnCreate = true;
      this.NPCs[index].SetActive(true);
    }
  }
}
