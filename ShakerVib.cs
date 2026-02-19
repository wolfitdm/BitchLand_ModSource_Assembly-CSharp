// Decompiled with JetBrains decompiler
// Type: ShakerVib
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class ShakerVib : MonoBehaviour
{
  public AudioSource VibSound;
  public bool EnableOnStart;
  public Rigidbody[] Parts;
  public Vector3 Amount;
  public float MaxTimer = 0.02f;
  private float Timer;
  private bool Fliper;

  public void Enable(bool value)
  {
    if ((Object) this.VibSound != (Object) null)
      this.VibSound.enabled = value;
    for (int index = 0; index < this.Parts.Length; ++index)
    {
      if ((Object) this.Parts[index] != (Object) null)
        this.Parts[index].isKinematic = false;
    }
  }

  private void Start() => this.Enable(this.EnableOnStart);

  private void Update()
  {
    this.Timer -= Time.deltaTime;
    if ((double) this.Timer > 0.0)
      return;
    this.Timer = this.MaxTimer;
    this.Fliper = !this.Fliper;
    if (this.Fliper)
      this.transform.localPosition += this.Amount;
    else
      this.transform.localPosition -= this.Amount;
  }
}
