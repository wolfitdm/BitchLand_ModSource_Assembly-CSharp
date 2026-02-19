// Decompiled with JetBrains decompiler
// Type: bl_Persona_Scared
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class bl_Persona_Scared : bl_Personality
{
  public bl_Persona_Scared() => this.FaceBlendshape = e_BlendShapes.Scared;

  public override string Reply_Hello(out int lineIndex)
  {
    string[] strArray = new string[3]
    {
      "WHY?!",
      "Stop!",
      "Get away!"
    };
    lineIndex = this.GetRandOf(strArray.Length);
    return strArray[lineIndex];
  }

  public override int PickSexOption() => 1;
}
