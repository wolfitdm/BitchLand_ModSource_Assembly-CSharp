// Decompiled with JetBrains decompiler
// Type: int_food
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
