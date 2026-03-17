// Decompiled with JetBrains decompiler
// Type: bl_BuiltPart
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class bl_BuiltPart : bl_MinableObject
{
  [ContextMenu("Make Buildable")]
  public void MakeBuildable()
  {
    this.RootObj = this.transform.root.gameObject;
    this.PrefabName = this.RootObj.name;
    this.InteractText = string.Empty;
    this.PlaceNPCOnInteract = false;
    this.PromptWhenAvailable = "Break";
    this.TimeMiningMax = 5f;
    this.MiningAnim = "Pickaxe";
    this.MiningTool = e_MiningTool.Axe;
  }
}
