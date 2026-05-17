// Decompiled with JetBrains decompiler
// Type: mminit_1
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class mminit_1 : mainmenu_animsetup
{
  public Girl TheGirl;

  public override void Init()
  {
    base.Init();
    this.TheGirl.AttatchBoobsToHands();
    this.TheGirl.A_Standing = "boobs1";
    this.TheGirl.SetHighLod();
  }
}
