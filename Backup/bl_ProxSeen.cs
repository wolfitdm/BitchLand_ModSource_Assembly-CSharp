// Decompiled with JetBrains decompiler
// Type: bl_ProxSeen
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class bl_ProxSeen : MonoBehaviour
{
  public float TimeOut;
  public List<string> Enablers = new List<string>();
  public bool IsPlayer;
  public List<string> Blockers = new List<string>();

  public void AddEnabler(string enablerID)
  {
    if (this.Enablers.Contains(enablerID))
      return;
    this.Enablers.Add(enablerID);
  }

  public void RemoveEnabler(string enablerID)
  {
    if (!this.Enablers.Contains(enablerID))
      return;
    this.Enablers.Remove(enablerID);
  }

  public bool HasEnabler(string enablerID) => this.Enablers.Contains(enablerID);

  public void AddBlocker(string blockerID)
  {
    if (this.Blockers.Contains(blockerID))
      return;
    this.Blockers.Add(blockerID);
  }

  public void RemoveBlocker(string blockerID)
  {
    if (!this.Blockers.Contains(blockerID))
      return;
    this.Blockers.Remove(blockerID);
  }

  public bool HasBlocker(string blockerID) => this.Blockers.Contains(blockerID);

  public bool IsBlocked() => this.Blockers.Count != 0 || this.Enablers.Count == 0;

  public void OnTriggerEnter(Collider other)
  {
    if (this.IsBlocked() || (double) this.TimeOut > 0.0)
      return;
    Person component = other.transform.root.GetComponent<Person>();
    if (!((UnityEngine.Object) component != (UnityEngine.Object) null) || !((UnityEngine.Object) component.ProxSeen != (UnityEngine.Object) null) || (UnityEngine.Object) component.ProxSeen == (UnityEngine.Object) this || component.ProxSeen.IsPlayer)
      return;
    component.Seen(this.transform.parent.gameObject);
  }

  public void Update()
  {
    if (this.IsBlocked())
      return;
    if ((double) this.TimeOut > 0.0)
      this.TimeOut -= Time.deltaTime;
    else
      this.TimeOut = 0.0f;
  }

  [Obsolete]
  public void Hide()
  {
  }

  [Obsolete]
  public void Show(float timeOut = 0.0f) => this.TimeOut = timeOut;
}
