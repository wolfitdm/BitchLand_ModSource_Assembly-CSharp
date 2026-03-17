// Decompiled with JetBrains decompiler
// Type: MortarSquadLeader
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class MortarSquadLeader : MonoBehaviour
{
  public MortarCrewLoader[] myLoader;
  private Animator myAnim;
  public float fireChance3outof5 = 2f;
  public int salvoCount = 5;
  public int roundsFired;
  private float chanceResult;

  private void Start() => this.myAnim = this.GetComponent<Animator>();

  public void FireMortar()
  {
    foreach (MortarCrewLoader mortarCrewLoader in this.myLoader)
      mortarCrewLoader.EnableFireMortar();
  }

  public void DecidetoFire()
  {
    this.chanceResult = (float) Random.Range(0, 5);
    if ((double) this.chanceResult >= (double) this.fireChance3outof5)
      return;
    this.myAnim.SetTrigger("fire");
  }

  public void UpdateSalvoCount()
  {
    ++this.roundsFired;
    if (this.roundsFired < this.salvoCount)
    {
      this.myAnim.SetTrigger("fire");
    }
    else
    {
      this.roundsFired = 0;
      this.myAnim.ResetTrigger("fire");
    }
  }
}
