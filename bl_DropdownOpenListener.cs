// Decompiled with JetBrains decompiler
// Type: bl_DropdownOpenListener
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D722A332-18BD-4C4F-854C-859C1C1AE1E7
// Assembly location: E:\sw_games\Bitchland_11c_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.EventSystems;

#nullable disable
public class bl_DropdownOpenListener : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
  public event bl_DropdownOpenListener.DropdownOpened OnDropdownOpened;

  public void OnPointerClick(PointerEventData eventData)
  {
    bl_DropdownOpenListener.DropdownOpened onDropdownOpened = this.OnDropdownOpened;
    if (onDropdownOpened == null)
      return;
    onDropdownOpened();
  }

  public delegate void DropdownOpened();
}
