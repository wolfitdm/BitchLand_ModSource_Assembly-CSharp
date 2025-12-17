// Decompiled with JetBrains decompiler
// Type: Squad_Leader_Mortar
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
