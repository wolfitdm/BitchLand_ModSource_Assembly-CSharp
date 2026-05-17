// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.StandardCaseView
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
