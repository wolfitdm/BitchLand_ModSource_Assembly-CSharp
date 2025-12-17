// Decompiled with JetBrains decompiler
// Type: int_MoveableDoor
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class int_MoveableDoor : int_Lockable
{
  public Transform Target;
  public Transform DefaultPos;
  public Transform OpenPos;
  public bool Opened;

  public override void Interact(Person person)
  {
    if (this.Locked)
      return;
    Transform transform = this.Opened ? this.DefaultPos : this.OpenPos;
    this.Opened = !this.Opened;
    this.Target.SetPositionAndRotation(transform.position, transform.rotation);
    if (this.Opened)
    {
      for (int index = 0; index < this.DeactivateOnInteract.Length; ++index)
        this.DeactivateOnInteract[index].SetActive(false);
      for (int index = 0; index < this.ActivateOnInteract.Length; ++index)
        this.ActivateOnInteract[index].SetActive(true);
    }
    else
    {
      for (int index = 0; index < this.DeactivateOnInteract.Length; ++index)
        this.DeactivateOnInteract[index].SetActive(true);
      for (int index = 0; index < this.ActivateOnInteract.Length; ++index)
        this.ActivateOnInteract[index].SetActive(false);
    }
  }
}
