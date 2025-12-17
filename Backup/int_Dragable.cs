// Decompiled with JetBrains decompiler
// Type: int_Dragable
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class int_Dragable : Interactible
{
  public string BodyPartName;
  public GameObject DragSpot;
  public bool CanAttatch = true;

  public int_Dragable() => this.InteractText = "Drag ";

  public override void Interact(Person person)
  {
    Debug.Log((object) "Dragable Interact");
    if ((Object) this.DragSpot != (Object) null)
      Object.Destroy((Object) this.DragSpot);
    this.enabled = true;
    base.Interact(person);
    if ((double) this.CarryWeight > (double) person.Strength)
    {
      person.AddRunBlocker("DraggingPerson");
      Main.Instance.GameplayMenu.ShowNotification("Can't run while carrying this");
    }
    this.DragSpot = new GameObject();
    this.DragSpot.transform.SetParent(person.ViewPoint.transform);
    this.DragSpot.transform.position = this.RootObj.transform.position;
    this.DragSpot.transform.localEulerAngles = Vector3.zero;
    this.DragSpot.AddComponent<Rigidbody>().isKinematic = true;
    this.DragSpot.AddComponent<FixedJoint>().connectedBody = this.RootObj.GetComponent<Rigidbody>();
  }

  public override void StopInteracting()
  {
    Debug.Log((object) nameof (StopInteracting));
    Main.Instance.Player.RemoveRunBlocker("DraggingPerson");
    this.enabled = false;
    base.StopInteracting();
    if (!((Object) this.DragSpot != (Object) null))
      return;
    Object.Destroy((Object) this.DragSpot);
  }

  private void Update()
  {
    float axis = Input.GetAxis("Mouse ScrollWheel");
    bool key1 = Input.GetKey(KeyCode.LeftControl);
    bool key2 = Input.GetKey(KeyCode.LeftShift);
    bool key3 = Input.GetKey(KeyCode.LeftAlt);
    if ((double) axis > 0.0)
    {
      if (key1)
        this.DragSpot.transform.Rotate(new Vector3(10f, 0.0f, 0.0f), Space.Self);
      else if (key2)
        this.DragSpot.transform.Rotate(new Vector3(0.0f, 10f, 0.0f), Space.Self);
      else if (key3)
      {
        this.DragSpot.transform.Rotate(new Vector3(0.0f, 0.0f, 10f), Space.Self);
      }
      else
      {
        this.DragSpot.transform.localPosition += new Vector3(0.0f, 0.0f, 0.05f);
        if ((double) this.DragSpot.transform.localPosition.z <= 1.5)
          return;
        this.DragSpot.transform.localPosition = new Vector3(0.0f, 0.0f, 1.5f);
      }
    }
    else if ((double) axis < 0.0)
    {
      if (key1)
        this.DragSpot.transform.Rotate(new Vector3(-10f, 0.0f, 0.0f), Space.Self);
      else if (key2)
        this.DragSpot.transform.Rotate(new Vector3(0.0f, -10f, 0.0f), Space.Self);
      else if (key3)
      {
        this.DragSpot.transform.Rotate(new Vector3(0.0f, 0.0f, -10f), Space.Self);
      }
      else
      {
        this.DragSpot.transform.localPosition -= new Vector3(0.0f, 0.0f, 0.05f);
        if ((double) this.DragSpot.transform.localPosition.z >= 0.5)
          return;
        this.DragSpot.transform.localPosition = new Vector3(0.0f, 0.0f, 0.5f);
      }
    }
    else if (Input.GetButtonUp("Interact") || Input.GetMouseButtonUp(UI_Settings.RightMouseButton) || Input.GetButtonUp("Drop") || Input.GetKeyUp(KeyCode.Z))
    {
      this.StopInteracting();
    }
    else
    {
      if (!this.CanAttatch || !Input.GetKeyUp(KeyCode.F))
        return;
      Collider[] componentsInChildren = this.transform.root.GetComponentsInChildren<Collider>();
      for (int index = 0; index < componentsInChildren.Length; ++index)
        componentsInChildren[index].gameObject.layer = 2;
      RaycastHit hitInfo;
      if (Physics.Raycast(this.RootObj.transform.position, this.DragSpot.transform.parent.TransformDirection(Vector3.forward), out hitInfo, 0.5f, int.MaxValue))
      {
        this.DragSpot.transform.SetParent(hitInfo.transform, true);
        this.enabled = false;
        base.StopInteracting();
      }
      for (int index = 0; index < componentsInChildren.Length; ++index)
        componentsInChildren[index].gameObject.layer = 0;
    }
  }
}
