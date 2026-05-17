// Decompiled with JetBrains decompiler
// Type: bl_DropdownOpenListener
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
