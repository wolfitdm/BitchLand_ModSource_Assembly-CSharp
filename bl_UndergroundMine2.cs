// Decompiled with JetBrains decompiler
// Type: bl_UndergroundMine2
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

#nullable disable
public class bl_UndergroundMine2 : MonoBehaviour
{
  public static bl_UndergroundMine2 Instance;
  public MonoBehaviour NavMines;
  public MonoBehaviour GloballyUpdateNav;
  public bool _Loaded;
  public List<GameObject> PrevOn = new List<GameObject>();
  public const float XScale = 4.5f;
  public const float YScale = 3f;
  public const float ZScale = 4.5f;
  public Dictionary<(int, int, int), bl_UndergroundMine_Block> Blocks = new Dictionary<(int, int, int), bl_UndergroundMine_Block>();

  public void Start() => bl_UndergroundMine2.Instance = this;

  public void CreateNew(int x, int y, bool placePlayer = false)
  {
    bl_UndergroundMine2.Instance = this;
    Main.Instance.Nav.enabled = false;
    if (!this._Loaded)
      this.LoadMines(string.Empty);
    this._Loaded = true;
    this.NavMines.GetType().GetMethod("BuildNavMesh").Invoke((object) this.NavMines, (object[]) null);
    Main.Instance.Nav2 = this.GloballyUpdateNav;
    bl_UndergroundMine_Block blockAt = this.GetBlockAt(x, 0, y);
    if (!blockAt.Empty)
    {
      this.EmptyBlock(x, 0, y);
      this.EmptyBlock(x, 0, y + 1);
      GameObject gameObject1 = Main.Spawn(Main.Instance.GetPrefab("MineExit"), blockAt.transform);
      gameObject1.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
      gameObject1.transform.SetParent((Transform) null);
      GameObject gameObject2 = Main.Spawn(Main.Instance.GetPrefab("WoodFloor"), blockAt.transform);
      gameObject2.transform.localPosition = Vector3.zero;
      gameObject2.transform.localEulerAngles = new Vector3(0.0f, 90f, 0.0f);
      gameObject2.transform.SetParent((Transform) null);
    }
    if (!placePlayer)
      return;
    Main.Instance.Player.transform.position = blockAt.transform.position;
    Main.Instance.PlayerWakeupPlaces.Clear();
    Main.Instance.PlayerWakeupPlaces.Add(blockAt.transform);
    Main.Instance.Player.UserControl.ResetSpot = blockAt.transform;
    this.OnEnterMines();
  }

  public bl_UndergroundMine_Block GetBlockAt(int x, int y, int z)
  {
    bl_UndergroundMine_Block blockAt;
    if (!this.Blocks.TryGetValue((x, y, z), out blockAt))
    {
      blockAt = new GameObject(x.ToString() + "_" + y.ToString() + "_" + z.ToString()).AddComponent<bl_UndergroundMine_Block>();
      blockAt.transform.position = new Vector3((float) x * 4.5f, (float) y * 3f, (float) z * 4.5f);
      blockAt.OpenTo = new bool[6];
      blockAt.Parts = new GameObject[6];
      this.Blocks.Add((x, y, z), blockAt);
    }
    return blockAt;
  }

