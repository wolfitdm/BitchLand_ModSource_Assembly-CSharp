// Decompiled with JetBrains decompiler
// Type: MortarAction
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class MortarAction : MonoBehaviour
{
  private AudioSource myAudio;
  public ParticleSystem[] gunFx;
  public AudioClip fireSound;
  public Rigidbody mortarPrefab;
  public Transform mortarBarrelEnd;
  public float shellVelocity = 1000f;
  public float azmuthSlop = 10f;
  private Quaternion originalBarrelEndRot;
  public float velocitySlop = 1f;

  private void Start()
  {
    this.myAudio = this.GetComponent<AudioSource>();
    this.originalBarrelEndRot = this.mortarBarrelEnd.rotation;
  }

  public void Fire()
  {
    this.myAudio.clip = this.fireSound;
    this.myAudio.loop = false;
    this.myAudio.Play();
    foreach (ParticleSystem particleSystem in this.gunFx)
      particleSystem.Play();
    this.ShootMortarRound();
  }

  public void ShootMortarRound()
  {
    this.shellVelocity += Random.Range(-this.velocitySlop, this.velocitySlop);
    this.mortarBarrelEnd.rotation *= Quaternion.Euler(Random.Range(-this.azmuthSlop, this.azmuthSlop), Random.Range(-this.azmuthSlop, this.azmuthSlop), 0.0f);
    Object.Instantiate<Rigidbody>(this.mortarPrefab, this.mortarBarrelEnd.position, this.mortarBarrelEnd.rotation).AddForce(this.mortarBarrelEnd.forward * this.shellVelocity);
    this.mortarBarrelEnd.rotation = this.originalBarrelEndRot;
  }
}
