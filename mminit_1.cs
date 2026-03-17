// Decompiled with JetBrains decompiler
// Type: mminit_1
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
