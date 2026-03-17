// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Effects.SmokeParticles
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
