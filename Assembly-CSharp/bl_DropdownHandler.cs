// Decompiled with JetBrains decompiler
// Type: bl_DropdownHandler
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
