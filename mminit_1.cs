// Decompiled with JetBrains decompiler
// Type: mminit_1
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
