// Decompiled with JetBrains decompiler
// Type: int_GooPills
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
