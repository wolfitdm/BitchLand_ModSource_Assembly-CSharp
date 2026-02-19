// Decompiled with JetBrains decompiler
// Type: MortarCrewLoader
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class MortarCrewLoader : MonoBehaviour
{
  public MortarAction myMortar;
  private Animator myAnim;
  public bool flipIdle;

  private void Start() => this.myAnim = this.GetComponent<Animator>();

  public void FIRE_Mortar() => this.myMortar.Fire();

  public void EnableFireMortar()
  {
    this.myAnim.SetTrigger("fire");
    this.flipIdle = !this.flipIdle;
    this.myAnim.SetBool("flipIdle", this.flipIdle);
  }
}
