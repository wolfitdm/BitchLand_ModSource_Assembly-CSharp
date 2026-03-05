// Decompiled with JetBrains decompiler
// Type: bl_Persona_Aggressive
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class bl_Persona_Aggressive : bl_Personality
{
  public bl_Persona_Aggressive() => this.FaceBlendshape = e_BlendShapes.Angry;

  public override string Reply_Hello(out int lineIndex)
  {
    string[] strArray = new string[3]
    {
      "WHAT DO YOU WANT?!",
      "Wanna get it'on?",
      "What!"
    };
    lineIndex = this.GetRandOf(strArray.Length);
    return strArray[lineIndex];
  }

  public override int PickSexOption() => Random.Range(0, 2) + 1;

  public override void OnSeeNakedPerson(Person thisPerson, Person person, bool forceAnyway = false)
  {
    base.OnSeeNakedPerson(thisPerson, person);
  }

  public override void OnSeeSexyPerson(Person thisPerson, Person person)
  {
    base.OnSeeSexyPerson(thisPerson, person);
  }
}
