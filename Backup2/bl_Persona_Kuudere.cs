// Decompiled with JetBrains decompiler
// Type: bl_Persona_Kuudere
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class bl_Persona_Kuudere : bl_Personality
{
  public override string Reply_Hello(out int lineIndex)
  {
    string[] strArray = new string[3]
    {
      "Hi?",
      "Hi",
      "Hello"
    };
    lineIndex = this.GetRandOf(strArray.Length);
    return strArray[lineIndex];
  }

  public override int PickSexOption() => Random.Range(0, 2) != 0 ? 2 : 0;
}
