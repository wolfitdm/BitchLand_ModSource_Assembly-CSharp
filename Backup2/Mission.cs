// Decompiled with JetBrains decompiler
// Type: Mission
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Mission : MonoBehaviour
{
  public string Title;
  public bool CompletedMission;
  public List<MissionGoal> Goals = new List<MissionGoal>();
  public MissionGoal CurrentGoal;
  public int CurrentGoalIndex;
  public bool _Inited;

  public virtual void InitMission() => this._Inited = true;

  public void CompleteGoal(int goal, bool showPermanent = false)
  {
    Debug.Log((object) ("CompleteGoal> " + goal.ToString()));
    this.Goals[goal].Completed = true;
    Main.Instance.GameplayMenu.DisplayGoal(this.Goals[goal], showPermanent);
  }

  public void FailGoal(int goal, bool showPermanent = false)
  {
    Debug.Log((object) ("FailGoal> " + goal.ToString()));
    this.Goals[goal].Failed = true;
    Main.Instance.GameplayMenu.DisplayGoal(this.Goals[goal], showPermanent);
  }

  public void AddGoal(int goal, bool showPermanent = false)
  {
    Debug.Log((object) ("AddGoal> " + goal.ToString()));
    this.Goals[goal].Completed = false;
    this.Goals[goal].Failed = false;
    this.CurrentGoal = this.Goals[goal];
    this.CurrentGoalIndex = goal;
    Main.Instance.GameplayMenu.DisplayGoal(this.Goals[goal], showPermanent);
  }

  public virtual void CompleteMission()
  {
    this.CompletedMission = true;
    Main.Instance.GameplayMenu.CompleteMission(this);
  }

  public virtual void FailMission() => Main.Instance.GameplayMenu.FailMission(this);
}
