// Decompiled with JetBrains decompiler
// Type: BadPoleDance
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
