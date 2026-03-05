// Decompiled with JetBrains decompiler
// Type: SmallProjectile
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SmallProjectile : AntiMissileProjectile
{
  [Header("Child class")]
  [Tooltip("parameters of child class")]
  public GameObject Blood_FX;
  public GameObject Dirt_FX;

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
        if (!((Object) this.Dirt_FX != (Object) null))
          break;
        Object.Instantiate<GameObject>(this.Dirt_FX, this.transform.position, this.transform.rotation);
        break;
      case "EnemySoldier":
        if (!((Object) this.Blood_FX != (Object) null))
          break;
        Object.Instantiate<GameObject>(this.Blood_FX, this.transform.position, this.transform.rotation);
        break;
      default:
        if (!((Object) this.Dirt_FX != (Object) null))
          break;
        Object.Instantiate<GameObject>(this.Dirt_FX, this.transform.position, this.transform.rotation);
        break;
    }
  }
}
