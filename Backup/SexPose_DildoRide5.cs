// Decompiled with JetBrains decompiler
// Type: SexPose_DildoRide5
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

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
