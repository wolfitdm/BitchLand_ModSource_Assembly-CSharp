// Decompiled with JetBrains decompiler
// Type: misc_toogleItem
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class misc_toogleItem : MonoBehaviour
{
  public Toggle TheToggle;
  public Text TheText;
  public int Index;
  public Action<bool, int> TheAction;

  public void OnClick()
  {
    if (this.TheAction == null)
      return;
    this.TheAction(this.TheToggle.isOn, this.Index);
  }
}
