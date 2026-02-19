// Decompiled with JetBrains decompiler
// Type: bl_SectionGenerate2
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class bl_SectionGenerate2 : MonoBehaviour
{
  public static int Seed;
  public ChunkGenerateData[,] NewChunks;
  public static bool _SmallWorld;
  [Header(" -- ")]
  public List<bl_WorldChunk> PrefabChunks = new List<bl_WorldChunk>();
  public List<bl_WorldChunk> PrefabChunks_Desert = new List<bl_WorldChunk>();
  public List<bl_WorldChunk> PrefabChunks_Forest = new List<bl_WorldChunk>();
  public List<bl_WorldChunk> PrefabChunks_Forest_burnt = new List<bl_WorldChunk>();
  public List<bl_WorldChunk> PrefabChunks_Forest_low = new List<bl_WorldChunk>();
  public List<bl_WorldChunk> PrefabChunks_Forest_high = new List<bl_WorldChunk>();
  [Header(" -- ")]
  public GameObject BorderPrefab;
  public GameObject PlayerStartPrefab;
  public GameObject StructureFlatPlain;
  public List<GameObject> PrefabStructures = new List<GameObject>();
  [Header(" -- runtime --- ")]
  public static List<Transform> ItemFallRespawnSpots = new List<Transform>();

  public static bool SmallWorld
  {
    get
    {
      if (Main.Instance.GlobalVars.ContainsKey("smallworld"))
        bl_SectionGenerate2._SmallWorld = Main.Instance.GlobalVars.Get("smallworld") == "1";
      return bl_SectionGenerate2._SmallWorld;
    }
    set
    {
      bl_SectionGenerate2._SmallWorld = value;
      Main.Instance.GlobalVars.Set("smallworld", value ? "1" : "0");
    }
  }

  public IEnumerator Generate(Vector3 startingPos, bl_WorldSection section = null, int seed = 0)
  {
    bl_SectionGenerate2 sectionGenerate2 = this;
    bl_SectionGenerate2.Seed = seed;
    System.Random random = new System.Random(seed);
    bl_SectionGenerate2.ItemFallRespawnSpots.Clear();
    int _sectionXSize = 64;
    int _sectionYSize = 64;
    if (bl_SectionGenerate2.SmallWorld)
    {
      _sectionXSize = 32;
      _sectionYSize = 32;
    }
    if ((UnityEngine.Object) section != (UnityEngine.Object) null)
    {
      section.ChunksX = _sectionXSize;
      section.ChunksY = _sectionYSize;
      section.ChunksCount = _sectionXSize * _sectionYSize;
    }
    sectionGenerate2.NewChunks = new ChunkGenerateData[_sectionXSize, _sectionYSize];
    int num1 = 120;
    int minInclusive1 = 5;
    int maxExclusive1 = 20;
    if (bl_SectionGenerate2.SmallWorld)
    {
      num1 /= 3;
      minInclusive1 /= 3;
      maxExclusive1 /= 3;
    }
    for (int index1 = 0; index1 < _sectionXSize; ++index1)
    {
      for (int index2 = 0; index2 < _sectionYSize; ++index2)
      {
        sectionGenerate2.NewChunks[index1, index2] = new ChunkGenerateData();
        sectionGenerate2.NewChunks[index1, index2].X = index1;
        sectionGenerate2.NewChunks[index1, index2].Y = index2;
      }
    }
    for (int index3 = 0; index3 < num1; ++index3)
    {
      int num2 = UnityEngine.Random.Range(minInclusive1, maxExclusive1);
      int num3 = UnityEngine.Random.Range(0, _sectionXSize);
      int num4 = UnityEngine.Random.Range(0, _sectionYSize);
      int num5 = UnityEngine.Random.Range(-1, 1);
      for (int index4 = 0; index4 < num2; ++index4)
      {
        for (int index5 = 0; index5 < num2; ++index5)
        {
          if (num3 + index4 < _sectionXSize && num4 + index5 < _sectionYSize)
            sectionGenerate2.NewChunks[num3 + index4, num4 + index5].Height += num5;
        }
      }
    }
    for (int index6 = 1; index6 < _sectionXSize - 1; ++index6)
    {
      for (int index7 = 1; index7 < _sectionYSize - 1; ++index7)
      {
        ChunkGenerateData newChunk1 = sectionGenerate2.NewChunks[index6, index7];
        ChunkGenerateData newChunk2 = sectionGenerate2.NewChunks[index6, index7 + 1];
        ChunkGenerateData newChunk3 = sectionGenerate2.NewChunks[index6 + 1, index7 + 1];
        ChunkGenerateData newChunk4 = sectionGenerate2.NewChunks[index6 + 1, index7];
        ChunkGenerateData newChunk5 = sectionGenerate2.NewChunks[index6 + 1, index7 - 1];
        newChunk1.ConnectedChunks = new ChunkGenerateData[4];
        newChunk1.ConnectedChunks[0] = sectionGenerate2.NewChunks[index6 - 1, index7];
        newChunk1.ConnectedChunks[1] = newChunk2;
        newChunk1.ConnectedChunks[2] = newChunk4;
        newChunk1.ConnectedChunks[3] = sectionGenerate2.NewChunks[index6, index7 - 1];
        while (true)
        {
          int num6 = newChunk2.Height - newChunk1.Height;
          if (num6 > 1)
            --newChunk2.Height;
          else if (num6 < -1)
            ++newChunk2.Height;
          else
            break;
        }
        while (true)
        {
          int num7 = newChunk3.Height - newChunk1.Height;
          if (num7 > 1)
            --newChunk3.Height;
          else if (num7 < -1)
            ++newChunk3.Height;
          else
            break;
        }
        while (true)
        {
          int num8 = newChunk4.Height - newChunk1.Height;
          if (num8 > 1)
            --newChunk4.Height;
          else if (num8 < -1)
            ++newChunk4.Height;
          else
            break;
        }
        while (true)
        {
          int num9 = newChunk5.Height - newChunk1.Height;
          if (num9 > 1)
            --newChunk5.Height;
          else if (num9 < -1)
            ++newChunk5.Height;
          else
            break;
        }
      }
    }
    for (int index8 = 1; index8 < _sectionXSize - 1; ++index8)
    {
      for (int index9 = 1; index9 < _sectionYSize - 1; ++index9)
      {
        ChunkGenerateData[] chunkGenerateDataArray = new ChunkGenerateData[8]
        {
          sectionGenerate2.NewChunks[index8 - 1, index9 - 1],
          sectionGenerate2.NewChunks[index8, index9 - 1],
          sectionGenerate2.NewChunks[index8 + 1, index9 - 1],
          sectionGenerate2.NewChunks[index8 - 1, index9],
          null,
          null,
          null,
          null
        };
        ChunkGenerateData newChunk = sectionGenerate2.NewChunks[index8, index9];
        chunkGenerateDataArray[4] = sectionGenerate2.NewChunks[index8 + 1, index9];
        chunkGenerateDataArray[5] = sectionGenerate2.NewChunks[index8 - 1, index9 + 1];
        chunkGenerateDataArray[6] = sectionGenerate2.NewChunks[index8, index9 + 1];
        chunkGenerateDataArray[7] = sectionGenerate2.NewChunks[index8 + 1, index9 + 1];
        int num10 = 0;
        for (int index10 = 0; index10 < chunkGenerateDataArray.Length; ++index10)
        {
          if (chunkGenerateDataArray[index10].Height > newChunk.Height)
            ++num10;
        }
        if (num10 == 0)
        {
          sectionGenerate2.NewChunks[index8, index9].Rot = UnityEngine.Random.Range(0, 4);
        }
        else
        {
          bool flag1 = chunkGenerateDataArray[3].Height > newChunk.Height;
          bool flag2 = chunkGenerateDataArray[1].Height > newChunk.Height;
          bool flag3 = chunkGenerateDataArray[6].Height > newChunk.Height;
          bool flag4 = chunkGenerateDataArray[4].Height > newChunk.Height;
          bool flag5 = chunkGenerateDataArray[0].Height > newChunk.Height;
          bool flag6 = chunkGenerateDataArray[5].Height > newChunk.Height;
          bool flag7 = chunkGenerateDataArray[2].Height > newChunk.Height;
          bool flag8 = chunkGenerateDataArray[7].Height > newChunk.Height;
          int num11 = (flag1 ? 1 : 0) + (flag2 ? 1 : 0) + (flag3 ? 1 : 0) + (flag4 ? 1 : 0);
          int num12 = (flag5 ? 1 : 0) + (flag6 ? 1 : 0) + (flag7 ? 1 : 0) + (flag8 ? 1 : 0);
          bool flag9 = flag1 & flag2 || flag2 & flag4 || flag4 & flag3 || flag3 & flag1;
          List<bl_WorldChunk> blWorldChunkList = new List<bl_WorldChunk>();
          for (int index11 = 0; index11 < sectionGenerate2.PrefabChunks.Count; ++index11)
          {
            if (num11 == sectionGenerate2.PrefabChunks[index11].Sides && num12 >= sectionGenerate2.PrefabChunks[index11].Corners_Min && num12 <= sectionGenerate2.PrefabChunks[index11].Corners_Max && flag9 == sectionGenerate2.PrefabChunks[index11].CornerSides)
              blWorldChunkList.Add(sectionGenerate2.PrefabChunks[index11]);
          }
          sectionGenerate2.NewChunks[index8, index9].WorldChunkType = blWorldChunkList[0].ThisType;
          switch (sectionGenerate2.NewChunks[index8, index9].WorldChunkType)
          {
            case e_WorldChunkType.Up1:
              if (flag1)
              {
                sectionGenerate2.NewChunks[index8, index9].Rot = 2;
                if (flag8 & flag7)
                {
                  sectionGenerate2.NewChunks[index8, index9].WorldChunkType = e_WorldChunkType.Up1_corner_1_2;
                  continue;
                }
                if (flag8)
                {
                  sectionGenerate2.NewChunks[index8, index9].WorldChunkType = e_WorldChunkType.Up1_corner_1_1;
                  continue;
                }
                if (flag7)
                {
                  sectionGenerate2.NewChunks[index8, index9].WorldChunkType = e_WorldChunkType.Up1_corner_1_1;
                  sectionGenerate2.NewChunks[index8, index9].Reverse = true;
                  continue;
                }
                continue;
              }
              if (flag2)
              {
                sectionGenerate2.NewChunks[index8, index9].Rot = 1;
                if (flag6 & flag8)
                {
                  sectionGenerate2.NewChunks[index8, index9].WorldChunkType = e_WorldChunkType.Up1_corner_1_2;
                  continue;
                }
                if (flag6)
                {
                  sectionGenerate2.NewChunks[index8, index9].WorldChunkType = e_WorldChunkType.Up1_corner_1_1;
                  continue;
                }
                if (flag8)
                {
                  sectionGenerate2.NewChunks[index8, index9].WorldChunkType = e_WorldChunkType.Up1_corner_1_1;
                  sectionGenerate2.NewChunks[index8, index9].Reverse = true;
                  continue;
                }
                continue;
              }
              if (flag3)
              {
                sectionGenerate2.NewChunks[index8, index9].Rot = 3;
                if (flag5 & flag7)
                {
                  sectionGenerate2.NewChunks[index8, index9].WorldChunkType = e_WorldChunkType.Up1_corner_1_2;
                  continue;
                }
                if (flag7)
                {
                  sectionGenerate2.NewChunks[index8, index9].WorldChunkType = e_WorldChunkType.Up1_corner_1_1;
                  continue;
                }
                if (flag5)
                {
                  sectionGenerate2.NewChunks[index8, index9].WorldChunkType = e_WorldChunkType.Up1_corner_1_1;
                  sectionGenerate2.NewChunks[index8, index9].Reverse = true;
                  continue;
                }
                continue;
              }
              if (flag4)
              {
                sectionGenerate2.NewChunks[index8, index9].Rot = 0;
                if (flag5 & flag6)
                {
                  sectionGenerate2.NewChunks[index8, index9].WorldChunkType = e_WorldChunkType.Up1_corner_1_2;
                  continue;
                }
                if (flag5)
                {
                  sectionGenerate2.NewChunks[index8, index9].WorldChunkType = e_WorldChunkType.Up1_corner_1_1;
                  continue;
                }
                if (flag6)
                {
                  sectionGenerate2.NewChunks[index8, index9].WorldChunkType = e_WorldChunkType.Up1_corner_1_1;
                  sectionGenerate2.NewChunks[index8, index9].Reverse = true;
                  continue;
                }
                continue;
              }
              continue;
            case e_WorldChunkType.Up1_corner_0_1:
              if (flag5)
              {
                sectionGenerate2.NewChunks[index8, index9].Rot = 0;
                continue;
              }
              if (flag6)
              {
                sectionGenerate2.NewChunks[index8, index9].Rot = 1;
                continue;
              }
              if (flag7)
              {
                sectionGenerate2.NewChunks[index8, index9].Rot = 3;
                continue;
              }
              if (flag8)
              {
                sectionGenerate2.NewChunks[index8, index9].Rot = 2;
                continue;
              }
              continue;
            case e_WorldChunkType.Up1_corner_0_2:
              if (flag5 & flag6)
              {
                sectionGenerate2.NewChunks[index8, index9].Rot = 1;
                continue;
              }
              if (flag6 & flag8)
              {
                sectionGenerate2.NewChunks[index8, index9].Rot = 2;
                continue;
              }
              if (flag8 & flag7)
              {
                sectionGenerate2.NewChunks[index8, index9].Rot = 3;
                continue;
              }
              if (flag7 & flag5)
              {
                sectionGenerate2.NewChunks[index8, index9].Rot = 0;
                continue;
              }
              if (flag5 & flag8 || flag6 & flag7)
              {
                sectionGenerate2.NewChunks[index8, index9].WorldChunkType = e_WorldChunkType.Up1_corner_0_2_X;
                goto case e_WorldChunkType.Up1_corner_0_2_X;
              }
              else
                continue;
            case e_WorldChunkType.Up1_corner_0_2_X:
              if (flag5 & flag8)
              {
                sectionGenerate2.NewChunks[index8, index9].Rot = 0;
                continue;
              }
              if (flag6 & flag7)
              {
                sectionGenerate2.NewChunks[index8, index9].Rot = 1;
                continue;
              }
              continue;
            case e_WorldChunkType.Up1_corner_1_1:
              if (flag1 & flag7)
              {
                sectionGenerate2.NewChunks[index8, index9].Reverse = true;
                break;
              }
              if (flag3 & flag5)
              {
                sectionGenerate2.NewChunks[index8, index9].Reverse = true;
                break;
              }
              if (flag4 & flag6)
              {
                sectionGenerate2.NewChunks[index8, index9].Reverse = true;
                break;
              }
              if (flag2 & flag8)
              {
                sectionGenerate2.NewChunks[index8, index9].Reverse = true;
                break;
              }
              break;
            case e_WorldChunkType.Up1_corner_2:
              if (flag1 & flag3)
              {
                sectionGenerate2.NewChunks[index8, index9].Rot = 3;
                if (flag7)
                {
                  sectionGenerate2.NewChunks[index8, index9].WorldChunkType = e_WorldChunkType.Up1_corner_2_1;
                  continue;
                }
                continue;
              }
              if (flag3 & flag4)
              {
                sectionGenerate2.NewChunks[index8, index9].Rot = 0;
                if (flag5)
                {
                  sectionGenerate2.NewChunks[index8, index9].WorldChunkType = e_WorldChunkType.Up1_corner_2_1;
                  continue;
                }
                continue;
              }
              if (flag4 & flag2)
              {
                sectionGenerate2.NewChunks[index8, index9].Rot = 1;
                if (flag6)
                {
                  sectionGenerate2.NewChunks[index8, index9].WorldChunkType = e_WorldChunkType.Up1_corner_2_1;
                  continue;
                }
                continue;
              }
              if (flag2 & flag1)
              {
                sectionGenerate2.NewChunks[index8, index9].Rot = 2;
                if (flag8)
                {
                  sectionGenerate2.NewChunks[index8, index9].WorldChunkType = e_WorldChunkType.Up1_corner_2_1;
                  continue;
                }
                continue;
              }
              continue;
            case e_WorldChunkType.Up1_corner_2_1:
              if (flag1 & flag3)
              {
                sectionGenerate2.NewChunks[index8, index9].Rot = 3;
                continue;
              }
              if (flag3 & flag4)
              {
                sectionGenerate2.NewChunks[index8, index9].Rot = 0;
                continue;
              }
              if (flag4 & flag2)
              {
                sectionGenerate2.NewChunks[index8, index9].Rot = 1;
                continue;
              }
              if (flag2 & flag1)
              {
                sectionGenerate2.NewChunks[index8, index9].Rot = 2;
                continue;
              }
              continue;
            case e_WorldChunkType.Up1_corner_3:
              if (flag1 & flag3 & flag4)
              {
                sectionGenerate2.NewChunks[index8, index9].Rot = 1;
                continue;
              }
              if (flag3 & flag4 & flag2)
              {
                sectionGenerate2.NewChunks[index8, index9].Rot = 2;
                continue;
              }
              if (flag4 & flag2 & flag1)
              {
                sectionGenerate2.NewChunks[index8, index9].Rot = 3;
                continue;
              }
              if (flag2 & flag1 & flag3)
              {
                sectionGenerate2.NewChunks[index8, index9].Rot = 0;
                continue;
              }
              continue;
          }
          if (flag1)
            sectionGenerate2.NewChunks[index8, index9].Rot = 2;
          else if (flag2)
            sectionGenerate2.NewChunks[index8, index9].Rot = 1;
          else if (flag3)
            sectionGenerate2.NewChunks[index8, index9].Rot = 3;
          else if (flag4)
            sectionGenerate2.NewChunks[index8, index9].Rot = 0;
        }
      }
    }
    for (int index12 = 0; index12 < _sectionXSize; ++index12)
    {
      for (int index13 = 0; index13 < _sectionYSize; ++index13)
      {
        if (index12 < _sectionXSize && index13 < _sectionYSize)
          sectionGenerate2.NewChunks[index12, index13].Biome = e_WorldBiome.Forest;
      }
    }
    int num13 = 20;
    int num14 = 5;
    int num15 = 10;
    if (bl_SectionGenerate2.SmallWorld)
    {
      int num16 = num13 / 4;
      int num17 = num14 / 4;
      int num18 = num15 / 4;
    }
    for (int index14 = 0; index14 < 5; ++index14)
    {
      int num19 = UnityEngine.Random.Range(0, _sectionXSize);
      int num20 = UnityEngine.Random.Range(0, _sectionYSize);
      int num21 = num19 + UnityEngine.Random.Range(5, 10);
      int num22 = num20 + UnityEngine.Random.Range(5, 10);
      for (int index15 = num19; index15 < num21; ++index15)
      {
        for (int index16 = num20; index16 < num22; ++index16)
        {
          if (index15 < _sectionXSize && index16 < _sectionYSize)
            sectionGenerate2.NewChunks[index15, index16].Biome = e_WorldBiome.Forest_LowDensity;
        }
      }
    }
    for (int index17 = 0; index17 < 10; ++index17)
    {
      int num23 = UnityEngine.Random.Range(0, _sectionXSize);
      int num24 = UnityEngine.Random.Range(0, _sectionYSize);
      int num25 = num23 + UnityEngine.Random.Range(5, 10);
      int num26 = num24 + UnityEngine.Random.Range(5, 10);
      for (int index18 = num23; index18 < num25; ++index18)
      {
        for (int index19 = num24; index19 < num26; ++index19)
        {
          if (index18 < _sectionXSize && index19 < _sectionYSize)
            sectionGenerate2.NewChunks[index18, index19].Biome = e_WorldBiome.Forest_Burnt;
        }
      }
    }
    for (int index20 = 0; index20 < 20; ++index20)
    {
      int num27 = UnityEngine.Random.Range(0, _sectionXSize);
      int num28 = UnityEngine.Random.Range(0, _sectionYSize);
      int num29 = num27 + UnityEngine.Random.Range(5, 20);
      int num30 = num28 + UnityEngine.Random.Range(5, 20);
      for (int index21 = num27; index21 < num29; ++index21)
      {
        for (int index22 = num28; index22 < num30; ++index22)
        {
          if (index21 < _sectionXSize && index22 < _sectionYSize)
            sectionGenerate2.NewChunks[index21, index22].Biome = e_WorldBiome.Forest_HighDensity;
        }
      }
    }
    int num31 = 5;
    int minInclusive2 = 20;
    int maxExclusive2 = 50;
    int minInclusive3 = 5;
    int maxExclusive3 = 10;
    if (bl_SectionGenerate2.SmallWorld)
    {
      num31 = 2;
      minInclusive2 /= 2;
      maxExclusive2 /= 2;
    }
    List<ChunkGenerateData> chunkGenerateDataList1 = new List<ChunkGenerateData>();
label_220:
    for (int index23 = 0; index23 < num31; ++index23)
    {
      int num32 = UnityEngine.Random.Range(minInclusive2, maxExclusive2);
      int num33 = UnityEngine.Random.Range(minInclusive3, maxExclusive3);
      int index24 = UnityEngine.Random.Range(2, _sectionXSize - 2);
      int index25 = UnityEngine.Random.Range(2, _sectionYSize - 2);
      int num34 = UnityEngine.Random.Range(0, 4);
      bool flag = false;
      for (int index26 = 0; index26 < num32; ++index26)
      {
        if ((sectionGenerate2.NewChunks[index24, index25].WorldChunkType == e_WorldChunkType.Plain || sectionGenerate2.NewChunks[index24, index25].WorldChunkType == e_WorldChunkType.Up1) && (!flag || sectionGenerate2.NewChunks[index24, index25].WorldChunkType != e_WorldChunkType.Up1))
        {
          sectionGenerate2.NewChunks[index24, index25].Road = true;
          chunkGenerateDataList1.Add(sectionGenerate2.NewChunks[index24, index25]);
          flag = sectionGenerate2.NewChunks[index24, index25].WorldChunkType == e_WorldChunkType.Up1;
        }
        if (--num33 <= 0)
        {
          num33 = UnityEngine.Random.Range(minInclusive3, maxExclusive3);
          int num35;
          do
          {
            num35 = UnityEngine.Random.Range(0, 4);
          }
          while ((num34 == 0 || num34 == 2) && (num35 == 0 || num35 == 2) || (num34 == 1 || num34 == 3) && (num35 == 1 || num35 == 3));
          num34 = num35;
        }
        switch (num34)
        {
          case 0:
            ++index24;
            if (index24 < _sectionXSize)
              break;
            goto label_220;
          case 1:
            ++index25;
            if (index25 < _sectionYSize)
              break;
            goto label_220;
          case 2:
            --index24;
            if (index24 > 0)
              break;
            goto label_220;
          case 3:
            --index25;
            if (index25 <= 0)
              goto label_220;
            else
              break;
        }
      }
    }
    for (int index27 = 0; index27 < chunkGenerateDataList1.Count; ++index27)
    {
      int num36 = 0;
      if (chunkGenerateDataList1[index27].ConnectedChunks != null)
      {
        for (int index28 = 0; index28 < chunkGenerateDataList1[index27].ConnectedChunks.Length; ++index28)
        {
          if (chunkGenerateDataList1[index27].ConnectedChunks[index28].Road)
            ++num36;
        }
        switch (num36)
        {
          case 0:
            if (chunkGenerateDataList1[index27].WorldChunkType == e_WorldChunkType.Plain)
            {
              sectionGenerate2.NewChunks[chunkGenerateDataList1[index27].X, chunkGenerateDataList1[index27].Y].WorldChunkType = e_WorldChunkType.RoadSingle;
              continue;
            }
            continue;
          case 1:
            if (chunkGenerateDataList1[index27].WorldChunkType == e_WorldChunkType.Plain)
            {
              sectionGenerate2.NewChunks[chunkGenerateDataList1[index27].X, chunkGenerateDataList1[index27].Y].WorldChunkType = e_WorldChunkType.RoadEnd;
              if (chunkGenerateDataList1[index27].ConnectedChunks[0].Road)
                sectionGenerate2.NewChunks[chunkGenerateDataList1[index27].X, chunkGenerateDataList1[index27].Y].Rot = 0;
              if (chunkGenerateDataList1[index27].ConnectedChunks[1].Road)
                sectionGenerate2.NewChunks[chunkGenerateDataList1[index27].X, chunkGenerateDataList1[index27].Y].Rot = 1;
              if (chunkGenerateDataList1[index27].ConnectedChunks[2].Road)
                sectionGenerate2.NewChunks[chunkGenerateDataList1[index27].X, chunkGenerateDataList1[index27].Y].Rot = 2;
              if (chunkGenerateDataList1[index27].ConnectedChunks[3].Road)
              {
                sectionGenerate2.NewChunks[chunkGenerateDataList1[index27].X, chunkGenerateDataList1[index27].Y].Rot = 3;
                continue;
              }
              continue;
            }
            continue;
          case 2:
            if (chunkGenerateDataList1[index27].WorldChunkType == e_WorldChunkType.Up1)
            {
              sectionGenerate2.NewChunks[chunkGenerateDataList1[index27].X, chunkGenerateDataList1[index27].Y].WorldChunkType = e_WorldChunkType.RoadUp1;
              continue;
            }
            if (chunkGenerateDataList1[index27].WorldChunkType == e_WorldChunkType.Plain)
            {
              if (chunkGenerateDataList1[index27].ConnectedChunks[0].Road && chunkGenerateDataList1[index27].ConnectedChunks[1].Road || chunkGenerateDataList1[index27].ConnectedChunks[1].Road && chunkGenerateDataList1[index27].ConnectedChunks[2].Road || chunkGenerateDataList1[index27].ConnectedChunks[2].Road && chunkGenerateDataList1[index27].ConnectedChunks[3].Road || chunkGenerateDataList1[index27].ConnectedChunks[3].Road && chunkGenerateDataList1[index27].ConnectedChunks[0].Road)
              {
                sectionGenerate2.NewChunks[chunkGenerateDataList1[index27].X, chunkGenerateDataList1[index27].Y].WorldChunkType = e_WorldChunkType.RoadL;
                if (chunkGenerateDataList1[index27].ConnectedChunks[0].Road && chunkGenerateDataList1[index27].ConnectedChunks[1].Road)
                  sectionGenerate2.NewChunks[chunkGenerateDataList1[index27].X, chunkGenerateDataList1[index27].Y].Rot = 1;
                if (chunkGenerateDataList1[index27].ConnectedChunks[1].Road && chunkGenerateDataList1[index27].ConnectedChunks[2].Road)
                  sectionGenerate2.NewChunks[chunkGenerateDataList1[index27].X, chunkGenerateDataList1[index27].Y].Rot = 2;
                if (chunkGenerateDataList1[index27].ConnectedChunks[2].Road && chunkGenerateDataList1[index27].ConnectedChunks[3].Road)
                  sectionGenerate2.NewChunks[chunkGenerateDataList1[index27].X, chunkGenerateDataList1[index27].Y].Rot = 3;
                if (chunkGenerateDataList1[index27].ConnectedChunks[3].Road && chunkGenerateDataList1[index27].ConnectedChunks[0].Road)
                {
                  sectionGenerate2.NewChunks[chunkGenerateDataList1[index27].X, chunkGenerateDataList1[index27].Y].Rot = 0;
                  continue;
                }
                continue;
              }
              sectionGenerate2.NewChunks[chunkGenerateDataList1[index27].X, chunkGenerateDataList1[index27].Y].WorldChunkType = e_WorldChunkType.Road;
              if (chunkGenerateDataList1[index27].ConnectedChunks[0].Road)
                sectionGenerate2.NewChunks[chunkGenerateDataList1[index27].X, chunkGenerateDataList1[index27].Y].Rot = 0;
              if (chunkGenerateDataList1[index27].ConnectedChunks[1].Road)
                sectionGenerate2.NewChunks[chunkGenerateDataList1[index27].X, chunkGenerateDataList1[index27].Y].Rot = 1;
              if (chunkGenerateDataList1[index27].ConnectedChunks[2].Road)
                sectionGenerate2.NewChunks[chunkGenerateDataList1[index27].X, chunkGenerateDataList1[index27].Y].Rot = 2;
              if (chunkGenerateDataList1[index27].ConnectedChunks[3].Road)
              {
                sectionGenerate2.NewChunks[chunkGenerateDataList1[index27].X, chunkGenerateDataList1[index27].Y].Rot = 3;
                continue;
              }
              continue;
            }
            continue;
          case 3:
            if (chunkGenerateDataList1[index27].WorldChunkType == e_WorldChunkType.Plain)
            {
              sectionGenerate2.NewChunks[chunkGenerateDataList1[index27].X, chunkGenerateDataList1[index27].Y].WorldChunkType = e_WorldChunkType.RoadT;
              if (!chunkGenerateDataList1[index27].ConnectedChunks[0].Road)
                sectionGenerate2.NewChunks[chunkGenerateDataList1[index27].X, chunkGenerateDataList1[index27].Y].Rot = 0;
              if (!chunkGenerateDataList1[index27].ConnectedChunks[1].Road)
                sectionGenerate2.NewChunks[chunkGenerateDataList1[index27].X, chunkGenerateDataList1[index27].Y].Rot = 1;
              if (!chunkGenerateDataList1[index27].ConnectedChunks[2].Road)
                sectionGenerate2.NewChunks[chunkGenerateDataList1[index27].X, chunkGenerateDataList1[index27].Y].Rot = 2;
              if (!chunkGenerateDataList1[index27].ConnectedChunks[3].Road)
              {
                sectionGenerate2.NewChunks[chunkGenerateDataList1[index27].X, chunkGenerateDataList1[index27].Y].Rot = 3;
                continue;
              }
              continue;
            }
            continue;
          case 4:
            if (chunkGenerateDataList1[index27].WorldChunkType == e_WorldChunkType.Plain)
            {
              sectionGenerate2.NewChunks[chunkGenerateDataList1[index27].X, chunkGenerateDataList1[index27].Y].WorldChunkType = e_WorldChunkType.RoadX;
              continue;
            }
            continue;
          default:
            continue;
        }
      }
    }
    int num37 = 120;
    if (bl_SectionGenerate2.SmallWorld)
      num37 /= 4;
    List<ChunkGenerateData> chunkGenerateDataList2 = new List<ChunkGenerateData>();
    for (int index29 = 2; index29 < _sectionXSize - 2; ++index29)
    {
      for (int index30 = 2; index30 < _sectionYSize - 2; ++index30)
      {
        if (sectionGenerate2.NewChunks[index29, index30].WorldChunkType == e_WorldChunkType.Plain)
          chunkGenerateDataList2.Add(sectionGenerate2.NewChunks[index29, index30]);
      }
    }
    for (int index31 = 0; index31 < num37; ++index31)
    {
      if (chunkGenerateDataList2.Count > 0)
      {
        int index32 = UnityEngine.Random.Range(0, chunkGenerateDataList2.Count);
        chunkGenerateDataList2[index32].Structure = UnityEngine.Random.Range(1, sectionGenerate2.PrefabStructures.Count + 1);
        chunkGenerateDataList2.RemoveAt(index32);
      }
    }
    for (int index33 = 16; index33 < _sectionXSize - 1; ++index33)
    {
      for (int index34 = 16; index34 < _sectionYSize - 1; ++index34)
      {
        if (sectionGenerate2.NewChunks[index33, index34].WorldChunkType == e_WorldChunkType.Plain && !sectionGenerate2.NewChunks[index33, index34].Road)
        {
          sectionGenerate2.NewChunks[index33, index34].Structure = 0;
          sectionGenerate2.NewChunks[index33, index34].WorldChunkType = e_WorldChunkType.PlayerStart;
          goto label_296;
        }
      }
    }
label_296:
    int _totalChunks = _sectionXSize * _sectionYSize;
    int _currentChunk = 0;
    Main.Instance.NewGameMenu.ExtraLoadingText.text = "0/" + _totalChunks.ToString();
    Main.Instance.NewGameMenu.ExtraLoadingTextTitle.text = "Spawning Chunks";
    yield return (object) null;
    Transform _PlayerStartChunk = (Transform) null;
    for (int x = 1; x < _sectionXSize - 1; ++x)
    {
      for (int y = 1; y < _sectionYSize - 1; ++y)
      {
        int worldChunkType = (int) sectionGenerate2.NewChunks[x, y].WorldChunkType;
        int structure = sectionGenerate2.NewChunks[x, y].Structure;
        Transform transform1;
        if (worldChunkType == 21)
        {
          transform1 = UnityEngine.Object.Instantiate<GameObject>(sectionGenerate2.PlayerStartPrefab).transform;
          _PlayerStartChunk = transform1;
        }
        else if (structure != 0)
        {
          transform1 = UnityEngine.Object.Instantiate<GameObject>(sectionGenerate2.StructureFlatPlain).transform;
        }
        else
        {
          switch (sectionGenerate2.NewChunks[x, y].Biome)
          {
            case e_WorldBiome.Desert:
              transform1 = UnityEngine.Object.Instantiate<bl_WorldChunk>(sectionGenerate2.PrefabChunks_Desert[worldChunkType]).transform;
              break;
            case e_WorldBiome.Forest:
              transform1 = UnityEngine.Object.Instantiate<bl_WorldChunk>(sectionGenerate2.PrefabChunks_Forest[worldChunkType]).transform;
              break;
            case e_WorldBiome.Forest_HighDensity:
              transform1 = UnityEngine.Object.Instantiate<bl_WorldChunk>(sectionGenerate2.PrefabChunks_Forest_high[worldChunkType]).transform;
              break;
            case e_WorldBiome.Forest_LowDensity:
              transform1 = UnityEngine.Object.Instantiate<bl_WorldChunk>(sectionGenerate2.PrefabChunks_Forest_low[worldChunkType]).transform;
              break;
            case e_WorldBiome.Forest_Burnt:
              transform1 = UnityEngine.Object.Instantiate<bl_WorldChunk>(sectionGenerate2.PrefabChunks_Forest_burnt[worldChunkType]).transform;
              break;
            default:
              transform1 = UnityEngine.Object.Instantiate<bl_WorldChunk>(sectionGenerate2.PrefabChunks[worldChunkType]).transform;
              break;
          }
        }
        transform1.transform.position = startingPos + new Vector3((float) (x * 27), (float) (sectionGenerate2.NewChunks[x, y].Height * 9), (float) (y * 27));
        transform1.transform.eulerAngles = new Vector3(-90f, 0.0f, (float) (90 * sectionGenerate2.NewChunks[x, y].Rot));
        transform1.localScale = new Vector3(100f, sectionGenerate2.NewChunks[x, y].Reverse ? -100f : 100f, 100f);
        transform1.name = "Chunk_" + x.ToString() + "_" + y.ToString();
        bl_WorldChunk component1 = transform1.gameObject.GetComponent<bl_WorldChunk>();
        component1.XCordinate = x;
        component1.YCordinate = y;
        component1.ThisType = (e_WorldChunkType) worldChunkType;
        component1.ThisData = sectionGenerate2.NewChunks[x, y];
        component1.OnSpawnChunk();
        if (structure != 0)
        {
          Transform transform2 = UnityEngine.Object.Instantiate<GameObject>(sectionGenerate2.PrefabStructures[structure - 1]).transform;
          transform2.position = transform1.transform.position;
          transform2.eulerAngles = new Vector3(0.0f, (float) (UnityEngine.Random.Range(0, 3) * 90), 0.0f);
          transform2.gameObject.SetActive(true);
          transform2.SetParent(transform1, true);
        }
        component1.ChunkObtainLODs();
        bl_Temp_onChunkSpawn component2 = transform1.GetComponent<bl_Temp_onChunkSpawn>();
        if ((UnityEngine.Object) component2 != (UnityEngine.Object) null)
          component2.OnChunkSpawn();
        component1.ThisData = (ChunkGenerateData) null;
        if (++_currentChunk % (_sectionXSize * 2) == 0)
        {
          Main.Instance.NewGameMenu.ExtraLoadingText.text = _currentChunk.ToString() + "/" + _totalChunks.ToString();
          Main.Instance.NewGameMenu.ExtraLoadingSliderEpic.value = (float) _currentChunk / (float) _totalChunks;
          Main.Instance.NewGameMenu.ExtraLoadingSlider.value = (float) _currentChunk / (float) _totalChunks;
          yield return (object) null;
        }
      }
    }
    Debug.Log((object) "spawn temp walls");
    for (int index = 1; index < _sectionXSize - 1; ++index)
    {
      Transform transform = UnityEngine.Object.Instantiate<GameObject>(sectionGenerate2.BorderPrefab).transform;
      transform.transform.position = new Vector3((float) (index * 27), (float) (sectionGenerate2.NewChunks[index, 0].Height * 9), 27f);
      transform.transform.eulerAngles = new Vector3(0.0f, 180f, 0.0f);
    }
    for (int index = 1; index < _sectionXSize - 1; ++index)
    {
      Transform transform = UnityEngine.Object.Instantiate<GameObject>(sectionGenerate2.BorderPrefab).transform;
      transform.transform.position = new Vector3(27f, (float) (sectionGenerate2.NewChunks[0, index].Height * 9), (float) (index * 27));
      transform.transform.eulerAngles = new Vector3(0.0f, -90f, 0.0f);
    }
    for (int index = 1; index < _sectionXSize - 1; ++index)
    {
      Transform transform = UnityEngine.Object.Instantiate<GameObject>(sectionGenerate2.BorderPrefab).transform;
      transform.transform.position = new Vector3((float) (index * 27), (float) (sectionGenerate2.NewChunks[index, _sectionXSize - 1].Height * 9), (float) ((_sectionXSize - 2) * 27));
      transform.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    }
    for (int index = 1; index < _sectionXSize - 1; ++index)
    {
      Transform transform = UnityEngine.Object.Instantiate<GameObject>(sectionGenerate2.BorderPrefab).transform;
      transform.transform.position = new Vector3((float) ((_sectionXSize - 2) * 27), (float) (sectionGenerate2.NewChunks[_sectionXSize - 1, index].Height * 9), (float) (index * 27));
      transform.transform.eulerAngles = new Vector3(0.0f, 90f, 0.0f);
    }
    Debug.Log((object) "placing player");
    Transform Spot = _PlayerStartChunk.Find("PlayerStart");
    Main.Instance.Player.PlaceAt(Spot);
    Main.Instance.Player.transform.eulerAngles = Vector3.zero;
    Main.Instance.PlayerWakeupPlaces.Clear();
    Main.Instance.PlayerWakeupPlaces.Add(Spot);
    Main.Instance.Player.UserControl.ResetSpot = Spot;
    sectionGenerate2.gameObject.SetActive(false);
    UI_Gameplay.OWGenerating = false;
    Debug.Log((object) "Finished Generation");
  }

  public void GoToCity() => Main.Instance.GameplayMenu.GoToCity();
}
