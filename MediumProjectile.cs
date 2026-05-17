// Decompiled with JetBrains decompiler
// Type: MediumProjectile
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class MediumProjectile : AntiMissileProjectile
{
  [Header("Child class")]
  [Tooltip("parameters of child class")]
  public GameObject BodyExplosion_FX;

  protected override void OnCollisionEnter(Collision col)
  {
    if (this.IsPooling)
      this.Destroy(this.gameObject);
    else
      Object.Destroy((Object) this.gameObject, 0.1f);
    switch (LayerMask.LayerToName(col.gameObject.layer))
    {
      case "EnemyPlane":
      case "EnemyTank":
        if (!((Object) this.Explosion != (Object) null))
          break;
        Object.Instantiate<GameObject>(this.Explosion, this.transform.position, this.transform.rotation);
        break;
      case "EnemySoldier":
        if (!((Object) this.BodyExplosion_FX != (Object) null))
          break;
        Object.Instantiate<GameObject>(this.BodyExplosion_FX, this.transform.position, this.transform.rotation);
        break;
      default:
        if (!((Object) this.Explosion != (Object) null))
          break;
        Object.Instantiate<GameObject>(this.Explosion, this.transform.position, this.transform.rotation);
        break;
    }
  }
}