  public bl_UndergroundMine_Block EmptyBlock(int x, int y, int z)
  {
    bl_UndergroundMine_Block blockAt = this.GetBlockAt(x, y, z);
    if (blockAt.Empty)
      return blockAt;
    blockAt.Empty = true;
    bl_UndergroundMine_Block[] undergroundMineBlockArray = new bl_UndergroundMine_Block[6]
    {
      this.GetBlockAt(x, y - 1, z),
      this.GetBlockAt(x, y + 1, z),
      this.GetBlockAt(x - 1, y, z),
      this.GetBlockAt(x + 1, y, z),
      this.GetBlockAt(x, y, z - 1),
      this.GetBlockAt(x, y, z + 1)
    };
    for (int index = 0; index < 6; ++index)
      blockAt.OpenTo[index] = undergroundMineBlockArray[index].Empty;
    for (int index = 0; index < blockAt.Parts.Length; ++index)
    {
      if ((UnityEngine.Object) blockAt.Parts[index] != (UnityEngine.Object) null)
        UnityEngine.Object.Destroy((UnityEngine.Object) blockAt.Parts[index]);
    }
    int dir1 = 0;
    if (!blockAt.OpenTo[dir1])
    {
      int num = UnityEngine.Random.Range(0, 4);
      this.AddComp(undergroundMineBlockArray[dir1], dir1, x, y - 1, z, "Mine_Floor", new Vector3(0.0f, 3f, 0.0f), new Vector3(0.0f, (float) (num * 90), 0.0f));
    }
    int dir2 = 1;
    if (!blockAt.OpenTo[dir2])
    {
      int num = UnityEngine.Random.Range(0, 4);
      this.AddComp(undergroundMineBlockArray[dir2], dir2, x, y + 1, z, "Mine_Ceiling", Vector3.zero, new Vector3(0.0f, (float) (num * 90), 0.0f));
    }
    int dir3 = 2;
    if (!blockAt.OpenTo[dir3])
      this.AddComp(undergroundMineBlockArray[dir3], dir3, x - 1, y, z, "Mine_Wall", new Vector3(2.25f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f));
    int dir4 = 3;
    if (!blockAt.OpenTo[dir4])
      this.AddComp(undergroundMineBlockArray[dir4], dir4, x + 1, y, z, "Mine_Wall", new Vector3(-2.25f, 0.0f, 0.0f), new Vector3(0.0f, 180f, 0.0f));
    int dir5 = 4;
    if (!blockAt.OpenTo[dir5])
      this.AddComp(undergroundMineBlockArray[dir5], dir5, x, y, z - 1, "Mine_Wall", new Vector3(0.0f, 0.0f, 2.25f), new Vector3(0.0f, -90f, 0.0f));
    int dir6 = 5;
    if (!blockAt.OpenTo[dir6])
      this.AddComp(undergroundMineBlockArray[dir6], dir6, x, y, z + 1, "Mine_Wall", new Vector3(0.0f, 0.0f, -2.25f), new Vector3(0.0f, 90f, 0.0f));
    GameObject gameObject = Main.Spawn(Main.Instance.GetPrefab("FallingDirt"), blockAt.transform);
    gameObject.transform.localPosition = new Vector3(0.0f, 1.5f, 0.0f);
    gameObject.transform.localEulerAngles = new Vector3(180f, 0.0f, 0.0f);
    this.TriggerNavUpdate();
    return blockAt;
  }

  public void AddComp(
    bl_UndergroundMine_Block sideBlock,
    int dir,
    int x,
    int y,
    int z,
    string prefab,
    Vector3 pos,
    Vector3 rot)
  {
    sideBlock.Parts[dir] = Main.Spawn(Main.Instance.GetPrefab(prefab), sideBlock.transform);
    bl_UndergroundMine_Part undergroundMinePart = sideBlock.Parts[dir].AddComponent<bl_UndergroundMine_Part>();
    undergroundMinePart.X = x;
    undergroundMinePart.Y = y;
    undergroundMinePart.Z = z;
    undergroundMinePart.ThisMine2 = this;
    undergroundMinePart.MiningTool = e_MiningTool.Shovel;
    undergroundMinePart.MiningAnim = "Pickaxe";
    undergroundMinePart.TimeMiningMax = 10f;
    undergroundMinePart.PromptWhenAvailable = "Dig";
    undergroundMinePart.RootObj = undergroundMinePart.gameObject;
    undergroundMinePart.transform.GetChild(0).gameObject.AddComponent<InteractRedirect>().Redirect = (Interactible) undergroundMinePart;
    undergroundMinePart.DontSaveInMain = true;
    sideBlock.Parts[dir].transform.localPosition = pos;
    sideBlock.Parts[dir].transform.localEulerAngles = rot;
  }

