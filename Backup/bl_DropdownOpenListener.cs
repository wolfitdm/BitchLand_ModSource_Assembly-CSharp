// Decompiled with JetBrains decompiler
// Type: bl_DropdownOpenListener
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 34432851-88D2-4640-8704-0D81AB8DF51E
// Assembly location: E:\sw_games\11_5\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
