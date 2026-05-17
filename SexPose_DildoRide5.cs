// Decompiled with JetBrains decompiler
// Type: SexPose_DildoRide5
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DAC2C327-70D4-472B-9503-C9271148CB13
// Assembly location: E:\Bitchland11e2_PreinstalledMods\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class SexPose_DildoRide5 : SexPose
{
  public Vector3 Pos;
  public Vector3 Rot;

  public override void SexPoseStart()
  {
    base.SexPoseStart();
    this.RefreshDildo();
    Main.RunInNextFrame(new Action(this.PosiotinPerson));
    Main.RunInNextFrame(new Action(this.PosiotinPerson), 5);
  }

  public override void RefreshDildo()
  {
    base.RefreshDildo();
    this.ThisDildo.RootObj.transform.SetParent(this.ThisScene.SpawnedSexSceneStructure);
    this.ThisDildo.RootObj.transform.SetLocalPositionAndRotation(this.Pos, Quaternion.Euler(this.Rot));
  }

  public void PosiotinPerson()
  {
    this.Person1.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.Euler(Vector3.zero));
    if (!((UnityEngine.Object) this.Person1.transform != (UnityEngine.Object) this.Person1.Anim.transform))
      return;
    this.Person1.Anim.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.Euler(Vector3.zero));
  }
}
