// Decompiled with JetBrains decompiler
// Type: Squad_Leader_Mortar
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
