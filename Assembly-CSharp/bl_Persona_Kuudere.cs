// Decompiled with JetBrains decompiler
// Type: bl_Persona_Kuudere
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
