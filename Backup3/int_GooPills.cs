// Decompiled with JetBrains decompiler
// Type: int_GooPills
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
