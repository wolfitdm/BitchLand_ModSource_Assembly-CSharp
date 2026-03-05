// Decompiled with JetBrains decompiler
// Type: int_GooPills
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
