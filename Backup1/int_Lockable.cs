// Decompiled with JetBrains decompiler
// Type: int_Lockable
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

#nullable disable
public class int_Lockable : Interactible
{
  public NavMeshObstacle Obstacle;
  public bool StartLocked;
  public bool PlayerOwned;
  public AudioSource Audio;
  public bool DEBUG_LOCKLOG;
  public e_KeyNames KeyID;
  public bool m_Locked;

  public override bool CheckCanInteract(Person person)
  {
    if (person.IsPlayer)
      return base.CheckCanInteract(person);
    return !this.Locked && base.CheckCanInteract(person);
  }

  public override void Start()
  {
    base.Start();
    if (this.DEBUG_LOCKLOG)
      Debug.LogWarning((object) "StartLocked will run");
    if (!this.StartLocked)
      return;
    this.Locked = true;
  }

  public void GenerateKeyID()
  {
  }

  public override bool CanInteract
  {
    get => Main.Instance.ScatContent || !this.ScatInteractible;
    set => base.CanInteract = value;
  }

  public bool Locked
  {
    get => this.m_Locked;
    set
    {
      this.m_Locked = value;
      if ((UnityEngine.Object) this.Obstacle != (UnityEngine.Object) null)
      {
        this.Obstacle.carving = value;
        this.Obstacle.enabled = value;
      }
      if (this.m_Locked)
      {
        this.InteractIcon = 1;
        if (!this.InteractText.Contains(" (Locked"))
        {
          if (this.KeyID != e_KeyNames.None)
            this.InteractText = this.InteractText + " (Locked - " + Main.Instance.DoorKeysNames[(int) this.KeyID] + ")";
          else
            this.InteractText += " (Locked)";
        }
        if ((UnityEngine.Object) this._RunningForSecs != (UnityEngine.Object) null)
        {
          this._RunningForSecs.Stop();
          this._RunningForSecs = (Main._runinseconds) null;
        }
        if ((UnityEngine.Object) this.InteractingPerson != (UnityEngine.Object) null)
          this.InteractingPerson.StopFollowing();
        this.OnLocked();
      }
      else
      {
        this.InteractIcon = this.DefaultInteractIcon;
        if (this.InteractText.Contains(" (Locked"))
        {
          if (this.KeyID != e_KeyNames.None)
            this.InteractText = this.InteractText.Replace(" (Locked - " + Main.Instance.DoorKeysNames[(int) this.KeyID] + ")", string.Empty);
          else
            this.InteractText = this.InteractText.Replace(" (Locked)", string.Empty);
        }
        if ((double) this.DoForSeconds != 0.0)
          this._RunningForSecs = Main.RunInSeconds((Action) (() => this.StopInteracting()), this.DoForSeconds);
        this.OnUnlocked();
        if (!((UnityEngine.Object) this.InteractingPerson != (UnityEngine.Object) null))
          return;
        this.StopInteracting();
      }
    }
  }

  public virtual void OnLocked()
  {
    if (!((UnityEngine.Object) this.Audio != (UnityEngine.Object) null))
      return;
    this.Audio.clip = Main.Instance.DoorLock;
    this.Audio.Play();
  }

  public virtual void OnUnlocked()
  {
    if (!((UnityEngine.Object) this.Audio != (UnityEngine.Object) null))
      return;
    this.Audio.clip = Main.Instance.DoorUnLock;
    this.Audio.Play();
  }

  public override string[] sd_SaveData(char SlitChar = ':')
  {
    List<string> stringList = new List<string>();
    string[] collection = base.sd_SaveData(SlitChar);
    if (collection != null)
      stringList.AddRange((IEnumerable<string>) collection);
    stringList.Add(this.Locked ? "1" : "0");
    stringList.Add(this.PlayerOwned ? "1" : "0");
    return stringList.ToArray();
  }

  public override void sd_LoadData(string[] Data, char SlitChar = ':')
  {
    base.sd_LoadData(Data, SlitChar);
    if (this.DEBUG_LOCKLOG)
      Debug.LogWarning((object) "Lock state is being loaded");
    this.Locked = Data[this._CurrentLoadingIndex++] == "1";
    this.PlayerOwned = Data[this._CurrentLoadingIndex++] == "1";
  }
}