  public void OnEnterMines()
  {
    Main.Instance.CapturedBuilding1_Area.OnEnter();
    Main.Instance.NewGameMenu.SmallLoading.SetActive(false);
    Main.Instance.GameplayMenu.ShowNotification("To save the game, exit the mines");
    Main.Instance.CanSaveFlags_add("InsideMines");
    Scene _minesScene = SceneManager.GetSceneByBuildIndex(6);
    for (int index = 0; index < Main.Instance.PeopleFollowingPlayer.Count; ++index)
    {
      Person _pp = Main.Instance.PeopleFollowingPlayer[index];
      _pp.AddMoveBlocker("teleporting");
      Main.RunInNextFrame((Action) (() =>
      {
        SceneManager.MoveGameObjectToScene(_pp.gameObject, _minesScene);
        _pp.PlaceAt(Main.Instance.Player.transform.position);
        _pp.gameObject.SetActive(true);
        _pp.RemoveMoveBlocker("teleporting");
      }), 2);
    }
    int_MineEntrance[] objectsOfType = UnityEngine.Object.FindObjectsOfType<int_MineEntrance>();
    for (int index1 = 0; index1 < objectsOfType.Length; ++index1)
    {
      for (int index2 = 0; index2 < objectsOfType.Length; ++index2)
      {
        double num = (double) Vector2.Distance(new Vector2(objectsOfType[index1].RootObj.transform.position.x, objectsOfType[index1].RootObj.transform.position.z), new Vector2(objectsOfType[index2].RootObj.transform.position.x, objectsOfType[index2].RootObj.transform.position.z));
      }
    }
  }

  public void OnExitMines()
  {
    Main.Instance.Nav.enabled = true;
    Main.Instance.Nav2 = Main.Instance.Nav2_stored;
    Main.Instance.CanSaveFlags_remove("InsideMines");
    Main.Instance.Default_Area.OnEnter();
    Transform transform = UnityEngine.Object.FindObjectOfType<bl_SectionGenerate2>(true)._PlayerStartChunk.Find("PlayerStart");
    Main.Instance.PlayerWakeupPlaces.Clear();
    Main.Instance.PlayerWakeupPlaces.Add(transform);
    Main.Instance.Player.UserControl.ResetSpot = transform;
  }

  public void TriggerNavUpdate()
  {
    Main.RunInNextFrame((Action) (() =>
    {
      Main.Instance.Nav2 = this.GloballyUpdateNav;
      Main.Instance.Nav2.GetType().GetMethod("RequestNavMeshUpdate").Invoke((object) Main.Instance.Nav2, (object[]) null);
    }), 2);
    Main.RunInNextFrame((Action) (() => Main.Instance.GarbageCollect()), 10);
  }

  public void SaveMines(string path)
  {
    Debug.LogError((object) ("SaveMines() -> " + path));
    if (!this._Loaded)
      return;
    using (BinaryWriter binaryWriter = new BinaryWriter((Stream) File.Open(path + "/Mines.dat", FileMode.Create)))
    {
      binaryWriter.Write("14");
      int num = 0;
      foreach (KeyValuePair<(int, int, int), bl_UndergroundMine_Block> block in this.Blocks)
      {
        if (block.Value.Empty)
          ++num;
      }
      binaryWriter.Write(num);
      foreach (KeyValuePair<(int, int, int), bl_UndergroundMine_Block> block in this.Blocks)
      {
        if (block.Value.Empty)
        {
          binaryWriter.Write(block.Key.Item1);
          binaryWriter.Write(block.Key.Item2);
          binaryWriter.Write(block.Key.Item3);
        }
      }
      binaryWriter.Write(1234);
    }
  }

  public void LoadMines(string path)
  {
    Debug.LogError((object) ("LoadMines() -> " + path));
    if (path == null || path.Length == 0)
      path = Main.Instance.CurrentSavePath + "/Section_" + Main.Instance.CurrentSection.ToString();
    string path1 = path + "/Mines.dat";
    if (!File.Exists(path1))
      return;
    using (BinaryReader binaryReader = new BinaryReader((Stream) File.Open(path1, FileMode.Open)))
    {
      binaryReader.ReadString();
      int num = binaryReader.ReadInt32();
      for (int index = 0; index < num; ++index)
        this.GetBlockAt(binaryReader.ReadInt32(), binaryReader.ReadInt32(), binaryReader.ReadInt32()).Empty = true;
      if (binaryReader.ReadInt32() != 1234)
        Debug.LogError((object) "Mines loading error");
    }
    this.RefreshMineEmpties();
  }

