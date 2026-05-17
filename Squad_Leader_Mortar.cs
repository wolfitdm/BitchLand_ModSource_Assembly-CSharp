// Decompiled with JetBrains decompiler
// Type: Squad_Leader_Mortar
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Squad_Leader_Mortar : MonoBehaviour
{
  public MortarCrewLoader[] myCrew;
  private Animator myAnim;

  private void Start() => this.myAnim = this.GetComponent<Animator>();

  public void FireMortar()
  {
    foreach (MortarCrewLoader mortarCrewLoader in this.myCrew)
      mortarCrewLoader.EnableFireMortar();
    this.myAnim.SetTrigger("fire");
  }
}
