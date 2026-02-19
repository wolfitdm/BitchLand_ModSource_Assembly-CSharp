// Decompiled with JetBrains decompiler
// Type: LaunchMissile
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class LaunchMissile : MonoBehaviour
{
  [Tooltip("Target Transform")]
  public Transform Target;
  [Tooltip("Missile to instantiate")]
  public Missile Missile;
  [Tooltip("Position for missile to launch")]
  public Transform[] LaunchSpot;
  [Tooltip("Missile Fire Rate / how frequently to launch the missile")]
  public float MissileFireRate;
  private bool Fire;
  private float nextlaunch;

  private void Update()
  {
    this.Fire = Input.GetKey(KeyCode.LeftShift);
    if (!this.Fire || (double) Time.time < (double) this.nextlaunch)
      return;
    this.nextlaunch = Time.time + this.MissileFireRate;
    this.FireMissile();
  }

  private void FireMissile()
  {
    for (int index = 0; index < this.LaunchSpot.Length; ++index)
      Object.Instantiate<Missile>(this.Missile, this.LaunchSpot[index].position, this.LaunchSpot[index].rotation).Target = this.Target;
  }
}
