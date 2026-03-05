// Decompiled with JetBrains decompiler
// Type: testasdasd
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
