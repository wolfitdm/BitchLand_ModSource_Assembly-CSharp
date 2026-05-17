// Decompiled with JetBrains decompiler
// Type: bl_Persona_Aggressive
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
