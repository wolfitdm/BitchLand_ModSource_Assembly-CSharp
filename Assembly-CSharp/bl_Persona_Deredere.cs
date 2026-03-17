// Decompiled with JetBrains decompiler
// Type: bl_Persona_Deredere
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class bl_Persona_Deredere : bl_Personality
{
  public bl_Persona_Deredere() => this.FaceBlendshape = e_BlendShapes.Smile;

  public override string Reply_Hello(out int lineIndex)
  {
    string[] strArray = new string[3]
    {
      "Oh Heyyo!",
      "Hi there!",
      "Hi Hi!"
    };
    lineIndex = this.GetRandOf(strArray.Length);
    return strArray[lineIndex];
  }

  public override int PickSexOption() => Random.Range(0, 2);
}
