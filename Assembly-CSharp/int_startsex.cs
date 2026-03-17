// Decompiled with JetBrains decompiler
// Type: int_startsex
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class int_startsex : Interactible
{
  public Person ThisPerosn;

  public override void Interact(Person person)
  {
    this.ThisPerosn.UnRagdoll();
    this.ThisPerosn.Energy = 0.0f;
    Main.Instance.SexScene.SpawnSexScene(3, 1, Main.Instance.Player, this.ThisPerosn);
  }
}
