// Decompiled with JetBrains decompiler
// Type: BadPoleDance
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
