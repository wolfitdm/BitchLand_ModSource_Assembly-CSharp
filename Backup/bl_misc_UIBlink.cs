// Decompiled with JetBrains decompiler
// Type: bl_misc_UIBlink
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
