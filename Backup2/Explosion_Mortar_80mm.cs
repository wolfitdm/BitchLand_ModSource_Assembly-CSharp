// Decompiled with JetBrains decompiler
// Type: Explosion_Mortar_80mm
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Explosion_Mortar_80mm : MonoBehaviour
{
  public AudioClip explosionSound;
  private AudioSource myAudio;
  public float lowPitchRange = 0.75f;
  public float highPitchRange = 1.5f;
  public GameObject crater;
  public Transform craterLocation;

  private void Awake()
  {
    this.myAudio = this.GetComponent<AudioSource>();
    Object.Destroy((Object) this.gameObject, 8f);
  }

  private void Start()
  {
    if ((Object) this.crater != (Object) null)
      this.Invoke("PlaceCrater", 0.3f);
    this.myAudio.clip = this.explosionSound;
    this.myAudio.pitch = Random.Range(this.lowPitchRange, this.highPitchRange);
    this.myAudio.Play();
  }

  private void PlaceCrater()
  {
    Object.Instantiate<GameObject>(this.crater, this.craterLocation.position, Quaternion.identity);
  }
}
