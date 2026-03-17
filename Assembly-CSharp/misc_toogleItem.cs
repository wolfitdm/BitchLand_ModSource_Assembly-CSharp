// Decompiled with JetBrains decompiler
// Type: misc_toogleItem
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
