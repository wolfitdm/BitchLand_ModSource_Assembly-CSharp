// Decompiled with JetBrains decompiler
// Type: bl_misc_UIBlink
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class bl_misc_UIBlink : MonoBehaviour
{
  public Image ThisImage;

  private void Update()
  {
    this.ThisImage.color = new Color(1f, 1f, 1f, Mathf.PingPong(Time.time / 4f, 0.25f) + 0.75f);
  }
}
