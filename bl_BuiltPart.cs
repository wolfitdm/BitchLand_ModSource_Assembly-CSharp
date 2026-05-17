// Decompiled with JetBrains decompiler
// Type: bl_BuiltPart
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
