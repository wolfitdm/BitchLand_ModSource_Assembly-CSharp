// Decompiled with JetBrains decompiler
// Type: int_startsex
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
