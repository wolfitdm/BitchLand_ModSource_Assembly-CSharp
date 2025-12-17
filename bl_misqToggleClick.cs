// Decompiled with JetBrains decompiler
// Type: bl_misqToggleClick
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
