// Decompiled with JetBrains decompiler
// Type: misc_toogleItem
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
