// Decompiled with JetBrains decompiler
// Type: MortarCrewLoader
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
