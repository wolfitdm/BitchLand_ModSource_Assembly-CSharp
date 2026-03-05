// Decompiled with JetBrains decompiler
// Type: bl_meleeHitBox
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class bl_meleeHitBox : MonoBehaviour
{
  public void OnTriggerEnter(Collider other)
  {
    Person component = other.transform.root.GetComponent<Person>();
    if (!((UnityEngine.Object) component != (UnityEngine.Object) null) || component.IsPlayer || component.CantBeHit)
      return;
    if (Main.Instance.Player.Doing_Punch)
      Main.Instance.Player.Punch(component);
    else if (Main.Instance.Player.Doing_ThrowDown)
      Main.Instance.Player.ThrowDown(component);
    else
      Main.Instance.Player.MeleeHit(component);
    this.gameObject.SetActive(false);
  }

  public void OnEnable()
  {
    Main.RunInSeconds((Action) (() => this.gameObject.SetActive(false)), 1f);
  }
}
