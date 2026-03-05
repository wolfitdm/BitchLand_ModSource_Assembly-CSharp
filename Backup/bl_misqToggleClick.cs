// Decompiled with JetBrains decompiler
// Type: bl_misqToggleClick
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
