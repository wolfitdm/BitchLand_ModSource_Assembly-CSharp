// Decompiled with JetBrains decompiler
// Type: TeleportDoor
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
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
      if (person.IsPlayer)
      {
        for (int index = 0; index < Main.Instance.PeopleFollowingPlayer.Count; ++index)
        {
          Person _pp = Main.Instance.PeopleFollowingPlayer[index];
          _pp.AddMoveBlocker("teleporting");
          Main.RunInNextFrame((Action) (() =>
          {
            _pp.PlaceAt(this.PositionToTp);
            _pp.RemoveMoveBlocker("teleporting");
          }), 2);
        }
      }
      for (int index = 0; index < this.ActivateOnInteract.Length; ++index)
        this.ActivateOnInteract[index].SetActive(true);
      for (int index = 0; index < this.DeactivateOnInteract.Length; ++index)
        this.DeactivateOnInteract[index].SetActive(false);
      for (int index = 0; index < this.ScriptToRun_OnInteract.Length; ++index)
        this.ScriptToRun_OnInteract[index].Invoke(this.ScriptFunctionToRun_OnInteract[index], 0.0f);
      if (!((UnityEngine.Object) this.MapArea != (UnityEngine.Object) null))
        return;
      if (this.AreaEnter)
        this.MapArea.OnEnter();
      else
        this.MapArea.OnLeave();
    }
  }
}