  public void RefreshMineEmpties()
  {
    Dictionary<(int, int, int), bl_UndergroundMine_Block> dictionary = new Dictionary<(int, int, int), bl_UndergroundMine_Block>();
    foreach (KeyValuePair<(int, int, int), bl_UndergroundMine_Block> block in this.Blocks)
      dictionary.Add(block.Key, block.Value);
    foreach (KeyValuePair<(int, int, int), bl_UndergroundMine_Block> keyValuePair in dictionary)
    {
      bl_UndergroundMine_Block undergroundMineBlock = keyValuePair.Value;
      if (undergroundMineBlock.Empty)
      {
        int x = keyValuePair.Key.Item1;
        int y = keyValuePair.Key.Item2;
        int z = keyValuePair.Key.Item3;
        bl_UndergroundMine_Block[] undergroundMineBlockArray = new bl_UndergroundMine_Block[6]
        {
          this.GetBlockAt(x, y - 1, z),
          this.GetBlockAt(x, y + 1, z),
          this.GetBlockAt(x - 1, y, z),
          this.GetBlockAt(x + 1, y, z),
          this.GetBlockAt(x, y, z - 1),
          this.GetBlockAt(x, y, z + 1)
        };
        for (int index = 0; index < 6; ++index)
          undergroundMineBlock.OpenTo[index] = undergroundMineBlockArray[index].Empty;
        for (int index = 0; index < undergroundMineBlock.Parts.Length; ++index)
        {
          if ((UnityEngine.Object) undergroundMineBlock.Parts[index] != (UnityEngine.Object) null)
            UnityEngine.Object.Destroy((UnityEngine.Object) undergroundMineBlock.Parts[index]);
        }
        int dir1 = 0;
        if (!undergroundMineBlock.OpenTo[dir1])
        {
          int num = UnityEngine.Random.Range(0, 4);
          this.AddComp(undergroundMineBlockArray[dir1], dir1, x, y - 1, z, "Mine_Floor", new Vector3(0.0f, 3f, 0.0f), new Vector3(0.0f, (float) (num * 90), 0.0f));
        }
        int dir2 = 1;
        if (!undergroundMineBlock.OpenTo[dir2])
        {
          int num = UnityEngine.Random.Range(0, 4);
          this.AddComp(undergroundMineBlockArray[dir2], dir2, x, y + 1, z, "Mine_Ceiling", Vector3.zero, new Vector3(0.0f, (float) (num * 90), 0.0f));
        }
        int dir3 = 2;
        if (!undergroundMineBlock.OpenTo[dir3])
          this.AddComp(undergroundMineBlockArray[dir3], dir3, x - 1, y, z, "Mine_Wall", new Vector3(2.25f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f));
        int dir4 = 3;
        if (!undergroundMineBlock.OpenTo[dir4])
          this.AddComp(undergroundMineBlockArray[dir4], dir4, x + 1, y, z, "Mine_Wall", new Vector3(-2.25f, 0.0f, 0.0f), new Vector3(0.0f, 180f, 0.0f));
        int dir5 = 4;
        if (!undergroundMineBlock.OpenTo[dir5])
          this.AddComp(undergroundMineBlockArray[dir5], dir5, x, y, z - 1, "Mine_Wall", new Vector3(0.0f, 0.0f, 2.25f), new Vector3(0.0f, -90f, 0.0f));
        int dir6 = 5;
        if (!undergroundMineBlock.OpenTo[dir6])
          this.AddComp(undergroundMineBlockArray[dir6], dir6, x, y, z + 1, "Mine_Wall", new Vector3(0.0f, 0.0f, -2.25f), new Vector3(0.0f, 90f, 0.0f));
      }
    }
  }
}
