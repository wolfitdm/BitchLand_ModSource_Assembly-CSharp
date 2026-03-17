// Decompiled with JetBrains decompiler
// Type: bl_UndergroundMine
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class bl_UndergroundMine : MonoBehaviour
{
  public int XSize = 16;
  public int YSize = 16;
  public int ZSize = 16;
  public bl_UndergroundMine_Block[,,] Blocks;
  public const float XScale = 4.5f;
  public const float YScale = 3f;
  public const float ZScale = 4.5f;

  public void Start() => this.CreateNew();

  public void CreateNew()
  {
    this.Blocks = new bl_UndergroundMine_Block[this.XSize, this.YSize, this.ZSize];
    bl_UndergroundMine_Block undergroundMineBlock = this.EmptyBlock(this.XSize / 2, this.YSize - 2, 1);
    GameObject gameObject = Main.Spawn(Main.Instance.GetPrefab("MineExit"));
    gameObject.transform.SetParent(undergroundMineBlock.transform);
    gameObject.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
  }

  public bl_UndergroundMine_Block GetBlockAt(int x, int y, int z)
  {
    bl_UndergroundMine_Block blockAt = this.Blocks[x, y, z];
    if ((Object) blockAt == (Object) null)
    {
      blockAt = new GameObject(x.ToString() + "_" + y.ToString() + "_" + z.ToString()).AddComponent<bl_UndergroundMine_Block>();
      blockAt.transform.position = new Vector3((float) x * 4.5f, (float) y * 3f, (float) z * 4.5f);
      blockAt.OpenTo = new bool[6];
      blockAt.Parts = new GameObject[6];
      this.Blocks[x, y, z] = blockAt;
    }
    return blockAt;
  }

  public bl_UndergroundMine_Block EmptyBlock(int x, int y, int z)
  {
    if (x == 0 || y == 0 || z == 0 || x == this.XSize - 1 || y == this.YSize - 1 || z == this.ZSize - 1)
      return (bl_UndergroundMine_Block) null;
    bl_UndergroundMine_Block blockAt = this.GetBlockAt(x, y, z);
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
      if ((Object) blockAt.Parts[index] != (Object) null)
        Object.Destroy((Object) blockAt.Parts[index]);
    }
    int dir1 = 0;
    if (!blockAt.OpenTo[dir1])
    {
      int num = Random.Range(0, 4);
      this.AddComp(undergroundMineBlockArray[dir1], dir1, x, y - 1, z, "Mine_Floor", new Vector3(0.0f, 3f, 0.0f), new Vector3(0.0f, (float) (num * 90), 0.0f));
    }
    int dir2 = 1;
    if (!blockAt.OpenTo[dir2])
    {
      int num = Random.Range(0, 4);
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
    undergroundMinePart.ThisMine = this;
    undergroundMinePart.MiningTool = e_MiningTool.Shovel;
    undergroundMinePart.MiningAnim = "Pickaxe";
    undergroundMinePart.TimeMiningMax = 0.1f;
    undergroundMinePart.PromptWhenAvailable = "Dig";
    undergroundMinePart.RootObj = undergroundMinePart.gameObject;
    undergroundMinePart.transform.GetChild(0).gameObject.AddComponent<InteractRedirect>().Redirect = (Interactible) undergroundMinePart;
    sideBlock.Parts[dir].transform.localPosition = pos;
    sideBlock.Parts[dir].transform.localEulerAngles = rot;
  }
}
