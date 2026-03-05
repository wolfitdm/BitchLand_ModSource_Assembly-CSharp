// Decompiled with JetBrains decompiler
// Type: bl_Persona_Motherly
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class bl_Persona_Motherly : bl_Personality
{
  public bl_Persona_Motherly() => this.FaceBlendshape = e_BlendShapes.Smug;

  public override string Reply_Hello(out int lineIndex)
  {
    string[] strArray = new string[3]
    {
      "Oh hi there~",
      "Hello~",
      "Can I...help you?"
    };
    lineIndex = this.GetRandOf(strArray.Length);
    return strArray[lineIndex];
  }

  public override int PickSexOption() => 1;
}
