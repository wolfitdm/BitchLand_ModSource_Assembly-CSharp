// Decompiled with JetBrains decompiler
// Type: bl_OnCollision
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
