// Decompiled with JetBrains decompiler
// Type: MortarSquadLeader
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
