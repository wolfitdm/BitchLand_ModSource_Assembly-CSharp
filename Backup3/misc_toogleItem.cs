// Decompiled with JetBrains decompiler
// Type: misc_toogleItem
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
