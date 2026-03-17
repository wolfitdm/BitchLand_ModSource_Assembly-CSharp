// Decompiled with JetBrains decompiler
// Type: bl_Persona_Tsundere
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class bl_Persona_Tsundere : bl_Personality
{
  public bl_Persona_Tsundere() => this.FaceBlendshape = e_BlendShapes.Angry;

  public override string Reply_Hello(out int lineIndex)
  {
    string[] strArray = new string[3]
    {
      "And you're talking to me because...?",
      "What do you want?",
      "I'm busy!"
    };
    lineIndex = this.GetRandOf(strArray.Length);
    return strArray[lineIndex];
  }

  public override int PickSexOption() => Random.Range(0, 3);
}
