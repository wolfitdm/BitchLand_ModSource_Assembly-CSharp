// Decompiled with JetBrains decompiler
// Type: int_food
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
