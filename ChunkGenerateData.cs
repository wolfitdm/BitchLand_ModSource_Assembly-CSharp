// Decompiled with JetBrains decompiler
// Type: ChunkGenerateData
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
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
  public bool MineEntrance;
  public int Structure;
  public e_WorldBiome Biome;
  [HideInInspector]
  public ChunkGenerateData[] ConnectedChunks;
  public List<string> Odds = new List<string>();
  public List<byte[]> Trees = new List<byte[]>();
}
