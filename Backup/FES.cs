// Decompiled with JetBrains decompiler
// Type: FES
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class FES : BaseType
{
  public override void ApplyTo(
    Person person,
    bool addClothing = true,
    bool addWeapon = true,
    bool addHair = true,
    RandomNPCHere commingFrom = null)
  {
    if ((double) Random.Range(0.0f, 1f) < 0.5)
      person.HasPenis = true;
    base.ApplyTo(person, addClothing, addWeapon, addHair, commingFrom);
    if (person.HasPenis)
    {
      float num = Random.Range(2.7f, 4f);
      person.Penis.transform.localScale = new Vector3(num, num, num);
    }
    if (person is Girl)
    {
      float num1 = Random.Range(0.2f, 0.8f);
      Vector3 vector3_1;
      if ((double) Random.Range(0.0f, 1f) < 0.75)
      {
        Transform boobRight = person.BoobRight;
        Transform boobLeft = person.BoobLeft;
        vector3_1 = new Vector3(person.BoobLeft.localScale.x + num1, person.BoobLeft.localScale.y + num1, person.BoobLeft.localScale.z + num1);
        Vector3 vector3_2 = vector3_1;
        boobLeft.localScale = vector3_2;
        Vector3 vector3_3 = vector3_1;
        boobRight.localScale = vector3_3;
      }
      else if ((double) Random.Range(0.0f, 1f) < 0.5)
        person.BoobLeft.localScale = new Vector3(person.BoobLeft.localScale.x + num1, person.BoobLeft.localScale.y + num1, person.BoobLeft.localScale.z + num1);
      else
        person.BoobRight.localScale = new Vector3(person.BoobRight.localScale.x + num1, person.BoobRight.localScale.y + num1, person.BoobRight.localScale.z + num1);
      float num2 = Random.Range(0.8f, 2f);
      float z = Random.Range(0.8f, 2f);
      Transform nippleLeft = person.NippleLeft;
      Transform nippleRight = person.NippleRight;
      vector3_1 = new Vector3(num2, num2, z);
      Vector3 vector3_4 = vector3_1;
      nippleRight.localScale = vector3_4;
      Vector3 vector3_5 = vector3_1;
      nippleLeft.localScale = vector3_5;
      float num3 = Random.Range(1f, 1.3f);
      person.Hips.localScale = new Vector3(num3, 1f, num3);
    }
    if ((double) Random.Range(0.0f, 1f) < 0.25)
      person.HandLeft.localScale = Vector3.zero;
    if ((double) Random.Range(0.0f, 1f) < 0.25)
      person.ForeArmLeft.parent.localScale = Vector3.zero;
    if ((double) Random.Range(0.0f, 1f) < 0.25)
      person.UpperArmLeft.parent.localScale = Vector3.zero;
    if ((double) Random.Range(0.0f, 1f) < 0.25)
      person.HandRight.localScale = Vector3.zero;
    if ((double) Random.Range(0.0f, 1f) < 0.25)
      person.ForeArmRight.parent.localScale = Vector3.zero;
    if ((double) Random.Range(0.0f, 1f) < 0.25)
      person.UpperArmRight.parent.localScale = Vector3.zero;
    person.States[20] = true;
    person.States[0] = true;
    person.States[2] = true;
    person.SetBodyTexture();
  }
}
