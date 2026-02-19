// Decompiled with JetBrains decompiler
// Type: int_food
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class int_food : int_ResourceItem
{
  public float Nutrition = 10f;
  public AudioClip Sound;

  public override void Interact(Person person) => this.Eat(person);

  public virtual void Eat(Person person)
  {
    person.Hunger -= this.Nutrition;
    if ((double) person.Hunger < 0.0)
      person.Hunger = 0.0f;
    person.TheHealth.ChangeHealth(this.Nutrition, false, person);
    person.Toilet += this.Nutrition;
    Object.Destroy((Object) this.RootObj);
    if (!((Object) this.Sound != (Object) null))
      return;
    person.PersonAudio.PlayOneShot(this.Sound);
  }
}
