// Decompiled with JetBrains decompiler
// Type: bl_WorldStructure
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class bl_WorldStructure : MonoBehaviour
{
  public static List<bl_WorldStructure> WorldStructures = new List<bl_WorldStructure>();
  public int Index_ObjsToNotUnparent = 3;
  public bool SpawnTrees;
  public GameObject[] NPCs;
  public Transform[] FallRespawnSpots;

  public void Start()
  {
    bl_WorldStructure.WorldStructures.Add(this);
    if (this.FallRespawnSpots == null)
      return;
    bl_SectionGenerate2.ItemFallRespawnSpots.AddRange((IEnumerable<Transform>) this.FallRespawnSpots);
  }

  public void SpawnNPCs()
  {
    for (int index = 0; index < this.NPCs.Length; ++index)
    {
      if ((UnityEngine.Object) this.NPCs[index] == (UnityEngine.Object) null)
      {
        Debug.LogError((object) "somehow null");
      }
      else
      {
        RandomNPCHere _npc = this.NPCs[index].GetComponent<RandomNPCHere>();
        _npc.DestroyOnCreate = false;
        this.NPCs[index].SetActive(true);
        Main.RunInNextFrame((Action) (() =>
        {
          Person personGenerated = _npc.PersonGenerated;
          personGenerated.Eyes.AddFlagger("OpenWorld");
          personGenerated.SetCullLod(true);
          UnityEngine.Object.Destroy((UnityEngine.Object) _npc.gameObject);
        }));
      }
    }
  }

  public void GetSpawned(bool loadingGame)
  {
    List<Transform> transformList = new List<Transform>();
    for (int objsToNotUnparent = this.Index_ObjsToNotUnparent; objsToNotUnparent < this.transform.childCount; ++objsToNotUnparent)
      transformList.Add(this.transform.GetChild(objsToNotUnparent));
    for (int index = 0; index < transformList.Count; ++index)
    {
      SaveableBehaviour componentInChildren = transformList[index].GetComponentInChildren<SaveableBehaviour>();
      if (!((UnityEngine.Object) componentInChildren == (UnityEngine.Object) null))
      {
        if (componentInChildren.ow_oddsaving)
          transformList[index].SetParent(this.transform.parent);
        else if (componentInChildren.HasByte2Data && !loadingGame)
          transformList[index].SetParent(this.transform.parent);
        else if (loadingGame)
          UnityEngine.Object.Destroy((UnityEngine.Object) transformList[index].gameObject);
        else
          transformList[index].SetParent((Transform) null);
      }
    }
  }
}
