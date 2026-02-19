// Decompiled with JetBrains decompiler
// Type: Int_Door
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Int_Door : int_Lockable
{
  public Animation Anim;
  public bool Open;
  public string OpenDoorText = "Open Door";
  public string CloseDoorText = "Close Door";
  public bool StartOpened;
  public Int_Door DoubleDoor;

  public override void Start()
  {
    if (this.StartOpened)
    {
      this.Open = true;
      this.Anim["DoorAnim1"].speed = 1f;
      this.Anim.Play();
      this.InteractText = this.CloseDoorText;
    }
    this.enabled = false;
    base.Start();
  }

  public override void OnLocked()
  {
    base.OnLocked();
    if (!((Object) this.Audio != (Object) null))
      return;
    this.Audio.clip = Main.Instance.DoorLock;
    this.Audio.Play();
  }

  public override void OnUnlocked()
  {
    base.OnUnlocked();
    if (!((Object) this.Audio != (Object) null))
      return;
    this.Audio.clip = Main.Instance.DoorUnLock;
    this.Audio.Play();
  }

  public override void Interact(Person person)
  {
    base.Interact(person);
    if (this.Locked)
    {
      if (!((Object) this.Audio != (Object) null))
        return;
      this.Audio.clip = Main.Instance.DoorLocked;
      this.Audio.Play();
    }
    else if (!this.Open)
      this.OpenDoor();
    else
      this.CloseDoor();
  }

  public void Update()
  {
    if (this.Anim.isPlaying)
      return;
    if ((Object) this.Audio != (Object) null)
    {
      this.Audio.clip = Main.Instance.DoorClose;
      this.Audio.Play();
    }
    this.enabled = false;
  }

  public void OpenDoor()
  {
    if (this.Open)
      return;
    this.Open = true;
    this.Anim["DoorAnim1"].speed = 1f;
    this.Anim.Play();
    this.InteractText = this.CloseDoorText;
    if ((Object) this.Audio != (Object) null)
    {
      this.Audio.clip = Main.Instance.DoorMove;
      this.Audio.Play();
    }
    if (!((Object) this.DoubleDoor != (Object) null))
      return;
    this.DoubleDoor.OpenDoor();
  }

  public void CloseDoor()
  {
    if (!this.Open)
      return;
    this.Open = false;
    this.Anim.Play();
    this.Anim["DoorAnim1"].time = this.Anim["DoorAnim1"].length - 0.1f;
    this.Anim["DoorAnim1"].speed = -1f;
    this.InteractText = this.OpenDoorText;
    if ((Object) this.Audio != (Object) null)
    {
      this.Audio.clip = Main.Instance.DoorMove;
      this.Audio.Play();
    }
    if ((Object) this.DoubleDoor != (Object) null)
      this.DoubleDoor.CloseDoor();
    this.enabled = true;
  }
}
