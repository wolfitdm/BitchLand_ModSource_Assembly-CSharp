// Decompiled with JetBrains decompiler
// Type: Mission
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2DEADBA5-E10A-4E88-A1ED-0D4DF3F1CF20
// Assembly location: E:\sw_games\build11_0\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
