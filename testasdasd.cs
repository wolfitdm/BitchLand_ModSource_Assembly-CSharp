// Decompiled with JetBrains decompiler
// Type: testasdasd
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class testasdasd : MonoBehaviour
{
  public Animator Anim;
  public string AnimToTest;

  private void Start() => this.Anim.Play(this.AnimToTest);

  private void Update()
  {
    if (!Input.GetKeyUp(KeyCode.V))
      return;
    this.Anim.Play(this.AnimToTest);
  }
}
