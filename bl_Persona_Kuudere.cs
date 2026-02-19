// Decompiled with JetBrains decompiler
// Type: bl_Persona_Kuudere
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
