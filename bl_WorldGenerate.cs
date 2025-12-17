// Decompiled with JetBrains decompiler
// Type: bl_WorldGenerate
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class bl_WorldGenerate : MonoBehaviour
{
  public static int Seed;
  public List<bl_WorldChunk> LoadedChunks = new List<bl_WorldChunk>();
  public GameObject TempWall;
  public ChunkGenerateData[,] NewChunks;
  public List<bl_WorldChunk> PrefabChunks = new List<bl_WorldChunk>();
  public List<bl_WorldChunk> PrefabChunks_Desert = new List<bl_WorldChunk>();
  public List<bl_WorldChunk> PrefabChunks_Forest = new List<bl_WorldChunk>();
  public List<GameObject> PrefabStructures = new List<GameObject>();
  public GameObject PlayerStartPrefab;
  public Person Player;
  public bool GenerateNOW;

  public void SpawnChunk(int XCordinate, int YCordinate)
  {
  }

  public void SpawnChunksCloserToPlayer()
  {
  }

  public void Start() => this.Generate(new Vector3(0.0f, 0.0f, 0.0f));

  public void Update()
  {
    if (!this.GenerateNOW)
      return;
    this.GenerateNOW = false;
    this.Generate(new Vector3(0.0f, 0.0f, 0.0f));
  }

  public void Generate(Vector3 startingPos, int seed = 0)
  {
    System.Random random = new System.Random(seed);
    Transform transform1 = (Transform) null;
    int maxExclusive1 = 64 /*0x40*/;
    int maxExclusive2 = 64 /*0x40*/;
    this.NewChunks = new ChunkGenerateData[maxExclusive1, maxExclusive2];
    int num1 = 30;
    int minInclusive1 = 5;
    int maxExclusive3 = 20;
    for (int index1 = 0; index1 < maxExclusive1; ++index1)
    {
      for (int index2 = 0; index2 < maxExclusive2; ++index2)
      {
        this.NewChunks[index1, index2] = new ChunkGenerateData();
        this.NewChunks[index1, index2].X = index1;
        this.NewChunks[index1, index2].Y = index2;
      }
    }
    for (int index3 = 0; index3 < num1; ++index3)
    {
      int num2 = UnityEngine.Random.Range(minInclusive1, maxExclusive3);
      int num3 = UnityEngine.Random.Range(0, maxExclusive1);
      int num4 = UnityEngine.Random.Range(0, maxExclusive2);
      int num5 = UnityEngine.Random.Range(-1, 1);
      for (int index4 = 0; index4 < num2; ++index4)
      {
        for (int index5 = 0; index5 < num2; ++index5)
        {
          if (num3 + index4 < maxExclusive1 && num4 + index5 < maxExclusive2)
            this.NewChunks[num3 + index4, num4 + index5].Height += num5;
        }
      }
    }
    for (int index6 = 1; index6 < maxExclusive1 - 1; ++index6)
    {
      for (int index7 = 1; index7 < maxExclusive2 - 1; ++index7)
      {
        ChunkGenerateData newChunk1 = this.NewChunks[index6, index7];
        ChunkGenerateData newChunk2 = this.NewChunks[index6, index7 + 1];
        ChunkGenerateData newChunk3 = this.NewChunks[index6 + 1, index7 + 1];
        ChunkGenerateData newChunk4 = this.NewChunks[index6 + 1, index7];
        ChunkGenerateData newChunk5 = this.NewChunks[index6 + 1, index7 - 1];
        newChunk1.ConnectedChunks = new ChunkGenerateData[4];
        newChunk1.ConnectedChunks[0] = this.NewChunks[index6 - 1, index7];
        newChunk1.ConnectedChunks[1] = newChunk2;
        newChunk1.ConnectedChunks[2] = newChunk4;
        newChunk1.ConnectedChunks[3] = this.NewChunks[index6, index7 - 1];
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
    for (int index8 = 1; index8 < maxExclusive1 - 1; ++index8)
    {
      for (int index9 = 1; index9 < maxExclusive2 - 1; ++index9)
      {
        ChunkGenerateData[] chunkGenerateDataArray = new ChunkGenerateData[8]
        {
          this.NewChunks[index8 - 1, index9 - 1],
          this.NewChunks[index8, index9 - 1],
          this.NewChunks[index8 + 1, index9 - 1],
          this.NewChunks[index8 - 1, index9],
          null,
          null,
          null,
          null
        };
        ChunkGenerateData newChunk = this.NewChunks[index8, index9];
        chunkGenerateDataArray[4] = this.NewChunks[index8 + 1, index9];
        chunkGenerateDataArray[5] = this.NewChunks[index8 - 1, index9 + 1];
        chunkGenerateDataArray[6] = this.NewChunks[index8, index9 + 1];
        chunkGenerateDataArray[7] = this.NewChunks[index8 + 1, index9 + 1];
        int num10 = 0;
        for (int index10 = 0; index10 < chunkGenerateDataArray.Length; ++index10)
        {
          if (chunkGenerateDataArray[index10].Height > newChunk.Height)
            ++num10;
        }
        if (num10 == 0)
        {
          this.NewChunks[index8, index9].Rot = UnityEngine.Random.Range(0, 4);
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
          for (int index11 = 0; index11 < this.PrefabChunks.Count; ++index11)
          {
            if (num11 == this.PrefabChunks[index11].Sides && num12 >= this.PrefabChunks[index11].Corners_Min && num12 <= this.PrefabChunks[index11].Corners_Max && flag9 == this.PrefabChunks[index11].CornerSides)
              blWorldChunkList.Add(this.PrefabChunks[index11]);
          }
          this.NewChunks[index8, index9].WorldChunkType = blWorldChunkList.Count != 1 ? blWorldChunkList[0].ThisType : blWorldChunkList[0].ThisType;
          switch (this.NewChunks[index8, index9].WorldChunkType)
          {
            case e_WorldChunkType.Up1:
              if (flag1)
              {
                this.NewChunks[index8, index9].Rot = 2;
                if (flag8 & flag7)
                {
                  this.NewChunks[index8, index9].WorldChunkType = e_WorldChunkType.Up1_corner_1_2;
                  continue;
                }
                if (flag8)
                {
                  this.NewChunks[index8, index9].WorldChunkType = e_WorldChunkType.Up1_corner_1_1;
                  continue;
                }
                if (flag7)
                {
                  this.NewChunks[index8, index9].WorldChunkType = e_WorldChunkType.Up1_corner_1_1;
                  this.NewChunks[index8, index9].Reverse = true;
                  continue;
                }
                continue;
              }
              if (flag2)
              {
                this.NewChunks[index8, index9].Rot = 1;
                if (flag6 & flag8)
                {
                  this.NewChunks[index8, index9].WorldChunkType = e_WorldChunkType.Up1_corner_1_2;
                  continue;
                }
                if (flag6)
                {
                  this.NewChunks[index8, index9].WorldChunkType = e_WorldChunkType.Up1_corner_1_1;
                  continue;
                }
                if (flag8)
                {
                  this.NewChunks[index8, index9].WorldChunkType = e_WorldChunkType.Up1_corner_1_1;
                  this.NewChunks[index8, index9].Reverse = true;
                  continue;
                }
                continue;
              }
              if (flag3)
              {
                this.NewChunks[index8, index9].Rot = 3;
                if (flag5 & flag7)
                {
                  this.NewChunks[index8, index9].WorldChunkType = e_WorldChunkType.Up1_corner_1_2;
                  continue;
                }
                if (flag7)
                {
                  this.NewChunks[index8, index9].WorldChunkType = e_WorldChunkType.Up1_corner_1_1;
                  continue;
                }
                if (flag5)
                {
                  this.NewChunks[index8, index9].WorldChunkType = e_WorldChunkType.Up1_corner_1_1;
                  this.NewChunks[index8, index9].Reverse = true;
                  continue;
                }
                continue;
              }
              if (flag4)
              {
                this.NewChunks[index8, index9].Rot = 0;
                if (flag5 & flag6)
                {
                  this.NewChunks[index8, index9].WorldChunkType = e_WorldChunkType.Up1_corner_1_2;
                  continue;
                }
                if (flag5)
                {
                  this.NewChunks[index8, index9].WorldChunkType = e_WorldChunkType.Up1_corner_1_1;
                  continue;
                }
                if (flag6)
                {
                  this.NewChunks[index8, index9].WorldChunkType = e_WorldChunkType.Up1_corner_1_1;
                  this.NewChunks[index8, index9].Reverse = true;
                  continue;
                }
                continue;
              }
              continue;
            case e_WorldChunkType.Up1_corner_0_1:
              if (flag5)
              {
                this.NewChunks[index8, index9].Rot = 0;
                continue;
              }
              if (flag6)
              {
                this.NewChunks[index8, index9].Rot = 1;
                continue;
              }
              if (flag7)
              {
                this.NewChunks[index8, index9].Rot = 3;
                continue;
              }
              if (flag8)
              {
                this.NewChunks[index8, index9].Rot = 2;
                continue;
              }
              continue;
            case e_WorldChunkType.Up1_corner_0_2:
              if (flag5 & flag6)
              {
                this.NewChunks[index8, index9].Rot = 1;
                continue;
              }
              if (flag6 & flag8)
              {
                this.NewChunks[index8, index9].Rot = 2;
                continue;
              }
              if (flag8 & flag7)
              {
                this.NewChunks[index8, index9].Rot = 3;
                continue;
              }
              if (flag7 & flag5)
              {
                this.NewChunks[index8, index9].Rot = 0;
                continue;
              }
              if (flag5 & flag8 || flag6 & flag7)
              {
                this.NewChunks[index8, index9].WorldChunkType = e_WorldChunkType.Up1_corner_0_2_X;
                goto case e_WorldChunkType.Up1_corner_0_2_X;
              }
              continue;
            case e_WorldChunkType.Up1_corner_0_2_X:
              if (flag5 & flag8)
              {
                this.NewChunks[index8, index9].Rot = 0;
                continue;
              }
              if (flag6 & flag7)
              {
                this.NewChunks[index8, index9].Rot = 1;
                continue;
              }
              continue;
            case e_WorldChunkType.Up1_corner_1_1:
              if (flag1 & flag7)
              {
                this.NewChunks[index8, index9].Reverse = true;
                break;
              }
              if (flag3 & flag5)
              {
                this.NewChunks[index8, index9].Reverse = true;
                break;
              }
              if (flag4 & flag6)
              {
                this.NewChunks[index8, index9].Reverse = true;
                break;
              }
              if (flag2 & flag8)
              {
                this.NewChunks[index8, index9].Reverse = true;
                break;
              }
              break;
            case e_WorldChunkType.Up1_corner_2:
              if (flag1 & flag3)
              {
                this.NewChunks[index8, index9].Rot = 3;
                if (flag7)
                {
                  this.NewChunks[index8, index9].WorldChunkType = e_WorldChunkType.Up1_corner_2_1;
                  continue;
                }
                continue;
              }
              if (flag3 & flag4)
              {
                this.NewChunks[index8, index9].Rot = 0;
                if (flag5)
                {
                  this.NewChunks[index8, index9].WorldChunkType = e_WorldChunkType.Up1_corner_2_1;
                  continue;
                }
                continue;
              }
              if (flag4 & flag2)
              {
                this.NewChunks[index8, index9].Rot = 1;
                if (flag6)
                {
                  this.NewChunks[index8, index9].WorldChunkType = e_WorldChunkType.Up1_corner_2_1;
                  continue;
                }
                continue;
              }
              if (flag2 & flag1)
              {
                this.NewChunks[index8, index9].Rot = 2;
                if (flag8)
                {
                  this.NewChunks[index8, index9].WorldChunkType = e_WorldChunkType.Up1_corner_2_1;
                  continue;
                }
                continue;
              }
              continue;
            case e_WorldChunkType.Up1_corner_2_1:
              if (flag1 & flag3)
              {
                this.NewChunks[index8, index9].Rot = 3;
                continue;
              }
              if (flag3 & flag4)
              {
                this.NewChunks[index8, index9].Rot = 0;
                continue;
              }
              if (flag4 & flag2)
              {
                this.NewChunks[index8, index9].Rot = 1;
                continue;
              }
              if (flag2 & flag1)
              {
                this.NewChunks[index8, index9].Rot = 2;
                continue;
              }
              continue;
            case e_WorldChunkType.Up1_corner_3:
              if (flag1 & flag3 & flag4)
              {
                this.NewChunks[index8, index9].Rot = 1;
                continue;
              }
              if (flag3 & flag4 & flag2)
              {
                this.NewChunks[index8, index9].Rot = 2;
                continue;
              }
              if (flag4 & flag2 & flag1)
              {
                this.NewChunks[index8, index9].Rot = 3;
                continue;
              }
              if (flag2 & flag1 & flag3)
              {
                this.NewChunks[index8, index9].Rot = 0;
                continue;
              }
              continue;
          }
          if (flag1)
            this.NewChunks[index8, index9].Rot = 2;
          else if (flag2)
            this.NewChunks[index8, index9].Rot = 1;
          else if (flag3)
            this.NewChunks[index8, index9].Rot = 3;
          else if (flag4)
            this.NewChunks[index8, index9].Rot = 0;
        }
      }
    }
    for (int index12 = 0; index12 < 3; ++index12)
    {
      int num13 = UnityEngine.Random.Range(5, 25);
      int num14 = UnityEngine.Random.Range(5, 25);
      int num15 = num13 + UnityEngine.Random.Range(5, 10);
      int num16 = num14 + UnityEngine.Random.Range(5, 10);
      for (int index13 = num13; index13 < num15; ++index13)
      {
        for (int index14 = num14; index14 < num16; ++index14)
        {
          if (index13 < maxExclusive1 && index14 < maxExclusive2)
            this.NewChunks[index13, index14].Biome = e_WorldBiome.Desert;
        }
      }
    }
    for (int index15 = 0; index15 < 5; ++index15)
    {
      int num17 = UnityEngine.Random.Range(1, 31 /*0x1F*/);
      int num18 = UnityEngine.Random.Range(1, 31 /*0x1F*/);
      int num19 = num17 + UnityEngine.Random.Range(10, 20);
      int num20 = num18 + UnityEngine.Random.Range(10, 20);
      for (int index16 = num17; index16 < num19; ++index16)
      {
        for (int index17 = num18; index17 < num20; ++index17)
        {
          if (index16 < maxExclusive1 && index17 < maxExclusive2)
            this.NewChunks[index16, index17].Biome = e_WorldBiome.Forest;
        }
      }
    }
    int num21 = 5;
    int minInclusive2 = 20;
    int maxExclusive4 = 50;
    int minInclusive3 = 5;
    int maxExclusive5 = 10;
    List<ChunkGenerateData> chunkGenerateDataList1 = new List<ChunkGenerateData>();
label_191:
    for (int index18 = 0; index18 < num21; ++index18)
    {
      int num22 = UnityEngine.Random.Range(minInclusive2, maxExclusive4);
      int num23 = UnityEngine.Random.Range(minInclusive3, maxExclusive5);
      int index19 = UnityEngine.Random.Range(1, maxExclusive1 - 1);
      int index20 = UnityEngine.Random.Range(1, maxExclusive2 - 1);
      int num24 = UnityEngine.Random.Range(0, 4);
      for (int index21 = 0; index21 < num22; ++index21)
      {
        if (this.NewChunks[index19, index20].WorldChunkType == e_WorldChunkType.Plain || this.NewChunks[index19, index20].WorldChunkType == e_WorldChunkType.Up1)
        {
          this.NewChunks[index19, index20].Road = true;
          chunkGenerateDataList1.Add(this.NewChunks[index19, index20]);
        }
        if (--num23 <= 0)
        {
          num23 = UnityEngine.Random.Range(minInclusive3, maxExclusive5);
          int num25;
          do
          {
            num25 = UnityEngine.Random.Range(0, 4);
          }
          while ((num24 == 0 || num24 == 2) && (num25 == 0 || num25 == 2) || (num24 == 1 || num24 == 3) && (num25 == 1 || num25 == 3));
          num24 = num25;
        }
        switch (num24)
        {
          case 0:
            ++index19;
            if (index19 < maxExclusive1)
              break;
            goto label_191;
          case 1:
            ++index20;
            if (index20 < maxExclusive2)
              break;
            goto label_191;
          case 2:
            --index19;
            if (index19 > 0)
              break;
            goto label_191;
          case 3:
            --index20;
            if (index20 <= 0)
              goto label_191;
            break;
        }
      }
    }
    for (int index22 = 0; index22 < chunkGenerateDataList1.Count; ++index22)
    {
      int num26 = 0;
      if (chunkGenerateDataList1[index22].ConnectedChunks != null)
      {
        for (int index23 = 0; index23 < chunkGenerateDataList1[index22].ConnectedChunks.Length; ++index23)
        {
          if (chunkGenerateDataList1[index22].ConnectedChunks[index23].Road)
            ++num26;
        }
        switch (num26)
        {
          case 0:
            if (chunkGenerateDataList1[index22].WorldChunkType == e_WorldChunkType.Plain)
            {
              this.NewChunks[chunkGenerateDataList1[index22].X, chunkGenerateDataList1[index22].Y].WorldChunkType = e_WorldChunkType.RoadSingle;
              continue;
            }
            continue;
          case 1:
            if (chunkGenerateDataList1[index22].WorldChunkType == e_WorldChunkType.Plain)
            {
              this.NewChunks[chunkGenerateDataList1[index22].X, chunkGenerateDataList1[index22].Y].WorldChunkType = e_WorldChunkType.RoadEnd;
              if (chunkGenerateDataList1[index22].ConnectedChunks[0].Road)
                this.NewChunks[chunkGenerateDataList1[index22].X, chunkGenerateDataList1[index22].Y].Rot = 0;
              if (chunkGenerateDataList1[index22].ConnectedChunks[1].Road)
                this.NewChunks[chunkGenerateDataList1[index22].X, chunkGenerateDataList1[index22].Y].Rot = 1;
              if (chunkGenerateDataList1[index22].ConnectedChunks[2].Road)
                this.NewChunks[chunkGenerateDataList1[index22].X, chunkGenerateDataList1[index22].Y].Rot = 2;
              if (chunkGenerateDataList1[index22].ConnectedChunks[3].Road)
              {
                this.NewChunks[chunkGenerateDataList1[index22].X, chunkGenerateDataList1[index22].Y].Rot = 3;
                continue;
              }
              continue;
            }
            continue;
          case 2:
            if (chunkGenerateDataList1[index22].WorldChunkType == e_WorldChunkType.Up1)
            {
              this.NewChunks[chunkGenerateDataList1[index22].X, chunkGenerateDataList1[index22].Y].WorldChunkType = e_WorldChunkType.RoadUp1;
              continue;
            }
            if (chunkGenerateDataList1[index22].WorldChunkType == e_WorldChunkType.Plain)
            {
              if (chunkGenerateDataList1[index22].ConnectedChunks[0].Road && chunkGenerateDataList1[index22].ConnectedChunks[1].Road || chunkGenerateDataList1[index22].ConnectedChunks[1].Road && chunkGenerateDataList1[index22].ConnectedChunks[2].Road || chunkGenerateDataList1[index22].ConnectedChunks[2].Road && chunkGenerateDataList1[index22].ConnectedChunks[3].Road || chunkGenerateDataList1[index22].ConnectedChunks[3].Road && chunkGenerateDataList1[index22].ConnectedChunks[0].Road)
              {
                this.NewChunks[chunkGenerateDataList1[index22].X, chunkGenerateDataList1[index22].Y].WorldChunkType = e_WorldChunkType.RoadL;
                if (chunkGenerateDataList1[index22].ConnectedChunks[0].Road && chunkGenerateDataList1[index22].ConnectedChunks[1].Road)
                  this.NewChunks[chunkGenerateDataList1[index22].X, chunkGenerateDataList1[index22].Y].Rot = 1;
                if (chunkGenerateDataList1[index22].ConnectedChunks[1].Road && chunkGenerateDataList1[index22].ConnectedChunks[2].Road)
                  this.NewChunks[chunkGenerateDataList1[index22].X, chunkGenerateDataList1[index22].Y].Rot = 2;
                if (chunkGenerateDataList1[index22].ConnectedChunks[2].Road && chunkGenerateDataList1[index22].ConnectedChunks[3].Road)
                  this.NewChunks[chunkGenerateDataList1[index22].X, chunkGenerateDataList1[index22].Y].Rot = 3;
                if (chunkGenerateDataList1[index22].ConnectedChunks[3].Road && chunkGenerateDataList1[index22].ConnectedChunks[0].Road)
                {
                  this.NewChunks[chunkGenerateDataList1[index22].X, chunkGenerateDataList1[index22].Y].Rot = 0;
                  continue;
                }
                continue;
              }
              this.NewChunks[chunkGenerateDataList1[index22].X, chunkGenerateDataList1[index22].Y].WorldChunkType = e_WorldChunkType.Road;
              if (chunkGenerateDataList1[index22].ConnectedChunks[0].Road)
                this.NewChunks[chunkGenerateDataList1[index22].X, chunkGenerateDataList1[index22].Y].Rot = 0;
              if (chunkGenerateDataList1[index22].ConnectedChunks[1].Road)
                this.NewChunks[chunkGenerateDataList1[index22].X, chunkGenerateDataList1[index22].Y].Rot = 1;
              if (chunkGenerateDataList1[index22].ConnectedChunks[2].Road)
                this.NewChunks[chunkGenerateDataList1[index22].X, chunkGenerateDataList1[index22].Y].Rot = 2;
              if (chunkGenerateDataList1[index22].ConnectedChunks[3].Road)
              {
                this.NewChunks[chunkGenerateDataList1[index22].X, chunkGenerateDataList1[index22].Y].Rot = 3;
                continue;
              }
              continue;
            }
            continue;
          case 3:
            if (chunkGenerateDataList1[index22].WorldChunkType == e_WorldChunkType.Plain)
            {
              this.NewChunks[chunkGenerateDataList1[index22].X, chunkGenerateDataList1[index22].Y].WorldChunkType = e_WorldChunkType.RoadT;
              if (!chunkGenerateDataList1[index22].ConnectedChunks[0].Road)
                this.NewChunks[chunkGenerateDataList1[index22].X, chunkGenerateDataList1[index22].Y].Rot = 0;
              if (!chunkGenerateDataList1[index22].ConnectedChunks[1].Road)
                this.NewChunks[chunkGenerateDataList1[index22].X, chunkGenerateDataList1[index22].Y].Rot = 1;
              if (!chunkGenerateDataList1[index22].ConnectedChunks[2].Road)
                this.NewChunks[chunkGenerateDataList1[index22].X, chunkGenerateDataList1[index22].Y].Rot = 2;
              if (!chunkGenerateDataList1[index22].ConnectedChunks[3].Road)
              {
                this.NewChunks[chunkGenerateDataList1[index22].X, chunkGenerateDataList1[index22].Y].Rot = 3;
                continue;
              }
              continue;
            }
            continue;
          case 4:
            if (chunkGenerateDataList1[index22].WorldChunkType == e_WorldChunkType.Plain)
            {
              this.NewChunks[chunkGenerateDataList1[index22].X, chunkGenerateDataList1[index22].Y].WorldChunkType = e_WorldChunkType.RoadX;
              continue;
            }
            continue;
          default:
            continue;
        }
      }
    }
    int num27 = 30;
    List<ChunkGenerateData> chunkGenerateDataList2 = new List<ChunkGenerateData>();
    for (int index24 = 1; index24 < maxExclusive1 - 1; ++index24)
    {
      for (int index25 = 1; index25 < maxExclusive2 - 1; ++index25)
      {
        if (this.NewChunks[index24, index25].WorldChunkType == e_WorldChunkType.Plain)
          chunkGenerateDataList2.Add(this.NewChunks[index24, index25]);
      }
    }
    for (int index26 = 0; index26 < num27; ++index26)
    {
      if (chunkGenerateDataList2.Count > 0)
      {
        int index27 = UnityEngine.Random.Range(0, chunkGenerateDataList2.Count);
        chunkGenerateDataList2[index27].Structure = UnityEngine.Random.Range(1, this.PrefabStructures.Count + 1);
        chunkGenerateDataList2.RemoveAt(index27);
      }
    }
    for (int index28 = 16 /*0x10*/; index28 < maxExclusive1 - 1; ++index28)
    {
      for (int index29 = 16 /*0x10*/; index29 < maxExclusive2 - 1; ++index29)
      {
        if (this.NewChunks[index28, index29].WorldChunkType == e_WorldChunkType.Plain && !this.NewChunks[index28, index29].Road)
        {
          this.NewChunks[index28, index29].Structure = 0;
          this.NewChunks[index28, index29].WorldChunkType = e_WorldChunkType.PlayerStart;
          goto label_265;
        }
      }
    }
label_265:
    for (int index30 = 1; index30 < maxExclusive1 - 1; ++index30)
    {
      for (int index31 = 1; index31 < maxExclusive2 - 1; ++index31)
      {
        int worldChunkType = (int) this.NewChunks[index30, index31].WorldChunkType;
        Transform transform2;
        if (worldChunkType == 21)
        {
          transform2 = UnityEngine.Object.Instantiate<GameObject>(this.PlayerStartPrefab).transform;
          transform1 = transform2;
        }
        else
        {
          switch (this.NewChunks[index30, index31].Biome)
          {
            case e_WorldBiome.Desert:
              transform2 = UnityEngine.Object.Instantiate<bl_WorldChunk>(this.PrefabChunks_Desert[worldChunkType]).transform;
              break;
            case e_WorldBiome.Forest:
              transform2 = UnityEngine.Object.Instantiate<bl_WorldChunk>(this.PrefabChunks_Forest[worldChunkType]).transform;
              break;
            default:
              transform2 = UnityEngine.Object.Instantiate<bl_WorldChunk>(this.PrefabChunks[worldChunkType]).transform;
              break;
          }
        }
        transform2.transform.position = startingPos + new Vector3((float) (index30 * 27), (float) (this.NewChunks[index30, index31].Height * 9), (float) (index31 * 27));
        transform2.transform.eulerAngles = new Vector3(-90f, 0.0f, (float) (90 * this.NewChunks[index30, index31].Rot));
        transform2.localScale = new Vector3(100f, this.NewChunks[index30, index31].Reverse ? -100f : 100f, 100f);
        transform2.name = $"Chunk_{index30.ToString()}_{index31.ToString()}";
        bl_WorldChunk component1 = transform2.gameObject.GetComponent<bl_WorldChunk>();
        component1.XCordinate = index30;
        component1.YCordinate = index31;
        component1.ThisType = (e_WorldChunkType) worldChunkType;
        component1.ThisData = this.NewChunks[index30, index31];
        component1.OnSpawnChunk();
        int structure = this.NewChunks[index30, index31].Structure;
        if (structure != 0)
        {
          Transform transform3 = UnityEngine.Object.Instantiate<GameObject>(this.PrefabStructures[structure - 1]).transform;
          transform3.position = transform2.transform.position;
          transform3.gameObject.SetActive(true);
        }
        bl_Temp_onChunkSpawn component2 = transform2.GetComponent<bl_Temp_onChunkSpawn>();
        if ((UnityEngine.Object) component2 != (UnityEngine.Object) null)
          component2.OnChunkSpawn();
      }
    }
    Debug.Log((object) "spawn temp walls");
    for (int index = 0; index < maxExclusive1 - 1; ++index)
      UnityEngine.Object.Instantiate<GameObject>(this.TempWall).transform.transform.position = new Vector3((float) (index * 27), (float) (this.NewChunks[index, 0].Height * 9), 0.0f);
    for (int index = 1; index < maxExclusive1; ++index)
      UnityEngine.Object.Instantiate<GameObject>(this.TempWall).transform.transform.position = new Vector3(0.0f, (float) (this.NewChunks[0, index].Height * 9), (float) (index * 27));
    for (int index = 1; index < maxExclusive1; ++index)
      UnityEngine.Object.Instantiate<GameObject>(this.TempWall).transform.transform.position = new Vector3((float) (index * 27), (float) (this.NewChunks[index, maxExclusive1 - 1].Height * 9), (float) ((maxExclusive1 - 1) * 27));
    for (int index = 0; index < maxExclusive1 - 1; ++index)
      UnityEngine.Object.Instantiate<GameObject>(this.TempWall).transform.transform.position = new Vector3((float) ((maxExclusive1 - 1) * 27), (float) (this.NewChunks[maxExclusive1 - 1, index].Height * 9), (float) (index * 27));
    Debug.Log((object) "placing player");
    Transform Spot = transform1.Find("PlayerStart");
    Main.Instance.Player.PlaceAt(Spot);
    Main.Instance.Player.transform.eulerAngles = Vector3.zero;
    Main.Instance.PlayerWakeupPlaces.Clear();
    Main.Instance.PlayerWakeupPlaces.Add(Spot);
    Main.Instance.Player.UserControl.ResetSpot = Spot;
    Debug.Log((object) "Finished Generation");
  }
}
