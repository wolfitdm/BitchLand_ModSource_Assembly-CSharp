// Decompiled with JetBrains decompiler
// Type: bl_misc_UIBlink
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
