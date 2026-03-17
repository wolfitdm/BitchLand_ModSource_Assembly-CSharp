// Decompiled with JetBrains decompiler
// Type: int_GooPills
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class int_GooPills : int_food
{
  public override void Eat(Person person)
  {
    base.Eat(person);
    person.IntestinalSubstance = 1;
    person.Toilet = person.ToiletMax;
    person.ShitOnFloor();
  }
}
