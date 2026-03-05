// Decompiled with JetBrains decompiler
// Type: ChunkGenerateData
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
