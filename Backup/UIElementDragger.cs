// Decompiled with JetBrains decompiler
// Type: UIElementDragger
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class UIElementDragger : MonoBehaviour
{
  public const string DRAGGABLE_TAG = "UIDrag";
  private bool dragging;
  private Vector2 originalPosition;
  private Transform objectToDrag;
  private Image objecttoDragImage;
  private List<RaycastResult> hitObjects = new List<RaycastResult>();

  private void Update()
  {
    if (Input.GetButtonDown("Fire"))
    {
      this.objectToDrag = this.GetDraggableTransformUnderMouse();
      if ((Object) this.objectToDrag != (Object) null)
      {
        this.dragging = true;
        this.originalPosition = (Vector2) this.objectToDrag.position;
        this.objecttoDragImage = this.objectToDrag.GetComponent<Image>();
        this.objecttoDragImage.raycastTarget = false;
      }
    }
    if (this.dragging)
      this.objectToDrag.position = Input.mousePosition;
    if (!Input.GetButtonUp("Fire") || !this.dragging)
      return;
    this.dragging = false;
    this.objecttoDragImage.raycastTarget = true;
  }

  private GameObject GetObjectUnderMouse()
  {
    EventSystem.current.RaycastAll(new PointerEventData(EventSystem.current)
    {
      position = (Vector2) Input.mousePosition
    }, this.hitObjects);
    return this.hitObjects.Count <= 0 ? (GameObject) null : this.hitObjects.First<RaycastResult>().gameObject;
  }

  private Transform GetDraggableTransformUnderMouse()
  {
    GameObject objectUnderMouse = this.GetObjectUnderMouse();
    return (Object) objectUnderMouse != (Object) null && objectUnderMouse.tag == "UIDrag" ? objectUnderMouse.transform : (Transform) null;
  }
}
