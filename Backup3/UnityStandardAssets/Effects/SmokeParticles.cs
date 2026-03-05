// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Effects.SmokeParticles
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace UnityStandardAssets.Effects
{
  public class SmokeParticles : MonoBehaviour
  {
    public AudioClip[] extinguishSounds;

    private void Start()
    {
      this.GetComponent<AudioSource>().clip = this.extinguishSounds[Random.Range(0, this.extinguishSounds.Length)];
      this.GetComponent<AudioSource>().Play();
    }
  }
}
