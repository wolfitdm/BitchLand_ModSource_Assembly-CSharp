// Decompiled with JetBrains decompiler
// Type: bl_misqToggleClick
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class bl_misqToggleClick : MonoBehaviour
{
  public int Index;
  public Toggle TheToggle;
  public Action<bool, int> OnClick;

  public void Click() => this.OnClick(this.TheToggle.isOn, this.Index);
}
