// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.StandardCaseView
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace VariableInventorySystem
{
  public class StandardCaseView : StandardStashView
  {
    public override void OnDroped(bool isDroped)
    {
      base.OnDroped(isDroped);
      this.ReApply();
    }
  }
}
