// Decompiled with JetBrains decompiler
// Type: bl_DropdownHandler
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class bl_DropdownHandler : MonoBehaviour
{
  public Dropdown dropdown;

  public event bl_DropdownHandler.DropdownOpened OnDropdownOpened;

  private void Start()
  {
    if (!((Object) this.dropdown != (Object) null))
      return;
    this.dropdown.gameObject.AddComponent<bl_DropdownOpenListener>().OnDropdownOpened += new bl_DropdownOpenListener.DropdownOpened(this.HandleDropdownOpened);
  }

  private void HandleDropdownOpened()
  {
    bl_DropdownHandler.DropdownOpened onDropdownOpened = this.OnDropdownOpened;
    if (onDropdownOpened == null)
      return;
    onDropdownOpened();
  }

  public delegate void DropdownOpened();
}
