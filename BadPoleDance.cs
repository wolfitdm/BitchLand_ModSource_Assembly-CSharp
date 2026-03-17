// Decompiled with JetBrains decompiler
// Type: BadPoleDance
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
