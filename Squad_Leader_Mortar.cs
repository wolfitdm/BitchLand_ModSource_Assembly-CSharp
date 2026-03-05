// Decompiled with JetBrains decompiler
// Type: Squad_Leader_Mortar
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
