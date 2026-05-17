// Decompiled with JetBrains decompiler
// Type: int_startsex
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
