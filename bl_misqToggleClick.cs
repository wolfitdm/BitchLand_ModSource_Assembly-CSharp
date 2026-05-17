// Decompiled with JetBrains decompiler
// Type: bl_misqToggleClick
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
