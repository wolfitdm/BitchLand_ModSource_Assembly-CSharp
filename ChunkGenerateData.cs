// Decompiled with JetBrains decompiler
// Type: ChunkGenerateData
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
[Serializable]
public class ChunkGenerateData
{
  public int X;
  public int Y;
  public int Height;
  public e_WorldChunkType WorldChunkType;
  public int Rot;
  public bool Reverse;
  public bool Road;
  public int Structure;
  public e_WorldBiome Biome;
  [HideInInspector]
  public ChunkGenerateData[] ConnectedChunks;
}
