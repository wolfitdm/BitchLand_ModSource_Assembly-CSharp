// Decompiled with JetBrains decompiler
// Type: VariableInventorySystem.StandardButton
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
namespace VariableInventorySystem;

public class StandardButton : Button, IVariableInventoryCellActions
{
  private Action onPointerClick;
  private Action onPointerOptionClick;
  private Action onPointerEnter;
  private Action onPointerExit;
  private Action onPointerDown;
  private Action onPointerUp;
  private Coroutine longPointerCoroutine;

  public void SetActive(bool value)
  {
    this.enabled = value;
    foreach (Graphic componentsInChild in this.GetComponentsInChildren<Graphic>())
      componentsInChild.raycastTarget = value;
  }

  public void SetCallback(Action onPointerClick) => this.onPointerClick = onPointerClick;

  public void SetCallback(
    Action onPointerClick,
    Action onPointerOptionClick,
    Action onPointerEnter,
    Action onPointerExit,
    Action onPointerDown,
    Action onPointerUp)
  {
    this.onPointerClick = onPointerClick;
    this.onPointerOptionClick = onPointerOptionClick;
    this.onPointerEnter = onPointerEnter;
    this.onPointerExit = onPointerExit;
    this.onPointerDown = onPointerDown;
    this.onPointerUp = onPointerUp;
  }

  public override void OnPointerClick(PointerEventData eventData)
  {
    base.OnPointerClick(eventData);
    if (eventData.button == PointerEventData.InputButton.Left)
    {
      Action onPointerClick = this.onPointerClick;
      if (onPointerClick == null)
        return;
      onPointerClick();
    }
    else
    {
      Action pointerOptionClick = this.onPointerOptionClick;
      if (pointerOptionClick == null)
        return;
      pointerOptionClick();
    }
  }

  public override void OnPointerEnter(PointerEventData eventData)
  {
    base.OnPointerEnter(eventData);
    Action onPointerEnter = this.onPointerEnter;
    if (onPointerEnter == null)
      return;
    onPointerEnter();
  }

  public override void OnPointerExit(PointerEventData eventData)
  {
    base.OnPointerExit(eventData);
    Action onPointerExit = this.onPointerExit;
    if (onPointerExit == null)
      return;
    onPointerExit();
  }

  public override void OnPointerDown(PointerEventData eventData)
  {
    base.OnPointerDown(eventData);
    Action onPointerDown = this.onPointerDown;
    if (onPointerDown == null)
      return;
    onPointerDown();
  }

  public override void OnPointerUp(PointerEventData eventData)
  {
    base.OnPointerUp(eventData);
    Action onPointerUp = this.onPointerUp;
    if (onPointerUp == null)
      return;
    onPointerUp();
  }
}
