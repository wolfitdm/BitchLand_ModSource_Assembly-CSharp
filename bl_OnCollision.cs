// Decompiled with JetBrains decompiler
// Type: bl_OnCollision
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class bl_OnCollision : MonoBehaviour
{
  public AudioSource Audio;
  public AudioClip[] Clips;

  public void OnCollisionEnter(Collision collision)
  {
    if ((double) collision.relativeVelocity.magnitude <= 1.0)
      return;
    this.Audio.PlayOneShot(this.Clips[Random.Range(0, this.Clips.Length)]);
  }
}
