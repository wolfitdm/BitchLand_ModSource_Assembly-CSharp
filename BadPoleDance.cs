// Decompiled with JetBrains decompiler
// Type: BadPoleDance
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class BadPoleDance : ThingToDo
{
  public override void Update()
  {
    base.Update();
    AnimatorStateInfo animatorStateInfo = this.ThisPerson.Anim.GetCurrentAnimatorStateInfo(0);
    this.ThisPerson.Anim.GetCurrentAnimatorClipInfo(0);
    if ((double) animatorStateInfo.normalizedTime % 1.0 >= 0.10000000149011612)
      return;
    this.ThisPerson.transform.position = this.Pos;
    this.ThisPerson.transform.eulerAngles = this.Rot;
  }
}
