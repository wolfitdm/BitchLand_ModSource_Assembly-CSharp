// Decompiled with JetBrains decompiler
// Type: bl_Persona_Scared
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
