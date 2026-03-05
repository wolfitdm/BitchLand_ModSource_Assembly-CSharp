// Decompiled with JetBrains decompiler
// Type: MortarCrewLoader
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
