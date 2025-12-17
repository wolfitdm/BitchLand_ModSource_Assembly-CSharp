// Decompiled with JetBrains decompiler
// Type: bl_Persona_Imature
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class bl_Persona_Imature : bl_Personality
{
  public bl_Persona_Imature() => this.FaceBlendshape = e_BlendShapes.Smile;

  public override string Reply_Hello(out int lineIndex)
  {
    string[] strArray = new string[3]
    {
      "HI!",
      "HELLO!",
      "WHAT do YOU want?"
    };
    lineIndex = Random.Range(0, strArray.Length);
    return strArray[lineIndex];
  }

  public override int PickSexOption() => Random.Range(0, 2) != 0 ? 2 : 0;
}
