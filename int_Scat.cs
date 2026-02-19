// Decompiled with JetBrains decompiler
// Type: int_Scat
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class int_Scat : int_food
{
  public int Substance;

  public void SetSizeOnSpawn()
  {
    float num = this.Nutrition / 10f;
    if ((double) num < 0.5)
      num = 0.5f;
    this.RootObj.transform.GetChild(0).localScale = new Vector3(num, num, num);
  }

  public override void Eat(Person person)
  {
    base.Eat(person);
    person.GainSexXP((int) this.Nutrition * 10);
    if (this.Substance != 0 || person.States[33])
      return;
    person.States[33] = true;
    person.SetBodyTexture();
  }

  public static float NutritionOf(int Hunger) => (float) ((100 - Hunger) / 4);

  public static float NutritionOfToilet(float toilet) => toilet / 4f;
}
