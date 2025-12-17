// Decompiled with JetBrains decompiler
// Type: int_Lockable
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

#nullable disable
public class int_Lockable : Interactible
{
  public NavMeshObstacle Obstacle;
  public bool StartLocked;
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

  public bool Locked
  {
    get => this.m_Locked;
    set
    {
      this.m_Locked = value;
      int num = (Object) this.Obstacle != (Object) null ? 1 : 0;
      if (this.m_Locked)
      {
        this.InteractIcon = 1;
        if (!this.InteractText.Contains(" (Locked"))
        {
          if (this.KeyID != e_KeyNames.None)
            this.InteractText = $"{this.InteractText} (Locked - {Main.Instance.DoorKeysNames[(int) this.KeyID]})";
          else
            this.InteractText += " (Locked)";
        }
        this.OnLocked();
      }
      else
      {
        this.InteractIcon = this.DefaultInteractIcon;
        if (this.InteractText.Contains(" (Locked"))
        {
          if (this.KeyID != e_KeyNames.None)
            this.InteractText = this.InteractText.Replace($" (Locked - {Main.Instance.DoorKeysNames[(int) this.KeyID]})", string.Empty);
          else
            this.InteractText = this.InteractText.Replace(" (Locked)", string.Empty);
        }
        this.OnUnlocked();
      }
    }
  }

  public virtual void OnLocked()
  {
  }

  public virtual void OnUnlocked()
  {
  }

  public override string[] sd_SaveData(char SlitChar = ':')
  {
    List<string> stringList = new List<string>();
    string[] collection = base.sd_SaveData(SlitChar);
    if (collection != null)
      stringList.AddRange((IEnumerable<string>) collection);
    stringList.Add(this.Locked ? "1" : "0");
    return stringList.ToArray();
  }

  public override void sd_LoadData(string[] Data, char SlitChar = ':')
  {
    base.sd_LoadData(Data, SlitChar);
    if (this.DEBUG_LOCKLOG)
      Debug.LogWarning((object) "Lock state is being loaded");
    this.Locked = Data[this._CurrentLoadingIndex++] == "1";
  }
}
