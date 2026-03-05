// Decompiled with JetBrains decompiler
// Type: bl_WorldStructure
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class bl_WorldStructure : MonoBehaviour
{
  public static List<bl_WorldStructure> WorldStructures = new List<bl_WorldStructure>();
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
