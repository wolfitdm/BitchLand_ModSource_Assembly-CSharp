// Decompiled with JetBrains decompiler
// Type: ChunkGenerateData
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
