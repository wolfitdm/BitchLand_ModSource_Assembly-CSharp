// Decompiled with JetBrains decompiler
// Type: bl_UndergroundMine_Part
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class bl_UndergroundMine_Part : bl_MinableObject
{
  public bl_UndergroundMine ThisMine;
  public bl_UndergroundMine2 ThisMine2;
  public int X;
  public int Y;
  public int Z;

  public override bool CheckCanInteract(Person person)
  {
    return this.Y > -33 && base.CheckCanInteract(person);
  }

  public override void Break(Person person) => this.ThisMine2.EmptyBlock(this.X, this.Y, this.Z);
}
