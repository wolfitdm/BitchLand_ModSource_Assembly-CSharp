// Decompiled with JetBrains decompiler
// Type: bl_BuiltPart
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
