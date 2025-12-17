// Decompiled with JetBrains decompiler
// Type: TeleportDoor
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class TeleportDoor : int_Lockable
{
  public Transform PositionToTp;
  public BL_MapArea MapArea;
  public bool AreaEnter;

  public override void Interact(Person person)
  {
    if (this.Locked)
    {
      Main.Instance.Player.PersonAudio.PlayOneShot(Main.Instance.DoorLocked);
    }
    else
    {
      Main.Instance.Player.PersonAudio.PlayOneShot(Main.Instance.DoorMove);
      person.transform.position = this.PositionToTp.position;
      person.transform.rotation = this.PositionToTp.rotation;
      for (int index = 0; index < this.ActivateOnInteract.Length; ++index)
        this.ActivateOnInteract[index].SetActive(true);
      for (int index = 0; index < this.DeactivateOnInteract.Length; ++index)
        this.DeactivateOnInteract[index].SetActive(false);
      for (int index = 0; index < this.ScriptToRun_OnInteract.Length; ++index)
        this.ScriptToRun_OnInteract[index].Invoke(this.ScriptFunctionToRun_OnInteract[index], 0.0f);
      if (!((Object) this.MapArea != (Object) null))
        return;
      if (this.AreaEnter)
        this.MapArea.OnEnter();
      else
        this.MapArea.OnLeave();
    }
  }
}
