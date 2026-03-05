// Decompiled with JetBrains decompiler
// Type: bl_misc_UIBlink
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
