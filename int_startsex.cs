// Decompiled with JetBrains decompiler
// Type: int_startsex
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
