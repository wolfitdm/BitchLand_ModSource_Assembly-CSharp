// Decompiled with JetBrains decompiler
// Type: misc_toogleItem
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
