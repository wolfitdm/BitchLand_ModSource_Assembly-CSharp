// Decompiled with JetBrains decompiler
// Type: testasdasd
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
